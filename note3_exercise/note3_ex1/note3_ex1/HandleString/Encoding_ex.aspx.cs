using System;
using System.Text;


namespace note3_ex1.HandleString
{
    public partial class Encoding_ex : System.Web.UI.Page
    {   // P 148
        protected void Page_Load(object sender, EventArgs e)
        {
            Encoding big5 = Encoding.GetEncoding("big5");
            byte[] buffer = big5.GetBytes(LB2.Text);
            foreach (var b in buffer)
                LB4.Text += b.ToString() + " ";
            LB6.Text = big5.GetString(buffer);

            Encoding utf8 = Encoding.UTF8; // 這個屬性會回傳一個物件
            buffer = utf8.GetBytes(LB6.Text);
            foreach (var b in buffer)
                LB8.Text += b.ToString() + " ";
            LB10.Text = utf8.GetString(buffer);

        }
    }
}