<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="employeeCumByBus.aspx.vb" Inherits="timeoffice1.employeeCumByBus" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee Travelling By Bus</title>
    <meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR"/>
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
           <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css"/>
  <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.6/umd/popper.min.js"></script>
  <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/js/bootstrap.min.js"></script>

                <link type="text/css" rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" />
        	              <link rel="stylesheet" href="../StyleSheet1.css" />
</head>
<body>
     <nav class="mb-1 navbar navbar-expand-sm bg-dark navbar-dark " >
  <a class="navbar-brand p-0" href="#"><img src="../NewFolder1/unnamed.png" class="rounded-circle z-depth-0"  height="45"/> </a>
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
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../wapframeset.aspx">
          <i class="fab glyphicon glyphicon-home "></i>
        </a></li>
       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../logon.aspx">
          <i class="fab glyphicon glyphicon-log-out"></i>
        </a></li>
           <li class="nav-item ">
        <a class="nav-link p-0" href="#">
          <img src="../NewFolder1/CRIS-Recruitment.jpg" class="rounded-circle z-depth-0"  height="45"/>
        </a>
      </li>
     </ul>
      
  </div>
</nav>
    <div class="container">
    <form id="form1" runat="server">
         <div class="row">
                <h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
                <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                </asp:DropDownList> <br />
            </div>
        
        <div class ="row">
        <div class="table-responsive">
            <table id="table1" class="table">
                <tr>
                    <td colspan="4">
                        <h3>Employee Travelling By Bus</h3><hr class="prettyline" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:Label ID="lbl_msg" runat="server" ForeColor="red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbl_emp_id" runat="server">Employee Id</asp:Label><span class="glyphicon-asterisk"></span>
                    </td>
                    <td>
                        <asp:TextBox ID="txt_emp_id" CssClass="form-control" AutoPostBack="true" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lbl_emp_name" runat="server">Employee Name</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txt_emp_name" CssClass="form-control" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbl_bus_no" runat="server">Bus Registration No.</asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddl_bus_no" CssClass="form-control ll" AutoPostBack="true" runat="server"></asp:DropDownList>
                        
                    </td>
                    <td>
                        <asp:Label ID="lbl_bus_route" runat="server">Bus Route</asp:Label>
                    </td>
                    <td>
                       <asp:DropDownList ID="ddl_bus_route" CssClass="form-control ll" runat="server"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="4">
                        <asp:Button ID="btn_save" CssClass="button button2" runat="server" Text="Save"/>
                    </td>
                </tr>
            </table>
       </div></div>
    </form>
    </div>
        <div class="card-footer" style="text-align:right; position:fixed;left:0;bottom:0;width:100%;"><h4>MAINTAINED BY CRIS</h4></div>
</body>
</html>
