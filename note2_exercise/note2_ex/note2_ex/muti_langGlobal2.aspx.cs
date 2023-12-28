using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace note2_ex
{
    public partial class muti_langGlobal2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // https://dotblogs.com.tw/yc421206/2015/11/27/asp_net_multiple_language_local_global_resource
            
            Label1.Text = this.GetGlobalResourceObject("LanguageResource", "Zero").ToString();
            Label2.Text = Resources.LanguageResource.Zero;
        }
    }
}