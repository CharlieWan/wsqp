<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WSQP.Mobile.Index1" %>

<!DOCTYPE html>
<html>
<head>
    <title>首页 | 成都市万顺汽配有限公司官方网站</title>
    <link rel="stylesheet" href="http://code.jquery.com/mobile/1.3.2/jquery.mobile-1.3.2.min.css">
    <script src="http://code.jquery.com/jquery-1.8.3.min.js"></script>
    <script src="http://code.jquery.com/mobile/1.3.2/jquery.mobile-1.3.2.min.js"> </script>
    <link href="css/grid-listview.css" rel="stylesheet" />
</head>
<body>
    <div data-role="page" id="pagelist">
        <div data-role="header">
            <h1>成都市万顺汽配</h1>
        </div>
        <div data-role="content">
            <div data-role="collapsible-set" data-theme="c" data-content-theme="d" data-inset="false">
                <div data-role="collapsible">
                    <h2>产品中心</h2>
                    <ul data-role="listview">
                      <%=productTitle %>
                    </ul>
                </div>
                <div data-role="collapsible">
                    <h2>新闻中心</h2>
                    <ul data-role="listview" data-theme="d" data-divider-theme="d" id="news">
                  <%=newsTitle %>
                    </ul>
                </div>
                <div data-role="collapsible">
                    <h2>品牌中心</h2>
                    <ul data-role="listview" data-theme="d" data-divider-theme="d">
                        <li data-role="list-divider">华菱</li>
                        <li>
                            <h2></h2>
                        </li>
                        <li data-role="list-divider">三环</li>
                        <li>
                            <h2></h2>
                        </li>
                        <li data-role="list-divider">好斯基</li>
                        <li>
                            <h4></h4>
                            <h4></h4>
                        </li>
                        <li data-role="list-divider">浙江紫阳</li>
                        <li>
                            <h4></h4>
                            <h4></h4>
                        </li>
                        <li data-role="list-divider">邮箱</li>
                        <li>
                            <h4>邮箱 :<a href="mailto:wanfenglu@21cn.com">wanfenglu@21cn.com</a></h4>
                            <h4>官方QQ:1586553115 </h4>
                        </li>
                    </ul>
                </div>
                <div data-role="collapsible">
                    <h2>关于我们</h2>
                    <ul data-role="listview" data-theme="d" data-divider-theme="d">
                        <li><a href="company.html">
                            <span>关于我们</span>
                        </a>
                        </li>
                        <li><a href="contact.html">
                            <span>联系我们</span>
                        </a>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
        <div data-role="footer">
            <h4>Copyright&copy;2010-2014 All Rights  Reserved </h4>
            <h4>成都市万顺汽配有限公司</h4>
             <h3><a href="../Index.aspx">电脑版</a> <a href="Index.aspx">触屏版</a></h3>
        </div>
    </div>
</body>
</html>

