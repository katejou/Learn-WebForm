using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace note3_ex1.FileManage
{
    public partial class FileSystemWatcher_ex : System.Web.UI.Page
    {
        // P 78  // 我掌握不到 ShowMovement(); 出現的時機。 

        protected void Page_Load(object sender, EventArgs e)
        {
            ShowMovement();  // 不知道為什麼有時會到第二或三次PostBack才顯示Label改變?
                             // 但是靜置一下有時就會第一次可行。
                             // 找不到原因

            string theFile = Path.Combine(Server.MapPath("."), "OriginalFile.txt");
            if (!File.Exists(theFile))
                File.Create(theFile).Close();
            ReadAllLineToTB2(theFile);
            if (!IsPostBack)
            {
                ViewState["File"] = theFile;
            }
        }

        #region - 監測用 -
        void ShowMovement()
        {
            // FileSystemWatcher  (這個資料夾之下)

            FileSystemWatcher watcher = new FileSystemWatcher();
            
            watcher.Path = Server.MapPath(".");
            watcher.EnableRaisingEvents = true;
            watcher.IncludeSubdirectories = true;
            watcher.Filter = "*.*";
            watcher.NotifyFilter =
            NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.Size | NotifyFilters.DirectoryName;

            watcher.Created += new FileSystemEventHandler(watcher_Created);
            watcher.Changed += new FileSystemEventHandler(watcher_Changed);
            watcher.Renamed += new RenamedEventHandler(watcher_Renamed);

        }

        void watcher_Created(object sender, FileSystemEventArgs e)
        {
            string msg = DateTime.Now.ToString("T") + "   " + e.ChangeType + "   :   " + e.Name;
            Lb3.Text = msg;
        }

        void watcher_Changed(object sender, FileSystemEventArgs e)
        {
            string msg = DateTime.Now.ToString("T") + "   " + e.ChangeType + "   :   " + e.Name;
            Lb1.Text = msg;
        }

        void watcher_Renamed(object sender, RenamedEventArgs e)
        {
            string msg = DateTime.Now.ToString("T") + "   " + e.ChangeType + "   :   " + e.OldName + "->" + e.Name;
            Lb2.Text = msg;
        }
        #endregion

        #region - 顯示內容用 - 

        protected void ReadAllLineToTB2(string fpfn)
        {
            string[] data = null;
            string curr_path = Server.MapPath(".");
            data = File.ReadAllLines(fpfn);
            TextBox2.Text = String.Join(" ", data);
        }
        protected void ReadAllLineToTB3(string fpfn)
        {
            string[] data = null;
            string curr_path = Server.MapPath(".");
            data = File.ReadAllLines(fpfn);
            TextBox3.Text = String.Join(" ", data);
        }

        #endregion

        protected void AppendAllText_Click(object sender, EventArgs e)
        {
            string fpfn = ViewState["File"].ToString();
            File.AppendAllText(fpfn, TextBox1.Text);
            ReadAllLineToTB2(fpfn);
            //ShowMovement();  <-- 就算是解封也不會有用。我推斷它要在被修改前就成立了物件才算，但是放在PostBack還是可以感應到，應該是加到了特別的(訂閱)Event。
        }

        protected void Move_Click(object sender, EventArgs e)
        {
            string source = ViewState["File"].ToString();
            string dest = source.Replace(Path.GetFileName(source), "NewGenFile.txt");

            // 不可能沒有原檔，所以不用檢查。
            //if (!File.Exists(source)){ Response.Write("<script> alert('沒有" + source + "') </script>"); return; }

            // 如果 舊的「新檔」在，刪了它。
            if (File.Exists(dest)) File.Delete(dest);

            File.Move(source, dest);  // 剪下﹑貼上

            // 再生成新的「原檔」
            File.Create(source).Close();
            ReadAllLineToTB2(source);

            // 顯示出「新檔」內容
            ReadAllLineToTB3(dest);

            //ShowMovement();  <-- 就算是解封也不會有用。它要在被修改前就成立了物件
        }

        protected void CreateDirectory_Click(object sender, EventArgs e)
        {

            string newFolder = Path.Combine(Server.MapPath("."), "NewFolder\\");

            if (Directory.Exists(newFolder)) // 如已有路徑會先刪後增，但問題是如果裡面有「任何」檔案，它都會出錯。
            {
                // 實作 DirectoryInfo
                DirectoryInfo directoryInfo = new DirectoryInfo(newFolder);
                FileInfo[] infos = directoryInfo.GetFiles();
                foreach (var info in infos)
                    File.Delete(info.FullName);  // 刪舊資料夾裡面可能有的任何檔案

                Directory.Delete(newFolder); // 刪舊資料夾
            }

            Directory.CreateDirectory(newFolder);  // 新增資料夾

            //ShowMovement();  <-- 就算是解封也不會有用。它要在被修改前就成立了物件
        }
    }
}