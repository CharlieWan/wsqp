<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="NewsHead.aspx.cs" Inherits="WSQP.NewsHeader" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="lcon_l">
        <strong>新闻动态</strong>
        <ul class="l_top">
            <%=sbNewsCate %>
        </ul>
        <div class="l_bottom"></div>
    </div>
    <div class="lcon_r">
        <div class="subnav_r">
            <div class="subnav_in">
                <strong>新闻动态</strong>
                <p>首页 >新闻动态><b><%=catName %></b></p>
            </div>
            <ul class="newsli">
                <%=sbNews %>
            </ul>
        </div>
    </div>
</asp:Content>

