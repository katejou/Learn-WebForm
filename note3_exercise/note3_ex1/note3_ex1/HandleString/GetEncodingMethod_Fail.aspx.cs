using System;
using System.IO;
using System.Text;


namespace note3_ex1.HandleString
{
    public partial class GetEncodingMethod : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // P 151 
            // 這個方法現在是不可行的了。
            // 因為 UTF8的檔案，現在已經沒有了BOM，也沒有了「前言」去給分別。
        }

        private bool IsUnicode(Encoding en, byte[] buffer)
        {
            byte[] preamble = en.GetPreamble(); // 取得前言  取UTF檔案編碼的前言，但檔案內容對比。
            bool IsUnicode = true;
            for (int i = 0; i < preamble.Length; i++)
                if (preamble[i] != buffer[i])
                { 
                    IsUnicode = false; break;
                }
            return IsUnicode;
        }

        protected void Button_isUTF8_Click(object sender, EventArgs e)
        {
            string curr_path = Server.MapPath(".");
            FileStream fs = new FileStream(Path.Combine(curr_path, TextBox1.Text), FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[fs.Length];
            fs.Read(buffer, 0, (int)fs.Length);
            fs.Close();

            if (IsUnicode(Encoding.UTF8, buffer))
                TextBox2.Text = Encoding.UTF8.GetString(buffer);
            else
                TextBox2.Text = "它其實是用UTF8編碼的檔案，但是這個結果卻顯示它不是。";
        }
    }
}