using System;
using System.IO;

namespace ASP.NET_EX10_
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string fileName = "\\illegal_download\\file";
            Label2.Text = xDirFileList(fileName);
            MultiView1.ActiveViewIndex = RadioButtonList1.SelectedIndex;
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = RadioButtonList1.SelectedIndex;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                // 如果有同名的檔案 ? /////////////////////////////////////////////
                string fn = FileUpload1.FileName;
                string path = Server.MapPath(@"\illegal_download\file\");
                int my_counter = 2;
                string tempfn = "";
                string tempPath = path + fn;

                if (File.Exists(tempPath))
                {
                    while (File.Exists(tempPath))
                    {
                        tempfn = my_counter.ToString() + fn;  // 目前只可以加數字在前面，加在後面會影響 副檔名 。
                        tempPath = path + tempfn;
                        my_counter = my_counter + 1;
                    }
                    // 脫離了迴圈，肯定了沒有同名
                    fn = tempfn;
                    Label4.Text = "上傳的檔名發生衝突，檔名修改如下 : " + fn;
                }
                else { Label4.Text = ""; }// 
                // https://mis2000lab.pixnet.net/blog/post/22195319


                    // 如容量太大 ? ////////////////////////////////////////////////////////
                    // 取得上傳檔案大小
                    int fileSize = FileUpload1.PostedFile.ContentLength;
                // 可以把數字故意改得比 View1 上顯示的小 
                if (!(fileSize < 3865))   
                { Label4.Text = " 檔案太大 "; return; }

                // https://melomelo1988.pixnet.net/blog/post/162838827


                // 如果檔案型別不合 ? ////////////////////////////////////////////////////////
                string fileExtension = Path.GetExtension(fn).ToLower();
                string[] allowExtension = { ".jpg", ".gif",".txt" };  // 可以嘗試上傳 .txt
                bool typeOK = false;
                for (int i = 0; i < allowExtension.Length; i++)
                {
                    if (fileExtension == allowExtension[i])
                    {
                        typeOK = true;
                    }
                }
                if (typeOK == false) { Label4.Text = " 檔案型別不合 "; return; }

                // https://codertw.com/%E5%89%8D%E7%AB%AF%E9%96%8B%E7%99%BC/221540/

                try
                {
                    FileUpload1.SaveAs(Server.MapPath(@"file\" + fn));
                    Label3.Text = "檔案上傳成功";
                    
                }
                catch (Exception ex)
                {
                    Label3.Text = ex.Message;    //"檔案上傳不成功";
                }
            }
            else
            {
                Label3.Text = " 沒有檔案 / 裡面沒有內容 ";
            }
        }
        //https://blog.xuite.net/tolarku/blog/213947444-%5BASP.NET%5D+%E5%88%97%E5%87%BA%E6%9F%90%E7%9B%AE%E9%8C%84%E4%B8%8B%E6%89%80%E6%9C%89%E6%AA%94%E6%A1%88%E4%B8%A6%E7%B5%A6%E4%BA%88%E9%80%A3%E7%B5%90+-+%E4%BD%BF%E7%94%A8+Label+-+C%23


        public string xDirFileList(string xdirectory)
        {
            string xresult = "";
            int i = 1;
            string rootpath = Request.PhysicalApplicationPath; //抓取專案所在實際目錄路徑
            DirectoryInfo docspath = new DirectoryInfo(rootpath + xdirectory); // 搭配專案相對應上傳的路徑

            FileInfo[] filelist = docspath.GetFiles();  //擷取目錄下所有檔案內容，並存到 FileInfo array


            xresult = "<TABLE width=90% style='border:1px dashed #2f6fab; background-color: #eaf2d3;'>";
            xresult += "<TR style='background-color:#5B9BD5;'><TD width='15%'>項次</TD><TD width='70%'>檔案名稱</TD><TD width='15%'>檔案大小</TD></TR>";
            foreach (FileInfo fl in filelist)
            {
                if (i % 5 == 0)  // 每五行以不同底色呈現表格樣式
                {
                    xresult += "<TR style='background-color:#ABC7E7;'><TD>" + i + "</TD><TD><a href='/EX_10/file/" + fl.Name + "'>" + fl.Name + "</a></TD><TD>" + fl.Length + "</TD></TR>";
                }  //要自己改 a href='/file/"  這個路徑的內容。 file 前己經會預設好是這個網頁的檔案路徑， /file/ 是後加的，而且不能有空格。 如果 顯示的文字是黑色的，或者點下去有 Error = 你沒有改成功。
                else
                {
                    xresult += "<TR><TD>" + i + "</TD><TD><a href='/EX_10/file/" + fl.Name + "'>" + fl.Name + "</TD><TD>" + fl.Length + "</a></TD></TR>";
                }
                i++;  //  顯示行號用之變數
            }
            xresult += "</TABLE>";


            return xresult;  //  以html 的 table 方式包裝內容，傳回去給 Label 做呈現的效果
        }


    }
}