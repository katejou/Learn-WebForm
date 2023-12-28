using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace ASP.NET_EX1_.EX_11
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            //// EX_11.(1.2.3) 
            //// Exception Lost ?  
            ////因為後端的PageLoad 出現問題時前端的 Page 屬性已經給了對方。
            ////對方因為 PageLoad 問題，收到 302 狀態碼，於是召喚 Page 屬性中的 ErrorPage / Application_Error 處理。
            ////因為它不是一有問題就攔截導向錯誤頁(如 Page_Application_err.aspx 中 Page_Error) ，而是一去一回。
            ////所以 Server.GetLastError() 錯誤會遺失, 物件會是 Null, 所以要多解一次去追回上一個 Exception  

            //Exception ex = Server.GetLastError();
            //Response.Write(ex.InnerException.Message);   // <--- 注意要多解一次
            //Server.Transfer("Err.html");   
            //Server.ClearError();
            //// 試關閉 Page 的攔截，測這個方法。



            //// EX 11.4
            //Exception ex = Server.GetLastError();
            //var logPath = Server.MapPath("~/EX_11/log.txt");

            //FileStream fs = default(System.IO.FileStream);

            //if (!File.Exists(logPath))
            //{
            //    fs = File.Create(logPath);
            //    fs.Close();   // 和 PDF 教材不同 , 這個應該放這裡。才不會和下面搶。
            //}

            //StreamWriter sw = File.AppendText(logPath);  
            //// 和 PDF 教材不同， new System.IO.StreamWriter(fs);只能在 create 也即是第一次之後用。
            //// 而我要用很多次
            //sw.WriteLine(DateTime.Now.ToString() + " , " + ex.InnerException.Message);
            //sw.Close();
            

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}