<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/hmasterPage.Master" AutoEventWireup="true" CodeBehind="ModifyPassword.aspx.cs" Inherits="WSQP.Admin.ModifyPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script >
        function ValidateIsNull()
        {
            
        }

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
                        }
                        else {
                            $("#error1").html("密码不正确！");
                            $(inObj).focus();
                        }
                    }
                });
            }
        }

        function confirmPassword()
        {
            var password = $("#newPassword").val();
            var cPassword = $("#confirmPassword").val();
            if (password != cPassword)
            {
                $("#error3").html("两次输入的密码不一致!");
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
              <input type="password" id="newPassword"  placeholder="新密码" />
              <span class="help-inline"></span>
          </div>
    </div> 
     <div class="control-group">
          <label class="control-label" for="confirmPassword">确认新密码:</label>
          <div class="controls">
              <input type="password" id="confirmPassword"  placeholder="确认新密码" name="cpassword" onblur="confirmPassword()"/>
               <span class="help-inline" id="error3"></span>
          </div>
    </div> 
     <div class="control-group">
          <div class="controls">
            <button type="submit" class="btn">确定</button>
          </div>
    </div> 
</asp:Content>
