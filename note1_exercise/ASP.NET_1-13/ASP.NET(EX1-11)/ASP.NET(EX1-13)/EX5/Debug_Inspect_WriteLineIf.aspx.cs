using System;


namespace ASP.NET_EX5._2_
{
    public partial class ASP_NET_EX5__2_ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String data = TextBox1.Text;
            System.Diagnostics.Debug.WriteLine("Data = " + data);
            System.Diagnostics.Debug.Write("Data = " + data);
            System.Diagnostics.Debug.WriteLineIf(data == "123", "  Data = " + data);
            // 用F5來開，打123再按 BUTTON , 檢視 > 輸出 > 看到兩行，三個結果。
            // (Write 不會換行。)
            // WriteLineIf 有更多的用法︰
            //https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.debug?view=netframework-4.8

        }
    }
}