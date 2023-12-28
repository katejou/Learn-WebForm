using System;
using System.Threading;

namespace Monitor_ex
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();

            //var tt3 = new ParameterizedThreadStart(p.MDoWrite);
            //Thread t3 = new Thread(tt3);
            //t3.Start(3);

            //var tt4 = new ParameterizedThreadStart(p.MDoWrite);
            //Thread t4 = new Thread(tt4);
            //t4.Start(4);

            //--------------------- TryEnter ---------------------

            //var tt5 = new ParameterizedThreadStart(p.M2DoWrite);
            //Thread t5 = new Thread(tt5);
            //t5.Start(5);

            //var tt6 = new ParameterizedThreadStart(p.M2DoWrite);
            //Thread t6 = new Thread(tt5);
            //t6.Start(6);

            // 和 3,4一起跑會有 RuntimeError
            // 我想是因為 Monitor 是只有一個，它能同時進入，但是無法其中一方先退出？

            //--------------------- TryEnter + bool ---------------------

            var tt7 = new ParameterizedThreadStart(p.M3DoWrite);
            Thread t7 = new Thread(tt7);
            t7.Start(7);

            var tt8 = new ParameterizedThreadStart(p.M3DoWrite);
            Thread t8 = new Thread(tt8);
            t8.Start(8);

            // 實驗証明 Monitor 是共用的，當另一個Thread未用完Moniotr，就不做 Exit。
            // 就算 TryEnter的等待時間 比Thread要執成完成的時間短，也不會出錯。
                    //進入時間第36秒
                    //start - 7
                    //進入時間第38秒
                    //start - 8      //<---- 而且它們是一起進入程式碼的，代表資源並不會被鎖…
                    //7 - 完成
                    //done - 7
                    //7 - 有做Exit   //<---- 看，只有7真的做了Exit 這個動作
                    //7 - 要跳出了
                    //8 - 完成
                    //done - 8
                    //8 - 要跳出了
            
            // 重點是︰它根本就沒有鎖到任何資源…為什麼thread還是可以同時進入？
            // 那做和不做的差別是︰
            // 不做沒error，做了有Error ?  .... 但有了error還是可以避開…
            // 完全的浪費我的時間…
        }



        public void M3DoWrite(object o)
        {
            bool NotOverTime = Monitor.TryEnter(this, 2000);

            try
            {
                Console.WriteLine("進入時間第{0}秒", DateTime.Now.Second);
                Console.WriteLine("start-" + o);
                Thread.Sleep(5000);
                Console.WriteLine(o + "-完成");
            }
            finally
            {
                Console.WriteLine("done-" + o);
                if (NotOverTime)
                {
                    Monitor.Exit(this);
                    Console.WriteLine(o + "-有做Exit");
                }
            }
            Console.WriteLine(o + "-要跳出了");
        }

        public void MDoWrite(object o)
        {
            Monitor.Enter(this);
            try
            {
                Console.WriteLine("start-" + o);
                Thread.Sleep(3000);

            }
            finally
            {
                Console.WriteLine("done-" + o);
                Monitor.Exit(this);
            }

        }

        public void M2DoWrite(object o)
        {
            Monitor.TryEnter(this, 6000);
            try
            {
                Console.WriteLine("start-" + o);
                Thread.Sleep(5000);
                Console.WriteLine(o + "-完成");
            }
            finally
            {
                Console.WriteLine("done-" + o);
                Monitor.Exit(this);  // <---- 和 3,4一起跑會有 RuntimeError
            }
            Console.WriteLine("要跳出了");
        }

    }
}
