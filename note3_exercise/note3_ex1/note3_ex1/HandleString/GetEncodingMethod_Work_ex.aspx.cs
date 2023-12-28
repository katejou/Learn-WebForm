using System;
using System.IO;
using System.Text;

namespace note3_ex1.HandleString
{
    public partial class GetEncodingMethod_Work_ex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private Encoding GetEncoding_utf8_or_big5(Stream sm)
        {
            // https://docs.microsoft.com/zh-tw/dotnet/api/system.io.streamreader.currentencoding?redirectedfrom=MSDN&view=net-5.0#System_IO_StreamReader_CurrentEncoding
            //using (var reader = new StreamReader(fpfn, Encoding.Default, false))
            //{
            //    while (reader.Peek() >= 0)
            //    {
            //        reader.Read();
            //    }
            //    return reader.CurrentEncoding;
            //}
            // 上面的方法沒有用，我不知道為什麼官網會這樣誤導…
            // Encoding.Default用中文的電腦就是BIG5，CurrentEncoding 怎樣也不會出現 utf8。
            // BIG5 和 UTF 8 的這兩個檔案都沒有 BOM 來判斷，所以一般(PDF)的方法也不適用

            //http://www.prochainsci.com/2018/01/c-big5-utf-8.html
            Encoding enc = Encoding.Default; //在中文電腦跑的是 BIG-5
            StreamReader reader = new StreamReader(sm, enc, true); // 不要用 using 否則會關閉 FileStream, 我不想打開同一個檔案兩次，所以才用 Stream 的。

            var result = reader.ReadToEnd(); //全部字讀出來
            byte[] r = enc.GetBytes(result); //把字串全部讀成 Byte    // 不是讀成文字，所以對原本的內容沒有影響，不會把 UTF8 扭曲成 BIG5

            byte[] utf8_buffer = new byte[] { r[0], r[1], r[2] }; //UTF-8 偵測 Buffer
            byte[] big5_buffer = new byte[] { r[0], r[1], r[2], r[3] }; //BIG-5 偵測 Buffer

            int u8 = Encoding.UTF8.GetString(utf8_buffer).Length; //顯示長度是否為 3
            int b5 = Encoding.Default.GetString(big5_buffer).Length; //顯示長度是否為 2

            // i 和 j 的所得到的長度是一樣的。 
            // UTF8 是一個字元 一個byte
            // BIG5 是一個字元 兩個byte
            // 但是他們判斷出對方法亂碼的時候，還是會當它為一個字(我想)。所以準確起見，還是兩個都做會比較好。

            if (u8 == 3) //如果 U8 讀三個byte有三個字，它就是 utf8
            {
                return Encoding.UTF8;
            }
            else if (b5 == 2) // B5 讀 四個 byte 有 兩個字
            {
                return reader.CurrentEncoding; // 目前是 BIG-5
            }
            else // 皆不是，它就是其他 , 回到Click 方法就會出錯
            {
                return null;
            }


        }

        protected void UTF8_Click(object sender, EventArgs e)
        {
            string curr_path = Server.MapPath(".");
            curr_path = Path.Combine(curr_path, TextBox1.Text);

            using (FileStream fs = new FileStream(curr_path, FileMode.Open, FileAccess.Read))
            {
                Encoding en = GetEncoding_utf8_or_big5(fs);
                Label1.Text = en.EncodingName;
                fs.Position = 0;  // 要把指針跳回一開始，否則會讀不到作任何內容。應該是因為 GetEncoding 是時候被 ReadToEnd 過的影響。
                byte[] temp = new byte[fs.Length];
                fs.Read(temp, 0, temp.Length);
                TextBox2.Text = en.GetString(temp);
            }
        }

        protected void BIG5_Click(object sender, EventArgs e)
        {
            string curr_path = Server.MapPath(".");
            curr_path = Path.Combine(curr_path, TextBox3.Text);

            using (FileStream fs = new FileStream(curr_path, FileMode.Open, FileAccess.Read))
            {
                Encoding en = GetEncoding_utf8_or_big5(fs);
                Label2.Text = en.EncodingName;
                fs.Position = 0;  // 要把指針跳回一開始，否則會讀不到作任何內容。應該是因為 GetEncoding 是時候被 ReadToEnd 過的影響。
                byte[] temp = new byte[fs.Length];
                fs.Read(temp, 0, temp.Length);
                TextBox4.Text = en.GetString(temp);
            }
        }
    }
}