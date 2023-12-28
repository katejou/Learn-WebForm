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
/// SQL 的摘要描述
/// </summary>
public class ReturnBPM
{
    public ReturnBPM()  {  }
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


    //查詢BPM DATA
    //傳回ID的姓名
    public string ReturnUserIDtoUserName(string UserID, string DbConfig)
    {
        if (UserID == "")
        {
            return null;
        }
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
            string selectcommand = "select USERNAME from usertable where USERID='" + UserID + "'";

            cmd = new OracleCommand(selectcommand, conn);
            DR = cmd.ExecuteReader(CommandBehavior.CloseConnection);


        }
        catch (Exception ex)
        {
            cmd.Parameters.Clear();
            MessageLog Log = new MessageLog();
            Log.Errorlog(ex.Message, ex.StackTrace);
        }
        string temp = "";
        if (DR != null)
        {
            if (DR.Read())
            {
                temp = DR[0].ToString();
            }
        }
        if (conn.State == ConnectionState.Open)
        {
            conn.Close();
        }
        conn.Dispose();

        DR.Close();
        DR.Dispose();
        if (temp == "")
        {
            return "";
        }
        else
        {
            return temp;
        }
    }

    //傳回部門ID所屬的部門主管ID
    public string ReturnUserIDtoUnitMgrID(string UserID, string DbConfig)
    {
        if (UserID == "")
        {
            return null;
        }
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
            string selectcommand = "select userrolerelation.USERID as USERID from userrolerelation LEFT join unit on unit.unitmanager=userrolerelation.roleid left join userunitrelation on unit.unitid=userunitrelation.UNITID where userunitrelation.USERID='" + UserID + "'";

            cmd = new OracleCommand(selectcommand, conn);
            DR = cmd.ExecuteReader(CommandBehavior.CloseConnection);


        }
        catch (Exception ex)
        {
            cmd.Parameters.Clear();
            MessageLog Log = new MessageLog();
            Log.Errorlog(ex.Message, ex.StackTrace);
        }
        string temp = "";
        if (DR != null)
        {
            if (DR.Read())
            {
                temp = DR[0].ToString();
            }
        }
        if (conn.State == ConnectionState.Open)
        {
            conn.Close();
        }
        conn.Dispose();
        DR.Close();
        DR.Dispose();
        if (temp == "")
        {
            return "";
        }
        else
        {
            return temp;
        }
    }
    //傳回使用者的上層主管，假如無，傳回空字串
    public string ReturnUserIDtoUpperMgrID(string UserID, string DbConfig)
    {
        if (UserID == "")
        {
            return null;
        }

        string UnitMgrID = ReturnUserIDtoUnitMgrID(UserID, DbConfig);
        if (UnitMgrID == "")
        {
            return "";
        }
        else if (UnitMgrID != UserID)
        {
            return UnitMgrID;
        }
        else  //相同時找上層部門主管
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
                string selectcommand = "select userrolerelation.USERID as USERID from userrolerelation LEFT join unit on unit.unitmanager=userrolerelation.roleid left join unitunitrelation on unit.unitid=unitunitrelation.parentunitid left join userunitrelation on unitunitrelation.unitid=userunitrelation.unitid where userunitrelation.USERID='" + UserID + "'";

                cmd = new OracleCommand(selectcommand, conn);
                DR = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                cmd.Parameters.Clear();
                MessageLog Log = new MessageLog();
                Log.Errorlog(ex.Message, ex.StackTrace);
            }
            string temp = "";
            if (DR != null)
            {
                if (DR.Read())
                {
                    temp = DR[0].ToString();
                }
            }
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Dispose();
            DR.Close();
            DR.Dispose();
            if (temp == "")
            {
                return "";
            }
            else
            {
                return temp;
            }
        }
    }

    //傳回使用者所屬的部門名稱
    public string ReturnUserIDtoUnitName(string UserID, string DbConfig)
    {
        if (UserID == "")
        {
            return null;
        }
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
            string selectcommand = "select unit.UNITNAME as UNITNAME  from unit LEFT JOIN userunitrelation On unit.UNITID=userunitrelation.UNITID  where USERID='" + UserID + "'";

            cmd = new OracleCommand(selectcommand, conn);
            DR = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
        catch (Exception ex)
        {
            cmd.Parameters.Clear();
            MessageLog Log = new MessageLog();
            Log.Errorlog(ex.Message, ex.StackTrace);
        }
        string UnitName = "";
        if (DR != null)
        {
            if (DR.Read())
            {
                UnitName = DR[0].ToString();
            }
        }
        if (conn.State == ConnectionState.Open)
        {
            conn.Close();
        }
        conn.Dispose();
        DR.Close();
        DR.Dispose();
        if (UnitName == "")
        {
            return "";
        }
        else
        {
            return UnitName;
        }
    }

    //傳回使用者所屬的部門ID
    public string ReturnUserIDtoUnitID(string UserID, string DbConfig)
    {
        if (UserID == "")
        {
            return null;
        }
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
            string selectcommand = "select unit.UNITID as UNITID from unit LEFT JOIN userunitrelation On unit.UNITID=userunitrelation.UNITID  where USERID='" + UserID + "'";

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
        string UnitID = "";
        if (DR != null)
        {
            if (DR.Read())
            {
                UnitID = DR[0].ToString();
            }
        }
        if (conn.State == ConnectionState.Open)
        {
            conn.Close();
        }
        conn.Dispose();
        DR.Close();
        DR.Dispose();
        if (UnitID == "")
        {
            return "";
        }
        else
        {
            return UnitID;
        }
    }

    //傳回使用者的分機
    public string ReturnUserIDtoPhone(string UserID, string DbConfig)
    {//所有皆傳空值，待Note與AD整合後開放**************************************2010/11/30
        return null;
        //if (UserID == "")
        //{
        //    return null;
        //}
        //OracleDataReader DR = null;
        //OracleConnection conn = new OracleConnection();
        //OracleCommand cmd = new OracleCommand();
        //try
        //{
        //    if (conn.State != ConnectionState.Open)
        //    {
        //        // conn.ConnectionString = connstring;
        //        conn = OracleConn(DbConfig);
        //        conn.Open();
        //    }
        //    string selectcommand = "select User_PHONE from usertable where USERID='" + UserID + "'";

        //    cmd = new OracleCommand(selectcommand, conn);
        //    DR = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        //    // 使用CommandBehavior.CloseConnection這個方式，當datareader消失時，會自動closeconnection。 function不用作conn.close及conn=nothing
        //}
        //catch (Exception ex)
        //{
        //    cmd.Parameters.Clear();
        //    MessageLog Log = new MessageLog();
        //    Log.Errorlog(ex.Message, ex.StackTrace);
        //}
        //string Phone = "";
        //if (DR != null)
        //{
        //    if (DR.Read())
        //    {
        //        Phone = DR[0].ToString();
        //    }
        //}
        //if (conn.State == ConnectionState.Open)
        //{
        //    conn.Close();
        //}
        //conn.Dispose();
        //DR.Close();
        //DR.Dispose();
        //if (Phone == "")
        //{
        //    return "";
        //}
        //else
        //{
        //    return Phone;
        //}
    }

    //傳入部門ID，傳回部門的名稱
    public string ReturnUnitIDtoUnitName(string UnitID, string DbConfig)
    {
        if (UnitID == "")
        {
            return null;
        }
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
            string selectcommand = "select UNITNAME from unit where UNITID='" + UnitID + "'";

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

        string UnitName = "";
        if (DR != null)
        {
            if (DR.Read())
            {
                UnitName = DR[0].ToString();
            }
        }
        if (conn.State == ConnectionState.Open)
        {
            conn.Close();
        }
        conn.Dispose();
        DR.Close();
        DR.Dispose();
        if (UnitName == "")
        {
            return "";
        }
        else
        {
            return UnitName;
        }
    }

    //傳入userID,流程名稱，傳回可開啟表單的ID
    public DataTable ReturnCheckNowDT(string UserID, string ProcessName, string DbConfig)
    {
        DataTable DT = new DataTable();

        if (UserID == "" || ProcessName == "")
        {
            return DT;
        }

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
            string select = "select pr.var_str1 ";
            select += "from WORKITEM wi, ProcessInstance pr ,WorkItemUser wo ";
            select += "where pr.DefinitionName = '" + ProcessName + "' ";
            select += "and wi.INSTANCEID = pr.InstanceID  ";
            select += "and pr.instancestatus='RUNNING' ";
            select += "and wi.WORKITEMID =wo.workid ";
            select += "and (wo.userid in((select roleid from userrolerelation where userid='" + UserID + "') union (select '" + UserID + "' from dual))) ";
            select += "and  wi.status in ('INACTIVE','ACTIVE')  order by pr.starttime desc ";
            DA = new OracleDataAdapter(select, conn);
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


    //傳回模糊查詢單，查詢輸入為USERNAME，email，輸出DT為UserID,UserName,USER_PHONE,UnitName  暫傳回phone為''  *********************2010/11/30
    public DataTable ReturnSearchUserDT(string UserName, string EMail, string DbConfig)
    {
        if (UserName == "" && EMail == "")
        {
            return null;
        }
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
            string selectcommand = "";
            if (UserName != "" && EMail == "")  //只有USERID
            {
                // selectcommand = "select usertable.USERID as USERID,usertable.USERNAME as USERNAME,usertable.USER_PHONE as USER_PHONE,UNIT.Unitname as UnitName from usertable left join userunitrelation on usertable.USERID=userunitrelation.USERID left join UNIT on userunitrelation.unitid=UNIT.UNITID where usertable.USERNAME like '%" + UserName + "%'";
                selectcommand = "select usertable.USERID as USERID,usertable.USERNAME as USERNAME,'' as USER_PHONE,UNIT.Unitname as UnitName from usertable left join userunitrelation on usertable.USERID=userunitrelation.USERID left join UNIT on userunitrelation.unitid=UNIT.UNITID where usertable.USERNAME like '%" + UserName + "%'";
            }
            else if (UserName == "" && EMail != "")
            {
                // selectcommand = "select usertable.USERID as USERID,usertable.USERNAME as USERNAME,usertable.USER_PHONE as USER_PHONE,UNIT.Unitname as UnitName from usertable left join userunitrelation on usertable.USERID=userunitrelation.USERID left join UNIT on userunitrelation.unitid=UNIT.UNITID where usertable.EMAIL like '%" + EMail + "%'";
                selectcommand = "select usertable.USERID as USERID,usertable.USERNAME as USERNAME,'' as USER_PHONE,UNIT.Unitname as UnitName from usertable left join userunitrelation on usertable.USERID=userunitrelation.USERID left join UNIT on userunitrelation.unitid=UNIT.UNITID where usertable.EMAIL like '%" + EMail + "%'";
            }
            else
            {
                //  selectcommand = "select usertable.USERID as USERID,usertable.USERNAME as USERNAME,usertable.USER_PHONE as USER_PHONE,UNIT.Unitname as UnitName from usertable left join userunitrelation on usertable.USERID=userunitrelation.USERID left join UNIT on userunitrelation.unitid=UNIT.UNITID where usertable.USERNAME like '%" + UserName + "% and' usertable.EMAIL like '%" + EMail + "%'";
                selectcommand = "select usertable.USERID as USERID,usertable.USERNAME as USERNAME,'' as USER_PHONE,UNIT.Unitname as UnitName from usertable left join userunitrelation on usertable.USERID=userunitrelation.USERID left join UNIT on userunitrelation.unitid=UNIT.UNITID where usertable.USERNAME like '%" + UserName + "% and' usertable.EMAIL like '%" + EMail + "%'";
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

    //傳回某單所有需可開啟人員 參數:主流程的instanceID 母流程的instanceID 傳回 USERID , USERTYPE(U=user R=Rule)
    public ArrayList ReturnSearchOpenUserAL(string instanceid, string DbConfig)
    {
        ArrayList member = new ArrayList();
        if (instanceid == "")
        {
            return member;
        }
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
            string selectcommand = "";

            selectcommand = "select  u.userid as userid,u.usertype as usertype ";
            selectcommand += "from workitemuser u ,workitem w ,processinstance t ";
            selectcommand += "where t.instanceid =w.instanceid ";
            selectcommand += "and w.workitemid=u.workid ";
            selectcommand += "and w.status in ('INACTIVE','ACTIVE') ";
            selectcommand += "and (t.instanceid='" + instanceid + "'  or t.parentid='" + instanceid + "') ";
            selectcommand += "and t.instancestatus='RUNNING'";

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

        if (DT.Rows.Count > 0)
        {
            string username = "";
            for (int i = 0; i < DT.Rows.Count; i++)
            {
                if (DT.Rows[i]["usertype"].ToString() == "U")  //為User
                {
                    username = ReturnUserIDtoUserName(DT.Rows[i]["userid"].ToString(), DbConfig);
                    if (!member.Contains(username))
                    {
                        member.Add(username);
                    }
                }
                else if (DT.Rows[i]["usertype"].ToString() == "R")  //rule
                {
                    DataTable DT2 = ReturnUserInRuleDT(DT.Rows[i]["userid"].ToString(), DbConfig);
                    for (int j = 0; j < DT2.Rows.Count; j++)
                    {
                        username = ReturnUserIDtoUserName(DT2.Rows[j]["userid"].ToString(), DbConfig);
                        if (!member.Contains(username))
                        {
                            member.Add(username);
                        }
                    }
                }
            }
        }
        return member;
    }

    //傳回某單所有需可簽核人員 參數:主流程的instanceID 母流程的instanceID 傳回 USERID , USERTYPE(U=user R=Rule)
    public ArrayList ReturnSearchSignUserAL(string instanceid, string DbConfig)
    {
        ArrayList member = new ArrayList();
        if (instanceid == "")
        {
            return member;
        }
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
            string selectcommand = "";

            selectcommand = "select u.userid, u.usertype ";
            selectcommand += "from activity a,WORKITEM w, ProcessInstance p, workitemuser u ";
            selectcommand += "where p.instanceid=w.instanceid ";
            selectcommand += "and u.workid=w.workitemid ";
            selectcommand += "and w.activityid=a.activityid ";
            selectcommand += "and (p.instanceid = '" + instanceid + "' or p.parentid='" + instanceid + "') ";
            selectcommand += "and p.instancestatus = 'RUNNING'";
            selectcommand += "and w.status in('INACTIVE','ACTIVE') ";
            selectcommand += "and a.activityname <> '知會人員'";

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

        if (DT.Rows.Count > 0)
        {
            string username = "";
            for (int i = 0; i < DT.Rows.Count; i++)
            {
                if (DT.Rows[i]["usertype"].ToString() == "U")  //為User
                {
                    username = ReturnUserIDtoUserName(DT.Rows[i]["userid"].ToString(), DbConfig);
                    if (!member.Contains(username))
                    {
                        member.Add(username);
                    }
                }
                else if (DT.Rows[i]["usertype"].ToString() == "R")  //rule
                {
                    DataTable DT2 = ReturnUserInRuleDT(DT.Rows[i]["userid"].ToString(), DbConfig);
                    for (int j = 0; j < DT2.Rows.Count; j++)
                    {
                        username = ReturnUserIDtoUserName(DT2.Rows[j]["userid"].ToString(), DbConfig);
                        if (!member.Contains(username))
                        {
                            member.Add(username);
                        }
                    }
                }
            }
        }
        return member;
    }

    //userrolerelation 傳回RuleID中所有的UserID DT 
    public DataTable ReturnUserInRuleDT(string RuleID, string DbConfig)
    {
        if (RuleID == "")
        {
            return null;
        }
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
            string selectcommand = "";

            selectcommand = "select USERID from userrolerelation where ROLEID='" + RuleID + "'";

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


    public DataTable ReturnSearchDeptDT(string UnitName, string DbConfig)
    {
        if (UnitName == "")
        {
            return null;
        }

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
            string selectcommand = "";

            selectcommand = "select UNITID, UNITNAME  from unit where UNITNAME like '%" + UnitName + "%'";
            // selectcommand = "select usertable.USERID as USERID,usertable.USERNAME as USERNAME,usertable.USER_PHONE as USER_PHONE,UNIT.Unitname as UnitName from usertable left join userunitrelation on usertable.USERID=userunitrelation.USERID left join UNIT on userunitrelation.unitid=UNIT.UNITID where usertable.USERNAME like '%" + UserName + "%'";
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

    //某部門ID是否含於某部門ID
    public Boolean ReturnUnitisinUnit(string Unitid, string InUnitid, string DbConfig)
    {
        if (Unitid == "" || InUnitid == "")
        {
            return false;
        }

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
            string selectcommand = "";
            selectcommand = "select unitpath from unitpathtable where unitid='" + Unitid + "'";

            DA = new OracleDataAdapter(selectcommand, conn);
            DA.Fill(DS);
            DT = DS.Tables[0];

            if (DT.Rows.Count == 0)
            {
                return false;
            }
            else
            {
                string Units = DT.Rows[0][0].ToString();

                if (Units.Length == 0)
                {
                    return false;
                }
                else
                {
                    Units = Units.Substring(1, (Units.Length - 2));

                    string[] Unitarray = Ctrl_String.Split("//", Units);
                    if (Unitarray.Contains(InUnitid))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

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

        return true;
    }


    //某userID是否含於某部門ID下
    public Boolean ReturnUserIDisinUnit(string UserID, string InUnitid, string DbConfig)
    {
        if (UserID == "" || InUnitid == "")
        {
            return false;
        }

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
            string selectcommand = "";
            // selectcommand = "select unitpath from unitpathtable where unitid='" + Unitid + "'";


            /*
              select u.unitpath,r.roleid,s.positionid
               from unitpathtable u ,userrolerelation r,UNITPOSITIONROLERELATION s
                where s.roleid=r.roleid
               and s.unitid=u.unitid
            and u.unitid='G100-1220'
            and r.userid='chichin_huang'
             */

            DA = new OracleDataAdapter(selectcommand, conn);
            DA.Fill(DS);
            DT = DS.Tables[0];

            if (DT.Rows.Count == 0)
            {
                return false;
            }
            else
            {
                string Units = DT.Rows[0][0].ToString();

                if (Units.Length == 0)
                {
                    return false;
                }
                else
                {
                    Units = Units.Substring(1, (Units.Length - 2));

                    string[] Unitarray = Ctrl_String.Split("//", Units);
                    if (Unitarray.Contains(InUnitid))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

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

        return true;
    }
    //更改instance Name  //傳入instanceID  更改instance名稱
    public Boolean ChanceInstanceName(string instanceID, string Name, string DbConfig)
    {
        if (instanceID == "" || Name == "")
        {
            return false;
        }

        OracleConnection conn = new OracleConnection();
        int intResult = -1;
        try
        {
            if (conn.State != ConnectionState.Open)
            {
                conn = OracleConn(DbConfig);
                conn.Open();
            }
            string command = "";
            command = "update ProcessInstance set instancename='" + Name + "' where instanceid='" + instanceID + "'";
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

        if (intResult == -1)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    //傳回使用者所屬的所有角色
    public ArrayList ReturnUserIDtoRoleIDAL(string UserID, string DbConfig)
    {
        ArrayList AL = new ArrayList();
        if (UserID == "")
        {
            return AL;
        }
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
            string selectcommand = "";

            selectcommand = "select ROLEID from userrolerelation where USERID='" + UserID + "'";

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
        for (int i = 0; i < DT.Rows.Count; i++)
        {
            AL.Add(DT.Rows[i][0].ToString());
        }
        return AL;
    }

    //傳回使用者是否有某個角色
    public Boolean ReturnUserIDisinRoleID(string UserID, string RoleID, string DbConfig)
    {
        if (UserID == "" || RoleID == "")
        {
            return false;
        }
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
            string selectcommand = "";

            selectcommand = "select ROLEID from userrolerelation where USERID='" + UserID + "' and ROLEID='" + RoleID + "'";

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
        if (DT.Rows.Count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //傳回使用者"所有角色"的單位與職級DT EX:A9 return  unit position
    public DataTable ReturnUserIDallRoletoPosition(string UserID, string DbConfig)
    {
        DataTable DT = new DataTable();
        if (UserID == "")
        {
            return DT;
        }

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
            string selectcommand = "";
            selectcommand = "select up.unitid,up.positionid,up.roleid ";
            selectcommand += "from userrolerelation ur,unitpositionrolerelation up ";
            selectcommand += "where ur.roleid = up.roleid ";
            selectcommand += "and ur.userid='" + UserID + "'";

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

    //傳回使用者"主要角色(在所屬單位下)於與 角色 級職DT EX:A9 return unit role position
    public DataTable ReturnUserIDmainUnitRoletoPosition(string UserID, string DbConfig)
    {
        DataTable DT = new DataTable();
        if (UserID == "")
        {
            return DT;
        }

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
            string selectcommand = "";

            selectcommand = "select un.unitid,up.positionid,up.roleid ";
            selectcommand += "from userrolerelation ur,unitpositionrolerelation up,userunitrelation un ";
            selectcommand += "where ur.roleid = up.roleid ";
            selectcommand += "and un.userid=ur.userid ";
            selectcommand += "and un.unitid=up.unitid ";
            selectcommand += "and ur.userid='" + UserID + "'";

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
class Ctrl_String
{
    public static string[] Split(string separator, string Text)
    {
        string[] sp = new string[] { separator };
        return Text.Split(sp, StringSplitOptions.RemoveEmptyEntries);
    }
    public static string[] Split(char separator, string Text)
    {
        char[] sp = new char[] { separator };
        return Text.Split(sp, StringSplitOptions.RemoveEmptyEntries);
    }
}