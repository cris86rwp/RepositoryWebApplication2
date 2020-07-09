<%@ Page Language="vb" AutoEventWireup="false" Codebehind="mouldAssemblyAdd.aspx.vb" Inherits="WebApplication2.mouldAssemblyAdd" %>
<!DOCTYPE HTML PUBLIC "-//W3C//Dtd HTML 4.0 transitional//EN">
<html>
	<head runat="server">
		<title>mouldAssemblyAdd</title>
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
         .auto-style2 {
             position: relative;
             width: 100%;
             -ms-flex-preferred-size: 0;
             flex-basis: 0;
             -ms-flex-positive: 1;
             flex-grow: 1;
             max-width: 100%;
             left: 0px;
             top: 0px;
             padding-left: 15px;
             padding-right: 15px;
         }
         </style>
	</head>
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
          <i class="fab glyphicon glyphicon-home "  style="font-size:30px;"></i>
        </a></li>

       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../../logon.aspx">
          <i class="fab glyphicon glyphicon-log-out"  style="font-size:30px;"></i>
        </a></li>
    
        <li class="nav-item ">
        <a class="nav-link p-0" href="#">
         
        <img src="../../../NewFolder1/CRIS-Recruitment.jpg" height="45" style="border-radius:43%"/>
       </a>
      </li>
     </ul>
      
  </div>
</nav>   
         <script>

    function isInputNumber(evt) {

                    var ch = String.fromCharCode(evt.which);
        if (!(/[0-9]/.test(ch)))
        {
        evt.preventDefault();
    }

             }
               function isNumber1(evt, element) {

                    var charCode = (evt.which) ? evt.which : event.keyCode

                      if (
                           (charCode != 45 ) && (charCode != 47 ) &&     // 
                           (charCode < 48 || charCode > 57))
                      return false;

                  return true;
            } 
             </script>

      

		<form id="Form1" method="post" runat="server">

           
            <%-- <div class="row">
    
                  <h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />
      </div>--%>
        
			<asp:panel id="Panel1"  runat="server"><%--style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 8px"--%>
                  <div class="container ">
          
                <div class="table">
			
					<div class="row">
						<div class="col" align="center"><h3><strong>Mould Assembly - Add</strong></h3>
								
                            <asp:textbox id="txtOperator_id" runat="server" Visible="False" cssclass="form-control"></asp:textbox></div>
					</div>
                    <br />
					<div class="row">
						<div class="col">
							<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></div>
					</div>
                    <br />
					<div class="row">
						<div class="col">Date</div>
						
						<div class="col">
							<asp:textbox id="txtdate" runat="server" AutoPostBack="true" CssClass="auto-style1" onkeypress="return isNumber1(event,this)" MaxLength="10" Width="103px" ></asp:textbox></div>
						<div class="col">Shift</div>
						
						<div class="col">
							<asp:radiobuttonlist id="rblShift" runat="server"  AutoPostBack="true" Repeatdirection="Horizontal" RepeatLayout="Flow" CssClass="rbl">
								<asp:ListItem Value="A" Selected="true">A&nbsp;</asp:ListItem>
								<asp:ListItem Value="B">B&nbsp;</asp:ListItem>
								<asp:ListItem Value="C">C&nbsp;</asp:ListItem>
							</asp:radiobuttonlist></div>
				
						<div class="col">Mould<span class="glyphicon-asterisk"></span></div>
						
						<div class="col" >
							<asp:textbox id="txtMouldNumber" runat="server"  AutoPostBack="true" CssClass="auto-style1" ToolTip="Enter numeric value" onkeypress="isInputNumber(event)" Width="103px"></asp:textbox></div>
					</div>
                    <br />
					<div class="row">
                        <div class="col">Type</div>
						
						<div class="col">
							<asp:label id="lblMouldType" runat="server"></asp:label>&nbsp;</div>
					
						<div class="col">Initial Ht</div>
						
						<div class="auto-style2">
							<asp:label id="lblMouldInit" runat="server"></asp:label>&nbsp;</div>
						<div class="col">Final Ht</div>
						
						<div class="col">
							<asp:label id="lblMouldFinal" runat="server"></asp:label>&nbsp;</div>
					</div>
                    <br />
					<div class="row">
						<div class="col">Gr Loss</div>
						<div class="col">
							<asp:label id="lblGrphiteRmvd" runat="server"></asp:label>&nbsp;</div>
						<div class="col">No. of IGs</div>
						
						<div class="col">
							<asp:textbox id="txtCntIngate" runat="server" CssClass="form-control" Width="103px"></asp:textbox>&nbsp;</div>
                        <div class="col"></div>
                        <div class="col"></div>
					</div>
                    <br />
					<div class="row">
						<div class="col" align="center">
							<asp:button id="btnSave" runat="server" Text="Save"  Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark" ></asp:button>
							</div>
                        <div class="col">
                           <asp:button id="btnClear" runat="server" Text="Clear"  Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark" ></asp:button>
							</div>
			</div>
				<asp:DataGrid id="grdMouldAssembly" runat="server"  BackColor="White" CssClass="table">
					<SelectedItemStyle Font-Bold="true" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="true" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>
                    </div></div>
			</asp:panel></form>
         <div class="card-footer" style="text-align:right;background-color:#cccccc;vertical-align:middle;position:absolute;bottom:0;width:100%;height:60px"><h4 style="color: black;font-size:15px">MAINTAINED BY CRIS</h4></div>
        <script type="text/javascript">
     $(document).ready(function () {
                       
                        $('#txtdate').datepicker({
                            dateFormat: "dd/mm/yy", 
                       
                            onSelect: function(date){            
                                var date1 = $('#txtdate').datepicker('getDate');           
                                                 
                              
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
