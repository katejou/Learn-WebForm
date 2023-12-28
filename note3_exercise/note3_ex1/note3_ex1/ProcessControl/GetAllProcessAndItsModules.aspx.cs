using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.ComponentModel;

namespace note3_ex1.Process_ex
{
    public partial class GetAllProcessAndItsModules : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GetPorcesses_Click(object sender, EventArgs e)
        {
            ListBox1.Items.Clear();
            foreach (Process p in Process.GetProcesses())
            {
                ListBox1.Items.Add(p.ProcessName);
            }
        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string pName = ListBox1.SelectedItem.ToString();
            Process[] ps = Process.GetProcessesByName(pName);

            if (ps.Length > 0) //不是沒有找到
            {
                try
                {
                    foreach (ProcessModule pm in ps[0].Modules) // 來到這一步就會有各種 Error，無法條例。
                    {
                        ListBox2.Items.Add(pm.ModuleName);
                    }
                }
                catch (Exception ex)
                {
                    Label1.Text = ex.Message;
                    Label2.Text = ex.ToString();                
                }

            }



        }
    }
}