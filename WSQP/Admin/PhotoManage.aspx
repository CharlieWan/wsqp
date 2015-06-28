<%@ Page Language="C#" MasterPageFile="~/Admin/hmasterPage.Master" AutoEventWireup="true" CodeBehind="PhotoManage.aspx.cs" Inherits="WSQP.PhotoManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../css/jquery.lightbox-0.5.css" rel="stylesheet" />
 <%--   <link href="../css/style.css" rel="stylesheet" />--%>
    <style type="text/css">
        #imgList  li img{
        width:150px;
        height:100px;
        border:1px solid #000000;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            change();
            $.ajaxSetup({ cache: false });
        });

        var catid = 1;
        function change() {
            $("#imgList").html("");
            catid = $("#selFolder").val();
            $.ajax({
                url: "AjaxGetPhoto.ashx",
                type: "post",
                data: "catid=" + catid,
                success: function (result) {
                    var objects = eval("(" + result + ")");
                    if (objects != null) {
                        for (var i = 0; i < objects.length; i++) {
                            $("#imgList").append("<li><a href='../" + objects[i].Path + "' name='a'><img src=../" + objects[i].Path + " /></a><a ondblclick='showedit(this)' id=" + objects[i].Id + ">" + objects[i].Name + "</a><a href='javascript:void(0)'  id=" + objects[i].Id + " onclick=del(this)>删除</a>");
                        }
                        $("#imgList li a[name='a']").lightBox();
                    }
                    else {
                        $("#imgList").html("木有数据！");
                    }
                }
            });
        }

        //删除一个对象
        function del(delObj) {
            var id = $(delObj).attr("id");
            if (confirm("你确定要删除该文件吗？")) {
                $.ajax({
                    url: "DelPhoto.ashx",
                    type: "post",
                    data: "id=" + id,
                    success: function (data) {
                        if (data == "OK") {
                            $(delObj).parent().remove();
                        }
                    }
                });
            }
        };

        //修改图片文件名
        function showedit(editObj) {
            var id = $(editObj).attr("id");
            var oldname = $(editObj).html();
            //var newInput = $("#imgList").add("<input>");
            //$(newInput).attr("value", oldname);
            //$(newInput).attr("id", id);
            //$(newInput).change("submitChange(this)");
            $(editObj).replaceWith("<input type='text' value='" + oldname + "' id=" + id + "  onblur='submitChange(this)' />");
        }

        //提交修改到数据库
        function submitChange(inputObj) {
            var newName = $(inputObj).val();
            var id = $(inputObj).attr("id");
            $.ajax({
                url: "EditFileName.ashx",
                type: "post",
                data: "newName=" + newName + "&id=" + id,
                success: function (result) {
                    if (result == "OK") {
                        $(inputObj).replaceWith("<a href='javascript:void(0)' ondblclick='showedit(this)' id=" + id + ">" + newName + "</a>");
                    }
                }
            });
        }
    </script>
    <table>
        <tr>
            <td>选择类别：
                        <select id="selFolder" name="folder" onchange="change()">
                            <%=cateHtml %>
                        </select>
            </td>
        </tr>
    </table>
    <ul id="imgList">
    </ul>  
<script src="../js/jquery.lightbox-0.5.js"></script>
</asp:Content>

