<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="WSQP.News" %>

<asp:content id="Content1" contentplaceholderid="ContentPlaceHolder1" runat="server">
        <div class="lcon_l">
            <strong>新闻动态</strong>
            <ul class="l_top">
                <li><a href="Newshead.aspx">公司新闻</a></li>
                <li><a href="Newshead.aspx">行业新闻</a></li>
                <li><a href="Newshead.aspx">展会报道</a></li>
            </ul>
            <div class="l_bottom"></div>
        </div>
        <div class="lcon_r">
            <div class="subnav_r">
                <div class="subnav_in">
                    <strong>新闻动态</strong>
                    <p>首页 >新闻动态><b>行业新闻</b></p>
                </div>
                <div class="newscontent">
                    <%=sbContent %>
                </div>
                <div class="NewsNavi">
                    <%=sbNavi %>
                </div>
            </div>
        </div>
</asp:content>
