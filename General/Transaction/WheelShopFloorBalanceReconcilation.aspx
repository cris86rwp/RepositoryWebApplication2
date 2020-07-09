<%@ Page Language="vb" AutoEventWireup="false" Codebehind="WheelShopFloorBalanceReconcilation.aspx.vb" Inherits="WebApplication2.WheelShopFloorBalanceReconcilation" Culture="en-GB" uiCulture="en-GB" %>
<!DOCTYPE HTML>
<HTML xmlns="http://www.w3.org/1999/xhtml">
	<HEAD runat="server">
		<title>WheelShopFloorBalanceOBforNextDay</title>
		
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
             <h1 style="color:white; font-size:30px; margin-left:325px; margin-top:5px">Rail Wheel Plant, Bela</h1> 
       
         </li>
          </ul>
    <ul class="navbar-nav ml-auto  navbar-right">
        <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../../wapframeset.aspx">
          <i class="fab glyphicon glyphicon-home "></i>
        </a></li>

       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../../logon.aspx">
          <i class="fab glyphicon glyphicon-log-out"></i>
        </a></li>
    
        <li class="nav-item ">
        <a class="nav-link p-0" href="#">
          <%--<img src="../../../CRIS-Recruitment.jpg" class="rounded-circle z-depth-0"  height="50" style="border-width: 34px; background-position: 5px 5px; width:50px;margin-top:3px;border-color:white; border-width:50px"/>
        --%><img src="../../NewFolder1/CRIS-Recruitment.jpg" height="45" style="border-radius:43%"/>
       </a>
      </li>
     </ul>
      
  </div>
</nav>
        

<!--/.Navbar -->
        <div class="container">
		<form id="Form1" method="post" runat="server">
           <%--  <div class="row">
    
                  -<h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />
      </div>--%>
            <div class="row"><div class="table">
			<TABLE id="Table1" class="table">
				<div class="row">
					<div class="col" align="middle" colSpan="3"><%--<STRONG><FONT size="4">Wheel 
								Shop Floor Balance Reconcilaton</FONT></STRONG><hr class="prettyline" /></div>--%>
                     <h1 class="heading">
            <asp:Label ID="Heading" runat="server"  Font-Bold="True"   Font-Size="X-Large" Text="Wheel Shop Floor Balance Reconcilation" align="center"></asp:Label>
              </h1>
                        </div>
				</div>
                
                <br />

				<div class="row">
					<div class="col" noWrap align="middle">Message:
					</div>
					<div class="col" colSpan="3" noWrap  rowSpan="1"><asp:label id="lblMessage" runat="server"  Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:label></div>
				<div class="col"><asp:RequiredFieldValidator ID ="rqd" runat="server" ControlToValidate="txtOperator" ErrorMessage="Enter Operato code"></asp:RequiredFieldValidator></div>
                </div>
                 <br />
				<div class="row">
					
				
					
				
				<div class="col" align="middle" >Input Date</div><div class="col"><asp:textbox id="txtInputDate" runat="server" CssClass="form-control"></asp:textbox>  
                  <%--  <asp:ImageButton ID="Imagebutton1" ImageUrl="../../NewFolder1/11.PNG" ImageAlign="Right" runat="server" OnClick="show_date" Height="20px" Width="20px" />
                                
                                <asp:Calendar ID="Cal1" runat="server" >
                                <SelectedDayStyle BackColor="red" />
                                 <DayHeaderStyle BackColor="#FFCC66" Height="1px" Font-Bold="true" />
                                <NextPrevStyle Font-Size="9pt" ForeColor="#FFCC66" />
                                <OtherMonthDayStyle ForeColor="#CC9966" />
                                 <SelectedDayStyle BackColor="#FFCC66" />
                                 <TitleStyle BackColor="#990000" Font-Bold="true" Font-Size="9pt" ForeColor="#FFFFCC" />
                                <TodayDayStyle BackColor="#FFCC66" ForeColor="white" />
                                </asp:Calendar>--%>
                  
                  <%--   <input type="text" id="txtInputDate" name="txtInputDate" readonly required style="width:200px" Class="form-control"/>
                                         --%>
				                                                 </div>
				<div class="col" align="middle">Shift</div><div class="col"><asp:dropdownlist id="ddlShift" runat="server" CssClass="form-control" Width="75px">
							<asp:ListItem Value="G" Selected="True">G</asp:ListItem>
							<asp:ListItem Value="A">A</asp:ListItem>
							<asp:ListItem Value="B">B</asp:ListItem>
							<asp:ListItem Value="C">C</asp:ListItem>
						</asp:dropdownlist></div>
				<div class="col" align="middle">Operator Code</div>	<div class="col"><asp:textbox id="txtOperator" runat="server" CssClass="form-control"></asp:textbox></div>
				</div>
                 <br />
				<div class="row">
					<div class="col" noWrap align="middle" >Closing Balance As On Date</div>
					<div class="col"><asp:textbox id="txtCBForDate" runat="server" CssClass="form-control" ></asp:textbox></div>
						
				<%--</div>
                 <br />
				<div class="row">--%>
					<%--<div class="col" noWrap ><STRONG>Product</STRONG></div>--%>
					<div class="col-6"><STRONG>Product Closing Balance</STRONG> (<EM>Rolls over as OB for next 
							day</EM>)
					</div>
				</div>
                 <br />
				<div class="row">
					<div class="col" align="middle">BoxN</div>
					<div class="col" colSpan="2"><asp:textbox id="txtBoxNQty" runat="server" CssClass="form-control" onkeypress="OnlyNumericEntry()"></asp:textbox></div>
				<%--</div>
                 <br />
                <div class="row">--%>
                <div class="col" align="middle" >BGC</div>
					<div class="col" colSpan="2"><asp:textbox id="txtBGCQty" runat="server" CssClass="form-control" onkeypress="OnlyNumericEntry()"></asp:textbox></div>
				</div>
                 <br />
                <div class="row">
                <div class="col" align="middle">Dispatch</div>
					<div class="col" colSpan="2"><asp:textbox id="txtDisQty" runat="server" CssClass="form-control" onkeypress="OnlyNumericEntry()"></asp:textbox></div>
				<%--</div>
                 <br />
                <div class="row">--%>
                <div class="col" align="middle">Wheels(HT+M/C)</div>
					<div class="col" colSpan="2"><asp:textbox id="txtWhlQty" runat="server" CssClass="form-control" onkeypress="OnlyNumericEntry()"></asp:textbox></div>
				</div>
                 <br />
                
				<%--<%--<div class="row">
					<div class="col" >840</div>
					<div class="col" colSpan="2"><asp:textbox id="txt840Qty" runat="server" CssClass="form-control" onkeypress="OnlyNumericEntry()"></asp:textbox></div>
				</div>--%>
				<%--<div class="row">
					
				<div class="row">
					<div class="col" >MGC</div>
					<div class="col" colSpan="2"><asp:textbox id="txtMGCQty" runat="server" CssClass="form-control" onkeypress="OnlyNumericEntry()"></asp:textbox></div>
				</div>
				<div class="row">
					<div class="col" >915 as CAST</div>
					<div class="col" colSpan="2">
						<asp:textbox id="txt915DQty" runat="server" CssClass="form-control" onkeypress="OnlyNumericEntry()"></asp:textbox></div>
				</div>
				<div class="row">
					<div class="col" >EMUBG</div>
					<div class="col" colSpan="2">
						<asp:TextBox id="txtEMUBGQty" runat="server" CssClass="form-control" onkeypress="OnlyNumericEntry()"></asp:TextBox></div>
				</div>
				<div class="row">
					<div class="col" >EMU (ROUGH)</div>
					<div class="col" colSpan="2">
						<asp:TextBox id="txtEMUQty" runat="server" CssClass="form-control" onkeypress="OnlyNumericEntry()"></asp:TextBox></div>
				</div>
				<div class="row">
					<div class="col">Others</div>
					<div class="col" colSpan="2"><asp:textbox id="txtOthersQty" runat="server" CssClass="form-control" onkeypress="OnlyNumericEntry()"></asp:textbox></div>
				</div>--%>
                <br />
				<div class="row">
					<div class="col" align="middle"  colSpan="3"><asp:button id="btnSave" runat="server"  BorderStyle="Solid" Font-Bold="True" Font-Size="20px" CssClass="btn btn-dark" Text="Save"></asp:button></div>
				</div>
                
			</TABLE>
		</div></div>
            <div class="row">
             <asp:datagrid id="WheelShopCB" CssClass="table" runat="server" CellPadding="1" CellSpacing="1" AutoGenerateColumns="False" forecolor="Black" OnItemDataBound="OnItemDataBound">
                    <AlternatingItemStyle BackColor="White"></AlternatingItemStyle>
                    <HeaderStyle ForeColor="White" BackColor="Navy"></HeaderStyle>
                    <Columns><asp:TemplateColumn HeaderText = "S.No" ItemStyle-Width="100">
        <ItemTemplate>
            <asp:Label ID="lblRowNumber" runat="server" />
            
        </ItemTemplate>
    </asp:TemplateColumn>
    
                    <asp:ButtonColumn Text="Select" HeaderText="Select" CommandName="Select"></asp:ButtonColumn>
                           <asp:BoundColumn DataField="InputDate" HeaderText="Date"></asp:BoundColumn>
                    <asp:BoundColumn DataField="InputShift" HeaderText="Shift"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Operator_code" HeaderText="Operator"></asp:BoundColumn>
                    <asp:BoundColumn DataField="ProductCode" HeaderText="Product Code"></asp:BoundColumn>
                    <asp:BoundColumn DataField="CBforDate" HeaderText="Closing Balance for Date"></asp:BoundColumn>
                    <asp:BoundColumn DataField="CBQty" HeaderText="CB Quantity"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Dispatch" HeaderText="Dispatch"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Wheels" HeaderText="Wheels"></asp:BoundColumn>
                    </Columns>
                    </asp:datagrid></div></TD>
		</form></div>
        <div class="card-footer" style="text-align:right;background-color:#cccccc;bottom:0;width:100%;vertical-align:middle;height:60px"><h4 style="color: black;font-size:15px">MAINTAINED BY CRIS</h4></div>

    <%--    <div class="card-footer" style="text-align:right;background-color:#cccccc"><h4>MAINTAINED BY CRIS</h4></div>--%>
    <%--     <script type="text/javascript">
$(document).ready(function () {
                       
                        $('#txtInputDate').datepicker({
                            dateFormat: "dd-mm-yy", 
                       
                            onSelect: function(date){            
                                var date1 = $('#txtInputDate').datepicker('getDate');           
                                                 
                              
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
--%>


                        
</script>
	</body>
</HTML>
