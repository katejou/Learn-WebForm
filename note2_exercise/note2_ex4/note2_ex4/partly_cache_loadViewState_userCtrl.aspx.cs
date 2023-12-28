using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace note2_ex3
{
    public partial class loadViewState_userCtrl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // P 318



        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            ViewState["keep"] = CheckBox1.Checked;
            PlaceHolder1.Controls.Clear(); // 先清了。
            LoadControls(); // 再決定要不要拿回來。
        }

        protected override void LoadViewState(object savedState)
        {
            base.LoadViewState(savedState);
            LoadControls();
        }

        public void LoadControls() // 這個不是放在PageLoad ? 
        {
            if (ViewState["keep"] != null)
            {
                if ((bool)ViewState["keep"] == true)
                {
                    Control control = LoadControl("WebUserControl1.ascx");
                    control.ID = "Dyn_user_Ctrl";
                    PlaceHolder1.Controls.Add(control);

                }
            }
        }



        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}