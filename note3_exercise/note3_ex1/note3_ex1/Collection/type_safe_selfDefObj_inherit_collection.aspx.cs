using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace note3_ex1
{

    /// <summary>
    /// 物件
    /// </summary>
    public class Employee
    {
        public string Name { set; get; } // set get 很重要！！！
        public int ID { set; get; }
        public Employee() { }
        // 因為有子類別要覆寫建構子，所以作為爸爸的他，必須把這個「空建構子」寫出來。
        public Employee(int ID, string Name)
        {
            this.ID = ID;
            this.Name = Name;
        }
    }

    /// <summary>
    /// 覆寫Collection的型別
    /// </summary>
    public class EmployeesCollection : Dictionary<int, Employee>
    {
        // 覆寫原本父型 Dictionary 中已自帶的 Add 方法
        public void Add(Employee Value)
        {
            Add(Value.ID, Value);
        }
    }

    /// <summary>
    /// 這個網頁的後端
    /// </summary>
    public partial class Dict_type_safe : System.Web.UI.Page
    {
        EmployeesCollection employees = new EmployeesCollection();

        protected void Page_Load(object sender, EventArgs e)
        {
            // P 46 
            // 這個是父型的新增方法
            employees.Add(101, new Employee(101, "Anita"));
            // 這個是子型自設的新增方法
            employees.Add(new Employee(102, "Andy"));
            employees.Add(new Employee(103, "Mary"));

            if (!Page.IsPostBack)
            {
                //GridView1.DataSource = employees.Values;
                //GridView1.DataBind();
                // GridView 不能 DataBind ? 但是 DataSource 明明有收到內容？

                // ID 為 'GridView1' 的 GridView 的資料來源
                // 沒有任何可以產生資料行的屬性 (Property) 或屬性 (Attribute)。
                // 請確認資料來源具有內容。

                // 問題解決，原來是 Employee 的屬性要為 { set; get; }
                GridView1.DataSource = employees.Values;
                GridView1.DataBind();
                ListBox1.DataSource = employees;
                ListBox1.DataTextField = "Key";
                ListBox1.DataBind();
            }

        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListBox1.SelectedIndex < 0)
                return;
            int key = int.Parse(ListBox1.SelectedValue);
            Label1.Text = key + " , " + employees[key].Name;
        }


    }
}