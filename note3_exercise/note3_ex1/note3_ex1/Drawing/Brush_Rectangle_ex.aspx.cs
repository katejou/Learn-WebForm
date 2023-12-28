using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Web.UI;

namespace note3_ex1.Drawing
{
    public partial class Brush_Rectangle_ex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Bitmap objBitmap;
            Graphics g;

            objBitmap = new Bitmap(400, 440);
            g = Graphics.FromImage(objBitmap);
            g.Clear(Color.Beige);

            Rectangle r1 = new Rectangle(50, 50, 150, 50);
            LinearGradientBrush b1 = new LinearGradientBrush(r1, Color.Green, Color.Yellow, LinearGradientMode.Vertical);
            g.FillRectangle(b1, r1);


            Rectangle r2 = new Rectangle(50, 150, 150, 50);
            GraphicsPath gp = new GraphicsPath();
            gp.AddRectangle(r2);
            PathGradientBrush b2 = new PathGradientBrush(gp);
            b2.CenterColor = Color.Red; // 形狀中間色
            b2.SurroundColors = new Color[] { Color.Aqua, Color.BlueViolet, Color.Aqua, Color.BlueViolet }; 
            // 可以加減，現在是四角的顏色
            g.FillRectangle(b2, r2);


            Rectangle r3 = new Rectangle(50, 250, 150, 50);
            HatchBrush b3 = new HatchBrush(HatchStyle.Cross, Color.Yellow, Color.Green);
            g.FillRectangle(b3, r3);

            Page.Response.ContentType = "image/jpeg"; // 這句是參考LineChart那一邊出來的，非常有用
            objBitmap.Save(Page.Response.OutputStream, ImageFormat.Jpeg);  // 網頁上顯示(單單一張圖片)

            objBitmap.Dispose();
            g.Dispose();
        }
    }
}