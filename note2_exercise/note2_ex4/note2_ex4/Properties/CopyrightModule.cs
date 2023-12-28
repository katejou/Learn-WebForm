using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class CopyrightModule : IHttpModule
{
    // 在繼承了這個介面之後，會有紅線，按修正後，會出現這兩個方法，把方法的內容清除
    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public void Init(HttpApplication context)
    {
        //throw new NotImplementedException();
        context.EndRequest += new EventHandler(context_EndRequest);
    }
    void context_EndRequest(object sender, EventArgs e)
    {

        HttpApplication application = (HttpApplication)sender;
        HttpContext context = application.Context;
        context.Response.Write("<h3>這個網站的版權是我的</h3>");
    }
}