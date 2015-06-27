<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WSQP.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="keywords" content="|万顺汽配|成都万顺汽配|四川万顺汽配|四川华菱|四川格尔发|江淮|离合器|黄石好斯基离合器|三环离合器|离合器|前面罩|堵板|大灯|华菱|格尔发|江淮|重卡|上车踏板|前盖板|保险杠|室内顶灯|大灯|尾灯|雾灯|传化物流|挡泥板|示高灯|踏板下饰板|踏板护板|踏板护板|踏板衬板|天旭汽配城|万欢|阮景|雾灯|雾灯总成|轮弧饰板|转向灯|万方禄" />
    <meta name="description" content="|万顺汽配|成都万顺汽配|四川万顺汽配|四川华菱|四川格尔发|江淮|离合器|黄石好斯基离合器|三环离合器|离合器|前面罩|堵板|大灯|华菱|格尔发|江淮|重卡|上车踏板|前盖板|保险杠|室内顶灯|大灯|尾灯|雾灯|传化物流|挡泥板|示高灯|踏板下饰板|踏板护板|踏板护板|踏板衬板|天旭汽配城|万欢|阮景|雾灯|雾灯总成|轮弧饰板|转向灯|万方禄" />
    <title>万顺汽配后台登录 | 成都市万顺汽配有限公司(主营华菱、江淮重卡全车件黄石三环、黄石好斯基离合器片、离合器压盘、浙江紫阳机械扭力胶芯等汽车配件)</title>
    <link href="css/style.css" rel="stylesheet" />
    <link href="css/login.css" rel="stylesheet" />
    <script src="js/jquery-1.7.1.js"></script>
    <script src="js/msgBox.js"></script>
    <script type="text/javascript">
        var backurl;
        var msgObj;
        var flag = 0;
        function ajaxLogin() {
            msgObj = new MsgBox();
            var name = $("#txtName").val();
            var password = $("#pwd").val();
            var isp = $("input[name='remember']:checked").val();
            backurl = $("#backurl").val();
            if (name != null && password != null) {
                $.ajax({
                    url: "LoginAjax.ashx",
                    data: "name=" + name + "&password=" + password + "&isp=" + isp + "&flag=" + flag,
                    type: "post",
                    success: function (result) {
                        msgObj.hidBox();
                        if (result == "OK") {
                            if (backurl != "") {
                                window.location = backurl;
                            }
                            else {
                                window.location = "Admin/UploadPhoto.aspx";
                            }
                        }
                        else if (result == "Error") {
                            msgObj.showSysMsgWTime("登陆失败！", "", 2000);
                        }
                    }
                });
            }
        }

        function refreshCode()
        {
            var url = "vaCode.ashx?id=";
            var r = Math.random() * 1000;
            url += r;
            document.all("codeImg").src = url;
            document.all("authcode").value = "";
            document.all("authcode").focus();
            return false;
        }

        function keyLogin() {
            if (event.keyCode == 13)  //回车键的键值为13
            {
               // ajaxLogin(); //调用登录按钮的登录事件
                $("#btnLogin").click();
            }
        }

        function verdict() {
            var code = $("#authcode").val();
            $.ajax({
                url: "verify.ashx",
                data: "code=" + code,
                type: "post",
                success: function (data) {
                    if (data == "OK") {
                        $("#crtimg").css("display", "block");
                        $("#incimg").css("display", "none");
                        flag = 1;
                    }
                    else {
                        $("#incimg").css("display", "block");
                        $("#crtimg").css("display", "none");
                        flag = 0;
                    }
                }
            });
        }
    </script>
</head>
<body onkeydown="keyLogin();">
    <div class="wrapper">
        <form method="post" runat="server">
            <input type="hidden" name="ispostback" value="1" />
            <div class="loginBox">
                <div class="loginBoxCenter">
                    <p>
                        <label for="username">用户名：</label>
                    </p>
                    <p>
                        <input type="text" id="txtName" name="txtName" class="loginInput"  value="admin" />
                    </p>
                    <p>
                        <label for="password">密码：</label><a class="forgetLink" href="#">忘记密码?</a>
                    </p>
                    <p>
                        <input type="password" id="pwd" name="pwd" class="loginInput"  value="67335998"/>
                    </p>
                    <p>
                        <label for="authcode">验证码：</label>
                    </p>
                    <p>
                        <input type="text" id="authcode" name="authcode" class="loginInput" onkeyup="verdict()" />
                        <img src="Vacode.ashx" width="50" height="20" id="codeImg" /><a href="javascript:void(0)" onclick="refreshCode()">刷新</a>
                        <img src="img/correct.gif" width="20" height="20" style="display: none;" id="crtimg" />
                        <img src="img/incorrect.gif" width="20" height="20" style="display: none;" id="incimg" />
                        <span id="result" style="color: red"></span>
                    </p>
                </div>
                <div class="loginBoxButtons">
                    <input id="remember" type="checkbox" name="remember" />
                    <label for="remember">记住登录状态</label>
                    <input type="button" id="btnLogin" value="登录" class="loginBtn" onclick="ajaxLogin()" />
                    <input type="hidden" id="backurl" value="<%=Request.QueryString["backurl"] %>" />
                </div>
            </div>
        </form>
    </div>
</body>
</html>
