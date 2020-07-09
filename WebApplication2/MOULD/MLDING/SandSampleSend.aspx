<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SandSampleSend.aspx.vb" Inherits="WebApplication2.SandSampleSend" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sand_Preperation</title>
  
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

	</head>
	<body style="overflow-x:hidden">

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
            <img src="../../NewFolder1/CRIS-Recruitment.jpg" height="45" style="border-radius:43%"/>
        </a>
      </li>
     </ul>
      
  </div>
</nav>
<!--/.Navbar -->
        
     <script>
                      $(document).ready(function () {
                       
                        $('#sanddate').datepicker({
                            dateFormat: "dd/mm/yy", 
                       
                            onSelect: function(date){            
                                var date1 = $('#sanddate').datepicker('getDate');           
                                                 
                              
                            }
                        });
      $('#Expected_testdate').datepicker({
                            dateFormat: "dd/mm/yy", 
                       
                            onSelect: function(date){            
                                var date1= $('#Expected_testdate').datepicker('getDate');           
                                                 
                              
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
    
     <div class="container">
   <form id="Form1" method="post" runat="server">
         <asp:Panel runat="server" ID="panel1">
        <div class ="row">
  
             <div  class="table"  id="table1">
           <div class=<"row">
                    <div class="col-12" align="center" ><h1>Sand Sample Results</h1> <hr /> </div >
                 </div ><br />
                 <div class="row">
                     <div class="col-2" >Date</div >
                     <div class="col-2" ><asp:TextBox ID="sanddate" runat="server" MaxLength="10" CssClass="form-control" autopostback="true" style="width:103px;"></asp:TextBox> </div >
                     <div class="col-2">shift</div >
                     <div class="col-2">
               <asp:radiobuttonlist id="rblshift" runat="server" CssClass="rbl" AutoPostBack="True" RepeatDirection="Horizontal" RepeatLayout="Flow">
								<asp:ListItem Value="A">A</asp:ListItem>
								<asp:ListItem Value="B">B</asp:ListItem>
								<asp:ListItem Value="C">C</asp:ListItem>
                                <asp:ListItem Value="G">G</asp:ListItem>
							</asp:radiobuttonlist>
                        </div >
                     <div class="col-2">Select Sample</div >
                     <div class="col-2">
                            <asp:DropDownList ID="DDLsample" runat="server" CssClass="form-control ll" AutoPostBack="True" style="width:103px;">
                            <asp:ListItem>select</asp:ListItem>
                           </asp:DropDownList>
                     </div>
  </div>
                 <br />
         
                  <div class="row">
                     <div class="col-2" >Expected Test Date</div>
                      <div class="col-2" ><asp:TextBox ID="Expected_testdate" runat="server" MaxLength="10" CssClass="form-control" autopostback="true" style="width:103px;"></asp:TextBox></div>
               <%--       <div class="col-2" ></div>
                      <div class="col-2" ></div>
                      <div class="col-2" ></div>
                      <div class="col-2" ></div>--%>
                      </div>
                 <br />
      <div class="row">
                     <div class="col-6"><asp:Label ID="Label1" runat="server" ForeColor="Red" ></asp:Label></div>
                     <div class="col-6"><asp:Label ID="Label2" runat="server" ForeColor="Red" ></asp:Label></div>
                 </div>
                    <br />
            <div class="row">
           <div class="col-12" align="center"> 
               <asp:Button ID="btn_batch" runat="server" Name="btn_batch" Text="Sand Sample Lab For Test" CssClass="btn btn-dark" Font-Bold="True" Font-Names="Arial" Font-Size="Medium" />
                    <asp:Button ID="Btnclear" runat="server" Text="CLEAR"   CssClass="btn btn-dark" Font-Bold="True" Font-Names="Arial" Font-Size="Medium" />
           </div >
        </div >
                 <br />
                
                  </div>
            <br />
               <div class ="row">
               <div class="table">
                     <div class="row">
					 <div class="col-12">
            <asp:Panel ID="panel8" runat="server">
                <div style="overflow-x: scroll; height:100%; width:90%" >
          <asp:DataGrid ID="Vw_batch_no" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" CssClass="table" GridLines="Vertical" ForeColor="Black">
             <Columns> <asp:ButtonColumn Text="Select" HeaderText="Select" CommandName="Select"></asp:ButtonColumn></Columns>                 
              <SelectedItemStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                <AlternatingItemStyle BackColor="#CCCCCC" />
                                <FooterStyle BackColor="#CCCCCC" />
                                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" /> 
         
                            </asp:DataGrid>
                    </div>
        </asp:Panel>
</div></div>
                   </div></div>
           
            </div>
         </asp:Panel>
    </form></div>
       <div class="card-footer" style="text-align:right;background-color:#cccccc; vertical-align:middle;height:45px; width:100%; bottom:0; position:fixed; margin-left:0px;"><h4 style="color: black;font-size:15px;">MAINTAINED BY CRIS</h4></div>
</body>
</html>