using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace note2_ex3_compo_calendar
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:compo_ca runat=server></{0}:compo_ca>")]
    public class compo_ca2_css : CompositeControl
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
        [TemplateContainer(typeof(compo_ca2_css))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public ITemplate ItemTemplate
        {
            get { return _itemTemplate; }
            set { _itemTemplate = value; }
        }


        public TextBox txt;
        public Button btn;
        public Calendar cal;

        protected override void CreateChildControls()
        {
            _itemTemplate.InstantiateIn(this);

            base.RecreateChildControls();
            // 建立一個TextBox控制項
            txt = new TextBox();
            txt.ID = "txt";
            txt.CssClass = "tb";
            this.Controls.Add(txt);

            // 建立一個Button控制項
            btn = new Button();
            btn.ID = "btn";
            btn.Text = "顯示日曆";
            btn.CssClass = "btn";
            btn.Click += new EventHandler(this.btnDate_Click); // 加入onclick動作
            this.Controls.Add(btn);

            // 建立一個Calendar控制項
            cal = new Calendar();
            cal.ID = "cal";
            cal.Visible = false;
            cal.CssClass = "cal";
            cal.SelectionChanged += new EventHandler(this.CaIDate_SelectionChanged);
            this.Controls.Add(cal);

        }


        // 按鈕onclick動作︰
        protected void btnDate_Click(object sender, EventArgs e)
        {
            cal.Visible = true;
        }


        // 日曆onclick動作︰
        protected void CaIDate_SelectionChanged(object sender, EventArgs e)
        {
            txt.Text = cal.SelectedDate.ToShortDateString();
            cal.Visible = false;
        }


    }
}
