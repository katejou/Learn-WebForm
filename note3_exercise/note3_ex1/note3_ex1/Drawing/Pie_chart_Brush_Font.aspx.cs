using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;

namespace note3_ex1.Drawing
{
    public partial class Pie_chart_Brush_Font : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // https://stackoverflow.com/questions/7752020/aspcan-i-enable-user-to-draw-a-line-in-webform

            Bitmap objBitmap;
            Graphics objGraphics;

            objBitmap = new Bitmap(400, 440);
            objGraphics = Graphics.FromImage(objBitmap);
            objGraphics.Clear(Color.White);

            Brush b1 = new SolidBrush(Color.LightSkyBlue);
            Brush b2 = new SolidBrush(Color.LightBlue);
            Brush b3 = new SolidBrush(Color.Lavender);

            Pen p = new Pen(Color.Yellow, 0);
            Rectangle rect = new Rectangle(10, 10, 280, 280);
            objGraphics.DrawEllipse(p, rect); // 畫出圓形
            objGraphics.FillPie(b1, rect, 0f, 60f);   // 90 - 150 度
            objGraphics.FillPie(b2, rect, 60f, 150f);  // 150 - 300 度
            objGraphics.FillPie(b3, rect, 210f, 150f);  // 300 - 450 度  (因為是由90度開始的，所以要360+90=450才是結束)

            FontFamily fontfml = new FontFamily(GenericFontFamilies.Serif);
            Font font = new Font(fontfml, 16);
            SolidBrush brush = new SolidBrush(Color.Blue);
            objGraphics.DrawString(" - Brush & Font -", font, brush, 70, 300);

            Page.Response.ContentType = "image/jpeg"; // 這句是參考LineChart那一邊出來的，非常有用
            objBitmap.Save(Page.Response.OutputStream, ImageFormat.Jpeg);  // 網頁上顯示(單單一張圖片)
            objBitmap.Save(Server.MapPath("pie_chart.jpg"), ImageFormat.Jpeg);     /// Server.MapPath 指的就是目前的資料夾

            objBitmap.Dispose();
            objGraphics.Dispose();

        }
    }
}