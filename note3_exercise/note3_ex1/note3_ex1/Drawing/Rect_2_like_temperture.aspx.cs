using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Web.UI;

namespace note3_ex1.Drawing
{
    public partial class Rect_2_like_temperture : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Bitmap objBitmap;
            Graphics g;
            objBitmap = new Bitmap(200, 500);
            g = Graphics.FromImage(objBitmap);
            g.Clear(Color.Beige);

            Rectangle borderRec = new Rectangle(100, 40, 50, 450);
            Rectangle tempRec = new Rectangle(110, 150, 30, 330);
            
            SolidBrush backBrush = new SolidBrush(Color.Honeydew); // 淡綠色
            Pen borderPen = new Pen(Color.Black, 5);
            LinearGradientBrush tempBrush
                = new LinearGradientBrush(tempRec, Color.Red, Color.Pink, LinearGradientMode.ForwardDiagonal); // 紅色漸變

            g.FillRectangle(backBrush, borderRec);
            g.DrawRectangle(borderPen, borderRec);
            g.FillRectangle(tempBrush, tempRec);

            Page.Response.ContentType = "image/jpeg"; // 這句是參考LineChart那一邊出來的，非常有用
            objBitmap.Save(Page.Response.OutputStream, ImageFormat.Jpeg);  // 網頁上顯示(單單一張圖片)
            objBitmap.Dispose();
            g.Dispose();

        }
    }
}