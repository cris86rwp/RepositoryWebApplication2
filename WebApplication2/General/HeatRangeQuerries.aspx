<%@ Page Language="vb" AutoEventWireup="false" Codebehind="HeatRangeQuerries.aspx.vb" Inherits="WebApplication2.HeatRangeQuerries" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Baking station</title>
         <meta charset="utf-8"/>
  <meta name="viewport" content="width=device-width, initial-scale=1"/>
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css"/>
  <script  src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
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

    <link href="../../StyleSheet1.css" rel="stylesheet" />

 
	</head>
	<body >
		<form id="Form1" method="post" runat="server">

            <nav class="mb-1 navbar navbar-expand-sm bg-dark navbar-dark " >
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
         <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../wapframeset.aspx"
             >
          <i class="fab glyphicon glyphicon-home "></i>
        </a></li>
       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../logon.aspx">
          <i class="fab glyphicon glyphicon-log-out"></i>
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
            <div class="row">
                <div class="table-responsive">



			<asp:Panel id="Panel1"  runat="server" >

                  <h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />
                       
				<TABLE id="Table2" class="table">
					<TR>
						<TD>Heat Range Querries</TD>
					</TR>
					<TR>
						<TD>
							<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label></TD>
					</TR>
					<TR>
						<TD>From Heat Number</TD>
						<TD>:
						</TD>
						<TD>
							<asp:textbox id="txtFromHeatNo" runat="server"  BorderStyle="Groove" CssClass="form-control"></asp:textbox>
							<asp:RequiredFieldValidator id="rfvld1" runat="server" ControlToValidate="txtFromHeatNo" Display="Dynamic">*</asp:RequiredFieldValidator></TD>
						<TD>To Heat Number</TD>
						<TD>:
						</TD>
						<TD>
							<asp:textbox id="txtToHeatNo" runat="server" BorderStyle="Groove" CssClass="form-control"></asp:textbox>
							<asp:RequiredFieldValidator id="rfvld2" runat="server" ControlToValidate="txtToHeatNo" Display="Dynamic">*</asp:RequiredFieldValidator></TD>
					</TR>
					<TR>
						<TD>
							<asp:RadioButtonList id="rblQue" runat="server" CssClass="rbl">
								<asp:ListItem Value="1" Selected="True">Heat Position</asp:ListItem>
								<asp:ListItem Value="2">MagOffLoads</asp:ListItem>
								<asp:ListItem Value="11">WFPS Rejections Summary</asp:ListItem>
								<asp:ListItem Value="3">WFPS Rejections Details</asp:ListItem>
								<asp:ListItem Value="4">MR Rejections</asp:ListItem>
								<asp:ListItem Value="5">MagOffloads Process Summary</asp:ListItem>
								<asp:ListItem Value="6">MagOffloads Process Details</asp:ListItem>
								<asp:ListItem Value="7">Foundry Returns</asp:ListItem>
								<asp:ListItem Value="8">RejectionCodewiseMRnCR</asp:ListItem>
								<asp:ListItem Value="9">RejectionCodewiseDetailsMRnCR</asp:ListItem>
								<asp:ListItem Value="10">MR and CR Rejections</asp:ListItem>
								<asp:ListItem Value="12">Cope Life Heat Wise</asp:ListItem>
								<asp:ListItem Value="13">Magna OffLoads</asp:ListItem>
								<asp:ListItem Value="14">Drag Life Heat Wise</asp:ListItem>
								<asp:ListItem Value="15">Stamping Numbers</asp:ListItem>
								<asp:ListItem Value="16">Rejection 51</asp:ListItem>
								<asp:ListItem Value="17">OffLoad 51</asp:ListItem>
								<asp:ListItem Value="33">Rejection 51 Count</asp:ListItem>
								<asp:ListItem Value="18">Rejection 10</asp:ListItem>
								<asp:ListItem Value="19">OffLoad 10</asp:ListItem>
								<asp:ListItem Value="20">Rejection 13</asp:ListItem>
								<asp:ListItem Value="21">OffLoad 13</asp:ListItem>
								<asp:ListItem Value="22">Rejection 15</asp:ListItem>
								<asp:ListItem Value="23">OffLoad 15</asp:ListItem>
								<asp:ListItem Value="24">Rejection 32</asp:ListItem>
								<asp:ListItem Value="25">OffLoad 32</asp:ListItem>
								<asp:ListItem Value="26">Rejection 46</asp:ListItem>
								<asp:ListItem Value="27">OffLoad 46</asp:ListItem>
								<asp:ListItem Value="28">Rejection 56</asp:ListItem>
								<asp:ListItem Value="29">OffLoad 56</asp:ListItem>
								<asp:ListItem Value="30">Rejection 62</asp:ListItem>
								<asp:ListItem Value="31">OffLoad 62</asp:ListItem>
								<asp:ListItem Value="32">MR Offloads</asp:ListItem>
								<asp:ListItem Value="34">HT Wheels</asp:ListItem>
								<asp:ListItem Value="35">Wheels In MR</asp:ListItem>
								<asp:ListItem Value="36">WheelQuerry</asp:ListItem>
								<asp:ListItem Value="37">Wheel Despatch</asp:ListItem>
								<asp:ListItem Value="38">Pour Time to Test Time</asp:ListItem>
							</asp:RadioButtonList></TD>
					</TR>
					<TR>
						<TD>XC Type :
							<asp:TextBox id="txtXC" runat="server" CssClass="form-control"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD>
							<asp:button id="BtnShow" runat="server"  BorderStyle="Groove" Text="Show Details" CssClass="button button2"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:button id="btnExportDetails" runat="server" Text="Export Details" CssClass="button button2"></asp:button></TD>
					</TR>
				</TABLE>
				<asp:DataGrid id="DataGrid1" runat="server"  cssclass="form-control"  BorderColor="#CC9966">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>
			</asp:Panel>&nbsp;
                        </form>
                    </div>
                </div>
            </div>
     <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
		
</HTML>
