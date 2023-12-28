using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Permissions;
using System.Data.SqlClient;

[assembly: UIPermission(SecurityAction.RequestMinimum, Window=UIPermissionWindow.SafeTopLevelWindows)]
[assembly: SqlClientPermission(SecurityAction.RequestMinimum, ConnectionString = "Data Source=.;Initial Catalog=Custom_Doc;Integrated Security=True")]
[assembly: SqlClientPermission(SecurityAction.RequestRefuse, ConnectionString = "Data Source=.;Initial Catalog=test;Integrated Security=True")]
[assembly: SecurityPermission(SecurityAction.RequestOptional, Unrestricted = true)]

namespace note3_ex3
{
    public partial class CASDeclare_ex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Build1_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(Link1.Text);
            try
            {
                cn.Open();
                R1.Text = "連線成功";
                cn.Close();
            }
            catch (Exception ex)
            {
                R1.Text = ex.Message;
            }
        }

        protected void Build2_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(Link2.Text);
            try
            {
                cn.Open();
                R2.Text = "連線成功";
                cn.Close();
            }
            catch (Exception ex)
            {
                R2.Text = ex.Message;
            }
        }
    }
}