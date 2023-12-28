using System;


namespace ASP.NET_EX1_.EX_11
{
    public partial class Page_err : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String s = "2009/2/30";
            DateTime d = DateTime.Parse(s);

        }

        /// <summary>
        /// 試註解這個方法，就可以測到 Application 的 err 攔截
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Error(object sender, EventArgs e)
        {
            Exception ex = default(Exception);
            ex = Server.GetLastError();
            Response.Write(ex.Message);

            Server.Transfer("Err.html");
            Server.ClearError();
        }

    }
}