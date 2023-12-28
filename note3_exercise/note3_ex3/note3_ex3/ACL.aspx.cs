using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.AccessControl;
using System.IO;
using System.Security.Principal;

namespace note3_ex3
{
    public partial class ACL : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string path = @"C:\Users\kate_jou\source\repos\Learning\ASP.NET\note3_exercise\note3_ex3\note3_ex3\acl_text.txt";
            // 這個是保留繼承？我不知道FileSecurity的繼承不保留是會怎樣？但也沒有興趣知道會對這個檔案做成什麼影響。
            FileSecurity fs = new FileSecurity(path, AccessControlSections.All);  // <--- 這個要用管理員的權限去跑
            fs.SetAccessRuleProtection(true, true);
            File.SetAccessControl(path, fs);
            // 這是增加一個User1的檔案讀取權限
            FileSecurity sd = File.GetAccessControl(path);
            string account = Environment.GetEnvironmentVariable("USERDOMAIN")+ @"\esser_yen";// <-- 不能用不存用這個Domain之中的人的名字
            FileSystemAccessRule ar = new FileSystemAccessRule(account, FileSystemRights.Read, AccessControlType.Allow);
            Boolean modify;
            sd.ModifyAccessRule(AccessControlModification.Add, ar, out modify);
            File.SetAccessControl(path, sd);
            if (modify)
            { Label1.Text = "成功"; Label2.Text = ""; }

            // 讀取及顯示目前檔案權限︰
            sd = File.GetAccessControl(path);
            ListBox1.Items.Clear();
            ListBox1.Items.Add("Owner: " + sd .GetOwner(typeof(NTAccount)).Value);
            ListBox1.Items.Add("Group: " + sd.GetGroup(typeof(NTAccount)).Value);
            ListBox1.Items.Add("+++++++++++++");
            foreach (FileSystemAccessRule far in sd.GetAccessRules(true, true, typeof(NTAccount)))
            {
                ListBox1.Items.Add(far.IdentityReference.Value + "-----" +
                far.FileSystemRights.ToString() + "-----" +
                far.AccessControlType.ToString());
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string path = @"C:\Users\kate_jou\source\repos\Learning\ASP.NET\note3_exercise\note3_ex3\note3_ex3\acl_text.txt";
            // 這個是保留繼承？我不知道FileSecurity的繼承不保留是會怎樣？
            FileSecurity fs = new FileSecurity(path, AccessControlSections.All);  
            fs.SetAccessRuleProtection(false, false);  // <-- 改為不繼承
            File.SetAccessControl(path, fs);

            FileSecurity sd = File.GetAccessControl(path);
            string account = Environment.GetEnvironmentVariable("USERDOMAIN") + @"\esser_yen";
            FileSystemAccessRule ar = new FileSystemAccessRule(account, FileSystemRights.Read, AccessControlType.Allow);//<-- 改為不允許
            Boolean modify;
            sd.ModifyAccessRule(AccessControlModification.Remove, ar, out modify);
            File.SetAccessControl(path, sd);
            if (modify)
            { Label2.Text = "成功"; Label1.Text = ""; }

            // 讀取及顯示目前檔案權限︰
            sd = File.GetAccessControl(path);
            ListBox1.Items.Clear();
            ListBox1.Items.Add("Owner: " + sd.GetOwner(typeof(NTAccount)).Value);
            ListBox1.Items.Add("Group: " + sd.GetGroup(typeof(NTAccount)).Value);
            ListBox1.Items.Add("+++++++++++++");
            foreach (FileSystemAccessRule far in sd.GetAccessRules(true, true, typeof(NTAccount)))
            {
                ListBox1.Items.Add(far.IdentityReference.Value + "-----" +
                far.FileSystemRights.ToString() + "-----" +
                far.AccessControlType.ToString());
            }
        }
    }
}