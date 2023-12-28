using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Windows.Forms;
using System.Web;

namespace note3_ex1.Drawing
{
    /// <summary>
    /// flag_pic 的摘要描述
    /// </summary>
    public class flag_pic : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
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

            context.Response.ContentType = "image/jpeg";
            flagB.Save(context.Response.OutputStream, ImageFormat.Jpeg); //回傳圖片

            flagB.Dispose();
            flagG.Dispose();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}