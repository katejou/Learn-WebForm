using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;

namespace note3_ex1.Drawing
{
    public partial class Load_GIF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Bitmap objBitmap;
            Graphics objGraphics;

            //objBitmap = new Bitmap(100, 100);
            //objGraphics = Graphics.FromImage(objBitmap);
            //objGraphics.Clear(Color.White);

            objBitmap = new Bitmap(Server.MapPath("Q.gif"));
            objGraphics = Graphics.FromImage(objBitmap);  // 要測下一行的無能要先封了這行
            //objGraphics.DrawImage(objBitmap, 10, 10, 10, 10); // <-- 無法指定位置和大小

            Page.Response.ContentType = "image/gif"; // 這句是參考LineChart那一邊出來的，非常有用
            objBitmap.Save(Page.Response.OutputStream, ImageFormat.Gif);  // 網頁上顯示(單單一張圖片)

            objBitmap.Dispose();
            objGraphics.Dispose();
        }
    }
}