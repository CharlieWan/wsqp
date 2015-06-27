<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" ValidateRequest="false"
    CodeBehind="Products.aspx.cs" Inherits="WSQP.Products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" type="text/css" href="/css/fancybox.css?v=2.1.5" media="screen" />
    <script type="text/javascript" src="js/jquery.fancybox.js?v=2.1.5"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.fancybox').fancybox();
        });
    </script>

    <div class="lcon_l">
        <strong>产品列表</strong>
        <%=sbLeft %>
        <div class="l_bottom"></div>
    </div>
    <div class="lcon_r">
        <div class="subnav_r">
            <div class="subnav_in">
                <strong>产品列表</strong>
                <p>首页 >产品列表><b></b></p>
            </div>
            <div class="article">
                <!-- 这里写页码的控制条-->
                <div class="sabrosus">
                    <%=pageText %>
                </div>
                <ul class="b_cent">
                    <%=sbHtml %>
                </ul>
            </div>
        </div>
    </div>

</asp:Content>
