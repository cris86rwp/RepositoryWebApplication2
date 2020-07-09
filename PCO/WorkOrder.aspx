<%@ Page Language="vb" AutoEventWireup="false" Codebehind="WorkOrder.aspx.vb" Inherits="WebApplication2.WorkOrder" %>
<!DOCTYPE HTML>
<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title>WorkOrder</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0"/>
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0"/>
		<meta name="vs_defaultClientScript" content="JavaScript"/>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5"/>
         
  <meta name="viewport" content="width=device-width, initial-scale=1"/>
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css"/>
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
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
     <%-- <link rel="stylesheet" href="../StyleSheet1.css" />--%>
           <script>

function OnlyNumericEntry() {
        if ((event.keyCode < 48 || event.keyCode > 57)) {
        event.returnValue = false;
    }
               }
               </script>
	</head>
	<body >
         <nav class="mb-1 navbar navbar-expand-sm bg-dark navbar-dark " >
  <a class="navbar-brand p-0" href="#"><img src="../NewFolder1/unnamed.png" class="rounded-circle z-depth-0"  height="45"/> </a>
  <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent-333"
    aria-controls="navbarSupportedContent-333" aria-expanded="false" aria-label="Toggle navigation">
    <span class="navbar-toggler-icon"></span>
  </button>
  <div class="collapse navbar-collapse " id="navbarSupportedContent-333" >
      <ul class="navbar-nav ml-auto navbar-center">
         <li class="nav-item" style="font-weight: bold">
             <h1 style="color:white; font-size:30px; margin-left:325px; margin-top:5px">Rail Wheel Plant, Bela</h1> 
       
         </li>
          </ul>
    <ul class="navbar-nav ml-auto  navbar-right">
        <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../wapframeset.aspx">
          <i class="fab glyphicon glyphicon-home " style="font-size:30px;"></i>
        </a></li>

       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../logon.aspx">
          <i class="fab glyphicon glyphicon-log-out" style="font-size:30px;"></i>
        </a></li>
    
        <li class="nav-item ">
        <a class="nav-link p-0" href="#">
          <%--<img src="../../../CRIS-Recruitment.jpg" class="rounded-circle z-depth-0"  height="50" style="border-width: 34px; background-position: 5px 5px; width:50px;margin-top:3px;border-color:white; border-width:50px"/>
        --%><img src="../NewFolder1/CRIS-Recruitment.jpg" height="45" style="border-radius:43%"/>
       </a>
      </li>
     </ul>
      
  </div>
</nav>
<!--/.Navbar -->

         
         <div class="container">
              <div class="row">
                <div class="table-responsive">

		<form id="Form1" method="post" runat="server">
            <%--<h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />--%>
			<asp:panel id="Panel1"  runat="server">
                 
				<table id="Table1" class="table">
					<tr>
						<td vAlign="top" align="center" colSpan="3"><h2>Manage Work Order </h2>
							<hr class="prettyline" />
						</td>
					</tr>
					<tr>
						<td colSpan="3">
							<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></td>
					</tr>
					<tr>
						<td >WOForTheMonth</td>
						<td>:</td>
						<td>
							<asp:radiobuttonlist id="rblMonth" runat="server" RepeatLayout="Flow" AutoPostBack="True" RepeatDirection="Horizontal" CssClass="rbl"></asp:radiobuttonlist>
							<asp:radiobuttonlist id="rblYear" runat="server" RepeatLayout="Flow" AutoPostBack="True" RepeatDirection="Horizontal" CssClass="rbl"></asp:radiobuttonlist></td>
					</tr>
					<tr>
						<td >Shop</td>
						<td >:</td>
						<td>
							<asp:radiobuttonlist id="rblShop" runat="server" RepeatLayout="Flow" AutoPostBack="True" RepeatDirection="Horizontal"  CssClass="rbl">
								<asp:ListItem Value="WheelShop" Selected="True">WheelShop</asp:ListItem>
								<%--<asp:ListItem Value="AxleShop">AxleShop</asp:ListItem>--%>
							</asp:radiobuttonlist></td>
					</tr>
					<tr>
						<td >Shop Code</td>
						<td >:</td>
						<td>
							<asp:radiobuttonlist id="rblShopCode" runat="server" RepeatLayout="Flow" AutoPostBack="True"  CssClass="rbl"></asp:radiobuttonlist></td>
					</tr>
					<tr>
						<td >Type</td>
						<td >:</td>
						<td>
							<asp:radiobuttonlist id="rblType" runat="server" RepeatLayout="Flow" AutoPostBack="True" RepeatDirection="Horizontal" CssClass="rbl">
								<asp:ListItem Value="New" Selected="True">New</asp:ListItem>
								<asp:ListItem Value="EnhanceQty">EnhanceQty</asp:ListItem>
								<asp:ListItem Value="Suspend">Suspend</asp:ListItem>
								<asp:ListItem Value="Delete">Delete</asp:ListItem>
								<asp:ListItem Value="Resume">Resume</asp:ListItem>
								<asp:ListItem Value="Close">Close</asp:ListItem>
							</asp:radiobuttonlist></td>
					</tr>
					<tr>
						<td >Product</td>
						<td>:</td>
						<td>
							<asp:RadioButtonList id="rblMake" runat="server" RepeatLayout="Flow" AutoPostBack="True" RepeatDirection="Horizontal"  CssClass="rbl">
								<asp:ListItem Value="RWF" Selected="True">RWP</asp:ListItem>
								<asp:ListItem Value="Non-RWF">Non-RWP</asp:ListItem>
							</asp:RadioButtonList></td>
					</tr>
								<tr>
                                   
									<td colspan="3">
										<asp:dropdownlist id="ddlProductCode" runat="server" AutoPostBack="True" CssClass="form-control ll"></asp:dropdownlist></td>
									<td>
										<asp:label id="lblDescription" runat="server"></asp:label></td>
								</tr>
							</table>
					
		
				
                    
				<table id="Table3"  class="table">
					<tr>
						<td>WorkOrderNo</td>
						<td>:</td>
						
                            <asp:Panel ID="Panel2" runat="server" BackColor="#FFC080">
                                <asp:Label ID="lblWO" runat="server" ForeColor="Transparent"></asp:Label>
                            </asp:Panel>
                           
                            <td>Qty:</td>
                            <td><asp:TextBox ID="txtQty" runat="server" AutoPostBack="True" CssClass="form-control" ToolTip="enter qty(only numeric)" onkeypress="OnlyNumericEntry()"></asp:TextBox>
                            </td>
                     
					</tr>
					<tr>
						<td>Start Date:</td>
						<td>
							<asp:Label id="lblStDt" runat="server"></asp:Label></td>
						<td>EndDate:</td>
						<td>
							<asp:Label id="lblEdDt" runat="server"></asp:Label></td>
					</tr>
					<tr>
						<td vAlign="top" align="center" colSpan="6">
							<asp:Button id="btnSave" runat="server" Text="Save" CssClass="button button2"></asp:Button></td>
					</tr>
				</table>
                   
               <table id="Table4"  class="table">
             

                    <asp:DataGrid id="DataGrid1" runat="server" BackColor="White" BorderColor="#CC9966" BorderStyle="None" CssClass="table">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<Columns>
						<asp:ButtonColumn Text="Select" CommandName="Select"></asp:ButtonColumn>
					</Columns>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>
				<asp:DataGrid id="DataGrid2" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" CssClass="table">
					<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
					<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
					<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
					<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
				</asp:DataGrid>
                    </table>
                
			</asp:panel>&nbsp;
                
		</form>

                </div>
                  </div></div>
        <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
              
	</body>
</html>
