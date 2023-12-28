<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ASP_Tool_CreateUser(fail).aspx.cs" Inherits="WebApplication1.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <p>
        <a href="https://www.itread01.com/p/630308.html">https://www.itread01.com/p/630308.html</a>
    </p>
    <p>
        砍掉重練的第一次︰&nbsp;&nbsp;&nbsp; 文章到一半不見了？
    </p>
    <p>
        <a href="https://ithelp.ithome.com.tw/articles/10028527">https://ithelp.ithome.com.tw/articles/10028527</a>
    </p>
    <p>
        這個是 VB 的語法，大約是指建了資料表之後，用迴圈去對帳密。
    </p>
    <p>
        <a href="https://www.c-sharpcorner.com/UploadFile/deepak.sharma00/how-to-configure-createuserwizard-and-login-control-using-as/">https://www.c-sharpcorner.com/UploadFile/deepak.sharma00/how-to-configure-createuserwizard-and-login-control-using-as/</a>
    </p>
    <p>
        這個要先建好資料庫，但是設定的程式碼可以抄考。
    </p>
    <p>
        <a href="https://www.howtoasp.net/how-to-use-asp-net-membership-createuserwizard-control/">https://www.howtoasp.net/how-to-use-asp-net-membership-createuserwizard-control/</a>
    </p>
    <p>
        &nbsp;
        CreateUserWizardCtrl: CreateUserWizardStep.ContentTemplate
    </p>
    <p>
        不包含 ID 為 Question 的安全性問題 IEditableTextControl，</p>
    <p>
        此為成員資格提供者需要問題與解答時的必要條件。</p>
    <form id="form1" runat="server">

        

    <p>
        <a href="https://docs.microsoft.com/zh-tw/dotnet/api/system.web.ui.webcontrols.createuserwizard?view=netframework-4.8">https://docs.microsoft.com/zh-tw/dotnet/api/system.web.ui.webcontrols.createuserwizard?view=netframework-4.8</a>
    </p>
    <p>
        &nbsp;</p>
      <asp:createuserwizard id="Createuserwizard1" runat="server" OnCreatedUser="Createuserwizard1_CreatedUser">
        <wizardsteps>
          <asp:createuserwizardstep runat="server" title="Sign Up for Your New Account">
            <contenttemplate>
              <table border="0">
                <tr>
                  <td>
                    <table border="0" style="height: 100%; width: 100%;">
                      <tr>
                        <td align="center" colspan="2">
                          Sign Up for Your New Account</td>
                      </tr>
                      <tr>
                        <td align="right">
                          <asp:label runat="server" associatedcontrolid="UserName" id="UserNameLabel">
                            User Name:</asp:label></td>
                        <td>
                          <asp:textbox runat="server" id="UserName"></asp:textbox>
                          <asp:requiredfieldvalidator runat="server" controltovalidate="UserName" tooltip="User Name is required."
                            id="UserNameRequired" validationgroup="Createuserwizard1" errormessage="User Name is required.">
                            *</asp:requiredfieldvalidator>
                        </td>
                      </tr>
                      <tr>
                        <td align="right">
                          <asp:label runat="server" associatedcontrolid="Password" id="PasswordLabel">
                            Password:</asp:label></td>
                        <td>
                          <asp:textbox runat="server" textmode="Password" id="Password"></asp:textbox>
                          <asp:requiredfieldvalidator runat="server" controltovalidate="Password" tooltip="Password is required."
                            id="PasswordRequired" validationgroup="Createuserwizard1" errormessage="Password is required.">
                            *</asp:requiredfieldvalidator>
                        </td>
                      </tr>
                      <tr>
                        <td align="right">
                          <asp:label runat="server" associatedcontrolid="ConfirmPassword" id="ConfirmPasswordLabel">
                            Confirm Password:</asp:label></td>
                        <td>
                          <asp:textbox runat="server" textmode="Password" id="ConfirmPassword"></asp:textbox>
                          <asp:requiredfieldvalidator runat="server" controltovalidate="ConfirmPassword" tooltip="Confirm Password is required."
                            id="ConfirmPasswordRequired" validationgroup="Createuserwizard1" errormessage="Confirm Password is required.">
                            *</asp:requiredfieldvalidator>
                        </td>
                      </tr>
                      <tr>
                        <td align="right">
                          <asp:label runat="server" associatedcontrolid="Email" id="EmailLabel">
                            Email:</asp:label></td>
                        <td>
                          <asp:textbox runat="server" id="Email"></asp:textbox>
                          <asp:requiredfieldvalidator runat="server" controltovalidate="Email" tooltip="Email is required."
                            id="EmailRequired" validationgroup="Createuserwizard1" errormessage="Email is required.">
                            *</asp:requiredfieldvalidator>
                        </td>
                      </tr>
                      <tr>
                        <td align="right">
                          <asp:label runat="server" associatedcontrolid="Question" id="QuestionLabel">
                            Security Question:</asp:label></td>
                        <td>
                          <asp:textbox runat="server" id="Question"></asp:textbox>
                          <asp:requiredfieldvalidator runat="server" controltovalidate="Question" tooltip="Security question is required."
                            id="QuestionRequired" validationgroup="Createuserwizard1" errormessage="Security question is required.">
                            *</asp:requiredfieldvalidator>
                        </td>
                      </tr>
                      <tr>
                        <td align="right">
                          <asp:label runat="server" associatedcontrolid="Answer" id="AnswerLabel">
                            Security Answer:</asp:label></td>
                        <td>
                          <asp:textbox runat="server" id="Answer"></asp:textbox>
                          <asp:requiredfieldvalidator runat="server" controltovalidate="Answer" tooltip="Security answer is required."
                            id="AnswerRequired" validationgroup="Createuserwizard1" errormessage="Security answer is required.">
                            *</asp:requiredfieldvalidator>
                        </td>
                      </tr>
                      <tr>
                        <td align="center" colspan="2">
                          <asp:comparevalidator runat="server" display="Dynamic" errormessage="The Password and Confirmation Password must match."
                            controltocompare="ConfirmPassword" controltovalidate="Password" id="PasswordCompare"
                            validationgroup="Createuserwizard1">
                          </asp:comparevalidator>
                        </td>
                      </tr>
                      <tr>
                        <td align="center" colspan="2" style="color: Red;">
                          <asp:literal runat="server" enableviewstate="False" id="FailureText">
                          </asp:literal>
                        </td>
                      </tr>
                    </table>
                  </td>
                </tr>
              </table>
            </contenttemplate>
          </asp:createuserwizardstep>
          <asp:completewizardstep runat="server" title="Complete">
            <contenttemplate>
              <table border="0">
                <tr>
                  <td>
                    <table border="0" style="height: 100%; width: 100%;">
                      <tr>
                        <td align="center" colspan="2">
                          Complete</td>
                      </tr>
                      <tr>
                        <td>
                          Your account has been successfully created.</td>
                      </tr>
                      <tr>
                        <td align="right" colspan="2">
                          <asp:button runat="server" validationgroup="Createuserwizard1" commandname="Continue"
                            id="ContinueButton" causesvalidation="False" text="Continue" />
                        </td>
                      </tr>
                    </table>
                  </td>
                </tr>
              </table>
            </contenttemplate>
          </asp:completewizardstep>
        </wizardsteps>
      </asp:createuserwizard>
        <br />
        System.Data.SqlClient.SqlException: 無法開啟登入所要求的資料庫 ???<br />
        <br />
        <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1">
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
        <br />
        放棄連結資料庫，太離找到適合的表格格式。<br />
        還不如自己用TextBox和Button 去操作資料庫輸入。<br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
       

    </form>
</body>
</html>
