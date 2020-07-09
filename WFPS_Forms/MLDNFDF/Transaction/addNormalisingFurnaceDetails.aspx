<%@ Page Language="vb" AutoEventWireup="false" Codebehind="addNormalisingFurnaceDetails.aspx.vb" Inherits="WebApplication2.addNormalisingFurnaceDetails" %>
<!DOCTYPE HTML PUBLIC >
<html>
	<head runat="server">
		<title>addNormalisingFurnaceDetails</title>
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

              function isNumber1(evt, element) {

                    var charCode = (evt.which) ? evt.which : event.keyCode

                      if (
                           (charCode != 45 ) && (charCode != 47 ) &&     // 
                           (charCode < 48 || charCode > 57))
                      return false;

                  return true;
            } 

         
                function isInputNumber(evt) {

                    var ch = String.fromCharCode(evt.which);
                    if (!(/[0-9]/.test(ch))) {
                        evt.preventDefault();
                    }

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

              function isNumber(evt, element) {

                    var charCode = (evt.which) ? evt.which : event.keyCode

                      if (
                           (charCode != 58 || $(element).val().indexOf(':') != -1) &&      // “:” CHECK COLON, AND ONLY ONE.
                           (charCode < 48 || charCode > 57))
                      return false;

                  return true;
                }    

                 function validateHhMm1(inputField) {
                 var isValid = /^([0-9]|0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$/.test(inputField.value);

                     if (isValid) {   
                          document.getElementById("result2").innerHTML = "";
                        inputField.style.backgroundColor = '#ffffff';
                     } else {
                           document.getElementById("result2").innerHTML = "*Time is Invalid";
                       inputField.style.backgroundColor = '#ff8080';
        }

        return isValid;
    }
              
        </script>
        <div class="container">

			<form id="Form1" method="post" runat="server">
             
	 <div class="row">
            <div class="table-responsive">
			<table id="Table1" class="table" >
				<tr>
					<td colspan="15"><FONT size="4"><strong>Normalizing Furnace</strong><hr class="prettyline" /></FONT>
					</td>
				</tr>
				<tr>
					<td colspan="9"><asp:label id="Message" runat="server" ForeColor="Red"></asp:label></td>
              	</tr>
                <tr>
                    <%-- <td colspan="3"><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter Date" ForeColor="Red" ControlToValidate="txtNF_date"></asp:RequiredFieldValidator></td>--%>
                </tr>
                <tr>
                <td><asp:Label id="lbl_srbit" CssClass="form-control"  runat="server" visible="false"></asp:Label></td>
                    <td>
                          <asp:Label id="lbl_wheelsrno" runat="server" Visible="false"></asp:Label>
					</td>
					</tr>
				<tr>					<td>Date<span class="glyphicon-asterisk"></span></td>
					<td>:</td>
					<td><asp:textbox id="txtNF_date" CssClass="form-control" onkeypress="return isNumber1(event,this)"  placeholder="dd/mm/yyyy" MaxLength="10" runat="server" AutoPostBack="true" ></asp:textbox></td>
					<td>Shift<span class="glyphicon-asterisk"></span></td>
					<td>:</td>
					<td><asp:dropdownlist id="cboShift" runat="server" CssClass="form-control ll" AutoPostBack="true">
                            <asp:ListItem Value="select">select</asp:ListItem>
							<asp:ListItem Value="A">A</asp:ListItem>
							<asp:ListItem Value="B">B</asp:ListItem>
							<asp:ListItem Value="C">C</asp:ListItem>
						</asp:dropdownlist></td>
                    <td>SIC</td>
					<td>:</td>
					<td><asp:textbox id="txt_sic" onkeypress="return ValidateAlpha(event)"  CssClass="form-control" runat="server"></asp:textbox></td>
					<%--<td>Mode</td>
					<td>:</td>
					<td>
						<asp:Label id="lblMode" runat="server" Font-Bold="True"></asp:Label></td>--%>
				</tr>
				<tr>
					<td>Heat Number<span class="glyphicon-asterisk"></span></td>
					<td>:</td>
					<td><asp:textbox id="txtHeat_number" ToolTip="Enter maximum 6 digit number" onkeypress="isInputNumber(event)" MaxLength="6" CssClass="form-control" runat="server" AutoPostBack="True"></asp:textbox></td>
					<td>Wheel Number<span class="glyphicon-asterisk"></span></td>
					<td>:</td>
					<td><asp:textbox id="txtWheel_number"  CssClass="form-control" runat="server" AutoPostBack="True" ></asp:textbox></td>
                    <td>Operator Employee Code</td>
					<td>:</td>
					<td><asp:textbox id="txtOperator_name"  CssClass="form-control" runat="server"></asp:textbox></td>
					<td></td>
					<td></td>
					<td></td>
				</tr>
                </table>
                <table id="Table2" class="table" >
				<tr>
					<td colspan="15"><u>Enter The Wheel Details:</u></td>
				</tr>
				<tr>
					
					<td>Pedestral Number</td>
					<td>:</td>
					<td>
                        <asp:DropDownList ID="ddl_pedestral_number" CssClass="form-control ll" runat="server">
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                            <asp:ListItem>7</asp:ListItem>
                            <asp:ListItem>8</asp:ListItem>
                            <asp:ListItem>9</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>11</asp:ListItem>
                            <asp:ListItem>12</asp:ListItem>
                            <asp:ListItem>13</asp:ListItem>
                            <asp:ListItem>14</asp:ListItem>
                            <asp:ListItem>15</asp:ListItem>
                            <asp:ListItem>16</asp:ListItem>
                            <asp:ListItem>17</asp:ListItem>
                            <asp:ListItem>18</asp:ListItem>
                            <asp:ListItem>19</asp:ListItem>
                            <asp:ListItem>20</asp:ListItem>
                            <asp:ListItem>21</asp:ListItem>
                            <asp:ListItem>22</asp:ListItem>
                            <asp:ListItem>23</asp:ListItem>
                            <asp:ListItem>24</asp:ListItem>
                            <asp:ListItem>25</asp:ListItem>
                            <asp:ListItem>26</asp:ListItem>
                            <asp:ListItem>27</asp:ListItem>
                            <asp:ListItem>28</asp:ListItem>
                            <asp:ListItem>29</asp:ListItem>
                            <asp:ListItem>30</asp:ListItem>
                            <asp:ListItem>31</asp:ListItem>
                            <asp:ListItem>32</asp:ListItem>
                            <asp:ListItem>33</asp:ListItem>
                            <asp:ListItem>34</asp:ListItem>
                            <asp:ListItem>35</asp:ListItem>
                            <asp:ListItem>36</asp:ListItem>
                            <asp:ListItem>37</asp:ListItem>
                            <asp:ListItem>38</asp:ListItem>
                            <asp:ListItem>39</asp:ListItem>
                            <asp:ListItem>40</asp:ListItem>
                            <asp:ListItem>41</asp:ListItem>
                            <asp:ListItem>42</asp:ListItem>
                            <asp:ListItem>43</asp:ListItem>
                            <asp:ListItem>44</asp:ListItem>
                            <asp:ListItem>45</asp:ListItem>
                            <asp:ListItem>46</asp:ListItem>
                            <asp:ListItem>47</asp:ListItem>
                            <asp:ListItem>48</asp:ListItem>
                             </asp:DropDownList><%--<asp:textbox id="txtPedestral_number"  CssClass="form-control" runat="server"></asp:textbox>--%></td>
					<td>Time In</td>
					<td>:</td>
					<td><asp:textbox id="txtTime_in"  onblur="validateHhMm(this)" MaxLength="5" onkeypress="return isNumber(event,this)" placeholder="hh:mm"  CssClass="form-control" runat="server"></asp:textbox></td>
                   <td style="color:red"><div id="result1"></div></td>
                    <td>Time Out</td>
					<td>:</td>
					<td><asp:textbox id="txtTime_out" onblur="validateHhMm1(this)" MaxLength="5" onkeypress="return isNumber(event,this)" placeholder="hh:mm"   CssClass="form-control" runat="server"  AutoPostBack="true"></asp:textbox></td>
				    <td style="color:red"><div id="result2"></div></td>
                </tr>
				<tr>
                    
                    <td>Wheel out Temp</td>
                    <td>:</td>
                    <td><asp:TextBox ID="txtwhlouttemp_aft_nf"  CssClass="form-control" onkeypress="isInputNumber(event)" MaxLength="4" runat="server"></asp:TextBox></td>
					<td>Quencher Number</td>
					<td>:</td>
					<td>
                        <asp:DropDownList ID="ddl_quencher_number" CssClass="form-control ll"  runat="server">
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                            <asp:ListItem>Bypass</asp:ListItem>
                        </asp:DropDownList><%--<asp:textbox id="txtQuencher_number"  CssClass="form-control" runat="server"></asp:textbox>--%></td>
                    <td>Wheel Temp RQ (in)</td>
                    <td>:</td>
                    <td><asp:TextBox ID="txtwhltmp_at_rq"  CssClass="form-control" onkeypress="isInputNumber(event)" MaxLength="4" runat="server"></asp:TextBox></td>
					<td>Offload Code</td>
					<td>:</td>
					<td>
                        <asp:DropDownList ID="offloadcodelist" runat="server"  CssClass="form-control ll">
                            <asp:ListItem>wheel temp low</asp:ListItem>
                            <asp:ListItem>Not quenching</asp:ListItem>
                            <asp:ListItem>Not into DF</asp:ListItem>
                            <asp:ListItem>Improper quenching</asp:ListItem>
                            <asp:ListItem>examination hold</asp:ListItem>
                        </asp:DropDownList></td>
				</tr>
                <tr>
                    <td>Cycle Time</td>
                    <td>:</td>
                    <td colspan="2"><asp:TextBox ID="txtcycletime"  CssClass="form-control" runat="server" Enabled="False"></asp:TextBox></td>
                </tr>
				<tr>
					<td >Remarks</td>
					<td>:</td>
					<td colspan="8"><asp:textbox id="txtRemarks"  CssClass="form-control" MaxLength="200" runat="server"></asp:textbox></td>
					</tr>
				<tr>
					<td colspan="14"><asp:button id="btnSave" runat="server" Text="Save" CssClass="button button2"></asp:button>
                        <asp:button id="btnClear" runat="server" Text="Clear" CssClass="button button2" CausesValidation="False"></asp:button>&nbsp;
						<asp:button id="btnExit" runat="server" CssClass="button button2"  Text="Exit" CausesValidation="False"></asp:button></td>
				</tr>
				</table>
                <table id="table3" class="table">
                    <tr>
					<td><asp:datagrid id="grdNormalizingFurnace" CssClass="table" runat="server" CellPadding="1" CellSpacing="1" AutoGenerateColumns="False" ForeColor="black"  >
							<%--<AlternatingItemStyle BackColor="White"></AlternatingItemStyle>--%>
							<HeaderStyle ForeColor="White" BackColor="Navy"></HeaderStyle>
							<Columns>
                              <%--  <asp:BoundColumn DataField="loading_date" ReadOnly="True" HeaderText="loading date"></asp:BoundColumn>--%>
                                <asp:ButtonColumn Text="Select" HeaderText="Select" ItemStyle-ForeColor="Tomato" CommandName="select"></asp:ButtonColumn>
                                	<asp:BoundColumn DataField="loading_date" HeaderText="Loading Date"></asp:BoundColumn>
								<asp:BoundColumn DataField="shift_code" HeaderText="shift"></asp:BoundColumn>
								<asp:BoundColumn DataField="SIC" HeaderText="SIC"></asp:BoundColumn>
                                <asp:BoundColumn DataField="heat_number" ReadOnly="True" HeaderText="heat Number"></asp:BoundColumn>
								<asp:BoundColumn DataField="wheel_number" ReadOnly="True" HeaderText="Wheel Number"></asp:BoundColumn>
								<asp:BoundColumn DataField="pedestral_number" HeaderText="Pedestral Number"></asp:BoundColumn>
								<asp:BoundColumn DataField="charge_in_time" HeaderText="Time In"></asp:BoundColumn>
								<asp:BoundColumn DataField="charge_out_time" HeaderText="Time Out"></asp:BoundColumn>
                                <asp:BoundColumn DataField="cycle_time" HeaderText="Cycle Time"></asp:BoundColumn>
                                <asp:BoundColumn DataField="wheelouttmp_aft_nf" HeaderText="Wheel temp"></asp:BoundColumn>
								<asp:BoundColumn DataField="quenched_number" HeaderText="Quencher Number"></asp:BoundColumn>
                                  <asp:BoundColumn DataField="wheeltmp_at_rq" HeaderText="Wheel temp at RQ"></asp:BoundColumn>
								<asp:BoundColumn DataField="offload_code" HeaderText="Offload Code"></asp:BoundColumn>
								<asp:BoundColumn DataField="remarks" HeaderText="Remarks"></asp:BoundColumn>
								<%--<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="Update" CancelText="Cancel" EditText="Edit"></asp:EditCommandColumn>
								<asp:ButtonColumn Text="Delete" CommandName="Delete"></asp:ButtonColumn>--%>
							</Columns>
						</asp:datagrid></td>
							</tr></table>

                 <table id="table5" class="table">
                    <tr>
					<td><asp:datagrid id="dg_wheel_details" CssClass="table" runat="server" CellPadding="1" CellSpacing="1" AutoGenerateColumns="False" ForeColor="black"  >
						
							<HeaderStyle ForeColor="White" BackColor="Navy"></HeaderStyle>
							<Columns>
                            
                                <asp:ButtonColumn Text="Select" HeaderText="Select" ItemStyle-ForeColor="DarkGreen" CommandName="select"></asp:ButtonColumn>
                                 <asp:BoundColumn DataField="pour_order" HeaderText="Sl no."></asp:BoundColumn>
                                <asp:BoundColumn DataField="heat_number" HeaderText="Heat number"></asp:BoundColumn>
								<asp:BoundColumn DataField="wheel_number" HeaderText="Wheel number"></asp:BoundColumn>
								<asp:BoundColumn DataField="description" HeaderText="Wheel type"></asp:BoundColumn>
								<%--<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="Update" CancelText="Cancel" EditText="Edit"></asp:EditCommandColumn>
								<asp:ButtonColumn Text="Delete" CommandName="Delete"></asp:ButtonColumn>--%>
							</Columns>
						</asp:datagrid></td>
							</tr></table>

                </div></div>
		</form>
    </div>
         <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</html>
