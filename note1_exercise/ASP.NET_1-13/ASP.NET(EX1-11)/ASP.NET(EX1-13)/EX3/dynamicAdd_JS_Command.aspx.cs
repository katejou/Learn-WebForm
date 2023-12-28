using System;


namespace ASP.NET_EX3._5_
{
    public partial class ASP_NET_EX3__5_ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (IsPostBack == false)
            //{
                Button1.OnClientClick = "function1()";
                Button2.OnClientClick = "function2()";
                Button3.OnClientClick = "function3()";

                ClientScript.RegisterClientScriptBlock(
                    this.GetType(),
                    "1",
                    "function function1() {alert('這是 RegisterClientScriptBlock'); return false;}",
                    true);

                ClientScript.RegisterStartupScript(
                    this.GetType(),
                    "2",
                    "function function2() {alert('這是 RegisterStartupScript');}",
                    true);

                ClientScript.RegisterClientScriptInclude(
                    this.GetType(),
                    "3",
                    "JavaScript1.js");  // 傳喚到 這個檔案裡的功能
           

            // 這個放了在 function1 的下方 ??? 作用是什麼？
            // https://ithelp.ithome.com.tw/questions/10188649


            // 意思是︰當用戶第一次開這個頁面的時候，我已經把方法都寫到對方的瀏覽器了。
            //          所以當按 Button 時，它不用再 PostBack 回來 PageLoad 我？
            //          否, 這些方法是在 PostBack 之前做的不錯，但是做完一次動作還是回來 PageLoad。
            //          差別只是先後，一般方法是會 PageLoad 再做 onclick 的方法。

            // 第一種和第二種方法的差別？
            // 為什麼第一種可以 return false ?
            // https://dotblogs.com.tw/boei/2010/07/13/16505
            // https://www.twblogs.net/a/5b7fcdde2b717767c6b1c410
            //   反正就是當轉化為最終的 HTML 時，放入的位置不一樣，和之後學的東東組合上會有效果的不同。   // <-- 但我暫時不知道有什麼用，第三個方法有什麼用途
            // https://dotblogs.com.tw/henry/2011/07/11/31455

        }
    }
}