using System;


namespace ASP.NET_EX9._2_
{
    public partial class EX9_4 : System.Web.UI.Page
    {
        static int pageLoadPostBackTimes = 0;
        static int internalPostBackTimes1 = 0;
        static int internalPostBackTimes2 = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            Label_3.Text = Label_1.Text = (++pageLoadPostBackTimes).ToString();
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(10000);
            Label_2.Text = (++internalPostBackTimes1).ToString();
        }

        protected void Timer2_Tick(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(20000);
            Label_4.Text = (++internalPostBackTimes2).ToString();
        }
    }
}