using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace note3_ex1.Serialize
{
    public partial class Binary_serial_ex : System.Web.UI.Page
    {
       

        protected void Page_Load(object sender, EventArgs e)
        {
            // P 196

            // 建立物件
            MyObject obj = new MyObject();
            obj.intAge = 18;  // 改預設年齡

            //------- 序列化為.bin 檔案 ------------
            //1
            BinaryFormatter formatter = new BinaryFormatter();
            //2
            string curr_path = Path.Combine(Server.MapPath("."), "MyObject.bin"); // 檔名前方不要加//，否則檔案會加到C://那一邊，不知為什麼。
            if (File.Exists(curr_path))
                File.Delete(curr_path);
            FileStream fs = new FileStream(curr_path, FileMode.Create);
            //3
            formatter.Serialize(fs, obj);
            fs.Close();
            //
            Label1.Text = Label1.Text + "成功";

            // ------ 反序列化 ------------
            fs = new FileStream(curr_path, FileMode.Open);
            obj = (MyObject)formatter.Deserialize(fs);
            fs.Close();
            //
            Label2.Text = Label2.Text + "成功";
            // 
            Label3.Text = "姓名︰ " + obj.GetName() + "<br/>年齡︰" + obj.intAge;

        }


    }
}