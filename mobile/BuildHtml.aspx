<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BuildHtml.aspx.cs" Inherits="WSQPMobileSite.BuildHtml" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="js/jquery.js"></script>
    <style type="text/css">
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $("input[type='radio']").click(function () {
                $("input[name='btn']").removeAttr("disabled");
            });
        });

        function enableSelect() {
            $("#sel").removeAttr("disabled");
        }

        function disablesel() {
            $("#sel").attr("disabled", "disabled");
        }

        function getHtml() {
            var ck = $("input:radio:checked").val();
            var fold = $("#sel").val();
            $.ajax({
                url: "BuildHtml.aspx",
                type: "post",
                data: "ck=" + ck + "&fold=" + fold,
                success: function (result) {
                    $("#msgDiv").html(result);
                }
            });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <input type="radio" name="ck" value="1" onclick="disablesel()" />新闻列表
             <input type="radio" name="ck" value="2" onclick="enableSelect()" />产品图片
            <select id="sel" disabled="disabled">
                <option value="/HL">华菱</option>
                <option value="/JAC">江淮</option>
                <option value="/LHQ1">三环离合器</option>
                <option value="/JGJ">紧固件</option>
                <option value="/JT">管类接头</option>
                <option value="/YS">雨刮雨刷</option>
                <option value="/NLJX">平衡胶套</option>
                <option value="/QT">其他</option>
                <option value="/LHQ2">好斯基离合器</option>
            </select>
            <input type="button" value="生成html" name="btn" onclick="getHtml()" disabled="disabled" />
        </div>
        <div id="msgDiv">

        </div>
    </form>
</body>
</html>
