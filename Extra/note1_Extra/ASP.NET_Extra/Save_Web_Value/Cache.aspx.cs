using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NET_Extra
{
    public partial class Cache : System.Web.UI.Page
    {
        System.Web.Caching.Cache cacheContainer = HttpRuntime.Cache;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //清除瀏覽器快取,按上一頁須重整頁面
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Cache.SetAllowResponseInBrowserHistory(false);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string data = "cacheContainer_InsertData";
            cacheContainer.Insert("test1", data);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Label1.Text = cacheContainer.Get("test1") as string;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string data = "cacheContainer_AddData";
            cacheContainer.Add("test1",
                                data,
                                null,
                                DateTime.Now.AddHours(1),
                                System.Web.Caching.Cache.NoSlidingExpiration,
                                System.Web.Caching.CacheItemPriority.High,
                                null);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Label2.Text = cacheContainer.Get("test1") as string;
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            string data = "cacheContainer_InsertCoverInsertData";
            cacheContainer.Insert("test1", data);
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Label3.Text = cacheContainer.Get("test1") as string;
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            string cacheData = cacheContainer.Get("test1") as string;

            if (cacheData == null)
            {
                Label4.Text = "空";
            }
            else
            {
                Label4.Text = "有";
            }
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            HttpRuntime.Cache.Remove("test1");
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                cacheContainer.Insert("test"+i, "aaabbbccc"+i);
            }
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            string str = "";
            IDictionaryEnumerator CacheEnum = HttpRuntime.Cache.GetEnumerator();

            while (CacheEnum.MoveNext())
            {
                str += "緩存名<b>[" + CacheEnum.Key + "]</b><br />";
            }
            this.Label5.Text = "當前網站總緩存數:" + HttpRuntime.Cache.Count + "<br />" + str;
        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            IDictionaryEnumerator CacheEnum = HttpRuntime.Cache.GetEnumerator();
            while (CacheEnum.MoveNext())
            {
                HttpRuntime.Cache.Remove(CacheEnum.Key.ToString());
            }
        }
    }
}