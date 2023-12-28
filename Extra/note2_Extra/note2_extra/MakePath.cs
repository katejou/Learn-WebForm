using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace note2_extra
{
    public class MakePath
    {
        public void makeWay() 
        {
            // 如果在後端，而不是模組之中，就不用寫那麼長。
            if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Log")))
                Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Log"));
            if (!Directory.Exists(System.Web.Hosting.HostingEnvironment.MapPath("~/Log")))
                Directory.CreateDirectory(System.Web.Hosting.HostingEnvironment.MapPath("~/Log"));
        }
    }
}