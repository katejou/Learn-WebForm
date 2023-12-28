using System;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;
using System.Web.Configuration;


namespace ASP.NET_EX8._5_
{
    public partial class WebForm14 : System.Web.UI.Page
    {
        string conn = WebConfigurationManager.ConnectionStrings["ConnectionStringSBK"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)  // 輸入大量資料
        {
            // 製造資料
            var dt = new DataTable();
            dt.Columns.Add("pig", typeof(string));
            dt.Columns.Add("pork", typeof(int));
            for (var i = 0; i < 1000; i++)
            {
                var row = dt.NewRow();
                row["pig"] = "pig" + i;
                row["pork"] = i;

                dt.Rows.Add(row);
            }

            // 輸入資料

            // 要在「參考」中加入 System.Transactions ，和上方也要用 using 把它帶進來才可以啟動 TransactionScope
            using (TransactionScope tx = new TransactionScope())
            {
                using (var sql = new SqlConnection(conn))
                {
                    sql.Open();
                    using (var sqlBulkCopy = new SqlBulkCopy(sql))
                    {
                        sqlBulkCopy.DestinationTableName = "[dbo].[farm]";
                        sqlBulkCopy.WriteToServer(dt);
                    }

                }
                tx.Complete();
            }

            GridView1.DataSourceID = "SqlDataSource123"; // 更新它連結的資料           
        }

        protected void Button2_Click(object sender, EventArgs e)  // 轉移表格
        {
            // 取得資料
            string cmdstring = "select * from farm";

            using (TransactionScope tx = new TransactionScope())
            {
                using (var sql = new SqlConnection(conn))
                {
                    SqlCommand commandPub = sql.CreateCommand(); // 這裡開始，using 和 new 兩句分開
                    using (commandPub)
                    {
                        commandPub.CommandText = cmdstring;
                        commandPub.CommandType = System.Data.CommandType.Text;
                        sql.Open();

                        SqlConnection connectionBulkCopy = new SqlConnection(conn);
                        using (connectionBulkCopy)
                        {
                            connectionBulkCopy.Open();
                            SqlDataReader dataReader = commandPub.ExecuteReader();

                            // 輸入資料
                            SqlBulkCopy bulkCopy = new SqlBulkCopy(connectionBulkCopy);
                            using (bulkCopy)
                            {
                                bulkCopy.DestinationTableName = "factory";
                                bulkCopy.ColumnMappings.Add("pig", "soul");  // 資料欄的配對
                                bulkCopy.ColumnMappings.Add("pork", "suasage");
                                bulkCopy.WriteToServer(dataReader);

                                GridView2.DataSourceID = "SqlDataSource223"; // 更新它連結的資料
                            }
                        }
                    }
                }
                tx.Complete();
            }
        }

        protected void Button3_Click(object sender, EventArgs e) // 清除資料
        {
            //指令準備
            string cmdstring1 = "delete from dbo.farm ; delete from dbo.factory";

            using (SqlConnection connection = new SqlConnection(conn))
            {
                SqlCommand command = new SqlCommand(cmdstring1, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();

                GridView2.DataSourceID = "SqlDataSource223"; // 更新它連結的資料
                GridView1.DataSourceID = "SqlDataSource123"; // 更新它連結的資料
            }

        }
    }
}

    

