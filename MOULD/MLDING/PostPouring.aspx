<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PostPouring.aspx.vb" Inherits="WebApplication2.PostPouring" %>

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
          <script>
 $(document).ready(function () {
                       
     $('#txtCastDate').datepicker({
         dateFormat: "dd/mm/yy",

         onSelect: function (date) {
             var date1 = $('#txtCastDate').datepicker('getDate');
         }


     });

      $('#txtEndDate').datepicker({
         dateFormat: "dd/mm/yy",

         onSelect: function (date) {
             var date1 = $('#txtEndDate').datepicker('getDate');
         }


     });
     
      $('#txtCBStartDate').datepicker({
         dateFormat: "dd/mm/yy",

         onSelect: function (date) {
             var date1 = $('#txtCBStartDate').datepicker('getDate');
         }

     });
    
      $('#txtCBEndDate').datepicker({
         dateFormat: "dd/mm/yy",

         onSelect: function (date) {
             var date1 = $('#txtCBEndDate').datepicker('getDate');
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
    <div class="container">
        <div class="row">
            <div class="table">
                <form id="Form1" method="post" runat="server">
            
                    <div  id="Table10" class="table">
                        <div class="row">
                            <div class="col-12" align="center">
                                <h1>302 Form Entry</h1>
                                <hr  />
                            </div>
                            <div class="col-2">&nbsp;</div>
                        </div>
                    </div >
                                       <asp:Panel ID="Panel1" runat="server">
                        <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>


                        <div  id="Table7" class="table">
                            <div class="row">
                                <div class="col-2"></div>
                            </div>
                        </div >
                        <div  id="Table12" class="table">
                            <div class="row">
                                <div class="col-2">HeatNumber</div>
                                <div class="col-2">
                                    <asp:TextBox ID="txtHeat_number" runat="server" style="width:103px;" CssClass="form-control" AutoPostBack="True"></asp:TextBox></div>
                                <div class="col-2">MeltingWONo&nbsp;</div>
                                <div class="col-2">
                                    <asp:Label ID="lblWoval" runat="server"></asp:Label>
                                </div>
                               <div class="col">StopSupp</div> 
                            <div class="col">
                  
                                <asp:DropDownList id="ddlStop_support" runat="server" AutoPostBack="True" CssClass=" form-control ll"></asp:DropDownList> 
                                                      
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-2">
                                    <asp:Label ID="lblWODesc" runat="server"></asp:Label>
                                </div>
                                <div class="col-2">
                                    <asp:Label ID="lblHtNo" runat="server" Visible="False"></asp:Label>
                                </div>
                            
                            </div><br />


                            <div class="row">     <div class="col-2">
                                    <asp:Label ID="lblSlNo" runat="server" Visible="False"></asp:Label>
                                </div></div><br />
                            <div class="row">
                                <div class="col-2">Date</div>
                                <div class="col-2">
                                    <asp:TextBox ID="txtCastDate" runat="server"  style="width:103px;" CssClass="form-control" placeholder="yyyy-mm-dd"></asp:TextBox></div>

                                <div class="col-2">Operator</div>
                                <div class="col-2">
                                    <asp:TextBox ID="txtOperator_mould" runat="server" MaxLength="20" style="width:103px;" CssClass="form-control"></asp:TextBox></div>
                                <div class="col-2">SSE/JE</div>
                                <div class="col-2">
                                    <asp:TextBox ID="txtShift_supervisor" runat="server" MaxLength="20" style="width:103px;" CssClass="form-control"></asp:TextBox></div>
                                </div>
                            <br />
                            <div class="row">
                                <div class="col-2">Shift</div>
                                <div class="col-2">
                                    <asp:RadioButtonList ID="rblGroup" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="rbl">
                                        <asp:ListItem Value="A">A &nbsp;&nbsp;</asp:ListItem>
                                        <asp:ListItem Value="B">B&nbsp;&nbsp;</asp:ListItem>
                                        <asp:ListItem Value="C">C&nbsp;&nbsp;</asp:ListItem>
                                        <asp:ListItem Selected="True">G</asp:ListItem>
                                    </asp:RadioButtonList></div>
                            </div><br />
                        </div >
                        <div  class="table">
                            <div class="row">
                                <div class="col-2">DomeDisc</div>
                                <div class="col-2">
                                    <asp:TextBox ID="txtDomedisc_used" runat="server" style="width:103px;" CssClass="form-control"></asp:TextBox></div>
                                <div class="col-2">End Date and Time</div>
                                <div class="col-2">
                                    <asp:TextBox ID="txtEndDate" runat="server" CssClass="form-control" style="width:103px;" ToolTip="fill Date" placeholder="yyyy-mm-dd"></asp:TextBox></div>
                                <div class="col-2">
                                    <asp:TextBox ID="txtEnd_time" runat="server" MaxLength="5" CssClass="form-control" style="width:103px;" ToolTip="Fill Time" placeholder="hh:mm"></asp:TextBox>
                                </div>
                            </div><br/>
                            <div class="row">
                                <div class="col-2">Drain Metal Level(In Inch) </div>
                                <div class="col-2">
                                    <asp:TextBox ID="txtDrain_MM" runat="server" CssClass="form-control" style="width:103px;"></asp:TextBox>
                                </div>
                                <%-- <div class="col-2">EndTemp</div>
                                                    <div class="col-2" colspan="2">
                                                        <asp:TextBox ID="txtEnd_temperature" runat="server" CssClass="form-control"></asp:TextBox>
                                                    </div>--%>
                            </div>
                        </div >
                        <div  id="Table15" class="table">
                            <div class="row">
                                <div class="col-2"></div>
                                <div class="col-2">StartDate</div>
                                <div class="col-2">StartTime</div>
                                <div class="col-2">EndDate</div>
                                <div class="col-2">EndTime</div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-2">Pouring</div>
                                <div class="col-2">
                                    <asp:TextBox ID="txtCBStartDate" runat="server" CssClass="form-control" style="width:103px;" placeholder="yyyy-mm-dd"></asp:TextBox>
                                </div>
                                <div class="col-2">
                                    <asp:TextBox ID="txtCorebakingSttm" runat="server" AutoPostBack="false" CssClass="form-control" style="width:103px;" placeholder="hh:mm"></asp:TextBox>
                                </div>
                                <div class="col-2">
                                    <asp:TextBox ID="txtCBEndDate" runat="server" CssClass="form-control" style="width:103px;" placeholder="yyyy-mm-dd"></asp:TextBox>
                                </div>
                                <div class="col-2">
                                    <asp:TextBox ID="txtCorebackEndTm" runat="server" CssClass="form-control" style="width:103px;" placeholder="hh:mm"></asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-2">TotalPourTime (In Min)</div>
                                <div class="col-2">
                                    <asp:TextBox ID="txtTotalpour_time" runat="server" CssClass="form-control" MaxLength="5" style="width:103px;"></asp:TextBox></div>
                                <div class="col-2">FinalTemp.ofMetal</div>
                                <%--<div class="col-2">
                                    <asp:TextBox ID="ftempofmtl" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-2">EndTemp</div>--%>
                                <div class="col-2" >
                                    <asp:TextBox ID="txtEnd_temperature" runat="server" CssClass="form-control" style="width:103px;"></asp:TextBox>
                                </div>
                            </div>
                            <br />
                        </div >
                        <div  id="Table13" class="table">
                            <div class="row">
                                <div class="col-2">Metal Weight after Pouring</div>
                                <div class="col-2">
                                    <asp:TextBox ID="txtmetalwt" runat="server" CssClass="form-control" style="width:103px;"></asp:TextBox></div>
                                <div class="col-2">Riser Weight </div>
                                <div class="col-2">
                                    <asp:TextBox ID="txtriserwt" runat="server" CssClass="form-control" style="width:103px;"></asp:TextBox></div>
                                <div class="col-2">Ladle Weight After Pouring</div>
                                <div class="col-2">
                                    <asp:TextBox ID="txtw4" runat="server" CssClass="form-control" style="width:103px;"></asp:TextBox>
                                </div>

                            </div>
                            <br />
                        </div >
                        <div  id="Table14" class="table">
                            <div class="row">
                                <div class="col-2"><strong>WhlCast</strong></div>
                                <div class="col-2">
                                    <asp:TextBox ID="txtWheelsCast" runat="server" CssClass="form-control" ReadOnly="True" style="width:103px;"></asp:TextBox></div>
                                <div class="col-2"><strong>CopesUsed</strong></div>
                                <div class="col-2">
                                    <asp:TextBox ID="txtwheelcast_cope" runat="server" CssClass="form-control" ReadOnly="True" style="width:103px;"></asp:TextBox></div>
                                <div class="col-2"><strong>DragsUsed</strong></div>
                                <div class="col-2">
                                    <asp:TextBox ID="txtwheelcast_drag" runat="server" CssClass="form-control" ReadOnly="True" style="width:103px;"></asp:TextBox></div>
                            </div><br />
                        </div >

                        <div  id="Table8" class="table">
                            <div class="row">
                                <div class="col-2">Tube1Cond</div>
                                <div class="col-2">
                                    <asp:TextBox ID="txtTube_condition0" runat="server" CssClass="form-control" style="width:103px;"></asp:TextBox>
                                </div>
             
                                <div class="col-2">Tube2Cond</div>
                                <div class="col-2">
                                    <asp:TextBox ID="txtTube_condition1" runat="server" CssClass="form-control" style="width:103px;"></asp:TextBox>
                                </div>
                          
                                <div class="col-2">Tube3Cond</div>
                                <div class="col-2">
                                    <asp:TextBox ID="txtTube_condition2" runat="server" CssClass="form-control" style="width:103px;"></asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-2">Reason of Less Wheel cast</div>


                                <div class="col-2">
                                    <asp:TextBox ID="txtPostRemarks0" runat="server" CssClass="form-control" style="width:103px;"></asp:TextBox>
                                </div>
                        
                                <div class="col-2">Reason of excess pouring start delay</div>

                                <div class="col-2">
                                    <asp:TextBox ID="txtPostRemarks1" runat="server" CssClass="form-control" style="width:103px;"></asp:TextBox>
                                </div>
                           
                                <div class="col-2">Reason of excess pouring time</div>


                                <div class="col-2">
                                    <asp:TextBox ID="txtPostRemarks" runat="server" CssClass="form-control" style="width:103px;height:35px;" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div><br />
                        </div >
                        <div  class="table">
                            <strong>
                                <asp:Label ID="lblCastWheels" runat="server" BackColor="#0066FF"></asp:Label>
                            </strong>
                            <caption>
                                <br />
                        
                                <div class="row">
                                    <div class="col-2">Remarks</div>
                                    <div class="col-2">
                                        <asp:TextBox ID="txtPostRemark" runat="server" CssClass="form-control" style="width:103px;height:35px;" TextMode="MultiLine"></asp:TextBox></div>
                                    <div class="col-2">
                                        <asp:Label ID="lblUser" runat="server" Visible="False"></asp:Label>
                                    </div>
                                </div>
                                <br />
                            </caption>
                        </div >

                        <div  class="table">
                            <div class="row">
                                <div class="col-12" align="middle">
                                    <asp:Button ID="btnpostsave" AccessKey="s" runat="server" Text="Save" CssClass="btn btn-dark" Font-Bold="True" Font-Names="Arial" Font-Size="Medium"></asp:Button>&nbsp;&nbsp;&nbsp;
											<asp:Button ID="btnPostClear" AccessKey="c" runat="server" Text="Clear" CausesValidation="False" CssClass="btn btn-dark" Font-Bold="True" Font-Names="Arial" Font-Size="Medium"></asp:Button>&nbsp;&nbsp;&nbsp;
											<asp:Button ID="btnPostExit" AccessKey="e" runat="server" Text="Exit" CausesValidation="False" CssClass="btn btn-dark" Font-Bold="True" Font-Names="Arial" Font-Size="Medium"></asp:Button></div>
                            </div><br />
                        </div >
                        <%--</asp:panel>--%>
                    </asp:Panel>
 
                           <div class ="row">
               <div id="table8" class="table">
                     <div class="row">
					 <div class="col-12"><asp:datagrid id="datagrid1" CssClass="table" runat="server" CellPadding="4" CellSpacing="2" AutoGenerateColumns="False" forecolor="Black" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" Width="100%">
							<FooterStyle BackColor="#CCCCCC" />
							<HeaderStyle ForeColor="White" BackColor="Black" Font-Bold="True"></HeaderStyle>
							<Columns>
								<%--<asp:ButtonColumn Text="Select" HeaderText="Select" CommandName="Select"></asp:ButtonColumn>--%>
							
								<%--<asp:BoundColumn DataField="cast_date" HeaderText="Cast_Date"></asp:BoundColumn>--%>
								<asp:BoundColumn DataField="heat_number" HeaderText="Heat_number"></asp:BoundColumn>
								<%--<asp:BoundColumn DataField="txtwheelcast_drag" HeaderText="Drag Used"></asp:BoundColumn>--%>
								<asp:BoundColumn DataField="end_time" HeaderText="End_time"></asp:BoundColumn>
								<asp:BoundColumn DataField="end_temperature" HeaderText="End_temperature"></asp:BoundColumn>
                               <%-- <asp:BoundColumn DataField="txtWheelsCast" HeaderText="WheelsCast"></asp:BoundColumn>--%>
                           <%--     <asp:BoundColumn DataField="txtwheelcast_cope" HeaderText="Cope Used"></asp:BoundColumn>
                                <asp:BoundColumn DataField="txtwheelcast_drag" HeaderText="Drag Used"></asp:BoundColumn>--%>
								<asp:BoundColumn DataField="total_pour_time" HeaderText="Total_Poure_Time"></asp:BoundColumn>
                                <asp:BoundColumn DataField="total_wheels_poured" HeaderText="Total_wheels_poured"></asp:BoundColumn>
								<asp:BoundColumn DataField="riserwt" HeaderText="Riserwt"></asp:BoundColumn>
                                <asp:BoundColumn DataField="lwtatpouring" HeaderText="Lwtatpouring"></asp:BoundColumn>
                              
							</Columns>
						    <ItemStyle BackColor="White" />
                            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" Mode="NumericPages" />
                            <SelectedItemStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
						</asp:datagrid> </div >
				 </div ></div>
               </div><br />
                </form>
            </div>
        </div>
    </div>
    <%-- <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS </h4></div>--%>
        <div class="card-footer" style="text-align:right;background-color:#cccccc;vertical-align:middle;height:45px; width:100%; bottom:0;position:relative;"><h4 style="color: black;font-size:15px;">MAINTAINED BY CRIS</h4></div>
</body>
</html>
