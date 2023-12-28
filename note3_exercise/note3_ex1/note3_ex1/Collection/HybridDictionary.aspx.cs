using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Collections.Specialized;

namespace note3_ex1
{
    public partial class collection_pick : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HybridDictionary hyper = new HybridDictionary();
            hyper.Add(8, "Number 8");
            hyper.Add(2, "Number 2");
            hyper.Add(3, "Number 3");
            foreach (DictionaryEntry entry in hyper)
            {
                ListBox1.Items.Add(String.Format("key:{0}, value:{1}", entry.Key, entry.Value));
            }
        }
    }
}