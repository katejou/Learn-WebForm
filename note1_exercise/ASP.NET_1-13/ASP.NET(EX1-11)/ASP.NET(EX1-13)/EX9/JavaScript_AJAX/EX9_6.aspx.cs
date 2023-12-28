using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using ASP.NET_EX1_.EX9.JavaScript_AJAX;
using System.Threading;

namespace ASP.NET_EX9._2_
{
    public partial class EX9_6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //TestOfSingletonLock lockMe = new TestOfSingletonLock();
            //TestOfSingletonLock lockMe = TestOfSingletonLock.Instance();
            //lock (lockMe)
            //{
            //    Thread.Sleep(5000); 

                string ID = Request.Form["ID"]; //接受傳入的參數
                                                //Response.Write("Hello ID Value : " + ID  );
                                                // 以上無法和下方的動作同時使用。
                                                // 因為︰ Response.Write 的內容，是會回傳到 HtmlPage1_EX9_6 做jason 解析的。
                                                // 所以 這個只可以加在後面或不加？
                string returnHello = "Hello ID Value : " + ID;
                // 不能加在後面，它和 解析 的方法不合。 
                // 於是我新開一個 EX9_7.aspx 去做這個動作。

                // 回傳Json資料的用法
                // 有時我們會需要Server端回傳的是一個Json字串，再由前端去做資料的處理
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                List<UserData> _list = new List<UserData>();

                //加入5筆假資料
                for (int i = 1; i <= 5; i++)
                {
                    UserData _data = new UserData();
                    _data.id = i;
                    _data.name = "測試" + i;
                    _list.Add(_data);
                }

                var retunJson = serializer.Serialize(_list);
                Response.Write(retunJson);
                Response.End();
            //}
        }

        public class UserData
        {
            public int id { get; set; }
            public string name { get; set; }
        }
    }
}