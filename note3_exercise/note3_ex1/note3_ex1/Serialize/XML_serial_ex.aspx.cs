using System;
using System.IO;
using System.Xml.Serialization;

namespace note3_ex1.Serialize
{
    public partial class XML_serial_ex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 建立物件
            MyBook obj = new MyBook();
            obj.BookID = 18;
            obj.BookName = "這是個書名";

            //------- 序列化為.xml 檔案 ------------
            //1
            XmlSerializer formatter = new XmlSerializer(typeof(MyBook));
            //2
            string curr_path = Path.Combine(Server.MapPath("."), "MyBook.xml"); // 檔名前方不要加//，否則檔案會加到C://那一邊，不知為什麼。
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
            obj = (MyBook)formatter.Deserialize(fs);
            fs.Close();
            //
            Label2.Text = Label2.Text + "成功";
            // 
            Label3.Text = "BookID︰ " + obj.BookID + "<br/>書名︰" + obj.BookName;

        }
    }
}