<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="EditDrawfurnaceDetails.aspx.vb" Inherits="WebApplication2.EditDrawfurnaceDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DrawFurnaceDetails</title>
    <link href="/wap.css" rel="stylesheet"/>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR"/>
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
         <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css"/>
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.6/umd/popper.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/js/bootstrap.min.js"></script>
         <link type="text/css" rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" />
        <link rel="stylesheet" href="../../../StyleSheet1.css" />
</head>
<body>
     <nav class="mb-1 navbar navbar-expand-sm bg-dark navbar-dark " >
 <a class="navbar-brand p-0" href="#"><img src="../../../NewFolder1/unnamed.png" class="rounded-circle z-depth-0"  height="45"/> </a>
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
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../../wapframeset.aspx">
          <i class="fab glyphicon glyphicon-home "></i>
        </a></li>
       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../../logon.aspx">
          <i class="fab glyphicon glyphicon-log-out"></i>
        </a></li>
    
        <li class="nav-item ">
        <a class="nav-link p-0" href="#">
          <img src="../../../NewFolder1/CRIS-Recruitment.jpg" class="rounded-circle z-depth-0"  height="45"/>
        </a>
      </li>
     </ul>
      
  </div>
</nav>
<!--/.Navbar --> 
    <script>

         function ValidateAlpha(evt)
    {
        var keyCode = (evt.which) ? evt.which : evt.keyCode
        if ((keyCode < 65 || keyCode > 90) && (keyCode < 97 || keyCode > 123) && keyCode != 32)
         
        return false;
            return true;
    }

 function isInputNumber(evt) {

                    var ch = String.fromCharCode(evt.which);
                    if (!(/[0-9]/.test(ch))) {
                        evt.preventDefault();
                    }

        }

          function isNumber(evt, element) {

                    var charCode = (evt.which) ? evt.which : event.keyCode

                      if (
                           (charCode != 58 || $(element).val().indexOf(':') != -1) &&      // “:” CHECK COLON, AND ONLY ONE.
                           (charCode < 48 || charCode > 57))
                      return false;

                  return true;
                }    

         function isNumber1(evt, element) {

                    var charCode = (evt.which) ? evt.which : event.keyCode

                      if (
                           (charCode != 45 ) && (charCode != 47 ) &&     // 
                           (charCode < 48 || charCode > 57))
                      return false;

                  return true;
            } 

            function validateHhMm(inputField) {
                         var isValid = /^([0-9]|0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$/.test(inputField.value);

                     if (isValid) {
           
                                       
                         //document.getElementById("result1").innerHTML = "";
                              inputField.style.backgroundColor = '#ffffff';
             
                     } else {
                           //document.getElementById("result1").innerHTML = "*Time is Invalid";
                         inputField.style.backgroundColor = '#ff8080';
                   
                     }

                      return isValid;
                 }

                 function validateHhMm1(inputField) {
                 var isValid = /^([0-9]|0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$/.test(inputField.value);

                     if (isValid) {   
                          //document.getElementById("result2").innerHTML = "";
                        inputField.style.backgroundColor = '#ffffff';
                     } else {
                           //document.getElementById("result2").innerHTML = "*Time is Invalid";
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
                 </asp:DropDownList>
                 <br />
          </div>
        <div class="row">
            <div class="table-responsive">
			<table id="Table1" class="table" >

                <tr>
					<td colspan="11"><FONT size="3"><strong>Draw Furnace Details</strong><hr class="prettyline" /></FONT>
					</td>
				</tr>
                <tr>
                    <td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ErrorMessage="Please Enter Date" ControlToValidate="txtNF_date"></asp:RequiredFieldValidator></td>
              <td colspan="9"><asp:label id="Message" runat="server" ForeColor="Red"></asp:label></td>
                    
                    </tr>
                    <tr>
                        <td>Date<span class="glyphicon-asterisk"></span></td>
					<td>:</td>
					<td><asp:textbox id="txtNF_date" onkeypress="return isNumber1(event,this)" placeholder="dd/mm/yyyy" MaxLength="10" CssClass="form-control" AutoPostBack="true"  runat="server"></asp:textbox></td>
                         
               <%--  <td>Mode</td>
					<td>:</td>
					<td>
						<asp:Label id="lblMode" runat="server" Font-Bold="True"></asp:Label></td>--%>
               </tr>
                    <tr>

			
					<td>Shift<span class="glyphicon-asterisk"></span></td>
					<td>:</td>
					<td><asp:dropdownlist id="cboShift" runat="server" CssClass="form-control ll" AutoPostBack="true" >
                            <asp:ListItem Value="select">select</asp:ListItem>
							<asp:ListItem Value="A">A</asp:ListItem>
							<asp:ListItem Value="B">B</asp:ListItem>
							<asp:ListItem Value="C">C</asp:ListItem>
						</asp:dropdownlist></td>
                  	<td>SIC</td>
                    <td>:</td>
                    <td>
                        <asp:TextBox ID="txt_sic" runat="server" onkeypress="return ValidateAlpha(event)" CssClass="form-control"></asp:TextBox></td>
                    <td> Hanger No </td>
                    <td>:</td>
                    <td>
                        <asp:TextBox ID="hanger_no" runat="server" CssClass="form-control"></asp:TextBox></td>
                   
               </tr>
                <tr>
					<td>Heat Number<span class="glyphicon-asterisk"></span></td>
					<td>:</td>
					<td><asp:textbox id="txtHeat_number" ToolTip="Enter maximum 6 digit number" onkeypress="isInputNumber(event)" MaxLength="6" CssClass="form-control" runat="server" AutoPostBack="True"></asp:textbox></td>
					<td>Wheel Number<span class="glyphicon-asterisk"></span></td>
					<td>:</td>
					<td><asp:textbox id="txtWheel_number" onkeypress="isInputNumber(event)" CssClass="form-control" runat="server" AutoPostBack="True"></asp:textbox></td>
				    <td>Operator Employee Code</td>
					<td>:</td>
					<td><asp:textbox id="txtOperator_name"  CssClass="form-control" runat="server"></asp:textbox></td>
                </tr>
                <tr>
					<td>DF in Time</td>
					<td>:</td>
					<td><asp:textbox id="txtdfin_time" onblur="validateHhMm(this)" placeholder="hh:mm" onkeypress="return isNumber(event,this)" MaxLength="5" CssClass="form-control" runat="server"></asp:textbox></td>
					<%--<td style="color:red"><div id="result1"></div></td>--%>
                    <td>DF out Time</td>
					<td>:</td>
					<td><asp:textbox id="txtdfout_time" onblur="validateHhMm1(this)" placeholder="hh:mm" onkeypress="return isNumber(event,this)" MaxLength="5"  CssClass="form-control" runat="server" AutoPostBack="true"></asp:textbox></td>
                  <%-- <td style="color:red"><div id="result2"></div></td>--%>
                    <td>Cycle Time</td>
                    <td>:</td>
                    <td><asp:textbox id="cycle_time"  CssClass="form-control" runat="server" Enabled="False"></asp:textbox></td>
                    </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td>Hub</td>
                    <td>Rim</td>
                    <td></td>
                    <td></td>
                    <td>Hub</td>
                    <td>Rim</td>
                </tr>
                    <tr>
                    <td>Wheel temp charging</td>
					<td>:</td>
				    <td><asp:textbox id="whltmp_charge_hub" onkeypress="isInputNumber(event)" MaxLength="4"  CssClass="form-control" runat="server"></asp:textbox></td>
                    <td><asp:textbox id="whltmp_charge_rim" onkeypress="isInputNumber(event)" MaxLength="4"  CssClass="form-control" runat="server"></asp:textbox></td>
                    <td>Wheel temp Discharging</td>
					<td>:</td>
					<td><asp:textbox id="whltmp_discharge_hub" onkeypress="isInputNumber(event)" MaxLength="4"  CssClass="form-control" runat="server"></asp:textbox></td>
                    <td><asp:textbox id="whltmp_discharge_rim" onkeypress="isInputNumber(event)" MaxLength="4"  CssClass="form-control" runat="server"></asp:textbox></td>
                   <td>HT Status</td>
                    <td>:</td>
                    <td><asp:DropDownList ID="ddl_htstatus" CssClass="form-control ll" runat="server">
                        <asp:ListItem>PASS</asp:ListItem>
                        <asp:ListItem>RHT</asp:ListItem>
                    </asp:DropDownList></td>
                 </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td>HC1</td>
                    <td>HC2</td>
                    <td>HC3</td>
                </tr>
                <tr>
                    <td>HC Duration</td>
                    <td>:</td>
                    <td><asp:textbox id="hc_duration"  CssClass="form-control" runat="server"></asp:textbox></td>
                    <td>HC Status</td>
                    <td>:</td>
                    <td><asp:dropdownlist id="hc1" runat="server" AutoPostBack="true" CssClass="form-control ll">
							<asp:ListItem Value="ok">Ok</asp:ListItem>
							<asp:ListItem Value="not ok">Not Ok</asp:ListItem>
                           </asp:dropdownlist></td>
                     <td><asp:dropdownlist id="hc2" AutoPostBack="true" runat="server" CssClass="form-control ll">
							<asp:ListItem Value="ok">Ok</asp:ListItem>
							<asp:ListItem Value="not ok">Not Ok</asp:ListItem>
                           </asp:dropdownlist></td>
                     <td><asp:dropdownlist id="hc3" AutoPostBack="true" runat="server" CssClass="form-control ll">
							<asp:ListItem Value="ok">Ok</asp:ListItem>
							<asp:ListItem Value="not ok">Not Ok</asp:ListItem>
                           </asp:dropdownlist></td>

                </tr>
                <tr>
                    <td>Remarks</td>
                    <td>:</td>
                    <td colspan="6"><asp:textbox id="txtremarks" MaxLength="200"  CssClass="form-control" runat="server"></asp:textbox></td>
                </tr>
                <tr>
					<td colspan="14"><asp:button id="btnSave" runat="server" Text="Save" CssClass="button button2"></asp:button>
                        <asp:button id="btnClear" runat="server" Text="Clear" CssClass="button button2" CausesValidation="False"></asp:button>&nbsp;
						<asp:button id="btnExit" runat="server" CssClass="button button2"  Text="Exit" CausesValidation="False"></asp:button></td>
				</tr>
                </table>
                <div class="row">
                    <div class="table-responsive">
                <table id="table7" class="table">
                    <tr>
					<td colspan="9"><asp:datagrid id="grdDrawFurnace" CssClass="table" runat="server" CellPadding="1" CellSpacing="1" AutoGenerateColumns="False" forecolor="Black">
							<AlternatingItemStyle BackColor="White"></AlternatingItemStyle>
							<HeaderStyle ForeColor="White" BackColor="Navy"></HeaderStyle>
							<Columns>
                                <asp:ButtonColumn Text="Select" HeaderText="Select" ItemStyle-ForeColor="Tomato" CommandName="select"></asp:ButtonColumn>
							<%--	<asp:BoundColumn DataField="loading_date" HeaderText="loading date"></asp:BoundColumn>--%>
                                <asp:BoundColumn DataField="loading_date" HeaderText="loading date"></asp:BoundColumn>
								<asp:BoundColumn DataField="shift_code" HeaderText="shift code"></asp:BoundColumn>
                                <asp:BoundColumn DataField="SIC" HeaderText="SIC"></asp:BoundColumn>
								<asp:BoundColumn DataField="operator_code" HeaderText="operator code"></asp:BoundColumn>
								<asp:BoundColumn DataField="heat_number" HeaderText="heat no"></asp:BoundColumn>
                                <asp:BoundColumn DataField="wheel_number" HeaderText="wheel no"></asp:BoundColumn>
								<asp:BoundColumn DataField="hanger_no" HeaderText="hanger no"></asp:BoundColumn>
                                <asp:BoundColumn DataField="df_in_time" HeaderText="Time in"></asp:BoundColumn>
                                <asp:BoundColumn DataField="df_out_time" HeaderText="Time out"></asp:BoundColumn>
                                <asp:BoundColumn DataField="cycle_time" HeaderText="Cycle Time"></asp:BoundColumn>
                                <asp:BoundColumn DataField="whltmp_charging_hub" HeaderText="charging hub"></asp:BoundColumn>
                                <asp:BoundColumn DataField="whltmp_charging_rim" HeaderText="charging rim"></asp:BoundColumn>
                                <asp:BoundColumn DataField="whltmp_discharging_hub" HeaderText="discharging hub"></asp:BoundColumn>
                                <asp:BoundColumn DataField="whltmp_discharging_rim" HeaderText="discharging rim"></asp:BoundColumn>
                                 <asp:BoundColumn DataField="ht_status" HeaderText="ht status"></asp:BoundColumn>
                                <asp:BoundColumn DataField="hc_duration" HeaderText="hc duration"></asp:BoundColumn>
                                <asp:BoundColumn DataField="hc1_status" HeaderText="hc1 status"></asp:BoundColumn>
                                <asp:BoundColumn DataField="hc2_status" HeaderText="hc2 status"></asp:BoundColumn>
                                <asp:BoundColumn DataField="hc3_status" HeaderText="hc3 status"></asp:BoundColumn>
								<asp:BoundColumn DataField="remarks" HeaderText="Remarks"></asp:BoundColumn>
								<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="Update" CancelText="Cancel" EditText="Edit"></asp:EditCommandColumn>
								<asp:ButtonColumn Text="Delete" CommandName="Delete"></asp:ButtonColumn>
							</Columns>
						</asp:datagrid></td>
				</tr>
               </table></div></div>
                <div class="row">
                    <div class="table-responsive">
                <table id="table5" class="table">
                    <tr>
					<td><asp:datagrid id="dg_wheel_normalising" CssClass="table" runat="server" CellPadding="1" CellSpacing="1" AutoGenerateColumns="False" ForeColor="black"  >
						
							<HeaderStyle ForeColor="White" BackColor="DarkMagenta"></HeaderStyle>
							<Columns>
                            
                                <asp:ButtonColumn Text="Select" HeaderText="Select" ItemStyle-ForeColor="DarkGreen" CommandName="select"></asp:ButtonColumn>
                               <asp:BoundColumn DataField="SlNo" HeaderText="Sl no."></asp:BoundColumn>
                                <asp:BoundColumn DataField="HeatNo" HeaderText="Heat Number"></asp:BoundColumn>
                                <asp:BoundColumn DataField="WheelNo" HeaderText="Wheel Number"></asp:BoundColumn>
								<asp:BoundColumn DataField="SIC" HeaderText="SIC"></asp:BoundColumn>
							    <asp:BoundColumn DataField="OP1" HeaderText="OP1"></asp:BoundColumn>
                                <asp:BoundColumn DataField="OP2" HeaderText="OP2"></asp:BoundColumn>
                                <asp:BoundColumn DataField="PedNo" HeaderText="Ped No."></asp:BoundColumn>
                                <asp:BoundColumn DataField="TempRQ" HeaderText="Temp at RQ"></asp:BoundColumn>
                                <asp:BoundColumn DataField="PedPosition" HeaderText="Ped Position"></asp:BoundColumn>
                                <asp:BoundColumn DataField="TimeIn" HeaderText="TimeIn"></asp:BoundColumn>
                                <asp:BoundColumn DataField="TimeOut" HeaderText="TimeOut"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Quencher" HeaderText="Quencher"></asp:BoundColumn>
                                <asp:BoundColumn DataField="remarks" HeaderText="remarks"></asp:BoundColumn>
								<%--<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="Update" CancelText="Cancel" EditText="Edit"></asp:EditCommandColumn>
								<asp:ButtonColumn Text="Delete" CommandName="Delete"></asp:ButtonColumn>--%>
							</Columns>
						</asp:datagrid></td>
							</tr></table></div></div>
                </div></div>
    </form>
         </div>
         <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
</body>
</html>
