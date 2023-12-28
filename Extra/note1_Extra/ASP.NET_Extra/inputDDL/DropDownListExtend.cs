using System;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ASP.NET_Extra
{
    [ToolboxData("<{0}:DropDownListExtend runat=\"server\" />")]
    public class DropDownListExtend : TextBox
    {
        public DropDownList _DropDownList;
        public DropDownListExtend()
        {
            Values = new Hashtable();
            _DropDownList = new DropDownList();
        }
        public Hashtable Values { get; set; }
        protected override void Render(HtmlTextWriter output)
        {
            int iWidth = Convert.ToInt32(base.Width.Value);
            if (iWidth == 0)
            {
                iWidth = 102;
                base.Width = Unit.Parse("102px");
            }
            int sWidth = iWidth + 25;
            int spanWidth = sWidth - 25;
            output.Write("<div style=\"POSITION:relative\">");
            output.Write("<span style=\"MARGIN-LEFT:" + spanWidth.ToString() + "px;OVERFLOW:hidden;WIDTH:25px\">");

            _DropDownList.Width = Unit.Parse(sWidth.ToString() + "px");
            _DropDownList.Style.Add("MARGIN-LEFT", "-" + spanWidth.ToString() + "px");
            _DropDownList.Attributes.Add("onchange", "this.parentNode.nextSibling.value=this.value");
            if (Values.Count > 0)
            {
                foreach (string key in Values.Keys)
                {
                    ListItem item = new ListItem();
                    item.Value = key;
                    item.Text = Values[key].ToString();
                    _DropDownList.Items.Add(item);
                }
            }
            if (_DropDownList.Items.Count == 1)
            {
                ListItem item = new ListItem();
                item.Value = "";
                item.Text = " ";
                _DropDownList.Items.Add(item);
                _DropDownList.SelectedIndex = 1;
            }
            _DropDownList.RenderControl(output);
            output.Write("</span>");

            Style.Clear();
            base.Width = Unit.Parse(iWidth.ToString() + "px");
            Style.Add("left", "0px");
            Style.Add("POSITION", "absolute");
            base.Render(output);
            output.Write("</div>");
        }
    }
}