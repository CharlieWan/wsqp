$(function () {
    $("li.mainlevel").mousemove(function () {
        $(this).find("ul").slideDown(200);
    });
    $("li.mainlevel").mouseleave(function () {
        $(this).find("ul").slideUp(200);
    });
});