<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ProductUnifiedPL.aspx.vb" Inherits="WebApplication2.ProductUnifiedPL" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title>ProductUnifiedPL</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0"/>
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0"/>
		<meta name="vs_defaultClientScript" content="JavaScript"/>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5"/>
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

        <%-- <link rel="stylesheet" href="../StyleSheet1.css" />--%>
                          <script>

function OnlyNumericEntry() {
        if ((event.keyCode < 48 || event.keyCode > 57)) {
        event.returnValue = false;
    }
                              }
                              </script>
	</head>
	<body>
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
			<asp:Panel id="Panel1" runat="server">
               
				<table id="Table2" class="table">
					<TR>
						<TD vAlign="top" align="left">
							</td></tr></table>

                               <table id="Table1" class="table">
								<TR>
									<TD><h2>RWP Product Unified PL Number Details 
												Entry</h2><hr class="prettyline" />&nbsp;
									</TD>
								</TR>
								<TR>
									<TD>
										<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label></TD>
								</TR>
								<TR>
									<TD>
										<asp:RadioButtonList CssClass="rbl" id="rblProduct" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal" AutoPostBack="True">
											<asp:ListItem Value="Wheel" Selected="True">Wheel</asp:ListItem>
											<%--<asp:ListItem Value="Axle">Axle</asp:ListItem>--%>
											<%--<asp:ListItem Value="WheelSet">Wheel Set</asp:ListItem>--%>
										</asp:RadioButtonList></TD>
								</TR>
							</table>
                
                               <table id="Table3" class="table">
								<TR>
									<TD>ProductCode</TD>
									<TD>
										<asp:Label id="lblProductCode" runat="server"></asp:Label></TD>
								</TR>
								<TR>
									<TD>UnifiedPL</TD>
									<TD>
										<asp:TextBox id="txtUnifiedPL" runat="server" AutoPostBack="True" CssClass="form-control" onkeypress="OnlyNumericEntry()" ToolTip="enter 8-digit UnifiedPL number(only numeric)" MaxLength="8"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD>ItemDescription</TD>
									<TD>
										<asp:TextBox id="txtItemDescription" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD>SpecificationNo</TD>
									<TD>
										<asp:TextBox id="txtSpecificationNo" runat="server" TextMode="MultiLine" CssClass="form-control" ></asp:TextBox></TD>
								</TR>
								<TR>
									<TD>DrawingNo</TD>
									<TD>
										<asp:TextBox id="txtDrawingNo" runat="server" CssClass="form-control"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD>Category</TD>
									<TD>
										<asp:TextBox id="txtCategory" runat="server" CssClass="form-control"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD align="middle" colSpan="2">
										<asp:Button id="btnSave" runat="server" Text="Save" CssClass="button button2"></asp:Button></TD>
								</TR>
							</table> 
						 
                <div class="row">
                                <div class="table-responsive">
                                   <asp:DataGrid id="DataGrid1" runat="server" CssClass="table"  AllowPaging="True" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966">
								<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
								<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
								<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
								<Columns>
									<asp:ButtonColumn Text="Select" CommandName="Select"></asp:ButtonColumn>
								</Columns>
								<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
							</asp:DataGrid>
                              
                        <asp:DataGrid id="DataGrid2" runat="server" CssClass="table" AllowPaging="True" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#3366CC">
					<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
					<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
					<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
					<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
				</asp:DataGrid>

                    </div></div>
			</asp:Panel>
		</form>
       </div></div></div>
        <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</html>
