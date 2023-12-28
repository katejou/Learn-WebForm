using System;
using System.IO;
using System.Web;
namespace note3_ex3
{
    class Do
    {
        /// <summary>
        /// 防止同時寫 Log 的門鎖
        /// </summary>
        private sealed class LockOfLog
        {
            static readonly LockOfLog TheOneAndOnly_ObjectAttribute = new LockOfLog();
            LockOfLog() { }
            internal static LockOfLog Instance() => TheOneAndOnly_ObjectAttribute;
        }

        /// <summary>
        /// 會傳入 errMsg 的寫Log
        /// </summary>
        internal static void WriteLog(string errMsg, string logFileName)
        {
            // 取路徑
            // https://tm731531.pixnet.net/blog/post/379436566

            // 注意這個 .cs 檔所在的位置，如果 IIS 架站後，找不到路徑，說部份的路徑(前段)不對。 <- 那不是真的。(前段那個虛擬地址沒有問題，反是檔案所在的層級問題。)
            string log_path_fn_ext = HttpContext.Current.Server.MapPath("~/Log") + "\\" + logFileName + ".txt";
            string nowTime = DateTime.Now.ToShortDateString() + "   " + DateTime.Now.ToShortTimeString();

            // 寫入檔案
            // https://dotblogs.com.tw/Harry/2016/10/14/181017

            if (File.Exists(log_path_fn_ext))
            {
                if (new FileInfo(log_path_fn_ext).Length > 1024 * 20) // 如果檔案大於 20 KB (大約是寫 30 次，然後清空再寫)
                    File.WriteAllText(log_path_fn_ext, String.Empty);  // 清空
                                                                       // https://stackoverflow.com/questions/5469812/verify-the-size-of-an-file-and-if-it-is-bigger-then-x-empty-it
            }
            else   // 如果檔案不存在
                File.Create(log_path_fn_ext).Close();//建立檔案

            LockOfLog lockMe = LockOfLog.Instance();
            lock (lockMe)
            {
                using (StreamWriter sw = File.AppendText(log_path_fn_ext))
                {
                    sw.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
                    sw.WriteLine("執行時間 : " + nowTime);
                    sw.WriteLine(errMsg);
                    sw.WriteLine();
                }
            }

            // 如果因為寫 LOG 而出錯，也沒有辨法再寫LOG了，只好讓它跳到 Application 層的出錯處理。

        }

    }  // end of DO

} // end of namespace