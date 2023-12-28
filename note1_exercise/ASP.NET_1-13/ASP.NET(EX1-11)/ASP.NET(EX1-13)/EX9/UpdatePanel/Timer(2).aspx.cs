using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading; // 這個是測執行緒的。


namespace ASP.NET_EX9._2_
{
    public partial class EX9_5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(10000);
            //var thread2 = new Thread(new ThreadStart(Sleep));
            //thread2.Start();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(10000);
            //var thread1 = new Thread(new ThreadStart(Sleep));
            //thread1.Start();
        }

        //private void Sleep()
        //{
        //    System.Threading.Thread.Sleep(10000);
        //}


    }
}