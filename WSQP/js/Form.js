function isValidEmail(strEmail) {
    var myreg = /^([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+@([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+\.[a-zA-Z]{2,3}$/;
    if (!myreg.test(strEmail))
        return true;
    else
        return false;
}
function isBlank(s) {
    var len = s.length;
    for (i = 0; i < len; i++) {
        if (s.charAt(i) != " ")
            return false;
    }
    return true;
}
function isNum(Num) {
    var i, j, strTemp;
    strTemp = "0123456789";
    if (Num.length == 0)
        return false;
    for (i = 0; i < Num.length; i++) {
        j = strTemp.indexOf(Num.charAt(i));
        if (j == -1) {
            return false;
        }
    }
    return true;
}
function isPost(NUM) {
    if (NUM.length != 6)
        return false;
    if (!isNum(NUM))
        return false;
    return true;
}
function isIDCard(NUM) {
    if (NUM.length != 15) {
        if (NUM.length != 18)
            return false;
    }
    return false;
    if (!isNum(NUM))
        return false;
    return true;
}