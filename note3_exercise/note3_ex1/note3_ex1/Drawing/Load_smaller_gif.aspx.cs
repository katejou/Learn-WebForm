using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;

namespace note3_ex1.Drawing
{
    public partial class Load_smaller_gif : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Bitmap objBitmap;
            Bitmap bmp;  // 縮子的那一張圖和作為基底的那一張圖要分開！
            Graphics g;  

            objBitmap = new Bitmap(200, 200);
            g = Graphics.FromImage(objBitmap);
            g.Clear(Color.Aqua);

            bmp = new Bitmap(Server.MapPath("Q.gif"));
            Image pThumbnail = bmp.GetThumbnailImage(100, 100, null, new IntPtr());
            g.DrawImageUnscaled(pThumbnail, 0, 0, pThumbnail.Width, pThumbnail.Height);

            Page.Response.ContentType = "image/gif"; // 這句是參考LineChart那一邊出來的，非常有用
            objBitmap.Save(Page.Response.OutputStream, ImageFormat.Gif);  // 網頁上顯示(單單一張圖片)

            objBitmap.Dispose();
            g.Dispose();
        }
    }
}