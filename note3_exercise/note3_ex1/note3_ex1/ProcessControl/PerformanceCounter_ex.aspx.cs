using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace note3_ex1.ProcessControl
{
    public partial class PerformanceCounter_ex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // P 375
        }

        /// <summary>
        /// 建立效能計數器與種類
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (PerformanceCounterCategory.Exists("Mod08_3"))
            {
                Label1.Text = "Mod08_3效能種類已建立";
                return;
            }

            CounterCreationData NewCounter = new CounterCreationData();
            NewCounter.CounterName = "OrderCounter";
            NewCounter.CounterType = PerformanceCounterType.NumberOfItems64;
            NewCounter.CounterHelp = "建立訂單的總數";
            CounterCreationDataCollection col = new CounterCreationDataCollection();
            col.Add(NewCounter);
            PerformanceCounterCategory.Create(
            "Mod08_3",
            "Mod08_3應用程式",
            PerformanceCounterCategoryType.SingleInstance,
            col);
            // 在上述的Create動件被拒絕了。System.UnauthorizedAccessException: '拒絕存取登錄機碼 
            // 用 系統管理員 的身份 再試一次  --> 成功
            // 我關了視窗，再執行一次，它會說︰ Mod08_3效能種類已建立，但是 Button2 按下去，還是會從 1 開始算。
        }

        /// <summary>
        /// 建立新訂單
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            PerformanceCounter counter = new PerformanceCounter("Mod08_3", "OrderCounter", false); 
            counter.Increment();

            // PDF 上的那一個Performance Monitor窗戶我找不到(大概已經太舊版了)，所以我用程式碼讀取，顯示到Label2
            
            Label2.Text = counter.NextValue().ToString();

            // 所以這個東東的作用就是建立一個在伺服器上的Counter ? 
        }
    }
}