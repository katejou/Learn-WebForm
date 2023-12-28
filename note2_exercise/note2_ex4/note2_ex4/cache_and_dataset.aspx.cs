using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace note2_ex4
{
    public partial class cache_and_dataset : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // P 385
            DataSet c = (DataSet)GetCaeheData();
            GridView1.DataSource = c;
            GridView1.DataBind();
        }

        public object GetCaeheData()
        {
            if (Cache["Region"] == null)
            {
                SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=Northwind;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("Select * from Region", cn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();
                da.Fill(ds);
                Cache.Insert("Region", ds);
                Label1.Text = "From DB :" + System.DateTime.Now.ToString();
            }
            else
            {
                Label1.Text = "From Cache!";
            }

            return Cache["Region"];
        }





    }
}