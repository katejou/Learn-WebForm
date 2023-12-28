using System;
using System.Web.UI;

namespace ASP.NET_Extra
{
    public partial class Session_EX : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["SessionSave"] = " 第一頁的 Session 值";  //賦值
            //Session.Timeout = 1; // 以分鐘為單位，代表 1 分鐘後設定的 SessionSave 會不存在。
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                ShowSession.Text = Session["SessionSave"].ToString();
            }
            catch(Exception ex)
            {
                ShowSession.Text = ex.Message + " \n 因為你取值的時間過了一分鐘 / 你根本沒有設下過值。 ";
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string page = "'SessionOtherPage.aspx'";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "popup", "window.open(" + page + ",'_blank')", true);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                ShowSession0.Text = Session["SessionSave"].ToString();
            }
            catch (Exception ex)
            {
                ShowSession0.Text = ex.Message + " \n 因為你取值的時間過了一分鐘 / 你在另一頁設下了空值。 ";
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Session.Remove("SessionSave");
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Session["One"] = "1";
            Session["Two"] = "2";
            Session["Three"] = "3";
            Session["Four"] = "4";
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            Session.Clear();
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            Session.Abandon();  // 會引發 Session_End 事件 ???  不知道是什麼，目前和其他兩個沒有分別，用到再說。
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            try
            {
                ShowSession1.Text = Session["One"].ToString() + Session["Two"].ToString() + Session["Three"].ToString() + Session["Four"].ToString();
            }
            catch(Exception ex)
            {
                ShowSession1.Text = ex.Message;
            }
        }
    }
}