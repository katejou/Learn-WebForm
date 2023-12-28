using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace note3_ex1.Drawing
{
    public partial class Show_pic_by_gen_Img_with_parameter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //生成圖片
        protected void Button1_Click(object sender, EventArgs e)
        {
            string l1 = TextBox1.Text;
            string l2 = TextBox2.Text;
            string l3 = TextBox3.Text;

            int temp;
            if (!int.TryParse(l1, out temp) || temp > 100 || temp < 0)
                l1 = 0.ToString();
            if (!int.TryParse(l2, out temp) || temp > 100 || temp < 0)
                l2 = 0.ToString();
            if (!int.TryParse(l3, out temp) || temp > 100 || temp < 0)
                l3 = 0.ToString();

            Image image = new Image();
            image.ImageUrl = "~/Drawing/flag_pic_gt_para.ashx?L1=" + l1 + "&L2=" + l2 + "&L3=" + l3;

            PlaceHolder1.Controls.Add(image);
        }
    }
}