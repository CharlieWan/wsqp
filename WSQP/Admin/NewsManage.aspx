<%@ Page Language="C#" MasterPageFile="~/Admin/hmasterPage.Master" AutoEventWireup="true" CodeBehind="NewsManage.aspx.cs" Inherits="WSQP.NewsManage" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../ckeditor/ckeditor.js"></script>
    <script type="text/javascript">
        function del(delObj) {
            if (confirm("你确定要删除该条新闻吗?")) {
                var nid = $(delObj).attr("id");
                $.ajax({
                    url: "DelNews.ashx",
                    type: "get",
                    data: "nid=" + nid,
                    success: function (data) {
                        if (data == "OK") {
                            $(delObj).parent().parent().remove();
                        }
                    }
                });
            }
        }

    </script>
    <table class="table table-hover">
      <thead>
          <tr>
              <th>id</th>
               <th>标题</th>
               <th>操作</th>
          </tr>
      </thead>
        <tbody>
   <%=htmlData%>
            </tbody>
    </table>
</asp:Content>
