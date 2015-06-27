<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Brand.aspx.cs" Inherits="WSQP.Brand" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="lcon_l">
            <strong>品牌中心</strong>
            <ul class="l_top">
                <li><a href="products.aspx">华菱重卡(CAMC)</a></li>
                <li><a href="products.aspx">江淮重卡(JAC)</a></li>
                <li><a href="products.aspx">三环离合器</a></li>
                <li><a href="products.aspx">好斯基离合器</a></li>
                <li><a href="products.aspx">紫阳平衡胶套</a></li>
            </ul>
            <div class="l_bottom"></div>
        </div>
        <div class="lcon_r">
            <div class="subnav_r">
                <div class="subnav_in">
                    <strong>品牌中心</strong>
                    <p>首页 >品牌中心><b>品牌中心</b></p>
                </div>
                <ul class="b_cent">
                    <li>
                        <a href="products.aspx">
                            <img src="img/brand4.jpg" width="153" height="113" alt="" /></a>
                        <p><a href="http://www.triringclutch.com/" target="_blank">三环离合器</a></p>
                    </li>
                    <li>
                        <a href="products.aspx">
                            <img src="img/brand3.jpg" width="153" height="113" alt="" /></a>
                        <p><a href="http://www.camc.cc/" target="_blank">华菱重卡(CAMC)</a></p>
                    </li>
                    <li>
                        <a href="products.aspx">
                            <img src="img/brand2.jpg" width="153" height="113" alt="" /></a>
                        <p><a href="http://www.jac.com.cn/" target="_blank">江淮重卡(JAC)</a></p>
                    </li>
                </ul>
            </div>
        </div>
</asp:Content>
