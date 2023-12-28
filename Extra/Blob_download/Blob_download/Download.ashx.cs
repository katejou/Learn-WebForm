using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
using Blob_download;


namespace WebApplication1
{
    /// <summary>
    /// Download 的摘要描述
    /// </summary>
    public class Download : IHttpHandler
    {
        private string logFileName = "File_Download_Error";

        public void ProcessRequest(HttpContext context)
        {
            string errMsg = string.Empty;

            //接收參數。
            var id = context.Request.Params["id"];
            ERP_DB db = new ERP_DB();
            try
            {
                string cmd = "select file_name, file_content_type from X where file_name is not null and FILE_ID = :id";
                // 去資料庫
                DataTable result = db.Oracle_search_dt(cmd,id,ref errMsg);
                
                cmd = "select file_data from X where file_name is not null and FILE_ID = :id";
                byte[] output = db.Oracle_search_bary(cmd, id, ref errMsg);

                // 資料庫出錯
                if (!string.IsNullOrEmpty(errMsg))
                {
                    context.Response.Write("<script>alert('資料庫出錯');history.back();</script>");
                }
                // 找不到
                else if (result == null)
                {
                    context.Response.Write("<script>alert('這個 FILE_ID 不存在');history.back();</script>");
                }
                // 去生出，及返還檔案，給使用者下載
                else
                {
                    // 參考網頁︰ https://ithelp.ithome.com.tw/articles/10190271

                    //將檔案輸出到瀏覽器
                    context.Response.Clear();
                    context.Response.AddHeader(
                        "Content-Length", output.Length.ToString());
                    context.Response.ContentType = result.Rows[0][1].ToString();
                    context.Response.AddHeader(
                        "content-disposition",
                        "attachment; filename=" + result.Rows[0][0].ToString());
                    context.Response.OutputStream.Write(output, 0, output.Length);
                }
            }
            catch (Exception ex)
            {
                context.Response.Write($"<script>alert('發生錯誤\n'{ex});history.back();</script>");
            }
            finally
            {
                NoExceptionResponseEnd();
            }





        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public void NoExceptionResponseEnd()
        {
            //context.Response.End();  
            // 以這個方法取代上方的結束，是來的黑暗大的建議。左方的寫法會引起'執行緒已中止'的Exception，不利於Debug。
            // https://blog.darkthread.net/blog/response-end-alternative/
            // 以下是貼的︰

            //https://stackoverflow.com/a/22363396/288936
            //將Buffer中的內容送出
            HttpContext.Current.Response.Flush();
            //忽視之後透過Response.Write輸出的內容
            HttpContext.Current.Response.SuppressContent = true;
            //忽略之後ASP.NET Pipeline的處理步驟，直接跳關到EndRequest
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }

    }


}