using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConstructorReturnDiffrenceObject_Test
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        ClassT object1 = new ConstructorTest("a");

        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = object1.str;    // Still Show As ClassT ? not Class1    // 只能理解成︰  ConstructorTest 那邊回傳已隱轉了一次，接收時又轉一次，把他徹底變為了 Class T  ?
            ClassA b = new ClassB();
            Label2.Text = b.str;         // 這個就顯示 ClassB 了。

            var object2 = new ConstructorTest("b");
            Label3.Text = object2.str;      // 這個也還是顯示 ClassT , 看來以建構子回傳的物件，只能回那個建構子物件所繼承的類型。 所以沒有任何意義。
        }
    }
}