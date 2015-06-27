<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Wstp.aspx.cs" Inherits="WSQP.Wstp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" type="text/css" href="/css/fancybox.css?v=2.1.5" media="screen" />
    <script type="text/javascript" src="js/jquery.fancybox.js?v=2.1.5"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.fancybox').fancybox();
        });
    </script>

    <div class="lcon_l">
        <strong>公司概况</strong>
        <ul class="l_top">
            <li><a href="company.aspx">公司概况</a></li>
            <li><a href="Ourstore.aspx">公司门店</a></li>
            <li><a href="wstp.aspx">资质认证</a></li>
        </ul>
        <div class="l_bottom"></div>
    </div>

    <div class="lcon_r">
        <div class="subnav_r">
            <div class="subnav_in">
                <strong>公司概况</strong>
                <p>首页 >公司概况><b>资质认证</b></p>
            </div>
            <ul class="b_cent">
                <li>
                    <a href="images/tp1.jpg" class="fancybox" data-fancybox-group="gallery">
                        <img src="images/tp1.jpg" alt="" width="150" height="150" /></a>
                    <span>浙江紫阳机械  </span>
                </li>
                <li>
                    <a href="images/tp2.jpg" class="fancybox" data-fancybox-group="gallery">
                        <img src="images/tp2.jpg" alt="" width="150" height="150" /></a>
                    <span>浙江长锋机械</span>
                </li>
                <li>
                    <a href="images/tp3.jpg" class="fancybox" data-fancybox-group="gallery">
                        <img src="images/tp3.jpg" alt="" width="150" height="150" /></a>
                    <span>湖北三环离合器</span>
                </li>
                <li>
                    <a href="images/tp4.jpg" class="fancybox" data-fancybox-group="gallery">
                        <img src="images/tp4.jpg" alt="" width="150" height="150" /></a>
                    <span>湖北好斯基离合器</span>
                </li>
            </ul>
        </div>
    </div>
</asp:Content>
