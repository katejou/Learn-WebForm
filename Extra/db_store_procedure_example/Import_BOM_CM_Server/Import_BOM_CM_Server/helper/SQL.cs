using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data;
using log4net;
using log4net.Config;
using System.IO;
using System.Collections;
using Oracle.ManagedDataAccess.Client;
/// <summary>
/// SQL 的摘要描述
/// </summary>
public class SQL
{
    public SQL() { }
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

    //執行DML的SQL(INSERT INTO、DELETE、UPDATE)，回傳成功筆數，如果失敗就回傳-1 //select成功與否皆傳回-1
    public int SqlCommand(string command, string DbConfig)  //傳回-1為失敗(傳回執行後筆數)
    {
        int intResult = -1;

        OracleConnection conn = new OracleConnection();
        try
        {
            if (conn.State != ConnectionState.Open)
            {
                conn = OracleConn(DbConfig);
                conn.Open();
            }

            OracleCommand cmd = new OracleCommand(command, conn);
            intResult = cmd.ExecuteNonQuery();
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
        return intResult;
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
            Log.Errorlog(selectcommand);
            Log.Errorlog(ex.Message, ex.StackTrace);
        }
        return DR;
    }

    public object[] OracleSqlCommandWithTransaction(string[] strSql, string DbConfig)  //成功傳回result[0]為true，失敗傳回result[0]為false ;result[1]為第n條error,result[2]為message
    {
        object[] result = new object[3];
        OracleTransaction sqlTran;
        int iCnt = 0;
        OracleCommand sqlCommand = new OracleCommand();
        OracleConnection DBConn = OracleConn(DbConfig);
        DBConn.Open();
        sqlTran = DBConn.BeginTransaction(IsolationLevel.ReadCommitted);
        try
        {
            sqlCommand.BindByName = true;
            sqlCommand.Connection = DBConn;
            sqlCommand.Transaction = sqlTran;

            for (iCnt = 0; iCnt <= strSql.Length - 1; iCnt++)
            {
                if (strSql[iCnt].Trim().Length != 0)
                {
                    sqlCommand.CommandText = strSql[iCnt];
                    sqlCommand.ExecuteNonQuery();
                }
            }
            sqlTran.Commit();

            result[0] = true;
            result[1] = -1;
            result[2] = "";
        }
        catch (Exception ex)
        {
            result[0] = false;
            result[1] = iCnt;
            result[2] = ex.Message;
            sqlTran.Rollback();

            MessageLog Log = new MessageLog();
            Log.Errorlog(result[1].ToString() + ":" + result[2].ToString(), ex.StackTrace);
        }
        finally
        {
            DBConn.Close();
            DBConn.Dispose();
        }
        return result;
    }

    public object[] OracleMultiParaOneCommWithTrans(string strSql, ArrayList ParaValueAL, string DbConfig)  //成功傳回result[0]為true，失敗傳回result[0]為false ;result[1]為第n條error,result[2]為message
    {
        object[] result = new object[3];
        OracleTransaction sqlTran;
        int iCnt = 0;
        OracleCommand sqlCommand = new OracleCommand();
        OracleConnection DBConn = OracleConn(DbConfig);
        DBConn.Open();
        sqlTran = DBConn.BeginTransaction(IsolationLevel.ReadCommitted);
        try
        {
            sqlCommand.BindByName = true;
            sqlCommand.Connection = DBConn;
            sqlCommand.Transaction = sqlTran;

            sqlCommand.CommandText = strSql;
            SortedList ParaValue;
            for (int i = 0; i < ParaValueAL.Count; i++)
            {
                ParaValue = (SortedList)ParaValueAL[i];
                for (int j = 0; j < ParaValue.Count; j++)
                {
                    sqlCommand.Parameters.Add(ParaValue.GetKey(j).ToString(), ParaValue.GetByIndex(j).ToString());
                }
                sqlCommand.ExecuteNonQuery();
            }
            sqlTran.Commit();
            result[0] = true;
            result[1] = -1;
            result[2] = "";
        }
        catch (Exception ex)
        {
            result[0] = false;
            result[1] = iCnt;
            result[2] = ex.Message;
            sqlTran.Rollback();

            MessageLog Log = new MessageLog();
            Log.Errorlog(result[1].ToString() + ":" + result[2].ToString(), ex.StackTrace);
        }
        finally
        {
            DBConn.Close();
            DBConn.Dispose();
        }
        return result;
    }

    public string OracleProcedure(string storeprocedure, string p_file_name, string P_TOP_ASSEMBLY, string P_MODEL_TYPE, string P_DESIGNATOR, string DbConfig)  //傳回是否成功
    {
        string result = "";

        OracleConnection conn = new OracleConnection();
        try
        {
            if (conn.State != ConnectionState.Open)
            {
                conn = OracleConn(DbConfig);
                conn.Open();
            }
            OracleCommand sqlCommand = new OracleCommand(string.Empty, conn)
            {
                BindByName = true,
                CommandType = CommandType.StoredProcedure,
                CommandText = storeprocedure
            };
            sqlCommand.Parameters.Add("p_file_name", OracleDbType.Varchar2, 50);
            sqlCommand.Parameters["p_file_name"].Value = p_file_name;
            sqlCommand.Parameters.Add("P_TOP_ASSEMBLY", OracleDbType.Varchar2, 50);
            sqlCommand.Parameters["P_TOP_ASSEMBLY"].Value = P_TOP_ASSEMBLY;
            sqlCommand.Parameters.Add("P_MODEL_TYPE", OracleDbType.Varchar2, 50);
            sqlCommand.Parameters["P_MODEL_TYPE"].Value = P_MODEL_TYPE;
            sqlCommand.Parameters.Add("P_DESIGNATOR", OracleDbType.Varchar2, 50);
            sqlCommand.Parameters["P_DESIGNATOR"].Value = P_DESIGNATOR;
            OracleParameter p_result = sqlCommand.Parameters.Add("p_result", OracleDbType.Varchar2, 4000);
            p_result.Direction = ParameterDirection.Output;
            sqlCommand.ExecuteNonQuery();
            result = p_result.Value.ToString();
        }
        catch (Exception ex)
        {
            MessageLog Log = new MessageLog();
            Log.Errorlog(storeprocedure, p_file_name + "," + P_TOP_ASSEMBLY);
            Log.Errorlog(ex.Message, ex.StackTrace);
        }
        finally
        {
            OracleConnection.ClearPool(conn);
            conn.Dispose();
        }
        if (result != "COMPLETED")
        {
            MessageLog Log = new MessageLog();
            Log.Errorlog(storeprocedure, p_file_name + "," + P_TOP_ASSEMBLY);
            Log.Errorlog("Oracle程式回傳訊息：", result);
        }
        return result;
    }
}