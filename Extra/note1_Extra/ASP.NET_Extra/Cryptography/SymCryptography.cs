using System;
using System.Collections.Generic;
using System.IO;
/*引用這兩個命名空間*/
using System.Security.Cryptography;
using System.Text;

namespace ASP.NET_Extra.Cryptography
{

    public class AesCryptography
    {
        /// <summary>
        /// 驗證key和iv的長度(AES只有三種長度適用)
        /// </summary>
        private static void Validate_KeyIV_Length(string key, string iv)
        {
            //驗證key和iv都必須為128bits或192bits或256bits
            List<int> LegalSizes = new List<int>() { 128, 192, 256 };
            int keyBitSize = Encoding.UTF8.GetBytes(key).Length * 8;
            int ivBitSize = Encoding.UTF8.GetBytes(iv).Length * 8;
            if (!LegalSizes.Contains(keyBitSize) || !LegalSizes.Contains(ivBitSize))
            {
                throw new Exception($@"key或iv的長度不在128bits、192bits、256bits其中一個，輸入的key bits:{keyBitSize},iv bits:{ivBitSize}");
            }

            // 1 Byte=8 Bit, 所以 128 Bit = 16 Byte, 256 Bit = 32 Byte
            // https://dotblogs.com.tw/yc421206/2012/04/18/71609

        }

        /// <summary>
        /// 加密後回傳base64String，相同明碼文字加密後的base64String結果會相同(類似雜湊)，除非變更key或iv
        /// 如果key和iv忘記遺失的話，資料就解密不回來
        /// base64String若使用在Url的話，Web端記得做UrlEncode
        /// </summary>
        public static string Encrypt(string key, string iv, string plain_text)
        {

            Validate_KeyIV_Length(key, iv);    //   沒有throw Exception 就沒有事。
            Aes aes = Aes.Create();     //  Aes 本身就是一個 Class  , 這個東西，即使 F12 去看了也沒有代碼的內容。
            aes.Mode = CipherMode.CBC;      //  非必須，但加了較安全
            aes.Padding = PaddingMode.PKCS7;        //  非必須，但加了較安全

            ICryptoTransform transform = aes.CreateEncryptor(Encoding.UTF8.GetBytes(key), Encoding.UTF8.GetBytes(iv));      //  放入  key  和  iv

            byte[] bPlainText = Encoding.UTF8.GetBytes(plain_text);      //  明碼文字轉byte[]
            byte[] outputData = transform.TransformFinalBlock(bPlainText, 0, bPlainText.Length);        //  由放入 key 和 iv 的 transform 來加密 plainText

            return Convert.ToBase64String(outputData);      //  把 plainText 由 byte[] 轉回  Base64String  再回覆  

        }

        /// <summary>
        /// 解密後，回傳明碼文字
        /// </summary>
        public static string Decrypt(string key, string iv, string base64String)
        {

            Validate_KeyIV_Length(key, iv);     // 同上

            Aes aes = Aes.Create();
            aes.Mode = CipherMode.CBC;//非必須，但加了較安全
            aes.Padding = PaddingMode.PKCS7;//非必須，但加了較安全

            ICryptoTransform transform = aes.CreateDecryptor(Encoding.UTF8.GetBytes(key), Encoding.UTF8.GetBytes(iv));       // 同上

            byte[] bEnBase64String = null;    //  有可能base64String格式錯誤, 所以先等於 null
            byte[] outputData = null;    //   有可能解密出錯, 所以先等於 null,  如果 解密出錯， 下中斷點的時候，比較好看到 值？
            try
            {
                bEnBase64String = Convert.FromBase64String(base64String);      //  FromBase64String  會把  base64String 變回 byte[]     
                outputData = transform.TransformFinalBlock(bEnBase64String, 0, bEnBase64String.Length);    // 用 transform 物件，將 bEnBase64String 解密。
            }
            catch (Exception ex)
            {
                //todo 寫Log
                throw new Exception($@"解密出錯:{ex.Message}");
            }

            //解密成功
            return Encoding.UTF8.GetString(outputData);     // 從 byte[] 轉為 string 回傳

        }

    }

    public class DesCryptography
    {
        public static string Encrypt(string key, string iv, string plain_text)
        {

            byte[] byteKey = Encoding.ASCII.GetBytes(key);
            byte[] byteIv = Encoding.ASCII.GetBytes(iv);
            byte[] dataByteArray = Encoding.UTF8.GetBytes(plain_text);

            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            des.Key = byteKey;
            des.IV = byteIv;
            string encrypt = "";

            using (MemoryStream ms = new MemoryStream())  // using IO
            using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
            {
                cs.Write(dataByteArray, 0, dataByteArray.Length);
                cs.FlushFinalBlock();
                encrypt = Convert.ToBase64String(ms.ToArray());
            }
            return encrypt;
        }

        public static string Decrypt(string key, string iv, string encrypt)
        {
            byte[] byteKey = Encoding.ASCII.GetBytes(key);
            byte[] byteIv = Encoding.ASCII.GetBytes(iv);
            byte[] dataByteArray = Convert.FromBase64String(encrypt);

            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            des.Key = byteKey;
            des.IV = byteIv;

            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(dataByteArray, 0, dataByteArray.Length);
                    cs.FlushFinalBlock();
                    return Encoding.UTF8.GetString(ms.ToArray());
                }
            }

        }

    }


    public class DesCryptography2
    {
        public static string Encrypt(string key, string iv, string plain_text)
        {
            StringBuilder sb = new StringBuilder();     // <--- 和上一個不同的地方

            byte[] bytekey = Encoding.ASCII.GetBytes(key);
            byte[] byteiv = Encoding.ASCII.GetBytes(iv);
            byte[] dataByteArray = Encoding.UTF8.GetBytes(plain_text);

            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            des.Key = bytekey;
            des.IV = byteiv;

            string encrypt = "";
            using (MemoryStream ms = new MemoryStream())
            using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
            {
                cs.Write(dataByteArray, 0, dataByteArray.Length);
                cs.FlushFinalBlock();
                //輸出資料
                foreach (byte b in ms.ToArray())
                {
                    sb.AppendFormat("{0:X2}", b);       // <--- 和上一個不同的地方
                }
                encrypt = sb.ToString();
            }
            return encrypt;
        }

        public static string Decrypt(string key, string iv, string encrypt)
        {
            byte[] dataByteArray = new byte[encrypt.Length / 2];     // <--- 和上一個不同的地方
            for (int x = 0; x < encrypt.Length / 2; x++)
            {
                int i = (Convert.ToInt32(encrypt.Substring(x * 2, 2), 16));
                dataByteArray[x] = (byte)i;
            }                                                        // 多了個計算的公式？

            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] bytekey = Encoding.ASCII.GetBytes(key);
            byte[] byteiv = Encoding.ASCII.GetBytes(iv);
            des.Key = bytekey;
            des.IV = byteiv;

            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(dataByteArray, 0, dataByteArray.Length);  // <--- dataByteArray 和上一個不同的地方
                    cs.FlushFinalBlock();
                    return Encoding.UTF8.GetString(ms.ToArray());
                }
            }
        }

    }

}