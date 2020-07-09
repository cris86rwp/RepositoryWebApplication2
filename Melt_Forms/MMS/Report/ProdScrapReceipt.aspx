<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ProdScrapReceipt.aspx.vb" Inherits="WebApplication2.ProdScrapReceipt" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
	<head runat="server">
		<title>ProdScrapReceipt</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0"/>
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0"/>
		<meta name="vs_defaultClientScript" content="JavaScript"/>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5"/>
         <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css"/>
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.6/umd/popper.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/js/bootstrap.min.js"></script>
          <link type="text/css" rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" />
        <link rel="stylesheet" href="../../../StyleSheet1.css"/>
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
         <div class="container">
       
                           
		<form id="Form1" method="post" runat="server">
			<asp:Panel id="Panel1"   runat="server">
                 <div class="row">
            <div class="table-responsive">
                <%--style="Z-INDEX: 103; LEFT: 8px; POSITION: absolute; TOP: 8px"--%>
				<table id="Table8" class="table"   > <%--cellSpacing="1" cellPadding="1" width="300"--%>
				</table>
							<table id="Table1" class="table"> <%--style="WIDTH: 343px; HEIGHT: 18px" cellSpacing="1" cellPadding="1" width="343"--%>
								<tr>
									<td>
										<asp:label id="lblConsignee" runat="server" Font-Bold="True"></asp:label>&nbsp;<strong>Production 
											Scrap&nbsp;Details</strong><hr class="prettyline"/></td>
								</tr>
								<tr>
									<td>
										<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></td>
								</tr>
							</table>
							<table id="Table3" class="table"  > <%--style="WIDTH: 557px; HEIGHT: 28px" cellSpacing="1" cellPadding="1" width="557"--%>
								<tr>
									<td>
										<asp:RadioButtonList id="rblType" runat="server" CssClass="rbl" RepeatDirection="Horizontal" RepeatLayout="Flow" AutoPostBack="True">
											<asp:ListItem Value="1" Selected="True">Receipts</asp:ListItem>
											<asp:ListItem Value="2">Returned Stores</asp:ListItem>
										</asp:RadioButtonList></td>
								</tr>
								<tr>
									<td>
										<asp:RadioButtonList id="rblScrap" runat="server"  CssClass="rbl" RepeatDirection="Horizontal" RepeatLayout="Flow" AutoPostBack="True"></asp:RadioButtonList></td>
								</tr>
							</table>
							<table id="Table2" class="table"  > <%--style="WIDTH: 202px; HEIGHT: 61px" cellSpacing="1" cellPadding="1" width="202"--%>
								<tr>
									<td>
										<asp:Label id="lblTypeDate" runat="server"></asp:Label>Date</td>
									<td>:</td>
									<td>
										<asp:textbox id="txtReceiptDate" runat="server" AutoPostBack="True"  CssClass="form-control"></asp:textbox></td>
								</tr>
								<tr>
									<td>
										<asp:Label id="lblTypeNo" runat="server"></asp:Label>No</td>
									<td>:</td>
									<td>
										<asp:textbox id="txtWagonNo" runat="server" AutoPostBack="True"  CssClass="form-control"></asp:textbox></td>
								</tr>
								<tr>
									<td>
										<asp:Label id="lblTypeQty" runat="server"></asp:Label>Qty</td>
									<td>:</td>
									<td>
										<asp:textbox id="txtReceiptQty" runat="server"  CssClass="form-control"></asp:textbox></td>
								</tr>
							</table>
							<table id="Table4" class="table"> <%--cellSpacing="1" cellPadding="1" width="300"--%>
								<tr>
									<td>Remarks</td>
									<td>:</td>
									<td>
										<asp:TextBox id="txtRemarks" runat="server" CssClass="form-control" ></asp:TextBox></td>
								</tr>
								<tr>
									<td align="center" colspan="3">
										<asp:Button id="btnSave" runat="server" Text="Save" class="button button2"></asp:Button>
										<asp:Label id="lblSl" runat="server"></asp:Label></td>
								</tr>
							</table>
						
							<asp:DataGrid id="DataGrid2" runat="server" CssClass="table">
								<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
								<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
								<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
								<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
							</asp:DataGrid>
                         
				<asp:DataGrid id="DataGrid1" runat="server"  CssClass="table">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<Columns>
						<asp:ButtonColumn Text="Select" CommandName="Select"></asp:ButtonColumn>
						<asp:ButtonColumn Text="Delete" CommandName="Delete"></asp:ButtonColumn>
					</Columns>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>
                </div></div>
			</asp:Panel>&nbsp;
		</form>
	    <p>
            &nbsp;</p></div>
	</body>
</html>
