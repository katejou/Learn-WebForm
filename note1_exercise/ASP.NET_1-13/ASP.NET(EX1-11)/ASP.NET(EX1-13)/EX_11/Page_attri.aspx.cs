using System;


namespace ASP.NET_EX1_.EX_11
{
    public partial class Page_attri : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int i = 0;
            int j = 10;
            int k = j / i;

            // 以 Page 屬性來跳的話，就不會用得到 ex.message 
        }
          
     
    }
}