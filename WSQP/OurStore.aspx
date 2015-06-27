<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="OurStore.aspx.cs" Inherits="WSQP.OurStore" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="css/jquery.lightbox-0.5.css" rel="stylesheet" />
    <script src="js/jquery.lightbox-0.5.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#ourstore li a").lightBox();
        });
    </script>
    <div class="lcon_l">
        <strong>公司概况</strong>
        <ul class="l_top">
            <li><a href="company.aspx">公司概况</a></li>
            <li><a href="OurStore.aspx">公司门店</a></li>
            <li><a href="wstp.aspx">资质认证</a></li>
        </ul>
        <div class="l_bottom"></div>
    </div>
    <div class="lcon_r">
        <div class="subnav_r">
            <div class="subnav_in">
                <strong>公司概况</strong>
                <p>首页 >公司概况><b>公司门店</b></p>
            </div>
            <ul id="ourstore">
                <li>
                    <a href="img/overlook.jpg">
                        <img src="img/overlook.jpg" /></a>
                    <span>公司格局</span>
                </li>
                <li>
                    <a href="img/store.jpg">
                        <img src="img/pattern.jpg" /></a>
                    <span>公司侧视</span>
                </li>
                <li>
                    <a href="img/store.jpg">
                        <img src="img/store.jpg" /></a>
                    <span>公司店面</span>
                </li>
            </ul>
        </div>
    </div>
</asp:Content>
