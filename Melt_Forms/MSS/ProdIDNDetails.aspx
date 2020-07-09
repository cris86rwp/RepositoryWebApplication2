<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ProdIDNDetails.aspx.vb" Inherits="WebApplication2.ProdIDNDetails" %>
<!DOCTYPE HTML >
<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title>ProdIDNDetails</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0"/>
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0"/>
		<meta name="vs_defaultClientScript" content="JavaScript"/>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5"/>
           <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css"/>
        <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
  <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>

         <link type="text/css" rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" />
       <%-- <link rel="stylesheet" href="../StyleSheet1.css"/>--%>
	</head>
	<body >
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
           
		<form id="Form1" method="post" runat="server">
             <div class="row">
    
                 <%-- <h4>&nbsp&nbsp&nbsp Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px" >
                     
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />--%>
                </div>
			<asp:Panel id="Panel1"  runat="server">
                 <div class ="row">
                <div class="table-responsive">
               <%-- style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px"--%>
				<table id="Table1"  class="table" >
                    <%--cellSpacing="1" cellPadding="1" width="300" --%>
					 <tr>
                       <td style=" color: #FFFFFF;"> <h4>&nbsp&nbsp&nbsp I D N Details &nbsp&nbsp&nbsp </h4><hr class="prettyline" />
						</td>
					 </tr>
				</table>
				<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label>
				<table id="Table2" class="table">
                   <%-- style="WIDTH: 140px; HEIGHT: 32px" cellSpacing="1" cellPadding="1" width="140"--%>
					 <tr>
						 <td style=" color: #FFFFFF;">IDNNo</td>
						 <td>
							<asp:TextBox id="txtIDNNo" runat="server" CssClass="form-control" AutoPostBack="True"></asp:TextBox></td>
						 <td style=" color: #FFFFFF;">ReceivedDate</td>
						 <td>
							<asp:TextBox id="txtRecDate" runat="server" CssClass="form-control"></asp:TextBox></td>
						 <td style=" color: #FFFFFF;">PresentStatus</td>
						 <td>
							<asp:DropDownList id="ddlPresentStatus" CssClass="form-control" runat="server"></asp:DropDownList></td>
					 </tr>
				</table>
				<asp:DataGrid id="DataGrid1" runat="server" CssClass="table">
                    <%--BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4"--%>
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>
				<table id="Table6" class="table">
                    <%--cellSpacing="1" cellPadding="1" width="300"--%>
					 <tr>
						 <td style=" color: #FFFFFF;">AccQty</td>
						 <td>
							<asp:TextBox id="txtAccQty" runat="server" CssClass="form-control" ></asp:TextBox></td>
						 <td style=" color: #FFFFFF;">RejQty</td>
						 <td>
							<asp:TextBox id="txtRejQty" runat="server" CssClass="form-control"></asp:TextBox></td>
						 <td style=" color: #FFFFFF;">ClearedDate</td>
						 <td>
							<asp:TextBox id="txtClearedDate" runat="server" CssClass="form-control"></asp:TextBox></td>
						 <td style=" color: #FFFFFF;">LabNo</td>
						 <td>
							<asp:TextBox id="txtLabNo" runat="server" CssClass="form-control"></asp:TextBox></td>
						 <td style=" color: #FFFFFF;">FileNo</td>
						 <td>
							<asp:TextBox id="txtFileNo" runat="server" CssClass="form-control"></asp:TextBox></td>
					 </tr>
				</table>
				<table id="Table3" class="table" >
                    <%--cellSpacing="1" cellPadding="1" width="300"--%>
				</table>
				<table id="Table4"  class="table">
				</table>
				<table id="Table5" class="table">
					 <tr>
						 <td style=" color: #FFFFFF;">ClearanceCriteria</td>
						 <td>
							<asp:DropDownList id="ddlCriteria" CssClass="form-control ll" runat="server" AutoPostBack="True"></asp:DropDownList></td>
						 <td>
							<asp:Panel id="pnlClear" runat="server">
								<table id="Table8" class="table" >
									 <tr>
										 <td style=" color: #FFFFFF;">ClearedBy</td>
										 <td>
											<asp:RadioButtonList id="rblClearedBy" runat="server"  CssClass="rbl" RepeatLayout="Flow" RepeatDirection="Horizontal">
												<%--Width="381px"--%>
                                                <asp:ListItem Value="SSE/SMS">SSE/SMS</asp:ListItem>
												<asp:ListItem Value="AWM">AWM</asp:ListItem>
												<asp:ListItem Value="WM">WM</asp:ListItem>
												<asp:ListItem Value="Dy.CME Mfg.">Dy.CME Mfg.</asp:ListItem>
											</asp:RadioButtonList></td>
									 </tr>
								</table>
							</asp:Panel></td>
					 </tr>
				</table>
				<table id="Table7" class="table" >
					<tr>
						<td>
							<asp:Label id="lblDate" runat="server" Visible="False"></asp:Label>
							<asp:Button id="btnIDN" CssClass="button button2" runat="server" Text="Save"></asp:Button>
							<asp:Label id="lblQty" runat="server" Visible="False"></asp:Label></td>
					 </tr>
				</table>
				<asp:DataGrid id="DataGrid2" runat="server" CssClass="table" >
                   <%-- BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4"--%>
					<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
					<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
					<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
					<Columns>
						<asp:ButtonColumn Text="Select" CommandName="Select"></asp:ButtonColumn>
					</Columns>
					<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
				</asp:DataGrid>
                     </div>
             </div>
			</asp:Panel>
		</form>
                    </div>
           <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
               
	</body>
</html>
