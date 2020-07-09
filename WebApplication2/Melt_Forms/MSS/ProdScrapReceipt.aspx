<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ProdScrapReceipt.aspx.vb" Inherits="WebApplication2.ProdScrapReceipt" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
	<head runat="server">
		<title>ProdScrapReceipt</title>
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
       <style>
    .rbl input[type="radio"] {
    margin-left: 15px;
    margin-right: 5px;
}
      
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
  <div class="collapse navbar-collapse " id="navbarSupportedContent-333" >
      <ul class="navbar-nav ml-auto navbar-center">
         <li class="nav-item" style="font-weight: bold">
             <h1 style="color:white; font-size:30px; margin-left:430px; margin-top:5px">Rail Wheel Plant, Bela</h1> 
       
         </li>
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
         
        <img src="../../NewFolder1/CRIS-Recruitment.jpg" height="45" style="border-radius:43%"/>
       </a>
      </li>
     </ul>
      
  </div>
</nav>
         <div class="container" align="center">
       
                           
		<form id="Form1" method="post" runat="server">
			<asp:Panel id="Panel1"   runat="server">
                 <div class="row">
            
                <%--style="Z-INDEX: 103; LEFT: 8px; POSITION: absolute; TOP: 8px"--%>
				<div class="table"   > <%--cellSpacing="1" cellPadding="1" width="300"--%>
				</div>
							<div class="table"> <%--style="WIDTH: 343px; HEIGHT: 18px" cellSpacing="1" cellPadding="1" width="343"--%>
								<div class="row" >
									<div class="col" >
										<asp:label id="lblConsignee" runat="server" Font-Bold="True"></asp:label>&nbsp;<strong><h2>Production 
											Scrap&nbsp;Details</strong></h2></div  >
								</div  >
								<div class="row" >
									<div class="col" >
										<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></div  >
								</div  >
							</div>
							<div class="table"  > <%--style="WIDTH: 557px; HEIGHT: 28px" cellSpacing="1" cellPadding="1" width="557"--%>
								<div class="row" >
									<div class="col" >
										<asp:RadioButtonList id="rblType" runat="server" CssClass="rbl" RepeatDirection="Horizontal" RepeatLayout="Flow" AutoPostBack="True">
											<asp:ListItem Value="1" Selected="True">Receipts</asp:ListItem>
											<asp:ListItem Value="2">Returned Stores</asp:ListItem>
										</asp:RadioButtonList></div  >
								</div  >
								<br><div class="row" >
									<div class="col" >
										<asp:RadioButtonList id="rblScrap" runat="server"  CssClass="rbl" RepeatDirection="Horizontal" RepeatLayout="Flow" AutoPostBack="True"></asp:RadioButtonList></div  >
								</div  >
							</div>
							<div class="table"  > <%--style="WIDTH: 202px; HEIGHT: 61px" cellSpacing="1" cellPadding="1" width="202"--%>
								<div class="row" >
									<div class="col-7" >
										<asp:Label id="lblTypeDate" runat="server"></asp:Label> Date</div  >
									
									<div class="col" >
										<asp:textbox id="txtReceiptDate" runat="server" width="99px" AutoPostBack="True"  CssClass="form-control"></asp:textbox></div  >
								 <div class="col"></div>
										 
                                </div  >
							<br>	<div class="row" >
									<div class="col-7" >
										<asp:Label id="lblTypeNo" runat="server"></asp:Label> No &nbsp&nbsp&nbsp</div  >
								
									<div class="col" >
										<asp:textbox id="txtWagonNo" runat="server" width="99px" AutoPostBack="True"  CssClass="form-control"></asp:textbox></div  >
								<div class="col"></div>
										 
                                </div  >
							<br>	<div class="row" >
									<div class="col-7" >
										<asp:Label id="lblTypeQty" runat="server"></asp:Label> Qty&nbsp</div  >
								
									<div class="col" >
										<asp:textbox id="txtReceiptQty" runat="server" width="99px" CssClass="form-control"></asp:textbox></div  >
								<div class="col"></div>
										 
                                </div  >
							</div>
							<div class="table"> <%--cellSpacing="1" cellPadding="1" width="300"--%>
								<br><div class="row" >
									<div class="col-7" >Remarks&nbsp&nbsp&nbsp&nbsp</div  >
									
									<div class="col" >
										<asp:TextBox id="txtRemarks" runat="server"  width="99px" CssClass="form-control" ></asp:TextBox></div  >
							<div class="col"></div>
										 
                                    </div  >
                             <br>   <div class="table">
								<div class="row" >
									<div class="col"  align="center" colspan="3">
										<asp:Button id="btnSave" runat="server" Text="Save"  Font-Size="20px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark" ></asp:Button>
										<asp:Label id="lblSl" runat="server"></asp:Label></div  >
								</div  >
							</div>
                                </div>
						
							<asp:DataGrid id="DataGrid2" runat="server" CssClass="table">
								<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
								<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
								<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
								<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
							</asp:DataGrid>
                         
				<asp:DataGrid id="DataGrid1" runat="server"  CssClass="table">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<Columns>
						<asp:ButtonColumn Text="Select" CommandName="Select"></asp:ButtonColumn>
						<asp:ButtonColumn Text="Delete" CommandName="Delete"></asp:ButtonColumn>
					</Columns>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>
                </div>
			</asp:Panel>&nbsp;
		</form>
	    </div>
        <div class="card-footer" style="text-align:right;background-color:#cccccc;vertical-align:middle;position:absolute;bottom:0;width:100%;height:60px"><h4 style="color: black;font-size:15px">MAINTAINED BY CRIS</h4></div>
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

                        
</script>
	</body>
</html>
