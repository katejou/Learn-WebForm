using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;

namespace note3_ex1.Drawing
{
    public partial class Text_Area : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Bitmap objBitmap;
            Graphics g;

            objBitmap = new Bitmap(400, 440);
            g = Graphics.FromImage(objBitmap);
            g.Clear(Color.White);

            // 方格中 文字外溢 --------------------
            Rectangle r = new Rectangle(50, 50, 100, 100);
            string s = "繪製文字時可以限制文字僅在某個區塊中" +
                       "，文字從左自右印出。" +
                       "超出範圍的部份會自動折行，" +
                       "但是底下超過的就看不到了。";
            Font f = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point);
            g.DrawString(s, f, Brushes.Blue, r);
            g.DrawRectangle(Pens.Red, r);

            // 方格中 文字擺放 --------------------
            r = new Rectangle(200, 50, 100, 100);
            s = "文字";
            StringFormat sf = new StringFormat();
            //水平對齊
            //Far = 靠右, Near = 靠左, Center = 置中
            sf.Alignment = StringAlignment.Far; // 靠右
            //垂直對齊
            //Far = 貼底, Near = 貼頂, Center = 置中
            sf.LineAlignment = StringAlignment.Near; // 貼頂
            g.DrawString(s, f, Brushes.Blue, r, sf);
            g.DrawRectangle(Pens.Red, r);


            // 方格中 文字方向 -----------------------------

            r = new Rectangle( 50, 200, 100, 100);
            s = "文字";
            sf = new StringFormat();

            sf.FormatFlags = StringFormatFlags.DirectionVertical;
            sf.Alignment = StringAlignment.Far; // 和上面打橫的時候意思反過來，變成︰靠左
            sf.LineAlignment = StringAlignment.Near;// 和上面打橫的時候意思反過來，變成︰貼底
            g.DrawString(s, f, Brushes.Blue, r, sf);
            g.DrawRectangle(Pens.Red, r);

            // 方格中 文字去鋸齒 -----------------------------

            r = new Rectangle(200, 200, 100, 100);
            g.TextRenderingHint = TextRenderingHint.AntiAlias; // <---------
            s = "去鋸齒文字";
            g.DrawString(s, f, Brushes.Blue, r, sf);
            g.DrawRectangle(Pens.Red, r);


            Page.Response.ContentType = "image/jpeg"; // 這句是參考LineChart那一邊出來的，非常有用
            objBitmap.Save(Page.Response.OutputStream, ImageFormat.Jpeg);  // 網頁上顯示(單單一張圖片)
           
            objBitmap.Dispose();
            g.Dispose();
        }
    }
}