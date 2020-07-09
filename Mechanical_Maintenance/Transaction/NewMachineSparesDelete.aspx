<%@ Page Language="vb" AutoEventWireup="false" Codebehind="NewMachineSparesDelete.aspx.vb" Inherits="WebApplication2.NewMachineSparesDelete" %>
<!DOCTYPE html PUBLIC "-//W3C//Dtd html 4.0 transitional//EN">
<html>
	<head runat="server">
		<title>NewMachineSparesDelete</title>
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
	<BODY style="overflow-x:hidden">

      <nav class="mb-1 navbar navbar-expand-sm bg-dark navbar-dark " >
  <a class="navbar-brand p-0" href="#"><img src="../../NewFolder1/unnamed.png" class="rounded-circle z-depth-0"  height="45"/> </a>
  <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent-333"
    aria-controls="navbarSupportedContent-333" aria-expanded="false" aria-label="Toggle navigation">
    <span class="navbar-toggler-icon"></span>
  </button>
  <div class="collapse navbar-collapse " id="navbarSupportedContent-333">
      <ul class="navbar-nav ml-auto  navbar-center">
          <li class="nav-item" style="font-weight: bold">
             <h1 style="color:white; font-size:30px; margin-left:430px; margin-top:5px">Rail Wheel Plant, Bela</h1> 
       
         </li>
          <%--<li class="nav-item"> <a class="nav-link" href="#" style="color:white; font-size:25px;">Rail Wheel Plant Bela</a></li>--%>
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
          <%--<img src="../../NewFolder1/CRIS-Recruitment.jpg" class="rounded-circle z-depth-0"  height="45"/>--%>
            <img src="../../NewFolder1/CRIS-Recruitment.jpg" height="45" style="border-radius:43%"/>
        </a>
      </li>
     </ul>
      
  </div>
</nav>
<!--/.Navbar -->
        <div class="container">
        <FORM id="Form1" method="post" runat="server">
             <div class="row">
                 <div class="table-responsive">
			        <asp:panel id="Panel1" runat="server">

                            <div class="container-fluid">
								<div class="row">
									<div class="col">
                                         <b><h1 align="middle" colspan="6">Machine Spares - Delete<hr class="prettyline" />
                                        </h1></b> 
                                     </div>
                                    </div>

                                   <div class="row">
									<div class="col-6">
										<asp:Label id="lblMessage" runat="server" Visible="False"></asp:Label></div>
                                	<div class="col-6">
                                        <asp:label id="lblGrp" runat="server" Visible="False"></asp:label>
                                        </div>
                                </div>

                                    <div class="row">
                                        <div class="col-6">
										<asp:Label id="lblUserID" runat="server" ForeColor="Red"></asp:Label>
                                        </div>
								</div>
							</div>
							 <div class="container-fluid">

								<div class="row">
									<div class="col-12" align="center">
                                        <asp:radiobuttonlist id="rdoTypeOfGroup" runat="server" RepeatLayout="Flow" CssClass="rbl" AutoPostBack="true" Repeatdirection="Horizontal">
							                <asp:ListItem Value="MachinePLs" Selected="true">Machine PLs &nbsp;&nbsp;</asp:ListItem>
							                <asp:ListItem Value="SubAssemblyPLs">SubAssembly PLs &nbsp;&nbsp;</asp:ListItem>
						               </asp:radiobuttonlist>
									</div>
                                    </div>
                                 <br />
                                    <div class="row">
									<div class="col-2">Machine</div>   
                                    <div class="col-2"><asp:panel id="pnlMachine" runat="server"><asp:DropDownList id="ddlMachines" runat="server" AutoPostBack="true" CssClass="form-control ll" style="width:100%;"></asp:DropDownList></asp:panel>
                                            <asp:panel id="pnlSubAssemlies" runat="server"><asp:DropDownList id="ddlSubAssemlies" runat="server" AutoPostBack="true" CssClass="form-control ll" style="width:100%;"></asp:DropDownList></asp:panel></div>
                                        <%--<asp:panel id="pnlSubAssemlies" runat="server"><div class="col-2"><asp:DropDownList id="ddlSubAssemlies" runat="server" AutoPostBack="true" CssClass="form-control ll" style="width:100%;"></asp:DropDownList></div></asp:panel>     --%>
                                   <%-- <asp:panel id="pnlMachine" runat="server"><div class="col-2"><asp:DropDownList id="ddlMachines" runat="server" AutoPostBack="true" CssClass="form-control ll" style="width:100%;"></asp:DropDownList></div></asp:panel>--%>
								        <div class="col-2"></div>    
                                        <div class="col-2">PL Number</div>
									<div class="col-2"><asp:dropdownlist id="ddlPLNumber" runat="server" AutoPostBack="true" CssClass="form-control ll"></asp:dropdownlist></div>
                                    </div>
                               <br />
                                 <div class="row">
                                     <div class="col-2">Qty</div>
									<div class="col-2"><asp:textbox id="txtQty" runat="server" CssClass="form-control"></asp:textbox></div>
							        <div class="col-2"><asp:Label id="lblUnit" runat="server"></asp:Label></div>
									<div class="col-2">Purpose</div>
                                     <div class="col-2"><asp:textbox id="txtPurpose" runat="server" CssClass="form-control"></asp:textbox></div>
								</div>
                               <br />
                            <br />
                                   <div class="row">
									<div class="col-12" align="middle">
										<asp:Button id="btnSave" runat="server" Text="Delete" BorderStyle="Solid" CssClass="btn btn-dark" Font-Bold="True" Font-Names="Arial" Font-Size="Medium"></asp:Button></div>
								</div>
                                 <br />
                                 </div>
 </asp:Panel>
                    </div>
             </div>
		</FORM>
            </div>
         <%--<div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>--%>
        <div class="card-footer" style="text-align:right;background-color:#cccccc;vertical-align:middle;height:45px; width:100%;position:absolute; bottom:0;"><h4 style="color: black;font-size:15px;">MAINTAINED BY CRIS</h4></div>
  
    </body>
</HTML>
