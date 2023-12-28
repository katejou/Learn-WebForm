using System;

namespace note2_ex
{
    public partial class ajax_prevent_repeat_click : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // P215
            // 在UpdatePanel中，只會引起非同步PostBack
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(3000);
            Label1.Text = DateTime.Now.ToString();
        }
    }
}