using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace note3_ex1.Serialize
{
    [Serializable()]
    public class MyObject
    {
        private string strName = "Jerry";
        public string GetName()
        {
            return strName;
        }

        public int intAge = 10;

        [NonSerialized()]
        public DateTime dateBirthday = DateTime.Now;
    }
}