using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.IO;

namespace note3_ex3
{
    public partial class SYN_CRYP : System.Web.UI.Page
    {

        TripleDESCryptoServiceProvider objDES = new TripleDESCryptoServiceProvider();

        protected void Page_Load(object sender, EventArgs e)
        {
            objDES.GenerateKey();
            objDES.GenerateIV();
        }

        /// <summary>
        /// 加密
        /// </summary>
        protected void Button1_Click(object sender, EventArgs e)
        {
            String path = Server.MapPath("syn_cryp.txt");// +@"syn_crpt.txt";
            if (!File.Exists(path))
                return;

            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                Byte[] enerypto = ProcessEncrypto(fs);

                if (enerypto.Length == 0)
                {
                    Label1.Text = "檔案沒有內容"; return;
                }
                FileStream outputFS = new FileStream(path.Replace("txt", "ene"), FileMode.Create);
                outputFS.Write(enerypto, 0, enerypto.Length);
                outputFS.Close();
            }
            Label1.Text = "產生加密檔案 syn_cryp.ene";
        }

        byte[] ProcessEncrypto(Stream sourceStream)
        {
            // 加密物件
            Byte[] key, iv;
            key = objDES.Key;
            iv = objDES.IV;
            ICryptoTransform objCrytpo = objDES.CreateEncryptor(key, iv);

            // 把加密物件 加入 Straem 的處理
            MemoryStream ms = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(ms);
            writer.Write(key);
            writer.Write(iv);

            // 把來源的 Stream 寫到新的加密 Stream
            using (CryptoStream cs = new CryptoStream(ms, objCrytpo, CryptoStreamMode.Write))
            {
                Byte[] buffer = new Byte[1024];
                int readCount;
                do
                {
                    readCount = sourceStream.Read(buffer, 0, 1024);
                    cs.Write(buffer, 0, readCount); // <-- 寫入
                    Array.Clear(buffer, 0, 1024);
                }
                while (readCount == 1024); // 因為寫到最後一個的時候，就不是 == buffersize了
                cs.FlushFinalBlock();

                return ms.ToArray(); // 回傳 已透過 cs 填好了 ms 給召喚的方法
            }

        }

        /// <summary>
        /// 解密
        /// </summary>
        protected void Button2_Click(object sender, EventArgs e)
        {
            String path = Server.MapPath("syn_cryp.ene");
            if (!File.Exists(path)) return;
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                Byte[] decrypto = ProcessDecrypto(fs);
                if (decrypto.Length == 0)
                {
                    Label2.Text = "檔案沒有內容"; return;
                }
                string decFileName = System.IO.Path.ChangeExtension(path, ".dec");
                FileStream outputFS = new FileStream(decFileName, FileMode.Create);
                outputFS.Write(decrypto, 0, decrypto.Length);
                outputFS.Close();
            }

            Label2.Text = "產生解密檔案 syn_cryp.dec";
        }

        byte[] ProcessDecrypto(Stream sourceStream)
        {

            // 讀取來源
            byte[] key, iv, data;
            BinaryReader reader = new BinaryReader(sourceStream);
            key = reader.ReadBytes(24);// 前 24 節是 Key 的意思？//<-- 反正他們這樣反而拿得到和加密時一樣的 KEY
            iv = reader.ReadBytes(8);// 24 後的 8 節是 IV 的意思？
            //key = objDES.Key; // <-- 這樣是不對的，因為每次拿出的Key 都不一樣？我也不知道為什麼會這樣。
            //iv = objDES.IV;//<---- 拿錯的 KEY 和 IV 去解密，會在 cs.Read 那裡出問題。
            data = reader.ReadBytes((int)sourceStream.Length);

            // 準備物件
            MemoryStream encMS = new MemoryStream(data);
            MemoryStream decMS = new MemoryStream();
            objDES = new TripleDESCryptoServiceProvider();
            ICryptoTransform objCrytpo = objDES.CreateDecryptor(key, iv);

            // 讀取及解密
            using (CryptoStream cs = new CryptoStream(encMS, objCrytpo, CryptoStreamMode.Read))
            {
                Byte[] buffer = new byte[1024];
                int readCount;
                do
                {
                    readCount = cs.Read(buffer, 0, 1024);//<-- 以解密讀取
                    decMS.Write(buffer, 0, readCount);//<-- 寫到另一個 Stream
                    Array.Clear(buffer, 0, 1024);// 清空暫存
                }
                while (readCount == 1024);

                decMS.Flush();
                return decMS.ToArray();
            }
        }



        //-------------------------------------


        protected void Button3_Click(object sender, EventArgs e)
        {
            DESCryptoServiceProvider objDES2 = new DESCryptoServiceProvider();
            objDES2.GenerateKey();
            objDES2.GenerateIV();
            Byte[] key = objDES2.Key;
            Byte[] iv = objDES2.IV;
            ICryptoTransform objCrytpo = objDES2.CreateEncryptor(key, iv);
            MemoryStream ms = new MemoryStream();

            CryptoStream cs = new CryptoStream(ms, objCrytpo, CryptoStreamMode.Write);
            StreamWriter sw = new StreamWriter(cs);
            sw.WriteLine("I Love myself");
            sw.Flush();
            cs.FlushFinalBlock();
            ms.Position = 0;
            Byte[] cipherMessage = new Byte[ms.Length];
            ms.Read(cipherMessage, 0, (int)ms.Length);
            Label3.Text = BitConverter.ToString(cipherMessage);
            cs.Close();

            ViewState["key"] = key;
            ViewState["iv"] = iv;
            ViewState["cipherMessage"] = cipherMessage;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            byte[] key = (Byte[])ViewState["key"];
            byte[] iv = (Byte[])ViewState["iv"];
            byte[] cipherMessage = (Byte[])ViewState["cipherMessage"];

            DESCryptoServiceProvider objDES2 = new DESCryptoServiceProvider();
            ICryptoTransform objCrytpo = objDES2.CreateDecryptor(key, iv);
            MemoryStream ms = new MemoryStream(cipherMessage);
            CryptoStream cs = new CryptoStream(ms, objCrytpo, CryptoStreamMode.Read);
            StreamReader sr = new StreamReader(cs);
            Label4.Text = sr.ReadToEnd();
            sr.Close();
        }
    }
}