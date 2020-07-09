<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Pouring.aspx.vb" Inherits="WebApplication2.Pouring" %>
<!DOCTYPE HTML>
<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title>PouringNew</title>
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

	</HEAD>
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
                                         <b><h1 align="middle" colspan="6">302 Form Entry    Pouring Sheet<hr class="prettyline" />
                                             <h1></h1>
                                        </h1></b> 
                                     </div>
                                    </div>

                                    <div class="row">
									<div class="col-6">
										<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label></div>
								</div>
							</div>
                        <asp:panel id="pnlPour" runat="server">
							 <div class="container-fluid">

								<div class="row">
									<div class="col-2">Heat Number</div>
                                    <div class="col-2"><asp:textbox id="txtHeat_number" runat="server" CssClass="form-control" AutoPostBack="True" MaxLength="6" ToolTip="enter 6-digit heat number(only numeric)" onkeypress="OnlyNumericEntry()"></asp:textbox></div>
                                    <div class="col-2">Melting WO No</div>
                                    <div class="col-2"><asp:label id="lblWoval" runat="server"></asp:label></div>
                                    <div class="col-2"><asp:label id="lblWODesc" runat="server" Width="100px"></asp:label></div>
                                    </div>
                                 <br />
                                 <div class="row">
                                  <div class="col-2"><asp:label id="lblHtNo" runat="server" Width="54px" Visible="False"></asp:label></div>
                                     <div class="col-2"><asp:Label id="lblSlNo" runat="server" Visible="False"></asp:Label></div>
                                     </div>
                                 <br />
                                 <div class="row">
									<div class="col-2">Tube In Time</div>
                                     <div class="col-2"><asp:TextBox ID="txtTITDate" runat="server" CssClass="form-control" AutoPostBack="True" Style="width:103px;" placeholder="dd/mm/yyyy"></asp:TextBox></div>
                                     <div class="col-2"> <asp:TextBox ID="txtTube_intime" runat="server" CssClass="form-control" AutoPostBack="True" MaxLength="5"></asp:TextBox></div>
                                     <div class="col-2">Tube Out Time</div>
                                     <div class="col-2"><asp:TextBox ID="txtTOTDate" runat="server" AutoPostBack="True" CssClass="form-control" Style="width:103px;" placeholder="dd/mm/yyyy"></asp:TextBox></div>
                                     <div class="col-2"> <asp:TextBox ID="txtTube_outtime" runat="server" AutoPostBack="True" MaxLength="5" CssClass="form-control"></asp:TextBox></div>
                                 </div>
                                 <br />
                                 <div class="row">
									<%--<div class="col-2">Tube Out Time</div>
                                     <div class="col-2"><asp:TextBox ID="txtTOTDate" runat="server" AutoPostBack="True" CssClass="form-control"></asp:TextBox></div>
                                     <div class="col-2"> <asp:TextBox ID="txtTube_outtime" runat="server" AutoPostBack="True" MaxLength="5" CssClass="form-control"></asp:TextBox></div>--%>
                                     <div class="col-2">LIM</div>
                                     <div class="col-2"><asp:TextBox ID="txtldlInsl_metal" runat="server" AutoPostBack="True" MaxLength="5" CssClass="form-control"></asp:TextBox></div>
                                     <div class="col-2">Date</div>
                                    <div class="col-2"><asp:textbox id="txtCastDate" runat="server" CssClass="form-control" AutoPostBack="True" onkeypress="return isNumber1(event,this)" MaxLength="20" placeholder="dd/mm/yyyy" Style="width:103px;"></asp:textbox></div>
                                    <div class="col-2">Operator</div>
                                    <div class="col-2"><asp:textbox id="txtOperator_mould" runat="server" CssClass="form-control" AutoPostBack="True" MaxLength="20" ></asp:textbox></div>
                                     </div>
                                 <br />
                             </div>

                            <div class="container-fluid">
								<div class="row">
									<%--<div class="col-2">Date</div>
                                    <div class="col-2"><asp:textbox id="txtCastDate" runat="server" CssClass="form-control" AutoPostBack="True" onkeypress="return isNumber1(event,this)" MaxLength="20" placeholder="dd/mm/yyyy"></asp:textbox></div>
                                    <div class="col-2">Operator</div>
                                    <div class="col-2"><asp:textbox id="txtOperator_mould" runat="server" CssClass="form-control" AutoPostBack="True" MaxLength="20" ></asp:textbox></div>--%>
                                    <div class="col-2">SSE/JE</div>
                                    <div class="col-2"><asp:textbox id="txtShift_supervisor" runat="server" CssClass="form-control" AutoPostBack="True"></asp:textbox></div>
                                    <div class="col-2">Shift</div>
									<div class="col-2">
                                        <asp:RadioButtonList id="rblGroup" runat="server" RepeatLayout="Flow"  RepeatDirection="Horizontal" CssClass="rbl">
																		<asp:ListItem Value="A">A </asp:ListItem>
																		<asp:ListItem Value="B">B </asp:ListItem>
																		<asp:ListItem Value="C">C </asp:ListItem>
																	    <asp:ListItem Value="G" Selected="True">G </asp:ListItem>
																	</asp:RadioButtonList></div>
                                </div>
                                <br />
                                  <div class="row">
                                  </div>
                                                 <br />
                                 <div class="row">
									<div class="col-6"><asp:RadioButtonList id="rblWO" CssClass="rbl" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal"></asp:RadioButtonList></div>
                                  </div>
                                 <br />
                              </div>

                             <div class="container-fluid">
								<div class="row">
                                    <div class="col-2">Pour Order</div>
                                     <div class="col-2"><asp:textbox id="txtPourOrder" runat="server" CssClass="form-control"></asp:textbox></div>
                                     <div class="col-2">PourDate</div>
                                     <div class="col-2"><asp:TextBox id="txtPourDate" runat="server" AutoPostBack="True" CssClass="form-control" Style="width:103px;" placeholder="dd/mm/yyyy"></asp:TextBox></div>
                                     <div class="col-2">Pour Time</div>
                                     <div class="col-2"><asp:textbox id="txtPourTime" runat="server" AutoPostBack="True" CssClass="form-control" MaxLength="8"  TabIndex="1" ></asp:textbox></div>
                                    <%--<div class="col-2">Pour Time</div>
                                     <div class="col-2"><asp:textbox id="txtPourHH" runat="server" AutoPostBack="True" CssClass="form-control" MaxLength="2"  placeholder="HH" TabIndex="1"></asp:textbox></div>
                                     <div class="col-2">:</div>
                                    <div class="col-2"><asp:textbox id="txtPourMM" runat="server" AutoPostBack="True" CssClass="form-control" MaxLength="2" placeholder="MM" TabIndex="1"></asp:textbox></div>--%>
                                    </div>
                                 <br />
                                 <div class="row">
                                    <div class="col-2">Cope No</div>
                                     <div class="col-2"><asp:TextBox ID="txtCopeNo" runat="server" AutoPostBack="True" CssClass="form-control" TabIndex="2"></asp:TextBox></div>
                                     <div class="col-2">CHO</div>
                                     <div class="col-2"><asp:DropDownList ID="ddlcho" runat="server" AutoPostBack="True" CssClass="form-control ll">
                                                    <asp:ListItem Value="C20">C20</asp:ListItem>
                                                    <asp:ListItem>C21</asp:ListItem>
                                                </asp:DropDownList>
                                     </div>
                                     <div class="col-2">Cope Life</div>
                                     <div class="col-2"><asp:TextBox ID="txtCopeUsed" runat="server" ReadOnly="True" CssClass="form-control"></asp:TextBox></div>
                                    </div>
                                 <br />
                                  <div class="row">
                                    <div class="col-2">Cope Temp</div>
                                    <div class="col-2"><asp:TextBox ID="txtCHOtemp" runat="server" CssClass="form-control"></asp:TextBox></div>
                                     <div class="col-2">Baking Temp</div>
                                       <div class="col-2"><asp:TextBox ID="txtbakectemp" runat="server" CssClass="form-control"></asp:TextBox></div>
                                       <div class="col-2">Cope Spray Temp</div>
                                       <div class="col-2"><asp:TextBox ID="txtsprayctemp" runat="server" CssClass="form-control"></asp:TextBox></div>
                                 </div>
                                 <br />
                                 <div class="row">
                                    <div class="col-2">Drag No</div>
                                     <div class="col-2"><asp:TextBox ID="txtDragNo" runat="server" AutoPostBack="True" CssClass="form-control" TabIndex="3"></asp:TextBox></div>
                                     <div class="col-2">DHO</div>
                                     <div class="col-2">
                                         <asp:DropDownList ID="ddldho" runat="server" AutoPostBack="True" CssClass="form-control ll">
                                                <asp:ListItem Value="D13"></asp:ListItem>
                                                <asp:ListItem>D14</asp:ListItem>
                                            </asp:DropDownList>
                                     </div>
                                     <div class="col-2">Engr No</div>
                                     <div class="col-2"><asp:TextBox ID="txtEngrNo" runat="server" ReadOnly="True" CssClass="form-control"></asp:TextBox></div>
                                     </div>
                                 <br />
                                  <div class="row">
                                    <div class="col-2">Drag Life</div>
                                    <div class="col-2"><asp:TextBox ID="txtDragUsed" runat="server" ReadOnly="True" CssClass="form-control"></asp:TextBox></div>
                                    <div class="col-2">Drag Temp</div>
                                    <div class="col-2"><asp:TextBox ID="txtDHOtemp" runat="server" CssClass="form-control"></asp:TextBox></div>
                                    <div class="col-2">Ingate Life</div>
                                    <div class="col-2"><asp:TextBox ID="txtIngateUsed" runat="server" ReadOnly="True" CssClass="form-control"></asp:TextBox></div>
                                   </div>
                                 <br />
                                 <div class="row">
                                    <div class="col-2">Drag Spray Temp</div>
                                    <div class="col-2"><asp:TextBox ID="txtspraydtemp" runat="server" CssClass="form-control"></asp:TextBox></div>
                                    <div class="col-2">Split Time</div>
                                    <div class="col-2"><asp:TextBox ID="txtSplitTime" runat="server" AutoPostBack="True"  MaxLength="5" CssClass="form-control" TabIndex="4">09:30</asp:TextBox></div>
                                    <div class="col-4"><asp:radiobuttonlist id="rdoByPass" tabIndex="-1" runat="server" CssClass="rbl" RepeatLayout="Flow" RepeatDirection="Horizontal" AutoPostBack="True" Font-Bold="True">
												<asp:ListItem Value="No ByPass" Selected="True">No ByPass&nbsp;</asp:ListItem>
												<asp:ListItem Value="6&amp;7">Cope &amp; Drag Bypass&nbsp;</asp:ListItem>
												<asp:ListItem Value="7">Drag ByPass</asp:ListItem>
											</asp:radiobuttonlist></div>
                                   <%-- <div class="col-2"></div>--%>
                                   </div>
                                 <br />
                                    <div class="row">
                                    <div class="col-2">F/C</div>
                                    <div class="col-2"><asp:DropDownList ID="cboFastContinuous" CssClass="form-control ll" runat="server">
                                                <asp:ListItem Selected="True" Value="Continuous">C</asp:ListItem>
                                                <asp:ListItem Value="Fast">F</asp:ListItem>
                                            </asp:DropDownList></div>
                                    <div class="col-2">C Rate</div>
                                    <div class="col-2"><asp:TextBox ID="txtControledRate" runat="server" CssClass="form-control">1.5</asp:TextBox></div>
                                    <div class="col-2">F Rate</div>
                                    <div class="col-2"><asp:TextBox id="txtFastRate" runat="server" CssClass="form-control">1.3</asp:TextBox></div>
                                   </div>
                                 <br />
                                    <div class="row">
                                    <div class="col-2">Rej Code/Sts </div>

                                         <div class="col-2"> <asp:DropDownList ID="DDLPourStatus_code" runat="server" CssClass="form-control ll"  >
    <asp:ListItem>select</asp:ListItem>
    <asp:ListItem Selected="True" Value="OK">OK</asp:ListItem>
    <asp:ListItem Value="XC-3" >XC-3</asp:ListItem>
    <asp:ListItem Value="XC-10">XC-10</asp:ListItem>
    <asp:ListItem Value="XC-13">XC-13</asp:ListItem>
    <asp:ListItem Value="XC-15">XC-15</asp:ListItem>
    <asp:ListItem Value="XC-30">XC-30</asp:ListItem>
    <asp:ListItem Value="XC-31">XC-31</asp:ListItem>
    <asp:ListItem Value="XC-32">XC-32</asp:ListItem>
    <asp:ListItem Value="XC-39">XC-39</asp:ListItem>
    <asp:ListItem Value="XC-46">XC-46</asp:ListItem>
    <asp:ListItem Value="XC-48">XC-48</asp:ListItem>
    <asp:ListItem Value="XC-50">XC-50</asp:ListItem>
    <asp:ListItem Value="XC-51">XC-51</asp:ListItem>
    <asp:ListItem Value="XC-53">XC-53</asp:ListItem>
    <asp:ListItem Value="XC-56">XC-56</asp:ListItem>
    <asp:ListItem Value="XC-58">XC-58</asp:ListItem>
    <asp:ListItem Value="XC-61">XC-61</asp:ListItem>
    <asp:ListItem Value="XC-62">XC-62</asp:ListItem>
    <asp:ListItem Value="XC-93">XC-93</asp:ListItem>
    <asp:ListItem Value="XC-124">XC-124</asp:ListItem>
    <asp:ListItem Value="XC-126">XC-126</asp:ListItem>
    <asp:ListItem Value="XC-139">XC-139</asp:ListItem>
    <asp:ListItem Value="RNB">RNB</asp:ListItem>
    <asp:ListItem Value="WSC">WSC</asp:ListItem>
    <asp:ListItem Value="WSD">WSD</asp:ListItem>
    <asp:ListItem Value="UNS">UNS</asp:ListItem>
    <asp:ListItem Value="FIN">FIN</asp:ListItem>
    <asp:ListItem Value="ROP">ROP</asp:ListItem>
    <asp:ListItem Value="BS">BS</asp:ListItem>
    <asp:ListItem Value="BD">BD</asp:ListItem>
    <asp:ListItem Value="MMT">MMT</asp:ListItem>
    <asp:ListItem Value="PHB">PHB</asp:ListItem>
    <asp:ListItem Value="PND">PND</asp:ListItem>
    <asp:ListItem Value="HNF">HNF</asp:ListItem>
    <asp:ListItem Value="WTL">WTL</asp:ListItem>
    <asp:ListItem Value="TAIL">TAIL</asp:ListItem>
    </asp:DropDownList> </div>
                                    <div class="col-2"><asp:textbox id="txtRejCode" runat="server" AutoPostBack="True" CssClass="form-control" TabIndex="5"></asp:textbox></div>
                                    <div class="col-2">Remarks</div>
                                    <div class="col-2"><asp:textbox id="txtRemarks" runat="server" CssClass="form-control" style="width:350px;height:50px;" TextMode="MultiLine" TabIndex="6"></asp:textbox></div>
                                    <div class="col-2"><asp:Label id="lblNotInMR" runat="server" Visible="False"></asp:Label> </div>
                                    <div class="col-2"></div>
                                   </div>
                                 <br />
                                   <div class="container-fluid">
                                    <div class="row">
									<div class="col-4" align="middle">
										<asp:Button id="btnSave" runat="server" Text="Save" BorderStyle="Solid" CssClass="btn btn-dark" Font-Bold="True" Font-Names="Arial" Font-Size="Medium"></asp:Button></div>
								       <div class="col-4" align="middle">
                                           <asp:button id="btnClear" runat="server" Text="Clear" CausesValidation="False"  BorderStyle="Solid" CssClass="btn btn-dark" Font-Bold="True" Font-Names="Arial" Font-Size="Medium"></asp:button></div>
											<div class="col-4" align="middle">
                                                <asp:button id="btnExit" runat="server" Text="Exit" CausesValidation="False"  BorderStyle="Solid" CssClass="btn btn-dark" Font-Bold="True" Font-Names="Arial" Font-Size="Medium"></asp:button></div>
                               </div>
                                 <br />
                                 </div>
                                      <div class="row">
                                    <div class="col-6"><asp:Label ID="lblUser" runat="server" Visible="False"></asp:Label></div>
                                   </div>
                                 <br />
                                 </div>
                 </asp:panel>
                        	<asp:datagrid id="grdPouring" runat="server" CssClass="table" Font-Size="Small" AutoGenerateColumns="False" CellPadding="3" GridLines="Vertical" ForeColor="Black" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px">
								<AlternatingItemStyle BackColor="#CCCCCC"></AlternatingItemStyle>
								<ItemStyle Font-Size="Small"></ItemStyle>
                                <FooterStyle BackColor="#CCCCCC" />
								<HeaderStyle ForeColor="White" BackColor="Black" Font-Bold="True"></HeaderStyle>
								<Columns>
									<asp:BoundColumn DataField="pouring_order" HeaderText="PO"></asp:BoundColumn>
									<asp:BoundColumn DataField="PourTime" HeaderText="PTime"></asp:BoundColumn>
									<asp:BoundColumn DataField="cope_number" ReadOnly="True" HeaderText="Cope"></asp:BoundColumn>
									<asp:BoundColumn DataField="cope_used" ReadOnly="True" HeaderText="CpL"></asp:BoundColumn>
									<asp:BoundColumn DataField="CHONO" HeaderText="CHO"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="CHOTMP" HeaderText="Cope Temp."></asp:BoundColumn>
                                    <asp:BoundColumn DataField="BCTMP" HeaderText="Bake Temp."></asp:BoundColumn>
                                    <asp:BoundColumn DataField="SCTMP" HeaderText="Cope Spray Temp."></asp:BoundColumn>
									<asp:BoundColumn DataField="drag_number" ReadOnly="True" HeaderText="Drag"></asp:BoundColumn>
									<asp:BoundColumn DataField="engraved_number" ReadOnly="True" HeaderText="Whl">
										<ItemStyle Font-Bold="True" ForeColor="#FF3333"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="drag_used" ReadOnly="True" HeaderText="DrL"></asp:BoundColumn>
									<asp:BoundColumn DataField="DHONO" HeaderText="DHO"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="DHOTMP" HeaderText="Drag Temp."></asp:BoundColumn>
                                    <asp:BoundColumn DataField="SDTMP" HeaderText="Drag Spray Temp."></asp:BoundColumn>
									<asp:BoundColumn DataField="ingate_used" ReadOnly="True" HeaderText="IngL"></asp:BoundColumn>
									<asp:BoundColumn DataField="SplitTime" ReadOnly="True" HeaderText="STime"></asp:BoundColumn>
									<asp:BoundColumn DataField="whether_f_c" ReadOnly="True" HeaderText="F/C"></asp:BoundColumn>
									<asp:BoundColumn DataField="CRate" ReadOnly="True" HeaderText="CRate"></asp:BoundColumn>
									<asp:BoundColumn DataField="FRate" ReadOnly="True" HeaderText="FRate"></asp:BoundColumn>
									<asp:BoundColumn DataField="rejection_code" ReadOnly="True" HeaderText="Rej"></asp:BoundColumn>
									<asp:BoundColumn DataField="remarks" ReadOnly="True" HeaderText="Remarks"></asp:BoundColumn>
									<asp:BoundColumn DataField="WhlType" ReadOnly="True" HeaderText="WhlType"></asp:BoundColumn>
									<asp:ButtonColumn Visible="False" Text="Delete" HeaderText="Delete" CommandName="Delete"></asp:ButtonColumn>
									<asp:ButtonColumn Text="Select" CommandName="Select"></asp:ButtonColumn>
									<asp:BoundColumn DataField="slno" HeaderText="slno"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="Sts" HeaderText="Sts"></asp:BoundColumn>
								</Columns>
								<PagerStyle Font-Size="Small" BackColor="#999999" ForeColor="Black" HorizontalAlign="Center"></PagerStyle>
							    <SelectedItemStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
							</asp:datagrid>
				
                        </asp:panel>
                </div>
             </div>
		</FORM>
            </div>
 <%--<div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>--%>
        <div class="card-footer" style="text-align:right;background-color:#cccccc;vertical-align:middle;height:45px; width:100%;bottom:0;"><h4 style="color: black;font-size:15px;">MAINTAINED BY CRIS</h4></div>
         
        <script>
 $(document).ready(function () {
                       
     $('#txtTITDate').datepicker({
         dateFormat: "dd/mm/yy",

         onSelect: function (date) {
             var date1 = $('#txtTITDate').datepicker('getDate');
         }


     });

      $('#txtTOTDate').datepicker({
         dateFormat: "dd/mm/yy",

         onSelect: function (date) {
             var date1 = $('#txtTOTDate').datepicker('getDate');
         }


     });
     
      $('#txtCastDate').datepicker({
         dateFormat: "dd/mm/yy",

         onSelect: function (date) {
             var date1 = $('#txtCastDate').datepicker('getDate');
         }


     });
    
      $('#txtPourDate').datepicker({
         dateFormat: "dd/mm/yy",

         onSelect: function (date) {
             var date1 = $('#txtPourDate').datepicker('getDate');
         }


     });

      $('#txtTOTDate').datepicker({
         dateFormat: "dd/mm/yy",

         onSelect: function (date) {
             var date1 = $('#txtTOTDate').datepicker('getDate');
         }


         });
                             $('#txtLLTDate').datepicker({
                            dateFormat: "dd/mm/yy", 
                       
                            onSelect: function(date){            
                                var date1= $('#txtLLTDate').datepicker('getDate');           
                                                 
                              
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

function OnlyNumericEntry() {
        if ((event.keyCode < 48 || event.keyCode > 57)) {
        event.returnValue = false;
    }
                                   }
                                    function isNumber1(evt, element) {

                    var charCode = (evt.which) ? evt.which : event.keyCode

                      if (
                           (charCode != 45 ) && (charCode != 47 ) &&     // 
                           (charCode < 48 || charCode > 57))
                      return false;

                  return true;
              } 

      </script>
	</body>
</html>

