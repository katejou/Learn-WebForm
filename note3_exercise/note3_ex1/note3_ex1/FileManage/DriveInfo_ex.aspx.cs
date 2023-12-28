using System;
using System.IO;

namespace note3_ex1.FileManage
{
    public partial class DriveInfo_ex : System.Web.UI.Page
    {
        // P 66

        protected void Page_Load(object sender, EventArgs e)
        {
            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in drives)
            {
                ListBox1.Items.Add("drive.Name :" + drive.Name);
                ListBox1.Items.Add("drive.DriveType.ToString() :" + drive.DriveType.ToString());
                if (drive.IsReady)
                {
                    ListBox1.Items.Add("drive.VolumeLabel :" + drive.VolumeLabel);
                    ListBox1.Items.Add("drive.DriveFormat : " + drive.DriveFormat);
                    ListBox1.Items.Add("drive.TotalSize :" + drive.TotalSize);
                }
                else
                {
                    ListBox1.Items.Add("目前無法使用");
                }
            }

            string[] drives2 = Directory.GetLogicalDrives();
            foreach (var drive in drives2)
            {
                ListBox2.Items.Add(drive);
            }
        }








    }
}