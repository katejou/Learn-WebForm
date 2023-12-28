using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Net;

namespace note3_ex1.FileManage
{
    public partial class BufferStream_ex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // P 99
        }

        protected void Upload_Click(object sender, EventArgs e)
        {
            Byte[] content = Encoding.UTF8.GetBytes(TextBox1.Text);

            string curr_path = Server.MapPath(".");
            WebRequest request = WebRequest.Create(Path.Combine(curr_path, "NewGenFile.txt"));
            request.Method = "POST";

            Stream webStream = request.GetRequestStream();
            BufferedStream buffer = new BufferedStream(webStream, 1024);
            buffer.Write(content, 0, content.Length);
            buffer.Close();

            try
            {
                request.GetResponse();
                Label1.Text = "上載完成";
                TextBox1.Text = "";
            }
            catch (Exception ex)
            {
                Label1.Text =  ex.Message;
            }
        }

        protected void Download_Click(object sender, EventArgs e)
        {

            string curr_path = Server.MapPath(".");
            WebRequest request = WebRequest.Create(Path.Combine(curr_path, "NewGenFile.txt"));
            request.Method = "POST";
            WebResponse response = request.GetResponse();   // <--- 和 Upload 不同，我要 Get之後的內容︰

            Stream webStream = response.GetResponseStream();
            BufferedStream buffer = new BufferedStream(webStream, 1024);
            
            Byte[] content = new byte[1024];
            int length = 0;
            StringBuilder sb = new StringBuilder(1024); // 1024 是最大的空間
            do
            {
                length = buffer.Read(content, 0, 1024); // 會回傳讀到位元組數目。
                sb.Append(Encoding.UTF8.GetString(content).Trim()); // content 從原本的空 Byte[] 被填入資料 -> 再化為文字
                Array.Clear(content, 0, 1024); // 清空 content (如果這個例子不必然是一次的話，是有意義的。)
            } 
            while (length == 1024);

            buffer.Close();

            TextBox1.Text = sb.ToString();
        }
    }
}