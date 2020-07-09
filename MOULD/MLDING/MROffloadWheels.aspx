<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MROffloadWheels.aspx.vb" Inherits="WebApplication2.MROffloadWheels" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title>MROffloadWheels</title>
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
  <a class="navbar-brand p-0" href="#"><img src="../../NewFolder1/unnamed.png" class="rounded-circle z-depth-0"  height="45"/> </a>
  <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent-333"
    aria-controls="navbarSupportedContent-333" aria-expanded="false" aria-label="Toggle navigation">
    <span class="navbar-toggler-icon"></span>
  </button>
  <div class="collapse navbar-collapse " id="navbarSupportedContent-333">
      <ul class="navbar-nav ml-auto  navbar-center">
          <li class="nav-item" style="font-weight: bold">
             <h1 style="color:white; font-size:30px; margin-left:430px; margin-top:5px">Rail Wheel Plant, Bela</h1> 
       
         </li>
          <%--<li class="nav-item"> <a class="nav-link" href="#" style="color:white; font-size:25px;">Rail Wheel Plant Bela</a></li>--%>
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
          <%--<img src="../../NewFolder1/CRIS-Recruitment.jpg" class="rounded-circle z-depth-0"  height="45"/>--%>
            <img src="../../NewFolder1/CRIS-Recruitment.jpg" height="45" style="border-radius:43%"/>
        </a>
      </li>
     </ul>
      
  </div>
</nav>
<!--/.Navbar -->

        <div class="container">
        <FORM id="Form1" method="post" runat="server">
             <div class="row">
                 <div class="table-responsive">
			        <asp:panel id="Panel1" runat="server">

                            <div class="container-fluid">
								<div class="row">
									<div class="col">
                                         <b><h1 align="middle" colspan="6">MR Offloaded Wheels<hr class="prettyline" />
                                        </h1></b> 
                                     </div>
                                    </div>

                                    <div class="row">
									<div class="col-6">
										<asp:Label id="Label10" runat="server" ForeColor="Red"></asp:Label></div>
								</div>
                             <br />
								<div class="row">
									<div class="col-12">
                             <asp:RadioButtonList id="rblMode" runat="server" CssClass="rbl" RepeatLayout="Flow" RepeatDirection="Horizontal"  AutoPostBack="True">
								<asp:ListItem Selected="True" Value="2">Many Heats &nbsp;&nbsp;&nbsp;&nbsp;</asp:ListItem>
								<asp:ListItem Value="1">Single Wheel</asp:ListItem>
							</asp:RadioButtonList>
                                        </div>
                                    </div>
                                </div>
					<br />
							<asp:Panel id="pnlOne" runat="server">
                                 <div class="container-fluid">
								<div class="row">
                                    <div class="col-2">Heat No</div>
									<div class="col-2"><asp:TextBox id="txtHeatNo" runat="server" CssClass="form-control" AutoPostBack="True"></asp:TextBox></div>
                                    <div class="col-2">Wheel No</div>
                                    <div class="col-2"><asp:TextBox id="txtWheelNo" runat="server" CssClass="form-control" AutoPostBack="True"></asp:TextBox></div>
                                    </div>
                                     </div>
							</asp:Panel>
				
				  <div class="container-fluid">
								<div class="row">
                                    <div class="col-2">SIC</div>
						<div class="col-2">
							<asp:TextBox id="txtSIC" runat="server" CssClass="form-control"></asp:TextBox></div>
						<div class="col-2">Present Status</div>
						<div class="col-2">
							<asp:TextBox id="txtPresentSts" runat="server" CssClass="form-control"></asp:TextBox></div>
                          
						<div class="col-2">Present Sts Date</div>
						<div class="col-2">
							<asp:TextBox id="txtPresentDate" runat="server" CssClass="form-control" style="width:103px;"></asp:TextBox></div>
                      </div>
                      <br />
                      <div class="row">
						<div class="col-2">Present Sts SIC</div>
						<div class="col-2">
							<asp:TextBox id="txtPresentSIC" runat="server" CssClass="form-control"></asp:TextBox></div>
						<div class="col-2">Remarks</div>
						<div class="col-2">
							<asp:TextBox id="txtRemarks" runat="server" CssClass="form-control"></asp:TextBox></div>
					</div>
                      <br />
                       <div class="row">
						<div class="col-12"><asp:RadioButtonList id="rblType" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal"></asp:RadioButtonList></div>
				</div>
                      <br />
                        <div class="row">
						<div class="col-12"><asp:RadioButtonList id="rblOffloadCode" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="rbl"></asp:RadioButtonList></div>
                            </div>
                       <br />
                        <div class="row">
						<div class="col-2">Date</div>
                           <div class="col-2"> <asp:TextBox id="txtHeatDt" runat="server" AutoPostBack="True" CssClass="form-control" style="width:103px;"></asp:TextBox></div>
                            <div class="col-2">Shift</div>
                            <div class="col-2">
                                <asp:RadioButtonList id="rblShift" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="rbl"  AutoPostBack="True">
												<asp:ListItem Value="A" Selected="True">A &nbsp;&nbsp;</asp:ListItem>
												<asp:ListItem Value="B">B &nbsp;&nbsp;</asp:ListItem>
												<asp:ListItem Value="C">C &nbsp;&nbsp;</asp:ListItem>
											</asp:RadioButtonList>
                                </div>
                            </div>
                      <br />
                        <div class="row">
                       <div class="col-12" align="middle">
                           <asp:Button id="btnSave"  runat="server" Text="Save" BorderStyle="Solid" CssClass="btn btn-dark" Font-Bold="True" Font-Names="Arial" Font-Size="Medium"></asp:Button>
                       </div>
                            
                      </div>
                      <br />
                      </div>
                </asp:panel>

						
							<asp:panel id="pnlTwo" runat="server">
			                  <div class="container-fluid">
								 <div class="row">
                                    <div class="col-12"><asp:Label id="Label1" runat="server"></asp:Label></div>
                                     </div>

                                   <div class="row">
                                       <div class="col-6" align="left" vAlign="top">
                                           <asp:DataGrid id="dgData1" runat="server" CssClass="table" BackColor="White" AutoGenerateColumns="False" Height="73px" BorderColor="#CC9966" BorderStyle="None" >
															<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
															<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
															<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
															<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
															<Columns>
																<asp:TemplateColumn>
																	<ItemTemplate>
																		<asp:CheckBox id="chkWheel" runat="server" CssClass="form-control"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:BoundColumn DataField="Wh" ReadOnly="True" HeaderText="Wh"></asp:BoundColumn>
															</Columns>
															<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
														</asp:DataGrid>
                                       </div>
                                        <div class="col-6" align="left" vAlign="top">
                                            <asp:DataGrid id="dgData2" runat="server" CssClass="table" BackColor="White" AutoGenerateColumns="False"  BorderColor="#CC9966" BorderStyle="None" >
															<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
															<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
															<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
															<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
															<Columns>
																<asp:TemplateColumn>
																	<ItemTemplate>
																		<asp:CheckBox id="chkWheel" runat="server" CssClass="form-control"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:BoundColumn DataField="Wh" ReadOnly="True" HeaderText="Wh"></asp:BoundColumn>
															</Columns>
															<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
														</asp:DataGrid>
                                          </div>
                                       </div>
                                  </div>

							<div class="container-fluid">
								 <div class="row">
                                    <div class="col-12" vAlign="top" align="middle"><asp:Label id="Label2" runat="server"></asp:Label></div>
                                     </div>
                                 <div class="row">
                                    <div class="col-6" vAlign="top" align="left">
                                        <asp:DataGrid id="dgData3" runat="server" CssClass="table" BackColor="White" AutoGenerateColumns="False"  BorderColor="#CC9966" BorderStyle="None" >
															<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
															<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
															<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
															<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
															<Columns>
																<asp:TemplateColumn>
																	<ItemTemplate>
																		<asp:CheckBox id="chkWheel" runat="server" CssClass="form-control"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:BoundColumn DataField="Wh" ReadOnly="True" HeaderText="Wh"></asp:BoundColumn>
															</Columns>
															<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
														</asp:DataGrid>
                                        </div>
                                     <div class="col-6" vAlign="top" align="left">
                                         <asp:DataGrid id="dgData4" runat="server" CssClass="table" BackColor="White" AutoGenerateColumns="False"  BorderColor="#CC9966" BorderStyle="None" >
															<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
															<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
															<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
															<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
															<Columns>
																<asp:TemplateColumn>
																	<ItemTemplate>
																		<asp:CheckBox id="chkWheel" runat="server" CssClass="form-control"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:BoundColumn DataField="Wh" ReadOnly="True" HeaderText="Wh"></asp:BoundColumn>
															</Columns>
															<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
														</asp:DataGrid>
                                     </div>
                                    </div>
                                </div>
			
                                <div class="container-fluid">
								 <div class="row">
                                    <div class="col-12" vAlign="top" align="middle"><asp:Label id="Label3" runat="server"></asp:Label></div>
                                     </div>
                                     <div class="row">
                                    <div class="col-6" vAlign="top" align="left">
                                        <asp:DataGrid id="dgData5" runat="server" CssClass="table" BackColor="White" AutoGenerateColumns="False"  BorderColor="#CC9966" BorderStyle="None" >
															<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
															<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
															<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
															<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
															<Columns>
																<asp:TemplateColumn>
																	<ItemTemplate>
																		<asp:CheckBox id="chkWheel" runat="server" CssClass="form-control"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:BoundColumn DataField="Wh" ReadOnly="True" HeaderText="Wh"></asp:BoundColumn>
															</Columns>
															<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
														</asp:DataGrid>
                                        </div>
                                          <div class="col-6" vAlign="top" align="left">
                                              <asp:DataGrid id="dgData6" runat="server" CssClass="table" BackColor="White" AutoGenerateColumns="False"  BorderColor="#CC9966" BorderStyle="None" >
															<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
															<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
															<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
															<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
															<Columns>
																<asp:TemplateColumn>
																	<ItemTemplate>
																		<asp:CheckBox id="chkWheel" runat="server" CssClass="form-control"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:BoundColumn DataField="Wh" ReadOnly="True" HeaderText="Wh"></asp:BoundColumn>
															</Columns>
															<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
														</asp:DataGrid>
                                              </div>
                                         </div>
                                    </div>
										
                                  <div class="container-fluid">
								 <div class="row">
                                    <div class="col-12"><asp:Label id="Label4" runat="server"></asp:Label></div>
                                     </div>
                                       <div class="row">
                                    <div class="col-6" vAlign="top" align="left">
										<asp:DataGrid id="dgData7" runat="server" CssClass="table" BackColor="White" AutoGenerateColumns="False"  BorderColor="#CC9966" BorderStyle="None" >
															<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
															<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
															<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
															<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
															<Columns>
																<asp:TemplateColumn>
																	<ItemTemplate>
																		<asp:CheckBox id="chkWheel" runat="server" CssClass="form-control"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:BoundColumn DataField="Wh" ReadOnly="True" HeaderText="Wh"></asp:BoundColumn>
															</Columns>
															<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
														</asp:DataGrid>
                                        </div>
                                           <div class="col-6" vAlign="top" align="left">
                                               <asp:DataGrid id="dgData8" runat="server" CssClass="table" BackColor="White" AutoGenerateColumns="False"  BorderColor="#CC9966" BorderStyle="None" >
															<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
															<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
															<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
															<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
															<Columns>
																<asp:TemplateColumn>
																	<ItemTemplate>
																		<asp:CheckBox id="chkWheel" runat="server" CssClass="form-control"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:BoundColumn DataField="Wh" ReadOnly="True" HeaderText="Wh"></asp:BoundColumn>
															</Columns>
															<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
														</asp:DataGrid>
                                               </div>
                                           </div>
                                      </div>

                                 <div class="container-fluid">
								 <div class="row">
                                    <div class="col-12" vAlign="top" align="middle"><asp:Label id="Label5" runat="server"></asp:Label></div>
                                     </div>
                                       <div class="row">
                                    <div class="col-6" vAlign="top" align="left">
                                        <asp:DataGrid id="dgData9" runat="server" CssClass="table" BackColor="White" AutoGenerateColumns="False"  BorderColor="#CC9966" BorderStyle="None" >
															<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
															<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
															<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
															<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
															<Columns>
																<asp:TemplateColumn>
																	<ItemTemplate>
																		<asp:CheckBox id="chkWheel" runat="server" CssClass="form-control"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:BoundColumn DataField="Wh" ReadOnly="True" HeaderText="Wh"></asp:BoundColumn>
															</Columns>
															<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
														</asp:DataGrid>
                                        </div>
                                            <div class="col-6" vAlign="top" align="left">
                                               <asp:DataGrid id="dgData10" runat="server" CssClass="table" BackColor="White" AutoGenerateColumns="False"  BorderColor="#CC9966" BorderStyle="None" >
															<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
															<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
															<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
															<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
															<Columns>
																<asp:TemplateColumn>
																	<ItemTemplate>
																		<asp:CheckBox id="chkWheel" runat="server" CssClass="form-control"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:BoundColumn DataField="Wh" ReadOnly="True" HeaderText="Wh"></asp:BoundColumn>
															</Columns>
															<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
														</asp:DataGrid> 
                                            </div>
                                           </div>
                                     </div>

                                  <div class="container-fluid">
								 <div class="row">
                                    <div class="col-12" vAlign="top" align="middle"><asp:Label id="Label6" runat="server"></asp:Label></div>
                                     </div>
                                       <div class="row">
                                    <div class="col-6" vAlign="top" align="left">
                                        <asp:DataGrid id="dgData11" runat="server" CssClass="table" BackColor="White" AutoGenerateColumns="False"  BorderColor="#CC9966" BorderStyle="None" >
															<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
															<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
															<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
															<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
															<Columns>
																<asp:TemplateColumn>
																	<ItemTemplate>
																		<asp:CheckBox id="chkWheel" runat="server" CssClass="form-control"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:BoundColumn DataField="Wh" ReadOnly="True" HeaderText="Wh"></asp:BoundColumn>
															</Columns>
															<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
														</asp:DataGrid>
                                        </div>
                                       <div class="col-6" vAlign="top" align="left">
                                           <asp:DataGrid id="dgData12" runat="server" CssClass="table" BackColor="White" AutoGenerateColumns="False"  BorderColor="#CC9966" BorderStyle="None" >
															<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
															<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
															<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
															<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
															<Columns>
																<asp:TemplateColumn>
																	<ItemTemplate>
																		<asp:CheckBox id="chkWheel" runat="server" CssClass="form-control"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:BoundColumn DataField="Wh" ReadOnly="True" HeaderText="Wh"></asp:BoundColumn>
															</Columns>
															<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
											</asp:DataGrid>


                                           </div>
                                           </div>
                                      </div>

                                  <div class="container-fluid">
								    <div class="row">
                                        <div class="col-6" vAlign="top" align="middle">
                                            <asp:Label id="Label7" runat="server"></asp:Label>
                                            </div>

                                        <div class="col-6" vAlign="top" align="left">
                                            <asp:DataGrid id="DataGrid2" runat="server" CssClass="table" BackColor="White" AutoGenerateColumns="False"  BorderColor="#CC9966" BorderStyle="None" >
															<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
															<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
															<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
															<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
															<Columns>
																<asp:TemplateColumn>
																	<ItemTemplate>
																		<asp:CheckBox id="chkWheel" runat="server" CssClass="form-control"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:BoundColumn DataField="Wh" ReadOnly="True" HeaderText="Wh"></asp:BoundColumn>
															</Columns>
															<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
														</asp:DataGrid>

                                             <div class="col-6" vAlign="top" align="left">
                                                        <asp:DataGrid id="DataGrid3" runat="server" CssClass="table" BackColor="White" AutoGenerateColumns="False"  BorderColor="#CC9966" BorderStyle="None" >
															<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
															<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
															<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
															<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
															<Columns>
																<asp:TemplateColumn>
																	<ItemTemplate>
																		<asp:CheckBox id="chkWheel" runat="server" CssClass="form-control"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:BoundColumn DataField="Wh" ReadOnly="True" HeaderText="Wh"></asp:BoundColumn>
															</Columns>
															<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
														</asp:DataGrid>
                                            </div>
                                            </div>
                                        </div>
                                      </div>

                                <div class="container-fluid">
								    <div class="row">
                                        <div class="col-6" vAlign="top" align="middle">
                                            <asp:Label id="Label8" runat="server"></asp:Label>
                                            </div>

                                        <div class="col-6" vAlign="top" align="left">
                                            <asp:DataGrid id="dgData13" runat="server" CssClass="table" BackColor="White" AutoGenerateColumns="False"  BorderColor="#CC9966" BorderStyle="None" >
															<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
															<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
															<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
															<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
															<Columns>
																<asp:TemplateColumn>
																	<ItemTemplate>
																		<asp:CheckBox id="chkWheel" runat="server" CssClass="form-control"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:BoundColumn DataField="Wh" ReadOnly="True" HeaderText="Wh"></asp:BoundColumn>
															</Columns>
															<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
														</asp:DataGrid>
                                            </div>
                                        <div class="col-6" vAlign="top" align="left">
                                            <asp:DataGrid id="dgData14" runat="server" CssClass="table" BackColor="White" AutoGenerateColumns="False" BorderColor="#CC9966" BorderStyle="None" >
															<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
															<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
															<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
															<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
															<Columns>
																<asp:TemplateColumn>
																	<ItemTemplate>
																		<asp:CheckBox id="chkWheel" runat="server" CssClass="form-control"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:BoundColumn DataField="Wh" ReadOnly="True" HeaderText="Wh"></asp:BoundColumn>
															</Columns>
															<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
														</asp:DataGrid>
                                            </div>
                                        </div>
                                    </div>

                                 <div class="container-fluid">
								    <div class="row">
                                        <div class="col-6" vAlign="top" align="middle"><asp:Label id="Label9" runat="server"></asp:Label></div>
                                        <div class="col-6" vAlign="top" align="left">
                                            <asp:DataGrid id="dgData15" runat="server" CssClass="table" BackColor="White" AutoGenerateColumns="False"  BorderColor="#CC9966" BorderStyle="None" >
															<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
															<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
															<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
															<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
															<Columns>
																<asp:TemplateColumn>
																	<ItemTemplate>
																		<asp:CheckBox id="chkWheel" runat="server" CssClass="form-control"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:BoundColumn DataField="Wh" ReadOnly="True" HeaderText="Wh"></asp:BoundColumn>
															</Columns>
															<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
														</asp:DataGrid>
                                            </div>
                                        <div class="col-6" vAlign="top" align="left">
                                            <asp:DataGrid id="dgData16" runat="server" CssClass="table" BackColor="White" AutoGenerateColumns="False"  BorderColor="#CC9966" BorderStyle="None" >
															<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
															<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
															<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
															<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
															<Columns>
																<asp:TemplateColumn>
																	<ItemTemplate>
																		<asp:CheckBox id="chkWheel" runat="server" CssClass="form-control"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:BoundColumn DataField="Wh" ReadOnly="True" HeaderText="Wh"></asp:BoundColumn>
															</Columns>
															<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
														</asp:DataGrid>
                                            </div>
                                        </div>
                                     </div>

                                  <div class="container-fluid">
								    <div class="row">
                                        <div class="col-6" vAlign="top" align="middle"><asp:Label id="Label11" runat="server"></asp:Label></div>
                                         <div class="col-6" vAlign="top" align="left"><asp:DataGrid id="dgData17" runat="server" CssClass="table" BackColor="White" AutoGenerateColumns="False"  BorderColor="#CC9966" BorderStyle="None" >
															<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
															<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
															<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
															<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
															<Columns>
																<asp:TemplateColumn>
																	<ItemTemplate>
																		<asp:CheckBox id="chkWheel" runat="server" CssClass="form-control"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:BoundColumn DataField="Wh" ReadOnly="True" HeaderText="Wh"></asp:BoundColumn>
															</Columns>
															<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
														</asp:DataGrid>
                                             </div>
                                         <div class="col-6" vAlign="top" align="left">
                                             <asp:DataGrid id="dgData18" runat="server" CssClass="table" BackColor="White" AutoGenerateColumns="False"  BorderColor="#CC9966" BorderStyle="None" >
															<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
															<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
															<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
															<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
															<Columns>
																<asp:TemplateColumn>
																	<ItemTemplate>
																		<asp:CheckBox id="chkWheel" runat="server" CssClass="form-control"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:BoundColumn DataField="Wh" ReadOnly="True" HeaderText="Wh"></asp:BoundColumn>
															</Columns>
															<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
														</asp:DataGrid>
                                             </div>
                                        </div>
                                      </div>
							</asp:panel>
					
                     <div class="container-fluid">
								<div class="row">
									<div class="col-12">
				<div class="table-responsive">
                    <asp:DataGrid id="DataGrid1" runat="server" BackColor="White" CssClass="table">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>
			</div>
                                        </div>
                                    </div>
                         </div>
                     </div></div>
            </FORM>
            </div>
        <%-- <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>--%>
        <div class="card-footer" style="text-align:right;background-color:#cccccc;vertical-align:middle;height:45px;bottom:0; width:100%; position:absolute;"><h4 style="color: black;font-size:15px">MAINTAINED BY CRIS</h4></div>
	
    <script>
 $(document).ready(function () {
                       
     $('#txtHeatDt').datepicker({
         dateFormat: "dd/mm/yy",

         onSelect: function (date) {
             var date1 = $('#txtHeatDt').datepicker('getDate');
         }


         });
                             $('#txtPresentDate').datepicker({
                            dateFormat: "dd/mm/yy", 
                       
                            onSelect: function(date){            
                                var date1= $('#txtPresentDate').datepicker('getDate');           
                                                 
                              
                            }
     });
    
    
  function getDate( element ) {
    var date;
    var dateFormat = "dd/MM/yyyy";
    try {
      date = $.datepicker.parseDate( dateFormat, element.value );
    } catch( error ) {
      date = null;
    }

    return date;
  }
    });

                        
</script>
    </body>
</html>
