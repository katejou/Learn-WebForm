using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace custom_test
{
    public partial class P3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GenBasicGV();

                try // 不一定是 P2 傳來的
                {
                    P2 p2 = (P2)Context.Handler;
                    ViewState["box_dt"] = Context.Items["box_dt"] as DataTable;
                    ViewState["item_dt"] = Context.Items["item_dt"] as DataTable;
                    ViewState["add_dt"] = Context.Items["add_dt"] as DataTable;
                    ViewState["oth_dt"] = Context.Items["oth_dt"] as DataTable;
                    DataTable inv_dt = Context.Items["inv_dt"] as DataTable;

                    if (inv_dt != null)
                        SetGVData(inv_dt);
                    else
                        SetGVDataByItem((DataTable)ViewState["item_dt"]);
                }
                catch
                {
                    // 不是由 P2 轉頁過來的就算了，又不會怎麼樣。
                    // 不過 審核頁 要修改資料，會跳到第一頁。
                    // 只有第一頁才能轉到第二，第二才能轉到(P3)這一頁？
                    // 還是用 session 去寫會比較好？
                }
            }
            else 
            {
                DataTable invdt = (DataTable)ViewState["inv_dt"];
                SynDts(ref invdt);
            }
        }

        #region -- About GridView -- 

        /// <summary>
        /// 生成第一條 Item 和 Box 的 DT 和 GV
        /// </summary>
        private void GenBasicGV()
        {
            // 貨物
            DataTable dt = new DataTable();

            dt.Columns.Add("item_no");
            dt.Columns.Add("inv_no");
            dt.Columns.Add("askey_pn");
            dt.Columns.Add("desc_good");
            dt.Columns.Add("dec_item");

            dt.Columns.Add("hs_code");
            dt.Columns.Add("brand");
            dt.Columns.Add("coo");
            dt.Columns.Add("qty");
            dt.Columns.Add("unit_price");
            DataRow dr = dt.NewRow();
            dt.Rows.Add(dr);

            ViewState["inv_dt"] = dt;
            Inv_GV.DataSource = dt;
            Inv_GV.DataBind();

        }

        /// <summary>
        /// 取 TextBox 輸入，更新到 DataTable 
        /// </summary>
        private void SynDts(ref DataTable inv_dt)
        {

            // 貨物
            for (int i = 0; i < inv_dt.Rows.Count; i++)
            {
                // 取得前端
                Label item_no = (Label)Inv_GV.Rows[i].Cells[0].FindControl("item_no");
                TextBox inv_no = (TextBox)Inv_GV.Rows[i].Cells[2].FindControl("inv_no");
                Label askey_pn = (Label)Inv_GV.Rows[i].Cells[3].FindControl("askey_pn");
                Label desc_good = (Label)Inv_GV.Rows[i].Cells[4].FindControl("desc_good");
                TextBox dec_item = (TextBox)Inv_GV.Rows[i].Cells[5].FindControl("dec_item");

                TextBox hs_code = (TextBox)Inv_GV.Rows[i].Cells[6].FindControl("hs_code");
                TextBox brand = (TextBox)Inv_GV.Rows[i].Cells[6].FindControl("brand");
                TextBox coo = (TextBox)Inv_GV.Rows[i].Cells[6].FindControl("coo");
                Label qty = (Label)Inv_GV.Rows[i].Cells[6].FindControl("qty");
                TextBox unit_price = (TextBox)Inv_GV.Rows[i].Cells[6].FindControl("unit_price");

                // 接收資料
                inv_dt.Rows[i]["item_no"] = item_no.Text.Trim();
                inv_dt.Rows[i]["inv_no"] = inv_no.Text.Trim();
                inv_dt.Rows[i]["askey_pn"] = askey_pn.Text.Trim();
                inv_dt.Rows[i]["desc_good"] = desc_good.Text.Trim();
                inv_dt.Rows[i]["dec_item"] = dec_item.Text.Trim();

                inv_dt.Rows[i]["hs_code"] = hs_code.Text.Trim();
                inv_dt.Rows[i]["brand"] = brand.Text.Trim();
                inv_dt.Rows[i]["coo"] = coo.Text.Trim();
                inv_dt.Rows[i]["qty"] = qty.Text.Trim();
                inv_dt.Rows[i]["unit_price"] = unit_price.Text.Trim();
            }

        }

        /// <summary>
        /// 繫結 GV 並 填入資料
        /// </summary>
        private void SetGVData(DataTable inv_dt)
        {
            // ------ 給予行數 -------
            ViewState["inv_dt"] = inv_dt;
            Inv_GV.DataSource = inv_dt;
            Inv_GV.DataBind();

            // ------- 填入資料 -------

            // 貨物
            for (int i = 0; i < inv_dt.Rows.Count; i++)
            {
                // 取得前端
                Label item_no = (Label)Inv_GV.Rows[i].Cells[0].FindControl("item_no");
                TextBox inv_no = (TextBox)Inv_GV.Rows[i].Cells[2].FindControl("inv_no");
                Label askey_pn = (Label)Inv_GV.Rows[i].Cells[3].FindControl("askey_pn");
                Label desc_good = (Label)Inv_GV.Rows[i].Cells[4].FindControl("desc_good");
                TextBox dec_item = (TextBox)Inv_GV.Rows[i].Cells[5].FindControl("dec_item");

                TextBox hs_code = (TextBox)Inv_GV.Rows[i].Cells[6].FindControl("hs_code");
                TextBox brand = (TextBox)Inv_GV.Rows[i].Cells[6].FindControl("brand");
                TextBox coo = (TextBox)Inv_GV.Rows[i].Cells[6].FindControl("coo");
                Label qty = (Label)Inv_GV.Rows[i].Cells[6].FindControl("qty");
                TextBox unit_price = (TextBox)Inv_GV.Rows[i].Cells[6].FindControl("unit_price");

                // 放入資料
                item_no.Text = inv_dt.Rows[i]["item_no"].ToString();
                inv_no.Text = inv_dt.Rows[i]["inv_no"].ToString();
                askey_pn.Text = inv_dt.Rows[i]["askey_pn"].ToString();
                desc_good.Text = inv_dt.Rows[i]["desc_good"].ToString();
                dec_item.Text = inv_dt.Rows[i]["dec_item"].ToString();

                hs_code.Text = inv_dt.Rows[i]["hs_code"].ToString();
                brand.Text = inv_dt.Rows[i]["brand"].ToString();
                coo.Text = inv_dt.Rows[i]["coo"].ToString();
                qty.Text = inv_dt.Rows[i]["qty"].ToString();
                unit_price.Text = inv_dt.Rows[i]["unit_price"].ToString();
            }

        }

        private void SetGVDataByItem( DataTable item_dt)
        {
            // ------ 給予行數 -------
            Inv_GV.DataSource = item_dt;
            Inv_GV.DataBind();

            // ------- 填入資料 -------
            DataTable inv_dt = (DataTable)ViewState["inv_dt"];
            // 貨物
            for (int i = 0; i < item_dt.Rows.Count; i++)
            {
                DataRow dr = inv_dt.NewRow();
                // 取得前端
                Label askey_pn = (Label)Inv_GV.Rows[i].Cells[3].FindControl("askey_pn");
                Label desc_good = (Label)Inv_GV.Rows[i].Cells[4].FindControl("desc_good");
                Label qty = (Label)Inv_GV.Rows[i].Cells[6].FindControl("qty");

                // 放入資料
                dr["askey_pn"] = askey_pn.Text = item_dt.Rows[i]["askey_pn"].ToString();
                dr["desc_good"] = desc_good.Text = item_dt.Rows[i]["desc_good"].ToString();
                dr["qty"] = qty.Text = item_dt.Rows[i]["pack_qty"].ToString();

                inv_dt.Rows.Add(dr);

            }

            ViewState["inv_dt"] = inv_dt;
        }
        #endregion

        #region  - 轉頁用 - 
        private string checkData(DataTable inv_dt)
        {
            return "";
        }

        protected void Last_Page(object sender, EventArgs e)
        {
            // 取上次(增加/減少一行時)的DataTable
            DataTable inv_dt = (DataTable)ViewState["inv_dt"];
            // 更新為目前輸入的資料
            SynDts(ref inv_dt);
            // 帶到Context
            Context.Items["box_dt"] = (DataTable)ViewState["box_dt"];
            Context.Items["item_dt"] = (DataTable)ViewState["item_dt"];
            Context.Items["add_dt"] = (DataTable)ViewState["add_dt"];
            Context.Items["oth_dt"] = (DataTable)ViewState["oth_dt"];
            Context.Items["inv_dt"] = inv_dt;
            // 傳送到上一頁
            Server.Transfer("P2.aspx");
        }

        protected void Next_Page(object sender, EventArgs e)
        {
            // 取上次(增加/減少一行時)的DataTable
            DataTable inv_dt = (DataTable)ViewState["inv_dt"];
            // 更新為目前輸入的資料
            SynDts(ref inv_dt);
            // 驗証 (不過的話 Alert)
            string errMsg = checkData(inv_dt);

            // 帶到Context
            Context.Items["box_dt"] = (DataTable)ViewState["box_dt"];
            Context.Items["item_dt"] = (DataTable)ViewState["item_dt"];
            Context.Items["add_dt"] = (DataTable)ViewState["add_dt"];
            Context.Items["oth_dt"] = (DataTable)ViewState["oth_dt"];
            Context.Items["inv_dt"] = inv_dt;
            // 傳送到下一頁
            Server.Transfer("P4.aspx");
        }
        #endregion

    }

}