using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ThrowExceptionTest
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string a = Method1();
            }
            catch (Exception ex)
            {
                WriteLog(ex);
            }
        }

        private string Method1()
        {
            try
            {
                string b = Method2();
                return "1";
            }
            catch
            {
                throw;
            }
                                 
        }

        private string Method2()
        {
            try
            {
                string b = Method3();
                return "2";
            }
            catch
            {
                throw;
            }
        }
        private string Method3()
        {
            try
            {
                throw new Exception("test");
            }
            catch
            {
                throw;
            }
        }

        private void WriteLog(Exception ex)
        {
            string logPath = Server.MapPath("/log");
            string logFileName = "Testing_Exception_throw_error_log.txt";

            // 要合成一個時間。
            string nowTime = DateTime.Now.ToShortDateString();
            nowTime += "   " + DateTime.Now.ToShortTimeString();

            if (!File.Exists(logPath + "\\" + logFileName))
            {
                //建立檔案
                File.Create(logPath + "\\" + logFileName).Close();
            }

            // https://dotblogs.com.tw/Harry/2016/10/14/181017
            // https://ithelp.ithome.com.tw/articles/10196899


                using (StreamWriter sw = File.AppendText(logPath + "\\" + logFileName))
                {
                    sw.WriteLine("執行時間 : " + nowTime);
                    sw.WriteLine(ex.ToString());
                    sw.WriteLine();
                }

        }
    }
}