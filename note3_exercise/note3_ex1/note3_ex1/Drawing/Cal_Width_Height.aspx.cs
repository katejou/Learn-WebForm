using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;

namespace note3_ex1.Drawing
{
    public partial class Cal_Width_Height : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // P 259 

            Bitmap objBitmap;
            Graphics g;

            objBitmap = new Bitmap(400, 440);
            g = Graphics.FromImage(objBitmap);
            g.Clear(Color.White);

            //Pen p = new Pen(Color.Blue);
            Font f = new Font("Arial", 20);
            string s = "文字文字";

            SizeF sizeF = new SizeF(400, 440); // <-- 背景大小
                                               
            //計算
            Single w = g.MeasureString(s, f, sizeF).Width;
            Single h = g.MeasureString(s, f, sizeF).Height;
            g.DrawString(s, f, Brushes.Blue, 50, 50);
            g.DrawRectangle(Pens.Red, 50, 50, w, h);

            s = "上面的長方形的 寛 x 高 ︰" + w.ToString() + " x " + h.ToString();
            f = new Font("Arial", 10);
            g.DrawString(s, f, Brushes.Blue, 50, 100);

            s = "對於這一個畫布的大小來說";
            g.DrawString(s, f, Brushes.Red, 60, 130);

            Page.Response.ContentType = "image/jpeg"; // 這句是參考LineChart那一邊出來的，非常有用
            objBitmap.Save(Page.Response.OutputStream, ImageFormat.Jpeg);  // 網頁上顯示(單單一張圖片)
            objBitmap.Save(Server.MapPath("pie_chart.jpg"), ImageFormat.Jpeg);     /// Server.MapPath 指的就是目前的資料夾

            objBitmap.Dispose();
            g.Dispose();


        }
    }
}