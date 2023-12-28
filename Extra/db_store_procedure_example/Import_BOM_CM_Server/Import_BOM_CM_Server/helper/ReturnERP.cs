using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data;
using log4net;
using log4net.Config;
using System.Collections;
using Oracle.ManagedDataAccess.Client;
/// <summary>
/// ReturnERP 的摘要描述
/// </summary>
public class ReturnERP
{
    public ReturnERP() { }
    public OracleConnection OracleConn(string DbConfig)  //資料庫連結
    {
        OracleConnection conn = new OracleConnection();
        try
        {
            string connstring = WebConfigurationManager.ConnectionStrings[DbConfig].ConnectionString;
            conn.ConnectionString = connstring;
        }
        catch (Exception ex)
        {
            MessageLog Log = new MessageLog();
            Log.Errorlog(ex.Message, ex.StackTrace);
        }
        return conn;
    }

    //傳回Select後的Table
    public DataTable ReturnSelectDT(string selectcommand, string DbConfig)
    {
        DataTable DT = new DataTable();
        OracleDataAdapter DA;
        DataSet DS = new DataSet();

        OracleConnection conn = new OracleConnection();
        try
        {
            if (conn.State != ConnectionState.Open)
            {
                conn = OracleConn(DbConfig);
                conn.Open();
            }

            DA = new OracleDataAdapter(selectcommand, conn);
            DA.Fill(DS);
            DT = DS.Tables[0];
            //cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            MessageLog Log = new MessageLog();
            Log.Errorlog(ex.Message, ex.StackTrace);
        }
        finally
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Dispose();
        }
        return DT;
    }

    public OracleDataReader ReturnSelectDR(string selectcommand, string DbConfig)
    {
        OracleDataReader DR = null;
        OracleConnection conn = new OracleConnection();
        OracleCommand cmd = new OracleCommand();
        try
        {
            if (conn.State != ConnectionState.Open)
            {
                // conn.ConnectionString = connstring;
                conn = OracleConn(DbConfig);
                conn.Open();
            }
            cmd = new OracleCommand(selectcommand, conn);
            DR = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            // 使用CommandBehavior.CloseConnection這個方式，當datareader消失時，會自動closeconnection。 function不用作conn.close及conn=nothing
        }
        catch (Exception ex)
        {
            cmd.Parameters.Clear();
            MessageLog Log = new MessageLog();
            Log.Errorlog(ex.Message, ex.StackTrace);
        }
        return DR;
    }

    //傳回Organization
    public DataTable ReturnAllOrganizationDT(string DbConfig)//傳回ORGANIZATION_CODE ORGANIZATION_ID
    {
        DataTable DT = new DataTable();
        OracleDataAdapter DA;
        DataSet DS = new DataSet();
        OracleConnection conn = new OracleConnection();
        try
        {
            if (conn.State != ConnectionState.Open)
            {
                conn = OracleConn(DbConfig);
                conn.Open();
            }

            string selectcommand = "select mp.organization_id,";
            selectcommand += " mp.organization_code ";
            selectcommand += " from mtl_parameters mp ";
            selectcommand += " where mp.master_organization_id=8 ";
            selectcommand += " and mp.organization_code not in ( 'BP1','BU6','CH3','CH4','CH7','EPA','EPC','EPS','IMC','AH1','AS1' ) ";
            selectcommand += " and mp.organization_id<>8 ";
            selectcommand += " order by mp.organization_code";

            DA = new OracleDataAdapter(selectcommand, conn);
            DA.Fill(DS);
            DT = DS.Tables[0];
        }
        catch (Exception ex)
        {
            MessageLog Log = new MessageLog();
            Log.Errorlog(ex.Message, ex.StackTrace);
        }
        finally
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Dispose();
        }
        return DT;
    }
}