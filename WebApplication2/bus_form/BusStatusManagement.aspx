<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="BusStatusManagement.aspx.vb" Inherits="timeoffice1.BusStatusManagement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bus Status Management</title>
    <link id="mss" href="/wap.css" rel="stylesheet"/>
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
    <script>
         function isNumber(evt, element) {

                    var charCode = (evt.which) ? evt.which : event.keyCode

                      if (
                           (charCode != 58 || $(element).val().indexOf(':') != -1) &&      // “:” CHECK COLON, AND ONLY ONE.
                           (charCode < 48 || charCode > 57))
                      return false;

                  return true;
                }   

            function validateHhMm(inputField) {
                         var isValid = /^([0-9]|0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$/.test(inputField.value);

                     if (isValid) {
           
                                       
                              inputField.style.backgroundColor = '#ffffff';
             
                     } else {
                         
                         inputField.style.backgroundColor = '#ff8080';
                   
                     }

                      return isValid;
            }
    </script>
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
                        <h3>Bus Status Management</h3><hr class="prettyline" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:Label ID="lbl_msg" runat="server" ForeColor="red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbl_bus_no" runat="server">Bus Registration No.</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txt_bus_no" CssClass="form-control" runat="server" AutoPostBack="True"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lbl_bus_route" runat="server">Bus Route</asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="dd1_route" CssClass="form-control ll" runat="server"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbl_shift" runat="server">Shift</asp:Label>
                    </td>
                    <td>
                        <asp:RadioButtonList ID="rbl_shift" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" CssClass="rbl" RepeatLayout="Flow">
                            <asp:ListItem Value="A">A</asp:ListItem>
                            <asp:ListItem Value="B">B</asp:ListItem>
                            <asp:ListItem Value="C">C</asp:ListItem>
                            <asp:ListItem Value="G">G</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td>
                          <asp:Label ID="lbl_timing" runat="server">Bus Timing</asp:Label>
                    </td>
                    <td>
                        <asp:RadioButtonList ID="rbl_in_out" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" CssClass="rbl" RepeatLayout="Flow">
                            <asp:ListItem Value="in">In</asp:ListItem>
                            <asp:ListItem Value="out">Out</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbl_arr_dept_time" runat="server">Arrival/Departure Time</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txt_arr_dept_time" CssClass="form-control" onblur="validateHhMm(this)" MaxLength="5" onkeypress="return isNumber(event,this)" placeholder="hh:mm" runat="server" AutoPostBack="True"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lbl_time" runat="server">Delay Time</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txt_time" CssClass="form-control" runat="server"></asp:TextBox>
                    </td>
                </tr>
                
                <tr>
                    <td></td>
                    <td colspan="3">
                        <asp:Button ID="btn_Save" CssClass="button button2" runat="server" Text="Save" />
                    </td>
                </tr>
            </table>
        </div></div>
    </form></div>
     <div class="card-footer" style="text-align:right; position:fixed;left:0;bottom:0;width:100%;"><h4>MAINTAINED BY CRIS</h4></div>
</body>
</html>
