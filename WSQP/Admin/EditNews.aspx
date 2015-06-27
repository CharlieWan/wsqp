<%@ Page Language="C#" MasterPageFile="~/Admin/hmasterPage.Master" AutoEventWireup="true" CodeBehind="EditNews.aspx.cs" Inherits="WSQP.Admin.EditNews" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../ckeditor/ckeditor.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            CKEDITOR.replace("myeditor");
        });
    </script>

    <div>
    <span>标题：</span>
    <input type="text" value="<%=title%>" name="title"  style="width: 400px;" placeholder="" /><br />
    <span>类别：</span>
    <select name="selNewsCate">
        <%=sbNewsCate %>
    </select>
    <textarea class="ckeditor" name="myeditor"><%=content %></textarea>
    <input type="submit" value="提交修改"  class="btn btn-info"/>
    </div>
</asp:Content>
