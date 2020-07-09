<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="bus_details_registration.aspx.vb" Inherits="timeoffice1.bus_details_registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bus Registration</title>

    <meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR" />
	<meta content="Visual Basic 7.0" name="CODE_LANGUAGE" />
	<meta content="JavaScript" name="vs_defaultClientScript" />
	<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema" />

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css"/>
    <script  src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.6/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/js/bootstrap.min.js"></script>
    <link type="text/css" rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" />
    <link rel="stylesheet" href="../../StyleSheet1.css" />

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
           
                                      document.getElementById("result1").innerHTML = "";
                              inputField.style.backgroundColor = '#ffffff';
             
                     } else {
                         document.getElementById("result1").innerHTML = "*Time is Invalid";
                         inputField.style.backgroundColor = '#ff8080';
                   
                     }

                      return isValid;
        }
         function isNumber1(evt, element) {

                    var charCode = (evt.which) ? evt.which : event.keyCode

                      if (
                           (charCode != 45 ) && (charCode != 47 ) &&     // 
                           (charCode < 48 || charCode > 57))
                      return false;

                  return true;
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
            <asp:Panel ID="panel1" runat="server">
                <div class="row">
                    <div class="table-responsive">
                        <table id="table1" class="table">
                            <tr>
                                <td colspan="4">
                                    <h3>Bus Registration/Details</h3><hr class="prettyline" />
                                </td>
                            </tr>
                            <tr><td colspan="2" style="color:red"><div id="result1"></div></td>
                                <td>
                                    <asp:Label ID="lbl_msg" ForeColor="Red" runat="server" ></asp:Label>
                                </td>
                            </tr>
                             <tr>
                                <td>
                                    <asp:Label ID="lbl_date" runat="server">Date</asp:Label> 
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_date" onkeypress="return isNumber1(event,this)" MaxLength="10" placeholder="mm/dd/yyyy" runat="server" CssClass="form-control"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_bus_code" runat="server">Bus Registration(Bus No.)</asp:Label><span class="glyphicon-asterisk"></span>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_bus_code" runat="server" CssClass="form-control"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_bus_route" runat="server">Bus Route</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_bus_route" runat="server" CssClass="form-control"></asp:TextBox>
                                </td>
                            </tr>
                           
                            <tr>
                                <td>
                                    <asp:Label id="lbl_shift" runat="server">Schedule Shift</asp:Label>
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="rbl_shift" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="rbl" CellPadding="2">
                                        <asp:ListItem Value="A" Selected="True">A</asp:ListItem>
                                        <asp:ListItem Value="B">B</asp:ListItem>
                                        <asp:ListItem Value="C">C</asp:ListItem>
                                        <asp:ListItem Value="G">G</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                
                            </tr>
                            <tr>
                               <%-- <td>
                                    <asp:Label id="lbl_dept_shift" runat="server">Schedule Arrival Shift</asp:Label>
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="rbl_dept_shift" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="rbl" CellPadding="2">
                                        <asp:ListItem Value="A" Selected="True">A</asp:ListItem>
                                        <asp:ListItem Value="B">B</asp:ListItem>
                                        <asp:ListItem Value="C">C</asp:ListItem>
                                        <asp:ListItem Value="G">G</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>--%>
                                <td>
                                    <asp:Label ID="lbl_schdul_arr" runat="server">Schedule Arrival Time</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_schdul_arr" onblur="validateHhMm(this)" MaxLength="5" onkeypress="return isNumber(event,this)" placeholder="hh:mm" runat="server" CssClass="form-control"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_schdul_dept" runat="server">Schedule Departure Time</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_schdul_dept" onblur="validateHhMm(this)" MaxLength="5" onkeypress="return isNumber(event,this)" placeholder="hh:mm" runat="server" CssClass="form-control"></asp:TextBox>
                                </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lbl_bus_status" runat="server">Bus Status</asp:Label>
                            </td>
                            <td>
                               <asp:RadioButtonList ID="rbl_bus_status" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="rbl" CellPadding="2">
                                    <asp:ListItem Value="Operational">Operational</asp:ListItem>
                                    <asp:ListItem Value="Non-Operational">Non-Operational</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td colspan="4">
                                <asp:Button ID="btn_save" runat="server" Text="Save" CssClass="button button2"/>
                            </td>
                           
                         </tr>
                    </table>
                </div>
            </div>
        </asp:Panel>
    </form>
    </div>
   <div class="card-footer" style="text-align:right; position:fixed;left:0;bottom:0;width:100%;"><h4>MAINTAINED BY CRIS</h4></div>
</body>
</html>
