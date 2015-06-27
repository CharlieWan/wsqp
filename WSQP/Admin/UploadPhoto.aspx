<%@ Page Language="C#" MasterPageFile="~/Admin/hmasterPage.Master" AutoEventWireup="true" CodeBehind="UploadPhoto.aspx.cs" Inherits="WSQP.UploadPhoto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../uploadify-v2.1.0/uploadify.css" rel="stylesheet" />
    <script src="../uploadify-v2.1.0/jquery-1.3.2.min.js"></script>
    <script src="../uploadify-v2.1.0/swfobject.js"></script>
    <script src="../uploadify-v2.1.0/jquery.uploadify.v2.1.0.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#selFolder").bind("change", function () {
                $("#uploadify").uploadifySettings("script", "uploadHandler.ashx?cid=" + $("#selFolder").val());
            });
            $("#uploadify").uploadify({
                'uploader': "../uploadify-v2.1.0/uploadify.swf",
                'cancelImg': "../uploadify-v2.1.0/cancel.png",
                'script': "uploadHandler.ashx?cid=" + $("#selFolder").val(),
                'queueID': 'fileQueue',
                'folder': "../upload",
                'auto': false,
                'multi': true
            });
        });

        function onExit() {
            window.location.href = "../Login.aspx";
        };
    </script>

    <div id="fileQueue">
        <p>
            <span>选择要上传的类别：</span>
            <select id="selFolder" name="folder">
                <%=cateHtml %>
            </select>
        </p>
        <input type="file" name="uploadify" id="uploadify" />
        <a href="javascript:$('#uploadify').uploadifyUpload()">上传</a>
        <a href="javascript:$('#uploadify').uploadifyClearQueue()">取消上传</a>
    </div>
</asp:Content>
