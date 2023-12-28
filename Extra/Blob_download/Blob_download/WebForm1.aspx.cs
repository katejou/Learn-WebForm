using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Blob_download
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string errmsg = "";
            DataTable dt = new ERP_DB().Oracle_search_dt("select file_id, file_name from FND_LOBS where file_name is not null and ROWNUM < 50", ref errmsg);
            if (string.IsNullOrEmpty(errmsg))
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string id = TextBox1.Text.Trim();
            if (!string.IsNullOrEmpty(id))
                Response.Redirect("Download.ashx?id=" + id);
        }
    }
}