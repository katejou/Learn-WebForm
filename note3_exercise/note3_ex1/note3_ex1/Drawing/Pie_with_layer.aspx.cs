using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;

namespace note3_ex1.Drawing
{
    public partial class Pie_with_layer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // P 260 
            Bitmap objBitmap;
            Graphics g;

            objBitmap = new Bitmap(400, 440);
            g = Graphics.FromImage(objBitmap);
            g.Clear(Color.White);

            Pen p = new Pen(Color.Blue);
            Pen borderPen = new Pen(Color.Black, 5);
            HatchBrush myprod = new HatchBrush(HatchStyle.Cross, Color.Red, Color.Pink);

            Rectangle rec1 = new Rectangle(50, 50, 150, 150);
            Rectangle rec2 = new Rectangle(60, 40, 150, 150);

            g.DrawEllipse(borderPen, rec1); // 用長方形和黑外線筆畫圓形
            g.FillPie(Brushes.Blue, rec1, 0.0f, 250.0f); // 填好由長方形演生的圓形的由90-(90+250)度，用藍筆。
            g.DrawPie(borderPen, rec2, 251.0f, 110.0f); // 用第二個長方形和黑筆，畫(某一個度數以內的扇形)
            g.FillPie(myprod, rec2, 251.0f, 110.0f); // 用筆觸填好扇形

            // 標題
            string title_txt = "市場佔有率";
            Font titleFont = new Font("標楷體", 20, FontStyle.Bold);
            float height = g.MeasureString(title_txt, titleFont).Height; // 計算出上面的字體要多高的長方形才可以包好。
            Rectangle titleRec = new Rectangle(20, 220, 300, (int)height + 20);

            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center; // 橫向置中
            sf.LineAlignment = StringAlignment.Center; // 直向置中

            g.DrawString(title_txt, titleFont, Brushes.Blue, titleRec, sf); // 寫字
            g.DrawRectangle(Pens.SkyBlue, titleRec); // 畫出字的外框長方形

            Page.Response.ContentType = "image/jpeg"; // 這句是參考LineChart那一邊出來的，非常有用
            objBitmap.Save(Page.Response.OutputStream, ImageFormat.Jpeg);  // 網頁上顯示(單單一張圖片)

            objBitmap.Dispose();
            g.Dispose();

        }
    }
}