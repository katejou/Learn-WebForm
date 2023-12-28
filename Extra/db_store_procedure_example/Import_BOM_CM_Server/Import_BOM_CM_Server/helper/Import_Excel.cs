using System;
using System.Data;
using System.Data.OleDb;
using System.Web;
/// <summary>
/// Import_Excel 的摘要描述
/// </summary>
public class Import_Excel
{
    public DataTable Return_Import_Excel_DT(HttpPostedFile PO)
    {
        string TempFileName = Guid.NewGuid().ToString();
        string FildLoaction = HttpContext.Current.Server.MapPath("~/Temp_File/" + TempFileName + ".xls");
        try
        {
            PO.SaveAs(FildLoaction);
            string ExcelString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FildLoaction + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1';Persist Security Info=False";
            OleDbDataAdapter ODA = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", ExcelString);
            DataSet Ds = new DataSet();
            ODA.Fill(Ds, "ReadData");
            return Ds.Tables[0];
        }
        catch (Exception ex)
        {
            MessageLog Log = new MessageLog();
            Log.Errorlog(ex.Message, ex.StackTrace);
            return null;
        }
    }
}