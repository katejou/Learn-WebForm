using System;
using System.Collections.Generic;


namespace ASP.NET_EX8._4_
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private List<string> GetData() {
            return new List<string> { "a","b" };
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            DropDownList2.DataSource = GetData(); DropDownList2.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlDataSource1.SelectParameters.Clear();
            if (!string.IsNullOrWhiteSpace(TextBox1.Text))
            {
                SqlDataSource1.SelectCommand += "WHERE [OrderID] = @search ";
                SqlDataSource1.SelectParameters.Add("search", TextBox1.Text);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlDataSource1.SelectParameters.Clear();
            if (!string.IsNullOrWhiteSpace(DropDownList1.Text))
            {
                SqlDataSource1.SelectCommand += "WHERE [CustomerID] = @search ";
                SqlDataSource1.SelectParameters.Add("search", DropDownList1.Text);
            }
        }
    }
}