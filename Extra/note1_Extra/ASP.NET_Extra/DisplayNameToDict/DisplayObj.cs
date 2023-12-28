using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DisplayName_To_Dict_Test
{
    public class DisplayObj
    {
        [DisplayName("a")]
        public string A { set; get; }

        [DisplayName("b")]
        public string B { set; get; }

    }
}