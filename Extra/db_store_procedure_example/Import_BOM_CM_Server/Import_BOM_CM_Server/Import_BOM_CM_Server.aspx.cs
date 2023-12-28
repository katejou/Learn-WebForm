#define test
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Collections;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
namespace Import_BOM_CM_Server
{
    public partial class Import_BOM_CM_Server : Page
    {
        readonly SQL sql1 = new SQL();
        readonly MessageLog Log = new MessageLog();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
#if prod
                if (Request["_fm_userid"] == null || Request["_fm_username"] == null)
                {
                    ScriptManager.RegisterStartupScript(GridView1, this.GetType(), "alert", "alert('您沒有檢視權限，請重新登入或開啟並由正常路徑登入!');window.opener=null;window.open('','_parent','');window.self.close();", true);
                    return;
                }
                ViewState["userID"] = Request["_fm_userid"].ToString();
#elif test
                ViewState["userID"] = "BPI_TEST";
#endif
                A_INV_CATEGORY();
                A_BOM_ASUS_CM_DESIGNATOR();
                ScriptManager.RegisterStartupScript(Button_Include, this.GetType(), "alert", "javascript:alert('此為ASUS CM TW(台北)頁面!');", true);
            }
            Button_Import.Attributes.Add("onclick", "disbutton();" + ClientScript.GetPostBackEventReference(Button_Import, ""));
            Button_Include.Attributes.Add("onclick", "checkinclude();");
        }

        //A_INV_CATEGORY Category選項
        protected void A_INV_CATEGORY()
        {
            string select = "select type from A_INV_CATEGORY where org_id = 3";
            DataTable DT = sql1.ReturnSelectDT(select, "ERP_PROD");
            DropDownList_Category.DataSource = DT;
            DropDownList_Category.DataBind();
        }

        // CM座標位置檔選項
        protected void A_BOM_ASUS_CM_DESIGNATOR()
        {
            string select = "select Distinct afv.flex_column1 flex_column1 from a_fnd_hardcode_groups afh,a_fnd_hardcode_group_values afv where afh.group_id = afv.group_id and afh.group_name = 'A_BOM_ASUS_CM_DESIGNATOR'";
            DataTable DT = sql1.ReturnSelectDT(select, "ERP_PROD");
            DropDownList_CM_DESIGNATOR.DataSource = DT;
            DropDownList_CM_DESIGNATOR.DataBind();
        }

        //匯入A_INV_IMPORT_ITEM
        protected void Button_Import_Click(object sender, EventArgs e)
        {
            if (Label_Error.Visible)
            {
                ScriptManager.RegisterStartupScript(Button_Include, this.GetType(), "alert", "javascript:alert('您的資料有誤，請重新匯入後存入資料庫!');", true);
                return;
            }

            Application.Lock();

            if (Label_Error.Visible)
            {
                ScriptManager.RegisterStartupScript(Button_Include, this.GetType(), "alert", "javascript:alert('資料檢查發生問題!');", true);
                return;
            }
            if (DropDownList_Category.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(Button_Include, this.GetType(), "alert", "javascript:alert('" + "選擇Cagetory!" + "');", true);
                return;
            }

            if (DropDownList_CM_DESIGNATOR.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(Button_Include, this.GetType(), "alert", "javascript:alert('請先選擇CM座標位置檔');", true);
                return;
            }

            string P_MODEL_TYPE = DropDownList_Category.SelectedItem.Text;
            string P_DESIGNATOR = DropDownList_CM_DESIGNATOR.SelectedItem.Value;
            string p_file_name = DateTime.Now.Year.ToString("0000") + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00") + DateTime.Now.Hour.ToString("00") + DateTime.Now.Minute.ToString("00") + DateTime.Now.Second.ToString("00") + DateTime.Now.Millisecond.ToString("0000");
            string UserID = ViewState["userID"].ToString();
            ArrayList AL = new ArrayList();
            SortedList ParaValue = new SortedList();
            for (int i = 0; i < GridView1.Rows.Count; i++)//FILE_NAME
            {
                //string SEQ_ID = ((Label)GridView1.Rows[i].FindControl("Label_NO")).Text;
                string LTYPE = ((Label)GridView1.Rows[i].FindControl("Label_LTYPE")).Text.Trim();                       //LTYPE 20
                string ASSEMBLY_NUM = ((Label)GridView1.Rows[i].FindControl("Label_Assemble_Num")).Text.Trim();         //ASSEMBLY 50
                string ITEM_NUM = ((Label)GridView1.Rows[i].FindControl("Label_Item_Num")).Text.Trim();                 //ITEM_NUM 50
                string ITEM_DESC = ((Label)GridView1.Rows[i].FindControl("Label_Item_Desc")).Text.Trim();               //COMPONENT_DESC 255
                string QVL = ((Label)GridView1.Rows[i].FindControl("Label_Qvl")).Text.Trim();                           //QVL 255
                string MEASURE = ((Label)GridView1.Rows[i].FindControl("Label_MEASURE")).Text.Trim();                   //MEASURE   20
                string UNIT = ((Label)GridView1.Rows[i].FindControl("Label_UNIT")).Text.Trim();                         //UNIT   20
                //string MARKING = ((Label)GridView1.Rows[i].FindControl("Label_MARKING")).Text.Trim();                   //Marking 100
                string CONFIG_CODE = ((Label)GridView1.Rows[i].FindControl("Label_Config_Code")).Text.Trim();           //CONFIG_CODE 100
                string ECN = ((Label)GridView1.Rows[i].FindControl("Label_ECN")).Text.Trim();                           //BCN 100
                string GA_FLAG = ((Label)GridView1.Rows[i].FindControl("Label_Ga_Flag")).Text.Trim();                   //GA_FLAG 100
                string DESIGNATOR = ((Label)GridView1.Rows[i].FindControl("Label_Desigator")).Text.Trim();              //DESIGNATOR 1000
                string BOM_DATE = ((Label)GridView1.Rows[i].FindControl("Label_BOM_Create_Date")).Text.Trim();          //BOM_DATE DATE
                string OPEN_FLAG = ((Label)GridView1.Rows[i].FindControl("Label_Open_Flag")).Text.Trim();               //OPEN_FLAG 20
                string OFFLINE = ((Label)GridView1.Rows[i].FindControl("Label_Offline")).Text.Trim();                   //OFFLINE 20

                ParaValue = new SortedList();

                //ParaValue.Add("SEQ_ID", SEQ_ID);
                ParaValue.Add("FILE_NAME", p_file_name);
                ParaValue.Add("LTYPE", LTYPE);
                ParaValue.Add("ASSEMBLE_NUM", ASSEMBLY_NUM);
                ParaValue.Add("ITEM_NUM", ITEM_NUM);
                ParaValue.Add("ITEM_DESC", ITEM_DESC);
                ParaValue.Add("QVL", QVL);
                ParaValue.Add("MEASURE", MEASURE);
                ParaValue.Add("UNIT", UNIT);
                ParaValue.Add("MARKING", UNIT);
                ParaValue.Add("CONFIG_CODE", CONFIG_CODE);
                ParaValue.Add("ECN", ECN);
                ParaValue.Add("GA_FLAG", GA_FLAG);
                ParaValue.Add("DESIGNATOR", DESIGNATOR);
                ParaValue.Add("BOM_Create_Date", Convert.ToDateTime(BOM_DATE).ToString("u").Substring(0, 19));
                ParaValue.Add("OPEN_FLAG", OPEN_FLAG);
                ParaValue.Add("OFF_LINE", OFFLINE);
                ParaValue.Add("BPM_AD", UserID);
                ParaValue.Add("MODEL_TYPE", P_MODEL_TYPE);

                AL.Add(ParaValue);
            }
            string insert = "insert into A_BOM_CM_SERVER_UPLOAD_TEMP(SEQ_ID,FILE_NAME,LTYPE,ASSEMBLE_NUM,ITEM_NUM,ITEM_DESC,QVL,MEASURE,";
            insert += "UNIT,MARKING,CONFIG_CODE,ECN,GA_FLAG,DESIGNATOR,BOM_Create_Date,OPEN_FLAG,OFF_LINE,BPM_AD,CREATION_DATE,LAST_UPDATE_DATE,MODEL_TYPE) ";

            insert += "values(A_BOM_CM_SERVER_IMPORT_PKG_S.Nextval,:FILE_NAME,:LTYPE,:ASSEMBLE_NUM,:ITEM_NUM,:ITEM_DESC,:QVL,:MEASURE,";
            insert += ":UNIT,:MARKING,:CONFIG_CODE,:ECN,:GA_FLAG,:DESIGNATOR,to_date(:BOM_Create_Date,'yyyy-mm-dd hh24:mi:ss'),:OPEN_FLAG,:OFF_LINE,:BPM_AD,sysdate,sysdate,:MODEL_TYPE)";

            object[] myObject = new object[3];
            myObject = sql1.OracleMultiParaOneCommWithTrans(insert, AL, "ERP_PROD");

            if ((bool)myObject[0])
            {
                //Call procedure
                string result = sql1.OracleProcedure("A_BOM_CM_SERVER_IMPORT_PKG.main", p_file_name, Label_TOP_ASSEMBLY.Text, P_MODEL_TYPE, P_DESIGNATOR, "ERP_PROD");

                if (result == "COMPLETED")
                {
                    ScriptManager.RegisterStartupScript(Button_Import, this.GetType(), "alert", "javascript:alert('" + "上傳成功!" + "');", true);
                    Log.InfoLog("執行" + p_file_name + "" + Label_TOP_ASSEMBLY.Text + "成功");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Button_Import, this.GetType(), "alert", "javascript:alert('" + "上傳失敗:" + result.Replace("</br>", "\\n").Replace('\'', '\"').Replace("'", "").Replace("\n", "\\n").Replace("\r", "\\r") + "，請洽MIS!" + "');", true);
                    Log.InfoLog("執行" + p_file_name + "" + Label_TOP_ASSEMBLY.Text + "上傳失敗:" + result);
                }

                GridView1.DataSource = null;
                GridView1.DataBind();
                Button_Import.Enabled = false;
                Label_Warning.Visible = false;
            }
            else
            {
                ScriptManager.RegisterStartupScript(Button_Import, this.GetType(), "alert", "javascript:alert('" + "檔案上傳失敗!" + myObject[2].ToString().Replace("</br>", "\\n").Replace('\'', '\"').Replace("'", "").Replace("\n", "\\n").Replace("\r", "\\r") + "');", true);
            }
            //解除鎖定
            DropDownList_Category.Enabled = true;
            Label_Warning.Visible = false;
            Label_Create_Date.Text = "";
            Label_TOP_ASSEMBLY.Text = "";
            Application.UnLock();
            Button_Import.Enabled = false;
        }

        protected void Button_Include_Click(object sender, EventArgs e)
        {
            if (DropDownList_Category.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(Button_Include, this.GetType(), "alert", "javascript:alert('" + "請先選擇Cagetory!" + "');", true);
                return;
            }
            //string P_MODEL_TYPE = DropDownList_Category.SelectedItem.Text;
            //string P_DESIGNATOR = DropDownList_CM_DESIGNATOR.SelectedItem.Value;
            Label_Error.Text = "";
            Label_Error.Visible = false;
            Button_Import.Enabled = false;
            HttpPostedFile Files = FileUpload1.PostedFile;
            if (Files.ContentLength > 0 && Files.FileName.ToLower().IndexOf(".xls") > 0)
            {
                if (!FileUpload1.HasFile)
                {
                    ScriptManager.RegisterStartupScript(Button_Include, this.GetType(), "alert", "javascript:alert('" + "請先選擇檔案!" + "');", true);
                    return;
                }

                string TempFileName = Guid.NewGuid().ToString();
                string FildLoaction = HttpContext.Current.Server.MapPath("~/Temp_File/" + TempFileName + ".xls");
                DataTable DT;
                try
                {
                    Files.SaveAs(FildLoaction);
                    string ExcelString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FildLoaction + ";Extended Properties='Excel 12.0;HDR=NO;IMEX=1;Persist Security Info=False;'";

                    //尋找所有的Table Name(Sheet)
                    OleDbConnection excelConn = new OleDbConnection(ExcelString);
                    excelConn.Open();
                    DataTable excelDT = null;
                    excelDT = excelConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    string SheetName = excelDT.Rows[0]["TABLE_NAME"].ToString();
                    if (SheetName == "_xlnm#_FilterDatabase")
                    {
                        for (int i = 0; i < excelDT.Rows.Count; i++)
                        {
                            SheetName = excelDT.Rows[i]["TABLE_NAME"].ToString();
                            if (SheetName != "_xlnm#_FilterDatabase")
                                break;
                        }
                    }

                    excelConn.Close();
                    excelConn.Dispose();
                    Alert_Message("取得Sheet:" + SheetName + "資料!");
                    if (SheetName.IndexOf("$") < 0)
                    {
                        SheetName += "$";
                    }

                    OleDbDataAdapter ODA = new OleDbDataAdapter("SELECT * FROM [" + SheetName + "]", ExcelString);
                    DataSet Ds = new DataSet();
                    ODA.Fill(Ds, "ReadData");
                    DT = Ds.Tables[0];
                    File.Delete(FildLoaction);
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(Button_Include, this.GetType(), "alert", "javascript:alert('" + ex.Message.ToString().Replace("</br>", "\\n").Replace('\'', '\"').Replace("'", "").Replace("\n", "\\n").Replace("\r", "\\r") + "');", true);
                    MessageLog Log = new MessageLog();
                    Log.Errorlog(ex.Message, ex.StackTrace);
                    File.Delete(FildLoaction);
                    return;
                }

                if (DT == null)
                {
                    ScriptManager.RegisterStartupScript(Button_Include, this.GetType(), "alert", "javascript:alert('檔案錯誤!');", true);
                    return;
                }
                else
                {
                    if (DT.Rows.Count > 0)
                    {
                        if (DT.Rows[0][0].ToString().Trim().ToUpper() == "confidential document".ToUpper())
                        {
                            DT.Rows.RemoveAt(0);  //已為移除第一列confidential document
                        }

                        DT.Columns[0].ColumnName = DT.Rows[0][0].ToString();
                        DT.Columns[1].ColumnName = DT.Rows[0][1].ToString();
                        DT.Columns[2].ColumnName = DT.Rows[0][2].ToString();
                        DT.Columns[3].ColumnName = DT.Rows[0][3].ToString();
                        DT.Columns[4].ColumnName = DT.Rows[0][4].ToString();
                        DT.Columns[5].ColumnName = DT.Rows[0][5].ToString();
                        DT.Columns[6].ColumnName = DT.Rows[0][6].ToString();
                        DT.Columns[7].ColumnName = DT.Rows[0][7].ToString();
                        DT.Columns[8].ColumnName = DT.Rows[0][8].ToString();
                        DT.Columns[9].ColumnName = DT.Rows[0][9].ToString();
                        DT.Columns[10].ColumnName = DT.Rows[0][10].ToString();
                        DT.Columns[11].ColumnName = DT.Rows[0][11].ToString();
                        DT.Columns[12].ColumnName = DT.Rows[0][12].ToString();
                        DT.Columns[13].ColumnName = DT.Rows[0][13].ToString();
                        DT.Columns[14].ColumnName = DT.Rows[0][14].ToString();

                        DT.Rows.RemoveAt(0);  //已為ColumnName移除第一列

                        if (DT.Columns[0].ColumnName != "主料/替料")
                        {
                            ScriptManager.RegisterStartupScript(Button_Include, this.GetType(), "alert", "javascript:alert('Excel第1欄未含主料/替料欄位!');", true);
                            return;
                        }
                        DT.Columns[0].ColumnName = "主料替料";

                        if (DT.Columns[1].ColumnName != "上階料號")
                        {
                            ScriptManager.RegisterStartupScript(Button_Include, this.GetType(), "alert", "javascript:alert('Excel第2欄未含上階料號欄位!');", true);
                            return;
                        }

                        if (DT.Columns[2].ColumnName != "料號")
                        {
                            ScriptManager.RegisterStartupScript(Button_Include, this.GetType(), "alert", "javascript:alert('Excel第3欄未含料號欄位!');", true);
                            return;
                        }

                        if (DT.Columns[3].ColumnName != "品名/規格")
                        {
                            ScriptManager.RegisterStartupScript(Button_Include, this.GetType(), "alert", "javascript:alert('Excel第4欄未含品名/規格欄位!');", true);
                            return;
                        }
                        DT.Columns[3].ColumnName = "品名規格";//品名/規格=>>品名規格

                        if (DT.Columns[4].ColumnName != "QVL")
                        {
                            ScriptManager.RegisterStartupScript(Button_Include, this.GetType(), "alert", "javascript:alert('Excel第5欄未含QVL欄位!');", true);
                            return;
                        }

                        if (DT.Columns[5].ColumnName != "發料單位")
                        {
                            ScriptManager.RegisterStartupScript(Button_Include, this.GetType(), "alert", "javascript:alert('Excel第6欄未含發料單位欄位!');", true);
                            return;
                        }

                        if (DT.Columns[6].ColumnName != "Qty")
                        {
                            ScriptManager.RegisterStartupScript(Button_Include, this.GetType(), "alert", "javascript:alert('Excel第7欄未含Marking欄位!');", true);
                            return;
                        }

                        if (DT.Columns[7].ColumnName != "Marking")
                        {
                            ScriptManager.RegisterStartupScript(Button_Include, this.GetType(), "alert", "javascript:alert('Excel第7欄未含Qty欄位!');", true);
                            return;
                        }

                        if (DT.Columns[8].ColumnName != "Config Code")
                        {
                            ScriptManager.RegisterStartupScript(Button_Include, this.GetType(), "alert", "javascript:alert('Excel第8欄未含Config Code欄位!');", true);
                            return;
                        }
                        DT.Columns[8].ColumnName = "Config_Code";//CONFIG CODE=>>CONFIG_CODE

                        if (DT.Columns[9].ColumnName != "ECN#")
                        {
                            ScriptManager.RegisterStartupScript(Button_Include, this.GetType(), "alert", "javascript:alert('Excel第9欄未含ECN#欄位!');", true);
                            return;
                        }
                        DT.Columns[9].ColumnName = "ECN";  //#造成錯誤，去除#

                        if (DT.Columns[10].ColumnName != "GA Flag")
                        {
                            ScriptManager.RegisterStartupScript(Button_Include, this.GetType(), "alert", "javascript:alert('Excel第10欄未含GA Flag欄位!');", true);
                            return;
                        }
                        DT.Columns[10].ColumnName = "GA_Flag";//GA Flag=>>GA_Flag

                        if (DT.Columns[11].ColumnName != "插件位置")
                        {
                            ScriptManager.RegisterStartupScript(Button_Include, this.GetType(), "alert", "javascript:alert('Excel第11欄未含插件位置欄位!');", true);
                            return;
                        }

                        if (DT.Columns[12].ColumnName != "展BOM時間")
                        {
                            ScriptManager.RegisterStartupScript(Button_Include, this.GetType(), "alert", "javascript:alert('Excel第12欄未含展BOM時間欄位!');", true);
                            return;
                        }

                        if (DT.Columns[13].ColumnName != "Open Flag")
                        {
                            ScriptManager.RegisterStartupScript(Button_Include, this.GetType(), "alert", "javascript:alert('Excel第13欄未含展BOM時間欄位!');", true);
                            return;
                        }
                        DT.Columns[13].ColumnName = "Open_Flag";

                        if (DT.Columns[14].ColumnName != "Offline")
                        {
                            ScriptManager.RegisterStartupScript(Button_Include, this.GetType(), "alert", "javascript:alert('Excel第14欄未含展BOM時間欄位!');", true);
                            return;
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Button_Include, this.GetType(), "alert", "javascript:alert('檔案無資料!');", true);
                        return;
                    }

                    try
                    {
                        GridView1.DataSource = DT;
                        GridView1.DataBind();
                    }
                    catch (Exception ex)
                    {
                        MessageLog Log = new MessageLog();
                        Log.Errorlog(ex.ToString(), ex.StackTrace);
                        Label_Error.Text += "資料匯入發生問題!<br/>";
                        Label_Error.Visible = true;
                        ScriptManager.RegisterStartupScript(Button_Include, this.GetType(), "alert", "javascript:alert('資料檢查發生問題：" + ex.Message.ToString().Replace("</br>", "\\n").Replace('\'', '"').Replace("'", "") + "，請勿上傳!');", true);
                    }

                    //ArrayList Arr_ITEM_NUMBER = new ArrayList();
                    if (GridView1.Rows.Count == 0)
                    {
                        ScriptManager.RegisterStartupScript(Button_Include, this.GetType(), "alert", "javascript:alert('無資料!');", true);
                    }

                    //string select;
                    //string BOM_IS_Exist;
                    //check匯入資料
                    for (int i = 0; i < GridView1.Rows.Count; i++)
                    {
                        ((Label)GridView1.Rows[i].FindControl("Label_NO")).Text = (GridView1.Rows[i].RowIndex + 1).ToString();
                        string LTYPE = ((Label)GridView1.Rows[i].FindControl("Label_LTYPE")).Text.Trim();                       //LTYPE 20
                        string ASSEMBLY_NUM = ((Label)GridView1.Rows[i].FindControl("Label_Assemble_Num")).Text.Trim();         //ASSEMBLY 50
                        string ITEM_NUM = ((Label)GridView1.Rows[i].FindControl("Label_Item_Num")).Text.Trim();                 //ITEM_NUM 50
                        string ITEM_DESC = ((Label)GridView1.Rows[i].FindControl("Label_Item_Desc")).Text.Trim();               //COMPONENT_DESC 255
                        string QVL = ((Label)GridView1.Rows[i].FindControl("Label_Qvl")).Text.Trim();                           //QVL 255
                        string MEASURE = ((Label)GridView1.Rows[i].FindControl("Label_MEASURE")).Text.Trim();                   //MEASURE   20
                        string UNIT = ((Label)GridView1.Rows[i].FindControl("Label_UNIT")).Text.Trim();                         //UNIT   20
                        string MARKING = ((Label)GridView1.Rows[i].FindControl("Label_MARKING")).Text.Trim();                   //Marking 100
                        string CONFIG_CODE = ((Label)GridView1.Rows[i].FindControl("Label_Config_Code")).Text.Trim();           //CONFIG_CODE 100
                        string ECN = ((Label)GridView1.Rows[i].FindControl("Label_ECN")).Text.Trim();                           //BCN 100
                        string GA_FLAG = ((Label)GridView1.Rows[i].FindControl("Label_Ga_Flag")).Text.Trim();                   //GA_FLAG 100
                        string DESIGNATOR = ((Label)GridView1.Rows[i].FindControl("Label_Desigator")).Text.Trim();              //DESIGNATOR 1000
                        string BOM_DATE = ((Label)GridView1.Rows[i].FindControl("Label_BOM_Create_Date")).Text.Trim();          //BOM_DATE DATE
                        string OPEN_FLAG = ((Label)GridView1.Rows[i].FindControl("Label_Open_Flag")).Text.Trim();               //OPEN_FLAG 20
                        string OFFLINE = ((Label)GridView1.Rows[i].FindControl("Label_Offline")).Text.Trim();                   //OFFLINE 20

                        if (System.Text.Encoding.Default.GetBytes(LTYPE).Length > 20 || (i != 0 && LTYPE.Length == 0))
                        {
                            GridView1.Rows[i].Cells[1].BackColor = System.Drawing.Color.Pink;
                            Label_Error.Text += "第" + (GridView1.Rows[i].RowIndex + 1).ToString() + "列，主料/替料" + LTYPE + "字數小於0或大於20!<br/>";
                            Label_Error.Visible = true;
                        }

                        if (i != 0 && (LTYPE != "─" && LTYPE != "S:" && LTYPE != "U:"))//─ U: S:
                        {
                            GridView1.Rows[i].Cells[1].BackColor = System.Drawing.Color.Pink;
                            Label_Error.Text += "第" + (GridView1.Rows[i].RowIndex + 1).ToString() + "列，主料/替料" + LTYPE + "字元不為─,S:,U:!<br/>";
                            Label_Error.Visible = true;
                        }

                        if (System.Text.Encoding.Default.GetBytes(ASSEMBLY_NUM).Length > 50)
                        {
                            GridView1.Rows[i].Cells[2].BackColor = System.Drawing.Color.Pink;
                            Label_Error.Text += "第" + (GridView1.Rows[i].RowIndex + 1).ToString() + "列，上階料號" + ASSEMBLY_NUM + "字數大於50!!<br/>";
                            Label_Error.Visible = true;
                        }

                        if (i == 0)//Assembly
                        {
                            Label_TOP_ASSEMBLY.Text = ASSEMBLY_NUM;
                        }
                        //20180322 不正確的參數 必定check為不存在，刪除段
                        //if (i == 0)//Assembly
                        //{
                        //    select = "select A_BOM_CM_SERVER_IMPORT_PKG.check_bom_exist('" + ASSEMBLY_NUM + "','" + P_MODEL_TYPE + "') from dual";
                        //    string Item_IS_Exist = (sql1.ReturnSelectDT(select, "ERP_PROD")).Rows[0][0].ToString();
                        //    if (Item_IS_Exist == "1")
                        //    {
                        //        GridView1.Rows[i].Cells[2].BackColor = System.Drawing.Color.Pink;
                        //        Label_Error.Text += "第" + (GridView1.Rows[i].RowIndex + 1).ToString() + "列，BOM:" + ASSEMBLY_NUM + "已存在!<br/>";
                        //        Label_Error.Visible = true;
                        //    }
                        //}

                        //select = "select A_BOM_CM_SERVER_IMPORT_PKG.check_item_exist('" + ASSEMBLY_NUM + "','" + P_MODEL_TYPE + "') from dual";  //此ASSEMBLY為check一般料號
                        //BOM_IS_Exist = (sql1.ReturnSelectDT(select, "ERP_PROD")).Rows[0][0].ToString();
                        //if (BOM_IS_Exist == "0")
                        //{
                        //    GridView1.Rows[i].Cells[2].BackColor = System.Drawing.Color.Yellow;
                        //    Label_Warning.Text += "第" + (GridView1.Rows[i].RowIndex + 1).ToString() + "列，料號" + ASSEMBLY_NUM + "不存在!<br/>";
                        //    Label_Warning.Visible = true;
                        //}

                        //select = "select A_BOM_CM_SERVER_IMPORT_PKG.check_item_exist('" + ITEM_NUM + "','" + P_MODEL_TYPE + "') from dual";  //此ASSEMBLY為check一般料號
                        //BOM_IS_Exist = (sql1.ReturnSelectDT(select, "ERP_PROD")).Rows[0][0].ToString();
                        //if (BOM_IS_Exist == "0")
                        //{
                        //    GridView1.Rows[i].Cells[3].BackColor = System.Drawing.Color.Yellow;
                        //    Label_Warning.Text += "第" + (GridView1.Rows[i].RowIndex + 1).ToString() + "列，料號" + ASSEMBLY_NUM + "不存在!<br/>";
                        //    Label_Warning.Visible = true;
                        //}

                        if (System.Text.Encoding.Default.GetBytes(ITEM_NUM).Length > 50)
                        {
                            GridView1.Rows[i].Cells[3].BackColor = System.Drawing.Color.Pink;
                            Label_Error.Text += "第" + (GridView1.Rows[i].RowIndex + 1).ToString() + "列，料號" + ITEM_NUM + "字數大於50!!<br/>";
                            Label_Error.Visible = true;
                        }

                        if (System.Text.Encoding.Default.GetBytes(ITEM_DESC).Length > 255)
                        {
                            GridView1.Rows[i].Cells[4].BackColor = System.Drawing.Color.Pink;
                            Label_Error.Text += "第" + (GridView1.Rows[i].RowIndex + 1).ToString() + "列，品名/規格" + ITEM_DESC + "字數大於255!!<br/>"; ;
                            Label_Error.Visible = true;
                        }

                        if (System.Text.Encoding.Default.GetBytes(QVL).Length > 255)
                        {
                            GridView1.Rows[i].Cells[5].BackColor = System.Drawing.Color.Pink;
                            Label_Error.Text += "第" + (GridView1.Rows[i].RowIndex + 1).ToString() + "列，QVL" + QVL + "字數大於255!!<br/>";
                            Label_Error.Visible = true;
                        }

                        if (System.Text.Encoding.Default.GetBytes(MEASURE).Length > 20)
                        {
                            GridView1.Rows[i].Cells[6].BackColor = System.Drawing.Color.Pink;
                            Label_Error.Text += "第" + (GridView1.Rows[i].RowIndex + 1).ToString() + "列，發料單位" + MEASURE + "字數大於20!!<br/>";
                            Label_Error.Visible = true;
                        }

                        if (System.Text.Encoding.Default.GetBytes(UNIT).Length > 20)
                        {
                            GridView1.Rows[i].Cells[7].BackColor = System.Drawing.Color.Pink;
                            Label_Error.Text += "第" + (GridView1.Rows[i].RowIndex + 1).ToString() + "列，UNIT" + UNIT + "字數大於20!!<br/>";
                            Label_Error.Visible = true;
                        }

                        if (System.Text.Encoding.Default.GetBytes(CONFIG_CODE).Length > 100)
                        {
                            GridView1.Rows[i].Cells[8].BackColor = System.Drawing.Color.Pink;
                            Label_Error.Text += "第" + (GridView1.Rows[i].RowIndex + 1).ToString() + "列，CONFIG_CODE" + CONFIG_CODE + "字數大於100!!<br/>";
                            Label_Error.Visible = true;
                        }

                        if (System.Text.Encoding.Default.GetBytes(ECN).Length > 50)
                        {
                            GridView1.Rows[i].Cells[9].BackColor = System.Drawing.Color.Pink;
                            Label_Error.Text += "第" + (GridView1.Rows[i].RowIndex + 1).ToString() + "列，ECN#" + ECN + "字數大於100!!<br/>";
                            Label_Error.Visible = true;
                        }

                        if (System.Text.Encoding.Default.GetBytes(GA_FLAG).Length > 50)
                        {
                            GridView1.Rows[i].Cells[11].BackColor = System.Drawing.Color.Pink;
                            Label_Error.Text += "第" + (GridView1.Rows[i].RowIndex + 1).ToString() + "列，GA_FLAG" + GA_FLAG + "字數大於100!!<br/>";
                            Label_Error.Visible = true;
                        }


                        if (!ValidDate(BOM_DATE))
                        {
                            GridView1.Rows[i].Cells[13].BackColor = System.Drawing.Color.Pink;
                            Label_Error.Text += "第" + (GridView1.Rows[i].RowIndex + 1).ToString() + "列，BOM_DATE" + BOM_DATE + "不為日期格式!!<br/>";
                            Label_Error.Visible = true;
                        }

                        if (CheckBox_Open_Flag.Checked)//160809 有勾選時check OPEN Flag
                        {
                            if (OPEN_FLAG != "Y" && OPEN_FLAG != "")
                            {
                                GridView1.Rows[i].Cells[14].BackColor = System.Drawing.Color.Pink;
                                Label_Error.Text += "第" + (GridView1.Rows[i].RowIndex + 1).ToString() + "列，OPEN_FLAG" + OPEN_FLAG + "不為Y or 空白!!<br/>";
                                Label_Error.Visible = true;
                            }
                        }
                    }

                    if (!Label_Error.Visible)
                    {
                        Button_Import.Enabled = true;
                    }
                    else
                    {
                        Label_Error.Text = "Error:<br>" + Label_Error.Text;
                    }
                    if (Label_Warning.Visible)
                    {
                        Label_Warning.Text = "Warning:<br>" + Label_Warning.Text;
                    }

                    DropDownList_Category.Enabled = false;
                    ScriptManager.RegisterStartupScript(Button_Include, this.GetType(), "alert", "javascript:alert('將匯入資料共" + GridView1.Rows.Count + "筆!請確認後點擊存入資料庫上傳');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(Button_Include, this.GetType(), "alert", "javascript:alert('請選擇檔案!');", true);
                return;
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ((Label)e.Row.FindControl("Label_NO")).Text = e.Row.RowIndex.ToString();
            }
        }

        protected bool ValidDate(string Date)
        {
            try
            {
                DateTime DT = Convert.ToDateTime(Date);
            }
            catch
            {
                return false;
            }
            return true;
        }

        void Alert_Message(string str)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(),
                "javascript:alert('" + str.Replace("</br>", "\\n").Replace('\'', '\"').Replace("'", "").Replace("\n", "\\n") + "');", true);
        }
    }
}