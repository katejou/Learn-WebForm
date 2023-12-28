using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Windows.Forms;
using System.Web;
using System.Drawing;

namespace note3_ex1.Drawing
{
    /// <summary>
    /// flag_pic_gt_para 的摘要描述
    /// </summary>
    public class flag_pic_gt_para : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            // 新的 ashx 不可以用複製來新增，否則即使是改了Class 的名稱，但 Routing 還是送不到這個地方。
            
            var l1 = context.Request.Params["L1"];
            var l2 = context.Request.Params["L2"];
            var l3 = context.Request.Params["L3"];

            Bitmap flagB;
            Graphics flagG;

            flagB = new Bitmap(100, 60);
            flagG = Graphics.FromImage(flagB);
            flagG.Clear(Color.White);

            flagG.FillRectangle(Brushes.Red, 0, 0, int.Parse(l1), 10);
            flagG.FillRectangle(Brushes.White, 0, 10, 100, 10);
            flagG.FillRectangle(Brushes.Red, 0, 20, int.Parse(l2), 10);
            flagG.FillRectangle(Brushes.White, 0, 30, 100, 10);
            flagG.FillRectangle(Brushes.Red, 0, 40, int.Parse(l3), 10);
            flagG.FillRectangle(Brushes.White, 0, 50, 100, 10);

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