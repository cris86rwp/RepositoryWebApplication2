<%@ Page Language="vb" AutoEventWireup="false" Codebehind="PTMSCriticalItemListAdd.aspx.vb" Inherits="WebApplication2.PTMSCriticalItemListAdd" smartNavigation="True" %>
<!DOCTYPE HTML >
<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title>PTMSCriticalItemListEdit</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR"/>
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
         <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css"/>
  <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.6/umd/popper.min.js"></script>
  <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/js/bootstrap.min.js"></script>

        
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
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}">
          <i class="fab glyphicon glyphicon-home "></i>
        </a></li>
       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}">
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
			<table id="Table3" class="table">
				</table>
						<table id="Table2" class="table">
							<tr>
								<td  colspan="6"><asp:label id="lblConsignee" runat="server"></asp:label><strong>
										&nbsp;Critical&nbsp;List - Add</strong><hr class="prettyline"/></td>
							</tr>
							<tr>
								<td>Message:
									<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></td>
							</tr>
							<tr>
								<td>PL Number</td>
								<td>:</td>
								<td colspan="4"><asp:dropdownlist id="ddlPlNumber" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:dropdownlist>&nbsp;</td>
							</tr>
						</table>
					<asp:datagrid id="dgBOM" runat="server"  CssClass="table">
							<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
							<AlternatingItemStyle BackColor="Gainsboro"></AlternatingItemStyle>
							<ItemStyle ForeColor="Black" BackColor="#EEEEEE"></ItemStyle>
							<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#000084"></HeaderStyle>
							<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
							<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
						</asp:datagrid>
						<table id="Table1" class="table">
							<tr>
								<td>Number</td>
								<td>:</td>
								<td><asp:textbox id="txtNum" runat="server" CssClass="form-control"></asp:textbox></td>
								<td>Date</td>
								<td>:</td>
								<td><asp:textbox id="txtDt" runat="server" CssClass="form-control" ></asp:textbox></td>
								<td>Qty</td>
								<td>:</td>
								<td><asp:textbox id="txtQty" runat="server" CssClass="form-control"></asp:textbox></td>
							</tr>
							<tr>
								<td>Supplier</td>
								<td>:</td>
								<td colspan="4"><asp:textbox id="txtSup" runat="server" CssClass="form-control"></asp:textbox>&nbsp;</td><td>DD</td><td>:</td>
									<td colspan="3"><asp:textbox id="txtDD" runat="server" CssClass="form-control"></asp:textbox></td>
							</tr>
							<tr>
								<td>RecdQty</td>
								<td>:</td>
								<td><asp:textbox id="txtRecdQty" runat="server" CssClass="form-control"></asp:textbox></td>
								<td>QtyUT</td>
								<td>:</td>
								<td><asp:textbox id="txtQtyUT" runat="server" CssClass="form-control"></asp:textbox></td>
								<td>QtyDue</td>
								<td>:</td>
								<td><asp:textbox id="txtQtyDue" runat="server" CssClass="form-control"></asp:textbox></td>
							</tr>
							<tr>
								<td>Remarks</td>
								<td>:</td>
								<td colspan="7"><asp:textbox id="txtRemarks" runat="server" CssClass="form-control"></asp:textbox></td>
							</tr>
							<tr>
								<td  align="center" colspan="9"><asp:button id="btnSave" CssClass="button button2" runat="server" Text="Save"></asp:button><asp:label id="lblType" runat="server"></asp:label><asp:label id="lblRecID" runat="server" Visible="False"></asp:label></td>
							</tr>
							<tr>
								<td  align="left" colspan="9">Saved&nbsp; Data for report :</td>
							</tr>
						</table>
						<asp:datagrid id="dgSavedData" runat="server" CssClass="table">
							<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#669999"></SelectedItemStyle>
							<ItemStyle ForeColor="#000066"></ItemStyle>
							<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#006699"></HeaderStyle>
							<FooterStyle ForeColor="#000066" BackColor="White"></FooterStyle>
							<Columns>
								<asp:ButtonColumn Text="Select" CommandName="Select"></asp:ButtonColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Left" ForeColor="#000066" BackColor="White" Mode="NumericPages"></PagerStyle>
						</asp:datagrid>
				
                    </div>
                </div>
		</form>
            </div>
          <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</html>
