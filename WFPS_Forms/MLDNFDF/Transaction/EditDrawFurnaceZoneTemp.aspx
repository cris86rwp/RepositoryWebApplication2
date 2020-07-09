<%@ Page Language="vb" AutoEventWireup="false" Codebehind="EditDrawFurnaceZoneTemp.aspx.vb" Inherits="WebApplication2.EditDrawFurnaceZoneTemp" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>addDrawFurnaceZoneTemp</title>
		<LINK href="/wap.css" rel="stylesheet"/>
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
        <script type="text/javascript">
            function isNumber1(evt) {

        var charCode = (evt.which) ? evt.which : event.keyCode

        if (
            (charCode != 47 ) &&    
            (charCode != 45 ) &&     
            (charCode < 48 || charCode > 57))
            return false;

        return true;
            }  
             function isInputNumber(evt) {

                    var ch = String.fromCharCode(evt.which);
        if (!(/[0-9]/.test(ch)))
        {
        evt.preventDefault();
    }

         }
           
            </script>
	</HEAD>
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
         <div class="container">

		<form id="Form1" method="post" runat="server">
            <div class="row">
                  
                  <h4>&nbsp&nbsp&nbspSelect Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px" >
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />
                </div>
             <div class="row">
            <div class="table-responsive">
			<table id="Table1"  class="table">
				<tr>
					<td  colspan="10"><font size="3">Draw Furnace Zone 
							Temperatures</font><hr class="prettyline"/></td>
				</tr>
				<tr>
				<%--	<td>
						<asp:Label id="Label1" runat="server">Mode:</asp:Label></td>--%>
                     <%-- <td>  <asp:RadioButtonList ID="rdo1" runat="server" CssClass="rbl" RepeatDirection="Horizontal" RepeatLayout="Flow" AutoPostBack="True">
                            <asp:ListItem>add</asp:ListItem>
                            <asp:ListItem>edit</asp:ListItem>
                            <asp:ListItem>view</asp:ListItem>
                            <asp:ListItem>delete</asp:ListItem>
                        </asp:RadioButtonList></td>--%>
                     <%--   <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" AutoPostBack="true"></asp:TextBox>--%>
						<%--<td><asp:Label id="lblMode" runat="server" ForeColor="Red"></asp:Label></td>
				 --%>
			 
					<td  colspan="4"><asp:label id="Message" runat="server" ForeColor="Red"></asp:label></td>
		      
                    
                    </tr>
				<tr>
					<td>Date:</td>
					
					<td><asp:textbox id="txtDate" onkeypress="return isNumber1(event)" MaxLength="10" placeholder="dd-mm-yyyy" runat="server" AutoPostBack="True" CssClass="form-control"></asp:textbox>
						<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Date" Display="Dynamic" ControlToValidate="txtDate"></asp:RequiredFieldValidator></td>
					<td>Shift:</td>
				
					<td><asp:dropdownlist id="cboShift" runat="server" CssClass="form-control ll" AutoPostBack="True"><%-- Width="77px" Height="30px"--%>
                        <asp:ListItem Value="select">Select</asp:ListItem>
                        <%--Selected="True"--%>
							<asp:ListItem Value="A">A</asp:ListItem>
							<asp:ListItem Value="B">B</asp:ListItem>
							<asp:ListItem Value="C">C</asp:ListItem>
						</asp:dropdownlist></td>
                    <td>SIC:</td>
                    <td colspan="4"><asp:textbox id="Textbox1"   runat="server" CssClass="form-control"></asp:textbox> </td>
                    <td>
                        Operators Name:
                    </td>
                     <td><asp:textbox id="txtOperator_name" CssClass="form-control" runat="server"></asp:textbox></td>
				</tr>
				<tr>
					<%--<td>Operators Name</td>
					<td>:</td>
					<td><asp:textbox id="txtOperator_name" CssClass="form-control" runat="server"></asp:textbox></td>--%>
                    <td>Time:</td>
                    <td><asp:dropdownlist id="cboTime" runat="server" CssClass="form-control ll">
                          <%-- <asp:ListItem Value="select">Select</asp:ListItem>--%>
                   <%--     Selected="True"--%>
							<asp:ListItem Value="06:15" >06:15</asp:ListItem>
							<asp:ListItem Value="07:15">07:15</asp:ListItem>
							<asp:ListItem Value="08:15">08:15</asp:ListItem>
							<asp:ListItem Value="09:15">09:15</asp:ListItem>
							<asp:ListItem Value="10:15">10:15</asp:ListItem>
							<asp:ListItem Value="11:15">11:15</asp:ListItem>
							<asp:ListItem Value="12:15">12:15</asp:ListItem>
							<asp:ListItem Value="13:15">13:15</asp:ListItem>
							<asp:ListItem Value="14:15">14:15</asp:ListItem>
							<asp:ListItem Value="15:15">15:15</asp:ListItem>
							<asp:ListItem Value="16:15">16:15</asp:ListItem>
							<asp:ListItem Value="17:15">17:15</asp:ListItem>
							<asp:ListItem Value="18:15">18:15</asp:ListItem>
							<asp:ListItem Value="19:15">19:15</asp:ListItem>
							<asp:ListItem Value="20:15">20:15</asp:ListItem>
							<asp:ListItem Value="21:15">21:15</asp:ListItem>
							<asp:ListItem Value="22:15">22:15</asp:ListItem>
							<asp:ListItem Value="23:15">23:15</asp:ListItem>
							<asp:ListItem Value="00:15">00:15</asp:ListItem>
							<asp:ListItem Value="01:15">01:15</asp:ListItem>
							<asp:ListItem Value="02:15">02:15</asp:ListItem>
							<asp:ListItem Value="03:15">03:15</asp:ListItem>
							<asp:ListItem Value="04:15">04:15</asp:ListItem>
							<asp:ListItem Value="05:15">05:15</asp:ListItem>
						</asp:dropdownlist></td>
					<td>LPG Flow Meter reading at 8:15:</td>
					
					<td><asp:textbox id="txtHSD_meter_reading"  onkeypress="isInputNumber(event)" CssClass="form-control" runat="server"></asp:textbox></td>
                 
				</tr>
				<tr>
					<%--<td>Time</td>
					<td>:</td>
					<td><asp:dropdownlist id="cboTime" runat="server" CssClass="form-control ll">
							<asp:ListItem Value="06:15" Selected="True">06:15</asp:ListItem>
							<asp:ListItem Value="07:15">07:15</asp:ListItem>
							<asp:ListItem Value="08:15">08:15</asp:ListItem>
							<asp:ListItem Value="09:15">09:15</asp:ListItem>
							<asp:ListItem Value="10:15">10:15</asp:ListItem>
							<asp:ListItem Value="11:15">11:15</asp:ListItem>
							<asp:ListItem Value="12:15">12:15</asp:ListItem>
							<asp:ListItem Value="13:15">13:15</asp:ListItem>
							<asp:ListItem Value="14:15">14:15</asp:ListItem>
							<asp:ListItem Value="15:15">15:15</asp:ListItem>
							<asp:ListItem Value="16:15">16:15</asp:ListItem>
							<asp:ListItem Value="17:15">17:15</asp:ListItem>
							<asp:ListItem Value="18:15">18:15</asp:ListItem>
							<asp:ListItem Value="19:15">19:15</asp:ListItem>
							<asp:ListItem Value="20:15">20:15</asp:ListItem>
							<asp:ListItem Value="21:15">21:15</asp:ListItem>
							<asp:ListItem Value="22:15">22:15</asp:ListItem>
							<asp:ListItem Value="23:15">23:15</asp:ListItem>
							<asp:ListItem Value="00:15">00:15</asp:ListItem>
							<asp:ListItem Value="01:15">01:15</asp:ListItem>
							<asp:ListItem Value="02:15">02:15</asp:ListItem>
							<asp:ListItem Value="03:15">03:15</asp:ListItem>
							<asp:ListItem Value="04:15">04:15</asp:ListItem>
							<asp:ListItem Value="05:15">05:15</asp:ListItem>
						</asp:dropdownlist></td>--%>
					<%--<td>Zone</td>
					<td></td>--%>
					<%--<td><asp:dropdownlist id="cboZone" CssClass="form-control ll" runat="server">
							<asp:ListItem Value="Z1">Z1</asp:ListItem>
							<asp:ListItem Value="Z2">Z2</asp:ListItem>
							<asp:ListItem Value="Z3">Z3</asp:ListItem>
							<asp:ListItem Value="Z4">Z4</asp:ListItem>
							<asp:ListItem Value="Z5">Z5</asp:ListItem>
							<asp:ListItem Value="Z6">Z6</asp:ListItem>
							<asp:ListItem Value="Z7">Z7</asp:ListItem>
							<asp:ListItem Value="Z8">Z8</asp:ListItem>
							<asp:ListItem></asp:ListItem>
						</asp:dropdownlist></td>--%>
                    
			 </table>
                <table id="Table2"  class="table">
                <tr>
                    <td>
                        <asp:Label ID="Zone1" runat="server" Text="Zone1_Temp:"></asp:Label></td>   
                    <td><asp:TextBox ID="Zone1t"  onkeypress="isInputNumber(event)"  CssClass="form-control" runat="server"></asp:TextBox><asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="EnterTemp. for zone1_temp" Display="Dynamic" ControlToValidate="Zone1t"></asp:RequiredFieldValidator><asp:RangeValidator id="rvtemp" runat="server" ErrorMessage="Enter b/w 0 to 10000" Display="Dynamic" ControlToValidate="Zone1t" MinimumValue="0" MaximumValue="1000" Type="Double"></asp:RangeValidator></td>
                    <td><asp:Label ID="Zone2" runat="server" Text="Zone2_Temp:"></asp:Label></td>
                    
                      <td>     <asp:TextBox ID="Zone2t"  onkeypress="isInputNumber(event)"  CssClass="form-control" runat="server"></asp:TextBox><asp:RequiredFieldValidator id="RequiredFieldValidator9" runat="server" ErrorMessage="EnterTemp. for zone2_temp" Display="Dynamic" ControlToValidate="Zone2t"></asp:RequiredFieldValidator><asp:RangeValidator id="RangeValidator7" runat="server" ErrorMessage="Enter b/w 0 to 1000" Display="Dynamic" ControlToValidate="Zone2t" MinimumValue="0" MaximumValue="1000" Type="Double"></asp:RangeValidator></td>
                    <td><asp:Label ID="Zone3" runat="server" Text="Zone3_Temp:"></asp:Label></td>
                    
                      <td>     <asp:TextBox ID="Zone3t"  onkeypress="isInputNumber(event)"  CssClass="form-control" runat="server"></asp:TextBox><asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ErrorMessage="EnterTemp. for zone3_temp" Display="Dynamic" ControlToValidate="Zone3t"></asp:RequiredFieldValidator><asp:RangeValidator id="RangeValidator1" runat="server" ErrorMessage="Enter b/w 0 to 1000" Display="Dynamic" ControlToValidate="Zone3t" MinimumValue="0" MaximumValue="1000" Type="Double"></asp:RangeValidator></td>
                    <td><asp:Label ID="Zone4" runat="server" Text="Zone4_Temp:"></asp:Label></td>
                   
                     <td>     <asp:TextBox ID="Zone4t"  onkeypress="isInputNumber(event)"  CssClass="form-control" runat="server"></asp:TextBox><asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server" ErrorMessage="EnterTemp. for zone4_temp" Display="Dynamic" ControlToValidate="Zone4t"></asp:RequiredFieldValidator><asp:RangeValidator id="RangeValidator2" runat="server" ErrorMessage="Enter b/w 0 to 1000" Display="Dynamic" ControlToValidate="Zone4t" MinimumValue="0" MaximumValue="1000" Type="Double"></asp:RangeValidator></td>
                      
                    </tr>
              
                <tr>
                    
                     <td><asp:Label ID="Zone5" runat="server" Text="Zone5_Temp:"></asp:Label></td>
                    <td> <asp:TextBox ID="Zone5t"  onkeypress="isInputNumber(event)"  CssClass="form-control" runat="server"></asp:TextBox><asp:RequiredFieldValidator id="RequiredFieldValidator5" runat="server" ErrorMessage="EnterTemp. for zone5_temp" Display="Dynamic" ControlToValidate="Zone5t"></asp:RequiredFieldValidator><asp:RangeValidator id="RangeValidator3" runat="server" ErrorMessage="Enter b/w 0 to 1000" Display="Dynamic" ControlToValidate="Zone5t" MinimumValue="0" MaximumValue="1000" Type="Double"></asp:RangeValidator></td>
                    <td><asp:Label ID="Zone6" runat="server" Text="Zone6_Temp:"></asp:Label></td>
                     <td> <asp:TextBox ID="Zone6t"  onkeypress="isInputNumber(event)"  CssClass="form-control" runat="server"></asp:TextBox><asp:RequiredFieldValidator id="RequiredFieldValidator6" runat="server" ErrorMessage="EnterTemp. for zone6_temp" Display="Dynamic" ControlToValidate="Zone6t"></asp:RequiredFieldValidator><asp:RangeValidator id="RangeValidator4" runat="server" ErrorMessage="Enter b/w 0 to 1000" Display="Dynamic" ControlToValidate="Zone6t" MinimumValue="0" MaximumValue="1000" Type="Double"></asp:RangeValidator></td>
                    <td><asp:Label ID="Zone7" runat="server" Text="Zone7_Temp:"></asp:Label></td>
                     <td><asp:TextBox ID="Zone7t"  onkeypress="isInputNumber(event)"  CssClass="form-control" runat="server"></asp:TextBox><asp:RequiredFieldValidator id="RequiredFieldValidator7" runat="server" ErrorMessage="EnterTemp. for zone7_temp" Display="Dynamic" ControlToValidate="Zone7t"></asp:RequiredFieldValidator><asp:RangeValidator id="RangeValidator5" runat="server" ErrorMessage="Enter b/w 0 to 1000" Display="Dynamic" ControlToValidate="Zone7t" MinimumValue="0" MaximumValue="1000" Type="Double"></asp:RangeValidator></td>
                    <td><asp:Label ID="Zone8" runat="server" Text="Zone8_Temp:"></asp:Label></td>
                     <td><asp:TextBox ID="Zone8t"  onkeypress="isInputNumber(event)"  CssClass="form-control" runat="server"></asp:TextBox><asp:RequiredFieldValidator id="RequiredFieldValidator8" runat="server" ErrorMessage="EnterTemp. for zone8_temp" Display="Dynamic" ControlToValidate="Zone8t"></asp:RequiredFieldValidator><asp:RangeValidator id="RangeValidator6" runat="server" ErrorMessage="Enter b/w 0 to 1000" Display="Dynamic" ControlToValidate="Zone8t" MinimumValue="0" MaximumValue="1000" Type="Double"></asp:RangeValidator></td>
                    </tr>
                
				
				<%--	<td>Temperature</td>
					<td>:</td>--%>
					<%--<td><asp:textbox id="txtTemperature" CssClass="form-control" runat="server"></asp:textbox>
						<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="EnterTemp." Display="Dynamic" ControlToValidate="txtTemperature"></asp:RequiredFieldValidator>
						<asp:RangeValidator id="rvtemp" runat="server" ErrorMessage="Nuemeric Please" Display="Dynamic" ControlToValidate="txtTemperature" MinimumValue="0.0000001" MaximumValue="9999999.9" Type="Double"></asp:RangeValidator></td>--%>
				 <tr>
                     <td></td>
				 </tr>
                    <tr><td></td></tr>
                    <tr>
                    <td>Remarks:</td>
                        <td colspan="5">
<asp:textbox id="txtRemarks" CssClass="form-control" MaxLength="200" runat="server"></asp:textbox>
                        </td>
                        </tr>
                   <%-- <tr>

                   
                        <td>Remarks:</td>
                        <td colspan="5"><asp:textbox id="txtRemarks" CssClass="form-control" MaxLength="200" runat="server"></asp:textbox></td>
                    </tr>--%>
                    </table>
                <table id ="table3" class="table">
               <%-- <tr>
              
					
					<td >Remarks:<asp:textbox id="txtRemarks" CssClass="form-control" MaxLength="200" runat="server"></asp:textbox></td>
                     
				</tr>--%>
				<tr>
					<td  colspan="8"><asp:button id="btnSave" runat="server" CssClass="button button2" Text="Save"></asp:button>&nbsp;<asp:button id="btnClear" runat="server"  Text="Clear" CssClass="button button2" CausesValidation="False"></asp:button>&nbsp;
						<asp:button id="btnExit" runat="server"  Text="Exit" CssClass="button button2" CausesValidation="False"></asp:button></td> <%--Width="71px" Height="24px" Width="71px" Height="24px"--%>
				</tr>
				<tr>
					<td colspan="8"><asp:datagrid id="grdDrawFurnace" runat="server" AutoGenerateColumns="False" BackColor="LightGray" ForeColor="Black">
							<AlternatingItemStyle BackColor="White"></AlternatingItemStyle>
							<HeaderStyle ForeColor="White" BackColor="Navy"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="mytime" ReadOnly="True" HeaderText="DateTime(mm-dd-yyyy)"></asp:BoundColumn>
								<asp:BoundColumn DataField="zone1t" ReadOnly="True" HeaderText="Zone1_Temp"></asp:BoundColumn>
                               <asp:BoundColumn DataField="zone2t" ReadOnly="True" HeaderText="Zone2_Temp"></asp:BoundColumn>
                                <asp:BoundColumn DataField="zone3t" ReadOnly="True" HeaderText="Zone3_Temp"></asp:BoundColumn>
                                	<asp:BoundColumn DataField="zone4t" ReadOnly="True" HeaderText="Zone4_Temp"></asp:BoundColumn>
                              	<asp:BoundColumn DataField="zone5t" ReadOnly="True" HeaderText="Zone5_Temp"></asp:BoundColumn>
                                <asp:BoundColumn DataField="zone6t" ReadOnly="True" HeaderText="Zone6_Temp"></asp:BoundColumn>
                                	<asp:BoundColumn DataField="zone7t" ReadOnly="True" HeaderText="Zone7_Temp"></asp:BoundColumn>
                               <asp:BoundColumn DataField="zone8t" ReadOnly="True" HeaderText="Zone8_Temp"></asp:BoundColumn>
                                
							<%--	<asp:BoundColumn DataField="zone_temperature" HeaderText="Temperature"></asp:BoundColumn>--%>
								<asp:BoundColumn DataField="remarks" HeaderText="Remarks"></asp:BoundColumn>
								<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="Update" CancelText="Cancel" EditText="Edit"></asp:EditCommandColumn>
								<asp:ButtonColumn Text="Delete" CommandName="Delete"></asp:ButtonColumn>
							</Columns>
						</asp:datagrid></td>
                       <td></td>
                    <td></td>
				</tr>
				<tr>
					<td colspan="8"></td>
				</tr>
         
			</table>
                 </div>
                 </div>
       
           
			&nbsp;
		</form>
        </div>
          <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>
