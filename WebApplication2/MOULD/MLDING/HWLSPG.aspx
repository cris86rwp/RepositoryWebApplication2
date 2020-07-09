<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="HWLSPG.aspx.vb" Inherits="WebApplication2.HWLSPG" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HotWheelLine</title>
  
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
  //         $(document).ready(function () {
  //          $('#txtdate').datepicker({
  //       dateFormat: "dd/MM/yy",

  //       onSelect: function (date) {
  //           var date1 = $('#txtdate').datepicker('getDate');
  //       }


  //   });
                       
  //function getDate( element ) {
  //  var date;
  //  var dateFormat = "dd/MM/yyyy";
  //  try {
  //    date = $.datepicker.parseDate( dateFormat, element.value );
  //  } catch( error ) {
  //    date = null;
  //  }

  //  return date;
  //}
  //      });
          function validateHhMm4(inputField) {
                         var isValid = /^([0-9]|0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$/.test(inputField.value);

                     if (isValid) {
           
                                       
                         document.getElementById("result4").innerHTML = "";
                              inputField.style.backgroundColor = '#ffffff';
             
                     } else {
                           document.getElementById("result4").innerHTML = "*Time is Invalid";
                         inputField.style.backgroundColor = '#ff8080';
                   
                     }

                      return isValid;
         }
          function validateHhMm3(inputField) {
                         var isValid = /^([0-9]|0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$/.test(inputField.value);

                     if (isValid) {
           
                                       
                         document.getElementById("result3").innerHTML = "";
                              inputField.style.backgroundColor = '#ffffff';
             
                     } else {
                           document.getElementById("result3").innerHTML = "*Time is Invalid";
                         inputField.style.backgroundColor = '#ff8080';
                   
                     }

                      return isValid;
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

           function ValidateAlpha(evt)
    {
        var keyCode = (evt.which) ? evt.which : evt.keyCode
        if ((keyCode < 65 || keyCode > 90) && (keyCode < 97 || keyCode > 123) && keyCode != 32)
         
        return false;
            return true;
    }
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
                           (charCode != 45 ) && (charCode != 47 ) &&     
                           (charCode < 48 || charCode > 57))
                      return false;

                  return true;
         } 

         function onlynum() {
             if ((event.keyCode < 48 || event.keyCode > 57)) {
                 event.returnValue = false;
             }
             if ((event.keyCode == 58)) {
                 event.returnValue = true

             }
         }

    //     $(function () {
    //    $("#Btnsave").click(function () {
    //        if ($(this).val() == "Yes") {
    //            $("#dvv").show();
    //            $(this).val("No");
    //        } else {
    //            $("#dvv").hide();
    //            $(this).val("Yes");
    //        }
    //    });
    //});
</script>
    
     <div class="container">
   <form id="Form1" method="post" runat="server">
         <asp:Panel runat="server" ID="panel3">
        <div class ="row">
  
             <div  class="table"  id="table3">
           <div class="row">
                    <div class="col-12" align="center" ><h1> Hot Wheel Line (SPG) </h1> <hr /> </div >
                 </div >
                 <div class="row">
                     <div class="col-2" >Date</div >
                     <div class="col-2" ><asp:TextBox ID="txtdate" runat="server" onkeypress="return isNumber1(event,this)" MaxLength="10" CssClass="form-control" autopostback="true" style="width:103px;"></asp:TextBox> </div >
                     <div class="col-2">shift</div >
                     <div class="col-2">
                      <asp:DropDownList ID="DDLshift" runat="server" CssClass="form-control ll" AutoPostBack="True" style="width:103px;">
                            <asp:ListItem>select-shift</asp:ListItem>
                            
                            <asp:ListItem>A</asp:ListItem>
                            <asp:ListItem>B</asp:ListItem>
                            <asp:ListItem>C</asp:ListItem>
                            <asp:ListItem>G</asp:ListItem>
                           </asp:DropDownList>
                        </div >
                     <div class="col-2">SSE/JE</div >
                     <div class="col-2">
                        <asp:TextBox ID="txtSSEJE" runat="server" onKeyPress="return ValidateAlpha(event);" CssClass="form-control" style="width:103px;"></asp:TextBox> </div >
                     </div>
                 <br />
                     <div class="row">
                     <div class="col-2"> Start time </div >
                     <div class="col-2">
                        <asp:TextBox ID="Txtstart_time" runat="server" onblur="validateHhMm(this)" MaxLength="5"   CssClass="form-control" placeholder="hh:mm" Text="00:00" style="width:103px;"></asp:TextBox> </div >
                  <%--  <div id="dvv" style="display: none" class="col-4">
                      <div class="col-2"> Finish time </div >
                      <div class="col-2">
                        <asp:TextBox ID="Txtfinish_time" runat="server" onblur="validateHhMm1(this)" MaxLength="5"  CssClass="form-control"  placeholder="hh:mm" Text="00:00" style="width:103px;"></asp:TextBox> </div >
                       </div>--%>
                         <div class="col-2"> Finish time </div >
                     <div class="col-2">
                        <asp:TextBox ID="Txtfinish_time" runat="server" onblur="validateHhMm1(this)" MaxLength="5"  CssClass="form-control"  placeholder="hh:mm" Text="00:00" style="width:103px;"></asp:TextBox> </div >
                    <div class="col-2">Moulding W.O. No. </div >
                     <div class="col-2" >
                        <asp:TextBox ID="txtmould" runat="server" CssClass="form-control" MaxLength="4" style="width:103px;"></asp:TextBox> </div >
                         </div>
                 <br />
                 <div class="row">
                     <div class="col-2"><div id="result1"></div> </div >
                     <div class="col-2"><div id="result2"></div> </div >
                 </div>
                 <br />
                        <div class="row">     
                           <div class="col-2">SPG1 Operator </div >
                           <div class="col-2"><asp:TextBox ID="TxtSPG1Oper" runat="server" CssClass="form-control" onKeyPress="return ValidateAlpha(event);" style="width:103px;"></asp:TextBox> </div >
                           <div class="col-2">SPG2 Operator </div >
                           <div class="col-2"><asp:TextBox ID="TxtSPG2Oper" runat="server" CssClass="form-control" onKeyPress="return ValidateAlpha(event);" style="width:103px;"></asp:TextBox> </div >
                           <div class="col-2">SPG3 Operator </div >
                           <div class="col-2"><asp:TextBox ID="TxtSPG3Oper" runat="server" CssClass="form-control" onKeyPress="return ValidateAlpha(event);" style="width:103px;"></asp:TextBox> </div >
                         </div>
                     <br />
                     <div class="row">
                         <div class="col-2">SPG4 Operator </div >
                           <div class="col-2"><asp:TextBox ID="TxtSPG4Oper" runat="server" CssClass="form-control" onKeyPress="return ValidateAlpha(event);" style="width:103px;"></asp:TextBox> </div >
                           
                    </div >
                 <br />
                 <div class="row">
                     <div class="col-12" align="center"> <asp:Button ID="BtnSHeader" runat="server" Text="SAVE DETAILS" CausesValidation="False"  CssClass="btn btn-dark" Font-Bold="True" Font-Names="Arial" Font-Size="Medium"/>  </div >
                         <div class="col-2"><asp:Label ID="Label2" runat="server" ></asp:Label> </div ></div>
                 <br />
                 <div class="row">
                     <div class="col-2">Process </div >
                   <div class="col-2">
                      <asp:RadioButtonList ID="rbl1" runat="server" CssClass="rbl" AutoPostBack="true"  RepeatLayout="Flow" RepeatDirection="Horizontal" style="width:103px;">
                            <asp:ListItem Value="heat" selected="True">Heat &nbsp;&nbsp;</asp:ListItem>
                            <asp:ListItem Value="rework">Rework &nbsp;&nbsp;</asp:ListItem>
                        </asp:RadioButtonList>
                     </div >
                      <asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                     </div >
               <br />
                </div></div>
           </asp:Panel>
          
         <asp:Panel runat="server" ID="Panel1" >
             <div class ="row">
                 <div class="table" id="table1">
                     <div class="row">
                     <div class="col-2">Heat No  </div >
                     <div class="col-2">
                        <asp:TextBox ID="Txtheat_no" runat="server" CssClass="form-control" ToolTip="enter 6 digit no only" AutoPostBack="True" MaxLength="6" onkeypress="isInputNumber(event)" style="width:103px;"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" display="Dynamic" ControlToValidate="Txtheat_no"></asp:RequiredFieldValidator> Donot prefix zeroes
                     </div >
                         <div class="col-2">Wheel No </div >
                         <div class="col-2">
                            <asp:DropDownList ID="DropDownList1" CssClass="form-control ll" runat="server" AutoPostBack="True" style="width:103px;">
                            </asp:DropDownList>
                         </div >
                         <div class="col-2">Temp </div >
                         <div class="col-2">
                            <asp:TextBox ID="Txttemp" runat="server" CssClass="form-control"  onkeypress="isInputNumber(event)" style="width:103px;"></asp:TextBox>
                            <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="please enter the number b/w 100 to 1800" ControlToValidate="Txttemp" MaximumValue="1800" MinimumValue="100" Type="Integer"></asp:RangeValidator>
                       
                             </div >
                         <%--<div class="col-2">M/C Operator </div >
                         <div class="col-2"><asp:TextBox ID="TxtMCOperator" runat="server" CssClass="form-control" style="width:103px;"></asp:TextBox> </div >--%>
                         <%--<div class="col-2">Wheel No </div >
                         <div class="col-2">
                            <asp:DropDownList ID="DropDownList1" CssClass="form-control ll" runat="server" AutoPostBack="True" style="width:103px;">
                            </asp:DropDownList>
                         </div >--%>
                     </div >
                    <br />
                     <div class="row">
                         <%--<div class="col-2">Temp </div >
                         <div class="col-2">
                            <asp:TextBox ID="Txttemp" runat="server" CssClass="form-control"  onkeypress="isInputNumber(event)" style="width:103px;"></asp:TextBox>
                            <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="please enter the number b/w 100 to 1800" ControlToValidate="Txttemp" MaximumValue="1800" MinimumValue="100" Type="Integer"></asp:RangeValidator>
                       
                             </div >--%>
                         <div class="col-2">M/C No </div >
                         <div class="col-2"><asp:DropDownList ID="DDLheatmcno" runat="server" CssClass="form-control ll" AutoPostBack="True" style="width:103px;">
                            <asp:ListItem Value="select" Selected="True">select</asp:ListItem>
                            <asp:ListItem>0</asp:ListItem>
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="please select m/c no" display="Dynamic" ControlToValidate="DDLheatmcno" InitialValue="select"></asp:RequiredFieldValidator> </div >
                         <div class="col-2">M/C Operator </div >
                         <div class="col-2"><asp:TextBox ID="TxtMCOperator" runat="server" CssClass="form-control" style="width:103px;"></asp:TextBox> </div >
                         <div class="col-2">Status </div >
                         <div class="col-2"><asp:DropDownList ID="DDLheat_status" runat="server" CssClass="form-control ll" AutoPostBack="True" style="width:103px;">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>OK</asp:ListItem>
                            <asp:ListItem>NOT OK</asp:ListItem>
                            </asp:DropDownList> </div >
                         </div>
                     <br />
                     <div class="row">
                       <asp:Panel runat="server" ID="Panel5" >
                         <div class="col-2">XC/Offload Code </div >
                         <div class="col-2"><asp:DropDownList ID="DDLheatXC_code" runat="server"    CssClass="form-control ll"  style="width:103px;">
                            <asp:ListItem></asp:ListItem>
    <asp:ListItem>XC-3</asp:ListItem>
    <asp:ListItem>XC-10</asp:ListItem>
    <asp:ListItem>XC-13</asp:ListItem>
    <asp:ListItem>XC-15</asp:ListItem>
    <asp:ListItem>XC-30</asp:ListItem>
    <asp:ListItem>XC-31</asp:ListItem>
    <asp:ListItem>XC-32</asp:ListItem>
    <asp:ListItem>XC-39</asp:ListItem>
    <asp:ListItem>XC-46</asp:ListItem>
    <asp:ListItem>XC-48</asp:ListItem>
    <asp:ListItem>XC-50</asp:ListItem>
    <asp:ListItem>XC-51</asp:ListItem>
    <asp:ListItem>XC-53</asp:ListItem>
    <asp:ListItem>XC-56</asp:ListItem>
    <asp:ListItem>XC-58</asp:ListItem>
    <asp:ListItem>XC-61</asp:ListItem>
    <asp:ListItem>XC-62</asp:ListItem>
    <asp:ListItem>XC-93</asp:ListItem>
    <asp:ListItem>XC-124</asp:ListItem>
    <asp:ListItem>XC-126</asp:ListItem>
    <asp:ListItem>XC-139</asp:ListItem>
    <asp:ListItem>RNB</asp:ListItem>
    <asp:ListItem>WSC</asp:ListItem>
    <asp:ListItem>WSD</asp:ListItem>
    <asp:ListItem>UNS</asp:ListItem>
    <asp:ListItem>FIN</asp:ListItem>
    <asp:ListItem>ROP</asp:ListItem>
    <asp:ListItem>BS</asp:ListItem>
    <asp:ListItem>BD</asp:ListItem>
    <asp:ListItem>MMT</asp:ListItem>
    <asp:ListItem>PHB</asp:ListItem>
    <asp:ListItem>PND</asp:ListItem>
    <asp:ListItem>HNF</asp:ListItem>
    <asp:ListItem>BackFire</asp:ListItem>
    <asp:ListItem>WTL</asp:ListItem>
    <asp:ListItem>TAIL</asp:ListItem>
    <asp:ListItem>ThickFlange</asp:ListItem>
    <asp:ListItem>AlRdyDone</asp:ListItem>
    <asp:ListItem>ByPass</asp:ListItem>
                            </asp:DropDownList> </div >
                           </asp:Panel>
                     </div >
                     <br />
    </div></div>
     </asp:Panel>

        <asp:Panel runat="server" ID="Panel2" >
               <div class ="row">
                 <div id="table2" class="table" >
                     <div class="row">
                          <div class="col-2">M/C Operator </div >
                         <div class="col-2"><asp:TextBox ID="TxtMCOperator1" runat="server" CssClass="form-control" style="width:103px;"></asp:TextBox> </div >
                         <div class="col-2">Heat No.</div >
                         <div class="col-2">
                            <asp:TextBox ID="Txtheat_no1" runat="server" CssClass="form-control" AutoPostBack="True" style="width:103px;"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" display="Dynamic" ControlToValidate="Txtheat_no1"></asp:RequiredFieldValidator> Donot prefix Zeroes
                         </div >
                         <div class="col-2">Wheel No. </div >
                        <div class="col-2"> <asp:TextBox ID="Txtwheel_no" runat="server"  CssClass="form-control" style="width:103px;"></asp:TextBox> </div >
                        </div>
                     <br />
                         <div class="row">
                         <div class="col-2">Temp </div >
                         <div class="col-2">
                            <asp:TextBox ID="Txttmp" runat="server" CssClass="form-control" onkeypress="isInputNumber(event)" style="width:103px;"></asp:TextBox>
                            <asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="please enter valid temp number" ControlToValidate="Txttmp" MaximumValue="1800" MinimumValue="100" Type="Integer"></asp:RangeValidator>
                         </div >
                          <div class="col-2">M/C No </div > 
                         <div class="col-2"><asp:DropDownList ID="DDLremcno" runat="server" AutoPostBack="true" CssClass="form-control ll" style="width:103px;">
                             <asp:ListItem Value="select">select</asp:ListItem>
                             <asp:ListItem>0</asp:ListItem>
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="please select m/c no" display="Dynamic" ControlToValidate="DDLremcno" InitialValue="select"></asp:RequiredFieldValidator> </div >
                         <div class="col-2">Status </div > 
                         <div class="col-2"><asp:DropDownList ID="DDLrestatus" runat="server" CssClass="form-control ll" AutoPostBack="True" style="width:103px;">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>OK</asp:ListItem>
                            <asp:ListItem>NOT OK</asp:ListItem>
                            </asp:DropDownList> </div >
                             </div>
                     <br />
                     <div class="row">
                        <asp:Panel runat="server" ID="Panel6" >
                         <div class="col-2">XC/Offload Code </div >
                         <div class="col-2"><asp:DropDownList ID="DDLrexccode" runat="server" CssClass="form-control ll" style="width:103px;">
                            <asp:ListItem></asp:ListItem>
    <asp:ListItem>XC-3</asp:ListItem>
    <asp:ListItem>XC-10</asp:ListItem>
    <asp:ListItem>XC-13</asp:ListItem>
    <asp:ListItem>XC-15</asp:ListItem>
    <asp:ListItem>XC-30</asp:ListItem>
    <asp:ListItem>XC-31</asp:ListItem>
    <asp:ListItem>XC-32</asp:ListItem>
    <asp:ListItem>XC-39</asp:ListItem>
    <asp:ListItem>XC-46</asp:ListItem>
    <asp:ListItem>XC-48</asp:ListItem>
    <asp:ListItem>XC-50</asp:ListItem>
    <asp:ListItem>XC-51</asp:ListItem>
    <asp:ListItem>XC-53</asp:ListItem>
    <asp:ListItem>XC-56</asp:ListItem>
    <asp:ListItem>XC-58</asp:ListItem>
    <asp:ListItem>XC-61</asp:ListItem>
    <asp:ListItem>XC-62</asp:ListItem>
    <asp:ListItem>XC-93</asp:ListItem>
    <asp:ListItem>XC-124</asp:ListItem>
    <asp:ListItem>XC-126</asp:ListItem>
    <asp:ListItem>XC-139</asp:ListItem>
    <asp:ListItem>RNB</asp:ListItem>
    <asp:ListItem>WSC</asp:ListItem>
    <asp:ListItem>WSD</asp:ListItem>
    <asp:ListItem>UNS</asp:ListItem>
    <asp:ListItem>FIN</asp:ListItem>
    <asp:ListItem>ROP</asp:ListItem>
    <asp:ListItem>BS</asp:ListItem>
    <asp:ListItem>BD</asp:ListItem>
    <asp:ListItem>MMT</asp:ListItem>
    <asp:ListItem>PHB</asp:ListItem>
    <asp:ListItem>PND</asp:ListItem>
    <asp:ListItem>HNF</asp:ListItem>
    <asp:ListItem>BackFire</asp:ListItem>
    <asp:ListItem>WTL</asp:ListItem>
    <asp:ListItem>TAIL</asp:ListItem>
    <asp:ListItem>ThickFlange</asp:ListItem>
    <asp:ListItem>AlRdyDone</asp:ListItem>
    <asp:ListItem>ByPass</asp:ListItem>
                            </asp:DropDownList> </div ></asp:Panel>
                         </div>
                     <br />
                    
                           </div>
             </div>
        </asp:Panel>
       
        <asp:Panel runat="server" ID="Panel4" >
             <div id="table5" class="table">
                  <div class="row"> 
                      <div class="col-2">SPG Grinding Wheels Replaced  </div >
                         <div class="col-2">
                            <asp:DropDownList ID="DDLSPG" runat="server" CssClass="form-control ll" AutoPostBack="True" style="width:103px;">
                              <asp:ListItem>N</asp:ListItem>
                              <asp:ListItem>Y</asp:ListItem>
                            </asp:DropDownList>
                             </div >
                             <div class="col-2">M/C No </div >
                             <div class="col-2"><asp:DropDownList ID="DDLgrindmc" runat="server" CssClass="form-control ll" AutoPostBack="True" style="width:103px;">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            </asp:DropDownList> </div >
                         <div class="col-2">Heat No </div >
                         <div class="col-2"><asp:TextBox ID="Txtspgrindheat_no" runat="server" CssClass="form-control" AutoPostBack="True" style="width:103px;"></asp:TextBox> </div >
                      </div>
                 <br />
                 <div class="row">  
                      <div class="col-2">Wheel No </div >
                       <div class="col-2">
                            <asp:DropDownList ID="DropDownList2" CssClass="form-control ll" runat="server" style="width:103px;">
                            </asp:DropDownList>
                         </div >
                     </div >
                 <br />
                     <div class="row">
                        <div class="col-2">Grinding Wheels Life </div >
                         <div class="col-2">SPG1 </div >
                         <div class="col-2"><asp:TextBox ID="Txtspg1" runat="server" CssClass="form-control" style="width:103px;"></asp:TextBox> </div >
                          <div class="col-2">SPG2 </div >
                         <div class="col-2"><asp:TextBox ID="Txtspg2" runat="server"  CssClass="form-control" style="width:103px;"></asp:TextBox> </div >
                     </div >
                 <br />
                 <div class="row">
                      <div class="col-2">SPG3 </div >
                         <div class="col-2"><asp:TextBox ID="Txtspg3" runat="server" CssClass="form-control" style="width:103px;"></asp:TextBox> </div >
                          <div class="col-2">SPG4 </div >
                         <div class="col-2"><asp:TextBox ID="Txtspg4" runat="server" CssClass="form-control" style="width:103px;"></asp:TextBox> </div >
                 </div>
                 <br />
                     <div class="row">
                         <div class="col-2">Stopper Pipe Cutting Wheels Replaced</div >
                         <div class="col-2">
                           <asp:DropDownList ID="DDLStpipe" runat="server" AutoPostBack="True" CssClass="form-control ll" style="width:103px;">
                               <asp:ListItem>N</asp:ListItem>
                                <asp:ListItem>Y</asp:ListItem>
                            </asp:DropDownList>
                            </div >
                          <div class="col-2">Heat No </div >
                         <div class="col-2"><asp:TextBox ID="Txtstheatno" runat="server" CssClass="form-control" AutoPostBack="True" style="width:103px;"></asp:TextBox> </div >
                         <div class="col-2">Wheel No </div >
                          <div class="col-2">
                            <asp:DropDownList ID="DropDownList4" CssClass="form-control ll" runat="server" style="width:103px;">
                            </asp:DropDownList>
                         </div >
                    </div >
                 <br />
                     <div class="row">
                           <div class="col-2"> ST.Pipe Cutting Wheels Life</div >
                         <div class="col-2">
                            <asp:TextBox ID="Txtstpipe" runat="server" CssClass="form-control" style="width:103px;"> </asp:TextBox> </div >
                       </div >
                 <br />
                  </div>
         </asp:Panel>

         <div class ="row">
        <div id="table7" class="table">
             <div class="row">
                         <div class="col-2">Remarks</div>
                             <div class="col-2"><asp:TextBox ID="Txtremark" runat="server" CssClass="form-control" MaxLength="200" TextMode="MultiLine" Style="width:500px; height:50px;"></asp:TextBox> </div >
                     </div >
            <br />
                 <div class="row">
           <div class="col-12" align="center"> 
               <asp:Button ID="Btnsave" runat="server" Name="Btnsave" Text="SAVE" CssClass="btn btn-dark" Font-Bold="True" Font-Names="Arial" Font-Size="Medium" />
              <%-- <asp:Button ID="Buttonupdt" runat="server" Name="Buttonupdt" Text="Update" CssClass="btn btn-dark"  visible="false" Font-Bold="True" Font-Names="Arial" Font-Size="Medium" />--%>
                    <asp:Button ID="Btnclear" runat="server" Text="CLEAR"   CssClass="btn btn-dark" Font-Bold="True" Font-Names="Arial" Font-Size="Medium" />
                    <asp:Button ID="Btnexit" runat="server" Text="EXIT"  CssClass="btn btn-dark" Font-Bold="True" Font-Names="Arial" Font-Size="Medium" />
              <asp:Label ID="Label1" runat="server" ForeColor="Red" ></asp:Label>
           </div >
        </div >
            <br />
            </div></div><br />
            <asp:Panel runat="server" ID="Panel7" >
             <div id="table6" class="table">
            <div class="row">
                <div class="col-12"> <asp:DataGrid ID="dg_insert" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" CssClass="table" ForeColor="Black" GridLines="Vertical" ViewStateMode="Enabled" Width="100%">
                               <Columns>
								<asp:ButtonColumn Text="Select" HeaderText="Select" CommandName="Select"></asp:ButtonColumn></Columns>
                               <SelectedItemStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                               <AlternatingItemStyle BackColor="#CCCCCC" />
                               <FooterStyle BackColor="#CCCCCC" />
                               <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                               <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />   
                   
                           </asp:DataGrid> </div >
            </div >
                 <br/>
       </div>
               </asp:Panel>

           <div class ="row">
               <div id="table8" class="table">
                     <div class="row">
					 <div class="col-12"><asp:datagrid id="dghotwheelineheader" CssClass="table" runat="server" CellPadding="4" CellSpacing="2" AutoGenerateColumns="False" forecolor="Black" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" Width="100%">
							<FooterStyle BackColor="#CCCCCC" />
							<HeaderStyle ForeColor="White" BackColor="Black" Font-Bold="True"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Select" HeaderText="Select" CommandName="Select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="Date" HeaderText="Date"></asp:BoundColumn>
								<asp:BoundColumn DataField="Shift" HeaderText="Shift "></asp:BoundColumn>
								<asp:BoundColumn DataField="SSEJE" HeaderText="SSE/JE"></asp:BoundColumn>
								<asp:BoundColumn DataField="StartTime" HeaderText="Start time"></asp:BoundColumn>
								<asp:BoundColumn DataField="FinishTime" HeaderText="Finish time"></asp:BoundColumn>
								
								<asp:BoundColumn DataField="Moulding_WO_No" HeaderText="Moulding_WO_No"></asp:BoundColumn>
								<asp:BoundColumn DataField="SPG1Operator" HeaderText="SPG1 Operator"></asp:BoundColumn>
								<asp:BoundColumn DataField="SPG2Operator" HeaderText="SPG2 Operator"></asp:BoundColumn>
                                <asp:BoundColumn DataField="SPG3Operator" HeaderText="SPG3 Operator"></asp:BoundColumn>
								<asp:BoundColumn DataField="SPG4Operator" HeaderText="SPG4 Operator"></asp:BoundColumn>
                              
							</Columns>
						    <ItemStyle BackColor="White" />
                            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" Mode="NumericPages" />
                            <SelectedItemStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
						</asp:datagrid> </div >
				 </div ></div>
               </div><br />
               <div class ="row">
               <div class="table">
                     <div class="row">
					 <div class="col-12">
            <asp:Panel ID="panel8" runat="server">
            <asp:DataGrid ID="grid1" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" CssClass="table" autogeneratecolumns="false" ForeColor="Black" GridLines="Vertical" Width="100%">
                <%--DataSourceID="SqlDataSource1"--%> 
                <AlternatingItemStyle BackColor="#CCCCCC" />
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle ForeColor="Black" HorizontalAlign="Center" BackColor="#999999" />
                <SelectedItemStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <Columns>
								<asp:ButtonColumn Text="Select" HeaderText="Select" CommandName="Select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="sl_no" HeaderText="SrNo"></asp:BoundColumn>
                                <asp:BoundColumn DataField="date" HeaderText="Date"></asp:BoundColumn>
								<asp:BoundColumn DataField="shift" HeaderText="Shift "></asp:BoundColumn>
								<asp:BoundColumn DataField="process_type" HeaderText="Process Type"></asp:BoundColumn>
								<asp:BoundColumn DataField="heatno" HeaderText="Heat No "></asp:BoundColumn>
								<asp:BoundColumn DataField="wheel_no" HeaderText="Wheel No"></asp:BoundColumn>
								<asp:BoundColumn DataField="spg_temp" HeaderText="SPG Temp"></asp:BoundColumn>
								<asp:BoundColumn DataField="spg_mc_no" HeaderText="SPG Mcn No"></asp:BoundColumn>
								<asp:BoundColumn DataField="spg_status" HeaderText="SPG Status"></asp:BoundColumn>
								<asp:BoundColumn DataField="spg_xc_code" HeaderText="SPG XC Code"></asp:BoundColumn>
                    <asp:BoundColumn DataField="MCoperator" HeaderText="MCoperator"></asp:BoundColumn>
                              
							</Columns>
            </asp:DataGrid>
           <%-- <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:con %>" SelectCommand="select process_type,heatno,wheel_no,spg_temp,spg_mc_no,spg_status,spg_xc_code,MCoperator from mm_hotwheelline_spgnew where date=CONVERT(varchar, getdate(),110) order by process_type ">
          </asp:SqlDataSource>--%>
        </asp:Panel>
</div></div>
                   </div></div>
            
        
    </form></div>
      <%-- <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS </h4></div>--%>
        <div class="card-footer" style="text-align:right;background-color:#cccccc;vertical-align:middle;height:45px; width:100%; bottom:0;"><h4 style="color: black;font-size:15px;">MAINTAINED BY CRIS</h4></div>
</body>
</html>