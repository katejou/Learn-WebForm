using System;
using ASP.NET_EX1_.EX9.JavaScript_AJAX;

namespace ASP.NET_EX9._2_
{
    public partial class EX9_7 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //TestOfSingletonLock lockMe = new TestOfSingletonLock();
            //TestOfSingletonLock lockMe = TestOfSingletonLock.Instance();
            //lock (lockMe)
            //{
                // Thread.Sleep(2000);  // 應用來實測 Singleton Lock 的功能
                // 如果 ALAX 的事物, 明明是兩個不同的執行緒
                // 一個會睡，一個不睡。
                // 睡的那個先進行，會 Hold 住鎖 5 秒。
                // 「不睡的那個」慢「睡的那個」5秒以內進行。 ( 但也不要按得太快，讓這個 Thread 有機會先搶到鎖)
                // 實測出鎖是有用的，因為「不睡的那個」，的確會等睡的那個進行完才拿到 Lock ，然後才進行下去。

                // 但是第一次 F5 出來的那個一個不太準...? 「不睡的那個」 總會比 「睡的那個」先搶到鎖…
                // 但再試幾次又沒有問題…

                string ID = Request.Form["ID"]; //接受傳入的參數
                Response.Write("Hello ID Value : " + ID);
            //}
        }
    }
}