using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace note2_ex3
{


    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        #region -- 加入這一段，可以讓它不受PostBack的影響，維持自己本身的值。
        private int _startPage;

        public int StartPage
        {
            get { return _startPage; }
            set { _startPage = value; }
        }

        protected override void LoadViewState(object savedState)
        {
            object[] totalState = null;
            if (savedState != null)
            {
                totalState = (object[])savedState;
                if (totalState.Length == 2)
                {
                    base.LoadViewState(totalState[0]);
                    // Load back your properties, etc. from ViewState
                    if (totalState[1] != null)
                        StartPage = int.Parse(totalState[1].ToString());
                }
            }
        } 
        #endregion

        protected override object SaveViewState()
        {
            object baseState = base.SaveViewState();
            object[] totalState = new object[2];
            // Save out your properties, etc. to ViewState.
            totalState[0] = baseState;
            totalState[1] = _startPage;
            return totalState;
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            // P 306
            // 日曆顯示 > 選日期 > 出現日期
           
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Calendar1.Visible = true;
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            Label1.Text = Calendar1.SelectedDate.ToString("d"); // 這個簡短日期的 ToString要記住！
            Calendar1.Visible = false;
        }

        public string myData
        {
            set
            {
                Label1.Text = value;
            }
            get
            {
                return Label1.Text;
            }
        }
    }
}