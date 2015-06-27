<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="WSQP.Mobile.News" %>
<!DOCTYPE html>
<html>
<head>
    <title>新闻中心</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="http://code.jquery.com/mobile/1.2.0/jquery.mobile-1.2.0.min.css" />
    <script src="http://code.jquery.com/jquery-1.8.2.min.js"></script>
    <script src="http://code.jquery.com/mobile/1.2.0/jquery.mobile-1.2.0.min.js"></script>
</head>
<body>
    <div data-role="page">
        <div data-role="header">
            <a href="javascript:history.back()" data-role="button" data-icon="arrow-l" data-transition="slide">返回</a>
            <h1></h1>
        </div>
        <div data-role="content">
            <div id="content">
                <%=sbHtml %>
            </div>
        </div>

        <div data-role="footer" data-id="foo1" data-position="fixed">
            <div data-role="navbar">
                <ul>
                    <li><a href="{1}">上一页</a></li>
                    <li><a href="{2}">下一页</a></li>
                </ul>
            </div>
        </div>

    </div>
</body>
</html>
