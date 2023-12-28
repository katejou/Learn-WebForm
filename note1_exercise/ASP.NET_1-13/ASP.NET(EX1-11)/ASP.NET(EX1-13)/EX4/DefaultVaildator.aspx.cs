using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NET_EX4._1_
{
    public partial class ASP_NET_EX4__1_ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            //  https://dotblogs.com.tw/rainmaker/2013/05/03/102768
            //  要加入這一句，要不然會有︰WebForms UnobtrusiveValidationMode 需要 'jquery' 的 Sc...
            //  據說︰ 經過上面設定好之後，驗証就會依ASP.NET 4.5之前的方式，建立驗証的物件來驗証 ...
        }
    }
}