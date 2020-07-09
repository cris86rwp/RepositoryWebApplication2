<%@ Page Language="vb" AutoEventWireup="false" Codebehind="WheelNotFoundInMaster.aspx.vb" Inherits="WebApplication2.WheelNotFoundInMaster"%>
<!DOCTYPE HTML>
<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title>WheelNotFoundInMaster</title>
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
        <script>
             function OnlyNumericEntry() {
        if ((event.keyCode < 48 || event.keyCode > 57)) {
        event.returnValue = false;
    }
}
              function ValidateAlpha(evt)
    {
        var keyCode = (evt.which) ? evt.which : evt.keyCode
        if ((keyCode < 65 || keyCode > 90) && (keyCode < 97 || keyCode > 123) && keyCode != 32)
         
        return false;
            return true;
        }
        </script>
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
			        <asp:Panel id="Panel1" runat="server">

                            <div class="container-fluid">
								<div class="row">
									<div class="col">
                                         <b><h1 align="middle" colspan="6">Wheel Not Found In Master<hr class="prettyline" />
                                             <h1></h1>
                                        </h1></b> 
                                     </div>
                                    </div>

                                    <div class="row">
									<div class="col-12">
										<asp:Label id="lblGroup" runat="server" Visible="False"></asp:Label></div>
                                        </div>
                                <br />
                                         <div class="row">
                                        <div class="col-6">
										<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label></div>
                               <div class="col-6">
                             <asp:RadioButtonList id="rblType" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="rbl">
								<asp:ListItem Value="AWMCLR" Selected="True">AWMCLR &nbsp;&nbsp;</asp:ListItem>
								<asp:ListItem Value="MLDING">MLDING &nbsp;&nbsp;</asp:ListItem>
							</asp:RadioButtonList></div>
								</div>
                                <br />
							</div>
                        <asp:Panel id="pnlAWMCLR" runat="server">
                            <div class="container-fluid">
								<div class="row">
									<div class="col-2 glyphicon-asterisk" style="color:red">Whl No</div>
                                    <div class="col-2 glyphicon-asterisk" style="color:red">Heat No</div>
                                    <div class="col-2">Year Of Manf</div>
                                    <div class="col-2">Fed Date</div>
                                    <div class="col-2"></div>
                                    <div class="col-2"></div>
                                    <br />
                                    </div>
                                <div class="row">
									<div class="col-2"><asp:TextBox id="txtWhlNo" runat="server" CssClass="form-control" MaxLength="6" ToolTip="Enter Wheel Number(only numeric)" onkeypress="OnlyNumericEntry()"></asp:TextBox></div>
                                    <div class="col-2"><asp:TextBox id="txtHeatNo" runat="server" CssClass="form-control" MaxLength="6" ToolTip="Enter Heat Number(only numeric)" onkeypress="OnlyNumericEntry()"></asp:TextBox></div>
                                    <div class="col-2"><asp:TextBox id="txtYearOfManf" runat="server" CssClass="form-control"></asp:TextBox></div>
                                    <div class="col-2"><asp:TextBox id="txtFedDate" runat="server" CssClass="form-control" ToolTip="date format mm/dd/yyyy" onkeypress="OnlyNumericEntry()"></asp:TextBox></div>
                                    <div class="col-2"><asp:RadioButtonList id="rblWhlType" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="rbl"></asp:RadioButtonList></div>
                                    <div class="col-2"></div>
                                    <br />
                                    </div>
                                  <div class="row">
									<div class="col-4" align="middle">
                                        <asp:Button id="btnAWMCLR" runat="server" Text="Save WNFM Wheel" BorderStyle="Solid" CssClass="btn btn-dark" Font-Bold="True" Font-Names="Arial" Font-Size="Medium"></asp:Button>
									</div>
                                      <br />
                                      </div>
                                </div>
                            </asp:Panel>
                        <asp:Panel id="pnlMLDING" runat="server">
                            <div class="container-fluid">
								<div class="row">
									<div class="col-2" >Whl No</div>
                                    <div class="col-2" ><asp:Label id="lblWhlNo" runat="server" BackColor="#FFC080"></asp:Label></div>
                                    <div class="col-2" >Heat No</div>
                                    <div class="col-2" ><asp:Label id="lblHeatNo" runat="server" BackColor="#FFC080"></asp:Label></div>
                                    <div class="col-2" >Whl Type</div>
                                    <div class="col-2" ><asp:Label id="lblWhlType" runat="server" BackColor="#FFC080"></asp:Label></div>
                                    
                                    </div>
                                <br />
                                <div class="row">
									<div class="col-2" >Year Of Manf</div>
                                    <div class="col-2" ><asp:Label id="lblYearOfManf" runat="server" BackColor="#FFC080"></asp:Label></div>
                                    <div class="col-2"><span class="glyphicon-asterisk" style="color:red"></span>Whl Read At MR</div>
                                    <div class="col-2" ><asp:TextBox id="txtWhlReadAtMR" runat="server" CssClass="form-control" MaxLength="3" ToolTip="Enter WheelReadAtMR Number(only numeric)" onkeypress="OnlyNumericEntry()"></asp:TextBox></div>
                                    <div class="col-2"><span class="glyphicon-asterisk" style="color:red"></span>Actual Wheel No</div>
                                    <div class="col-2" ><asp:TextBox id="txtWheel_number" runat="server" CssClass="form-control" MaxLength="3" ToolTip="Enter Wheel Number(only numeric)" onkeypress="OnlyNumericEntry()"></asp:TextBox></div>
                                    
                                    </div>
                                <br />
                                <div class="row">
									<div class="col-2" ><span class="glyphicon-asterisk" style="color:red"></span>Actual Heat No</div>
                                    <div class="col-2" ><asp:TextBox id="txtheat_number" runat="server" CssClass="form-control" MaxLength="6" ToolTip="Enter Wheel Number(only numeric)" onkeypress="OnlyNumericEntry()"></asp:TextBox></div>
                                    <div class="col-2" >SIC</div>
                                    <div class="col-2" ><asp:TextBox id="txtSIC" runat="server" CssClass="form-control" MaxLength="3" ToolTip="Enter only character" onkeypress="onlyLetter(this)"></asp:TextBox></div>
                                    <div class="col-2" >MR Date</div>
                                    <div class="col-2" ><asp:TextBox id="txtMRDate" runat="server" CssClass="form-control" Style="width:103px;" placeholder="dd/mm/yyyy"></asp:TextBox></div>
                                    
                                    </div>
                                <br />
                                <div class="row">
									<div class="col-2" >Remarks</div>
                                    <div class="col-6" ><asp:TextBox id="txtRemarks" runat="server" CssClass="form-control" MaxLength="250"></asp:TextBox></div>
                                    <div class="col-6" ></div>
                                    <%--<div class="col-2" ></div>
                                    <div class="col-2" ></div>
                                    <div class="col-2" ></div>--%>
                                   
                                    </div>
                                 <br />
                                </div>
                            	<asp:DataGrid id="DataGrid1" runat="server" BackColor="White" CellPadding="3" CssClass="table" BorderWidth="1px" BorderStyle="Solid" BorderColor="#999999" AutoGenerateColumns="False" ForeColor="Black" GridLines="Vertical">
						<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#000099"></SelectedItemStyle>
						<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Black"></HeaderStyle>
						<FooterStyle BackColor="#CCCCCC"></FooterStyle>
						            <AlternatingItemStyle BackColor="#CCCCCC" />
						<Columns>
							<asp:ButtonColumn Text="Select" CommandName="Select"></asp:ButtonColumn>
							<asp:BoundColumn DataField="WhlNo" ReadOnly="True" HeaderText="WhlNo"></asp:BoundColumn>
							<asp:BoundColumn DataField="HeatNo" ReadOnly="True" HeaderText="HeatNo"></asp:BoundColumn>
							<asp:BoundColumn DataField="WhlType" ReadOnly="True" HeaderText="WhlType"></asp:BoundColumn>
							<asp:BoundColumn DataField="YearOfManf" HeaderText="YearOfManf"></asp:BoundColumn>
							<asp:BoundColumn DataField="SlNo" HeaderText="SlNo"></asp:BoundColumn>
							<asp:ButtonColumn Text="Delete" CommandName="Delete"></asp:ButtonColumn>
						</Columns>
						<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999"></PagerStyle>
					</asp:DataGrid>
                            <div class="container-fluid">
                                 <div class="row">
									<div class="col-2" ><asp:Label id="lblSlNo" runat="server" Visible="False"></asp:Label></div>
                                   <%-- <div class="col-2" ><asp:Button id="btnMLDING" runat="server" Text="Update WNFM Wheel" CssClass="button button2"></asp:Button></div>
                                    <div class="col-12" ></div>
                                    <div class="col-2" ></div>
                                    <div class="col-2" ></div>
                                    <div class="col-2" ></div>--%>
                                    
                                    </div>
                                <br />
                                <div class="row">
                                    <div class="col-12" align="middle"><asp:Button id="btnMLDING" runat="server" Text="Update WNFM Wheel" BorderStyle="Solid" CssClass="btn btn-dark" Font-Bold="True" Font-Names="Arial" Font-Size="Medium" ></asp:Button></div>
                                    </div>
                                <br />
                                   <div class="row">
									<div class="col-12" align="middle"><h3><b>Search for MOPO Wheels based on</b></h3></div>
                                    <div class="col-2" ></div>
                                       </div>
                                <br />
                                </div>
                            <asp:Panel id="pnlSearch" runat="server">
                                <div class="container-fluid">
                                 <div class="row">
									<div class="col-12" >
                                        <asp:RadioButtonList id="rblSearch" runat="server" RepeatLayout="Flow" CssClass="rbl" AutoPostBack="True">
										<asp:ListItem Value="1">Selected WhlNo , WhlType , YearOfManf &nbsp;&nbsp;</asp:ListItem>
										<asp:ListItem Value="2">Selected HeatNo &nbsp;&nbsp;</asp:ListItem>
										<asp:ListItem Value="3">Engraved Number</asp:ListItem>
									</asp:RadioButtonList>
									</div>
                                     </div>
                                    <br />
                                    </div>
                                <asp:Panel id="List1" runat="server">
                                <div class="container-fluid">
                                 <div class="row">
									<div class="col-2" >Whl No</div>
                                     <div class="col-2" >Whl Type</div>
                                     <div class="col-2" >Year Of Manf</div>
                                     </div>
                                    <br />
                                     <div class="row">
									<div class="col-2" ><asp:TextBox id="List1a" runat="server" CssClass="form-control"></asp:TextBox></div>
                                     <div class="col-2" ><asp:TextBox id="List1b" runat="server" CssClass="form-control"></asp:TextBox></div>
                                         <div class="col-2" ><asp:TextBox id="List1c" runat="server" CssClass="form-control"></asp:TextBox></div>
                                         <div class="col-2" ></div>
                                    </div>
                                    <br />
                                    </div>
                                    </asp:Panel>
									<asp:Panel id="List2" runat="server">
                                       <div class="row">
									<div class="col-2" >Heat No</div>
                                     <div class="col-2" ><asp:TextBox id="List2a" runat="server" CssClass="form-control"></asp:TextBox></div>
                                         <div class="col-2" ></div>
                                         <div class="col-2" ></div>
                                    </div>
                                        <br />
                                   </asp:Panel>
									<asp:Panel id="List3" runat="server">
                                         <div class="row">
									         <div class="col-2" >Wheel No</div>
                                              <div class="col-2" ><asp:TextBox id="List3a" runat="server" CssClass="form-control"></asp:TextBox></div>
                                             <div class="col-2" >Year Of Manf</div>
                                             <div class="col-2" ><asp:TextBox id="List3b" runat="server" CssClass="form-control"></asp:TextBox></div>
                                           </div>
                                        <br />
                                        </asp:Panel>
                        <div class="container-fluid">
                          <div class="row">
									<div class="col-4" align="middle">
										<asp:Button id="btnSearch" accessKey="s" runat="server" Text="Search" BorderStyle="Solid" CssClass="btn btn-dark" Font-Bold="True" Font-Names="Arial" Font-Size="Medium"></asp:Button>
									</div>
                              </div>
                             <br />
                           </div>
                         <asp:DataGrid id="DataGrid2" runat="server" BackColor="White" CellPadding="3" BorderWidth="1px" CssClass="table" BorderStyle="Solid" BorderColor="#999999" ForeColor="Black" GridLines="Vertical">
							<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#000099"></SelectedItemStyle>
							<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Black"></HeaderStyle>
							 <AlternatingItemStyle BackColor="#CCCCCC" />
							<FooterStyle BackColor="#CCCCCC"></FooterStyle>
							<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999"></PagerStyle>
						</asp:DataGrid>
			</asp:Panel>
				</asp:Panel>	
                        </asp:Panel>
	        </div>
          </div>
		</FORM>
            </div>
      <%--<div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>--%>
        <div class="card-footer" style="text-align:right;background-color:#cccccc;vertical-align:middle;height:45px; width:100%;bottom:0;"><h4 style="color: black;font-size:15px;">MAINTAINED BY CRIS</h4></div>
	<script>
        $(document).ready(function () {
            $('#txtMRDate').datepicker({
         dateFormat: "dd/mm/yy",

         onSelect: function (date) {
             var date1 = $('#txtMRDate').datepicker('getDate');
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
