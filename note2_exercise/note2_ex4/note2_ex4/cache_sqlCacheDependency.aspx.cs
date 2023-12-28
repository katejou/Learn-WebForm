using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace note2_ex4
{
    public partial class cache_sqlCacheDependency : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)  // sqlCache 的設定有更新，應該不算是PostBack ?
            { 
                Label1.Text = "「載入」這一頁的時間 ︰ " + DateTime.Now.ToString();
                //GridView1.DataSource = SqlDataSource1;
                //GridView1.DataBind();
            }

            Label2.Text = "「PostBack」這一頁的時間 ︰ " + DateTime.Now.ToString();

        }

        /// <summary>
        /// change in database table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToString("T");
            string cmd_string = "update Employees set LastName = '" + time + "' where EmployeeID = 1";
            ExecuteNonQueryCommand(cmd_string, out string _);

            Label3.Text = "「修改這個Tabel」的時間 ︰ " + DateTime.Now.ToString();
        }

        // 連結的字串
        readonly string connectionString = WebConfigurationManager.ConnectionStrings["NorthwindConnectionString1"].ConnectionString;
        private void ExecuteNonQueryCommand(string cmd_string, out string errMsg)
        {
            errMsg = string.Empty;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(cmd_string, connection))
                    {
                        // 執行命令                    
                        command.Connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                errMsg = "\n指令︰" + cmd_string + "\nError:\n" + ex.ToString();
            }
        }  // end of ExecuteNonQueryCommand

        protected void Button2_Click(object sender, EventArgs e)
        {
            GridView1.DataSourceID = "SqlDataSource1";
            //GridView1.DataSource = SqlDataSource1;
            //GridView1.DataBind();
        }
    }
}