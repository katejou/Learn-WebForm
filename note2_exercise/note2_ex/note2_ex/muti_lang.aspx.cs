using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Threading;

namespace note2_ex
{
    public partial class muti_lang : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.UserLanguages[0] != null)
            {
                //如果在Web.config或 前端的<%Page%>設了 culture = auto，那一開始就會依 UserLanguages (反之，則依這個server的語言為先)
                lb0.Text = Thread.CurrentThread.CurrentCulture.ToString();

                // 如果不設為auto，則上方為Sever的語言，下方為瀏覽器的語言。
                string CultrueName = Request.UserLanguages[0];
                lb1.Text = CultrueName;

                // 不知道和Thread是有什麼關係？？
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Request.UserLanguages[0]);
                // 為什麼要創造一個文化？？
                lb2.Text = Thread.CurrentThread.CurrentCulture.ToString();

                lb5.Text = DateTime.Now.ToString();  // 時間(會每秒更新)

                //直接自己設定文化,(例，日本﹑韓國)︰
                Thread.CurrentThread.CurrentCulture = new CultureInfo("ja-JP");
                lb3.Text = Thread.CurrentThread.CurrentCulture.ToString();
                
                lb6.Text = DateTime.Now.ToString();  // 時間(會每秒更新)

                Thread.CurrentThread.CurrentCulture = new CultureInfo("ko-KR");
                lb4.Text = Thread.CurrentThread.CurrentCulture.ToString();

                lb7.Text = DateTime.Now.ToString();  // 時間(會每秒更新)

                // 回到使用者本身的語言來顥示日曆
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Request.UserLanguages[0]);
            }




        }
    }
}