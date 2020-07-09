<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="pouringtube_pre.aspx.vb" Inherits="WebApplication2.pouringtube_pre" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Pouring Tube Preparation</title>
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
     <script>
          $(document).ready(function () {
            $('#date_txt').datepicker({
         dateFormat: "dd/mm/yy",

         onSelect: function (date) {
             var date1 = $('#date_txt').datepicker('getDate');
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

    function isInputNumber(evt) {

                    var ch = String.fromCharCode(evt.which);
        if (!(/[0-9]/.test(ch)))
        {
        evt.preventDefault();
    }

         }

       function isNumber(evt, element) {

        var charCode = (evt.which) ? evt.which : event.keyCode

        if (
           /* (charCode != 45 || $(element).val().indexOf('-') != -1) && */     // “-” CHECK MINUS, AND ONLY ONE.
            (charCode != 46 || $(element).val().indexOf('.') != -1) &&      // “.” CHECK DOT, AND ONLY ONE.
            (charCode < 48 || charCode > 57))
            return false;

        return true;
    }    
            </script>
    

    
        <div class="container">
   <form id="Form1" method="post" runat="server">
         <asp:Panel ID="Panel1"  runat="server"  >

             <div class ="row">
        
                <div class="table">
                      <div class="row">
                          <div class="col">
                                         <b><h1 align="middle" colspan="6">Pouring Tube Preparation Details <hr class="prettyline" />
                                             <h1></h1>
                                             <h1></h1>
                                             <h1></h1>
                                             <h1></h1>
                                             <h1></h1>
                                        </h1></b> 
                                     </div>
                </div>
                    <div class="row">
                    <div class="col-2">Date </div>
                    <div class="col-2" >
                        <asp:TextBox ID="date_txt" runat="server" CssClass="form-control" Width="103px" ></asp:TextBox>
                   
                    </div>  
                      
                        <div class="col-2">Shift
                    </div>
                    <div class="col-2">
                         <asp:DropDownList ID="shift_dd1" runat="server" CssClass="form-control ll" AutoPostBack="True" Width="103px" >
                            <asp:ListItem>select shift</asp:ListItem>
                            <asp:ListItem>A</asp:ListItem>
                            <asp:ListItem>B</asp:ListItem>
                            <asp:ListItem>C</asp:ListItem>
                            <asp:ListItem>G</asp:ListItem>
                        </asp:DropDownList>
                  </div>
                 
                    <div class="col-2"> SSE/JE</div>
                    <div class="col-2">
                        <asp:TextBox ID="sse_txt" runat="server" CssClass="form-control" Width="103px"></asp:TextBox>
                       </div>
                        </div>
                    <br />
                        <div class="row">
                        <div class="col-2">
                            Operator1
                        </div>
                <div class="col-2"> <asp:TextBox ID="op1_txt" runat="server" CssClass="form-control" Width="103px"></asp:TextBox></div>
                        <div class="col-2">Operator2</div>
                        <div class="col-2">
                            <asp:TextBox ID="op2_txt" runat="server" CssClass="form-control" Width="103px"></asp:TextBox></div>
                        <div class="col-2"> Operator3</div>
                        <div class="col-2"> <asp:TextBox ID="op3_txt" runat="server" CssClass="form-control" Width="103px"></asp:TextBox></div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-2">Super 3000 Mixing done (in KG)</div>
                        <div class="col-2" class="tooltiptext">
                            <asp:TextBox ID="super_txt" runat="server"  CssClass="form-control" width="103px" ToolTip="Enter maximum 3 numeric value" onkeypress="isInputNumber(event)" MaxLength="3" TextMode="Number"   ></asp:TextBox><asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="please enter valid quantity" ControlToValidate="super_txt" ForeColor="#6600FF" MaximumValue="999" MinimumValue="1"></asp:RangeValidator>
                        </div>
                        <div class="col-2"></div>
                        <div class="col-2" >No of HC Pressing & Chipping Done</div>
                        <div class="col-2" class="tooltiptext">
                            <asp:TextBox ID="pressing_txt" runat="server" onkeypress="isInputNumber(event)" CssClass="form-control" Width="103px" ToolTip="Enter maximum 2  numeric value" MaxLength="2" TextMode="Number"></asp:TextBox></div>
                         </div>
                    <div class="row">
                        <div class="col-2">No of P Tube measuring & cutting done</div>
                        <div class="col-2" class="tooltiptext">
                            <asp:TextBox ID="measuring_txt" runat="server" onkeypress="isInputNumber(event)" CssClass="form-control" Width="103px" ToolTip="Enter maximum 2  numeric value" MaxLength="2" TextMode="Number" ></asp:TextBox></div>
                        <div class="col-2"></div>
                        <div class="col-2">Tube Height (in Inch)</div>
                        <div class="col-2">
                            <asp:TextBox ID="height_txt" runat="server" onkeypress="return isNumber(event, this)"    CssClass="form-control" Width="103px" ></asp:TextBox></div>
                      </div>
                              </div>
            <div class="table">
                                     
                         
                                                                                           
                                                                                               <br />
                                                                                               <div class="row">
                                                                                                   <div class="col">
                                                                                                       <br />
                                                                                                       Tube Centering &amp; reaming Done</div>
                                                                                                   <div class="col" class="tooltiptext">TN1<asp:TextBox ID="tube_centeringtn1" runat="server" CssClass="form-control" MaxLength="6" onkeypress="isInputNumber(event)" TextMode="Number" ToolTip="Enter maximum 6 digit of tube no"></asp:TextBox>
                                                                                                   </div>
                                                                                                   <div class="col">TN2<asp:TextBox ID="tube_centeringtn2" runat="server" CssClass="form-control" MaxLength="6" onkeypress="isInputNumber(event)" TextMode="Number"></asp:TextBox>
                                                                                                   </div>
                                                                                                   <div class="col">TN3<asp:TextBox ID="tube_centeringtn3" runat="server" CssClass="form-control" MaxLength="6" onkeypress="isInputNumber(event)" TextMode="Number"></asp:TextBox>
                                                                                                   </div>
                                                                                                   <div class="col">TN4<asp:TextBox ID="tube_centeringtn4" runat="server" CssClass="form-control" MaxLength="6" onkeypress="isInputNumber(event)" TextMode="Number"></asp:TextBox>
                                                                                                   </div>
                                                                                                   <div class="col">TN5<asp:TextBox ID="tube_centeringtn5" runat="server" CssClass="form-control" MaxLength="6" onkeypress="isInputNumber(event)" TextMode="Number"></asp:TextBox>
                                                                                                   </div>
                                                                                                   <div class="col">TN6<asp:TextBox ID="tube_centeringtn6" runat="server" CssClass="form-control" MaxLength="6" onkeypress="isInputNumber(event)" TextMode="Number"></asp:TextBox>
                                                                                                   </div>
                                                                                                   <div class="col">TN7<asp:TextBox ID="tube_centeringtn7" runat="server" CssClass="form-control" MaxLength="6" onkeypress="isInputNumber(event)" TextMode="Number"></asp:TextBox>
                                                                                                   </div>
                                                                                                   <div class="col">TN8<asp:TextBox ID="tube_centeringtn8" runat="server" CssClass="form-control" MaxLength="6" onkeypress="isInputNumber(event)" TextMode="Number"></asp:TextBox>
                                                                                                   </div>
                                                                                                   <div class="col" class="auto-style1">TN9<asp:TextBox ID="tube_centeringtn9" runat="server" CssClass="form-control" MaxLength="6" onkeypress="isInputNumber(event)" TextMode="Number"></asp:TextBox>
                                                                                                   </div>
                                                                                                   <div class="col">TN10<asp:TextBox ID="tube_centeringtn10" runat="server" CssClass="form-control" MaxLength="6" onkeypress="isInputNumber(event)" TextMode="Number"></asp:TextBox>
                                                                                                   </div>
                                                                                               </div>
                                                                                               <div class="row">
                                                                                                   <div class="col">
                                                                                                       <br />
                                                                                                       Parting rings fitted &amp; Flame dry in Tube</div>
                                                                                                   <div class="col" class="tooltiptext">TN1<asp:TextBox ID="parting_tn1" runat="server" CssClass="form-control" MaxLength="6" onkeypress="isInputNumber(event)" TextMode="Number" ToolTip="Enter maximum 6 digit of tube no"></asp:TextBox>
                                                                                                   </div>
                                                                                                   <div class="col">TN2<asp:TextBox ID="parting_tn2" runat="server" CssClass="form-control" MaxLength="6" onkeypress="isInputNumber(event)" TextMode="Number"></asp:TextBox>
                                                                                                   </div>
                                                                                                   <div class="col">TN3<asp:TextBox ID="parting_tn3" runat="server" CssClass="form-control" MaxLength="6" onkeypress="isInputNumber(event)" TextMode="Number"></asp:TextBox>
                                                                                                   </div>
                                                                                                   <div class="col">TN4<asp:TextBox ID="parting_tn4" runat="server" CssClass="form-control" MaxLength="6" onkeypress="isInputNumber(event)" TextMode="Number"></asp:TextBox>
                                                                                                   </div>
                                                                                                   <div class="col">TN5<asp:TextBox ID="parting_tn5" runat="server" CssClass="form-control" MaxLength="6" onkeypress="isInputNumber(event)" TextMode="Number"></asp:TextBox>
                                                                                                   </div>
                                                                                                   <div class="col">TN6<asp:TextBox ID="parting_tn6" runat="server" CssClass="form-control" MaxLength="6" onkeypress="isInputNumber(event)" TextMode="Number"></asp:TextBox>
                                                                                                   </div>
                                                                                                   <div class="col">TN7<asp:TextBox ID="parting_tn7" runat="server" CssClass="form-control" MaxLength="6" onkeypress="isInputNumber(event)" TextMode="Number"></asp:TextBox>
                                                                                                   </div>
                                                                                                   <div class="col">TN8<asp:TextBox ID="parting_tn8" runat="server" CssClass="form-control" MaxLength="6" onkeypress="isInputNumber(event)" TextMode="Number"></asp:TextBox>
                                                                                                   </div>
                                                                                                   <div class="col" class="auto-style1">TN9<asp:TextBox ID="parting_tn9" runat="server" CssClass="form-control" MaxLength="6" onkeypress="isInputNumber(event)" TextMode="Number"></asp:TextBox>
                                                                                                   </div>
                                                                                                   <div class="col">TN10<asp:TextBox ID="parting_tn10" runat="server" CssClass="form-control" MaxLength="6" onkeypress="isInputNumber(event)" TextMode="Number"></asp:TextBox>
                                                                                                   </div>
                                                                                               </div>
                <br />
                <div class="row">
                    <div class="col-12" align="middle">
                    <b>                                            
                Grinding &amp; Glazing of Tubes</b></div>
                </div>
                <br />
                                                                                               <div class="row">
                                                                                                   <div class="col">&nbsp;<br /> Tube No<br /></div>
                                                                                                   <div class="col" class="tooltiptext">TN1<asp:TextBox ID="tubeno_tn1" runat="server" CssClass="form-control" MaxLength="6" onkeypress="isInputNumber(event)" TextMode="Number" ToolTip="Enter maximum 6 digit of tube no"></asp:TextBox>
                                                                                                   </div>
                                                                                                   <div class="col">TN2<asp:TextBox ID="tubeno_tn2" runat="server" CssClass="form-control" MaxLength="6" onkeypress="isInputNumber(event)" TextMode="Number"></asp:TextBox>
                                                                                                   </div>
                                                                                                   <div class="col">TN3<asp:TextBox ID="tubeno_tn3" runat="server" CssClass="form-control" MaxLength="6" onkeypress="isInputNumber(event)" TextMode="Number"></asp:TextBox>
                                                                                                   </div>
                                                                                                   <div class="col">TN4<asp:TextBox ID="tubeno_tn4" runat="server" CssClass="form-control" MaxLength="6" onkeypress="isInputNumber(event)" TextMode="Number"></asp:TextBox>
                                                                                                   </div>
                                                                                                   <div class="col">TN5<asp:TextBox ID="tubeno_tn5" runat="server" CssClass="form-control" MaxLength="6" onkeypress="isInputNumber(event)" TextMode="Number"></asp:TextBox>
                                                                                                   </div>
                                                                                                   <div class="col">TN6<asp:TextBox ID="tubeno_tn6" runat="server" CssClass="form-control" MaxLength="6" onkeypress="isInputNumber(event)" TextMode="Number"></asp:TextBox>
                                                                                                   </div>
                                                                                                   <div class="col">TN7<asp:TextBox ID="tubeno_tn7" runat="server" CssClass="form-control" MaxLength="6" onkeypress="isInputNumber(event)" TextMode="Number"></asp:TextBox>
                                                                                                   </div>
                                                                                                   <div class="col">TN8<asp:TextBox ID="tubeno_tn8" runat="server" CssClass="form-control" MaxLength="6" onkeypress="isInputNumber(event)" TextMode="Number"></asp:TextBox>
                                                                                                   </div>
                                                                                                   <div class="col">TN9<asp:TextBox ID="tubeno_tn9" runat="server" CssClass="form-control" MaxLength="6" onkeypress="isInputNumber(event)" TextMode="Number"></asp:TextBox>
                                                                                                   </div>
                                                                                                   <div class="col">TN10<asp:TextBox ID="tubeno_tn10" runat="server" CssClass="form-control" MaxLength="6" onkeypress="isInputNumber(event)" TextMode="Number"></asp:TextBox>
                                                                                                   </div>
                                                                                               </div>
                <br />
                                                                                               <div class="row">
                                                                                                   <div class="col">&nbsp;Vaccume</div>
                                                                                                   <div class="col" class="tooltiptext">
                                                                                                       <asp:TextBox ID="vaccume_txt1" runat="server" CssClass="form-control" MaxLength="3" onkeypress="isInputNumber(event)" TextMode="Number" ToolTip="Enter maximum 3  numeric value"></asp:TextBox>
                                                                                                   </div>
                                                                                                   <div class="col">
                                                                                                       <asp:TextBox ID="vaccume_txt2" runat="server" CssClass="form-control" MaxLength="3" onkeypress="isInputNumber(event)"></asp:TextBox>
                                                                                                   </div>
                                                                                                   <div class="col">
                                                                                                       <asp:TextBox ID="vaccume_txt3" runat="server" CssClass="form-control" MaxLength="3" onkeypress="isInputNumber(event)" TextMode="Number"></asp:TextBox>
                                                                                                   </div>
                                                                                                   <div class="col">
                                                                                                       <asp:TextBox ID="vaccume_txt4" runat="server" CssClass="form-control" MaxLength="3" onkeypress="isInputNumber(event)" TextMode="Number"></asp:TextBox>
                                                                                                   </div>
                                                                                                   <div class="col">
                                                                                                       <asp:TextBox ID="vaccume_txt5" runat="server" CssClass="form-control" MaxLength="3" onkeypress="isInputNumber(event)" TextMode="Number"></asp:TextBox>
                                                                                                   </div>
                                                                                                   <div class="col">
                                                                                                       <asp:TextBox ID="vaccume_txt6" runat="server" CssClass="form-control" MaxLength="3" onkeypress="isInputNumber(event)" TextMode="Number"></asp:TextBox>
                                                                                                   </div>
                                                                                                   <div class="col">
                                                                                                       <asp:TextBox ID="vaccume_txt7" runat="server" CssClass="form-control" MaxLength="3" onkeypress="isInputNumber(event)" TextMode="Number"></asp:TextBox>
                                                                                                   </div>
                                                                                                   <div class="col">
                                                                                                       <asp:TextBox ID="vaccume_txt8" runat="server" CssClass="form-control" MaxLength="3" onkeypress="isInputNumber(event)" TextMode="Number"></asp:TextBox>
                                                                                                   </div>
                                                                                                   <div class="col" class="auto-style1">
                                                                                                       <asp:TextBox ID="vaccume_txt9" runat="server" CssClass="form-control" MaxLength="3" onkeypress="isInputNumber(event)" TextMode="Number"></asp:TextBox>
                                                                                                   </div>
                                                                                                   <div class="col">
                                                                                                       <asp:TextBox ID="vaccume_txt10" runat="server" CssClass="form-control" MaxLength="3" onkeypress="isInputNumber(event)" TextMode="Number"></asp:TextBox>
                                                                                                   </div>
                                                                                               </div>
                <br />
                                                                                               <div class="row">
                                                                                                   <div class="col">Time (in Sec)&nbsp;</div>
                                                                                                   <div class="col" class="tooltiptext">
                                                                                                       <asp:TextBox ID="time_txt1" runat="server" CssClass="form-control" MaxLength="3" onkeypress="isInputNumber(event)" TextMode="Number" ToolTip="enter maximum 3  numeric value"></asp:TextBox>
                                                                                                   </div>
                                                                                                   <div class="col">
                                                                                                       <asp:TextBox ID="time_txt2" runat="server" CssClass="form-control" MaxLength="3" onkeypress="isInputNumber(event)" TextMode="Number"></asp:TextBox>
                                                                                                   </div>
                                                                                                   <div class="col">
                                                                                                       <asp:TextBox ID="time_txt3" runat="server" CssClass="form-control" MaxLength="3" onkeypress="isInputNumber(event)" TextMode="Number"></asp:TextBox>
                                                                                                   </div>
                                                                                                   <div class="col">
                                                                                                       <asp:TextBox ID="time_txt4" runat="server" CssClass="form-control" MaxLength="3" onkeypress="isInputNumber(event)" TextMode="Number"></asp:TextBox>
                                                                                                   </div>
                                                                                                   <div class="col">
                                                                                                       <asp:TextBox ID="time_txt5" runat="server" CssClass="form-control" MaxLength="3" onkeypress="isInputNumber(event)" TextMode="Number"></asp:TextBox>
                                                                                                   </div>
                                                                                                   <div class="col">
                                                                                                       <asp:TextBox ID="time_txt6" runat="server" CssClass="form-control" MaxLength="3" onkeypress="isInputNumber(event)" TextMode="Number"></asp:TextBox>
                                                                                                   </div>
                                                                                                   <div class="col">
                                                                                                       <asp:TextBox ID="time_txt7" runat="server" CssClass="form-control" MaxLength="3" onkeypress="isInputNumber(event)" TextMode="Number"></asp:TextBox>
                                                                                                   </div>
                                                                                                   <div class="col">
                                                                                                       <asp:TextBox ID="time_txt8" runat="server" CssClass="form-control" MaxLength="3" onkeypress="isInputNumber(event)" TextMode="Number"></asp:TextBox>
                                                                                                   </div>
                                                                                                   <div class="col" class="auto-style1">
                                                                                                       <asp:TextBox ID="time_txt9" runat="server" CssClass="form-control" MaxLength="3" onkeypress="isInputNumber(event)" TextMode="Number"></asp:TextBox>
                                                                                                   </div>
                                                                                                   <div class="col">
                                                                                                       <asp:TextBox ID="time_txt10" runat="server" CssClass="form-control" MaxLength="3" onkeypress="isInputNumber(event)" TextMode="Number"></asp:TextBox>
                                                                                                   </div>
                                                                                               </div>
                                                                                                 <br />
                                                                                               <div class="row">
                                                                                                   <div class="col-2">Glaze used (in Kg)</div>
                                                                                                   <div class="col-2" class="tooltiptext">
                                                                                                       <asp:TextBox ID="txt_glaze" runat="server" CssClass="form-control" MaxLength="2" onkeypress="isInputNumber(event)" TextMode="Number" ToolTip="Enter maximum 2 numeric value"></asp:TextBox>
                                                                                                   </div>
                                                                                                   <div class="col-2">
                                                                                                       <asp:Label ID="Label3" runat="server" Text="Baume"></asp:Label>
                                                                                                      </div>
                                                                                                   <div class="col-2" class="tooltiptext">
                                                                                                   
                                                                                                       <asp:TextBox ID="Txt_Baume" runat="server" CssClass="form-control" MaxLength="2" onkeypress="isInputNumber(event)" TextMode="Number" ToolTip="Enter maximum 2 numeric value"></asp:TextBox>
                                                                                                   </div>
                                                                                                    <div class="col-2">
                                                                                                       <asp:Label ID="Label2" runat="server" Text="Remarks"> </asp:Label>
                                                                                                   </div>
                                                                                                   <div class="col-2">
                                                                                                       <asp:TextBox ID="txt_remark" runat="server" CssClass="form-control" MaxLength="200" TextMode="MultiLine" Style="width:130px; height:35px;"></asp:TextBox>
                                                                                                   </div>
                                                                                               </div>
                                                                                                 <br />
                                                                                              <%-- <div class="row">
                                                                                                   <div class="col" colspan="6">&nbsp;</div>
                                                                                               </div>--%>
                                                                                               <div class="row">
                                                                                                  
                                                                                               </div>
                                                                                               <div class="row">
                                                                                                   <div class="col-12" align="middle">
                                                                                                       <asp:Label ID="lbl_msg" runat="server" ForeColor="Red"></asp:Label>
                                                                                                       <asp:Button ID="Button1" runat="server" Text="Save" BorderStyle="Solid" CssClass="btn btn-dark" Font-Bold="True" Font-Names="Arial" Font-Size="Medium" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                                       <asp:Button ID="Button2" runat="server" Text="Clear" BorderStyle="Solid" CssClass="btn btn-dark" Font-Bold="True" Font-Names="Arial" Font-Size="Medium" />
                                                                                                       &nbsp;&nbsp;&nbsp;
                                                                                                       <asp:Label ID="Label4" runat="server" ForeColor="Red"></asp:Label>
                                                                                                   </div>
                                                                                               </div>
                <br />
                  <asp:Panel runat="server" ID="Panel7" >
             <div id="table6" class="table">
                   <div class="row">
					 <div class="col-12">
                         <asp:datagrid id="dg_show" CssClass="table" runat="server" CellPadding="4" CellSpacing="2" AutoGenerateColumns="False" forecolor="Black" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" Width="100%">
							<FooterStyle BackColor="#CCCCCC" />
							<HeaderStyle ForeColor="White" BackColor="Black" Font-Bold="True"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Select" HeaderText="Select" CommandName="Select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="date" HeaderText="Date"></asp:BoundColumn>
								<asp:BoundColumn DataField="shift" HeaderText="Shift "></asp:BoundColumn>
								<asp:BoundColumn DataField="sse" HeaderText="SSE"></asp:BoundColumn>
								<asp:BoundColumn DataField="op1" HeaderText="Operator1"></asp:BoundColumn>
								<asp:BoundColumn DataField="op2" HeaderText="Operator2"></asp:BoundColumn>
								<asp:BoundColumn DataField="op3" HeaderText="Operator3"></asp:BoundColumn>
								<asp:BoundColumn DataField="super_3000in_kg" HeaderText="Super_3000"></asp:BoundColumn>
								<asp:BoundColumn DataField="no_of_hc_pressing" HeaderText="No_of_hc_pressing"></asp:BoundColumn>
                                <asp:BoundColumn DataField="no_of_p_tube" HeaderText="No of p_tube"></asp:BoundColumn>
								<asp:BoundColumn DataField="tubehieght_in_inch" HeaderText="Tubeheight"></asp:BoundColumn>
                                <asp:BoundColumn DataField="glazed_kg" HeaderText="Glazed_kg"></asp:BoundColumn>
								<asp:BoundColumn DataField="baume" HeaderText="Baume"></asp:BoundColumn>
                                <asp:BoundColumn DataField="remarks" HeaderText="Remarks"></asp:BoundColumn>
							</Columns>
						    <ItemStyle BackColor="White" />
                            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" Mode="NumericPages" />
                            <SelectedItemStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
						</asp:datagrid> </div >
				 </div >
                 <br />
                  <div class="row">
					 <div class="col-12">
                         <div style="overflow-x: scroll; height:100%; width:100%" >
                             <asp:datagrid id="dg_show2" CssClass="table" runat="server" CellPadding="4" CellSpacing="2" AutoGenerateColumns="False" forecolor="Black" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" Width="100%" PageSize="20">
							<FooterStyle BackColor="#CCCCCC" />
							<HeaderStyle ForeColor="White" BackColor="Black" Font-Bold="True"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Select" HeaderText="Select" CommandName="Select"></asp:ButtonColumn>
								
                              <asp:BoundColumn DataField="tubecentering_tn1" HeaderText="Tubecentering_tn1"></asp:BoundColumn>
								<asp:BoundColumn DataField="tubecentering_tn2" HeaderText="Tubecentering_tn2"></asp:BoundColumn>
								<asp:BoundColumn DataField="tubecentering_tn3" HeaderText="Tubecentering_tn3"></asp:BoundColumn>
                                <asp:BoundColumn DataField="tubecentering_tn4" HeaderText="Tubecentering_tn4"></asp:BoundColumn>
								<asp:BoundColumn DataField="tubecentering_tn5" HeaderText="Tubecentering_tn5"></asp:BoundColumn>
                                <asp:BoundColumn DataField="tubecentering_tn6" HeaderText="Tubecentering_tn6"></asp:BoundColumn>
								<asp:BoundColumn DataField="tubecentering_tn7" HeaderText="Tubecentering_tn7"></asp:BoundColumn>
								<asp:BoundColumn DataField="tubecentering_tn8" HeaderText="Tubecentering_tn8"></asp:BoundColumn>
                                <asp:BoundColumn DataField="tubecentering_tn9" HeaderText="Tubecentering_tn9"></asp:BoundColumn>
								<asp:BoundColumn DataField="tubecentering_tn10" HeaderText="Tubecentering_tn10"></asp:BoundColumn>
                                <asp:BoundColumn DataField="parting_tn1" HeaderText="Parting_tn1"></asp:BoundColumn>
								<asp:BoundColumn DataField="parting_tn2" HeaderText="Parting_tn2"></asp:BoundColumn>
								<asp:BoundColumn DataField="parting_tn3" HeaderText="Parting_tn3"></asp:BoundColumn>
                                <asp:BoundColumn DataField="parting_tn4" HeaderText="Parting_tn4"></asp:BoundColumn>
								<asp:BoundColumn DataField="parting_tn5" HeaderText="Parting_tn5"></asp:BoundColumn>
                                <asp:BoundColumn DataField="parting_tn6" HeaderText="Parting_tn6"></asp:BoundColumn>
								<asp:BoundColumn DataField="parting_tn7" HeaderText="Parting_tn7"></asp:BoundColumn>
								<asp:BoundColumn DataField="parting_tn8" HeaderText="Parting_tn8"></asp:BoundColumn>
                                <asp:BoundColumn DataField="parting_tn9" HeaderText="Parting_tn9"></asp:BoundColumn>
								<asp:BoundColumn DataField="parting_tn10" HeaderText="Parting_tn10"></asp:BoundColumn>
							</Columns>
						    <ItemStyle BackColor="White" />
                            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" VerticalAlign="Bottom" />
                            <SelectedItemStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
						</asp:datagrid> </div ></div>
				 </div >
                 <br />
                  <div class="row">
					 <div class="col-12">
                         <div style="overflow-x: scroll; height:100%; width:100%" >
                             <asp:datagrid id="dg_show3" CssClass="table" runat="server" CellPadding="4" CellSpacing="2" AutoGenerateColumns="False" forecolor="Black" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" Width="100%">
							<FooterStyle BackColor="#CCCCCC" />
							<HeaderStyle ForeColor="White" BackColor="Black" Font-Bold="True"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Select" HeaderText="Select" CommandName="Select"></asp:ButtonColumn>

								<asp:BoundColumn DataField="glindingtubeno_tn1" HeaderText="Glindingtubeno_tn1"></asp:BoundColumn>
								<asp:BoundColumn DataField="glindingtubeno_tn2" HeaderText="Glindingtubeno_tn2 "></asp:BoundColumn>
								<asp:BoundColumn DataField="glindingtubeno_tn3" HeaderText="Glindingtubeno_tn3"></asp:BoundColumn>
								<asp:BoundColumn DataField="glindingtubeno_tn4" HeaderText="Glindingtubeno_tn4"></asp:BoundColumn>
								<asp:BoundColumn DataField="glindingtubeno_tn5" HeaderText="Glindingtubeno_tn5"></asp:BoundColumn>
                                <asp:BoundColumn DataField="glindingtubeno_tn6" HeaderText="Glindingtubeno_tn6"></asp:BoundColumn>
								<asp:BoundColumn DataField="glindingtubeno_tn7" HeaderText="Glindingtubeno_tn7"></asp:BoundColumn>
								<asp:BoundColumn DataField="glindingtubeno_tn8" HeaderText="Glindingtubeno_tn8"></asp:BoundColumn>
                                <asp:BoundColumn DataField="glindingtubeno_tn9" HeaderText="Glindingtubeno_tn9"></asp:BoundColumn>
								<asp:BoundColumn DataField="glindingtubeno_tn10" HeaderText="Glindingtubeno_tn10"></asp:BoundColumn>
								<asp:BoundColumn DataField="glindingvaccume_tn1" HeaderText="Glindingvaccume_tn1"></asp:BoundColumn>
								<asp:BoundColumn DataField="glindingvaccume_tn2" HeaderText="Glindingvaccume_tn2"></asp:BoundColumn>
								<asp:BoundColumn DataField="glindingvaccume_tn3" HeaderText="Glindingvaccume_tn3"></asp:BoundColumn>
                                <asp:BoundColumn DataField="glindingvaccume_tn4" HeaderText="Glindingvaccume_tn4"></asp:BoundColumn>
								<asp:BoundColumn DataField="glindingvaccume_tn5" HeaderText="Glindingvaccume_tn5"></asp:BoundColumn> 
                                <asp:BoundColumn DataField="glindingvaccume_tn6" HeaderText="Glindingvaccume_tn6"></asp:BoundColumn>
								<asp:BoundColumn DataField="glindingvaccume_tn7" HeaderText="Glindingvaccume_tn7"></asp:BoundColumn>
								<asp:BoundColumn DataField="glindingvaccume_tn8" HeaderText="Glindingvaccume_tn8"></asp:BoundColumn>
                                <asp:BoundColumn DataField="glindingvaccume_tn9" HeaderText="Glindingvaccume_tn9"></asp:BoundColumn>
                                <asp:BoundColumn DataField="glindingvaccume_tn10" HeaderText="Glindingvaccume_tn10"></asp:BoundColumn>
								<asp:BoundColumn DataField="glindingtime_tn1" HeaderText="Glindingtime_tn1"></asp:BoundColumn>
								<asp:BoundColumn DataField="glindingtime_tn2" HeaderText="Glindingtime_tn2"></asp:BoundColumn>
								<asp:BoundColumn DataField="glindingtime_tn3" HeaderText="Glindingtime_tn3"></asp:BoundColumn>
								<asp:BoundColumn DataField="glindingtime_tn4" HeaderText="Glindingtime_tn4"></asp:BoundColumn>
                                <asp:BoundColumn DataField="glindingtime_tn5" HeaderText="Glindingtime_tn5"></asp:BoundColumn>
								<asp:BoundColumn DataField="glindingtime_tn6" HeaderText="Glindingtime_tn6"></asp:BoundColumn>
								<asp:BoundColumn DataField="glindingtime_tn7" HeaderText="Glindingtime_tn7"></asp:BoundColumn>
                                <asp:BoundColumn DataField="glindingtime_tn8" HeaderText="Glindingtime_tn8"></asp:BoundColumn>
								<asp:BoundColumn DataField="glindingtime_tn9" HeaderText="Glindingtime_tn9"></asp:BoundColumn>
								<asp:BoundColumn DataField="glindingtime_tn10" HeaderText="Glindingtime_tn10"></asp:BoundColumn>
							</Columns>
						    <ItemStyle BackColor="White" />
                            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" Mode="NumericPages" />
                            <SelectedItemStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
						</asp:datagrid> </div ></div>
				 </div >
                 </div>
                      </asp:Panel>
            </div>
                 </div>
   </asp:Panel>      
		</form>
            </div>
         <%--<div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>--%>
        <div class="card-footer" style="text-align:right;background-color:#cccccc;vertical-align:middle;height:45px; width:100%; bottom:0;"><h4 style="color: black;font-size:15px;">MAINTAINED BY CRIS</h4></div>
        </BODY>
    </html>