using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security; // 這個是新的
using System.Web.UI;
using System.Web.UI.WebControls;

namespace note2_ex2
{
    public partial class role : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // P 277 
            if (!IsPostBack)
            {
                foreach (MembershipUser muser in Membership.GetAllUsers())
                {
                    ListBox1.Items.Add(muser.UserName);
                }
                foreach (string role in Roles.GetAllRoles())
                {
                    ListBox2.Items.Add(role);
                }

            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!Roles.RoleExists(TextBox1.Text))
            {
                Roles.CreateRole(TextBox1.Text);
                Label1.Text = "角色︰" + TextBox1.Text + " 建立成功";
            }
            else
            {
                Label1.Text = "角色︰" + TextBox1.Text + " 已存在";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (!Roles.IsUserInRole(ListBox1.SelectedItem.Text, ListBox2.SelectedItem.Text))
            {
                Roles.AddUserToRole(ListBox1.SelectedItem.Text, ListBox2.SelectedItem.Text);
                Label1.Text="已成功將「成員」加入「角色」";
            }
            else
            {
                Label1.Text = "「成員」已存在於「角色」";
            }
        }
    }
}