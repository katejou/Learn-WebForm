using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace note2_ex
{
    public partial class Session_buybucket : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            List<string> selected = new List<string>();
            foreach (ListItem book in CheckBoxList1.Items)
                if (book.Selected)
                    selected.Add(book.Value);
            Session["BookList"] = selected;

        }
    }
}