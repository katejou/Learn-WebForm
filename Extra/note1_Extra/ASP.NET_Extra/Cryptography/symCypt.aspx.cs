using System;
using System.Collections.Generic;
using System.IO;
/*引用這兩個命名空間*/
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace ASP.NET_Extra.Cryptography
{
    public partial class C1 : System.Web.UI.Page
    {
        private static string AesKey = "1234567812345678";//必須至少16個字元，最大32個字元，因為使用AES演算法，可以的話，最好給32個字比較安全
        private static string AesIV = "1234567812345678";//必須至少16個字元，最大32個字元，因為使用AES演算法，可以的話，最好給32個字比較安全

        private static string DesKey = "12345678";
        private static string DesIV = "12345678";

        protected void Page_Load(object sender, EventArgs e)
        {
            // 原文
            string plain_text = "Hello World!!";
            // AES 加密
            string base64String = AesCryptography.Encrypt(AesKey, AesIV, plain_text);
            Label1.Text = $@"加密後  :    {base64String}";
            // AES 解密
            string decrypt_text = AesCryptography.Decrypt(AesKey, AesIV, base64String);
            Label2.Text = $@"解密後  :    {decrypt_text}";

            // DES 加密
            string base64String2 = DesCryptography.Encrypt(DesKey, DesIV, plain_text);
            Label3.Text = $@"加密後  :    {base64String2}";
            // DES 解密
            string decrypt_text2 = DesCryptography.Decrypt(DesKey, DesIV, base64String2);
            Label4.Text = $@"解密後  :    {decrypt_text2}";

            // DES 加密2
            string base64String3 = DesCryptography2.Encrypt(DesKey, DesIV, plain_text);
            Label5.Text = $@"加密後  :    {base64String3}";
            // DES 解密2
            string decrypt_text3 = DesCryptography2.Decrypt(DesKey, DesIV, base64String3);
            Label6.Text = $@"解密後  :    {decrypt_text3}";


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string plain_file = HttpContext.Current.Server.MapPath("text.txt");     // C:\\Users\\kate_jou\\source\\repos\\ASP.NET_Extra\\ASP.NET_Extra\\Cryptography\\
            string encrypt_file = HttpContext.Current.Server.MapPath("encrypt_text.txt");

            //    路徑上， / 和  ~/  的分別︰    https://dotblogs.com.tw/supershowwei/2018/09/17/124506
            // https://stackoverflow.com/questions/6424114/slash-vs-tilde-slash-in-style-sheet-path
            //     /  =  site root    ~/  =  Root directory of the application


            if (!File.Exists(plain_file))
            {
                return;
            }

            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] key = Encoding.ASCII.GetBytes("12345678");
            byte[] iv = Encoding.ASCII.GetBytes("87654321");

            des.Key = key;
            des.IV = iv;

            using (FileStream sourceStream = new FileStream(plain_file, FileMode.Open, FileAccess.Read))  // 無法同時使用兩個檔案
            using (FileStream encryptStream = new FileStream(encrypt_file, FileMode.Create, FileAccess.Write))
            {
                //檔案加密
                byte[] dataByteArray = new byte[sourceStream.Length];
                sourceStream.Read(dataByteArray, 0, dataByteArray.Length);

                using (CryptoStream cs = new CryptoStream(encryptStream, des.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(dataByteArray, 0, dataByteArray.Length);
                    cs.FlushFinalBlock();
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string encrypt_file = HttpContext.Current.Server.MapPath("encrypt_text.txt");
            string decrypt_file = HttpContext.Current.Server.MapPath("decrypt_text.txt");

            if (!File.Exists(encrypt_file))
            {
                return;
            }

            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] key = Encoding.ASCII.GetBytes("12345678");
            byte[] iv = Encoding.ASCII.GetBytes("87654321");

            des.Key = key;
            des.IV = iv;

            using (FileStream encryptStream = new FileStream(encrypt_file, FileMode.Open, FileAccess.Read))
            using (FileStream decryptStream = new FileStream(decrypt_file, FileMode.Create, FileAccess.Write))
            {
                byte[] dataByteArray = new byte[encryptStream.Length];
                encryptStream.Read(dataByteArray, 0, dataByteArray.Length);
                using (CryptoStream cs = new CryptoStream(decryptStream, des.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(dataByteArray, 0, dataByteArray.Length);
                    cs.FlushFinalBlock();
                }
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            byte[] salt = new byte[] { 0x0A, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0xF1 };
            string input = TextBox1.Text;
            byte[] key = Encoding.UTF8.GetBytes(input);
            Rfc2898DeriveBytes rfcKey = new Rfc2898DeriveBytes(key, salt, 8);
            byte[] keyData = rfcKey.GetBytes(8);

            // string strKeyData = Convert.ToBase64String(keyData);   // <-- 這裡多了 32 Bytes ? 
            // Validate_Key_Length(strKeyData);     // 不應該把Key化成文字去驗。

            string strKeyData = "";
            foreach (var num in keyData) { strKeyData +=  num + " | "; }     // 這 8 個數字，應該直接給  DESCryptoServiceProvider  使用
            Label7.Text = strKeyData;
            
        }





        /// <summary>
        /// 驗證key的長度
        /// </summary>
        private static void Validate_Key_Length(string key)
        {
            List<int> LegalSizes = new List<int>() { 64 };
            int keyBitSize = Encoding.UTF8.GetBytes(key).Length * 8;

            if (!LegalSizes.Contains(keyBitSize) )
            {
                throw new Exception($@"key或iv的長度不在128bits、192bits、256bits其中一個，輸入的key bits:{keyBitSize}");
            }

            // 1 Byte=8 Bit, 所以 128 Bit = 16 Byte, 256 Bit = 32 Byte
            // https://dotblogs.com.tw/yc421206/2012/04/18/71609

        }
    }
}