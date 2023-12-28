using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace note2_ex3_cusCtrl
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:WebCustomControl2 runat=server></{0}:WebCustomControl2>")]
    public class WebCustomControl2 : WebControl
    {
        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public string Text
        {
            get
            {
                String s = (String)ViewState["Text"];
                return ((s == null) ? String.Empty : s);
            }

            set
            {
                ViewState["Text"] = value;
            }
        }

        protected override void RenderContents(HtmlTextWriter output)
        {
            if (Text.Contains("Hi"))
            {
                Text = Text.Replace("Hi", "<font color='blue'>Hi</font>");
            }
            output.Write("CustomControl2 : " + Text);
        }
    }
}
