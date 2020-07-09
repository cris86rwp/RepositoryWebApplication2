<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SandPreparationNew.aspx.vb" Inherits="WebApplication2.SandPreparationNew" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sand Preparation</title>
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
  <style>
     
 .rbl input[type="radio"] {
    margin-left: 6px;
    margin-right: 0px;
}
  .ui-datepicker {
    background: #333;
    border: 1px solid #555;
    color: #EEE;
   
}
      </style>
    <script>
        function isInputNumber(evt) {
            var ch = String.fromCharCode(evt.which);
            if (!(/[0-9]/.test(ch)))
            {
                evt.preventDefault();
            }
        }

        function isInputNumber1(evt) {
            var ch = String.fromCharCode(evt.which);
            if (!(/[1-9]/.test(ch)))
            {
                evt.preventDefault();
            }
        }

        //for date
        function isNumber1(evt, element) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (
                           (charCode != 45 ) && (charCode != 47 ) &&     //
                           (charCode < 48 || charCode > 57))
                      return false;
                    return true;
        }
        //for number with decimal
        function isNumber(evt, element) {
                var charCode = (evt.which) ? evt.which : event.keyCode
                if (
           /* (charCode != 45 || $(element).val().indexOf('-') != -1) && */     // “-” CHECK MINUS, AND ONLY ONE.
            (charCode != 46 || $(element).val().indexOf('.') != -1) &&      // “.” CHECK DOT, AND ONLY ONE.
            (charCode < 48 || charCode > 57))
            return false;

        return true;
        }    

           function validateHhMm(inputField) {
                         var isValid = /^([0-9]|0[0-9]|1[0-9]|2[0-3]):([0-5][0-9])$/.test(inputField.value);

                     if (isValid) {
                         document.getElementById("result1").innerHTML = "";
                              inputField.style.backgroundColor = '#ffffff';
             
                     } else {
                           document.getElementById("result1").innerHTML = "*Time is Invalid";
                         inputField.style.backgroundColor = '#ff8080';
                   
                     }

                      return isValid;
        }
         $(document).ready(function () {
                       
                        $('#sanddate').datepicker({
                            dateFormat: "dd/mm/yy",
                       
                            onSelect: function(date){            
                                var date1 = $('#sanddate').datepicker('getDate');          
                                                 
                             
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
     
</head>
<body>

   <nav class="mb-1 navbar navbar-expand-sm bg-dark navbar-dark " >
  <a class="navbar-brand p-0" href="#"><img src="../../..//NewFolder1/unnamed.png" class="rounded-circle z-depth-0"  height="45"/> </a>
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
          <i class="fab glyphicon glyphicon-home " style="font-size:30px"></i>
        </a></li>

       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../../logon.aspx">
          <i class="fab glyphicon glyphicon-log-out" style="font-size:30px"> </i>
        </a></li>
   
        <li class="nav-item ">
        <a class="nav-link p-0" href="#">
         
        <img src="../../../NewFolder1/CRIS-Recruitment.jpg" height="45" style="border-radius:43%"/>
       </a>
      </li>
     </ul>
     
  </div>
</nav>
    <div class="container" align="center">
        <form id="form1" runat="server">
           
            <asp:Panel ID="Panel1" runat="server">
                <div class="row">
                 
                        <div class="table">
                            <div class="row" >
                               <div class="col"  colspan="9"> <h2><Strong>SAND PLANT DETAILS</h2> </Strong>  <%--<strong></strong> style="text-align: center"--%>
                                   
                                </div >
                            </div >
                        <br>    <div class="row" >
                                <div class="col"  colspan="9">
                                    <asp:Label ID="lblmsg" runat="server" ForeColor="red"></asp:Label>
                                </div >
                            </div >
                            <div class="row" >
                                <div class="col" >
                                    <asp:Label ID="lbldate" runat="server">Date </asp:Label>
                                </div >
                                <div class="col" >
                                    <asp:TextBox ID="sanddate" runat="server" AutoPostBack="True" CssClass="form-control" Enabled="True"
                                onkeypress="return isNumber1(event,this)"     MaxLength="10"></asp:TextBox>
                                </div >
                                <div class="col" > <asp:Label ID="lblshift" runat="server">Shift</asp:Label>
                                    <asp:RadioButtonList id="rblshift" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="rbl">
                                        <asp:ListItem Value="A" Selected="True">A</asp:ListItem>
                                        <asp:ListItem Value="B">B</asp:ListItem>
                                        <asp:ListItem Value="C">C</asp:ListItem>
                                        <asp:ListItem Value="G">G</asp:ListItem>
                                    </asp:RadioButtonList>
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                </div >
                                <div class="col"></div>
                                <div class="col" >
                                    <asp:Label ID="lbl_sseje" runat="server">&nbsp;&nbsp;SSE/JE</asp:Label>
                               </div >
                                                       
                                <div class="col" >
                                    <asp:TextBox ID="sse_jename" runat="server" CssClass="form-control" ToolTip="Enter sse/je name"></asp:TextBox>
                                </div >

                                  </div>
                         <br>   <div class="row">
                                <div class="col" >
                                    <asp:Label ID="lbl_opreator1" runat="server">Operator 1</asp:Label>
                                </div >
                                <div class="col" >
                                    <asp:TextBox ID="operator1" runat="server" CssClass="form-control" ToolTip="Enter operator1 name"></asp:TextBox>
                                </div >
                                <div class="col" >
                                    <asp:Label ID="lbl_operator2" runat="server">Operator 2 </asp:Label>
                                   
                                </div >
                                <div class="col" >
                                    <asp:TextBox ID="tboperator2" runat="server" CssClass="form-control" ToolTip="Enter operator2 name"></asp:TextBox>
                                </div >
                           
                                <div class="col" >
                                    <asp:Label ID="lblrecipe" runat="server">Recipe</asp:Label>        
                                </div >
                                <div class="col" >
                                    <asp:CheckBox ID="chk_recipe" runat="server" AutoPostBack="true" OnCheckedChanged="chk_recipe_CheckedChanged"/>
                                </div >
                            </div >
                            <div class="row" >
                                <div class="col" align="centre"><h3><strong>Sand Position</h3></strong></div>
                            </div >
                           <br>    
                             <div class="row" >                              
                                <div class="col" > <asp:Label ID="lblbumker1" runat="server">Bunker_No_1_(in_MT)</asp:Label>  </div>
                                <div class="col" >  <asp:TextBox ID="bumker1" runat="server" CssClass="form-control" onkeypress="return isNumber(event, this)" ToolTip="Enter bumker no.1 only in number"> </asp:TextBox>   </div >                              
                              <div class="col" >  <asp:Label ID="lblbumker2" runat="server">Bunker_No_2_(in_MT)</asp:Label>  </div>
                                <div class="col" >  <asp:TextBox ID="bumker2" runat="server" CssClass="form-control" onkeypress="return isNumber(event, this)" ToolTip="Enter bumker no.2 only in number"></asp:TextBox>  </div >
                               <div class="col" >  <asp:Label ID="lblbumker3" runat="server">Bunker_No_3_(in_MT)</asp:Label> </div >
                                <div class="col" >  <asp:TextBox ID="bumker3" runat="server" CssClass="form-control" onkeypress="return isNumber(event, this)" ToolTip="Enter bumker no.3 only in number"></asp:TextBox>  </div >
                                <div class="col" >  <asp:Label ID="lblsilo" runat="server"> Silo </asp:Label>  </div>
                                <div class="col" >  <asp:TextBox ID="silo1" runat="server" CssClass="form-control" ToolTip="Enter silo no. only in number"></asp:TextBox>  </div >  
                           </div >                                                    
                            <%--<div class="row" >
                                 <div class="col" ></div >
                                <div class="col" ></div >
                                <div class="col" > <asp:Label ID="lblbumker1" runat="server">Bunker No 1 (in MT)</asp:Label>
                                </div >
                                <div class="col" >
                                    <asp:TextBox id="bumker1" runat="server" CssClass="form-control" onkeypress="return isNumber(event, this)" ToolTip="Enter bumker no.1 only in number"> </asp:TextBox>
                                </div >  <div class="col" ></div >
                                <div class="col" ></div >
                            </div >
                            <br>   <div class="row" >
                                  <div class="col" ></div >
                                <div class="col" ></div >
                                <div class="col" >
                                    <asp:Label ID="lblbumker2" runat="server">Bunker No 2 (in MT)</asp:Label>
                                </div >
                                <div class="col" >
                                    <asp:TextBox ID="bumker2" runat="server" CssClass="form-control" onkeypress="return isNumber(event, this)" ToolTip="Enter bumker no.2 only in number"></asp:TextBox>
                                </div >
                                  <div class="col" ></div >
                                <div class="col" ></div >
                            </div >
                           <br>    <div class="row" >
                                 <div class="col" ></div >
                                <div class="col" ></div >
                                <div class="col" >
                                    <asp:Label ID="lblbumker3" runat="server">Bunker No 3 (in MT)</asp:Label>
                                </div >
                                <div class="col" >  
                                    <asp:TextBox ID="bumker3" runat="server" CssClass="form-control" onkeypress="return isNumber(event, this)" ToolTip="Enter bumker no.3 only in number"></asp:TextBox>
                                </div >
                                 <div class="col" ></div >
                                <div class="col" ></div >
                            </div >
                          <br>  <div class="row" >
                                <div class="col" ></div >
                                <div class="col" ></div >
                                <div class="col" >
                                <asp:Label ID="lblsilo" runat="server"> Silo </asp:Label>
                                </div >
                                <div class="col" >
                                <asp:TextBox ID="silo1" runat="server" CssClass="form-control" ToolTip="Enter silo no. only in number"></asp:TextBox>
                                </div >
                                <div class="col" ></div >
                                <div class="col" ></div >
                            </div >--%>
                        <br>    <div class="row" >
                                <div class="col" ><asp:Label ID="lbldrier" runat="server"><h5> Drier/Cooler </h5></asp:Label>
                                </div >
                                <div class="col" ></div >
                                <div class="col" ><asp:Label ID="lblstrttime" runat="server">Start_Time </asp:Label>
                                </div >
                                <div class="col" >
                                <asp:TextBox ID="strttime" runat="server" CssClass="form-control" onblur="validateHhMm(this)" MaxLength="5"   ToolTip="time in format HH:MM">00:00</asp:TextBox>
                                </div >
           <div class="col"  style="color:red"><div id="result1" style="color:red"></div></div >
                               
                                <div class="col" >
                                    <asp:Label ID="lblstptime" runat="server">Stop_Time</asp:Label> </div >
                                <div class="col" >
                                    <asp:TextBox ID="stptime"  runat="server" CssClass="form-control" onblur="validateHhMm(this)" MaxLength="5" ToolTip="time in format HH:MM">00:00</asp:TextBox>
                                </div >
                                <div class="col"  style="color:red"><div id="result2" style="color:red"></div></div >
                            </div >
                          <br>  <div class="row" >
                                <div class="col" ><asp:Label ID="lblhxlprep" runat="server"> Hexa Solution Preparation </asp:Label>
                                </div >
                                <div class="col" >
                                    <asp:RadioButtonList ID="rblhxlprep" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="rbl" AutoPostBack="true" OnSelectedIndexChanged="rblhxlprep_SelectedIndexChanged">
                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                        <asp:ListItem Value="0"> No</asp:ListItem>
                                    </asp:RadioButtonList>                                
                                                                       
                                </div >
                                <div class="col" ></div >
                                <div class="col" ></div >

                                <div class="col" >
                                    <asp:Label ID="lblhexa" runat="server" Visible="false"> Hexa Used (in Kg)</asp:Label>  
                                </div >
                                <div class="col" >
                                    <asp:TextBox ID="tbhexa" runat="server" Visible="false" CssClass="form-control" onkeypress="return isNumber(event, this)" ToolTip="Enter hexa_used only in number"></asp:TextBox>  
                                </div >
                            </div >
                        <br>    <div class="row" >
                                <div class="col" ><asp:Label ID="lblbtchcoated" runat="server"> No of Batch Coated</asp:Label>
                                </div >
                                <div class="col" >
                                    <asp:TextBox ID="btchcoated" runat="server" CssClass="form-control" onkeypress="isInputNumber(event)" ToolTip="Enter batch_coated only in number"></asp:TextBox>
                                </div >
                                <div class="col" ><asp:Label ID="lblresin" runat="server">Resin Used (in Kg)</asp:Label>
                                </div >
                                <div class="col" >
                                    <asp:TextBox ID="resin" runat="server" CssClass="form-control" ToolTip="Enter resin_used only in number" onkeypress="return isNumber(event, this)"></asp:TextBox>
                                </div >
                                <div class="col" ><asp:Label ID="lblmake" runat="server">Make</asp:Label>
                                </div >
                                <div class="col" >
                                    <asp:TextBox ID="make" runat="server" CssClass="form-control"></asp:TextBox>
                                </div >
                            </div >
                          <br/>
                            <%-- <div class="row" >
                                <div class="col" >
                                    <asp:Label ID="lblbatch" runat="server"> Sample Collected from Batch No</asp:Label>
                                </div >
                                <div class="col" >
                                    <asp:TextBox ID="tb_batch" runat="server" CssClass="form-control" onkeypress="isInputNumber(event)" ToolTip="Enter the batch no.(only in number)"></asp:TextBox>
                                    <asp:Label ID="lbl_batch" runat="server" ForeColor="White"></asp:Label>
                                </div >
                                <div class="col" >
                                    <asp:Button ID="btn_batch" runat="server" Text="add"   Font-Size="20px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark" />
                                </div >
                                <div class="col" >
                                    <asp:TextBox ID="vw_batch" runat="server" Enabled="false" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                </div >
                            </div >--%>
                             <div class="row">
                                <div class="col-12" align="center"><h3>Sample Collected from Batch No</div>
                                </div><br />
                            <div class="row">
                                <div class="col-1">
                                    <asp:Label ID="sample1" runat="server">SampleNo1</asp:Label>
                                </div >
                                <div class="col-1">
                                    <asp:TextBox ID="sample_no1" runat="server" CssClass="form-control" onkeypress="isInputNumber1(event)" ToolTip="Enter the batch no.(only in number)" style="width:40px;"></asp:TextBox>
                                    <%--<asp:RangeValidator id="rng_batch" runat="server" ControlToValidate="tb_batch" ErrorMessage="batch no. between 1 to 50" MaximumValue="50" MinimumValue="1"></asp:RangeValidator>--%>
                                     </div >
                                 <div class="col-1">
                                    <asp:Label ID="sample2" runat="server">SampleNo2</asp:Label>
                                </div >
                                <div class="col-1">
                                    <asp:TextBox ID="sample_no2" runat="server" CssClass="form-control" onkeypress="isInputNumber1(event)" ToolTip="Enter the batch no.(only in number)" style="width:40px;"></asp:TextBox>
                                     </div >
                                  <div class="col-1">
                                    <asp:Label ID="sample3" runat="server">SampleNo3</asp:Label>
                                </div >
                                <div class="col-1">
                                    <asp:TextBox ID="sample_no3" runat="server" CssClass="form-control" onkeypress="isInputNumber1(event)" ToolTip="Enter the batch no.(only in number)" style="width:40px;"></asp:TextBox>
                                     </div >
                                <div class="col-1">
                                    <asp:Label ID="sample4" runat="server">SampleNo4</asp:Label>
                                </div >
                                <div class="col-1">
                                    <asp:TextBox ID="sample_no4" runat="server" CssClass="form-control" onkeypress="isInputNumber1(event)" ToolTip="Enter the batch no.(only in number)" style="width:40px;"></asp:TextBox>
                                     </div >
                                <div class="col-1">
                                    <asp:Label ID="sample5" runat="server">SampleNo5</asp:Label>
                                </div >
                                <div class="col-1">
                                    <asp:TextBox ID="sample_no5" runat="server" CssClass="form-control" onkeypress="isInputNumber1(event)" ToolTip="Enter the batch no.(only in number)" style="width:40px;"></asp:TextBox>
                                     </div >
                                </div><br />
                            <div class="row">
                                 
                                  <div class="col-1">
                                    <asp:Label ID="sample6" runat="server">SampleNo6</asp:Label>
                                </div >
                                <div class="col-1">
                                    <asp:TextBox ID="sample_no6" runat="server" CssClass="form-control" onkeypress="isInputNumber1(event)" ToolTip="Enter the batch no.(only in number)" style="width:40px;"></asp:TextBox>
                                     </div >
                                 <div class="col-1">
                                    <asp:Label ID="sample7" runat="server">SampleNo7</asp:Label>
                                </div >
                                <div class="col-1">
                                    <asp:TextBox ID="sample_no7" runat="server" CssClass="form-control" onkeypress="isInputNumber1(event)" ToolTip="Enter the batch no.(only in number)" style="width:40px;"></asp:TextBox>
                                     </div >
                                 <div class="col-1">
                                    <asp:Label ID="sample8" runat="server">SampleNo8</asp:Label>
                                </div >
                                <div class="col-1">
                                    <asp:TextBox ID="sample_no8" runat="server" CssClass="form-control" onkeypress="isInputNumber1(event)" ToolTip="Enter the batch no.(only in number)" style="width:40px;"></asp:TextBox>
                                     </div >
                                <div class="col-1">
                                    <asp:Label ID="sample9" runat="server">SampleNo9</asp:Label>
                                </div >
                                <div class="col-1">
                                    <asp:TextBox ID="sample_no9" runat="server" CssClass="form-control" onkeypress="isInputNumber1(event)" ToolTip="Enter the batch no.(only in number)" style="width:40px;"></asp:TextBox>
                                     </div >
                                <div class="col-1">
                                    <asp:Label ID="sample10" runat="server">SampleNo10</asp:Label>
                                </div >
                                <div class="col-1">
                                    <asp:TextBox ID="sample_no10" runat="server" CssClass="form-control" onkeypress="isInputNumber1(event)" ToolTip="Enter the batch no.(only in number)" style="width:40px;"></asp:TextBox>
                                     </div >
                                </div>
                            <br />

                           <div class="row" aria-grabbed="false">
                                <div class="col" >
                                    <asp:Label ID="lblsandmnth" runat="server"> Sand Unloaded in Current Month in Bin </asp:Label>
                                </div >
                                <div class="col" >
                                    <asp:TextBox ID="sandmnth" runat="server" CssClass="form-control" ToolTip="Enter sand amount(in number)" onkeypress="isInputNumber(event)"></asp:TextBox>
                                </div >
                               <div class="col" >
                                    <asp:Label ID="lblremarks" runat="server">Remarks</asp:Label>
                                </div >
                                <div class="col"  colspan="5">
                                    <asp:TextBox ID="remarks" runat="server" CssClass="form-control" TextMode="MultiLine"  Style="width:600px; height:60px;" ></asp:TextBox>
                                </div >
                             <%-- <div class="col" ></div >
                                <div class="col" ></div >
                              <div class="col" ></div >
                                <div class="col" ></div >--%>
                            </div >
                         <%--<br>   <div class="row" >
                                <div class="col" >
                                    <asp:Label ID="lblremarks" runat="server">Remarks</asp:Label>
                                </div >
                                <div class="col"  colspan="5">
                                    <asp:TextBox ID="remarks" runat="server" CssClass="form-control" TextMode="MultiLine"  Style="width:600px; height:60px;" ></asp:TextBox>
                                </div >
                               <div class="col" ></div >
                                <div class="col" ></div >  <div class="col" ></div >
                                <div class="col" ></div >
                            </div >--%>
                          <br>  <div class="row" >
                                <div class="col"  colspan="4"><asp:Button ID="btnsave" runat="server" Text="Save"  Font-Size="20px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark" /></div >
                                <div class="col"  colspan="5"><asp:Button ID="btnreset" runat="server" Text="Reset"  Font-Size="20px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark" /></div >
                            </div >
                            <%--<div class="row" >
                                <div class="col"  colspan="2">
                                    <asp:Label ID="msg" runat="server"  ForeColor="White"></asp:Label>
                                </div >
                            </div >--%>
                        </div>
                        <asp:Panel ID="vw_sand_panels" runat="server">
                            <asp:DataGrid ID="vw_sand_details" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CssClass="table" CellSpacing="2" HorizontalAlign="Left">
                             <columns>
                                 <asp:ButtonColumn text="Select" HeaderText="Select" CommandName="Select"> </asp:ButtonColumn></columns>
                                <SelectedItemStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                                <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                                <ItemStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" Mode="NumericPages" />
                            </asp:DataGrid>
                        </asp:Panel>
                       
                        <br />
                        <br />
                       
                        <asp:Panel ID="vw_batch_panel" runat="server">
                            <asp:DataGrid ID="Vw_batch_no" runat="server" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CssClass="table" CellSpacing="1" GridLines="None">
                                  <columns>
                                 <asp:ButtonColumn text="Select" HeaderText="Select" CommandName="Select"> </asp:ButtonColumn></columns>
                                <SelectedItemStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                                <ItemStyle BackColor="#DEDFDE" ForeColor="Black" />
                                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
         
                            </asp:DataGrid>
                        </asp:Panel>
   
   
                    </div>
               
            </asp:Panel>
        </form>
    </div>
    <div class="card-footer" style="text-align:right;background-color:#cccccc;vertical-align:middle;position:relative;bottom:0;width:100%;height:60px"><h4 style="color: black;font-size:15px">MAINTAINED BY CRIS</h4></div>
</body>
</html>
