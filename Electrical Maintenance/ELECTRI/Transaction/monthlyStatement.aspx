<%@ Page Language="vb" AutoEventWireup="false" Codebehind="monthlyStatement.aspx.vb" Inherits="WebApplication2.monthlyStatement" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
	<HEAD runat="server">
		<title>Monthly Statement Edit</title>
		    <link rel="stylesheet" type="text/css" href="css/jquery-ui.css">
   <LINK id="mss" href="/wap.css" rel="stylesheet"/>
		<META content="Microsoft Visual Studio.NET 7.0" name="GENERATOR"/>
		<META content="Visual Basic 7.0" name="CODE_LANGUAGE"/>
		<META content="JavaScript" name="vs_defaultClientScript"/>
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
         <meta charset="utf-8"/>
  <meta name="viewport" content="width=device-width, initial-scale=1"/>
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css"/>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.6/umd/popper.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/js/bootstrap.min.js"></script>
         <link type="text/css" rel="stylesheet" href="https://cdn.datatables.net/1.10.9/css/dataTables.bootstrap.min.css" />
    <link type="text/css" rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" />
    <link type="text/css" rel="stylesheet" href="https://cdn.datatables.net/responsive/1.0.7/css/responsive.bootstrap.min.css" />
        <link href="jQuery.datetimepicker.min.css" rel="stylesheet" />
        <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.9/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/responsive/1.0.7/js/dataTables.responsive.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.9/js/dataTables.bootstrap.min.js"></script>
            <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
        <script type="text/javascript" src= "https://ajax.googleapis.com/ajax/libs/jqueryui/1.12.1/jquery-ui.min.js">  </script>
<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
<script type="text/javascript" src="//ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
<script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
<script type="text/javascript" src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
 
     <style type="text/css">
         .ui-datepicker {
    background: #333;
    border: 1px solid #555;
    color: #EEE;
    
}
        </style>	
    	</head>
	<body style="overflow-x:hidden">

      <nav class="mb-1 navbar navbar-expand-sm bg-dark navbar-dark " >
  <a class="navbar-brand p-0" href="#"><img src="../../../NewFolder1/unnamed.png" class="rounded-circle z-depth-0"  height="45"/> </a>
  <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent-333"
    aria-controls="navbarSupportedContent-333" aria-expanded="false" aria-label="Toggle navigation">
    <span class="navbar-toggler-icon"></span>
  </button>
  <div class="collapse navbar-collapse " id="navbarSupportedContent-333">
      <ul class="navbar-nav ml-auto  navbar-center">
          <li class="nav-item" style="font-weight: bold">
             <h1 style="color:white; font-size:30px; margin-left:430px; margin-top:5px">Rail Wheel Plant, Bela</h1> 
       
         </li>
      </ul>
    <ul class="navbar-nav ml-auto  navbar-right">
        <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../../wapframeset.aspx">
          <i class="fab glyphicon glyphicon-home " style="font-size:30px;"></i>
        </a></li>
       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../../logon.aspx">
          <i class="fab glyphicon glyphicon-log-out" style="font-size:30px;"></i>
        </a></li>
    
        <li class="nav-item ">
        <a class="nav-link p-0" href="#">
            <img src="../../../NewFolder1/CRIS-Recruitment.jpg" height="45" style="border-radius:43%"/>
        </a>
      </li>
     </ul>
      
  </div>
</nav>
<!--/.Navbar -->
        <div class="container">

		<FORM id="Form1" method="post" runat="server">
              
            <div class="row table-responsive">

			<TABLE id="Table1" class="table">
				<TR>
					<TD  colSpan="6">MONTHLY STATEMENT</TD>
				</TR>
				<TR>
					<TD  colSpan="6">Mode :<asp:label id="lblMode" runat="server" Width="57px" ForeColor="Blue" Font-Bold="True" Font-Names="Arial" Font-Size="Smaller"></asp:label></TD>
				</TR>
				<TR>
					<TD  colSpan="6" rowSpan="1"><asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></TD>
				</TR>
				<TR>
					<TD  colSpan="6" rowSpan="1">DATE :
						<asp:textbox id="txtDate" runat="server" CssClass="form-control" AutoPostBack="True"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ControlToValidate="txtDate" ErrorMessage="*"></asp:requiredfieldvalidator><%--<asp:rangevalidator id="RangeValidator1" runat="server" ControlToValidate="txtDate" ErrorMessage="*" MinimumValue="1/1/1900" MaximumValue="1/1/9999" Type="Date"></asp:rangevalidator>--%></TD>
				</TR>
				<TR>
					<TD colSpan="6"></TD>
				</TR>
				<TR>
					<TD colSpan="2">NBPDCL Energy Purchase</TD>
					<TD ><asp:textbox id="txtKpctl" runat="server" CssClass="form-control"></asp:textbox></TD>
					<TD colSpan="2" >Dg&nbsp;Energy (Local Generation)</TD>
					<TD><asp:textbox id="txtDG" runat="server" CssClass="form-control"></asp:textbox></TD>
				</TR>
				<TR>
					<TD colSpan="6"><U>Melting Energy</U></TD>
				</TR>
				<TR>
					<TD>Furnace I</TD>
					<TD ><asp:textbox id="txtfurA" runat="server" CssClass="form-control"></asp:textbox></TD>
					<TD >Furnace II</TD>
					<TD><asp:textbox id="txtfurB" runat="server" CssClass="form-control"></asp:textbox></TD>
					<TD >Furnace III</TD>
					<TD><asp:textbox id="txtfurC" runat="server" CssClass="form-control"></asp:textbox></TD>
				</TR>
				<%--<TR>
					<TD colSpan="2">Plant Cooling System</TD>
					<TD ><asp:textbox id="txtCool" runat="server" CssClass="form-control"></asp:textbox></TD>
					<TD colSpan="2" ></TD>
					<TD></TD>
				</TR>--%>
				<TR>
					<TD colSpan="2">Melt Shop Sub-Stn(Essen)</TD>
					<TD ><asp:textbox id="txtWheelEss" runat="server" CssClass="form-control"></asp:textbox></TD>
					<TD colSpan="2" >Melt Shop Sub-Stn (N-Essen)</TD>
					<TD><asp:textbox id="txtWheelNEss" runat="server" CssClass="form-control"></asp:textbox></TD>
				</TR>
				<TR>
					<TD colSpan="2">TUBE PREHEAT Ovens</TD>
					<TD ><asp:textbox id="txtHold" runat="server" CssClass="form-control"></asp:textbox></TD>
					<TD colSpan="2" >Moulding Pre-Heat Oven</TD>
					<TD><asp:textbox id="txtPreHeat" runat="server" CssClass="form-control"></asp:textbox></TD>
				</TR>
				<TR>
					<TD colSpan="2">Fume Extraction</TD>
					<TD ><asp:textbox id="txtExtract" runat="server" CssClass="form-control"></asp:textbox></TD>
					<TD colSpan="2" >Compressor Substation</TD>
					<TD><asp:textbox id="txtCompress" runat="server" CssClass="form-control"></asp:textbox></TD>
				</TR>
                	<TR>
					<TD colSpan="6"><U>Remaining Energy Points</U></TD>
				</TR>
              
				<%--<TR>
					<TD colSpan="2">Assembly SubStation</TD>
					<TD ><asp:textbox id="txtAssembly" runat="server" CssClass="form-control"></asp:textbox></TD>
					<TD  colSpan="2"></TD>
					<TD></TD>
				</TR>--%>
				<TR>
					<%--<TD colSpan="2">AxleShop(Essential)</TD>
					<TD ><asp:textbox id="txtAEssen" runat="server" CssClass="form-control"></asp:textbox></TD>--%>
			<%--		<TD colSpan="2" >AxleShop(Non-Essential)</TD>
					<TD><asp:textbox id="txtANEssen" runat="server" CssClass="form-control"></asp:textbox></TD>--%>
                    <TD colSpan="2" >Remainig Shops</TD>
					<TD><asp:textbox id="txtANEssen" runat="server" CssClass="form-control"></asp:textbox></TD>
				</TR>
				<%--<TR>
					<TD colSpan="2">G.F.M. SubStation</TD>
					<TD ><asp:textbox id="txtForge" runat="server" CssClass="form-control"></asp:textbox></TD>
					<TD colSpan="2" >&nbsp;Canteen Sub-Station</TD>
					<TD><asp:textbox id="txtCanteen" runat="server" CssClass="form-control"></asp:textbox></TD>
				</TR>--%>
				<TR>
					<TD colSpan="2">Colony(1&amp;2)</TD>
					<TD ><asp:textbox id="txtColony" runat="server" CssClass="form-control"></asp:textbox></TD>
					<TD colSpan="2">Colony(3&amp;4)</TD>
					<TD ><asp:textbox id="txtColony1" runat="server" CssClass="form-control"></asp:textbox></TD>
					
                    <TD colSpan="2" >Admn. Bldg. </TD>
					<TD><asp:textbox id="txtAdmin" runat="server" CssClass="form-control"></asp:textbox></TD>
				</TR>
				<TR>
					<%--<TD colSpan="2">EMMS Sub-Stn &amp; Dcos
					</TD>
					<TD >
						<asp:textbox id="txtEmms" runat="server" CssClass="form-control"></asp:textbox></TD>--%>
					<%--<TD colSpan="2" ">LOP</TD>
					<TD>
						<asp:textbox id="txtLOP" runat="server" CssClass="form-control"></asp:textbox></TD>--%>
				</TR>
				<%--<TR>
					<TD colSpan="2">RWF Meter</TD>
					<TD >
						<asp:textbox id="txtrwfgen" runat="server" CssClass="form-control"></asp:textbox></TD>
					<TD  colSpan="2"></TD>
					<TD></TD>
				</TR>--%>
				<TR>
					<TD colSpan="2">NBPDCL + Dg Energy</TD>
					<TD >
						<asp:Label id="lblKp_Dg" runat="server" Width="116px">0</asp:Label></TD>
					<TD  colSpan="2">Total Energy</TD>
					<TD>
						<asp:Label id="lblTotalEnergy" runat="server" Width="116px">0</asp:Label></TD>
				</TR>
				<TR>
					<%--<TD colSpan="2">&nbsp;</TD>
					<TD ></TD>--%>
					<TD  colSpan="2">Total Steel Scrap Melted</TD>
					<TD>
						<asp:textbox id="txtTotal_Steel_Scrap" runat="server" CssClass="form-control"></asp:textbox></TD>
				</TR>
                <TR>
                    <TD  colSpan="2">PCS</TD>
					<TD>
						<asp:textbox id="txtPCS" runat="server" CssClass="form-control"></asp:textbox></TD>
                </TR>
                <TR>
                    <TD  colSpan="2">Pump</TD>
					<TD>
						<asp:textbox id="txtpump" runat="server" CssClass="form-control"></asp:textbox></TD>
                </TR>
                  <TR>
                    <TD  colSpan="2">Stn Aux</TD>
					<TD>
						<asp:textbox id="txtstn_aux" runat="server" CssClass="form-control"></asp:textbox></TD>
                </TR>
				<TR>
					<TD colSpan="2">Difference in Energy</TD>
					<TD >
						<asp:Label id="lblDiff" runat="server" Width="116px">0</asp:Label></TD>
					</TR>
				<TR>
                    <TD  colSpan="2">
						<asp:button id="btnCalculateEnergy" runat="server" Font-Size="Smaller" Font-Names="Arial" CssClass="button button2" BorderStyle="Groove" Text="Calculate Energy"></asp:button></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD colSpan="6" >
                        	</TD>
				</TR>
				<%--<TR>
					<TD  colSpan="6">
						<asp:button id="Button1" runat="server" Font-Size="Smaller" Font-Names="Arial" CssClass="button button2" Text="Save" BorderStyle="Groove"></asp:button>
						<asp:button id="Button2" runat="server" Font-Size="Smaller" Font-Names="Arial" CssClass="button button2" Text="Clear" BorderStyle="Groove"></asp:button>
						<asp:button id="Button3" runat="server" Font-Size="Smaller" Font-Names="Arial" CssClass="button button2" Text="Exit" BorderStyle="Groove" CausesValidation="False"></asp:button></TD>
				</TR>--%>
			</TABLE>

                        <TABLE id="Table2" class="table">
							<TR>
								<TD>CODE</TD>
								<TD>AF-I</TD>
								<TD>AF-II</TD>
								<TD>AF-III</TD>
							</TR>
							<TR>
								<TD>A</TD>
								<TD>
									<asp:textbox id="txtaa" runat="server" CssClass="form-control">0</asp:textbox></TD>
								<TD>
									<asp:textbox id="txtab" runat="server" CssClass="form-control">0</asp:textbox></TD>
								<TD>
									<asp:textbox id="txtac" runat="server" CssClass="form-control">0</asp:textbox></TD>
							</TR>
							<TR>
								<TD>B</TD>
								<TD>
									<asp:textbox id="txtba" runat="server" CssClass="form-control">0</asp:textbox></TD>
								<TD>
									<asp:textbox id="txtbb" runat="server" CssClass="form-control">0</asp:textbox></TD>
								<TD>
									<asp:textbox id="txtbc" runat="server" CssClass="form-control">0</asp:textbox></TD>
							</TR>
							<TR>
								<TD>C</TD>
								<TD>
									<asp:textbox id="txtca" runat="server" CssClass="form-control">0</asp:textbox></TD>
								<TD>
									<asp:textbox id="txtcb" runat="server" CssClass="form-control">0</asp:textbox></TD>
								<TD>
									<asp:textbox id="txtcc" runat="server" CssClass="form-control">0</asp:textbox></TD>
							</TR>
							<TR>
								<TD>D</TD>
								<TD>
									<asp:textbox id="txtda" runat="server" CssClass="form-control">0</asp:textbox></TD>
								<TD>
									<asp:textbox id="txtdb" runat="server" CssClass="form-control">0</asp:textbox></TD>
								<TD>
									<asp:textbox id="txtdc" runat="server" CssClass="form-control">0</asp:textbox></TD>
							</TR>
							<TR>
								<TD>E</TD>
								<TD>
									<asp:TextBox id="txtea" runat="server" CssClass="form-control">0</asp:TextBox></TD>
								<TD>
									<asp:TextBox id="txteb" runat="server" CssClass="form-control">0</asp:TextBox></TD>
								<TD>
									<asp:TextBox id="txtec" runat="server" CssClass="form-control">0</asp:TextBox></TD>
							</TR>
							<TR>
								<TD>TOTAL</TD>
								<TD>
									<asp:Label id="lblTotalA" runat="server" CssClass="form-control">0</asp:Label></TD>
								<TD>
									<asp:Label id="lblTotalB" runat="server" CssClass="form-control">0</asp:Label></TD>
								<TD>
									<asp:Label id="lblTotalC" runat="server" CssClass="form-control">0</asp:Label></TD>
							</TR>
							<TR>
								<TD  colSpan="4">TOTAL NO. OF HEATS
									<asp:Label id="lblTotalABC" runat="server" Width="116px">0</asp:Label></TD>
							</TR>
							<TR>
								<TD  colSpan="4">
									<asp:button id="txtCalculateHeat" runat="server" Font-Size="Smaller" Font-Names="Arial" CssClass="button button2" BorderStyle="Groove" Text="Calculate Heats"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="center" align="middle" width="100%" colSpan="6">
						<asp:button id="btnSave" runat="server" Font-Size="Smaller" Font-Names="Arial" Width="71px" Height="24px" Text="Save" BorderStyle="Groove"></asp:button>
						<asp:button id="btnCancel" runat="server" Font-Size="Smaller" Font-Names="Arial" Width="71px" Height="24px" Text="Clear" BorderStyle="Groove"></asp:button>
						<asp:button id="btnExit" runat="server" Font-Size="Smaller" Font-Names="Arial" Width="71px" Height="24px" Text="Exit" BorderStyle="Groove" CausesValidation="False"></asp:button></TD>
				</TR>
			</TABLE>
		</div></form></div>
         <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>
