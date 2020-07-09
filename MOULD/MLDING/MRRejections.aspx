<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MRRejections.aspx.vb" Inherits="WebApplication2.MRRejections" %>
<!DOCTYPE HTML >
<HTML>
	<HEAD runat="server">
		<title>MRRejection</title>
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
            .auto-style3 {
                width: 942px;
                height: 14px;
            }
            .auto-style4 {
                width: 999px;
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
                                         <b><h1 align="middle" colspan="6">MR Rejections Details<hr class="prettyline" />
                                             <h1></h1>
                                        </h1></b> 
                                     </div>
                                    </div>

                                 <div class="row">
									<div class="col-6">
										<asp:Label id="lblMessage" runat="server" Visible="False"></asp:Label></div>
                                     </div>

                                   <div class="row">
									<div class="col-12" align="middle"><asp:RadioButtonList id="rblType" runat="server" AutoPostBack="True"  CssClass="rbl" RepeatLayout="Flow" RepeatDirection="Horizontal">
								<asp:ListItem Value="Data" Selected="True">Data &nbsp;&nbsp;</asp:ListItem>
								<asp:ListItem Value="Reasons">Reasons &nbsp;&nbsp;</asp:ListItem>
							</asp:RadioButtonList>
									</div>
                                     <%--  <div class="col-2"></div>
                                       <div class="col-2"></div>
                                       <div class="col-2"></div>
                                       <div class="col-2"></div>
                                       <div class="col-2"></div>--%>
                                       </div>
                                <br />
                                </div>
                        <asp:Panel id="pnlData" runat="server">
                             <div class="container-fluid">
								<div class="row">
									<div class="col-2">Tapped Date</div>
                                    <div class="col-2"><asp:TextBox id="txtTappedDate" runat="server" AutoPostBack="True" CssClass="form-control" Style="width:103px;" placeholder="dd/mm/yyyy" ></asp:TextBox></div>
                                       <div class="col-2">Wheel No</div>
                                       <div class="col-2"><asp:Label id="lblWheelNo" runat="server"></asp:Label></div>
                                       <div class="col-2">Heat No</div>
                                       <div class="col-2"><asp:Label id="lblHeatNo" runat="server"></asp:Label></div>
                                    </div>
                                 <br />
                                 <div class="row">
									<div class="col-2">MR XC</div>
                                     <div class="col-2"><asp:TextBox id="txtMRRej" runat="server" CssClass="form-control" AutoPostBack="True"></asp:TextBox></div>
                                      <div class="col-2"></div>
                                       <div class="col-4"><asp:RadioButtonList id="RadioButtonList2" runat="server" CssClass="rbl" RepeatLayout="Flow" RepeatDirection="Horizontal">
									<asp:ListItem Value="PIC" Selected="True">PIC&nbsp;&nbsp;</asp:ListItem>
									<asp:ListItem Value="BIC">BIC&nbsp;&nbsp;</asp:ListItem>
									<asp:ListItem Value="HIC">HIC&nbsp;&nbsp;</asp:ListItem>
									<asp:ListItem Value="SpIC">SpIC</asp:ListItem>
								</asp:RadioButtonList>
                                       </div>
                                       <div class="col-2"><asp:TextBox id="txtLIC" runat="server"  CssClass="form-control"></asp:TextBox></div>
                                       <%--<div class="col-2">ShiftIC</div>
                                       <div class="col-2"><asp:TextBox id="txtSIC" runat="server" CssClass="form-control"></asp:TextBox></div>--%>
                                     </div>
                                     <br />
                                  <div class="row">
                                      <div class="col-2">Shift IC</div>
                                       <div class="col-2"><asp:TextBox id="txtSIC" runat="server" CssClass="form-control"></asp:TextBox></div>
									<div class="col-2">Reasons</div>
                                      <div class="col-2"><asp:DropDownList id="ddlReasons" runat="server" CssClass="form-control ll" ></asp:DropDownList></div>
                                       <div class="col-2">Remarks</div>
                                       <div class="col-2"><asp:TextBox id="txtRemarks" runat="server" CssClass="form-control" ></asp:TextBox></div>
                                      
                                      </div>
                                 <br />
                                        <br />

                                  <div class="row">
									<div class="col-12" align="middle">
										<asp:Button id="btnRemarks" runat="server" Text="Save Remarks" BorderStyle="Solid" CssClass="btn btn-dark" Font-Bold="True" Font-Names="Arial" Font-Size="Medium"></asp:Button></div>
								</div>
                                 <br />
                                 </div>
                        </asp:panel>
                        <asp:Panel id="pnlReasons" runat="server">
                               <div class="container-fluid">
								<div class="row">
									<div class="col-2">MR XC</div>
                                    <div class="col-2"><asp:TextBox id="txtMRXC" runat="server"  CssClass="form-control" AutoPostBack="True"></asp:TextBox></div>
                                    <div class="col-2"></div>
                                       <div class="col-2">Reason</div>
                                       <div class="col-2"><asp:TextBox id="txtReason" runat="server" CssClass="form-control"></asp:TextBox></div>
                                       
                                       <div class="col-2"></div>
                                    </div>
                                   <br />
                                    <br />
                                    <div class="row">
									<div class="col-12" align="middle">
										<asp:Button id="btnReason" runat="server" Text="Save Reason" BorderStyle="Solid" CssClass="btn btn-dark" Font-Bold="True" Font-Names="Arial" Font-Size="Medium"></asp:Button></div>
								</div>
                                 <br />
                                </div>
                            	<asp:DataGrid id="DataGrid2" runat="server" CssClass="table"  BackColor="White" BorderWidth="1px" BorderStyle="Solid" BorderColor="#999999" CellPadding="3" ForeColor="Black" GridLines="Vertical">
						<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#000099"></SelectedItemStyle>
						<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Black"></HeaderStyle>
						            <AlternatingItemStyle BackColor="#CCCCCC" />
						<FooterStyle BackColor="#CCCCCC"></FooterStyle>
						<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999"></PagerStyle>
					</asp:DataGrid>
                            </asp:panel>
                                </asp:panel>
         </div>
             </div>
		</FORM>
            </div>
        
        <%--<div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>--%>
        <div class="card-footer" style="text-align:right;background-color:#cccccc;vertical-align:middle;height:45px; width:100%;position:absolute; bottom:0;"><h4 style="color: black;font-size:15px;">MAINTAINED BY CRIS</h4></div>
  
        
         <script type="text/javascript">
 $(document).ready(function () {

   $('#txtTappedDate').datepicker({
         dateFormat: "dd/mm/yy",

         onSelect: function (date) {
             var date1 = $('#txtTappedDate').datepicker('getDate');
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