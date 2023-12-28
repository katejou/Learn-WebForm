using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace note2_ex3
{
    public partial class dynamic_userControl : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            // 由後端來引用︰
            Control obj = Page.LoadControl("WebUserControl1.ascx");


            #region 因為 父型 System.Web.UI.UserControl 無法序列化，所以無法變成List去加入ViewState
            //if (ViewState["GorupControl"] != null)
            //{
            //    GorupControl gorupControl = new GorupControl();
            //    gorupControl.cList = (List<Control>)ViewState["GorupControl"];
            //    gorupControl.cList.Add(obj);
            //    ViewState["GorupControl"] = gorupControl.cList;
            //    foreach (var ct in gorupControl.cList) 
            //    {
            //        PlaceHolder1.Controls.Add(ct);
            //    }
            //}
            //else 
            //{
            //GorupControl gorupControl = new GorupControl();
            //gorupControl.cList.Add(obj);
            //ViewState["GorupControl"] = gorupControl.cList;
            // } 
            #endregion

            PlaceHolder1.Controls.Add(obj);

            // 可以加入複數自訂控制項於同一頁。

            //obj = Page.LoadControl("WebUserControl1.ascx");
            //PlaceHolder1.Controls.Add(obj);
            //obj = Page.LoadControl("WebUserControl1.ascx");
            //PlaceHolder1.Controls.Add(obj);

            // 如果 WebUserControl1 要動態給值的話，要去看另一個專案，在這裡實行不知道和什麼東西相沖，太亂了。
            // 專案 : WebUserControl_dyn_gen_give_value
        }


    }
}