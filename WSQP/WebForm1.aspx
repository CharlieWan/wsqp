<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WSQP.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="js/jquery-1.8.0.min.js"></script>
    <script type="text/javascript">
        function abc()
        {
            alert($("input[name='aa']").val());
        }

    </script>
      
</head>
<body>
    <form id="form1" runat="server">
    <div>
  <%-- <img src="../upload/20140902101640505.jpg" />
        <img src="img/2.jpg" />
        <img src="upload/DSCN6438.jpg" />--%>
        <input  type="text" name="aa" onchange=""  value="ii" onblur=""/>
    </div>
    </form>
</body>
</html>
