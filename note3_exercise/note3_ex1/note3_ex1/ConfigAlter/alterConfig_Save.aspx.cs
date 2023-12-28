using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace note3_ex1.ConfigAlter
{
    public partial class alterConfig_Save : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void alertCS_Click(object sender, EventArgs e)
        {
            Configuration conf = WebConfigurationManager.OpenWebConfiguration("~");
            conf.ConnectionStrings.ConnectionStrings["A_ConnectionString"].ConnectionString = DateTime.Now.ToString("yyyyMMddHHmmss");
            conf.Save();
            CSnow.Text = WebConfigurationManager.ConnectionStrings["A_ConnectionString"].ToString();
        }

        protected void alertAS_Click(object sender, EventArgs e)
        {
            // https://dotblogs.com.tw/joumingt/2009/06/01/8631

            Configuration conf = WebConfigurationManager.OpenWebConfiguration("~");
            conf.AppSettings.Settings["A_key"].Value = DateTime.Now.ToString("G");
            conf.Save();
            ASnow.Text = WebConfigurationManager.AppSettings["A_key"];
        }
    }
}