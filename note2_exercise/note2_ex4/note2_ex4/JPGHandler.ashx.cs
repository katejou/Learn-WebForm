using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace note2_ex4
{
    /// <summary>
    /// PDF  P 428  實作 
    /// </summary>
    public class Handler1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            context.Response.ContentType = "image/jpg";

            FileStream fs = File.OpenRead(context.Server.MapPath("photo.jpg"));

            int b;

            while ((b = fs.ReadByte()) != -1)
            {
                context.Response.OutputStream.WriteByte((byte)b);
            }
            fs.Close();
        }

        public bool IsReusable
        {
            get
            {
                //return false;
                return true;
            }
        }
    }
}