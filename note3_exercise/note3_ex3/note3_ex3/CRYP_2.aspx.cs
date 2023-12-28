using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace note3_ex3
{
    public partial class ASYN_CRYP : System.Web.UI.Page
    {

        TripleDESCryptoServiceProvider objDES = new TripleDESCryptoServiceProvider();

        protected void Page_Load(object sender, EventArgs e)
        {
            objDES.GenerateKey();
            objDES.GenerateIV();
        }

        /// <summary>
        /// 加密 檔案
        /// </summary>
        protected void Button1_Click(object sender, EventArgs e)
        {
            String path = Server.MapPath("syn_cryp.txt");// +@"syn_crpt.txt";
            if (!File.Exists(path))
                return;

            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                Byte[] enerypto = ProcessEncrypto(fs);// 加密檔案內容

                if (enerypto.Length == 0)
                {
                    Label1.Text = "檔案沒有內容"; return;
                }
                FileStream outputFS = new FileStream(path.Replace("txt", "ene"), FileMode.Create); // 建新加密檔
                outputFS.Write(enerypto, 0, enerypto.Length);  // 新檔寫入「對稱Key」加密後的內容。
                outputFS.Close();
            }
            Label1.Text = "產生加密檔案 syn_cryp.ene";
        }

        /// <summary>
        /// 對稱加密
        /// </summary>
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
            writer.Write(ProtectKey(key)); // 由「非對稱」再將 它們加密一次
            writer.Write(ProtectKey(iv));

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

                return ms.ToArray(); // 回傳 已透過 cs 處理好的 ms 給召喚的方法
            }

        }

        /// <summary>
        /// 解密 檔案
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

        /// <summary>
        /// 對稱解密
        /// </summary>
        byte[] ProcessDecrypto(Stream sourceStream)
        {

            // 讀取來源
            byte[] key, iv, data;
            BinaryReader reader = new BinaryReader(sourceStream);
            // 對稱時 24 和 8 : 
            //key = reader.ReadBytes(24);// 前 24 節是 Key 的意思？//<-- 反正他們這樣反而拿得到和加密時一樣的 KEY
            //iv = reader.ReadBytes(8);// 24 後的 8 節是 IV 的意思？
            ////key = objDES.Key; // <-- 這樣是不對的，因為每次拿出的Key 都不一樣？我也不知道為什麼會這樣。
            ////iv = objDES.IV;//<---- 拿錯的 KEY 和 IV 去解密，會在 cs.Read 那裡出問題。
            // 不對稱時 128, 128 ?︰
            key = UnprotectKey(reader.ReadBytes(128));
            iv = UnprotectKey(reader.ReadBytes(128));

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

        /// <summary>
        /// 加密文字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button3_Click(object sender, EventArgs e)
        {
            DESCryptoServiceProvider objDES2 = new DESCryptoServiceProvider();
            objDES2.GenerateKey();
            objDES2.GenerateIV();
            Byte[] key = objDES2.Key;
            Byte[] iv = objDES2.IV;
            //ICryptoTransform objCrytpo = objDES2.CreateEncryptor(ProtectKey(key), ProtectKey(iv));
            // Runtime Error : 說System.Security.Cryptography.CryptographicException: '指定的金鑰不是此演算法的有效大小。'
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

            ViewState["key"] = ProtectKey(key); // <-- 在存到公開地方時，才將它非對稱加密一下。
            ViewState["iv"] = ProtectKey(iv);// <-- 在存到公開地方時，才將它非對稱加密一下。
            ViewState["cipherMessage"] = cipherMessage;
        }

        /// <summary>
        /// 解密文字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button4_Click(object sender, EventArgs e)
        {
            byte[] key = UnprotectKey((Byte[])ViewState["key"]); // 在公開地方拿回來的時候，解密一下。
            byte[] iv = UnprotectKey((Byte[])ViewState["iv"]); // 在公開地方拿回來的時候，解密一下。
            byte[] cipherMessage = (Byte[])ViewState["cipherMessage"];

            DESCryptoServiceProvider objDES2 = new DESCryptoServiceProvider();
            ICryptoTransform objCrytpo = objDES2.CreateDecryptor(key, iv);
            MemoryStream ms = new MemoryStream(cipherMessage);
            CryptoStream cs = new CryptoStream(ms, objCrytpo, CryptoStreamMode.Read);
            StreamReader sr = new StreamReader(cs);
            Label4.Text = sr.ReadToEnd();
            sr.Close();
        }


        /// <summary>
        /// 以私Key加密
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        byte[] ProtectKey(Byte[] key)
        {
            // 設定參數 (都是公Key?因為沒有另一台電腦？)
            CspParameters param = new CspParameters();
            param.KeyContainerName = "MyKeyContainer";
            param.Flags = CspProviderFlags.UseMachineKeyStore;
            // 產生非對稱加密
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(param);
            return RSA.Encrypt(key, false);
        }

        /// <summary>
        /// 以公Key解密
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        byte[] UnprotectKey(byte[] key)
        {
            // 設定參數 (都是公Key?因為沒有另一台電腦？)
            CspParameters param = new CspParameters();
            param.KeyContainerName = "MyKeyContainer"; 
            param.Flags = CspProviderFlags.UseMachineKeyStore;
            // 產生非對稱解密
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(param);
            return RSA.Decrypt(key, false);
            // System.Security.Cryptography.CryptographicException: '資料錯誤。
        }
    }
}