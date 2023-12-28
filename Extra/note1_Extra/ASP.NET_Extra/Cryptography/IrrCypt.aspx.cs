using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// 因為加密所以才存在的 V
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;
// 因為加密所以才存在的 ^

namespace ASP.NET_Extra.Cryptography
{
    public partial class cypt2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// SHA1 加密
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void SHA1_Click(object sender, EventArgs e)
        {
            string ori = tb_SHA1.Text;
            if (!string.IsNullOrEmpty(ori))
            {
                try
                {
                    //string aaa = FormsAuthentication.HashPasswordForStoringInConfigFile(ori, "SHA1");
                    // 出現已過時的警告。
                    // https://www.itdaan.com/tw/abb8c05e0c6a6d563a26fdfead290bf5

                    SHA1 algorithm = SHA1.Create();
                    byte[] data = algorithm.ComputeHash(Encoding.UTF8.GetBytes(ori));
                    string sh1 = "";
                    for (int i = 0; i < data.Length; i++)
                    {
                        sh1 += data[i].ToString("x2").ToUpperInvariant();
                    }

                    SHA1encypt_1.Text = sh1;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// SHA1 對比
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void SHA1encypt_Click(object sender, EventArgs e)
        {
            string ori = tb_SHA1.Text;
            if (!string.IsNullOrEmpty(ori))
            {
                try
                {
                    SHA1 algorithm = SHA1.Create();
                    byte[] data = algorithm.ComputeHash(Encoding.UTF8.GetBytes(ori));
                    string sh1 = "";
                    for (int i = 0; i < data.Length; i++)
                    {
                        sh1 += data[i].ToString("x2").ToUpperInvariant();
                    }

                    SHA1decypt_1.Text = sh1;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// MD5 加密
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void MD5_Click(object sender, EventArgs e)
        {
            string ori = tb_MD5.Text;
            if (!string.IsNullOrEmpty(ori))
            {
                try
                {
                    // string aaa = FormsAuthentication.HashPasswordForStoringInConfigFile(ori, "MD5");
                    // 出現已過時的警告。
                    // https://blog.csdn.net/CrackLibby/article/details/81840385
                    // MD5 md5Hash = MD5.Create();  
                    // 以上的資料，除了 第一行不同，其他都一樣。

                    // https://www.itread01.com/content/1526618298.html

                    MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
                    byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(ori));

                    StringBuilder sBuilder = new StringBuilder();
                    for (int i = 0; i < data.Length; i++)
                    {
                        sBuilder.Append(data[i].ToString("x2"));
                    }

                    MD5encypt_1.Text = sBuilder.ToString();

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// MD5 對比
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void MD5encypt_Click(object sender, EventArgs e)
        {
            string ori = tb_MD5.Text;
            if (!string.IsNullOrEmpty(ori))
            {
                try
                {
                    MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
                    byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(ori));

                    StringBuilder sBuilder = new StringBuilder();
                    for (int i = 0; i < data.Length; i++)
                    {
                        sBuilder.Append(data[i].ToString("x2"));
                    }

                    MD5decypt_1.Text = sBuilder.ToString();

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

    }
}