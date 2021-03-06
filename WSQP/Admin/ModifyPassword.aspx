﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/hmasterPage.Master" AutoEventWireup="true" CodeBehind="ModifyPassword.aspx.cs" Inherits="WSQP.Admin.ModifyPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script >
        function  checkPassword(inObj)
        {
            var strName = $(inObj).attr("strname");
            if ($(inObj).val() == "") {
                $("#error1").html("*请输入原始密码！");
                $(inObj).focus();
            }
            else {
                $("#error1").html("");
                $.ajax({
                    type: "post",
                    url: "../LoginAjax.ashx",
                    data: {
                        name: strName,
                        password: $(inObj).val().trim(),
                        flag:1
                    },
                    dataType: "text",
                    success: function (data) {
                        if (data == "OK") {
                            $("#error1").html("密码正确！");
                            canSubmit = 1;
                        }
                        else {
                            $("#error1").html("密码不正确！");
                            $(inObj).focus();
                        }
                    }
                });
            }
        }

        //检验密码长度是否ok
        function CheckPasswordLength()
        {
            var newP = $("#newPassword").val();
            if (newP == "") {
                $("#error2").html("请输入新密码！");
            }
            else {
                $("#error2").html("");
                if (newP.length < 6 || newP.length > 10) {
                    $("#error2").html("密码长度需为6到10之间的字母与数字组合!");
                }
            }
        }

        var newP;
        //校验两次密码输入的是相同的
        function confirmPasswordIsSame()
        {
            var password = $("#newPassword").val();
            var cPassword = $("#confirmPassword").val();
            if (password != cPassword) {
                $("#error3").html("两次输入的密码不一致!");
                return false;
            }
            else {
                newP = cPassword;
                return true;
            }
        }
        
        //提交修改到后台处理
        function submitModifyPass()
        {
            if (confirmPasswordIsSame()) {
                $.ajax({
                    type: "post",
                    data: {
                        newPassword: newP
                    },
                    url: "SubmitModifyPassword.ashx",
                    success: function (data) {
                        if (data == "OK") {
                            alert("修改成功！");
                            windows.location.href = "~/index.aspx";
                        }
                        else {
                            alert("失败,请检查！");
                        }
                    }
                });
            }
            else {
                alert("密码不一致！");
            }
        }
    </script>
    <div class="control-group" id="oldIuput">
         <label class="control-label" for="oldPassword">请输入旧密码:</label>
          <div class="controls">
              <input type="password" id="oldPassword" placeholder="旧密码" onblur="checkPassword(this)" strname="<%=Session["uinfo"] %>"/>
               <span class="help-inline text-error" id="error1"></span>
          </div>
    </div>
    <div class="control-group">
          <label class="control-label" for="newPassword">请输入新密码:</label>
          <div class="controls">
              <input type="password" id="newPassword"  placeholder="新密码" onblur="CheckPasswordLength()" />
              <span class="help-inline text-success" id="error2"></span>
          </div>
    </div> 
     <div class="control-group">
          <label class="control-label" for="confirmPassword">确认新密码:</label>
          <div class="controls">
              <input type="password" id="confirmPassword"  placeholder="确认新密码" name="cpassword" onblur="confirmPasswordIsSame()"/>
               <span class="help-inline" id="error3"></span>
          </div>
    </div> 
     <div class="control-group">
          <div class="controls">
              <input type="hidden"  name="flag" id="flag" value="0"/>
            <button type="button" class="btn" onclick="submitModifyPass()">确定</button>
          </div>
    </div> 
</asp:Content>
