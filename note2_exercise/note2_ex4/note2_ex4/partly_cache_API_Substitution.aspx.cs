using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace note2_ex4
{
    public partial class partly_cache_API : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // P 381 

            Label1.Text = "Page: " + System.DateTime.Now.ToString();

        }

        public static string GetCurrentDate(HttpContext context)
        {
            // 記得加 Public 這個字
            return DateTime.Now.ToString();
        }
    }
}