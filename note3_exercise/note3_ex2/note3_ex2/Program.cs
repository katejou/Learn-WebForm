using System;
using System.Threading;
using System.Timers;

namespace note3_ex2
{
    public class MyOwnTest
    {
        public bool finshed = false;
        public int class_ID;

        public void MakeAThreadAndRun()
        {
            ThreadStart starter = new ThreadStart(Count10);
            Thread tl = new Thread(starter);
            tl.Start();
        }

        private void Count10()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine("class_ID:{0}-->Count:{1}",
                class_ID, i);
                Thread.Sleep(2000); // 每兩秒數一
            }
            finshed = true;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            #region 404 ThreadStart ParameterizedThreadStart
            //ThreadStart starter = new ThreadStart(Print); // 舊
            //ParameterizedThreadStart paramStart = new ParameterizedThreadStart(Print); //新

            //// Print這個多型，不用特別指明，有跑的時候，就會有差
            //Thread tl = new Thread(starter);
            //Thread t2 = new Thread(paramStart);

            //tl.Start();
            //t2.Start(15);// <- 多型

            ////它們是都跑 20 次，但是由不同的數字開始起跑。
            ////它們一同起跑，所以每個Cycle都一起完成，一同前進…
            ////但是它們並沒有交流。 
            #endregion

            #region 410 ThreadPool

            //WaitCallback cb = new WaitCallback(Print);// 放入等待池
            //ThreadPool.QueueUserWorkItem(cb, 1); // 從池中取出並運作
            //ThreadPool.QueueUserWorkItem(cb, 15); // 再取一次

            ////和上面一個實作的對比
            ////它也像是開了兩個Thread，同時運行。

            #endregion

            #region 412 Timer
            // TimerCallBack 和 WaitCallBack 不同，是專用於 Timer 的
            //Timer timer = new Timer(new TimerCallback(CheckStatus), null, 0, 2000);
            // 上面是PDF 的，我看不出它的作用到底是什麼？
            //TimerCallback tc = new TimerCallback(CheckStatus);
            //Timer timer = new Timer(tc, null, 0, 2000);
            // 它就只是印出了一下？
            // 我去官網看看它的作用是︰ 每 X 秒跳出來一次
            // https://docs.microsoft.com/zh-tw/dotnet/api/system.timers.timer?view=net-5.0
            //SetTimer();
            //// Timer開始，但頭一秒沒有事做，程式會先印︰
            //Console.WriteLine("\nPress the Enter key to exit the application...\n");
            //Console.WriteLine("The application started at {0:HH:mm:ss.fff}", DateTime.Now);
            //Console.ReadLine();
            //// 程式會在這裡一直等待輸入，期間Timer一直做自己的事…
            //aTimer.Stop(); // 當按下Enter，程式讀取了上一行，就會跑來「停止」timer
            //aTimer.Dispose(); // 一定要按停再解散？
            //Console.WriteLine("Terminating the application...");

            #endregion

            #region 414 SynchronzationLock
            //ThreadStart starter = new ThreadStart(PrintShare);
            //// 重點是PrintShare這個方法中的某段程式碼
            //Thread tl = new Thread(starter);
            //Thread t2 = new Thread(starter);
            //tl.Start();
            //t2.Start();
            #endregion

            #region 415 Monitor

            #region Fail
            //ThreadStart starter = new ThreadStart(PrintShare2);
            //// 重點是PrintShare2這個方法中的某段程式碼
            //Thread tl = new Thread(starter);
            //Thread t2 = new Thread(starter);
            //tl.Start();
            //t2.Start();
            ////它不能像是lock一樣，Thread不會等候資料釋放，它會直接跑出RunTimeError 
            #endregion

            #region REF
            //我覺得PDF 沒有說得很清楚，我找參考，說明他和 Lock 的分別
            // http://tsaiyuchi.blogspot.com/2015/11/c-thread-monitor.html
            //var thd1 = new Thread(delegate ()
            //{
            //    Console.WriteLine("Start thd1");

            //    try
            //    {
            //        Monitor.Enter(i);
            //        Console.WriteLine("enter thd1"); Thread.Sleep(1000);
            //    }
            //    finally { Monitor.Exit(i); Console.WriteLine("thd1 exit"); }

            //    Console.WriteLine("End thd1");
            //});


            //var thd2 = new Thread(delegate ()
            //{
            //    Console.WriteLine("Start thd2");

            //    try
            //    {
            //        Monitor.Enter(i);
            //        Console.WriteLine("enter thd2"); Thread.Sleep(1000);
            //    }
            //    finally { Monitor.Exit(i); Console.WriteLine("thd2 exit"); }

            //    Console.WriteLine("End thd2");
            //});

            //thd1.Start();
            //thd2.Start();

            //Console.ReadKey();

            // 結果是他們都開始，然後分別進入...完結
            //Start thd1
            //Start thd2

            //enter thd1
            //thd1 exit
            //End thd1

            //enter thd2
            //thd2 exit
            //End thd2 
            #endregion

            #region Fail2
            // 我覺得 Monitor 和 lock 最大的不同是它 (((( 不可以共用程式碼 ???? )))) 
            // 一定要確定一個Thread跑完一段程式碼，(所以出動到了「委派」，再做另一個。也不能引用方法，在方法中Exit…) 
            // 故也不能承傳運算值。差評…還是只是因為我不會用？反正目前只是用到寫Log，所以我不深究了…

            // 改正實驗︰
            //ThreadStart starter = new ThreadStart(PrintShare3);
            //Thread tl = new Thread(starter);
            //Thread t2 = new Thread(starter);
            //Monitor.Enter(i);
            //tl.Start();
            //Monitor.Exit(i);
            //i = (int)i + 10;
            //Monitor.Enter(i);
            //t2.Start();
            //Monitor.Exit(i); 
            #endregion

            // 不論怎麼區分，i 的值都是 10。不明所以，明明 t1 未發生，t2應該累加到 20… 也許是 static object 變化的特性…
            // 總之還是乖乖用 lock 好了。

            #region Fail3
            // https://dotblogs.com.tw/noncoder/2018/06/30/lock-Monitor
            // 我開了另一個專案，將它作為起始專案的話，就有這個參考的完整實作

            // 依上述推測︰
            // 是否不能用static，一定要先成不同的「實體」?
            //Program p = new Program();
            //var tt1 = new ThreadStart(p.PrintShare4);
            //Thread t1 = new Thread(tt1);
            //t1.Start();
            //Program pp = new Program();
            //var tt2 = new ThreadStart(pp.PrintShare4);
            //Thread t2 = new Thread(tt2);
            //t2.Start(); 
            // 還是會有RunTime Error.. 我不幹了。

            #endregion

            #endregion

            #region 429 自行測試
            
            MyOwnTest test_obj = new MyOwnTest(); test_obj.class_ID = 100;
            MyOwnTest test_obj2 = new MyOwnTest(); test_obj2.class_ID = 200;

            test_obj.MakeAThreadAndRun();
            Thread.Sleep(1000);
            test_obj2.MakeAThreadAndRun();

            SetTimerForMyTest(test_obj2);
            Thread.Sleep(3000);
            SetTimerForMyTest(test_obj);

            // 跑出來︰

            // class_ID: 100-- > Count:10
            // 檢查時間︰ 14:30:38.091  物件︰100  未完成
            // class_ID:200-- > Count:10
            // 檢查時間︰ 14:30:39.091  物件︰200  未完成
            // 檢查時間︰ 14:30:40.091  物件︰100  完成

            // 物件 200 沒有顯示 完成 
            // 原因是數到 10 的那一下，Timer也剛好檢查，但 finish 屬性還沒有來得及 = true;
            // 在 Main 因為兩個 obj 都跑完後， Main也會跑完，自然 Timer也關了，所以︰沒有檢查到 200 已完成
            Console.ReadLine();// 試試加這一行，不讓Main跑完…

            // 檢查時間︰ 14:39:12.157  物件︰100  未完成
            //class_ID:200-- > Count:10
            // 檢查時間︰ 14:39:13.155  物件︰200  未完成
            // 檢查時間︰ 14:39:14.161  物件︰100  完成
            // 檢查時間︰ 14:39:15.156  物件︰200  完成
            // 檢查時間︰ 14:39:16.160  物件︰100  完成
            // 檢查時間︰ 14:39:17.155  物件︰200  完成
            // 檢查時間︰ 14:39:18.159  物件︰100  完成
            // 檢查時間︰ 14:39:19.156  物件︰200  完成

            // 好了，這樣的話，不按Enter，它就一直跑…
            // 這個測試證明我的方法可以，儘管PDF的東東無法實作，但是他的想法啟發了我。

            #endregion
        }

        private static void SetTimerForMyTest(MyOwnTest obj)
        {
            //bool Done = obj.finshed;
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(2000);// 間隔 2 秒
            // Hook up the Elapsed event for the timer. 
            // https://stackoverflow.com/questions/9977393/how-do-i-pass-an-object-into-a-timer-event
            aTimer.Elapsed += (sender, e) => OnTimedEventForMyTest(sender, e, obj); // 當時間到了要做的事情
            aTimer.AutoReset = true; // 自己循還
            aTimer.Enabled = true;// 啟動
        }

        private static void OnTimedEventForMyTest(Object source, ElapsedEventArgs e, MyOwnTest obj)
        {
            Console.Write(" 檢查時間︰ {0:HH:mm:ss.fff}  物件︰{1}", e.SignalTime, obj.class_ID);

            if (obj.finshed)
                Console.WriteLine("  完成");
            else
                Console.WriteLine("  未完成");
        }


        private object ii = 0;
        void PrintShare4()
        {
            Monitor.Enter(ii);
            try
            {
                int j = (int)ii + 1;
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " : " + j);
                ii = j;
                Thread.Sleep(1000);
            }
            finally
            {
                Monitor.Exit(ii);
            }
        }

        static void PrintShare3()
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " : " + i);
            i = (int)i + 10;
        }

        static void PrintShare2()
        {
            Monitor.Enter(i);
            try
            {
                int j = (int)i + 1;
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " : " + j);
                i = j;
                Thread.Sleep(1000);
            }
            finally
            {
                Monitor.Exit(i);
            }
        }

        static private object i = 0;

        // 在列印的時候，不讓其他Thread更改i
        static void PrintShare()
        {
            for (int k = 0; k < 2; k++)
            {
                lock (i)
                {
                    int j = (int)i + 1;
                    Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " : " + j);
                    i = j;
                }
                Thread.Sleep(1000);
            }
        }

        private static System.Timers.Timer aTimer;

        private static void SetTimer()
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(2000);// 間隔 2 秒
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent; // 當時間到了要做的事情
            aTimer.AutoReset = true; // 自己循還
            aTimer.Enabled = true;// 啟動
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}",
                              e.SignalTime);
        }

        static void CheckStatus(Object state)
        {
            Console.WriteLine("Checking Status.");
        }

        /// <summary>
        /// 沒有參數，沒有回傳
        /// </summary>
        public static void Print()
        {
            for (int i = 1; i <= 20; i++)
            {
                Console.WriteLine("Thread ID:{0}-->Count:{1}",
                Thread.CurrentThread.ManagedThreadId, i);
                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// 有一個Object參數，沒有回傳
        /// </summary>
        /// <param name="obj"></param>
        static void Print(object obj)
        {
            int startno = (int)obj;
            for (int i = startno; i <= startno + 19; i++)
            {
                Console.WriteLine("Thread ID:{0}-- > Count: {1}",
                Thread.CurrentThread.ManagedThreadId, i);
                Thread.Sleep(1000);
            }
        }

    }
}
