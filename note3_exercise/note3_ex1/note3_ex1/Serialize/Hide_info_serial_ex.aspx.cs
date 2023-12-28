using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;



namespace note3_ex1.Serialize
{
    [Serializable]
    public class Employee
    {
        [NonSerialized]
        private decimal _salary;
        private decimal sensdata;
        public string Name { get; set; }
        public short Level { get; set; }
        public decimal Salary
        {
            get { return _salary; }
            set { _salary = value; }
        }
        public DateTime UpdateTime { get; set; }

        [OnSerializing]
        public void Serializing(StreamingContext content)
        {
            // 序列前
            sensdata = (Level < 3 ? 0 : Salary);
            // XmlSerializer沒有經過這裡
        }
        // 序列後？Serialized ? 

        //[OnDeserializing]
        //public void Deserializing(StreamingContext content)
        //{
        //    //反序前
        //    UpdateTime = DateTime.Now;
        //    // 明明有經過也明明設定了…
        //    // 但是到成功反序的時候，這個屬性值卻回到初始。
        //    // 所以我覺得這個反序前的方法廢廢的，該不會只是為了和上方的Serializing對稱…
        //}
        //// 果然是有沒有都沒差。

        [OnDeserialized]
        public void Deserialized(StreamingContext content)
        {
            //反序後
            Salary = (Level < 3 ? 0 : sensdata);
            UpdateTime = DateTime.Now;
            // 反而是在這裡設定的時間值被保留

            // XmlSerializer沒有經過這裡，而且它強迫 UpdateTime 的 set 不能是 Private 要不然，他無法序列化。(但是他又不自己跳過去)
        }

    }

    public partial class Hide_info_serial_ex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // P 228 
        }

        /// <summary>
        /// 序列化
        /// </summary>
        protected void Button1_Click(object sender, EventArgs e)
        {
            //生成序列化的物件
            Employee emp = new Employee()
            { Name = "Anita", Level = short.Parse(TextBox1.Text), Salary = 30000 };
            // 只要把Level改為3以下，Salary就會顥示為 0
            // 代表它沒有被序列化，維持在初始的值。
            // 但是 XmlSerializer 不吃這一套，他還是會照樣把 Salary 顯示出來。

            //存成 bin 檔 (Binary)
            string currPath = Path.Combine(Server.MapPath("."), "HideSalary.bin");
            if (File.Exists(currPath)) File.Delete(currPath);
            using (FileStream fs = new FileStream(currPath, FileMode.Create, FileAccess.Write))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, emp);
            }
            //存成 xml 檔(SOAP)
            currPath = Path.Combine(Server.MapPath("."), "HideSalarySOAP.xml");
            if (File.Exists(currPath)) File.Delete(currPath);
            using (FileStream fs = new FileStream(currPath, FileMode.Create, FileAccess.Write))
            {
                SoapFormatter formatter = new SoapFormatter();
                formatter.Serialize(fs, emp);
            }
            //存成 xml 檔(XML)
            currPath = Path.Combine(Server.MapPath("."), "HideSalaryXML.xml");
            if (File.Exists(currPath)) File.Delete(currPath);
            using (FileStream fs = new FileStream(currPath, FileMode.Create, FileAccess.Write))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(Employee));
                formatter.Serialize(fs, emp);
            }
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        protected void Button2_Click(object sender, EventArgs e)
        {
            Employee emp; // 接收物件

            string currPath = Path.Combine(Server.MapPath("."), "HideSalary.bin");
            // 反序列化 bin 檔 (Binary)
            using (FileStream fs = new FileStream(currPath, FileMode.Open, FileAccess.Read))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                emp = (Employee)formatter.Deserialize(fs);
            }

            Label2.Text = emp.Name + "<br/>" + emp.Level + "<br/>" + emp.Salary + "<br/>" + emp.UpdateTime;

            // 反序列化 xml 檔(SOAP)
            currPath = Path.Combine(Server.MapPath("."), "HideSalarySOAP.xml");
            using (FileStream fs = new FileStream(currPath, FileMode.Open, FileAccess.Read))
            {
                SoapFormatter formatter = new SoapFormatter();
                emp = (Employee)formatter.Deserialize(fs);
            }
            // Label4
            Label4.Text = emp.Name + "<br/>" + emp.Level + "<br/>" + emp.Salary + "<br/>" + emp.UpdateTime;

            // 反序列化 xml 檔(XML)
            currPath = Path.Combine(Server.MapPath("."), "HideSalaryXML.xml");
            using (FileStream fs = new FileStream(currPath, FileMode.Open, FileAccess.Read))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(Employee));
                emp = (Employee)formatter.Deserialize(fs);
            }
            // Label6
            Label6.Text = emp.Name + "<br/>" + emp.Level + "<br/>" + emp.Salary + "<br/>" + emp.UpdateTime;



        }








    }
}