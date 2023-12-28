using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace note3_ex1.ProcessControl
{
    public partial class EventLog2 : System.Web.UI.Page
    {
        List<EventLogEntry> entryList = new List<EventLogEntry>();
        List<string> strList1 = new List<string>();
        List<string> strList2 = new List<string>();
        List<string> strList3 = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            // P350

            // 要用管理員的權限跑，才可以寫入，不然只能讀取。
            // 寫入
            //EventLog myLog = new EventLog("Application"); // 不是特別選的，只是PDF用它做例子。
            //myLog.Source = "MSSQL_$SQLEXPRESS"; // 不是特別選的，只是PDF用它做例子。
            EventLog myLog = new EventLog("AAA"); // 隨便寫也可以
            myLog.Source = "BBB"; // 隨便寫也可以
            myLog.WriteEntry("1234Information", EventLogEntryType.Information);
            myLog.WriteEntry("5678Warning", EventLogEntryType.Warning);
            myLog.WriteEntry("90Error", EventLogEntryType.Error);
        }

        // 讀取
        protected void Button1_Click(object sender, EventArgs e)
        {
            EventLog myLog = new EventLog("AAA");
            myLog.Source = "BBB";

            foreach (EventLogEntry entry in myLog.Entries)
                entryList.Add(entry);

            for (int i = entryList.Count - 1; i > entryList.Count - 4; i--)
            {
                strList1.Add(entryList[i - 1].EntryType.ToString());
                strList2.Add(entryList[i - 1].Message);
                strList3.Add(entryList[i - 1].TimeWritten.ToString());
            }

            ListBox1.DataSource = strList1;
            ListBox1.DataBind();
            ListBox2.DataSource = strList2;
            ListBox2.DataBind();
            ListBox3.DataSource = strList3;
            ListBox3.DataBind();
        }

        //刪除
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (EventLog.Exists("AAA"))
            {
                EventLog.Delete("AAA");
                Label1.Text = "已刪除";
            }
            else
                Label1.Text = "無此檔";

            // 再次讀取
            //EventLog myLog = new EventLog("AAA");
            //myLog.Source = "BBB";

            //foreach (EventLogEntry entry in myLog.Entries)  // 再次讀取 會卡這行，說無此檔
            //    entryList.Add(entry);

            strList1.Clear();
            ListBox1.DataSource = strList1;
            ListBox1.DataBind();
            strList2.Clear();
            ListBox2.DataSource = strList2;
            ListBox2.DataBind();
            strList3.Clear();
            ListBox3.DataSource = strList3;
            ListBox3.DataBind();
        }
    }
}