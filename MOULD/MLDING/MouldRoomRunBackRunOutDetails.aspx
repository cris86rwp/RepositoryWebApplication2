<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MouldRoomRunBackRunOutDetails.aspx.vb" Inherits="WebApplication2.MouldRoomRunBackRunOutDetails" %>
<!DOCTYPE HTML >
<HTML>
	<HEAD runat="server">
		<title>MouldRoomRunBackRunOutDetails</title>
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
	<BODY style="overflow-x:hidden">

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
                                         <b><h1 align="middle" colspan="6">Run back &amp; Run out Rejected Wheel Details<hr class="prettyline" />
                                        </h1></b> 
                                     </div>
                                    </div>
                                    <div class="row">
									<div class="col-6">
										<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label></div>
								</div>
							</div>
							 <div class="container-fluid">

								<div class="row">
									<div class="col-2">Date</div>
									<div class="col-2"><asp:TextBox id="txtDate" runat="server" CssClass="form-control" AutoPostBack="True" style="width:103px"></asp:TextBox></div>
									<div class="col-2">Status</div>
									<div class="col-2"><asp:Label id="lblStatus" runat="server"></asp:Label>&nbsp;</div>
                                    <div class="col-2">Heat Number</div>
									<div class="col-2"><asp:Label id="lblHeat" runat="server"></asp:Label>&nbsp;</div>
								</div>
                               <br />
								<div class="row">
									
									<div class="col-2">Wheel Number</div>
									<div class="col-2"><asp:Label id="lblWheel" runat="server"></asp:Label>&nbsp;</div>
                                    <div class="col-2">Pouring Order</div>
									<div class="col-2"><asp:Label id="lblPO" runat="server"></asp:Label>&nbsp;</div>
									<div class="col-2">Pouring Operator</div>
								    <div class="col-2"><asp:TextBox id="txtPourOperator" runat="server" CssClass="form-control" style="width:103px"></asp:TextBox></div>
								</div>
                                 <br />

                              <div class="row">
									<div class="col-2">Plunger Pressure</div>
									<div class="col-2"><asp:TextBox id="txtPlungerPr" runat="server" CssClass="form-control" style="width:103px"></asp:TextBox></div>
									<div class="col-2">Cope Centring Remarks</div>
									<div class="col-2"><asp:TextBox id="txtCentringRemarks" runat="server" CssClass="form-control" style="width:103px"></asp:TextBox></div>
                                    <div class="col-2">Pouring Close down Remarks</div>
									<div class="col-2"><asp:TextBox id="txtCloseDownRemarks" runat="server" CssClass="form-control" style="width:103px"></asp:TextBox></div>
								</div>
                                 <br />
                                <div class="row">
									<div class="col-2">Seating Remarks</div>
								    <div class="col-2"><asp:TextBox id="txtSeatingRemarks" runat="server" CssClass="form-control" style="width:103px"></asp:TextBox></div>
                                    <div class="col-2">Pouring Tube Sink Remarks</div>
									<div class="col-2"><asp:TextBox id="txtTubeSinkRemarks" runat="server" CssClass="form-control" style="width:103px"></asp:TextBox></div>
									<div class="col-2">Prg Crane Remarks</div>
								    <div class="col-2"><asp:TextBox id="txtPrgCraneRemarks" runat="server" CssClass="form-control" style="width:103px"></asp:TextBox></div>
								</div>
						        <br />
							
                         <div class="row">
									<div class="col-2">Cope Number</div>
									<div class="col-2"><asp:Label id="lblCope" runat="server"></asp:Label>&nbsp;</div>
									<div class="col-2">CTC Operator</div>
									<div class="col-2"><asp:TextBox id="txtCTCOperator" runat="server" CssClass="form-control" style="width:103px"></asp:TextBox></div>
                                    <div class="col-2">Dome Disc Fitted</div>
									<div class="col-2">
										<asp:RadioButtonList id="rblDD" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="rbl">
											<asp:ListItem Value="Y">Yes &nbsp;&nbsp;&nbsp;</asp:ListItem>
											<asp:ListItem Value="N" Selected="True">No</asp:ListItem>
										</asp:RadioButtonList>
									</div>
								</div>
                                 <br />

							 <div class="row">
									
                                 <div class="col-2">Stopper Pipe Condition</div>
								 <div class="col-2"><asp:TextBox id="txtPipeCondition" runat="server" CssClass="form-control" style="width:103px"></asp:TextBox></div>
                                 <div class="col-2">Cope Condition Remarks</div>
								 <div class="col-2"><asp:TextBox id="txtCopeConditionRemarks" runat="server" CssClass="form-control" style="width:103px"></asp:TextBox></div>
                                 <div class="col-2">Drag Number</div>
							     <div class="col-2"><asp:Label id="lblDrag" runat="server"></asp:Label>&nbsp;</div>
							</div>
                                 <br />

								<div class="row">
									<div class="col-2">DT Operator</div>
                                    <div class="col-2"><asp:TextBox id="txtDTOperator" runat="server" CssClass="form-control" style="width:103px"></asp:TextBox></div>
                                    <div class="col-2">Drag Condition Remarks</div>
									<div class="col-2"><asp:TextBox id="txtDragConditionRemarks" runat="server" CssClass="form-control" style="width:103px"></asp:TextBox></div>
								    <div class="col-2">Ingate Reamer Operator</div>
								    <div class="col-2"><asp:TextBox ID="txtIngateReamerOperator" runat="server" CssClass="form-control" style="width:103px"></asp:TextBox></div>
								</div>
                                 <br />
								
								<div class="row">
									<div class="col-2">Overall Remarks</div>
									<div class="col-2"><asp:TextBox id="txtRemarks" runat="server" CssClass="form-control" style="width:103px"></asp:TextBox></div>
								</div>
                                 <br />
								<div class="row">
									<div class="col-12" align="middle">
										<asp:Button id="btnSave" runat="server" Text="Save" BorderStyle="Solid" CssClass="btn btn-dark" Font-Bold="True" Font-Names="Arial" Font-Size="Medium"></asp:Button></div>
								</div>
                                 <br />

							</div>
						
						
							<asp:DataGrid id="dgXCWheels" runat="server" AutoGenerateColumns="False" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966" CssClass="table">
								<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
								<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
								<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
								<Columns>
									<asp:ButtonColumn Text="Select" CommandName="Select"></asp:ButtonColumn>
									<asp:BoundColumn DataField="Ht" ReadOnly="True" HeaderText="Ht"></asp:BoundColumn>
									<asp:BoundColumn DataField="Whl" ReadOnly="True" HeaderText="Whl"></asp:BoundColumn>
									<asp:BoundColumn DataField="Sts" ReadOnly="True" HeaderText="Sts"></asp:BoundColumn>
									<asp:BoundColumn DataField="PO" ReadOnly="True" HeaderText="PO"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="PourOperator" ReadOnly="True" HeaderText="PourOperator"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="PlungerPr" ReadOnly="True" HeaderText="PlungerPr"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="CentringRemarks" ReadOnly="True" HeaderText="CentringRemarks"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="CTCOperator" ReadOnly="True" HeaderText="CTCOperator"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="DomeDisc" ReadOnly="True" HeaderText="DomeDisc"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="PipeCondition" ReadOnly="True" HeaderText="PipeCondition"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="DTOperator" ReadOnly="True" HeaderText="DTOperator"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="Remarks" ReadOnly="True" HeaderText="Remarks"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="drag_number" ReadOnly="True" HeaderText="drag_number"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="cope_number" ReadOnly="True" HeaderText="cope_number"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="CloseDownRemarks" ReadOnly="True" HeaderText="CloseDownRemarks"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="SeatingRemarks" ReadOnly="True" HeaderText="SeatingRemarks"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="TubeSinkRemarks" ReadOnly="True" HeaderText="TubeSinkRemarks"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="PrgCraneRemarks" ReadOnly="True" HeaderText="PrgCraneRemarks"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="DragConditionRemarks" ReadOnly="True" HeaderText="DragConditionRemarks"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="CopeConditionRemarks" ReadOnly="True" HeaderText="CopeConditionRemarks"></asp:BoundColumn>
								</Columns>
								<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
							</asp:DataGrid>
				
				<asp:DataGrid id="dgSavedWheels" runat="server" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#3366CC">
					<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
					<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
					<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
					<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
				</asp:DataGrid>
						</asp:Panel>
                    </div></div>
		</FORM>
            </div>
         <%--<div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>--%>
        <div class="card-footer" style="text-align:right;background-color:#cccccc;vertical-align:middle;height:45px; width:100%;"><h4 style="color: black;font-size:15px">MAINTAINED BY CRIS</h4></div>
	<script>
 $(document).ready(function () {
                       
                        $('#txtDate').datepicker({
                            dateFormat: "dd/mm/yy", 
                       
                            onSelect: function(date){            
                                var date1 = $('#txtDate').datepicker('getDate');           
                                                 
                              
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
</HTML>
