<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsBrief.aspx.cs" Inherits="WSQP.Mobile.NewsBrief" %>

<!DOCTYPE html>
<html>
<head>
    <title><%=NewsCatName %></title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="http://code.jquery.com/mobile/1.2.0/jquery.mobile-1.2.0.min.css" />
    <script src="http://code.jquery.com/jquery-1.8.2.min.js"></script>
    <script src="http://code.jquery.com/mobile/1.2.0/jquery.mobile-1.2.0.min.js"></script>
</head>
<body>
    <div data-role="page">
        <div data-role="header">
            <a href="Index.aspx" data-role="button" data-icon="star">首页</a>
            <h1><%=NewsCatName %></h1>
        </div>
        <div data-role="content">
            <ul data-role="listview" data-count-theme="c">
             <%=sbHtml %>
            </ul>
        </div>
        <div data-role="footer" data-id="foo1" data-position="fixed">
            <div data-role="navbar">
                <ul>
                    <li><a href="#" data-transition="slide">上一页</a></li>
                    <li><a href="#" data-transition="slide">下一页</a></li>
                </ul>
            </div>
        </div>
    </div>
</body>
</html>

