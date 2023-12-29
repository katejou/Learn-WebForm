using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using DataAccess = Oracle.DataAccess.Client;
using Oracle.ManagedDataAccess.Client;
using System.Web.Configuration;

namespace Project1.App_Code.VS850
{
    public class ObjDataSource
    {
        readonly string cnB2B = WebConfigurationManager.ConnectionStrings["B2B_DB"].ConnectionString;

        public DataTable get850_LV(string seqid)
        {

            DataTable dt_VERIZON_850_LINE = new DataTable();
            using (OracleConnection cn = new OracleConnection(cnB2B))
            {
                using (OracleCommand cmdVERIZON_ITEM_MST = new OracleCommand("select PODETAIL_SEQID, MANUFACTURER_ID, QUANTITY_ORDERED, REQUESTED_SHIP_DATE from VERIZON_850_LINE where head_seqid = " + seqid, cn))
                {
                    try
                    {
                        cmdVERIZON_ITEM_MST.Connection.Open();
                        using (OracleDataReader odr = cmdVERIZON_ITEM_MST.ExecuteReader())
                            if (!odr.HasRows)
                                return null;
                            else
                                dt_VERIZON_850_LINE.Load(odr);
                    }
                    catch (Exception ex)
                    {
                        Helper.WriteLog(ex, "DbError");
                    }
                }
            }
            return dt_VERIZON_850_LINE;
        }

        public DataTable get850_PO(string seqid)
        {

            DataTable dt = new DataTable();
            using (OracleConnection cn = new OracleConnection(cnB2B))
            {
                using (OracleCommand cmdVERIZON_ITEM_MST = new OracleCommand("select PURCHASE_ORDER_NUMBER from VERIZON_850_HEAD where head_seqid = " + seqid, cn))
                {
                    try
                    {
                        cmdVERIZON_ITEM_MST.Connection.Open();
                        using (OracleDataReader odr = cmdVERIZON_ITEM_MST.ExecuteReader())
                            if (!odr.HasRows)
                                return null;
                            else
                                dt.Load(odr);
                    }
                    catch (Exception ex)
                    {
                        Helper.WriteLog(ex, "DbError");
                    }
                }
            }
            return dt;
        }



    }
}