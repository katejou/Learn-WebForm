using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project1
{
    public partial class VS_Reply : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // 處理 Query String
                if (Request.QueryString["HEAD"] == null || Request.QueryString["HEAD"] == "")   // 傳值不等於空或無
                {
                    Response.Write("<script>alert('缺少指定 HEAD_SEQID 的 QueryString 參數');</script>");
                    Response.Write("<script>history.back(-1);</script>"); // 回上一頁
                    return;
                }
                else if (!int.TryParse(Request.QueryString["HEAD"].ToString(), out _)) // 傳值不是數字
                {
                    Response.Write("<script>alert('指定 HEAD 的 QueryString 參數不是數字');</script>");
                    Response.Write("<script>history.back(-1);</script>"); // 回上一頁
                    return;
                }
                else
                {
                    ViewState["seqid"] = Request.QueryString["HEAD"].ToString();
                }
            }
        }

        // 新增
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                var seqid = ViewState["seqid"].ToString();

                if (ddl_ACKNOWLEDGMENT_TYPE.SelectedValue == "AD")
                {
                    new DataBaseTrans().Insert_Verizon_855_AD(seqid, out string errMsg);
                    if (!string.IsNullOrEmpty(errMsg))
                    {
                        Helper.ResponseWrite(errMsg, Page); // 資料庫出錯(log已寫)
                        return;
                    }
                }
                else // AC 和 AE 
                {
                    // 取資料
                    DataTable dt = getLVdt();
                    // 驗證
                    verify(dt, out string errMsg);
                    if (!string.IsNullOrEmpty(errMsg))
                    {
                        Helper.ResponseWrite("前端驗證和後端不符", Page);
                        throw new Exception(errMsg);
                    }
                    // 準備資料
                    DataBaseTrans db_trans = new DataBaseTrans();
                    DataTable new_dt = db_trans.VERIZON_850_LINE(seqid, out errMsg);
                    if (!string.IsNullOrEmpty(errMsg))
                    {
                        Helper.ResponseWrite(errMsg, Page);
                        throw new Exception(errMsg);
                    }
                    DataTable merged_dt = merge(seqid, dt, new_dt);
                    // 操作資料庫
                    db_trans.Insert_Verizon_855_AC_AE(seqid, ddl_ACKNOWLEDGMENT_TYPE.SelectedValue, merged_dt, out errMsg);
                    if (!string.IsNullOrEmpty(errMsg))
                    {
                        Helper.ResponseWrite(errMsg, Page); // 資料庫出錯(log已寫)
                        return;
                    }
                }

                // 成功，回查詢頁
                string newUrl = (Request.Url.AbsoluteUri).Replace(Request.RawUrl, "");
                newUrl += "/Query.aspx?Customer=VS&Table=850";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('回覆成功'); window.location='" + newUrl + "';", true);

            }
            catch (Exception ex)
            {
                Helper.WriteLog(ex, "VS_Reply_Error");
            }
        }

        private DataTable getLVdt()
        {

            DataTable table = new DataTable();
            table.Columns.Add("PODETAIL_SEQID");
            table.Columns.Add("MANUFACTURER_ID");
            table.Columns.Add("LINE_ITEM_STATUS_CODE");
            table.Columns.Add("PROMISED_FOR_SHIPMENT_DATE_input");
            table.Columns.Add("PROMISED_FOR_SHIPMENT_DATE_original");
            table.Columns.Add("BACKORDERED_QUANTITY");
            table.Columns.Add("QUANTITY_ORDERED");

            for (int j = 0; j < ListView_Line.Items.Count; j++)
            {
                ArrayList valholder = new ArrayList();
                for (int k = 0; k < ListView_Line.Items[j].Controls.Count; k++)
                {
                    if (ListView_Line.Items[j].Controls[k].GetType() == typeof(Label))
                    {
                        Label tep = ListView_Line.Items[j].Controls[k] as Label;
                        valholder.Add(tep.Text);
                    }
                    if (ListView_Line.Items[j].Controls[k].GetType() == typeof(DropDownList))
                    {
                        DropDownList tep = ListView_Line.Items[j].Controls[k] as DropDownList;
                        valholder.Add(tep.SelectedValue);
                    }
                    if (ListView_Line.Items[j].Controls[k].GetType() == typeof(TextBox))
                    {
                        TextBox tep = ListView_Line.Items[j].Controls[k] as TextBox;
                        valholder.Add(tep.Text);
                    }
                }
                DataRow dr = table.NewRow();
                for (int z = 0; z < valholder.Count; z++)
                {
                    dr[z] = valholder[z].ToString();
                }
                table.Rows.Add(dr);
            }

            return table;
        }

        private void verify(DataTable dt, out string errMsg)
        {
            errMsg = string.Empty;

            foreach (DataRow row in dt.Rows)
            {
                var row_no = row["PODETAIL_SEQID"].ToString();
                var code = row["LINE_ITEM_STATUS_CODE"].ToString();
                var date = row["PROMISED_FOR_SHIPMENT_DATE_input"].ToString();
                var date_original = row["PROMISED_FOR_SHIPMENT_DATE_original"].ToString();
                var quantity = row["BACKORDERED_QUANTITY"].ToString();
                var quantity_limit = row["QUANTITY_ORDERED"].ToString();

                // 必填
                if ((code == "BP" && (date == "" || quantity == "")) || (code == "DR" && date == ""))
                    errMsg += "\n第 " + row_no + " 行的「必填」有問題\n當 LINE_ITEM_STATUS_CODE = " + code + "\nPROMISED_FOR_SHIPMENT_DATE 的輸入 = " + date + "\nBACKORDERED_QUANTITY 的輸入 = " + quantity;
                // 數量
                if (code == "BP" && (quantity == quantity_limit || quantity == "0"))
                    errMsg += "\n第 " + row_no + " 行的「數量」有問題\n當 QUANTITY_ORDERED = " + quantity_limit + "\nBACKORDERED_QUANTITY 的輸入 = " + quantity;
                // 日期
                if (code == "DR" && date == date_original)
                    errMsg += "\n第 " + row_no + " 行的「日期」有問題\n當 LINE_ITEM_STATUS_CODE = " + code + "\nPROMISED_FOR_SHIPMENT_DATE 的輸入等如原本的 : " + date_original;
            }

        }

        private DataTable merge(string seqid, DataTable old_dt, DataTable new_dt)
        {
            // 解除唯讀
            new_dt.Columns["LINE_ITEM_STATUS_CODE"].ReadOnly = false;
            new_dt.Columns["LINE_ITEM_STATUS_CODE"].MaxLength = 2; // 如不設，MaxLength = 0
            new_dt.Columns["PROMISED_FOR_SHIPMENT_DATE"].ReadOnly = false;
            new_dt.Columns["PROMISED_FOR_SHIPMENT_DATE"].MaxLength = 8;
            new_dt.Columns["BACKORDERED_QUANTITY"].ReadOnly = false;
            new_dt.Columns["BACKORDERED_QUANTITY"].MaxLength = 15;

            // 逐行替換
            for (int i = 0; i < new_dt.Rows.Count; i++)
            {
                string code = old_dt.Rows[i]["LINE_ITEM_STATUS_CODE"].ToString();
                new_dt.Rows[i]["LINE_ITEM_STATUS_CODE"] = code;
                if (code == "DR")
                    new_dt.Rows[i]["PROMISED_FOR_SHIPMENT_DATE"] = old_dt.Rows[i]["PROMISED_FOR_SHIPMENT_DATE_input"].ToString();
                if (code == "BP")
                {
                    new_dt.Rows[i]["PROMISED_FOR_SHIPMENT_DATE"] = old_dt.Rows[i]["PROMISED_FOR_SHIPMENT_DATE_input"].ToString();
                    new_dt.Rows[i]["BACKORDERED_QUANTITY"] = old_dt.Rows[i]["BACKORDERED_QUANTITY"].ToString();
                }
            }

            return new_dt;
        }


    }
}