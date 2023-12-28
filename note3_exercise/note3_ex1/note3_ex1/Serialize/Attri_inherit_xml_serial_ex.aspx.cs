using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace note3_ex1.Serialize
{
    public partial class Attri_inherit_xml_serial_ex : System.Web.UI.Page
    {
        public class Food
        {
            public string name { get; set; }
            public decimal price { get; set; }
            public override string ToString()
            {
                return name + price;
            }
        }

        public class SeaFood : Food
        {
            [XmlAttribute("Type")]
            public string Type { get; set; }
            public override string ToString()
            {
                return Type + "\t" + base.ToString();
            }
        }

        public class GroupFood
        {
            // 如果不加這些標簽，會令SeaFood無法寫進去StringWriter
            [XmlArray("菜單")]
            [XmlArrayItem(typeof(Food))]
            [XmlArrayItem(typeof(SeaFood))]
            public List<Food> FoodList = new List<Food>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // P 218 
            GroupFood gf = new GroupFood();
            gf.FoodList.Add(new Food() { name = "食物一", price = 80 });
            gf.FoodList.Add(new SeaFood() { name = "食物二", price = 90, Type = "外星類" });

            //------- 序列化為.xml 檔案 ------------
            //1
            XmlSerializer formatter = new XmlSerializer(typeof(GroupFood));
            //2
            string curr_path = Path.Combine(Server.MapPath("."), "GroupFood.xml"); // 檔名前方不要加//，否則檔案會加到C://那一邊，不知為什麼。
            if (File.Exists(curr_path))
                File.Delete(curr_path);
            FileStream fs = new FileStream(curr_path, FileMode.Create);
            //3
            formatter.Serialize(fs, gf);
            fs.Close();
            //
            Label1.Text = Label1.Text + "成功";

            // ------ 反序列化 ------------
            fs = new FileStream(curr_path, FileMode.Open);
            gf = (GroupFood)formatter.Deserialize(fs);
            fs.Close();
            //
            Label2.Text = Label2.Text + "成功";

            StringBuilder sb = new StringBuilder();
            foreach (var obj in gf.FoodList)
                sb.Append( obj.ToString() + "<br/>");
            Label3.Text = sb.ToString();

        }
    }
}