<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ASP_Tool_AddUser(fail).aspx.cs" Inherits="WebApplication1.ASP_Tool_AddUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        /*.createUser {
            width: 350px;
            font: 14px Verdana,Sans-Serif;
            background-color: lightblue;
            border: solid 3px black;
            padding: 4px;
        }

        .createUser_title {
            background-color: darkblue;
            color: white;
            font-weight: bold;
        }

        .createUser_instructions {
            font-size: 12px;
            text-align: left;
            padding: 10px;
        }

        .createUser_button {
            border: solid 1px black;
            padding: 3px;


                            CssClass="createUser"
                TitleTextStyle-CssClass="createUser_title"
                InstructionTextStyle-CssClass="createUser_instructions"
                CreateUserButtonStyle-CssClass="createUser_button"
                ContinueButtonStyle-CssClass="createUser_button"


        }*/
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:CreateUserWizard ID="CreateUserWizard1" runat="server"


                InstructionText="InstructionText"
                CompleteSuccessText="CompleteSuccessText"
                PasswordRegularExpressionErrorMessage="最少三個字，要含有一個是數字，一個符號"
                PasswordRegularExpression=""
                ContinueDestinationPageUrl="~/ASP_Tool_loginPage.aspx"
                RequireEmail="true"
                OnCreatedUser="CreateUserWizard1_CreatedUser">

                <TitleTextStyle CssClass="createUser_title" />
                <ContinueButtonStyle CssClass="createUser_button" />
                <CreateUserButtonStyle CssClass="createUser_button" />
                <InstructionTextStyle CssClass="createUser_instructions" />

                <MailDefinition
                    BodyFileName="~/Register.txt"
                    CC="katejou02@gmail.com"
                    From="myself@ASP_ToolAddUser.com"
                    Subject="成功註冊">
                </MailDefinition>

                <WizardSteps>
                    <asp:CreateUserWizardStep runat="server" ID="CreateUserWizardStep1" />
                    <asp:CompleteWizardStep runat="server" ID="CompleteWizardStep1" />
                    <asp:WizardStep StepType="Finish">
                        uh  
                    </asp:WizardStep>
                </WizardSteps>

            </asp:CreateUserWizard>
            <br />
            <asp:Label ID="msg" runat="server"></asp:Label>
            <br />
            <br />
            <br />
            按下建立使用者後，不停轉圈，沒有動作？&nbsp;&nbsp;&nbsp; <br />
            // 因為找不到更多參考，準備放棄，改跟一下官網的教學。<br />
            <br />
            <br />
            <br />
            <br />
            建立的使用者，會到哪裡？<br />
            <br />
            教學︰<br />
            <a href="https://www.cnblogs.com/lel1447/archive/2008/10/20/1315252.html">https://www.cnblogs.com/lel1447/archive/2008/10/20/1315252.html</a><br />
            <br />
            取消問電郵的那一行？<br />
            RequireEmail=&quot;false&quot;<br />
            取消問安全性問題的那兩行？要去web.config 去調？<br />
            有部份跟不上。<br />
            <br />
            <a href="http://hk.uwenku.com/question/p-tmaumwcq-bgm.html">http://hk.uwenku.com/question/p-tmaumwcq-bgm.html</a><br />
            說可以把帳密郵寄給電郵？︰
            <br />
            <br />
            protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e) 
            <br />
            { 
            <br />
            CreateUserWizard cuw = (CreateUserWizard) CreateUserWizard1.FindControl(&quot;CreateUserWizard1&quot;); MailUtility.SendMessage(cuw.Email, cuw.UserName); 
            <br />
            } 
            <br />
            但最好不要這樣做 ?<br />
            MailUtility 找不到能引用的模組。<br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
