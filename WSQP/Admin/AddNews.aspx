<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddNews.aspx.cs"
    Inherits="WSQP.AddNews" ValidateRequest="false" MasterPageFile="~/Admin/hmasterPage.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../ckeditor/ckeditor.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            CKEDITOR.replace('editor01');
        });
    </script>
     
    <div class="control-group">
    <label class="control-label" for="inputTitle">标题：</label>
    <input type="text" name="title"  id="inputTitle" placeholder="请输入新闻标题"/>
       </div>
    <div class="control-group">
    <label class="control-label"  for=".selNewsCate">新闻类别：</label>
    <select name="selNewsCate">
        <%=sbNewsCate %>
    </select>
        </div>
    <div class="control-group">
    <textarea name="editor01" class="ckeditor" rows="3"> 
    </textarea>
        </div>
    <div class="control-group">
    <input type="submit" value="添加" class="btn btn-primary" />
    </div>
</asp:Content>


