using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace note3_ex1.FileManage
{
    public partial class File_ex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // P 75
        }

        protected void WriteAllLine_Click(object sender, EventArgs e)
        {
            string[] data = new[] { TextBox2.Text };
            string curr_path = Server.MapPath(".");
            File.WriteAllLines( Path.Combine(curr_path,TextBox1.Text), data);
            Response.Write("<script> alert('寫入成功') </script>");
        }

        protected void ReadAllLine_Click(object sender, EventArgs e)
        {
            string[] data = null;
            string curr_path = Server.MapPath(".");
            data = File.ReadAllLines(Path.Combine(curr_path, TextBox3.Text));
            TextBox4.Text = String.Join(" ", data);
            //Response.Write("<script> alert('讀取成功') </script>");
        }
    }
}