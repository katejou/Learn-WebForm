using System;


namespace ASP.NET_EX2._1_
{
     // 這個是來源的後端。

   public partial class Source : System.Web.UI.Page
   {
        
        public string myText
        {   //  Previous Page 的 Property
            get { return TextBox1.Text; }
        }  // 和 Target3 的 Page_Load 說︰ Response.Write(PreviousPage.myText);


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)  // Query Stirng 連結
        {// Query Stirng 連結
            Response.Redirect("EX2_1Target1.aspx?myText=" + TextBox1.Text);
            // 以 myText 作為 Key 把 TextBox1所輸入的文字傳給 ~/Target1.aspx
            // Target1 的 PAGE LOAD : Response.Write(Request.QueryString["myText"]);
        }

    }
}