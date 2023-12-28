using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace test
{
    public partial class dyn_can_del : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                GenBasic();
            else
            {
                // 取上次(增加/減少一行時)的DataTable 
                DataTable dt = (DataTable)ViewState["dt"];
                // 同步
                SynDt(ref dt);
            }
        }

        private void GenBasic()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ASSIGNED_ID");
            dt.Columns.Add("QUANTITY_ORDERED");
            dt.Columns.Add("UNIT_OF_MEASURE_CODE");
            dt.Columns.Add("UNIT_PRICE");
            dt.Columns.Add("PRODUCT_ID_QUAL1");
            dt.Columns.Add("PRODUCT_ID1");
            dt.Columns.Add("PRODUCT_ID_QUAL2");
            dt.Columns.Add("PRODUCT_ID2");
            dt.Columns.Add("PRODUCT_DESCRIPTION");
            dt.Columns.Add("QUOTE_QUAL");
            dt.Columns.Add("QUOTE_NUMBER");
            dt.Columns.Add("QUANTITY");
            dt.Columns.Add("ARRIVALDATE");
            dt.Columns.Add("ITEM_DESCRIPTION");
            dt.Columns.Add("ITEM_MSG");
            dt.Rows.Add();

            ViewState["dt"] = dt;
            GV.DataSource = dt;
            GV.DataBind();
        }



        protected void Del_Click(object sender, EventArgs e)
        {
            if (GV.Rows.Count == 1)
            {
                //Do.Alert("不能刪最後一行", Page);
                return;
            }

            try
            {
                // 在PageLoad已同步
                DataTable dt = (DataTable)ViewState["dt"];

                // 刪按按鈕 的 這一行
                Button thisBtn = sender as Button;
                GridViewRow row = thisBtn.NamingContainer as GridViewRow;
                int selectedRowIndex = row.RowIndex;
                dt.Rows.RemoveAt(selectedRowIndex);

                // 重新繫結 GridView 和 設定 ViewState
                ReSetGV(dt);
            }
            catch (Exception ex)
            {
                //Helper.Alert(ex.Message, Page);
                //Helper.WriteLog(ex, ErrorLogFileName);
            }
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            try
            {
                // 在PageLoad已同步
                DataTable dt = (DataTable)ViewState["dt"];

                // 開新的一行 
                DataRow dr = dt.NewRow();
                dt.Rows.Add(dr);
                // 重新繫結 GridView 和 設定 ViewState
                ReSetGV(dt);
            }
            catch (Exception ex)
            {
                //Helper.Alert(ex.Message, Page);
                //Helper.WriteLog(ex, ErrorLogFileName);
            }
        }


        private void SynDt(ref DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                // 取得前端
                Control obj = (Control)GV.Rows[i].Cells[1].FindControl("myUc");
                ICustomControl2 cu = obj as ICustomControl2;

                // 輸入資料
                dt.Rows[i]["ASSIGNED_ID"] = cu.txt_ASSIGNED_ID;
                dt.Rows[i]["QUANTITY_ORDERED"] = cu.txt_QUANTITY_ORDERED;
                dt.Rows[i]["UNIT_OF_MEASURE_CODE"] = cu.txt_UNIT_OF_MEASURE_CODE;
                dt.Rows[i]["UNIT_PRICE"] = cu.txt_UNIT_PRICE;
                dt.Rows[i]["PRODUCT_ID_QUAL1"] = cu.val_PRODUCT_ID_QUAL1;
                dt.Rows[i]["PRODUCT_ID1"] = cu.txt_PRODUCT_ID1;
                dt.Rows[i]["PRODUCT_ID_QUAL2"] = cu.val_PRODUCT_ID_QUAL2;
                dt.Rows[i]["PRODUCT_ID2"] = cu.txt_PRODUCT_ID2;
                dt.Rows[i]["PRODUCT_DESCRIPTION"] = cu.txt_PRODUCT_DESCRIPTION;
                dt.Rows[i]["QUOTE_QUAL"] = cu.val_QUOTE_QUAL;
                dt.Rows[i]["QUOTE_NUMBER"] = cu.txt_QUOTE_NUMBER;
                dt.Rows[i]["QUANTITY"] = cu.txt_QUANTITY;
                dt.Rows[i]["ARRIVALDATE"] = cu.txt_ARRIVALDATE;
                dt.Rows[i]["ITEM_DESCRIPTION"] = cu.txt_ITEM_DESCRIPTION;
                dt.Rows[i]["ITEM_MSG"] = cu.txt_ITEM_MSG;
            }
        }

        private void ReSetGV(DataTable dt)
        {
            ViewState["dt"] = dt;

            // 給予行數，但沒有資料
            GV.DataSource = dt;
            GV.DataBind();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                // 取得前端
                Control obj = (Control)GV.Rows[i].Cells[1].FindControl("myUc");
                ICustomControl2 cu = obj as ICustomControl2;

                // 輸入資料
                cu.txt_ASSIGNED_ID = dt.Rows[i]["ASSIGNED_ID"].ToString();
                cu.txt_QUANTITY_ORDERED = dt.Rows[i]["QUANTITY_ORDERED"].ToString();
                cu.txt_UNIT_OF_MEASURE_CODE = dt.Rows[i]["UNIT_OF_MEASURE_CODE"].ToString();
                cu.txt_UNIT_PRICE = dt.Rows[i]["UNIT_PRICE"].ToString();
                cu.val_PRODUCT_ID_QUAL1 = dt.Rows[i]["PRODUCT_ID_QUAL1"].ToString();
                cu.txt_PRODUCT_ID1 = dt.Rows[i]["PRODUCT_ID1"].ToString();
                cu.val_PRODUCT_ID_QUAL2 = dt.Rows[i]["PRODUCT_ID_QUAL2"].ToString();
                cu.txt_PRODUCT_ID2 = dt.Rows[i]["PRODUCT_ID2"].ToString();
                cu.txt_PRODUCT_DESCRIPTION = dt.Rows[i]["PRODUCT_DESCRIPTION"].ToString();
                cu.val_QUOTE_QUAL = dt.Rows[i]["QUOTE_QUAL"].ToString();
                cu.txt_QUOTE_NUMBER = dt.Rows[i]["QUOTE_NUMBER"].ToString();
                cu.txt_QUANTITY = dt.Rows[i]["QUANTITY"].ToString();
                cu.txt_ARRIVALDATE = dt.Rows[i]["ARRIVALDATE"].ToString();
                cu.txt_ITEM_DESCRIPTION = dt.Rows[i]["ITEM_DESCRIPTION"].ToString();
                cu.txt_ITEM_MSG = dt.Rows[i]["ITEM_MSG"].ToString();

            }
        }

    }
}