using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace note3_ex1.HandleString
{
    public partial class StringBulider_ex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // P 131
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder(200);
            foreach (DriveInfo info in DriveInfo.GetDrives())
            {
                sb.AppendFormat("{0},格式{1}", info.Name, info.DriveFormat);
            }
            Label1.Text = sb.ToString();
        }
    }
}