using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NET_EX5._6_
{
    public partial class ASP_NET_EX_5_6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Trace.TraceFinished += new TraceContextEventHandler(Trace_TraceFinished);
        } // 為什麼是 += ? .... 不想再深究這個是什麼了。
        void Trace_TraceFinished(object sender, TraceContextEventArgs e)
        {
            //列舉追蹤記錄 (捉到最新的訊息。)
            foreach (TraceContextRecord r in e.TraceRecords)
            {
                if (r.Message == "自設的Trace.Warn")
                {
                    Response.Write("我是用if捉出來的自設內容︰");
                    Response.Write("<br/>");
                    Response.Write(r.Message);
                    Response.Write("<br/>");
                    Response.Write("  因為我是在Page Load做的，之前的紅字會被清理。去Trace.axd找找吧");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Trace.Warn("Test message", "自設的Trace.Warn");
        }
    }
}