<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FeedBack.aspx.cs" Inherits="WSQP.FeedBack" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="js/Form.js"></script>
    <script type="text/javascript">
        function Check(frm) {
            if (isBlank(frm.messageTitle.value)) {
                alert("请输入标题！");
                frm.messageTitle.focus();
                return false;
            }
            if (isBlank(frm.messageName.value)) {
                alert("请输入您的称呼！");
                frm.messageName.focus();
                return false;
            }

            if (isBlank(frm.messagePhone.value)) {
                alert("请输入您的电话！");
                frm.messagePhone.focus();
                return false;
            }

            if (isValidEmail(frm.messageEmail.value)) {
                alert("请输入正确的E-mail地址！");
                frm.messageEmail.focus();
                return false;
            }

            if (isBlank(frm.messageContent.value)) {
                alert("请输入内容！");
                frm.messageContent.focus();
                return false;
            }
            return true;
        }
    </script>
    <div class="lcon_l">
        <strong>联系我们</strong>
        <ul class="l_top">
            <li><a href="Contact.aspx">联系我们</a></li>
            <li><a href="FeedBack.aspx">反馈留言</a></li>
        </ul>
        <div class="l_bottom"></div>
    </div>
    <div class="lcon_r">
        <div class="subnav_r">
            <div class="subnav_in">
                <strong>咨询反馈</strong>
                <p>首页 >联系我们><b>咨询反馈</b></p>
            </div>
            <form id="formMessage" method="post" runat="server" onsubmit="return Check(this)" class="commonForm" action="FeedBack.aspx">
                <table class="feedback">
                    <tbody>
                        <tr>
                            <td>
                                <table class="feedback">
                                    <tbody>
                                        <tr>
                                            <td class="auto-style1">咨询主题：</td>
                                            <td>
                                                <input type="text" name="Title" class="commoninput_text" maxlength="50" /><font color="#FF0000">*</font></td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style1">您的称呼：</td>
                                            <td>
                                                <input type="text" name="userName" class="commoninput_text" maxlength="30" /><font color="#FF0000">*</font></td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style1">您的电话：</td>
                                            <td>
                                                <input type="text" name="Phone" class="commoninput_text" maxlength="50" /><font color="#FF0000">*</font></td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style1">您的邮箱：</td>
                                            <td>
                                                <input type="text" name="Email" class="commoninput_text" maxlength="50" /><font color="#FF0000">*</font></td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style1">留言内容：</td>
                                            <td>
                                                <textarea name="Content" cols="50" rows="4" class="commoninput_textarea"></textarea><font color="#FF0000">*</font></td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <table class="feedback" style="height: 40px">
                    <tbody>
                        <tr>
                            <td>
                                <p class="commonbuttonbed">
                                    <input type="submit" class="commoninput_btn" value="提 交" />
                                    <input type="reset" class="commoninput_btn" value="重 置" />
                                </p>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </form>
        </div>
    </div>

</asp:Content>
