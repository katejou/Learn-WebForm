using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NET_EX4._3_
{
    public partial class ASP_NET_EX4__3_ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }


        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {

            if (int.Parse(args.Value) % 2 == 0)
            {
                args.IsValid = true;
                TextBox7.Text = "";  //算是自行定義錯誤的顯示方式。書中的方法好像無法執行？
            }

            else
            {
                args.IsValid = false;
                TextBox7.Text = "要雙數";
            }

            //foreach (IValidator vtor in this.Validators)
            //{
            //    if (!vtor.IsValid)
            //    {
            //        TextBox7.Text = vtor.ErrorMessage;
            //    }
            //}     // 無法生效的書中方法？

        }

    }
}