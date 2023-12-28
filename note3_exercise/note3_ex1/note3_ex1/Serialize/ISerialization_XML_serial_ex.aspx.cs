using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Security.Permissions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;

namespace note3_ex1.Serialize
{

    [Serializable]
    public class Employee2 : ISerializable
    {
        [NonSerialized] private decimal _salary;
        public String Name { get; set; }
        public short Level { get; set; }
        public decimal Salary
        {
            get { return _salary; }
            set { _salary = value; }
        }
        public Employee2() { }

        #region ---- ISerializable 實作 ---- 
        private Employee2(SerializationInfo info, StreamingContext context)
        {
            Name = info.GetString("Name");
            Level = info.GetInt16("Level");
            Salary = info.GetDecimal("Salary");
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            //throw new NotImplementedException();
            info.AddValue("Name", Name);
            info.AddValue("Level", Level);
            info.AddValue("Salary", (Level < 3 ? 0 : Salary));
        }
        #endregion
    }
    public partial class ISerialization_XML_serial_ex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // P 226 
        }

        /// <summary>
        /// 序列化
        /// </summary>
        protected void Button1_Click(object sender, EventArgs e)
        {
            //生成序列化的物件
            Employee2 emp = new Employee2()
            { Name = "Anita", Level = short.Parse(TextBox1.Text), Salary = 30000 };
            // 只要把Level改為3以下，Salary就會顥示為 0
            // 代表它沒有被序列化，維持在初始的值。
            // 但是 XmlSerializer 不吃這一套，他還是會照樣把 Salary 顯示出來。

            //存成 bin 檔 (Binary)
            string currPath = Path.Combine(Server.MapPath("."), "ISeriHideSalary.bin");
            if (File.Exists(currPath)) File.Delete(currPath);
            using (FileStream fs = new FileStream(currPath, FileMode.Create, FileAccess.Write))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, emp);
            }
            //存成 xml 檔(SOAP)
            currPath = Path.Combine(Server.MapPath("."), "ISeriHideSalarySOAP.xml");
            if (File.Exists(currPath)) File.Delete(currPath);
            using (FileStream fs = new FileStream(currPath, FileMode.Create, FileAccess.Write))
            {
                SoapFormatter formatter = new SoapFormatter();
                formatter.Serialize(fs, emp);
            }
            //存成 xml 檔(XML)
            currPath = Path.Combine(Server.MapPath("."), "ISeriHideSalaryXML.xml");
            if (File.Exists(currPath)) File.Delete(currPath);
            using (FileStream fs = new FileStream(currPath, FileMode.Create, FileAccess.Write))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(Employee2));
                formatter.Serialize(fs, emp);
            }
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        protected void Button2_Click(object sender, EventArgs e)
        {
            Employee2 emp; // 接收物件

            string currPath = Path.Combine(Server.MapPath("."), "ISeriHideSalary.bin");
            // 反序列化 bin 檔 (Binary)
            using (FileStream fs = new FileStream(currPath, FileMode.Open, FileAccess.Read))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                emp = (Employee2)formatter.Deserialize(fs);
            }

            Label2.Text = emp.Name + "<br/>" + emp.Level + "<br/>" + emp.Salary ;

            // 反序列化 xml 檔(SOAP)
            currPath = Path.Combine(Server.MapPath("."), "ISeriHideSalarySOAP.xml");
            using (FileStream fs = new FileStream(currPath, FileMode.Open, FileAccess.Read))
            {
                SoapFormatter formatter = new SoapFormatter();
                emp = (Employee2)formatter.Deserialize(fs);
            }
            // Label4
            Label4.Text = emp.Name + "<br/>" + emp.Level + "<br/>" + emp.Salary;

            // 反序列化 xml 檔(XML)
            currPath = Path.Combine(Server.MapPath("."), "ISeriHideSalaryXML.xml");
            using (FileStream fs = new FileStream(currPath, FileMode.Open, FileAccess.Read))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(Employee2));
                emp = (Employee2)formatter.Deserialize(fs);
            }
            // Label6
            Label6.Text = emp.Name + "<br/>" + emp.Level + "<br/>" + emp.Salary;

        }
    }
}