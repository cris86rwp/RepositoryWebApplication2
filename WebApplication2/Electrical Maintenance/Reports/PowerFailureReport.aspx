<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PowerFailureReport.aspx.vb" Inherits="WebApplication2.PowerFailureReport" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head runat="server">
    <title>PowerFailure</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
    <meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.6/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/js/bootstrap.min.js"></script>
    <link type="text/css" rel="stylesheet" href="https://cdn.datatables.net/1.10.9/css/dataTables.bootstrap.min.css" />
    <link type="text/css" rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" />
    <link type="text/css" rel="stylesheet" href="https://cdn.datatables.net/responsive/1.0.7/css/responsive.bootstrap.min.css" />
    <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.9/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/responsive/1.0.7/js/dataTables.responsive.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.9/js/dataTables.bootstrap.min.js"></script>
    <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
    <%--<link rel="stylesheet" href="../../StyleSheet1.css" />--%>
</head>
<body ms_positioning="GridLayout" bgcolor="#99ccff">
    <nav class="mb-1 navbar navbar-expand-sm bg-dark navbar-dark ">
   <a class="navbar-brand p-0" href="#"><img src="../../NewFolder1/unnamed.png" class="rounded-circle z-depth-0"  height="45"/> </a>
  <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent-333"
    aria-controls="navbarSupportedContent-333" aria-expanded="false" aria-label="Toggle navigation">
    <span class="navbar-toggler-icon"></span>
  </button>
  <div class="collapse navbar-collapse " id="navbarSupportedContent-333">
      <ul class="navbar-nav ml-auto  navbar-center">
          <li class="nav-item"> <a class="nav-link" href="#" style="color:white; font-size:25px;">Rail Wheel Plant Bela</a></li>
      </ul>
    <ul class="navbar-nav ml-auto  navbar-right">
        <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../wapframeset.aspx">
          <i class="fab glyphicon glyphicon-home " style="font-size:30px;"></i>
        </a></li>
       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../logon.aspx">
          <i class="fab glyphicon glyphicon-log-out" style="font-size:30px;"></i>
        </a></li>
    
        <li class="nav-item ">
        <a class="nav-link p-0" href="#">
          <img src="../../NewFolder1/CRIS-Recruitment.jpg" class="rounded-circle z-depth-0"  height="45"/>
        </a>
      </li>
     </ul>
      
  </div>
</nav>
    <div class="container">
        <form id="Form2" method="post" runat="server">
            <div class="row">

                <%--<h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>

                <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" CssClass="form-control ll" OnSelectedIndexChanged="dd1_SelectedIndexChanged" Width="400px">
                    <asp:ListItem>select</asp:ListItem>
                    <asp:ListItem>Theme1</asp:ListItem>
                    <asp:ListItem>Theme2</asp:ListItem>
                    <asp:ListItem>Theme3</asp:ListItem>
                </asp:DropDownList>
                <br />--%>
            </div>
            <div class="table-responsive">
                <asp:Panel ID="Panel1" runat="server">
                    <table id="Table1" class="table">
                        <tr>
                            <td colspan="3">Power Failure Report&nbsp;<hr class="prettyline" />
                                <asp:Label ID="lblMode" runat="server" ForeColor="Blue" Font-Bold="True" Font-Names="Arial" Font-Size="Smaller" Width="63px"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="left" colspan="3">
                                <asp:Label ID="lblMessage" runat="server" Width="360px" ForeColor="Red"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="middle" colspan="3">&nbsp;Select Month&nbsp;&nbsp;:
							<asp:DropDownList ID="ddlMonth" CssClass="form-control ll" runat="server"></asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td align="middle" colspan="3">&nbsp;&nbsp; Select 
							Year&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :
							<asp:DropDownList ID="ddlYear" CssClass="form-control ll" runat="server"></asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td align="middle" colspan="3">
                                <asp:Button ID="Button2" runat="server" CssClass="button button2" Text="Monthly Report" Font-Size="Smaller" Font-Names="Arial"></asp:Button></td>
                        </tr>
                        <tr>
                            <td align="middle" colspan="3">From Month Year :
							<asp:DropDownList ID="FromMonth" CssClass="form-control ll" runat="server"></asp:DropDownList>
                                <asp:DropDownList ID="FromYear" CssClass="form-control ll" runat="server"></asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td align="middle" colspan="3">To Month Year :
							<asp:DropDownList ID="ToMonth" CssClass="form-control ll" runat="server"></asp:DropDownList>
                                <asp:DropDownList ID="ToYear" CssClass="form-control ll" runat="server"></asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td align="middle" colspan="3">
                                <asp:Button ID="btnYear" CssClass="button button2" runat="server" Text="Yearly Report"></asp:Button></td>
                        </tr>
                    </table>
                </asp:Panel>
        </form>
        <div class="card-footer" style="text-align: right;">
            <h4>MAINTAINED BY CRIS</h4>
        </div>
</body>
</html>
