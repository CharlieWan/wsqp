<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WSQP.Index" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="js/PicSwitch.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var u = navigator.userAgent;
            if (u.match("Android") || u.match("IPhone") || u.match("IPad")) {
                window.location.href = "../Mobile/Index.aspx";
            }
            else {
                $("#detail_ban").css("display", "none");
                var myleft = 0;
                var timer = setInterval(sport, 30)
                function sport() {
                    $('.wuxi ul').css({ left: myleft -= 2 })
                    if (myleft <= -418) {
                        myleft = 0;
                    }
                }
                $('.wuxi li').mouseover(function (e) {
                    clearInterval(timer);
                    $(this).siblings().stop().fadeTo(500, 0.5)//突出显示当前的图片；
                }).mouseout(function (e) {
                    clearInterval(timer);
                    timer = setInterval(sport, 30);
                    $('.wuxi li').stop().fadeTo(500, 1);
                });
            }
        });
    </script>

    <div id="banner">
        <ul class="showt">
            <li><a href="Products.aspx">
                <img src="img/b1.jpg" alt="" /></a></li>
            <li><a href="Products.aspx">
                <img src="img/b2.jpg" alt="" /></a></li>
            <li><a href="Products.aspx">
                <img src="img/b3.jpg" alt="" /></a></li>
            <li><a href="Products.aspx">
                <img src="img/b4.jpg" alt="" /></a></li>
            <li><a href="Products.aspx">
                <img src="img/b5.jpg" alt="" /></a></li>
            <li><a href="Products.aspx">
                <img src="img/b6.jpg" alt="" /></a></li>
        </ul>
    </div>
    <div class="contt">
        <div class="contl">
            <div class="conl_t">
                <p>
                    <strong>产品展示</strong>
                </p>
                <a href="products.aspx">
                    <img src="img/more.jpg" alt="" /></a>
            </div>
            <ul class="line">
                <li class="one"></li>
                <li class="two"></li>
            </ul>
            <ul class="product">
                <li>
                    <a href="products.aspx?pid=1&cid=1">
                        <img src="img/1.jpg" alt="离合器" />
                    </a>
                    <p><a href="products.aspx?pid=1&cid=1">1</a></p>

                </li>
                <li>
                    <a href="products.aspx?pid=1&cid=2">
                        <img src="img/2.jpg" alt="华菱重卡" /></a>
                    <p><a href="products.aspx?pid=1&cid=2">2</a></p>

                </li>
                <li>
                    <a href="products.aspx?pid=1&cid=3">
                        <img src="img/3.jpg" alt="" /></a>
                    <p><a href="products.aspx?pid=1&cid=3">3</a></p>

                </li>
                <li class="forth">
                    <a href="products.aspx?pid=1&cid=4">
                        <img src="img/4.jpg" alt="" /></a>
                    <p><a href="products.aspx?pid=1&cid=4">4</a></p>

                </li>
                <li>
                    <a href="products.aspx?pid=1&cid=5">
                        <img src="img/5.jpg" alt="" /></a>
                    <p><a href="products.aspx?pid=1&cid=5">5</a></p>
                </li>
                <li>
                    <a href="products.aspx?pid=1&cid=6">
                        <img src="img/6.jpg" alt="" /></a>
                    <p><a href="products.aspx?pid=1&cid=6">6</a></p>

                </li>
                <li>
                    <a href="products.aspx?pid=1&cid=7">
                        <img src="img/7.jpg" alt="" /></a>
                    <p><a href="products.aspx?pid=1&cid=7">7</a></p>

                </li>
                <li class="forth">
                    <a href="products.aspx?pid=1&cid=8">
                        <img src="img/8.jpg" alt="" /></a>
                    <p><a href="products.aspx?pid=1&cid=8">8</a></p>
                </li>
            </ul>
        </div>
        <div class="contl contr">
            <div class="conl_t conr_t ">
                <p>
                    <strong>新闻动态</strong>

                </p>
                <a href="newshead.aspx">
                    <img src="img/more.jpg" alt="" /></a>
            </div>
            <ul class="line liner">
                <li class="one oner"></li>
                <li class="two twor"></li>
            </ul>
            <ul class="news">
                <%=indexNews %>
            </ul>
        </div>
    </div>
    <div class="contt contb ">
        <div class="contl">
            <div class="conl_t">
                <p>
                    <strong>品牌中心</strong>

                </p>
                <a href="brand.aspx">
                    <img src="img/more.jpg" alt="" /></a>
            </div>
            <ul class="line">
                <li class="one"></li>
                <li class="two"></li>
            </ul>
            <ul class="brand">
                <li>
                    <a href="brand.aspx">
                        <img src="img/brand2.jpg" alt="" /></a>
                    <p><a href="brand.aspx">江淮系列</a></p>
                </li>
                <li>
                    <a href="brand.aspx">
                        <img src="img/brand4.jpg" alt="" /></a>
                    <p><a href="brand.aspx">湖北三环系列</a></p>
                </li>
                <li>
                    <a href="brand.aspx">
                        <img src="img/brand3.jpg" alt="" /></a>

                    <p><a href="brand.aspx">华菱重卡系列</a></p>
                </li>
            </ul>
        </div>
        <div class="contl contr">
            <div class="conl_t conr_t ">
                <p>
                    <strong>合作伙伴</strong>
                </p>
                <a href="brand.aspx">
                    <img src="img/more.jpg" alt="" /></a>
            </div>
            <ul class="line liner">
                <li class="one oner"></li>
                <li class="two twor"></li>
            </ul>
            <div class="wuxi">
                <ul>
                    <li>
                        <img src="img/brand1.jpg" alt="" />
                    </li>
                    <li>
                        <img src="img/brand2.jpg" alt="" />
                    </li>
                    <li>
                        <img src="img/brand3.jpg" alt="" />
                    </li>
                    <li>
                        <img src="img/brand4.jpg" alt="" />
                    </li>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>

