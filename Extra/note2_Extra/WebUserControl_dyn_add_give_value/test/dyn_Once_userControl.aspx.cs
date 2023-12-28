using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using test;

namespace note2_ex3
{
    public partial class dynamic_userControl : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //PlaceHolder1.Controls.Clear(); <-- 如果有需要是可以Clear

            // 由後端來引用︰
            if (IsPostBack && ViewState["wucExist"] != null)
                Load2PH(123, 456);
            // 每次都要Gen，否則PostBack就會不見。但是它的值會維持和使用者目前輸入的一樣。
            // 值如果從 123,456 被使用者改了，也不會擔心它會被覆寫。
            // 它只是要同樣的生成條件，以我的理解。


        }

        protected void GetValue_Click(object sender, EventArgs e)
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
            if (PlaceHolder1.Controls.Count > 0)
            {
                foreach (WebUserControl1 item in PlaceHolder1.Controls)
                {

                    DataRow dr = dt.NewRow();

                    dr["ASSIGNED_ID"] = item.txt_ASSIGNED_ID;
                    dr["QUANTITY_ORDERED"] = item.txt_QUANTITY_ORDERED;
                    dr["UNIT_OF_MEASURE_CODE"] = item.txt_UNIT_OF_MEASURE_CODE;
                    dr["UNIT_PRICE"] = item.txt_UNIT_PRICE;
                    dr["PRODUCT_ID_QUAL1"] = item.val_PRODUCT_ID_QUAL1;
                    dr["PRODUCT_ID1"] = item.txt_PRODUCT_ID1;
                    dr["PRODUCT_ID_QUAL2"] = item.val_PRODUCT_ID_QUAL2;
                    dr["PRODUCT_ID2"] = item.txt_PRODUCT_ID2;
                    dr["PRODUCT_DESCRIPTION"] = item.txt_PRODUCT_DESCRIPTION;
                    dr["QUOTE_QUAL"] = item.val_QUOTE_QUAL;
                    dr["QUOTE_NUMBER"] = item.txt_QUOTE_NUMBER;
                    dr["QUANTITY"] = item.txt_QUANTITY;
                    dr["ARRIVALDATE"] = item.txt_ARRIVALDATE;
                    dr["ITEM_DESCRIPTION"] = item.txt_ITEM_DESCRIPTION;
                    dr["ITEM_MSG"] = item.txt_ITEM_MSG;

                    dt.Rows.Add(dr);
                }
            }

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void Load_Click(object sender, EventArgs e)
        {
            ViewState["wucExist"] = true;
            PlaceHolder1.Controls.Clear(); // 記得要清一下，否則會維持第一次成生的樣子不變。但在PageLoad千萬不要，那就是要用來維持原狀的。
            Load2PH(123, 456);
        }

        private void Load2PH(int a, int b)
        {
            Control obj = Page.LoadControl("WebUserControl1.ascx");
            obj.ID = "obj0";
            PlaceHolder1.Controls.Add(obj);
            ICustomControl cu = obj as ICustomControl;
            cu.txt_ASSIGNED_ID = a.ToString();

            // 可以加入複數自訂控制項於同一頁。

            obj = Page.LoadControl("WebUserControl1.ascx");
            obj.ID = "obj1";
            PlaceHolder1.Controls.Add(obj);
            cu = obj as ICustomControl;
            cu.txt_ASSIGNED_ID = b.ToString();
        }

        protected void PostBack_Click(object sender, EventArgs e)
        {

        }
    }
}