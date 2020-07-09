<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Baking.aspx.vb" Inherits="WebApplication2.Baking" %>

<%--<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Baking.aspx.vb" Inherits="WebApplication6.Baking" %>--%>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Baking station</title>
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
   <link href="StyleSheet1.css" rel="stylesheet" />
                           <script>
 function onlynum() {
             if ((event.keyCode < 48 || event.keyCode > 57)) {
                 event.returnValue = false;
             }
             if ((event.keyCode == 58)) {
                 event.returnValue = true

             }
         }
function OnlyNumericEntry() {
        if ((event.keyCode < 48 || event.keyCode > 57)) {
        event.returnValue = false;
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
  function isNumber(evt, element) {

                    var charCode = (evt.which) ? evt.which : event.keyCode

                      if (
                           (charCode != 58 || $(element).val().indexOf(':') != -1) &&      // “:” CHECK COLON, AND ONLY ONE.
                           (charCode < 48 || charCode > 57))
                      return false;

                  return true;
                }    
                              
   function ValidateAlpha(evt)
    {
        var keyCode = (evt.which) ? evt.which : evt.keyCode
        if ((keyCode < 65 || keyCode > 90) && (keyCode < 97 || keyCode > 123) && keyCode != 32)
         
        return false;
            return true;
    }
    function validateHhMm(inputField) {
                         var isValid = /^([0-9]|0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$/.test(inputField.value);

                     if (isValid) {
           
                                       
                         document.getElementById("result1").innerHTML = "";
                              inputField.style.backgroundColor = '#ffffff';
             
                     } else {
                           document.getElementById("result1").innerHTML = "*Time is Invalid";
                         inputField.style.backgroundColor = '#ff8080';
                   
                     }

                      return isValid;
         }
             function validateHhMm1(inputField) {
                         var isValid = /^([0-9]|0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$/.test(inputField.value);

                     if (isValid) {
           
                                       
                         document.getElementById("result2").innerHTML = "";
                              inputField.style.backgroundColor = '#ffffff';
             
                     } else {
                           document.getElementById("result2").innerHTML = "*Time is Invalid";
                         inputField.style.backgroundColor = '#ff8080';
                   
                     }

                      return isValid;
                 }

       
</script>


 
</head>
<body>
    
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
     <div class="container">
            <div class="row">
                <div class="table-responsive">
    <form id="form2" runat="server">
                               
              <asp:Panel runat="server" ID="panel1">
                 <table class="table">
                      <tr>
                   <td vAlign="top" align="middle"><h2>Baking Station</h2><hr class="prettyline" /></td>
               </tr>
                 </table>
            <table  class="table">
              
                <tr>
                    <td>Date:</td>
                    <td>
                        <asp:TextBox ID="txtdate" runat="server" CssClass="form-control"  onkeypress="return isNumber1(event,this)" MaxLength="10" placeholder="dd/mm/yyyy"></asp:TextBox></td>
                    <td>shift:</td>
                    <td>
                        <asp:DropDownList ID="Ddlshift" CssClass="form-control ll" runat="server">
                            <asp:ListItem>select-shift</asp:ListItem>
                            <asp:ListItem>A</asp:ListItem>
                            <asp:ListItem>B</asp:ListItem>
                            <asp:ListItem>C</asp:ListItem>
                            <asp:ListItem>G</asp:ListItem>
                        </asp:DropDownList></td>
                    <td>SSE/JE:</td>
                    <td>
                        <asp:TextBox ID="txtSSEJE" runat="server" CssClass="form-control"  ToolTip="pls do not enter numbers(only character)" onKeyPress="return ValidateAlpha(event);" AutoPostBack="True"></asp:TextBox></td>
                     </tr>
                <tr>
                    <td>CTA1 Operator:</td>
                    <td>
                        <asp:TextBox ID="txtoperator" runat="server" CssClass="form-control" ToolTip="enter 6-digit operator" onkeypress="return ValidateAlpha(event);"></asp:TextBox>
                     
                    </td>
                     <td>Core Baking Operator: </td>
                    <td>
                        <asp:TextBox ID="txtCorebakingoperator" runat="server" CssClass="form-control" MaxLength="6" ToolTip="enter 6-digit Core operator number(only character)" onkeypress="return ValidateAlpha(event);"></asp:TextBox></td>
                    <td>Dome Baking Operator:</td>
                    <td>
                        <asp:TextBox ID="txtDomebakingoperator" runat="server" CssClass="form-control" MaxLength="6" ToolTip="enter 6-digit Dome operator number(only character)" onkeypress="return ValidateAlpha(event);"></asp:TextBox></td>
                     </tr>
                <tr>

                    <td>Moulding W.O. No.:</td>
                    <td>
                        <asp:TextBox ID="txtmould" runat="server" CssClass="form-control"></asp:TextBox></td>
                    
                         <td colspan="3" align="center">MOULD ORIGIN:</td>
                     <td> <asp:RadioButtonList ID="rbl1" runat="server" CssClass="rbl" AutoPostBack="true"  RepeatLayout="Flow" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1" Selected="True">Heat</asp:ListItem>
                            <asp:ListItem Value="2">MPO</asp:ListItem> </asp:RadioButtonList>
                    </td>
                 
                </table>
                  <asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                   </asp:Panel>
        <asp:Panel runat="server" ID="panel3">
            <table class="table">
                <tr>
                    <td>
                        <asp:Label ID="heat" runat="server" Text="Heat No:"></asp:Label> </td>
                    <td >
                        <asp:TextBox ID="txtheat" CssClass="form-control" runat="server" AutoPostBack="True" MaxLength="6" ToolTip="enter 6-digit heat number(only numeric)" onkeypress="OnlyNumericEntry()"></asp:TextBox>
                        <%--<asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage=" Allow 6 digit numbers" MaximumValue="5"></asp:RangeValidator>--%>
                    </td>
                    <%--if heat no selected then display start&finish time--%>
                      <td> </td> <td> </td>   <td> </td> <td> </td>                
                </tr>
                </table></asp:Panel>
            <asp:Panel runat="server" ID="panel4">
                <table class="table">
                <tr>
                   
                <td> </td> <td> </td>  <td> </td> <td> </td> 
                </tr>
                </table>
                </asp:Panel>

                <asp:Panel runat="server" ID="panel2">
                    <table class="table">
                        <tr> <td> <asp:Label ID="starttime" runat="server" Text="Start Time"></asp:Label></td>
                    <td >
                        <asp:TextBox ID="txtstarttime" runat="server" onblur="validateHhMm(this)" Text="00:00" MaxLength="5" CssClass="form-control" ToolTip="hh:mm"></asp:TextBox></td>
                    <td>
                        <asp:Label ID="finishtime" runat="server" Text="Finish Time"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtfinishtime" runat="server" Text="00:00" onblur="validateHhMm1(this)" MaxLength="5" CssClass="form-control" ToolTip="hh:mm"></asp:TextBox></td> 
                    <td> <asp:Label ID="sandqty" runat="server" Text=" Sand Qty:"></asp:Label> </td>
                    <%--<td>
                        <asp:TextBox ID="txtsandqty" runat="server" CssClass="form-control" ToolTip="enter sand qty(in numeric)" onkeypress="OnlyNumericEntry()"></asp:TextBox></td>--%>
                    <td>
                        <asp:Label ID="Riserinkg" runat="server" Text="Riser hole(in kg):"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtriserkg" runat="server" CssClass="form-control" MaxLength="9999" ToolTip="enter kg value(only numeric)" onkeypress="OnlyNumericEntry()"></asp:TextBox></td>
                    <td>
                        <asp:Label ID="domeingm" runat="server" Text="Dome(in gm):"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtdomegm" runat="server" CssClass="form-control" MaxLength="9999" ToolTip="enter gm value(only numeric)" onkeypress="OnlyNumericEntry()"></asp:TextBox></td>
                </tr>
                <tr >
                    <td rowspan="2">
                        <asp:Label ID="dometemp" runat="server" Text="Dome Temp:"></asp:Label></td>
                   <td rowspan="2">
                     
                       1 <asp:TextBox ID="txtdometmp1" runat="server" CssClass="form-control" ToolTip="enter dome temprature(numeric or float value)"  onkeypress="OnlyNumericEntry()"></asp:TextBox>
                  </td>
                    
                    <td rowspan="2">
                        
                        2<asp:TextBox ID="txtdometmp2" runat="server" CssClass="form-control" ToolTip="enter dome temprature(numeric or float value)"  onkeypress="OnlyNumericEntry()"></asp:TextBox>
                        
                    </td>
                    
                    <td  rowspan="2" colspan="2">
                        <asp:Label ID="padtemp" runat="server" Text="Pad Temp:"></asp:Label></td>
                    <td>1</td>
                    <td>2</td>
                    <td>3</td>
                    <td>4</td>
                    </tr>
                <tr>
                    
                   <td>
                        <asp:TextBox ID="txtpadtmp1" runat="server" CssClass="form-control" ToolTip="enter pad temprature(numeric or float value)"  onkeypress="OnlyNumericEntry()"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="txtpadtmp2" runat="server" CssClass="form-control" ToolTip="enter pad temprature(numeric or float value)"  onkeypress="OnlyNumericEntry()"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="txtpadtmp3" runat="server" CssClass="form-control" ToolTip="enter pad temprature(numeric or float value)"  onkeypress="OnlyNumericEntry()"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="txtpadtmp4" runat="server" CssClass="form-control" ToolTip="enter pad temprature(numeric or float value)"  onkeypress="OnlyNumericEntry()"></asp:TextBox></td>
   
                </tr>
                </table>

             <table class="table">
                            
                            <tr >
                                <td>Sprue Temp (pad wise)</td>
                                <td>
                                    1</td>
                                <td>
                                    2</td>
                                <td>
                                    3</td>
                                <td>
                                    4</td>
                                <td>
                                    5</td>
                                <td>
                                     6</td>
                                <td>
                                    7</td>
                                <td>
                                     8</td>
                                <td>
                                    9</td>
                                <td>
                                    10</td>
                            </tr>
                            <tr>
                                <td>Pad1
                                </td>
                                <td>
                                    <asp:TextBox ID="txtpad11" runat="server" CssClass="form-control" ToolTip="enter pad temprature(numeric or float value)"  onkeypress="OnlyNumericEntry()"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtpad12" runat="server" CssClass="form-control" ToolTip="enter pad temprature(numeric or float value)"  onkeypress="OnlyNumericEntry()"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtpad13" runat="server" CssClass="form-control" ToolTip="enter pad temprature(numeric or float value)"  onkeypress="OnlyNumericEntry()"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtpad14" runat="server" CssClass="form-control" ToolTip="enter pad temprature(numeric or float value)"  onkeypress="OnlyNumericEntry()"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtpad15" runat="server" CssClass="form-control" ToolTip="enter pad temprature(numeric or float value)"  onkeypress="OnlyNumericEntry()"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtpad16" runat="server" CssClass="form-control" ToolTip="enter pad temprature(numeric or float value)"  onkeypress="OnlyNumericEntry()"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtpad17" runat="server" CssClass="form-control" ToolTip="enter pad temprature(numeric or float value)"  onkeypress="OnlyNumericEntry()"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtpad18" runat="server" CssClass="form-control" ToolTip="enter pad temprature(numeric or float value)"  onkeypress="OnlyNumericEntry()"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtpad19" runat="server" CssClass="form-control" ToolTip="enter pad temprature(numeric or float value)"  onkeypress="OnlyNumericEntry()"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtpad20" runat="server" CssClass="form-control" ToolTip="enter pad temprature(numeric or float value)"  onkeypress="OnlyNumericEntry()"></asp:TextBox></td>

                            </tr>
                            <tr>
                                <td>Pad2</td>
                                <td>
                                    <asp:TextBox ID="txtpad21" runat="server" CssClass="form-control" ToolTip="enter pad temprature(numeric or float value)"  onkeypress="OnlyNumericEntry()"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtpad22" runat="server" CssClass="form-control" ToolTip="enter pad temprature(numeric or float value)"  onkeypress="OnlyNumericEntry()"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtpad23" runat="server" CssClass="form-control" ToolTip="enter pad temprature(numeric or float value)"  onkeypress="OnlyNumericEntry()"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtpad24" runat="server" CssClass="form-control" ToolTip="enter pad temprature(numeric or float value)"  onkeypress="OnlyNumericEntry()"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtpad25" runat="server" CssClass="form-control" ToolTip="enter pad temprature(numeric or float value)"  onkeypress="OnlyNumericEntry()"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtpad26" runat="server" CssClass="form-control" ToolTip="enter pad temprature(numeric or float value)"  onkeypress="OnlyNumericEntry()"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtpad27" runat="server" CssClass="form-control" ToolTip="enter pad temprature(numeric or float value)"  onkeypress="OnlyNumericEntry()"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtpad28" runat="server" CssClass="form-control" ToolTip="enter pad temprature(numeric or float value)"  onkeypress="OnlyNumericEntry()"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtpad29" runat="server" CssClass="form-control" ToolTip="enter pad temprature(numeric or float value)"  onkeypress="OnlyNumericEntry()"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtpad30" runat="server" CssClass="form-control" ToolTip="enter pad temprature(numeric or float value)"  onkeypress="OnlyNumericEntry()"></asp:TextBox></td>

                            </tr>
                            <tr>
                                <td>Pad3</td>
                                <td>
                                    <asp:TextBox ID="txtpad31" runat="server" CssClass="form-control" ToolTip="enter pad temprature(numeric or float value)"  onkeypress="OnlyNumericEntry()"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtpad32" runat="server" CssClass="form-control" ToolTip="enter pad temprature(numeric or float value)"  onkeypress="OnlyNumericEntry()"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtpad33" runat="server" CssClass="form-control" ToolTip="enter pad temprature(numeric or float value)"  onkeypress="OnlyNumericEntry()"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtpad34" runat="server" CssClass="form-control" ToolTip="enter pad temprature(numeric or float value)"  onkeypress="OnlyNumericEntry()"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtpad35" runat="server" CssClass="form-control" ToolTip="enter pad temprature(numeric or float value)"  onkeypress="OnlyNumericEntry()"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtpad36" runat="server" CssClass="form-control" ToolTip="enter pad temprature(numeric or float value)"  onkeypress="OnlyNumericEntry()"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtpad37" runat="server" CssClass="form-control" ToolTip="enter pad temprature(numeric or float value)"  onkeypress="OnlyNumericEntry()"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtpad38" runat="server" CssClass="form-control" ToolTip="enter pad temprature(numeric or float value)"  onkeypress="OnlyNumericEntry()"></asp:TextBox></td>
                               <td>
                                    <asp:TextBox ID="txtpad39" runat="server" CssClass="form-control" ToolTip="enter pad temprature(numeric or float value)"  onkeypress="OnlyNumericEntry()"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtpad40" runat="server" CssClass="form-control" ToolTip="enter pad temprature(numeric or float value)"  onkeypress="OnlyNumericEntry()"></asp:TextBox></td>

                            </tr>
                            <tr>
                                <td>Pad4</td>
                                <td>
                                    <asp:TextBox ID="txtpad41" runat="server" CssClass="form-control" ToolTip="enter pad temprature(numeric or float value)"  onkeypress="OnlyNumericEntry()"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtpad42" runat="server" CssClass="form-control" ToolTip="enter pad temprature(numeric or float value)"  onkeypress="OnlyNumericEntry()"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtpad43" runat="server" CssClass="form-control" ToolTip="enter pad temprature(numeric or float value)"  onkeypress="OnlyNumericEntry()"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtpad44" runat="server" CssClass="form-control" ToolTip="enter pad temprature(numeric or float value)"  onkeypress="OnlyNumericEntry()"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtpad45" runat="server" CssClass="form-control" ToolTip="enter pad temprature(numeric or float value)"  onkeypress="OnlyNumericEntry()"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtpad46" runat="server" CssClass="form-control" ToolTip="enter pad temprature(numeric or float value)"  onkeypress="OnlyNumericEntry()"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtpad47" runat="server" CssClass="form-control" ToolTip="enter pad temprature(numeric or float value)"  onkeypress="OnlyNumericEntry()"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtpad48" runat="server" CssClass="form-control" ToolTip="enter pad temprature(numeric or float value)"  onkeypress="OnlyNumericEntry()"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtpad49" runat="server" CssClass="form-control" ToolTip="enter pad temprature(numeric or float value)"  onkeypress="OnlyNumericEntry()"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txtpad50" runat="server" CssClass="form-control" ToolTip="enter pad temprature(numeric or float value)"  onkeypress="OnlyNumericEntry()"></asp:TextBox></td>

                            </tr>
                                               </table><br />
            <table class="table">
                <tr>
                    <td>
                        <asp:Label ID="copeno" runat="server" Text="Cope No.:"></asp:Label>.</td>
                   <td> <asp:TextBox ID="txtcopeno" runat="server" CssClass="form-control" MaxLength="5" ToolTip="enter cope number(only numeric)"  onkeypress="OnlyNumericEntry()" AutoPostBack="True"></asp:TextBox></td>
                    <td>
                        <asp:Label ID="copetmp" runat="server" Text="Cope Temp:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtcopetmp" runat="server" CssClass="form-control" ToolTip="enter cope temprature(numeric or float value)"  onkeypress="OnlyNumericEntry()"></asp:TextBox></td>
                    <td>
                        <asp:Label ID="domeno" runat="server" Text="Dome No:"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="Ddldomeno" CssClass="ll" runat="server" Width="40px">
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                        </asp:DropDownList></td>
                   
                     <td>
                        <asp:Label ID="dometime" runat="server" Text="Dome Bak Time(in sec):"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtdometime" runat="server" CssClass="form-control" ToolTip="enter number of dome time(only numeric)"  onkeypress="OnlyNumericEntry()"></asp:TextBox></td>
                       <td> <asp:Label ID="padno" runat="server" Text="Pad No:"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="Ddlpadno" CssClass="ll" runat="server" Width="40px">
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                        </asp:DropDownList></td>
                    <td>
                        <asp:Label ID="baktime" runat="server" Text="Pad Bak Time(in sec):"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtbaktime" runat="server" CssClass="form-control" ToolTip="enter number of bak time(only numeric)"  onkeypress="OnlyNumericEntry()"></asp:TextBox></td>
                    <td>
                   
                        <asp:Label ID="status" runat="server" Text="Status:"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="Ddlstatus" CssClass="ll" runat="server">
                            <asp:ListItem>OK</asp:ListItem>
                            <asp:ListItem>Not OK</asp:ListItem>
                             <asp:ListItem>Only Pad OK</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <table class="table">
                <tr>
                    <td style="position:center">Remarks:</td>
                    <td>
                        <asp:TextBox ID="txtremarks" runat="server" CssClass="form-control"  TextMode="MultiLine" Style="width:500px; height:50px;" MaxLength="250"></asp:TextBox></td>
                </tr>
                    </table>
                <tr>
                       <td>
                        <asp:Button ID="btnsave" runat="server" CssClass="button button2" Text="SAVE"  /></td>
           <td> <asp:Button ID="btnclear" runat="server" Text="CLEAR" CssClass="button button2" /></td>
           
                       <td><asp:Button ID="btnexit" runat="server" CssClass="button button2" Text="EXIT" />
               </td>
                </tr>
                 </table>
                  </asp:Panel>
        <asp:TextBox id
             
                                  <table id="table8" class="table">
                                        <TR>
                    <TD colSpan="6">
                        <asp:datagrid id="bakingstationheader" CssClass="table" runat="server" CellPadding="1" CellSpacing="1" AutoGenerateColumns="False" forecolor="Black" OnItemDataBound="OnItemDataBound">
                    <AlternatingItemStyle BackColor="White"></AlternatingItemStyle>
                    <HeaderStyle ForeColor="White" BackColor="Navy"></HeaderStyle>
                    <Columns><asp:TemplateColumn HeaderText = "S.No" ItemStyle-Width="100">
        <ItemTemplate>
            <asp:Label ID="lblRowNumber" runat="server" />
            
        </ItemTemplate>
    </asp:TemplateColumn>
                    <asp:ButtonColumn Text="Select" HeaderText="Select" CommandName="Select"></asp:ButtonColumn>
                    <asp:BoundColumn DataField="date" HeaderText="Date"></asp:BoundColumn>
                    <asp:BoundColumn DataField="shift" HeaderText="Shift "></asp:BoundColumn>
                    <asp:BoundColumn DataField="sseorje" HeaderText="SSE/JE"></asp:BoundColumn>
                    <asp:BoundColumn DataField="heatnumber" HeaderText="heat_heatno"></asp:BoundColumn>
                    <asp:BoundColumn DataField="startTime" HeaderText="Start time"></asp:BoundColumn>
                    <asp:BoundColumn DataField="finishTime" HeaderText="Finish time"></asp:BoundColumn>                    
                    <asp:BoundColumn DataField="operatorname" HeaderText="operator"></asp:BoundColumn>
                    <asp:BoundColumn DataField="core_operator" HeaderText="core_Operator"></asp:BoundColumn>
                    <asp:BoundColumn DataField="dome_operator" HeaderText="dome_Operator"></asp:BoundColumn>
                    <asp:BoundColumn DataField="mouldingwonumber" HeaderText="Moulding_WO_No"></asp:BoundColumn>
                   
                    </Columns>
                    </asp:datagrid></TD>
                    </TR>

                    </table>

                        <TR>
                    <TD colSpan="6">
                        <asp:datagrid id="bakingstation" CssClass="table" runat="server" CellPadding="1" CellSpacing="1" AutoGenerateColumns="False" forecolor="Black">
                    <AlternatingItemStyle BackColor="White"></AlternatingItemStyle>
                    <HeaderStyle ForeColor="White" BackColor="Navy"></HeaderStyle> 
                    <Columns>
    
                    <asp:ButtonColumn Text="Select" HeaderText="Select" CommandName="Select"></asp:ButtonColumn>
                    <asp:BoundColumn DataField="ID" HeaderText="SrNo"></asp:BoundColumn>
                    <asp:BoundColumn DataField="heatnumber" HeaderText="Heat Number"></asp:BoundColumn>
                    <asp:BoundColumn DataField="date" HeaderText="Date"></asp:BoundColumn>
                    <asp:BoundColumn DataField="shift" HeaderText="Shift"></asp:BoundColumn>
                    <asp:BoundColumn DataField="mouldorigin" HeaderText="Mould_origin"></asp:BoundColumn>
                    <asp:BoundColumn DataField="cope_no" HeaderText="Cope_No"></asp:BoundColumn>
                    <asp:BoundColumn DataField="cope_tmp" HeaderText="Cope_tmp"></asp:BoundColumn>
                    <asp:BoundColumn DataField="pad_no" HeaderText="Pad_No"></asp:BoundColumn>
                    <asp:BoundColumn DataField="pad_bak_time" HeaderText="Pad_bakTime"></asp:BoundColumn>
                    <asp:BoundColumn DataField="dome_no" HeaderText="Dome_No"></asp:BoundColumn>
                    <asp:BoundColumn DataField="dome_bak_time" HeaderText="Dome_bakTime"></asp:BoundColumn>
                    <asp:BoundColumn DataField="status" HeaderText="Status"></asp:BoundColumn>
                    <asp:BoundColumn DataField="remarks" HeaderText="Remarks"></asp:BoundColumn>
                   
                    </Columns>
                    </asp:datagrid></TD>
                                   <TD colSpan="6">
                        <asp:datagrid id="dgtemp" CssClass="table" runat="server" CellPadding="1" CellSpacing="1" AutoGenerateColumns="False" forecolor="Black" OnItemDataBound="OnItemDataBound">
                    <AlternatingItemStyle BackColor="White"></AlternatingItemStyle>
                    <HeaderStyle ForeColor="White" BackColor="Navy"></HeaderStyle>
                    <Columns><asp:TemplateColumn HeaderText = "S.No" ItemStyle-Width="100">
        <ItemTemplate>
            <asp:Label ID="lblRowNumber" runat="server" />
            
        </ItemTemplate>
    </asp:TemplateColumn>
    
                     <asp:ButtonColumn Text="Select" HeaderText="Select" CommandName="Select"></asp:ButtonColumn>
                    <asp:BoundColumn DataField="date" HeaderText="Date"></asp:BoundColumn>
                    <asp:BoundColumn DataField="shift" HeaderText="Shift"></asp:BoundColumn>
                    <asp:BoundColumn DataField="heatnumber" HeaderText="Heat Number"></asp:BoundColumn>
                    <asp:BoundColumn DataField="pad1tmp1" HeaderText="pad1tmp1"></asp:BoundColumn>
                    <asp:BoundColumn DataField="pad1tmp2" HeaderText="pad1tmp2"></asp:BoundColumn>
                    <asp:BoundColumn DataField="pad1tmp3" HeaderText="pad1tmp3"></asp:BoundColumn>
                    <asp:BoundColumn DataField="pad1tmp4" HeaderText="pad1tmp4"></asp:BoundColumn>
                    <asp:BoundColumn DataField="pad1tmp5" HeaderText="pad1tmp5"></asp:BoundColumn>
                    <asp:BoundColumn DataField="pad1tmp6" HeaderText="pad1tmp6"></asp:BoundColumn>
                    <asp:BoundColumn DataField="pad1tmp7" HeaderText="pad1tmp7"></asp:BoundColumn>
                    <asp:BoundColumn DataField="pad1tmp8" HeaderText="pad1tmp8"></asp:BoundColumn>
                    <asp:BoundColumn DataField="pad1tmp9" HeaderText="pad1tmp9"></asp:BoundColumn>
                    <asp:BoundColumn DataField="pad1tmp10" HeaderText="pad1tmp10"></asp:BoundColumn>
                    <asp:BoundColumn DataField="pad2tmp1" HeaderText="pad2tmp1"></asp:BoundColumn>
                    <asp:BoundColumn DataField="pad2tmp2" HeaderText="pad2tmp2"></asp:BoundColumn>
                    <asp:BoundColumn DataField="pad2tmp3" HeaderText="pad2tmp3"></asp:BoundColumn>
                    <asp:BoundColumn DataField="pad2tmp4" HeaderText="pad2tmp4"></asp:BoundColumn>
                    <asp:BoundColumn DataField="pad2tmp5" HeaderText="pad2tmp5"></asp:BoundColumn>
                    <asp:BoundColumn DataField="pad2tmp6" HeaderText="pad2tmp6"></asp:BoundColumn>
                    <asp:BoundColumn DataField="pad2tmp7" HeaderText="pad2tmp7"></asp:BoundColumn>
                    <asp:BoundColumn DataField="pad2tmp8" HeaderText="pad2tmp8"></asp:BoundColumn>
                    <asp:BoundColumn DataField="pad2tmp9" HeaderText="pad2tmp9"></asp:BoundColumn>
                     <asp:BoundColumn DataField="pad2tmp10" HeaderText="pad2tmp10"></asp:BoundColumn>
                    <asp:BoundColumn DataField="pad3tmp1" HeaderText="pad3tmp1"></asp:BoundColumn>
                    <asp:BoundColumn DataField="pad3tmp2" HeaderText="pad3tmp2"></asp:BoundColumn>
                    <asp:BoundColumn DataField="pad3tmp3" HeaderText="pad3tmp3"></asp:BoundColumn>
                    <asp:BoundColumn DataField="pad3tmp4" HeaderText="pad3tmp4"></asp:BoundColumn>
                    <asp:BoundColumn DataField="pad3tmp5" HeaderText="pad3tmp5"></asp:BoundColumn>
                    <asp:BoundColumn DataField="pad3tmp6" HeaderText="pad3tmp6"></asp:BoundColumn>
                    <asp:BoundColumn DataField="pad3tmp7" HeaderText="pad3tmp7"></asp:BoundColumn>
                    <asp:BoundColumn DataField="pad3tmp8" HeaderText="pad3tmp8"></asp:BoundColumn>
                    <asp:BoundColumn DataField="pad3tmp9" HeaderText="pad3tmp9"></asp:BoundColumn>
                    <asp:BoundColumn DataField="pad3tmp10" HeaderText="pad3tmp10"></asp:BoundColumn>
                    <asp:BoundColumn DataField="pad4tmp1" HeaderText="pad4tmp1"></asp:BoundColumn>
                    <asp:BoundColumn DataField="pad4tmp2" HeaderText="pad4tmp2"></asp:BoundColumn>
                    <asp:BoundColumn DataField="pad4tmp3" HeaderText="pad4tmp3"></asp:BoundColumn>
                    <asp:BoundColumn DataField="pad4tmp4" HeaderText="pad4tmp4"></asp:BoundColumn>
                    <asp:BoundColumn DataField="pad4tmp5" HeaderText="pad4tmp5"></asp:BoundColumn>
                    <asp:BoundColumn DataField="pad4tmp6" HeaderText="pad4tmp6"></asp:BoundColumn>
                    <asp:BoundColumn DataField="pad4tmp7" HeaderText="pad4tmp7"></asp:BoundColumn>
                    <asp:BoundColumn DataField="pad4tmp8" HeaderText="pad4tmp8"></asp:BoundColumn>
                    <asp:BoundColumn DataField="pad4tmp9" HeaderText="pad4tmp9"></asp:BoundColumn>
                    <asp:BoundColumn DataField="pad4tmp10" HeaderText="pad4tmp10"></asp:BoundColumn>
                    
                    </Columns>
                    </asp:datagrid></TD>
                    </TR>
       
    </form>
                     </div>
                </div>
            </div>
     <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
</body>
</html>