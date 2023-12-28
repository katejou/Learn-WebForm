using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace note3_ex1.Serialize
{
    public partial class Attribute_XML_serial_ex : System.Web.UI.Page
    {
        [XmlRoot("產品一")]
        public class Product1
        {
            [XmlElement("產品ID")]
            public int ID;
            [XmlAttribute("產品Name")]
            public string Name;
        }

        public class Product2
        {
            public int ID;
            public string Name;
        }
        public class GroupProduct2
        {
            public Product2[] AryOfProduct2;
        }
        public class AttriGroupProduct2
        {
            [XmlArray("產品二的串列")]
            [XmlArrayItem("串列的成員")]
            public Product2[] AryOfProduct2;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // 建立 「使用 Attri 」物件
            Product1 obj = new Product1();
            obj.ID = 18;
            obj.Name = "這是個產品名";

            #region -- 序和反序 LB ( 1-3 ) --

            //------- 序列化為.xml 檔案 ------------
            //1
            XmlSerializer formatter = new XmlSerializer(typeof(Product1));
            //2
            string curr_path = Path.Combine(Server.MapPath("."), "Product1.xml"); // 檔名前方不要加//，否則檔案會加到C://那一邊，不知為什麼。
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
            obj = (Product1)formatter.Deserialize(fs);
            fs.Close();
            //
            Label2.Text = Label2.Text + "成功";
            // 
            Label3.Text = "Product_ID︰ " + obj.ID + "<br/>Product_Name︰" + obj.Name;

            #endregion

            // 建立 「不用 Attri」的 物件串列物件
            GroupProduct2 gpP2 = new GroupProduct2();
            Product2 p2_1 = new Product2(); p2_1.ID = 10; p2_1.Name = "p2_1的名稱";
            Product2 p2_2 = new Product2(); p2_2.ID = 11; p2_2.Name = "p2_2的名稱";
            gpP2.AryOfProduct2 = new Product2[2];
            gpP2.AryOfProduct2[0] = p2_1;
            gpP2.AryOfProduct2[1] = p2_2;

            #region -- 序和反序 LB ( 4-6 ) --

            formatter = new XmlSerializer(typeof(GroupProduct2));
            //2
            curr_path = Path.Combine(Server.MapPath("."), "GroupProduct2.xml"); // 檔名前方不要加//，否則檔案會加到C://那一邊，不知為什麼。
            if (File.Exists(curr_path))
                File.Delete(curr_path);
            fs = new FileStream(curr_path, FileMode.Create);
            //3
            formatter.Serialize(fs, gpP2);
            fs.Close();
            //
            Label4.Text = Label4.Text + "成功";

            // ------ 反序列化 ------------
            fs = new FileStream(curr_path, FileMode.Open);
            gpP2 = (GroupProduct2)formatter.Deserialize(fs);
            fs.Close();
            //
            Label5.Text = Label5.Text + "成功";
            // 
            StringBuilder sb = new StringBuilder();
            foreach (var oj in gpP2.AryOfProduct2)
                sb.Append("Product2_ID︰ " + oj.ID + "<br/>Product2_Name︰" + oj.Name + "<br/>");
            Label6.Text = sb.ToString();

            #endregion

            // 建立 「使用 Attri」的 物件串列物件
            AttriGroupProduct2 AgpP2 = new AttriGroupProduct2();
            AgpP2.AryOfProduct2 = new Product2[2];
            AgpP2.AryOfProduct2[0] = p2_1;
            AgpP2.AryOfProduct2[1] = p2_2;

            #region -- 序和反序 LB ( 7-9 ) --

            formatter = new XmlSerializer(typeof(AttriGroupProduct2));
            //2
            curr_path = Path.Combine(Server.MapPath("."), "AttriGpPt2.xml"); // 檔名前方不要加//，否則檔案會加到C://那一邊，不知為什麼。
            if (File.Exists(curr_path))
                File.Delete(curr_path);
            fs = new FileStream(curr_path, FileMode.Create);
            //3
            formatter.Serialize(fs, AgpP2);
            fs.Close();
            //
            Label7.Text = Label7.Text + "成功";

            // ------ 反序列化 ------------
            fs = new FileStream(curr_path, FileMode.Open);
            AgpP2 = (AttriGroupProduct2)formatter.Deserialize(fs);
            fs.Close();
            //
            Label8.Text = Label8.Text + "成功";
            // 
            sb.Clear();
            foreach (var oj in AgpP2.AryOfProduct2)
                sb.Append("Product2_ID︰ " + oj.ID + "<br/>Product2_Name︰" + oj.Name + "<br/>");
            Label9.Text = sb.ToString();

            #endregion

        }
    }
}