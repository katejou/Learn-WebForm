using System;
using System.Threading;
using System.Threading.Tasks;

namespace APM_Model
{
    class Program
    {
        static int Counter(int startno, int stopno)
        {
            int data = 0;
            for (; startno <= stopno; startno++)
            {
                data += startno;
                Thread.Sleep(50);
            }
            return data;
        }

        // 委派
        delegate int MyDelegate(int startno, int stopno);

        // 建立委派實體，委派會接受和它有一樣參數的方法
        static MyDelegate worker = new MyDelegate(Counter);

        // 輸出執行結果
        static void CallbackMethod(IAsyncResult ar)
        {
            // 這個平台又不支援它了…什麼鬼…
            int result = worker.EndInvoke(ar);// 委派有 EndInvoke 的方法
                                              // 只要傳入 IAsyncResult 最可以得到 Counter 現在 data 的值？
                                              // 即時迴圈還沒有跑完？
            Console.WriteLine("Result = " + result);
        }

        static void Main(string[] args)
        {
            // 建立CallBackMethod的非同步容器
            AsyncCallback asynccb = new AsyncCallback(CallbackMethod);
            // 委派容器的實體，啟動時要他代理的方法參數放前面，輸出的方法放後面…最得一個我暫時不管它是什麼。
            //worker.BeginInvoke(1, 100, asynccb, null);
            //Console.Read();


            // 發生 runtimeerror ，說這個平台不支援…
            // 好不容易用到了 委派…算了，我也沒有實用…只是以上的推論，都沒有證實啊…
            // https://stackoverflow.com/questions/66462388/operation-is-not-supported-on-this-platform-exmple
            // 這個網頁說要 .Net FrameWork，Core 不支援。但是我在專案屬性那邊沒有這個選項…
            // https://www.cnblogs.com/Zev_Fung/p/12823418.html#_label1
            // 這個網站說可以這樣改︰
            //IAsyncResult result = caller.BeginInvoke(3000, out threadid, null, null);
            //var workTask = Task.Run(() => caller.Invoke(3000, out threadid));
            var workTask = Task.Run(() => worker.Invoke(1, 100)); // <-- 但是這樣沒有辨法帶 委法的那個方法
            CallbackMethod(workTask); // 這個跑到 worker.EndInvoke 那一行又不行了。
            Console.Read();

            // 我放棄…

        }
    }
}
