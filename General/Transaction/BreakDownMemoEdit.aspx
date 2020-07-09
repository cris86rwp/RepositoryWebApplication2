<%@ Page Language="vb" AutoEventWireup="false" Codebehind="BreakDownMemoEdit.aspx.vb" Inherits="WebApplication2.BreakDownMemoEdit" Culture="en-GB" uiCulture="en-GB" %>
<!DOCTYPE HTML >
<HTML>
	<HEAD runat="server">
		<title>BreakDownMemo Edit</title>
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
 
       <%-- <link rel="stylesheet" href="../../StyleSheet1.css" />--%>
     
     
	    <style type="text/css">
            .auto-style1 {
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

                      input[type=text]
    {
        padding: 5px 40px;
        width:50%;
        border:none;
        outline: none;
        font-weight: bold;
    }
                    .ui-datepicker {
    background: #333;
    border: 1px solid #555;
    color: #EEE;
}
        </style>
	</HEAD>
	<BODY style="overflow-x:hidden">

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
          <i class="fab glyphicon glyphicon-log-out" style="font-size:30px"> </i>
        </a></li>
   
        <li class="nav-item ">
        <a class="nav-link p-0" href="#">
         
        <img src="../../NewFolder1/CRIS-Recruitment.jpg" height="45" style="border-radius:43%"/>
       </a>
      </li>
     </ul>
     
  </div>
</nav>
<!--/.Navbar -->
		<div class="container" align="cenetr">
        <FORM id="Form1" method="post" runat="server">
         <%--   <div class="row">
    
                  <h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />
      </div>--%>
             <div class="row">
               
			        <asp:panel id="Panel1" runat="server">

                            <div class="container">
								<div class="row">
									<div class="col">
                                <strong><h2 align="middle" >Break Down Edit
                                        </h2></strong> 
                                     </div>
                                    </div>
                                    <div class="row">
									<div class="col-6">
                                         <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                                     </div>
                                    </div>
                                      <div class="row">
									<div class="col-3">Department</div>
                                         <div class="col-3">
                                             <asp:Label ID="lblDepartment_code" runat="server">M</asp:Label>
                                         </div>
                                         <div class="col-3">Shop Code</div>
                                             <div class="col-3"><asp:CheckBox ID="chkExtEdit" runat="server" AutoPostBack="True" CssClass="checkbox" Text="Ext.Edit" ></asp:CheckBox>
                                         </div>
                                         <div class="col-3">
                                             <asp:RadioButtonList ID="rblShop" runat="server" AutoPostBack="True" CssClass="rbl" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                             </asp:RadioButtonList>
                                         </div>
                                     </div>

                                    <div class="row">
									<div class="col-3">Group </div>
                                        <div class="col-3">
                                             <asp:Label ID="lblGroupCode" runat="server"></asp:Label>
                                         </div>
                                         
                                         <div class="col-3">Operator</div>
                                         <div class="col-3"><asp:TextBox ID="txtOperator" runat="server" BackColor="Silver" CssClass="form-control" style="width:200px" placeholder="Enter Operator No."></asp:TextBox>
                                         </div>
                                     </div>
                                <br />

                                     <div class="row">
									<div class="col-3">Memo No</div>
                                         
                                         <div class="col-3">
                                             <asp:Label ID="lblMemoNumber" runat="server"></asp:Label>
                                         </div>
                                         <div class="col-3">Machine Code </div>
                                         <div class="col-3">
                                             <asp:Label ID="lblMachineCode" runat="server"></asp:Label>
                                         </div>
                                     </div>
                                <br />
                                       <div class="row">
									<div class="col-3">Memo Slip No</div>
                                         
                                        <div class="col-3">
                                             <asp:Label ID="lblMemoSlipNumber" runat="server"></asp:Label>
                                         </div>
                                         <div class="col-3">BD Code Type </div>
                                         <div class="col-3">
                                             <asp:Label ID="lblBDCodeType" runat="server"></asp:Label>
                                         </div>
                                     </div>
                                <br />
                                   <div class="row">
									<div class="col-3">Break Down Details </div>
                                             <div class="col-3"></div>
                                         
                                             <%--<asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="txtBDnToTime" ErrorMessage="CustomValidator"></asp:CustomValidator>--%>
									<div class="col-3">Production Affected </div>
									<div class="col-3">
                                             <asp:DropDownList ID="ddlProductionAffected" runat="server" CssClass="form-control l" style="width:200px">
                                                 <asp:ListItem Value="1">Yes</asp:ListItem>
                                                 <asp:ListItem Selected="True" Value="0">No</asp:ListItem>
                                             </asp:DropDownList>
                                         </div>
                                     </div>
                                <br />
                                     <%--<p><Date: <input type="text" id="fromDate"> TO <input type="text" id="toDate"></p>--%>
                                       <div class="row">
									<div class="col-3">From Date</div>
                                        <div class="col-3">
                                            <asp:TextBox ID="txtBDnFromDate" runat="server" CssClass="form-control" placeholder="select Date" Enabled="True" style="width:200px"></asp:TextBox>
                                            <%-- <input type="text" id="txtBDnFromDate" name="txtBDnFromDate" readonly required style="width:200px" placeholder="select Date" Class="form-control"/>--%>
                                         </div>
                                         <div class="col-3">To Date</div>
                                        <div class="col-3">
                                            <asp:TextBox ID="txtBDnToDate" runat="server" CssClass="form-control" placeholder="select Date" Enabled="True" style="width:200px;"></asp:TextBox>
                                             <%--<input type="text" id="txtBDnToDate" name="txtBDnToDate" readonly required style="width:200px;" placeholder="select Date" Class="form-control"/>--%>
                                         </div>
                                     </div>
                                <br />
                                     <%--  <tr>
                        <td>From date</td>
                        <td></td>
                        <td>--%><%--<asp:TextBox ID="txtBDnFromDate" runat="server" CssClass="form-control" placeholder="select Date" Enabled="True"></asp:TextBox>--%><%--<asp:ImageButton ID="ImageButton1" ImageUrl="~/IMAGES/cal1.png" ImageAlign="Bottom" runat="server" OnClick="show_date" Height="27px" Width="40px" />
                            <asp:Calendar ID="Calendar1" runat="server" Visible="false" onselectionchanged="Date_Selected"></asp:Calendar>--%><%-- <asp:RequiredFieldValidator runat="server" ID="RequFilesStart" ControlToValidate="txtBDnFromDate" ErrorMessage="Enter Selection From date!" ValidationGroup="validation1"> </asp:RequiredFieldValidator>--%><%--  </td>
                        <td>To Date</td>
                        <td></td>
                        <td>--%><%-- <asp:TextBox ID="txtBDnToDate" runat="server" CssClass="form-control" placeholder="select Date" Enabled="True"></asp:TextBox>--%><%--<asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/IMAGES/cal1.png"  ImageAlign="Bottom" OnClick="show_date1" Height="27px" Width="40px"/>
                            <asp:Calendar ID="Calendar2" runat="server" Visible="false" onselectionchanged="Date_Selected1"></asp:Calendar>--%><%-- <asp:RequiredFieldValidator runat="server" ID="ReqFiledEnd" ControlToValidate="txtBDnToDate" ErrorMessage="Enter Selection To date!" ValidationGroup="validation1"></asp:RequiredFieldValidator>
             
                         <asp:CompareValidator ID="CompareValSelDate" runat="server" 
            ControlToValidate="txtBDnToDate"
            ControlToCompare="txtBDnFromDate" 
            CultureInvariantValues="true" Type="Date"
            Operator="GreaterThanEqual" ValidationGroup="validation1" 
            ErrorMessage="Selection End Date should be greater then Selected start date"
            Display="dynamic"></asp:CompareValidator>   --%><%-- <asp:CustomValidator runat="server" ID="datesValidator" OnServerValidate="DatesValidator_Validate" ErrorMessage="end date should be greater than  or equal to start date"></asp:CustomValidator>--%><%-- </td>
                    </tr>
                    <tr>--%>
                                     <div class="row">
									<div class="col-3">Time</div>
                                         <div class="col-3">
                                             <asp:TextBox ID="txtBDnFromTime" runat="server" AutoPostBack="True" BackColor="#CCCCCC" CssClass="form-control" placeholder="(hh:mm)" style="width:200px"></asp:TextBox>
                                         </div>
                                          <div class="col-3">
                                        Time </div>
                                          <div class="col-3">
                                             <asp:TextBox ID="txtBDnToTime" runat="server" BackColor="#CCCCCC" CssClass="form-control" placeholder="(hh:mm)" style="width:200px"></asp:TextBox>
                                         </div>
                                     </div>
                                <br />
                                     <div class="row">
									<div class="col-6">
                                             <asp:Label ID="Label1" runat="server" Visible="False">Total Time loss </asp:Label>
                                         </div>
									<div class="col-6">
                                             <asp:Label ID="lblTotal_time" runat="server" Visible="False"></asp:Label>
                                         </div>
                                     </div>
                                <br />
                                   <div class="row">
									<div class="col-3">Remarks</div>
                                         <div class="col-6">
                                             <asp:TextBox ID="txtRemarks" runat="server"  width="200px" Height="35px" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                         </div>
                                     </div>
                                <br />
                                     <div class="row">
									<div class="col-12" align="middle">
                                         
                                             <asp:Button ID="btnSave" runat="server" BorderStyle="Solid" CssClass="btn btn-dark" Font-Bold="True" Font-Names="Arial" Font-Size="Medium" Text="Save" />
                                             <asp:Button ID="btnClear" runat="server" BorderStyle="Solid" CausesValidation="False" CssClass="btn btn-dark" Font-Bold="True" Font-Names="Arial" Font-Size="Medium" Text="Clear" />
                                             <asp:Button ID="btnExit" runat="server" BorderStyle="Solid" CausesValidation="False" CssClass="btn btn-dark" Font-Bold="True" Font-Names="Arial" Font-Size="Medium" Text="Exit" />
                                         </div>
                                     </div>
                                <br />
                                
                       
				</div>
				<asp:datagrid id="DataGrid1" runat="server" BorderStyle="Solid" CellPadding="3" BackColor="White" BorderWidth="1px" BorderColor="#999999" CssClass="table" ForeColor="Black" GridLines="Vertical">
					<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#000099"></SelectedItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Black"></HeaderStyle>
					<FooterStyle BackColor="#CCCCCC"></FooterStyle>
					<AlternatingItemStyle BackColor="#CCCCCC" />
					<Columns>
						<asp:ButtonColumn Text="Select" CommandName="Select"></asp:ButtonColumn>
					</Columns>
					<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999"></PagerStyle>
				</asp:datagrid>
			</asp:Panel>
                    </div>
		</FORM>
            </div>
         <%--<div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>--%>
      <div class="card-footer" style="text-align:right;background-color:#cccccc;vertical-align:middle;position:absolute;bottom:0;width:100%;height:60px"><h4 style="color: black;font-size:15px">MAINTAINED BY CRIS</h4></div>
          <script type="text/javascript">
$(document).ready(function () {
                       
                        $('#txtBDnToDate').datepicker({
                            dateFormat: "dd-mm-yy" 
    });
                        
                        $("#txtBDnFromDate").datepicker({
                            dateFormat: "dd-mm-yy", 
                           
                            onSelect: function(date){            
                                var date1 = $('#txtBDnFromDate').datepicker('getDate');           
                                                 
                                $('#txtBDnToDate').datepicker("option","minDate",date1);            
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

	</BODY>
</HTML>
