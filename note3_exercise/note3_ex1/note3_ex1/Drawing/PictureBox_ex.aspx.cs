using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Windows.Forms;

namespace note3_ex1.Drawing
{
    public partial class PictureBox_ex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // P 265 
            Bitmap flagB;
            Graphics flagG;

            flagB = new Bitmap(200, 100);
            flagG = Graphics.FromImage(flagB);
            flagG.Clear(Color.DarkOrchid);

            flagG.FillRectangle(Brushes.Red, 0, 0, 200, 10);
            flagG.FillRectangle(Brushes.White, 0, 10, 200, 10);
            flagG.FillRectangle(Brushes.Red, 0, 20, 200, 10);
            flagG.FillRectangle(Brushes.White, 0, 30, 200, 10);
            flagG.FillRectangle(Brushes.Red, 0, 40, 200, 10);
            flagG.FillRectangle(Brushes.White, 0, 50, 200, 10);

            PictureBox pictureBox1 = new PictureBox();
            pictureBox1.Location = new Point(50, 50);
            //this.Controls.Add(pictureBox1);  // <-- 這裡不是WinForm 沒有辨法實作。
            pictureBox1.Image = flagB;

            // https://docs.microsoft.com/zh-tw/dotnet/api/system.drawing.imaging.encoderparameter?view=net-5.0
            System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
            EncoderParameters myEncoderParameters = new EncoderParameters(1);
            EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 200L);
            myEncoderParameters.Param[0] = myEncoderParameter;
            ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);
            flagB.Save(Server.MapPath("flag.jpg"), jpgEncoder, myEncoderParameters);// 存成新檔

            Page.Response.ContentType = "image/jpeg";
            flagB.Save(Page.Response.OutputStream, ImageFormat.Jpeg);  // 網頁上顯示(單單一張圖片)
            flagB.Save(Server.MapPath("flag2.jpg"), ImageFormat.Jpeg); // 和上面的方法作對比 (沒有差別)

            flagB.Dispose();
            flagG.Dispose();

        }

        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }

            return null;
        }
    }
}