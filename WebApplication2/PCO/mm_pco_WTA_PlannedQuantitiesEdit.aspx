<%@ Page Language="vb" AutoEventWireup="false" Codebehind="mm_pco_WTA_PlannedQuantitiesEdit.aspx.vb" Inherits="WebApplication2.mm_pco_WTA_PlannedQuantitiesEdit" %>
<!DOCTYPE HTM>
<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title>mm_pco_WTA_PlannedQuantitiesEdit</title>
		
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
              function isNumber1(evt, element) {

                    var charCode = (evt.which) ? evt.which : event.keyCode

                      if (
                           (charCode != 45 ) && (charCode != 47 ) &&     // 
                           (charCode < 48 || charCode > 57))
                      return false;

                  return true;
            }
            function OnlyNumericEntry() {
        if ((event.keyCode < 48 || event.keyCode > 57)) {
        event.returnValue = false;
    }
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
        <%--  <h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />--%>
     
			<div  class="table">
				<div class="row">
					<div class="col" align="center"><h2>WTA Planned Quantities</h2></div>
				</div>
				<div class="row">
					<div class="col" colSpan="3">Mode :
						<asp:label id="lblMode" runat="server" ></asp:label></div>
				</div>
                <br />
				<div class="row">
					<div class="col" colSpan="3">Message<asp:label id="lblMessage" runat="server" ForeColor="Red" ></asp:label></div>
				</div>
                <br />
				<div class="row">
					<div class="col">Product Code--Desc</div>
					<%--<div class="col">:</div>--%>
					<div class="col"><asp:dropdownlist id="ddlProductCode" runat="server" AutoPostBack="True" CssClass="form-control ll"></asp:dropdownlist></div>
			<%--	</div>
				<div class="row">--%>
					<div class="col">WTA Number--Date </div>
					<%--<div class="col">:</div>--%>
					<div class="col"><asp:dropdownlist id="ddlWTANumber" runat="server" AutoPostBack="True" CssClass="auto-style1 form-control ll"></asp:dropdownlist></div>
				</div>
                <br />
				<div class="row">
					<div class="col">WTA Order--Date</div>
					<%--<div class="col">:</div>--%>
					<div class="col"><asp:dropdownlist id="ddlOrderNumber" runat="server" AutoPostBack="True" CssClass="form-control ll"></asp:dropdownlist></div>
				<%--</div>
                <br />
				<div class="row">--%>
					<div class="col">Quantity Date</div>
					<%--<div class="col">:</div>--%>
					<div class="col"><asp:textbox id="txtQuantityDate" runat="server" AutoPostBack="True" CssClass="form-control" onkeypress="return isNumber1(event,this)" MaxLength="10" placeholder="dd/mm/yyyy"></asp:textbox><asp:label id="lblQtyDt" runat="server" Visible="False" CssClass="form-control"></asp:label></div>
				</div>
                <br />
				<div class="row">
					<div class="col">Order Quantity</div>
					<%--<div class="col">:</div>--%>
					<div class="col"><asp:textbox id="txtOrderQty" runat="server" AutoPostBack="True" CssClass="form-control" ToolTip="enter Order Qty(only numeric)" onkeypress="OnlyNumericEntry()"></asp:textbox></div>
				<%--</div>
				<div class="row">--%>
					<div class="col">Remarks</div>
					<%--<div class="col">:</div>--%>
					<div class="col"><asp:textbox id="txtPlanRemarks" runat="server" CssClass="form-control" MaxLength="250"></asp:textbox></div>
				</div>
                </div>
                 <div class="table">
				<div class="row">
					<div class="col" vAlign="top" align="center" ><asp:button id="btnSave" runat="server" Text="Save" borderStyle="Solid" Font-Bold="True" Font-Size="20px" CssClass="btn btn-dark"></asp:button></div>
				</div>
                </div>
            
            <div class="table-responsive">
				<div class="row">

					<div class="col" vAlign="top" align="left" colSpan="3"><asp:datagrid id="dgData" runat="server" BorderColor="#3366CC" CssClass="table">
							<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
							<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
							<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
							<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
							<Columns>
								<asp:ButtonColumn Text="Select" CommandName="Select"></asp:ButtonColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></div>
				</div>
			</div>
               
                
		</form>
           </div></div></div>
      <div class="card-footer" style="text-align:right;background-color:#cccccc;vertical-align:middle;height:45px;width:100%"><h4 style="color: black;font-size:15px">MAINTAINED BY CRIS</h4></div>
	 <script type="text/javascript">
$(document).ready(function () {
                       
                        $('#txtQuantityDate').datepicker({
                            dateFormat: "dd/mm/yy", 
                       
                            onSelect: function(date){            
                                var date1 = $('#txtQuantityDate').datepicker('getDate');           
                                                 
                              
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
