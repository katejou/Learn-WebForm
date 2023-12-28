using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web.UI;

namespace note3_ex1.Drawing
{
    public partial class Rectangle_ex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Bitmap objBitmap;
            Graphics g;

            objBitmap = new Bitmap(400, 440);
            g = Graphics.FromImage(objBitmap);
            g.Clear(Color.Beige);

            SolidBrush b1 = new SolidBrush(Color.DarkBlue);
            g.FillRectangle(b1, 50, 50, 150, 20);
            g.FillRectangle(Brushes.DarkViolet, 100, 150, 20, 150);

            Page.Response.ContentType = "image/jpeg"; // 這句是參考LineChart那一邊出來的，非常有用
            objBitmap.Save(Page.Response.OutputStream, ImageFormat.Jpeg);  // 網頁上顯示(單單一張圖片)
           
            objBitmap.Dispose();
            g.Dispose();

        }
    }
}