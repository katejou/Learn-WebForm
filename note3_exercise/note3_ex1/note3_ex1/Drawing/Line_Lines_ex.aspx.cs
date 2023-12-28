using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace note3_ex1.Drawing
{
    public partial class Line_Lines_ex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ////https://bbs.csdn.net/topics/60286609
            int bmpWidth = 250;
            int bmpHeight = 250;
            Bitmap bmp = new Bitmap(bmpWidth, bmpHeight);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.Snow);
            // P 242

            // 單線
            Pen p = new Pen(Color.Blue);
            p.Width = 2;
            p.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;
            g.DrawLine(p, 0, 0, 250, 250); // 左上到右下 一條藍線 

            // 多線
            p = new Pen(Color.Red);
            p.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            g.DrawLines(p, new Point[] { new Point(0,250), new Point(40, 170), new Point(210,80), new Point(250,0) });
            // Point 單輸入一個值的話，會預設 Y 值為 0 
            // 題外︰兩端是各減/加 40 , 80 ，才做出風車的形態。

            Page.Response.ContentType = "image/jpeg"; // 這句是參考LineChart那一邊出來的，非常有用
            bmp.Save(Page.Response.OutputStream, ImageFormat.Jpeg);  // 網頁上顯示(單單一張圖片)
            //bmp.Save(Server.MapPath("line.jpg"), ImageFormat.Jpeg);     /// Server.MapPath 指的就是目前的資料夾

            bmp.Dispose();
            g.Dispose();

        }
    }
}