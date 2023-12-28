using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace note3_ex3
{
    public partial class Hash_ex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 第一個Hash
        /// </summary>
        protected void Button1_Click(object sender, EventArgs e)
        {
            Byte[] Message = Encoding.Unicode.GetBytes(TextBox1.Text);
            SHA1CryptoServiceProvider SHhash = new SHA1CryptoServiceProvider();
            Byte[] HashValue = SHhash.ComputeHash(Message);
            Label1.Text = BitConverter.ToString(HashValue);
        }

        /// <summary>
        /// 第二個Hash
        /// </summary>
        protected void Button2_Click(object sender, EventArgs e)
        {
            Byte[] Message = Encoding.Unicode.GetBytes(TextBox1.Text);
            SHA1CryptoServiceProvider SHhash = new SHA1CryptoServiceProvider();
            Byte[] HashValue = SHhash.ComputeHash(Message);
            Label2.Text = BitConverter.ToString(HashValue);
            bool bSame = true;
            if (Label1.Text.Length != Label2.Text.Length)
                bSame = false;
            else
            {
                for (int i = 0; i < Label1.Text.Length; i++)
                {
                    if (Label1.Text[i] != Label2.Text[i])
                    {
                        bSame = false; break;
                    }
                }
            }

            Label3.Text = bSame.ToString();

        }

        // P 580 練習 ------------------------------------------------------

        byte[] GetHashValue(string hashName, string data)
        {
            HashAlgorithm hashAlog = HashAlgorithm.Create(hashName);
            Byte[] buffer = Encoding.UTF8.GetBytes(data);
            return hashAlog.ComputeHash(buffer);
            // Runtime Error : 
            // System.NullReferenceException: '並未將物件參考設定為物件的執行個體。'
            // hashAlog 為 null。
            // 這個問題，是因為 hashName 的字串，有限定的範圍，不可以自取︰
            // https://docs.microsoft.com/zh-tw/dotnet/api/system.security.cryptography.hashalgorithm.create?view=net-5.0
        }

        bool VerifyHashValue(Byte[] hashl, Byte[] hash2)
        {
            for (int i = 0; i < hashl.Length; i++)
            {
                if (hashl[i] != hash2[i])
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 存密碼入檔
        /// </summary>
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBox2.Text)) return;
            string pw = TextBox2.Text;
            Byte[] hashValue = GetHashValue("SHA", pw);
            // 寫入檔案的內容
            string path = Path.Combine(Server.MapPath("."), "mypassword.dat");
            FileStream saveToFile = new FileStream(path, FileMode.Create);
            saveToFile.Write(hashValue, 0, hashValue.Length); // 寫入經過hash的內容
            saveToFile.Close();
            Label4.Text = "成功";
        }

        /// <summary>
        /// 讀檔和對比密碼
        /// </summary>
        protected void Button4_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(TextBox3.Text)) return;
            string pw = TextBox3.Text;
            Byte[] new_hashValue = GetHashValue("SHA", pw);
            // 取出檔案的內容
            string path = Path.Combine(Server.MapPath("."), "mypassword.dat");
            FileStream saveToFile = new FileStream(path, FileMode.Open);
            Byte[] take_out_hashValue = new byte[saveToFile.Length];
            saveToFile.Read(take_out_hashValue, 0, (int)saveToFile.Length);
            saveToFile.Close();
            // 對比 取出的檔案內容 和 現在輸入的密碼對比正不正確
            if (VerifyHashValue(take_out_hashValue, new_hashValue))
                Label5.Text = "密碼正確";
            else
                Label5.Text = "密碼不正確";
        }
    
    }
}