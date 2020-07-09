<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MouldTransaction.aspx.vb" Inherits="WebApplication2.MouldTransaction" %>
<!DOCTYPE HTML>

<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title>MouldTransaction</title>
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

       <!--
        <link rel="stylesheet" href="../../StyleSheet1.css" />-->
	    <style type="text/css">
            .auto-style2 {
                display: block;
                font-size: 14px;
                font-weight: 400;
                line-height: 1.42857143;
                color: #555;
                background-clip: padding-box;
                border-radius: 4px;
                transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
                -webkit-box-shadow: inset 0 1px 1px rgba(0, 0, 0, .075);
                box-shadow: inset 0 1px 1px rgba(0, 0, 0, .075);
                -webkit-transition: border-color ease-in-out .15s, -webkit-box-shadow ease-in-out .15s;
                -o-transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
                border: 1px solid #ccc;
                padding: 6px 12px;
                background-color: #fff;
                background-image: none;
            }
        </style>
	</head>
	<body >
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
          <i class="fab glyphicon glyphicon-home " style="font-size:30px"></i>
        </a></li>
       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../logon.aspx">
          <i class="fab glyphicon glyphicon-log-out"style="font-size:30px"></i>
        </a></li>
    
        <li class="nav-item ">
        <a class="nav-link p-0" href="#">
          <img src="../../NewFolder1/CRIS-Recruitment.jpg" class="rounded-circle z-depth-0"  height="45"/>
        </a>
      </li>
     </ul>
      
  </div>
</nav>
<!--/.Navbar -->
		<form id="Form1" method="post" runat="server">
   <div class="table">
			<asp:panel id="Panel1"  runat="server">
				
                            <div style="text-align:center">
        <div class="container">
        <h1 class="heading">MR Mould Transaction Edit Remarks
            </h1>
            </div>
            </div>
                        
                    
                  <div class=row>
                        <div class=col>
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                       </div>
                    </div>
                  <div class=row>

                        <div class=col>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Date:</div>
                
                        <div class=col>
                            <asp:TextBox ID="txtDate" runat="server" AutoPostBack="True" BorderStyle="Groove" CssClass="auto-style2" Width="234px"></asp:TextBox>
                           <%-- <asp:ImageButton ID="Imagebutton1" runat="server" Height="27px" ImageAlign="Bottom" ImageUrl="../../Images/11.PNG" OnClick="show_date" Width="40px" />
                            <asp:Calendar ID="Cal1" runat="server">
                                <SelectedDayStyle BackColor="red" />
                                <DayHeaderStyle BackColor="#FFCC66" Font-Bold="true" Height="1px" />
                                <NextPrevStyle Font-Size="9pt" ForeColor="#FFCC66" />
                                <OtherMonthDayStyle ForeColor="#CC9966" />
                                <SelectedDayStyle BackColor="#FFCC66" />
                                <TitleStyle BackColor="#990000" Font-Bold="true" Font-Size="9pt" ForeColor="#FFFFCC" />
                                <TodayDayStyle BackColor="#FFCC66" ForeColor="white" />
                            </asp:Calendar>--%>
                        </div>
                      
                        <div class=col>&nbsp;&nbsp; Shift:
                            <asp:TextBox ID="Txtshift" runat="server" AutoPostBack="True" BorderStyle="Groove" CssClass="auto-style2" Visible="false" Width="234px"></asp:TextBox>
                        </div>
                        
                        <div class=col>
                            <asp:RadioButtonList ID="rblShift" runat="server" AutoPostBack="True" CssClass="rbl" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                <asp:ListItem Value="A">A</asp:ListItem>
                                <asp:ListItem Value="B">B</asp:ListItem>
                                <asp:ListItem Value="C">C</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                    <div class=row>
                        <div class=col></div>
               
                        <div class=col>
                            <asp:DropDownList ID="ddlMoulds" runat="server" CssClass="form-control ll" style="margin-left: 0px" Width="233px">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class=row>
                        <div class=col>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Remarks:</div>
                       
                        <div class=col>&nbsp;<asp:DropDownList ID="ddlRemarks" runat="server" CssClass="form-control ll" Width="323px">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class=row>
                        <div class="row"></div>
                            <div class="row"></div>
                 <br />
                <br />    
                        <div class="col" align="center">
                            <asp:Button ID="btnUpdate"  runat="server"  Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark"  Text="Update" />
                       
    </div>
                        </div>
                
                   <div>
         
				<asp:DataGrid id="DataGrid1" runat="server" BorderStyle="None" CssClass="table" CellPadding="4" BackColor="White" BorderWidth="1px" BorderColor="#CC9966">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>
                       </div>
               
			 </div>
                <div class="container"></div>
        <div class="card-footer" style="text-align:right;background-color:#cccccc;vertical-align:middle;position:absolute;bottom:0;width:100%;height:60px"><h4 style="color: black;font-size:15px">MAINTAINED BY CRIS</h4></div>
            
            
            </asp:panel>
          </form>
        <script>
 $(document).ready(function () {
                       
                        $('#txtDate').datepicker({
                            dateFormat: "dd-mm-yy", 
                       
                            onSelect: function(date){            
                                var date1 = $('#txtDate').datepicker('getDate');           
                                                 
                              
                            }
                        });
    
  function getDate( element ) {
    var date;
    var dateFormat = "dd-MM-yyyy";
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
