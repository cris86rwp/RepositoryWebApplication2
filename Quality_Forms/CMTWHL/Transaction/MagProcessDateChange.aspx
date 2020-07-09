<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MagProcessDateChange.aspx.vb" Inherits="WebApplication2.MagProcessDateChange" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>MagProcessDateChange</title>
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
     <!--<link rel="stylesheet" href="../../StyleSheet1.css" />-->

	</HEAD>
	<body >
           <nav class="mb-1 navbar navbar-expand-sm bg-dark navbar-dark " >
  <a class="navbar-brand p-0" href="#"><img src="../../../NewFolder1/unnamed.png" class="rounded-circle z-depth-0"  height="45"/> </a>
  <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent-333"
    aria-controls="navbarSupportedContent-333" aria-expanded="false" aria-label="Toggle navigation">
    <span class="navbar-toggler-icon"></span>
  </button>
  <div class="collapse navbar-collapse " id="navbarSupportedContent-333" >
      <ul class="navbar-nav ml-auto navbar-center">
         <li class="nav-item" style="font-weight: bold">
             <h1 style="color:white; font-size:30px; margin-left:430px; margin-top:5px">Rail Wheel Plant, Bela</h1> 
       
         </li>
          </ul>
    <ul class="navbar-nav ml-auto  navbar-right">
        <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../../wapframeset.aspx">
          <i class="fab glyphicon glyphicon-home " style="font-size:30px"></i>
        </a></li>

       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../../logon.aspx">
          <i class="fab glyphicon glyphicon-log-out" style="font-size:30px"> </i>
        </a></li>
    
        <li class="nav-item ">
        <a class="nav-link p-0" href="#">
         
        <img src="../../../NewFolder1/CRIS-Recruitment.jpg" height="45" style="border-radius:43%" />
       </a>
      </li>
     </ul>
      
  </div>
</nav>
        <script>
 $(document).ready(function () {
                       
                        $('#txtNewDate').datepicker({
                            dateFormat: "dd-mm-yy", 
                       
                            onSelect: function(date){            
                                var date1 = $('#txtNewDate').datepicker('getDate');           
                                                 
                              
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
  <br />
<!--/.Navbar -->
        <div class="container">
		<form id="Form1" method="post" runat="server">
            <div class="row"><div class="table">
			<asp:panel id="Panel1"  runat="server">
				
							<TABLE id="Table2" class="table">
								<div class="row">
									<div class="col" align="center"><STRONG><FONT size="5">Mag Process Wheels - Date Change </FONT></STRONG>
												<asp:Label id="lblEmpCode" runat="server" Visible="False"></asp:Label></FONT></FONT></div>
								</div>
                                <br />
								<div class="row">
									<div class="col" colSpan="7">
										<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label>
										<asp:Label id="lblTestDate" runat="server" Visible="False"></asp:Label></div>
								</div>
                                 <br />
								<div class="row">
									<div class="col" colSpan="7" align="center" style="margin-left:-15px">Be careful. There is no way to reverse the date and shift</div>
								</div>
                                 <br />
								<div class="row">
									<div class="col" colSpan="7" align="center" style="margin-left:70px"><FONT color="black">Date of the wheels shown in the grid 
											below&nbsp;will be changed to</FONT>&nbsp;New Date;</div>
								</div>
                                 <br />
								<div class="row">
									<div class="col" colSpan="7" align="center" style="margin-left:-85px">Grid on the right side shows score;</div>
								</div>
                                 <br />
								<div class="row">
									<div class="col" colSpan="7" align="center" style="margin-left:148px">New Date is Today's Date which can be altered provided Pink Sheet 
										is&nbsp;not generated&nbsp;.&nbsp;</div>
								</div>
                                 <br />
								<div class="row">
									<div class="col" colSpan="7" align="center" style="margin-left:85px">Select From check-box for starting wheel and To check-box for 
										ending wheel.</div>
								</div>
                                 <br />
                                 <br />
								<div class="row">
									<div class="col">New Date</div>
									
									<div class="col">
										<asp:TextBox id="txtNewDate" runat="server" CssClass="form-control" AutoPostBack="True" Width="120px"></asp:TextBox></div>
									<div class="col">New Shift</div>
									
									<div class="col">
										<asp:RadioButtonList id="rblShift" runat="server" CssClass="rbl" AutoPostBack="True" RepeatLayout="Flow" RepeatDirection="Horizontal">
											<asp:ListItem Value="A" Selected="True">&nbsp;A&nbsp</asp:ListItem>
											<asp:ListItem Value="B">&nbsp;B&nbsp</asp:ListItem>
											<asp:ListItem Value="C">&nbsp;C&nbsp</asp:ListItem>
										</asp:RadioButtonList></div>
									<div class="col">
										<asp:Button id="Button1" runat="server" Text="Change To New Date and Shift"  Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark"></asp:Button></div>
								</div>
                                 <br />
							</TABLE>
							<asp:Label id="lblMag1Start" runat="server" Visible="False"></asp:Label>
							<asp:Label id="lblMag2Start" runat="server" Visible="False"></asp:Label>
							<asp:Label id="lblMag1End" runat="server" Visible="False"></asp:Label>
							<asp:Label id="lblMag2End" runat="server" Visible="False"></asp:Label>
						
							<asp:DataGrid id="DataGrid2" runat="server" CssClass="table" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4">
								<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
								<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
								<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
								<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
							</asp:DataGrid>
				<asp:DataGrid id="DataGrid1" runat="server" CssClass="table" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4" AutoGenerateColumns="False">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<Columns>
						<asp:BoundColumn DataField="Sl" ReadOnly="True" HeaderText="Sl"></asp:BoundColumn>
						<asp:BoundColumn DataField="TestedDt" ReadOnly="True" HeaderText="TestedDt"></asp:BoundColumn>
						<asp:BoundColumn DataField="Sh" ReadOnly="True" HeaderText="Sh"></asp:BoundColumn>
						<asp:BoundColumn DataField="Wheel" ReadOnly="True" HeaderText="Wheel"></asp:BoundColumn>
						<asp:BoundColumn DataField="Heat" ReadOnly="True" HeaderText="Heat"></asp:BoundColumn>
						<asp:BoundColumn DataField="GrindSts" ReadOnly="True" HeaderText="GrindSts"></asp:BoundColumn>
						<asp:BoundColumn DataField="MCNSts" ReadOnly="True" HeaderText="MCNSts"></asp:BoundColumn>
						<asp:BoundColumn DataField="Line" ReadOnly="True" HeaderText="Line"></asp:BoundColumn>
						<asp:BoundColumn DataField="WhlSts" ReadOnly="True" HeaderText="WhlSts"></asp:BoundColumn>
						<asp:BoundColumn DataField="SaveDatetime" ReadOnly="True" HeaderText="SaveDatetime"></asp:BoundColumn>
						<asp:BoundColumn DataField="Mag1" ReadOnly="True" HeaderText="Mag1"></asp:BoundColumn>
						<asp:BoundColumn DataField="Mag2" ReadOnly="True" HeaderText="Mag2"></asp:BoundColumn>
						<asp:TemplateColumn HeaderText="From">
							<ItemTemplate>
								<asp:CheckBox id="chkFrom" runat="server"></asp:CheckBox>
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="To">
							<ItemTemplate>
								<asp:CheckBox id="chkTo" runat="server"></asp:CheckBox>
							</ItemTemplate>
						</asp:TemplateColumn>
					</Columns>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>
			</asp:panel>
                </div></div></form></div>
         <div class="card-footer" style="text-align:right;background-color:#cccccc;vertical-align:middle;position:relative;bottom:0;width:100%;height:60px"><h4 style="color: black;font-size:15px">MAINTAINED BY CRIS</h4></div>

	</body>
</HTML>
