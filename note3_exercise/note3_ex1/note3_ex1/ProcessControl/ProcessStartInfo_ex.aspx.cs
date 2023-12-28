using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace note3_ex1.ProcessControl
{
    public partial class ProcessStartInfo_ex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // P 339
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // 開啟哪一個程序
            ProcessStartInfo info = new ProcessStartInfo("C:\\Program Files\\Notepad++\\notepad++.exe");
            // 開啟哪一個檔案
            info.Arguments = @"C:\Users\kate_jou\source\repos\ASP.NET\note3_exercise\note3_ex1\note3_ex1\ProcessControl\ToOpen.txt"; 

            if (CheckBox1.Checked)
            {   // 由於我沒有辨法，也不想多建一個user，所以我不會實作這個部份
                info.UseShellExecute = false;
                info.UserName = "UserName";
                info.Password = new System.Security.SecureString();
                info.Password.AppendChar(Convert.ToChar("1")); // <- 我不知道這個意思是什麼。
            }

            Process.Start(info);
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Process[] p = Process.GetProcessesByName("notepad++");

            if (p.Length > 0 && !p[0].HasExited)
            {
                Label1.Text = p[0].ProcessName + "已結束"; // <-- 不能放在被刪除後

                p[0].CloseMainWindow();
                p[0].WaitForExit();
                p[0].Close();
            }
            
        }
    }
}