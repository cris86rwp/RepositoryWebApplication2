<%@ Page Language="vb" AutoEventWireup="false" Codebehind="CriticalStockItemListDelete.aspx.vb" Inherits="WebApplication2.CriticalStockItemListDelete" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>CriticalStockItemListDelete</title>
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
	<body>
           
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
          <i class="fab glyphicon glyphicon-home "  style="font-size:30px"></i>
        </a></li>

       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../../logon.aspx">
          <i class="fab glyphicon glyphicon-log-out"  style="font-size:30px"></i>
        </a></li>
    
        <li class="nav-item ">
        <a class="nav-link p-0" href="#">
         
        <img src="../../../NewFolder1/CRIS-Recruitment.jpg" height="45" style="border-radius:43%"/>
       </a>
      </li>
     </ul>
      
  </div>
</nav>  
 	<form id="Form1" method="post" runat="server">
<div class="container">

<div class="table">
     
                
    
                             <%-- <h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                             <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                                 <asp:ListItem>select</asp:ListItem>
                                 <asp:ListItem>Theme1</asp:ListItem>
                                 <asp:ListItem>Theme2</asp:ListItem>
                                 <asp:ListItem>Theme3</asp:ListItem>
                             </asp:DropDownList>
                             <br />--%>
       
							<div class="row">
								<div class="col" align="center"><FONT size="5"><asp:label id="lblConsignee" runat="server"></asp:label>&nbsp;Critical 
										Item List - Stock</FONT>&nbsp; (Delete)
								</div>
							</div><br />
							<div class="row">
								<div class="col"><asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></div>
							</div><br />
							<div class="row">
								<div class="col">Pl Number</div>
								
								<div class="col" ><asp:dropdownlist id="ddlPLNumber" runat="server" AutoPostBack="True" CssClass="form-control ll" Width="103px"></asp:dropdownlist></div>
								<div class="col">Sl No</div>
								
								<div class="col"><asp:textbox id="txtSlNo" runat="server" CssClass="form-control" AutoPostBack="True" Width="103px"></asp:textbox></div>
							
								<div class="col">Pl Desc</div>
							
								<div class="col"><asp:label id="lblPlDesc" runat="server" Width="103px"></asp:label>&nbsp;</div>
							</div><br />
							<div class="row">
								<div class="col">Recoup Type</div>
						
								<div class="col"><asp:label id="lblRecoupType" runat="server" Width="103px"></asp:label>&nbsp;</div>
								<div class="col">Recoup Qty</div>
								
								<div class="col"><asp:label id="lblRecoupQty" runat="server" Width="103px"></asp:label>&nbsp;</div>
							
								<div class="col">Last Issue Dt</div>
							
								<div class="col"><asp:label id="lblLastIssueDate" runat="server" Width="103px"></asp:label>&nbsp;</div>
								</div><br />
							<div class="row">
                                <div class="col">Equipment</div>
							
								<div class="col"><asp:textbox id="txtEquip" runat="server" CssClass="form-control" Width="103px"></asp:textbox></div>
							
								<div class="col">Number</div>
								
								<div class="col"><asp:textbox id="txtNum" runat="server" CssClass="form-control" Width="103px"></asp:textbox></div>
								<div class="col">Date</div>
						
								<div class="col" ><asp:textbox id="txtDt" runat="server" CssClass="form-control" Width="103px"></asp:textbox></div>
								</div><br />
							<div class="row">
                                <div class="col">Qty</div>
								
								<div class="col"><asp:textbox id="txtQty" runat="server" CssClass="form-control" Width="103px"></asp:textbox></div>
							
								<div class="col">Supplier</div>
								
								<div class="col"><asp:textbox id="txtSup" runat="server" CssClass="form-control" Width="103px"></asp:textbox></div>
                                <div class="col">DD</div>
									<div class="col"><asp:textbox id="txtDD" runat="server" CssClass="form-control" Width="103px"></asp:textbox></div>
							</div><br />
							<div class="row">
								<div class="col">Recd Qty</div>
							
								<div class="col"><asp:textbox id="txtRecdQty" runat="server" CssClass="form-control" Width="103px"></asp:textbox></div>
								<div class="col">Qty UT</div>
								
								<div class="col"><asp:textbox id="txtQtyUT" runat="server" CssClass="form-control" Width="103px"></asp:textbox></div>
								<div class="col">Qty Due</div>
							
								<div class="col"><asp:textbox id="txtQtyDue" runat="server" CssClass="form-control" Width="103px"></asp:textbox></div>
							</div><br />
							<div class="row">
								<div class="col">Remarks</div>
								
								<div class="col"><asp:textbox id="txtRemarks" runat="server" CssClass="form-control" Width="103px"></asp:textbox></div>
                                <div class="col"></div>
                                    <div class="col"></div>
                                    <div class="col"></div>
                                    <div class="col"></div>
							</div><br />
							<div class="row">
								<div class="col" align="center">
                                 
                                    <asp:button id="btnSave" runat="server" Text="Delete"  Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark" ></asp:button>
						
                                    <asp:label id="lblRecID" runat="server" Visible="False"></asp:label></div></div>
							</div>
    
						
						<asp:datagrid id="dgSavedData" runat="server" Font-Size="Smaller" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="3" GridLines="Vertical" CssClass="Table">
							<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
							<AlternatingItemStyle BackColor="Gainsboro"></AlternatingItemStyle>
							<ItemStyle ForeColor="Black" BackColor="#EEEEEE"></ItemStyle>
							<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#000084"></HeaderStyle>
							<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
							<Columns>
								<asp:ButtonColumn Text="Delete" CommandName="Delete"></asp:ButtonColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
						</asp:datagrid>
				
			
    </div>
    
		</form>
        <div class="card-footer" style="text-align:right;background-color:#cccccc;vertical-align:middle;position:absolute;bottom:0;width:100%;height:60px"><h4 style="color: black;font-size:15px">MAINTAINED BY CRIS</h4></div>
  			<script type="text/javascript">
     $(document).ready(function () {
                       
                        $('#txtDt').datepicker({
                            dateFormat: "yy/mm/dd", 
                       
                            onSelect: function(date){            
                                var date1 = $('#txtDt').datepicker('getDate');           
                                                 
                              
                            }
                        });
    
  function getDate( element ) {
    var date;
    var dateFormat = "yyyy/MM/dd";
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
 