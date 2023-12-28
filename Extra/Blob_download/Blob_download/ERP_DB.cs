using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace Blob_download
{
    public class ERP_DB
    {

        readonly static string connString_test = WebConfigurationManager.ConnectionStrings["Oracle_DB_ERP_Conn_test"].ConnectionString;


        /// <summary>
        /// 回傳DataTable
        /// </summary>
        internal DataTable Oracle_search_dt(string cmdText, ref string errmsg)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(connString_test))
                {
                    using (OracleCommand cmd = new OracleCommand(cmdText, connection))
                    {
                        DataSet ds = new DataSet();
                        OracleDataAdapter da = new OracleDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(ds);
                        return ds.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                errmsg = ex.ToString();
                return null;
            }
        }

        /// <summary>
        /// 回傳DataTable
        /// </summary>
        internal DataTable Oracle_search_dt(string cmdText,string id,ref string errmsg)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(connString_test))
                {
                    using (OracleCommand cmd = new OracleCommand(cmdText, connection))
                    {
                        cmd.Parameters.Add(new OracleParameter("id", id));

                        DataSet ds = new DataSet();
                        OracleDataAdapter da = new OracleDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(ds);
                        return ds.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                errmsg += ex.ToString();
                return null;
            }
        }

        /// <summary>
        /// 回傳 Byte[]
        /// </summary>
        internal Byte[] Oracle_search_bary(string cmdText, string id, ref string errmsg)
        {
            // 如果 id 不是數字的話，會出錯。所以前端，和傳值之前的驗証要做得更好。(如果真的去用)
            try
            {
                using (OracleConnection connection = new OracleConnection(connString_test))
                {
                    connection.Open();
                    using (OracleCommand cmd = new OracleCommand(cmdText, connection))
                    {
                        cmd.Parameters.Add(new OracleParameter("id", id));

                        // 參考︰https://www.codeproject.com/Articles/48619/Reading-and-Writing-BLOB-Data-to-Microsoft-SQL-or
                        using (IDataReader dataReader = cmd.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                byte[] byteArray = (Byte[])dataReader[0];
                                return byteArray;
                            }
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                errmsg += ex.ToString();
                return null;
            }

        }
    }
}