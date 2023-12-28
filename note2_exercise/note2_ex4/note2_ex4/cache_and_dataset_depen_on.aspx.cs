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
    public partial class cache_and_dataset_do : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Cache["key1"] = DateTime.Now.ToString("G");
                Label2.Text = Cache["key1"].ToString();
            }

            DataSet c = (DataSet)GetCaeheData();
            GridView1.DataSource = c;
            GridView1.DataBind();

            // https://docs.microsoft.com/zh-tw/dotnet/api/system.web.caching.cachedependency?view=netframework-4.8
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

                string[] dependencyKey = new string[1];
                dependencyKey[0] = "key1";
                CacheDependency dependency = new CacheDependency(null, dependencyKey);

                Cache.Insert("Region", ds, dependency);
                Label1.Text = "From DB :" + System.DateTime.Now.ToString();

            }
            else
            {
                Label1.Text = "From Cache!";
            }

            return Cache["Region"]; 
        }

        /// <summary>
        /// Key 1
        /// </summary>
        protected void Button2_Click(object sender, EventArgs e)
        {
            Cache["key1"] = DateTime.Now.ToString("G");
            Label2.Text = Cache["key1"].ToString();
            Label1.Text = Cache["Region"] == null ? "Cache['Region']為 NULL " : Cache["Region"].ToString();
        }
    }
}