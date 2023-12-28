using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class ASP_Tool_AddUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //CreateUserWizard1..Attributes["onclick"] = "this.disabled = true;this.value = 'Please wait..';" + Page.ClientScript.GetPostBackEventReference(CreateUserWizard1, "");
            //CreateUserWizard1.CreatingUser += new System.EventHandler(CreatingUser, "");
        }

        protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
        {
            try
            {

                CreateUserWizard cuw = (CreateUserWizard)CreateUserWizard1.FindControl("CreateAccountButton");
                // Create new user.

                MembershipUser newUser = Membership.CreateUser(cuw.UserName, cuw.Password);


                // If user created successfully, set password question and answer (if applicable) and 
                // redirect to login page. Otherwise return an error message.

                if (Membership.RequiresQuestionAndAnswer)
                {
                    newUser.ChangePasswordQuestionAndAnswer(cuw.Password,
                                                            cuw.Question,
                                                            cuw.Answer);
                }

                Response.Redirect("~/ASP_Tool_loginPage.aspx");
            }
            catch (MembershipCreateUserException ex)
            {
                msg.Text = GetErrorMessage(ex.StatusCode);
            }
            catch (HttpException ex)
            {
                msg.Text = ex.Message;
            }
        }

        public string GetErrorMessage(MembershipCreateStatus status)
        {
            switch (status)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "Username already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A username for that email address already exists. Please enter a different email address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The email address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }




    }
}
