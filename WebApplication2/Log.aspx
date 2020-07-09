<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Log.aspx.vb" Inherits="WebApplication2.Log" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <asp:Label ID ="label1" runat="server" Text="Employee Code"></asp:Label>
            <asp:TextBox  ID="ec" runat="server"></asp:TextBox><br />
            <asp:Label ID ="label2" runat="server" Text="Password"></asp:Label>
            <asp:TextBox  ID="pswd" runat="server" TextMode="Password"></asp:TextBox><br />
            <asp:Button ID ="login" runat ="server" Text="Login" />
        </div>
    </form>
</body>
</html>
