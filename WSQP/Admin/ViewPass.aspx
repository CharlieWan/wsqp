<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewPass.aspx.cs" Inherits="WSQP.Admin.ViewPass" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>ViewPass</title>
    <link rel="stylesheet" href="http://code.jquery.com/mobile/1.3.2/jquery.mobile-1.3.2.min.css" />
    <script src="http://code.jquery.com/jquery-1.8.3.min.js"></script>
    <script src="http://localhost:3761/js/jquery-1.7.1.js"></script>
    <script src="http://code.jquery.com/mobile/1.3.2/jquery.mobile-1.3.2.min.js"> </script>
     <script type="text/javascript">
         function showDetail(aObj) {
             var id = $(aObj).attr("valu");
             $.ajax({
                 url: "GetEntry.ashx",
                 data: "id=" + id,
                 type: "get",
                 success: function (result) {
                     var objects = eval("(" + result + ")");
                     var htmlStr = "";
                     for (var i = 0; i < objects.length; i++) {
                         htmlStr += "<h3><a href=" + objects[i].url + " target='_blank'>" + objects[i].title + "</a></h3>";
                         htmlStr += "<p>用户名:" + objects[i].userName + "</p><p>密码:" + objects[i].userPwd + "</p>";
                         htmlStr += "<p>备注:" + objects[i].Remark + "</p>";
                         $("#det").html(htmlStr);
                     }
                 }
             });
         }
    </script>
</head>

<body>
    <div data-role="header">
        <h1>ViewPass</h1>
    </div>
    <div data-role="content">
        <div data-role="collapsible-set" data-theme="c" data-content-theme="d" data-inset="true">
            <%=sbHtml %>
        </div>
        <div data-role="popup" id="detail" data-theme="d" data-overlay-theme="b" class="ui-content" style="max-width:340px; padding-bottom:2em;">
             <div id="det"></div>
            <a href="javascript:history.back()" data-role="button" data-rel="back" data-theme="b" data-icon="check" data-inline="true" data-mini="true">OK</a>
            <a href="javascript:history.back()" data-role="button" data-rel="back" data-inline="true" data-mini="true">Cancel</a>
        </div>
    </div>
    <div data-role="footer">
        <h4>Copyright&copy;2010-2015 All Rights  Reserved </h4>
        <h4>Designed by Charlie Man</h4>
    </div>
</body>
</html>

