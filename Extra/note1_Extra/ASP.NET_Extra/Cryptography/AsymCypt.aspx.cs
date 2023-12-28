using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web;


namespace ASP.NET_Extra.Cryptography
{
    public partial class AsymCypt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)   // 防止每次按鈕後，得到不配對的公私key
            {
                string privateKeyFile = HttpContext.Current.Server.MapPath("PrivateKey.xml");
                string publicKeyFile = HttpContext.Current.Server.MapPath("PublicKey.xml");

                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                using (StreamWriter writer = new StreamWriter(privateKeyFile, false))  //這個文件要保密...
                {
                    writer.WriteLine(rsa.ToXmlString(true));  // 生成私鑰
                }
                using (StreamWriter writer = new StreamWriter(publicKeyFile, false))
                {
                    writer.WriteLine(rsa.ToXmlString(false));  // 生成公鑰
                }
            }

        }


        protected void ReadPubKey_Click(object sender, EventArgs e)
        {
            string publicKeyFile = HttpContext.Current.Server.MapPath("PublicKey.xml");
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(publicKeyFile))
                {
                    // Read the stream to a string, and write the string to the console.
                    String line = sr.ReadToEnd();
                    puKey.Text = line;
                }
            }
            catch (IOException ex)
            {
                puKey.Text = ex.Message;
            }
                       
        }

        protected void ReadPriKey_Click(object sender, EventArgs e)
        {
            string privateKeyFile = HttpContext.Current.Server.MapPath("PrivateKey.xml");
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(privateKeyFile))
                {
                    // Read the stream to a string, and write the string to the console.
                    String line = sr.ReadToEnd();
                    prKey.Text = line;
                }
            }
            catch (IOException ex)
            {
                prKey.Text = ex.Message;
            }
        }


        protected void RSAencypt_Click(object sender, EventArgs e)
        {
            // 以公 Kye 加密
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(1024);

            //將公鑰導入到RSA對象中，準備加密；
            rsa.FromXmlString(puKey.Text);
            // 要加密的內容
            byte[] data = System.Text.ASCIIEncoding.ASCII.GetBytes(plain_text.Text);
            //對數據data進行加密，並返回加密結果；
            byte[] buffer = rsa.Encrypt(data, false);  //第二個參數用來選擇Padding的格式 
            
            // https://www.itread01.com/content/1543510334.html
            encypt.Text = Convert.ToBase64String(buffer);

        }

        protected void RHAdecypt_Click(object sender, EventArgs e)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(1024);
            //將私鑰導入到RSA對象中，準備加密；
            rsa.FromXmlString(prKey.Text);

            byte[] arrEnc = Convert.FromBase64String(encypt.Text); //Enc為需要解密的字串
            byte[] arrDec = rsa.Decrypt(arrEnc, false);

            decypt.Text = Encoding.UTF8.GetString(arrDec);
        }


    }
}