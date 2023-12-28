using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;

namespace note3_ex1.FileManage
{
    public partial class Read_Write_File : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // P 91 
            // OriginalFile.txt
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string curr_path = Server.MapPath(".");
            String fileName = Path.Combine(curr_path, "OriginalFile.txt");

            using (FileStream fs = new FileStream(fileName, FileMode.Open,FileAccess.Read))
            {
                StreamReader sr = new StreamReader(fs, Encoding.GetEncoding("big5"));
                TextBox1.Text = sr.ReadToEnd();
                sr.Close();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string curr_path = Server.MapPath(".");
            String fileName = Path.Combine(curr_path, "OriginalFile.txt");

            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding("big5"));
                sw.Write(TextBox1.Text);
                sw.Close();
            }
        }
    }
}