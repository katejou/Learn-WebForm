<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="note2_ex2.membership_ajax" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript">
        function pageLoad() {
            // 繫結方法
            // PDF 寫的方法不能，疑似不支援了︰
            // document.getElementById('loginButton'). attachEvent( 'onclick', login); 

            // 登入
            document.getElementById('loginButton').onclick = login;
            // 登出
            $addHandler($get('logoutButton'), 'click', logout);
        }

        // 登入
        function login() {
            var u = $get('username').value; // .value 結合 input type="text" name= 會出錯？但換作 TB 就好了。
            var p = $get('password').value;
            var isPersistent = false;
            var customInfo = null;
            var redirectUrl = null;
            // 下面的方法，引用上以上的參數值，和下面的兩個方法。
            Sys.Services.AuthenticationService.login(u, p, isPersistent, customInfo, redirectUrl, loginCompleted, loginFailed);
        }
        // 被登入引用的方法一
        function loginCompleted(result, context, methodName) {
            if (result) {
                alert("Successfuly logged in.");
            }
            else {
                alert("Failed to login.");
            }
        }
        // 被登入引用的方法二
        function loginFailed(error, context, methodlName) {
            alert(error.get_message());
        }
        // 登出
        function logout() {
            //Sys.Services.AuthenticationService.logout('Default.aspx'); // 我認為這個PDF上的地址不對
            // 我參考︰http://vito-note.blogspot.com/2012/12/ajaxform.html
            Sys.Services.AuthenticationService.logout(null, LogoutServiceCompleted, LogoutServiceFailed, "Context Info");
        }
        // 被登出引用的方法一
        function LogoutServiceCompleted(result, userContext, methodName) {
            alert('你已完成登出.');
        }
        // 被登出引用的方法二
        function LogoutServiceFailed(error, userContext, methodName) {
            alert('登出失敗..\n\n' + error.get_message());
        }

        function checkFirst() {
            var loggedIn = Sys.Services.AuthenticationService.get_isLoggedIn();
            if (!loggedIn) {
                alert("請先login");
                return false;
            }
            return true;
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
            <div>
                Username:
                <asp:TextBox runat="server" ID="username"></asp:TextBox>
                <%--<input type="text" name="username" />--%>
                Admin / User
            </div>

            <div>
                Password:
                <asp:TextBox runat="server" ID="password"></asp:TextBox>
                <%--<input type="password" name="password" />--%>
                P@sswOrd
            </div>

            <div>
                <input type="button" id="loginButton" value="Login" />
                <input type="button" id="logoutButton" value="Logout" />
            </div>
            <a href="sec\sec.aspx" onclick="return checkFirst()"><b>看秘密網頁</b>(要先登入)</a><br />
            <a href="profile_ex1.aspx"><b>去學習 profile 和 Page.Theme</b>(也要先登入，否則網站不會過去，也沒有任何表示)</a><br />
        </div>
    </form>
</body>
</html>
