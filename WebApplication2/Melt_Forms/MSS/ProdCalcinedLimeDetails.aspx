<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ProdCalcinedLimeDetails.aspx.vb" Inherits="WebApplication2.ProdCalcinedLimeDetails" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
	<head runat="server">
		<title>ProdCalcinedLimeDetails</title>
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
 	</head>
      <style type="text/css">
         .ui-datepicker {
    background: #333;
    border: 1px solid #555;
    color: #EEE;
    
}
</style>
	<body>

        
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
          <i class="fab glyphicon glyphicon-home " style="font-size:30px;"></i>
        </a></li>
       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../logon.aspx">
          <i class="fab glyphicon glyphicon-log-out" style="font-size:30px;"></i>
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


         <div class="container">
             	<form id="Form1" method="post" runat="server">

                     	<asp:panel id="Panel1"  runat="server">
            <div class ="row">
                <div class="table-responsive">
	
		
				<div class="Table" border="0">
					<div class="row">
						<div class="col" c align="center" >
							<asp:label id="lblConsignee"  runat="server" Font-Bold="True"></asp:label>&nbsp;
                            <STRONG><h2>Production Calcined Lime Receipt Details<h2></STRONG></div>
					</div>
					<div class="row">
						<div class="col">
							<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></div>
					</div>
				</div>
				<div class="table" border="0">
					<div class="row">
						<div class="col">DC No</div>
						<div class="col">
							<asp:textbox id="txtDCNo" runat="server" CssClass="form-control" AutoPostBack="True"></asp:textbox></div>
						<div class="col">DBR No</div>
						<div class="col">
							<asp:Label id="lblDBRNo" runat="server"></asp:Label>&nbsp;</div>
						<div class="col">Year Sl</div>
						<div class="col">
							<asp:TextBox id="txtYearSl" runat="server" CssClass="form-control" ></asp:TextBox></div>
                        <div class="col"></div>
                        <div class="col"></div>
					</div>
					<br><div class="row">
						<div class="col">Receipt Date</div>
						
						<div class="col">
							<asp:textbox id="txtReceiptDate" runat="server" CssClass="form-control"  AutoPostBack="True"></asp:textbox></div>
						<div class="col">Rec Qty</div>
						<div class="col" >
							<asp:TextBox id="txtRecQty" runat="server" CssClass="form-control" ></asp:TextBox></div>
                        <div class="col"></div>
                        <div class="col"></div>
                        <div class="col"></div>
                        <div class="col"></div>
					</div>
					<br><div class="row">
						<div class="col">From Heat</div>
	
						<div class="col">
							<asp:textbox id="txtFromHeat" runat="server" CssClass="form-control"  AutoPostBack="True"></asp:textbox></div>
						<div class="col">Lab No</div>
						<div class="col" colspan="3">
							<asp:Label id="lblLabNo" runat="server"></asp:Label>&nbsp;</div>
                        <div class="col"></div>
                        <div class="col"></div>
                        <div class="col"></div>
                        <div class="col"></div>
					</div>
					<br><div class="row">
						<div class="col">To Heat</div>
					
						<div class="col">
							<asp:textbox id="txtToHeat" runat="server" CssClass="form-control" ></asp:textbox></div>
						<div class="col">Used Date</div>
						<div class="col">
							<asp:TextBox id="txtUsedDate" runat="server" CssClass="form-control" ></asp:TextBox></div>
                        <div class="col"></div>
                        <div class="col"></div>
                        <div class="col"></div>
                        <div class="col"></div>
					</div>
					<br><div class="row">
						<div class="col">No Of Bags</div>
						
						<div class="col">
							<asp:TextBox id="txtNoOfBags" runat="server" CssClass="form-control" ></asp:TextBox></div>
						<div class="col">Result</div>
						<div class="col" >
							<asp:RadioButtonList id="rblResult" runat="server"   RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="rbl">
								<asp:ListItem Value="0">Pass&nbsp</asp:ListItem>
								<asp:ListItem Value="1">&nbsp;Fail</asp:ListItem>
							</asp:RadioButtonList></div>
                        <div class="col"></div>
                        <div class="col"></div>
                        <div class="col"></div>
                        <div class="col"></div>
					</div>
				</div>
               
                  
				
							<asp:DataGrid id="DataGrid2" CssClass="table" runat="server"  BackColor="White">
								<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
								<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
								<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
								<Columns>
									<asp:ButtonColumn Text="Select" CommandName="Select"></asp:ButtonColumn>
								</Columns>
								<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
							</asp:DataGrid>
                       
               
							<asp:DataGrid id="DataGrid3" CssClass="table" runat="server" ForeColor="Black" BackColor="White"  GridLines="Vertical">
								<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#000099"></SelectedItemStyle>
								<AlternatingItemStyle BackColor="#CCCCCC"></AlternatingItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Black"></HeaderStyle>
								<FooterStyle BackColor="#CCCCCC"></FooterStyle>
								<Columns>
									<asp:ButtonColumn Text="Select" CommandName="Select"></asp:ButtonColumn>
								</Columns>
								<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999"></PagerStyle>
							</asp:DataGrid>	
				
				<div class="table" border="0">
					<div class="row">
						<div class="col">Remarks</div>
						
						<div class="col">
							<asp:TextBox id="txtRemarks" runat="server" CssClass="form-control" ></asp:TextBox></div>
                        <div class="col"></div>
                        <div class="col"></div>
                        <div class="col"></div>
                        <div class="col"></div>
                        <div class="col"></div>
                        <div class="col"></div>
					</div>
					<div class="row">
						<div class="col" align="center" colspan="3">
							<asp:Button id="btnSave"  Font-Size="20px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark"  runat="server" Text="Save"></asp:Button>
							<asp:Label id="lblSl" runat="server"></asp:Label></div>
					</div>
					<br><div class="row">
						<div class="col"  colspan="3"  align="center">Saved Data Grid :</div>
					</div>
				</div>
                  
				<asp:DataGrid id="DataGrid1" runat="server" CssClass="table" BackColor="White"  AutoGenerateColumns="False">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<Columns>
						<asp:ButtonColumn Text="Select" CommandName="Select"></asp:ButtonColumn>
						<asp:BoundColumn DataField="SlNo" ReadOnly="True" HeaderText="SlNo"></asp:BoundColumn>
						<asp:BoundColumn DataField="YearSl" ReadOnly="True" HeaderText="YearSl"></asp:BoundColumn>
						<asp:BoundColumn DataField="DCNo" ReadOnly="True" HeaderText="DCNo"></asp:BoundColumn>
						<asp:BoundColumn DataField="ReceiptDt" ReadOnly="True" HeaderText="ReceiptDt"></asp:BoundColumn>
						<asp:BoundColumn DataField="dbr_number" ReadOnly="True" HeaderText="dbr_number"></asp:BoundColumn>
						<asp:BoundColumn DataField="LabNo" ReadOnly="True" HeaderText="LabNo"></asp:BoundColumn>
						<asp:BoundColumn DataField="RecQty" ReadOnly="True" HeaderText="RecQty"></asp:BoundColumn>
						<asp:BoundColumn DataField="FromHeat" ReadOnly="True" HeaderText="FromHeat"></asp:BoundColumn>
						<asp:BoundColumn DataField="ToHeat" ReadOnly="True" HeaderText="ToHeat"></asp:BoundColumn>
						<asp:BoundColumn DataField="Bags" ReadOnly="True" HeaderText="Bags"></asp:BoundColumn>
						<asp:BoundColumn DataField="Result" ReadOnly="True" HeaderText="Result"></asp:BoundColumn>
						<asp:BoundColumn DataField="Remarks" ReadOnly="True" HeaderText="Remarks"></asp:BoundColumn>
						<asp:BoundColumn DataField="DumpNo" ReadOnly="True" HeaderText="DumpNo"></asp:BoundColumn>
						<asp:BoundColumn DataField="SupplierName" ReadOnly="True" HeaderText="SupplierName"></asp:BoundColumn>
						<asp:BoundColumn DataField="Sl" ReadOnly="True" HeaderText="Sl"></asp:BoundColumn>
						<asp:ButtonColumn Text="Delete" CommandName="Delete"></asp:ButtonColumn>
					</Columns>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
                   
				</asp:DataGrid>
                            </div></div> 
                               
			</asp:panel></form>
                    </div>
                <div class="card-footer" style="text-align:right;background-color:#cccccc;vertical-align:middle;position:relative;bottom:0;width:100%;height:60px"><h4 style="color: black;font-size:15px">MAINTAINED BY CRIS</h4></div>
	<script>
 $(document).ready(function () {
                       
                        $('#txtReceiptDate').datepicker({
                            dateFormat: "dd-mm-yy", 
                       
                            onSelect: function(date){            
                                var date1 = $('#txtReceiptDate').datepicker('getDate');           
                                                 
                              
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
         $(document).ready(function () {
                       
                        $('#txtUsedDate').datepicker({
                            dateFormat: "dd-mm-yy", 
                       
                            onSelect: function(date){            
                                var date1 = $('#txtUsedDate').datepicker('getDate');           
                                                 
                              
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
