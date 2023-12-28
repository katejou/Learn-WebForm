using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Text;

namespace note3_ex1.FileManage
{
    public partial class IsolatedStorageFile_ex : System.Web.UI.Page
    {
        IsolatedStorageFile isoFile = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);
        protected void Page_Load(object sender, EventArgs e)
        {
            // P 119
        }

        protected void OpenWrite_Click(object sender, EventArgs e)
        {
            IsolatedStorageFileStream isoStream =
            new IsolatedStorageFileStream("NewGenFile.txt", FileMode.Create, isoFile);
            StreamWriter sw = new StreamWriter(isoStream, Encoding.UTF8);
            sw.Write(TextBox2.Text);
            sw.Close();
            Label2.Text = "寫入成功";
        }

        protected void OpenRead_Click(object sender, EventArgs e)
        {
            //isoFile = IsolatedStorageFile.GetMachineStoreForAssembly();
            //if (isoFile.GetFileNames("NewGenFile.txt").Length == 0)
            if (!isoFile.FileExists("NewGenFile.txt"))
            {
                Label1.Text = "沒有這個檔案";
                return;
            }
            // 如果有這個檔案，讀出內容
            IsolatedStorageFileStream isoStream = 
                new IsolatedStorageFileStream("NewGenFile.txt", FileMode.Open, isoFile);
            String result = (new StreamReader(isoStream)).ReadToEnd();
            isoStream.Close();
            TextBox1.Text = result;
            Label1.Text = "讀出成功";
        }
    }
}