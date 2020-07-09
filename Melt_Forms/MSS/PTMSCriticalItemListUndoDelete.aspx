<%@ Page Language="vb" AutoEventWireup="false" Codebehind="PTMSCriticalItemListUndoDelete.aspx.vb" Inherits="WebApplication2.PTMSCriticalItemListUndoDelete" smartNavigation="True" %>
<!DOCTYPE HTML>
<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title>PTMSCriticalItemListUndoDelete</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0"/>
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0"/>
		<meta name="vs_defaultClientScript" content="JavaScript"/>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5"/>
            <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css"/>
        <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
  <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
           <link type="text/css" rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" />
          <%--<link rel="Stylesheet" href="../StyleSheet1.css" />--%>
	</head>
	<body>
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
    
                 <%-- <h4>&nbsp&nbsp&nbspSelect Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px" >
                     
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />--%>
                </div>
             <div class ="row">
                <div class="table-responsive">
			<table id="Table1" class="table">
                <%--style="Z-INDEX: 101; LEFT: 7px; POSITION: absolute; TOP: 3px" cellSpacing="0" cellPadding="0" width="300"--%>
				</table>
						<table id="Table2" class="table">
                           <%-- style="WIDTH: 423px; HEIGHT: 22px" cellSpacing="1" cellPadding="1" width="423"--%>
							 <tr>
								<td colspan="6" style=" color: #FFFFFF;">
										<asp:label id="lblConsignee" runat="server"></asp:label>&nbsp;Critical&nbsp;List - Undo Delete<hr class="prettyline"/></td>
							 </tr>
							 <tr>
								<td style=" color: #FFFFFF;">Message :
									<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></td>
							 </tr>
							 <tr>
								<td style=" color: #FFFFFF;">PL Number</td>
								<td style=" color: #FFFFFF;">:</td>
								<td colspan="4">
									<asp:dropdownlist id="ddlPlNumber"  CssClass="form-control ll" runat="server" AutoPostBack="True" ></asp:dropdownlist>&nbsp;</td>
							 </tr>
						</table>
						<asp:datagrid id="dgBOM" runat="server" CssClass="table" >
                            <%--CellPadding="3" BorderWidth="1px" BorderStyle="None" GridLines="Vertical" BackColor="White" BorderColor="#999999"--%>
							<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
							<AlternatingItemStyle BackColor= "Gainsboro"></AlternatingItemStyle>
							<ItemStyle ForeColor="Black" BackColor="#EEEEEE"></ItemStyle>
							<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#000084"></HeaderStyle>
							<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
							<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
						</asp:datagrid>
				 
				
						<table id="Table3" class="table">
							 <tr>
								<td style=" color: #FFFFFF;">Number</td>
								<td style=" color: #FFFFFF;">:</td>
								<td>
									<asp:textbox id="txtNum" runat="server" CssClass="form-control"></asp:textbox></td>
								<td style=" color: #FFFFFF;">Date</td>
								<td style=" color: #FFFFFF;">:</td>
								<td>
									<asp:textbox id="txtDt" runat="server" CssClass="form-control"></asp:textbox></td>
								<td style=" color: #FFFFFF;">Qty</td>
								<td style=" color: #FFFFFF;">:</td>
								<td>
									<asp:textbox id="txtQty" runat="server" CssClass="form-control"></asp:textbox></td>
							 </tr>
							 <tr>
								<td style=" color: #FFFFFF;">Supplier</td>
								<td style=" color: #FFFFFF;">:</td>
								<TD colSpan="4">
									<asp:textbox id="txtSup" runat="server" CssClass="form-control"></asp:textbox>
                                    </td><td style=" color: #FFFFFF;">DD</td>
                                    <td style=" color: #FFFFFF;">:</td>
                                    <td colspan="3">
							
									<asp:textbox id="txtDD" runat="server" CssClass="form-control"></asp:textbox></td>
							 </tr>
							 <tr>
								<td style=" color: #FFFFFF;">RecdQty</td>
								<td style=" color: #FFFFFF;">:</td>
								<td>
									<asp:textbox id="txtRecdQty" runat="server" CssClass="form-control"></asp:textbox></td>
								<td style=" color: #FFFFFF;">QtyUT</td>
								<td style=" color: #FFFFFF;">:</td>
								<td>
									<asp:textbox id="txtQtyUT" runat="server" CssClass="form-control"></asp:textbox></td>
								<td style=" color: #FFFFFF;">QtyDue</td>
								<td style=" color: #FFFFFF;">:</td>
								<td>
									<asp:textbox id="txtQtyDue" runat="server" CssClass="form-control"></asp:textbox></td>
							 </tr>
							 <tr>
								<td style=" color: #FFFFFF;">Remarks</td>
								<td style=" color: #FFFFFF;">:</td>
								<td colspan="7">
									<asp:textbox id="txtRemarks" runat="server" CssClass="form-control"></asp:textbox></td>
							 </tr>
							 <tr>
								<td  colspan="9">
									<asp:button id="btnSave" CssClass="button button2" runat="server" Text="Undo Delete"></asp:button>
									<asp:label id="lblType" runat="server"></asp:label>
									<asp:label id="lblRecID" runat="server" Visible="False"></asp:label></td>
							 </tr>
							 <tr>
								<td colspan="9" style=" color: #FFFFFF;">Saved&nbsp; Data for report </td>
							 </tr>
						</table>
						<asp:datagrid id="dgSavedData" runat="server" CssClass="table" >
                            <%--CellPadding="3" BorderWidth="1px" BorderStyle="None" BackColor="White" BorderColor="#CCCCCC" Font-Size="Smaller"--%>
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
