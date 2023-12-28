using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace note2_ex3_btn_2
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:WebCustomBtn runat=server></{0}:WebCustomBtn>")]
    public class WebCustomBtn2 : Button
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

        //protected override void RenderContents(HtmlTextWriter output)
        //{
        //    output.Write(Text);
        //}


        private int currentIndex = 0;

        public int currentCounter

        {
            get { return currentIndex; }

            set { currentIndex = value; }

        }


        protected override object SaveControlState()
        {
            return currentIndex != 0 ? (object)currentIndex : null;
        }
        protected override void LoadControlState(object state)
        {
            if (state != null)
            {
                currentIndex = (int)state;
            }

        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Page.RegisterRequiresControlState(this);
        }
    }
}
