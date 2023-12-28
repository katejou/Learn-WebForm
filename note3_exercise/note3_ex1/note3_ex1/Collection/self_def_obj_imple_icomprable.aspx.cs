using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace note3_ex1
{
    class Employee2 : Employee, IComparable<Employee2>
    {
        public DateTime HireDate { set; get; }

        /// <summary>
        /// 利用 舊 方法覆寫成 新 的，只比較「同類」物件之間的HireDate
        /// </summary>
        /// <returns></returns>
        public int CompareTo(Employee2 other)
        {
            // 這個方法，是強迫覆寫的，所以原本介面應該有寫好方法(回傳 0/1/-1)，但是abstract了？
            return this.HireDate.CompareTo(other.HireDate);
        }

        public Employee2(int ID, string Name, DateTime HireDate)
        {
            this.ID = ID;
            this.Name = Name;
            this.HireDate = HireDate;
        }
    }

    //// 這個沒有辦法去做，因為 Dictionary 沒有斷承 IComparable ，所以它的 Value 不可以比它更大…(以我的理解是這樣，不然你打開看看它寫什麼)
    //public class Employees2Collection : Dictionary<int, Employee2>
    //{
    //    // 覆寫原本父型 Dictionary 中已自帶的 Add 方法
    //    public void Add(Employee2 Value)
    //    {
    //        Add(Value.ID, Value);
    //    }
    //}

    /// <summary>
    /// 網頁
    /// </summary>
    public partial class self_def_obj_imple_icomprable : System.Web.UI.Page
    {
        List<Employee2> employee2s = new List<Employee2>();
        protected void Page_Load(object sender, EventArgs e)
        {
            employee2s.Add(new Employee2(101, "Anita", new DateTime(1999, 7, 1)));
            employee2s.Add(new Employee2(201, "Andy", new DateTime(1999, 1, 1)));
            employee2s.Add(new Employee2(301, "Mary", new DateTime(2000, 4, 1)));
            BindListBox(employee2s);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            employee2s.Sort(); /// <-----------------這個就是覆寫 Employee2.CompareTo(Employee2 other) 的意義！！！ 所以當它成為了一個 List<Employee2> 的時候，可以 Sort 它自己！
            BindListBox(employee2s);
        }


        private void BindListBox(List<Employee2> employee2s) 
        {
            List<string> tmp_li = new List<string>(); string tmp_str;
            foreach (var people in employee2s)
            {
                tmp_str = people.ID + " , " + people.Name + " , " + people.HireDate.ToString("d");
                tmp_li.Add(tmp_str);
            }
            ListBox1.DataSource = tmp_li;
            ListBox1.DataBind();

        }

    }
}