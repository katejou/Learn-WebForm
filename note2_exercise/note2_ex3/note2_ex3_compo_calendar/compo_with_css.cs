using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace note2_ex3_compo_css
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:compo_with_css runat=server></{0}:compo_with_css>")]
    public class compo_with_css : CompositeControl
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

        private ITemplate _itemTemplate;
        [TemplateContainer(typeof(compo_with_css))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public ITemplate ItemTemplate
        {
            get { return _itemTemplate; }
            set { _itemTemplate = value; }
        }
        protected override void CreateChildControls() 
        {
            _itemTemplate.InstantiateIn(this);
        }

        public string ProductID { get; set; }

        public string ProductName { get; set; }

        public decimal UnitPrice { get; set; }





    }
}
