using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Permissions;
using System.IO;

namespace note3_ex3
{
    public partial class CAS_Declarative_Imperative : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [FileIOPermission(SecurityAction.Demand, Write = @"C:\Users\kate_jou\source\repos\Learning\ASP.NET\note3_exercise\note3_ex3\note3_ex3")]
        protected void Declarative_Click(object sender, EventArgs e)
        {
            CreateFile();
            Label1.Text = "Declarative_Click 建立 Declarative_Imperative.txt";
        }


        //[FileIOPermission(SecurityAction.Demand)]
        [FileIOPermission(SecurityAction.Deny)]
        [Obsolete]
        void CreateFile()
        {
            using (StreamWriter sw = File.CreateText(@"C:\Users\kate_jou\source\repos\Learning\ASP.NET\note3_exercise\note3_ex3\note3_ex3\Declarative_Imperative.txt"))
            {
            }
        }

        protected void Imperative_Click(object sender, EventArgs e)
        {
            FileIOPermission fp = new FileIOPermission(FileIOPermissionAccess.Write, @"C:\Users\kate_jou\source\repos\Learning\ASP.NET\note3_exercise\note3_ex3\note3_ex3\Declarative_Imperative.txt");
            fp.Demand();
            //fp.Deny();//<-- 有已過時的綠線
            try
            {
                CreateFile();
                Label1.Text = "Imperative_Click 建立 Declarative_Imperative.txt";
            }
            catch (Exception) 
            {
                Label1.Text = "Imperative_Click 無法建立 Declarative_Imperative.txt";
            }
        }
    }
}