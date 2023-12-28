using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET_EX1_.EX9.JavaScript_AJAX
{
    public class TestOfSingletonLock
    {
        //public static TestOfSingletonLock Instance { get; } = new TestOfSingletonLock();

        // 以下這些可以簡化成上面一行

        private static readonly TestOfSingletonLock a = new TestOfSingletonLock();
        private TestOfSingletonLock() { }
        public static TestOfSingletonLock Instance()
        {
            return a;
        }
    }
}