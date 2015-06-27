﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="WSQP.Mobile.Products" %>
<!DOCTYPE html>
<html>
<head>
    <title>产品中心</title>
     <meta charset="utf-8" />
    <link rel="stylesheet" href="http://code.jquery.com/mobile/1.3.2/jquery.mobile-1.3.2.min.css">
    <script src="http://code.jquery.com/jquery-1.8.3.min.js"></script>
    <script src="http://code.jquery.com/mobile/1.3.2/jquery.mobile-1.3.2.min.js"> </script>
    <link href="../css/grid-listview.css" rel="stylesheet" />
    <script type="text/javascript">
        $(document).on("pageinit", "#pagelist", function () {
          //ShowBigPic();
        });

        function ShowBigPic() {
            $(".pics").on("click", function () {
                var target = $(this),
                    brand = target.find("h2").html(),
                    model = target.find("p").html(),
                    short_old = target.attr("id"),
                short = short_old.substr(0, short_old.length - 4);
                closebtn = '<a href="#" data-rel="back" data-role="button" data-theme="a" data-icon="delete" data-iconpos="notext" data-shadow="false" data-iconshadow="false" class="ui-btn-right">Close</a>',
                header = '<div data-role="header"><h2>' + brand + ' ' + model + '</h2></div>',
                img = '<img src="' + model + '"  alt="' + brand + '" class="photo">',
                popup = '<div data-role="popup" id="popup-' + short + '" data-short="' + short + '" data-theme="none" data-overlay-theme="a" data-corners="false" data-tolerance="15">' + closebtn + header + img + '</div>';

                $.mobile.activePage.append(popup).trigger("pagecreate");

                $(".photo", "#popup-" + short).load(function () {
                    var height = $(this).height(),
                        width = $(this).width();

                    $(this).attr({ "height": height, "width": width });

                    $("#popup-" + short).popup("open");

                    clearTimeout(fallback);
                });

                var fallback = setTimeout(function () {
                    $("#popup-" + short).popup("open");
                }, 2000);
            });

            $(document).on("popupbeforeposition", ".ui-popup", function () {

                var maxHeight = $(window).height() - 68 + "px";
                $("img.photo", this).css("max-height", maxHeight);
            });

            $(document).on("popupafterclose", ".ui-popup", function () {
                $(this).remove();
            });
        }
    </script>
</head>
<body>
    <div data-role="page" id="pagelist" data-url="pics" data-title="pics">
        <div data-role="header" role="banner">
                   <a href="javascript:history.back()" data-role="button" data-icon="arrow-l" data-transition="slide">返回</a>
            <h1><%=proName %></h1>
        </div>
        <div data-role="content">
            <ul data-role="listview" id="list">
          <%=sbHtml %>
            </ul>
        </div>
        <div data-role="footer" data-id="foo1" data-position="fixed">
            <div data-role="navbar">
                <ul>
                    <li><a href="#">上一页</a></li>
                    <li><a href="#">下一页</a></li>
                </ul>
            </div>
        </div>
    </div>
</body>
</html>

