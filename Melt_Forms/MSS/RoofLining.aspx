<%@ Page Language="vb" AutoEventWireup="false"  Codebehind="RoofLining.aspx.vb" Inherits="WebApplication2.RoofLining" %>

<!DOCTYPE HTML PUBLIC >
<html>
	<head runat="server">
		<title>ROOF REFRACOTRY CASTING</title>
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
        <script type="text/javas cript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.9/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/responsive/1.0.7/js/dataTables.responsive.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.9/js/dataTables.bootstrap.min.js"></script>
            <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
        <script type="text/javascript" src= "https://ajax.googleapis.com/ajax/libs/jqueryui/1.12.1/jquery-ui.min.js">  </script>
<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
<script type="text/javascript" src="//ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
<script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
<script type="text/javascript" src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>

	</HEAD>
	<body>
            
                 <nav class="mb-1 navbar navbar-expand-sm bg-dark navbar-dark " >
  <a class="navbar-brand p-0" href="#"><img src="../../NewFolder1/unnamed.png" class="rounded-circle z-depth-0"  height="45"/> </a>
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
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../../wapframeset.aspx">
          <i class="fab glyphicon glyphicon-home "></i>
        </a></li>

       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../../logon.aspx">
          <i class="fab glyphicon glyphicon-log-out"></i>
        </a></li>
    
        <li class="nav-item ">
        <a class="nav-link p-0" href="#">
          <%--<img src="../../../CRIS-Recruitment.jpg" class="rounded-circle z-depth-0"  height="50" style="border-width: 34px; background-position: 5px 5px; width:50px;margin-top:3px;border-color:white; border-width:50px"/>
        --%><img src="../../NewFolder1/CRIS-Recruitment.jpg" height="45" style="border-radius:43%"/>
       </a>
      </li>
     </ul>
      
  </div>
</nav>
       
<!--/.Navbar -->


          <div class="container">
            
		<form id="Form1" method="post" runat="server">

            
			<asp:Panel id="Panel1" runat="server">
                <%--style="Z-INDEX: 101; LEFT: 2px; POSITION: absolute; TOP: 2px" --%>


                <div class="row">
            <div class="table">
				<div class="table" >
                 <div class="col" align="middle" colSpan="3"><%--<STRONG><FONT size="4">Wheel 
								Shop Floor Balance Reconcilaton</FONT></STRONG><hr class="prettyline" /></div>--%>
                     <h1 class="heading">
            <asp:Label ID="Heading" runat="server"  Font-Bold="True"   Font-Size="X-Large" Text="ROOF REFRACTORY CASTING" align="center"></asp:Label>
              </h1>
                        </div>
					<div class="row">
						<div class="col">
							<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label></div>
					</div>
				</div>
				
				<%--<table id="Table3" class="table">
                    <%--cellSpacing="1" cellPadding="1" width="300"
					<div class="row">
						<div class="col">
                            dept,contract
							<asp:RadioButtonList id="rblLinedBy"  runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="rbl"></asp:RadioButtonList></div>
					</div>
				</table>--%>
				<div class="table">
                   <%-- cellSpacing="1" cellPadding="1" width="300"--%>
					<div class="row">
						<div class="col" align="center">
							<asp:Label id="lblItemName" runat="server" Text="Furnace No:  "></asp:Label>&nbsp;&nbsp;&nbsp;
							<asp:RadioButtonList id="rbLiningItemNo"  runat="server" AutoPostBack="True" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="rbl">
                        <asp:ListItem Value="A" Selected="True">A</asp:ListItem>
                         <asp:ListItem Value="B">B</asp:ListItem>
					 <asp:ListItem Value="C">C</asp:ListItem>
                                </asp:RadioButtonList>

						</div>
					</div>
                    <div class="row">
                        <div class="col">
                        <asp:Label id="lblroof" runat="server" Text="Roof No:"></asp:Label></div>
						
                        <div class="col">
                            <asp:RadioButtonList id="rbA"  runat="server" AutoPostBack="True" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="rbl">
                        <asp:ListItem Value="RA1" Selected="True">RA1</asp:ListItem>
                         <asp:ListItem Value="RA2">RA2</asp:ListItem>
                     </asp:RadioButtonList>   </div>
                         <div class="col">
                            <asp:RadioButtonList id="rbB"  runat="server" AutoPostBack="True" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="rbl">
                        <asp:ListItem Value="RB1">RB1</asp:ListItem>
                         <asp:ListItem Value="RB2">RB2</asp:ListItem>
                     </asp:RadioButtonList>   </div>
                         <div class="col">
                            <asp:RadioButtonList id="rbC"  runat="server" AutoPostBack="True" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="rbl">
                        <asp:ListItem Value="RC1">RC1</asp:ListItem>
                         <asp:ListItem Value="RC2">RC2</asp:ListItem>
                     </asp:RadioButtonList>   </div>
                    </div>
                    <div class="row">
                        <div class="col" align="center">
                            <asp:RadioButtonList id="rblinedby"  runat="server" AutoPostBack="True" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="rbl">
                        <asp:ListItem Value="1" Selected="True" >Department</asp:ListItem>
                         <asp:ListItem Value="2">Contract</asp:ListItem>
					
                                </asp:RadioButtonList>
                        </div>
                    </div>
				</div>
                <div class="row">
                    <div class="table-responsive">
				<asp:DataGrid id="DataGrid3" runat="server" CssClass="table" ForeColor="Black" BorderColor="#DEDFDE" BorderWidth="1px" BackColor="White" CellPadding="4" GridLines="Vertical" BorderStyle="None">
					<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#CE5D5A"></SelectedItemStyle>
					<AlternatingItemStyle BackColor="White"></AlternatingItemStyle>
                   
					<ItemStyle BackColor="#F7F7DE"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#6B696B"></HeaderStyle>
					<FooterStyle BackColor="#CCCC99"></FooterStyle>
					<PagerStyle HorizontalAlign="Right" ForeColor="Black" BackColor="#F7F7DE" Mode="NumericPages"></PagerStyle>
				</asp:DataGrid></div></div>
				<div class="table" >
                    <%--cellSpacing="1" cellPadding="1" width="300"--%>
					<div class="row">
						<div class="col" vAlign="top" align="left">
							<div class="table" ></div>
                                <%--cellSpacing="1" cellPadding="1" width="300"--%>
								<div class="row">
									<div class="col" align="right">Lining No</div>
									
									<div class="col">
										<asp:TextBox id="txtLiningNo" runat="server" AutoPostBack="True" CssClass="form-control"></asp:TextBox></div>
								
							
									<div class="col" align="right">Previous Lining No</div>
									
									<div class="col">
										<asp:TextBox id="txtPreLiningNo" runat="server" AutoPostBack="True" CssClass="form-control"></asp:TextBox></div>
								
									<div class="col" align="right">Last Heat No of Previous Lining</div>
								
									<div class="col">
										<asp:TextBox id="txtLastHeatNo" runat="server" AutoPostBack="True" CssClass="form-control"></asp:TextBox></div>
								</div>
							</div>
                        </div>
                    <br />
							<asp:DataGrid id="DataGrid1" CssClass="table" runat="server" BorderColor="#3366CC" BorderWidth="1px" BackColor="White" CellPadding="4" BorderStyle="None">
								<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
								<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
								<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
								<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
							</asp:DataGrid>
							<div class="table" >
                             <%--   cellSpacing="1" cellPadding="1" width="300"--%>
								<div class="row">
                                    
                                    <div class="col"></div>
									<div class="col" colSpan="2"></div>
									<div class="col" colSpan="2">Date
									</div>
                                    
                                  <div class="col">Time(hh:mm)</div>
                                    
                                    <div class="col"></div>
								</div>
								<div class="row">
                                    <div class="col"></div>
									<div class="col">Handed Over On</div>
									
									<div class="col">
										<asp:TextBox id="txtHandedOverOnDate" runat="server" CssClass="form-control"></asp:TextBox></div>
									<div class="col">
										<asp:TextBox id="txtHandedOverOnTime" runat="server" CssClass="form-control"></asp:TextBox></div>
								
                                
                                    <div class="col"></div></div>
								<div class="row">
                                    
                                    <div class="col"></div>
									<div class="col">Work Started On</div>
									
									<div class="col">
										<asp:TextBox id="txtWorkStartedOnDate" runat="server" CssClass="form-control"></asp:TextBox></div>
									<div class="col">
										<asp:TextBox id="txtWorkStartedOnTime" runat="server" CssClass="form-control"></asp:TextBox></div>
								
                                    <div class="col"></div>
								</div>
                                <div class="row">
                                    
                                    <div class="col"></div>
									<div class="col">Work Completed On</div>
									
									<div class="col">
										<asp:TextBox id="txtWorkCompletedOnDate" runat="server" CssClass="form-control"></asp:TextBox></div>
									<div class="col">
										<asp:TextBox id="txtWorkCompletedOnTime" runat="server" CssClass="form-control"></asp:TextBox></div>
							
                                    <div class="col"></div>	</div>
							</div>
						</div>
<%--						<div class="col" vAlign="top" align="left">--%>
							<asp:Panel id="pnlFWP" runat="server">
								<div class="table">
                                    <%--cellSpacing="1" cellPadding="1" width="300"--%>
									<div class="row">
                                        <div class="col"></div>
										<div class="col">With Reference To<FONT color="#ff6633"> Furnace Full Lining No</FONT></div>
										
										<div class="col">
											<asp:TextBox id="txtFFLNo" runat="server" CssClass="form-control"></asp:TextBox></div>
									<div class="col"></div>

									</div>
								</div>
							</asp:Panel>
							<asp:Panel id="pnlLadle" runat="server">
								<div class="table">
                                   <%-- style="WIDTH: 393px; HEIGHT: 106px" cellSpacing="1" cellPadding="1" width="393"--%>
									<div class="row">
										<div class="col" align="center"><strong>LADLE DIAMETER AFTER RELINING(in mm)</strong></div>
									</div>
									<div class="row">
										<div class="col">I) BOTTOM-TRUNION TO TRUNION</div>
										
										<div class="col">
											<asp:TextBox id="txtBTT" runat="server" CssClass="form-control"></asp:TextBox></div>
									</div>
									<div class="row">
										<div class="col">II) BOTTOM-MOUTH TO OPPO MOUTH</div>
										
										<div class="col">
											<asp:TextBox id="txtBMOM" runat="server" CssClass="form-control"></asp:TextBox></div>
									</div>
									<div class="row">
										<div class="col">III) TOP-TRUNION TO TRUNION</div>
										
										<div class="col">
											<asp:TextBox id="txtTTT" runat="server" CssClass="form-control"></asp:TextBox></div>
									</div>
									<div class="row">
										<div class="col">IV) TOP-MOUTH TO OPPO MOUTH</div>
										
										<div class="col">
											<asp:TextBox id="txtTMOM" runat="server" CssClass="form-control"></asp:TextBox></div>
									</div>
									<div class="row">
										<div class="col">V) LADLE DEPTH AFTER RELINING</div>
										
										<div class="col">
											<asp:TextBox id="txtDepth" runat="server" CssClass="form-control"></asp:TextBox></div>
									</div>
								</div>
							</asp:Panel>

						<%--</div>--%>
					</div>
                    
				</div>
                   <%-- cellSpacing="1" cellPadding="1" width="300"--%>
					<div class="row">
					<%--	<div class="col" vAlign="top" align="left">--%>
							<div class="table">
                               <%-- cellSpacing="1" cellPadding="1" width="300"--%>
								<div class="row">
									<div class="col">LOA No</div>
								
									<div class="col">
										<asp:TextBox id="txtLOANo" runat="server" AutoPostBack="True" CssClass="form-control"></asp:TextBox></div>
									<div class="col">LOA Date</div>
									
									<div class="col">
										<asp:TextBox id="txtLOADate" runat="server" CssClass="form-control"></asp:TextBox></div>
								<div class="col">Scheduled Qty</div>
									<div class="col">
										<asp:TextBox id="txtScheduledQty" runat="server" CssClass="form-control"></asp:TextBox></div>
									</div>
							</div>
							<div class="table">
								<div class="row">
									<div class="col">Used Qty</div>
									<div class="col" style="WIDTH: 7px">
										<asp:TextBox id="txtCompletedQty" runat="server" CssClass="form-control"></asp:TextBox></div>
									<div class="col">Available</div>
									<div class="col">
										<asp:Label id="Label1" runat="server"></asp:Label></div>
                                    <div class="col">Remarks</div>
									<div class="col" colSpan="5">
										<asp:TextBox id="txtLOARemarks" runat="server" CssClass="form-control" ></asp:TextBox></div>
								
								</div>
								<div class="row">
                                    <div class="col"></div>
									
                                    <div class="col"></div>

								</div>
							</div>
<%--						</div>
						<div class="col" vAlign="top" align="left">--%>
							<div class="table">
                             <%--   cellSpacing="1" cellPadding="1" width="300"--%>
								<div class="row">
									<div class="col">Group Leader1</div>
									<div class="col">
										<asp:TextBox id="txtGroupLeader1" runat="server" CssClass="form-control"></asp:TextBox></div>
									<div class="col">Group Leader2</div>
									<div class="col">
										<asp:TextBox id="txtGroupLeader2" runat="server" CssClass="form-control"></asp:TextBox></div>
								</div>
								<div class="row">
                                    
									<div class="col">Inspection Note</div>
									<div class="col" colSpan="3">
										<asp:TextBox id="txtInspectionNote" runat="server" CssClass="form-control"></asp:TextBox></div>
								
                                    <div class="col"></div>
                                    <div class="col"></div>

								</div>
							</div>
						<%--</div>--%>
					</div>
			
				<div class="table">
					<div class="row">
					<div class="col" align="middle"  colSpan="3"><asp:button id="btnSave" runat="server"  BorderStyle="Solid" Font-Bold="True" Font-Size="20px" CssClass="btn btn-dark" Text="Save"></asp:button></div>
				</div>
				</div>
                   <div class="row">
                    <div class="table-responsive">
				<asp:DataGrid id="DataGrid2" CssClass="table" runat="server" BorderColor="#CC9966" BorderWidth="1px" BackColor="White" CellPadding="4" BorderStyle="None">
					
                    <SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					 <Columns>
                        <asp:ButtonColumn Text="Select" HeaderText="Select" CommandName="Select"></asp:ButtonColumn>
                  
                    </Columns>
                    <ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					  <HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid></div></div>
                </asp:Panel>
		</form>  </div>
        
                <div class="card-footer" style="text-align:right;background-color:#cccccc;bottom:0;width:100%;vertical-align:middle;height:60px"><h4 style="color: black;font-size:15px">MAINTAINED BY CRIS</h4></div>

</body>
</html>
