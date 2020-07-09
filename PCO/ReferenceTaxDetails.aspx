<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ReferenceTaxDetails.aspx.vb" Inherits="WebApplication2.ReferenceTaxDetails" %>
<!DOCTYPE HTML>
<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title>ReferenceTaxDetails</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
         <meta charset="utf-8"/>
  <meta name="viewport" content="width=device-width, initial-scale=1"/>
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css"/>
  <script  src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.6/umd/popper.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/js/bootstrap.min.js"></script>
         <link type="text/css" rel="stylesheet" href="https://cdn.datatables.net/1.10.9/css/dataTables.bootstrap.min.css" />
    <link type="text/css" rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" />
    <link type="text/css" rel="stylesheet" href="https://cdn.datatables.net/responsive/1.0.7/css/responsive.bootstrap.min.css" />
    <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.9/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/responsive/1.0.7/js/dataTables.responsive.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.9/js/dataTables.bootstrap.min.js"></script>
    <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>

        <%-- <link rel="stylesheet" href="../StyleSheet1.css" />--%>
        <script>
             function isNumber1(evt, element) {

                    var charCode = (evt.which) ? evt.which : event.keyCode

                      if (
                           (charCode != 45 ) && (charCode != 47 ) &&     // 
                           (charCode < 48 || charCode > 57))
                      return false;

                  return true;
            } 
        </script>
	</head>
	<body>
       <nav class="mb-1 navbar navbar-expand-sm bg-dark navbar-dark " >
  <a class="navbar-brand p-0" href="#"><img src="../NewFolder1/unnamed.png" class="rounded-circle z-depth-0"  height="45"/> </a>
  <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent-333"
    aria-controls="navbarSupportedContent-333" aria-expanded="false" aria-label="Toggle navigation">
    <span class="navbar-toggler-icon"></span>
  </button>
  <div class="collapse navbar-collapse " id="navbarSupportedContent-333" >
      <ul class="navbar-nav ml-auto navbar-center">
         <li class="nav-item" style="font-weight: bold">
             <h1 style="color:white; font-size:30px; margin-left:325px; margin-top:5px">Rail Wheel Plant, Bela</h1> 
       
         </li>
          </ul>
    <ul class="navbar-nav ml-auto  navbar-right">
        <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../wapframeset.aspx">
          <i class="fab glyphicon glyphicon-home " style="font-size:30px;"></i>
        </a></li>

       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../logon.aspx">
          <i class="fab glyphicon glyphicon-log-out" style="font-size:30px;"></i>
        </a></li>
    
        <li class="nav-item ">
        <a class="nav-link p-0" href="#">
          <%--<img src="../../../CRIS-Recruitment.jpg" class="rounded-circle z-depth-0"  height="50" style="border-width: 34px; background-position: 5px 5px; width:50px;margin-top:3px;border-color:white; border-width:50px"/>
        --%><img src="../NewFolder1/CRIS-Recruitment.jpg" height="45" style="border-radius:43%"/>
       </a>
      </li>
     </ul>
      
  </div>
</nav>
      
  
<!--/.Navbar -->

         
         <div class="container">
              <div class="row">
                <div class="table">
       
		<form id="Form1" method="post" runat="server">
           <%-- <h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>--%>
                 <br />
			<asp:panel id="Panel1" runat="server">
			<%--	<TABLE id="Table1" class="table">--%>
                    <div  class="table">
					<div class="row">
						<div class="col" align="center"><h2>Invoice TAX Details</h2></div>
					</div>
				<%--</TABLE>--%><div class="row">
				<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label></div></div><%--</TABLE>--%>
				<%--<TABLE id="Table3" class="table">--%>
                <div  class="table">
					<div class="row">
						<div class="col">
							<asp:RadioButtonList id="rblGroup" runat="server" CssClass="rbl" AutoPostBack="True" RepeatLayout="Flow" RepeatDirection="Horizontal">
								<asp:ListItem Value="MRKTING" Selected="True">MRKTING</asp:ListItem>
								<asp:ListItem Value="PCOPCO">PCOPCO</asp:ListItem>
								<asp:ListItem Value="WARD30">WARD30</asp:ListItem>
								<asp:ListItem Value="C&amp;F">C&amp;F</asp:ListItem>
							</asp:RadioButtonList></div>
					</div></div>
				<%--</TABLE>--%>
				<asp:Panel id="pnlPCO" runat="server">
					<TABLE id="Table12" class="table">
						<div class="row">
							<div class="col-3">Dispatch Advice No</div>
							<div class="col-4" colSpan="2">
								<asp:DropDownList id="ddlDespatchAdviceNo" CssClass="form-control ll" runat="server" AutoPostBack="True" Width="150px"></asp:DropDownList></div>
						</div>
					</TABLE>
				</asp:Panel>
				<asp:Panel id="pnlMrk" runat="server">
					<TABLE id="Table2" class="table">
						<div class="row">
							<div class="col">ReferenceID</div>
							<div class="col">:</div>
							<div class="col">
								<asp:DropDownList id="ddlRefID" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:DropDownList></div>
						</div>
					</TABLE>
				</asp:Panel>
				<asp:Panel id="pnlWard" runat="server">
					<TABLE id="Table15" class="table">
						<div class="row">
							<div class="col">SaleOrders</div>
							<div class="col">
								<asp:DropDownList id="ddlSaleOrders" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:DropDownList></div>
						</div>
					</TABLE>
					
				</asp:Panel>
				<asp:Panel id="pnlInvoice" runat="server">
					<TABLE id="Table14" class="table">
						<div class="row">
							<div class="col-3">InvoiceNo</div>
							<div class="col-4">
								<asp:RadioButtonList id="rblInvoice" runat="server" CssClass="rbl" AutoPostBack="True" RepeatLayout="Flow" RepeatDirection="Horizontal"></asp:RadioButtonList></div>
						</div>
					</TABLE>
					<TABLE id="Table13" class="table">
						<div class="row">
							<div class="col-3">WagonLorryNo</div>
							<div class="col-4">
								<asp:Label id="lblWagonNo" runat="server"></asp:Label></div>
						</div>
					</TABLE>
				</asp:Panel>
				<asp:Panel id="pnlGen" runat="server">
					<TABLE id="Table4" class="table">
						<div class="row">
							<div class="col"colSpan="3">InvoiceDate</div>
							<div class="col">
								<asp:TextBox id="txtInvoiceDate" runat="server" CssClass="form-control" onkeypress="return isNumber1(event,this)" MaxLength="10" placeholder="dd/mm/yyyy"></asp:TextBox></div>
							<div class="col">TotalValue</div>
							<div class="col">
								<asp:TextBox id="txtTotalValue" runat="server" CssClass="form-control"></asp:TextBox></div>
							<div class="col">TaxableValue</div>
							<div class="col">
								<asp:TextBox id="txtTaxableValue" runat="server" CssClass="form-control"></asp:TextBox></div>
						</div>
					</TABLE>
					<TABLE id="Table5" class="table">
						<div class="row">
							<div class="col-2">Goods A/c HSN
							</div>
							<div class="col-2">
								<asp:TextBox id="txtGoodsHSN" runat="server" CssClass="form-control"></asp:TextBox></div>
							<div class="col-2">GoodsDescription</div>
							<div class="col-2">
								<asp:TextBox id="txtGoodsDescription" runat="server" CssClass="form-control"></asp:TextBox></div>
                            <div class="col">EligibleForITC</div>
							<div class="col">
								<asp:RadioButtonList id="RadioButtonList1" runat="server" CssClass="rbl" RepeatLayout="Flow" RepeatDirection="Horizontal">
									<asp:ListItem Value="0" Selected="True">No</asp:ListItem>
									<asp:ListItem Value="1">Yes</asp:ListItem>
								</asp:RadioButtonList></div>
						</div>
						</div>
					</TABLE>
					<TABLE id="Table6" class="table">
						<div class="row">
							<div class="col">UnitCode</div>
							<div class="col">
								<asp:DropDownList id="ddlUnitCode" runat="server" CssClass="form-control"></asp:DropDownList></div>
							<div class="col">Quantity</div>
							<div class="col">
								<asp:TextBox id="txtQuantity" runat="server" CssClass="form-control"></asp:TextBox></div>
							<div class="col">Rate</div>
							<div class="col">
								<asp:TextBox id="txtRate" runat="server" CssClass="form-control"></asp:TextBox></div>
							<%--<div class="col">EligibleForITC</div>
							<div class="col">
								<asp:RadioButtonList id="rblITC" runat="server" CssClass="rbl" RepeatLayout="Flow" RepeatDirection="Horizontal">
									<asp:ListItem Value="0" Selected="True">No</asp:ListItem>
									<asp:ListItem Value="1">Yes</asp:ListItem>
								</asp:RadioButtonList></div>--%>
						</div>
					</TABLE>
					<TABLE id="Table7" class="table">
                        <div class="row">
							<div class="col-sm">IGSTRate</div>
							<div class="col" style="padding-left:45px">
								<asp:TextBox id="txtIGSTRate" runat="server" CssClass="form-control" AutoPostBack="True" width="48px" ></asp:TextBox></div>
							<div class="col-sm">CGSTRate</div>
							<div class="col">
								<asp:TextBox id="txtCGSTRate" runat="server" CssClass="form-control" AutoPostBack="True" width="48px"></asp:TextBox></div>
							<div class="col">SGSTRate</div>
							<div class="col">
								<asp:TextBox id="txtSGSTRate" runat="server" CssClass="form-control" AutoPostBack="True" width="48px"></asp:TextBox></div>
							<div class="col">UGSTRate</div>
							<div class="col">
								<asp:TextBox id="txtUGSTRate" runat="server" CssClass="form-control" AutoPostBack="True" width="48px"></asp:TextBox></div>
							<div class="col">CessRate</div>
							<div class="col">
								<asp:TextBox id="txtCessRate" runat="server" CssClass="form-control" AutoPostBack="True" width="48px"></asp:TextBox></div>
							</div>
                        <br />
                        <div class="row">
                            <div class="col">IGSTCharged Amount</div>
							<div class="col">
								<asp:TextBox id="txtIGSTChargedAmt" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox></div>
						<div class="col">CGSTCharged Amount</div>
							<div class="col">
								<asp:TextBox id="txtCGSTChargedAmt" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox></div>
						<div class="col">SGSTCharged Amount</div>
							<div class="col">
								<asp:TextBox id="txtSGSTChargedAmt" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox></div>
						<div class="col">UGSTCharged Amount</div>
							<div class="col">
								<asp:TextBox id="txtUGSTChargedAmt" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox></div>
							<div class="col">CessCharged Amount</div>
							<div class="col">
								<asp:TextBox id="txtCessChargedAmt" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox></div>
						


                            </div>
						<%--<div class="row">
							<div class="col">IGSTRate</div>
							<div class="col">
								<asp:TextBox id="txtIGSTRate" runat="server" CssClass="form-control" AutoPostBack="True"></asp:TextBox></div>
							<div class="col">IGSTChargedAmt</div>
							<div class="col">
								<asp:TextBox id="txtIGSTChargedAmt" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox></div>
						</div>
						<div class="row">
							<div class="col">CGSTRate</div>
							<div class="col">
								<asp:TextBox id="txtCGSTRate" runat="server" CssClass="form-control" AutoPostBack="True"></asp:TextBox></div>
							<div class="col">CGSTChargedAmt</div>
							<div class="col">
								<asp:TextBox id="txtCGSTChargedAmt" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox></div>
						</div>
						<div class="row">
							<div class="col">SGSTRate</div>
							<div class="col">
								<asp:TextBox id="txtSGSTRate" runat="server" CssClass="form-control" AutoPostBack="True"></asp:TextBox></div>
							<div class="col">SGSTChargedAmt</div>
							<div class="col">
								<asp:TextBox id="txtSGSTChargedAmt" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox></div>
						</div>
						<div class="row">
							<div class="col">UGSTRate</div>
							<div class="col">
								<asp:TextBox id="txtUGSTRate" runat="server" CssClass="form-control" AutoPostBack="True"></asp:TextBox></div>
							<div class="col">UGSTChargedAmt</div>
							<div class="col">
								<asp:TextBox id="txtUGSTChargedAmt" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox></div>
						</div>
						<div class="row">
							<div class="col">CessRate</div>
							<div class="col">
								<asp:TextBox id="txtCessRate" runat="server" CssClass="form-control" AutoPostBack="True"></asp:TextBox></div>
							<div class="col">CessChargedAmt</div>
							<div class="col">
								<asp:TextBox id="txtCessChargedAmt" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox></div>
						</div>--%>
					</TABLE>
					<TABLE id="Table8" class="table">
						<div class="row">
							<div class="col-3">Name /Recipient of Service/Goods</div>
							<div class="col-4">
								<asp:TextBox id="txtGoodsName" runat="server" CssClass="form-control"></asp:TextBox></div>
                            <div class="col-3">Tax Payable on Reverse Charge basis</div>
							<div class="col-2">
								<asp:RadioButtonList id="rblReverseTax" runat="server" CssClass="rbl" RepeatLayout="Flow" RepeatDirection="Horizontal">
									<asp:ListItem Value="0" Selected="True">No</asp:ListItem>
									<asp:ListItem Value="1">Yes</asp:ListItem>
								</asp:RadioButtonList></div>
						</div>
					</TABLE>
					<TABLE id="Table9" class="table">
						<div class="row">
							<div class="col">Place Of Supply</div>
							<div class="col">
								<asp:TextBox id="txtPlaceOfSupply" runat="server" CssClass="form-control"></asp:TextBox></div>
							<div class="col">Recepient GSTIN</div>
							<div class="col-3">
								<asp:TextBox id="txtRecepientGSTIN" runat="server" CssClass="form-control"></asp:TextBox></div>
                            <div class="col-1">TDS</div>
							<div class="col">
								<asp:TextBox id="txtTDS" runat="server" CssClass="form-control"></asp:TextBox></div>
						</div>
					</TABLE>
					<%--<TABLE id="Table10" class="table">
						<div class="row">
							<div class="col">Tax Payable on Reverse Charge basis</div>
							<div class="col">
								<asp:RadioButtonList id="RadioButtonList1" runat="server" CssClass="rbl" RepeatLayout="Flow" RepeatDirection="Horizontal">
									<asp:ListItem Value="0" Selected="True">No</asp:ListItem>
									<asp:ListItem Value="1">Yes</asp:ListItem>
								</asp:RadioButtonList></div>
							
						</div>
					</TABLE>--%>
					<TABLE id="Table11" class="table">
						<div class="row">
							<div class="col" align="middle" colspan="3">
								<asp:Button id="btnSave" runat="server"  Text="Save Details" orderStyle="Solid" Font-Bold="True" Font-Size="20px" CssClass="btn btn-dark"></asp:Button></div>
						</div>
					</TABLE>
					<asp:DataGrid id="DataGrid1" runat="server" CssClass="table" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966">
						<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
						<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
						<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
						<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
						<Columns>
							<asp:ButtonColumn Text="Select" CommandName="Select"></asp:ButtonColumn>
						</Columns>
						<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
					</asp:DataGrid>
				</asp:Panel>
			</asp:panel></form>
                     </div></div></div> 
        <div class="card-footer" align="middle" style="text-align:right;background-color:#cccccc;vertical-align:middle;height:45px"><h4 style="color: black;font-size:15px">MAINTAINED BY CRIS</h4></div>
		 <script type="text/javascript">
$(document).ready(function () {
                       
                        $('#txtInvoiceDate').datepicker({
                            dateFormat: "dd-mm-yy", 
                       
                            onSelect: function(date){            
                                var date1 = $('#txtInvoiceDate').datepicker('getDate');           
                                                 
                              
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
