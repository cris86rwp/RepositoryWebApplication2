<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="HotWheelLineHubCut.aspx.vb" Inherits="WebApplication2.HotWheelLineHubCut" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>
HotWheelLine</title>
  
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR"/>
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>

         <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css"/>

  <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.6/umd/popper.min.js"></script>
  <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/js/bootstrap.min.js"></script>

                <link type="text/css" rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" />

        <link rel="stylesheet" href="StyleSheet1.css" />
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
</nav>    <script>
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

</script>
        
   <div class="container">
   <form id="Form1" method="post" runat="server">
                      
         <asp:Panel runat="server" ID="panel3">
                  <div class ="row">
        <div class="table-responsive">
            <table  class="table"  id="table4">
                  <tr>
                   <td colspan="8" align="center" ><h3> HotWheelLine HubCut Details </h3> <hr class="prettyline" /></td>
                </tr>
                <tr>
                    <td >Date:</td>
                    <td >
                        <asp:TextBox ID="txtdate" runat="server" CssClass="form-control"  onkeypress="return isNumber1(event,this)" MaxLength="10" autopostback="true" Enabled="true"></asp:TextBox></td>
                    <td>Shift:</td>
                    <td>
                       
                        <asp:DropDownList ID="DDLshift" runat="server" AutoPostBack="True" CssClass="form-control ll">
                            <asp:ListItem>select-shift</asp:ListItem>
                            
                            <asp:ListItem>A</asp:ListItem>
                            <asp:ListItem>B</asp:ListItem>
                            <asp:ListItem>C</asp:ListItem>
                            <asp:ListItem>G</asp:ListItem>
                            
                        </asp:DropDownList>
                       
                    <td>SSE/JE:</td>
                  <%--  <td class="tooltiptext">--%>
                        <td>
                        <asp:TextBox ID="TxtSSEJE" runat="server" CssClass="form-control"  onKeyPress="return ValidateAlpha(event);"   ></asp:TextBox></td>
                    <td>Moulding W.O. No.:</td>
                    <td >
                        <asp:TextBox ID="TxtMouldWO" runat="server" CssClass="form-control" MaxLength="4"></asp:TextBox></td>
                </tr>
               
      <tr>     
     <td>HC1 Operator:</td>
     <td><asp:TextBox ID="TxtHC1Oper" runat="server" CssClass="form-control" onKeyPress="return ValidateAlpha(event);"></asp:TextBox></td>
     <td>HC2 Operator:</td>
     <td><asp:TextBox ID="TxtHC2Oper" runat="server" CssClass="form-control" onKeyPress="return ValidateAlpha(event);"></asp:TextBox></td>
     <td>HC3 Operator:</td>
     <td><asp:TextBox ID="TxtHC3Oper" runat="server" CssClass="form-control" onKeyPress="return ValidateAlpha(event);"></asp:TextBox></td>
     <td>Stamping Operator:</td>
     <td><asp:TextBox ID="TxtSTMOper" runat="server" CssClass="form-control" onKeyPress="return ValidateAlpha(event);"></asp:TextBox></td>
    </tr>
                <tr>
                    <td> Start time</td>
                     <td> <asp:TextBox ID="TxtStart_Time" runat="server"  CssClass="form-control"  onblur="validateHhMm(this)" MaxLength="5"   placeholder="hh:mm" Text="00:00" Enabled="True"></asp:TextBox></td><td><div id="result1"></div></td>
                      <td> Finish time</td>
                 <td> <asp:TextBox ID="TxtFinish_Time" runat="server" onblur="validateHhMm1(this)" MaxLength="5" CssClass="form-control"  placeholder="hh:mm" Text="00:00" Enabled="True"></asp:TextBox></td><td><div id="result2"></div></td>
           <td align="center"> <asp:Button ID="BtnSHeader" runat="server" Text="SAVE DETAILS" CssClass="button button2"  CausesValidation="False"/> </td>
          <td><asp:Label ID="Label2" runat="server" ></asp:Label></td>
               </tr>
                <tr>
                    <td>Process:</td>
                   
                    <td colspan="3">
                        <asp:RadioButtonList ID="rbl1" runat="server" CssClass="rbl" AutoPostBack="true"  RepeatLayout="Flow" RepeatDirection="Horizontal">
                            <asp:ListItem Value="heat" Selected="True">Heat</asp:ListItem>
                            <asp:ListItem Value="rework">Rework</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    </tr>
               
                </table></div></div>
                 <asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                   </asp:Panel>
          
         <asp:Panel runat="server" ID="Panel1" >
         <div class ="row">
         <div class="table-responsive">
                <table id="table1" class="table">
                    <tr height="50px">
                         <td>Heat No </td>
                    <td>
                        <asp:TextBox ID="TxtHheat_No" runat="server" CssClass="form-control" ToolTip="enter 6 digit no only" AutoPostBack="True" MaxLength="6" onkeypress="isInputNumber(event)" ></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" display="Dynamic" ControlToValidate="TxtHheat_No"></asp:RequiredFieldValidator> Donot prefix zeroes</td>
                         <td>Wheel No</td>
                        <td>
                            <asp:DropDownList ID="DDLHWheelNo" CssClass="form-control ll" runat="server" AutoPostBack="true">
                            </asp:DropDownList>
                        </td>

                        <td>Temp</td>
                        <td>
                            <asp:TextBox ID="TxtHTemp" runat="server" CssClass="form-control"  onkeypress="isInputNumber(event)"></asp:TextBox>
                             <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="please enter the number b/w 100 to 1800" ControlToValidate="TxtHTemp" MaximumValue="1800" MinimumValue="100" Type="Integer"></asp:RangeValidator>
                        </td>
                        <td> Stamping Status</td>
                       
                         <td><asp:DropDownList ID="DDLHStampStatus" runat="server" CssClass="form-control ll" AutoPostBack="True" width="100px">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>OK</asp:ListItem>
                            <asp:ListItem>Not OK</asp:ListItem>
			                <asp:ListItem>ByPass</asp:ListItem>
                            <asp:ListItem>PND</asp:ListItem>
                            </asp:DropDownList></td>
                          </tr>
                        <tr height="50px">
                        
                        <td>M/C No</td>
                        <td><asp:DropDownList ID="DDLHeatMcNo" runat="server" CssClass="form-control ll" AutoPostBack="True" width="80px">
                            <asp:ListItem>select</asp:ListItem>
                            <asp:ListItem>0</asp:ListItem>
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            </asp:DropDownList> <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="please select m/c no" display="Dynamic" ControlToValidate="DDLHeatMcNo" InitialValue="select"></asp:RequiredFieldValidator></td>
                        <td>HC Operator:</td>
                        <td><asp:TextBox ID="TxtHCHOperator" runat="server" CssClass="form-control"></asp:TextBox></td>
                        <td>Status</td>
                        <td><asp:DropDownList ID="DDLheat_status" runat="server" CssClass="form-control ll" AutoPostBack="True" width="80px">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>OK</asp:ListItem>
                            <asp:ListItem>Not OK</asp:ListItem>
                            </asp:DropDownList></td>
                            <asp:Panel runat="server" ID="Panel5" >
                        <td>XC/Offload Code</td> 
                         <%--<asp:Panel runat="server" ID="Panel5" >--%>
                        <td><asp:DropDownList ID="DDLheatXC_code" runat="server" CssClass="form-control ll" width="80px" >
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
                            </asp:DropDownList></td>

                            </asp:Panel>
                             
                    </tr>
         </table>
             <%--<asp:Label id="Label2" runat="server" ForeColor="Red"></asp:Label>--%>
          
        </div></div>
             </asp:Panel><br />

        <asp:Panel runat="server" ID="Panel2" >
        <div class ="row">
        <div class="table-responsive">
                <table id="table2" class="table" >
                     <tr height="50px"> 
                     <td> Heat No. </td>
                        <td> <asp:TextBox ID="TxtRWheat_No" runat="server" CssClass="form-control" AutoPostBack="True" ></asp:TextBox>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" display="Dynamic" ControlToValidate="TxtRWheat_No"></asp:RequiredFieldValidator> Donot prefix Zeroes
                        </td>
                        
                        <td> Wheel No.</td>
                          <td> <asp:TextBox ID="TxtRWwheel_No" runat="server"  CssClass="form-control" witdh="180px"></asp:TextBox></td>
                        <%--<td> <asp:DropDownList ID="DDLRWWheelNo" CssClass="form-control ll" runat="server">
                            </asp:DropDownList>
                        </td>--%>
                        <td> Temp</td>
                        <td>
                            <asp:TextBox ID="TxtRWtemp" runat="server" CssClass="form-control" ></asp:TextBox>
                             <asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="please enter valid temp number" ControlToValidate="TxtRWtemp" MaximumValue="1800" MinimumValue="100" Type="Integer"></asp:RangeValidator>
                        </td>
                         
                        <td> Stamping Status</td>
                        <td><asp:DropDownList ID="DDLRWStampStatus" runat="server" CssClass="form-control ll" Width="100px">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>OK</asp:ListItem>
                            <asp:ListItem>Not OK</asp:ListItem>
			                <asp:ListItem>ByPass</asp:ListItem>
                            <asp:ListItem>PND</asp:ListItem>
			                <asp:ListItem>A-Done</asp:ListItem>
                            </asp:DropDownList></td>
                        </tr> 
                         <tr height="50px">
                         <td>M/C No</td><td><asp:DropDownList ID="DDLRWMcNo" runat="server" CssClass="form-control ll" AutoPostBack="True">
                            <asp:ListItem>select</asp:ListItem>
                             <asp:ListItem>0</asp:ListItem>
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            </asp:DropDownList>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="please select m/c no" display="Dynamic" ControlToValidate="DDLRWMcNo" InitialValue="select"></asp:RequiredFieldValidator></td>
                                        
                             <td>HC Operator:</td>
                        <td><asp:TextBox ID="TxtHCRWOperator" runat="server" CssClass="form-control"></asp:TextBox></td>
                        <td>Status</td><td><asp:DropDownList ID="DDLRWStatus" runat="server" CssClass="form-control ll" AutoPostBack="true" Width="100px">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>OK</asp:ListItem>
                            <asp:ListItem>Not OK</asp:ListItem>
                            </asp:DropDownList></td>
                             <asp:Panel runat="server" ID="Panel6" >
                        <td>XC/Offload Code</td>
                        <%--<asp:Panel runat="server" ID="Panel6" >--%>
                             <td><asp:DropDownList ID="DDLRWXcCode" runat="server" CssClass="form-control ll" width="80px">
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
                            </asp:DropDownList> </td>

                             </asp:Panel>
                        </tr>
                     </table>
                     </div></div>
             </asp:Panel><br />

         <asp:Panel runat="server" ID="Panel4" >
         <div class ="row">
         <div class="table-responsive">
                <table id="table5" class="table" >

                        <tr><td width="100px">Hub Cutting Nozzle replaced </td>
                        <td width="75px">
                            <asp:DropDownList ID="DDLHC" runat="server" CssClass="form-control ll" AutoPostBack="True">
                                <asp:ListItem>N</asp:ListItem>
                                <asp:ListItem>Y</asp:ListItem>
                                </asp:DropDownList>
                            
                        </td>
                            
                            <td width="100px">M/C No</td>
                            <td width="75px"><asp:DropDownList ID="DDLNZRepMcNo" runat="server" CssClass="form-control ll" AutoPostBack="True">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>                          
                            </asp:DropDownList></td>
                              <td>Nozzale Type</td>
                              <td width="115px"><asp:DropDownList ID="DDLNozzalType" runat="server" CssClass="form-control ll" AutoPostBack="True">
                               <asp:ListItem Value="AC">Air Cool</asp:ListItem>
                                 <asp:ListItem Value="WC">Water cool</asp:ListItem>
                                 </asp:DropDownList></td>
                        <td>Heat No</td>
                            <td width="80px"><asp:TextBox ID="TxtHC_NZ_Heat_No" runat="server" CssClass="form-control" AutoPostBack="True" ></asp:TextBox></td>
                        <td>Wheel No</td>
                            
                             <td width="100px">
                            <asp:DropDownList ID="DDLHC_NZ" CssClass="form-control ll" runat="server" AutoPostBack="true" >
                              
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                       <td>&nbsp;Hub Cutting Nozzle Life</td> 
                      
                        <td>HC1</td>
                        <td><asp:TextBox ID="TxtNLHC1" runat="server" CssClass="form-control"></asp:TextBox></td>
                         <td>HC2</td>
                        <td><asp:TextBox ID="TxtNLHC2" runat="server"  CssClass="form-control"></asp:TextBox></td>
                         <td>HC3</td>
                        <td>
                            <asp:TextBox ID="TxtNLHC3" runat="server"  CssClass="form-control"></asp:TextBox></td>
                    </tr>
                  
                    </table>
                </div> 

               </div> 
        </asp:Panel><br />

         <div class ="row">
        <div class="table-responsive">
     
       <table id="table3" class="table">
               <tr>
                       <td>Remarks:</td>
            <td colspan="5">
                            <asp:TextBox ID="TxtHCRemarks" runat="server" CssClass="form-control" Width="441px" Height="75px"></asp:TextBox></td>
             </tr>
                <tr>
          <td  colspan="12" align="center"> <asp:Button ID="BtnSave" runat="server" Text="SAVE" CssClass="button button2" />
                    <asp:Button ID="BtnClear" runat="server" Text="CLEAR"  CssClass="button button2" />
                    <asp:Button ID="BtnExit" runat="server" Text="EXIT" CssClass="button button2" />
              <asp:Label ID="Label1" runat="server" ></asp:Label>
          </td>
                    
          </tr>
                
        </table>
               <asp:Panel runat="server" ID="Panel7" >
            <table id="table6" class="table">
           <tr>
               <td> <asp:DataGrid ID="dg_insert" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" CssClass="table" ForeColor="Black" GridLines="Vertical" >
                               <SelectedItemStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                               <AlternatingItemStyle BackColor="#CCCCCC" />
                               <FooterStyle BackColor="#CCCCCC" />
                               <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                               <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />                            
                           </asp:DataGrid></td>

               
           </tr>

                
        </table>
               </asp:Panel>

              <div class ="row">
        <div class="table-responsive">
            
              <table id="table8" class="table">
                    <TR>
					<TD colSpan="6"><asp:datagrid id="dghotwheelineHCheader" CssClass="table" runat="server" CellPadding="1" CellSpacing="1" AutoGenerateColumns="False" forecolor="Black">
							<AlternatingItemStyle BackColor="White"></AlternatingItemStyle>
							<HeaderStyle ForeColor="White" BackColor="Navy"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Select" HeaderText="Select" CommandName="Select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="sl_no" HeaderText="sl_no"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Date" HeaderText="Date"></asp:BoundColumn>
								<asp:BoundColumn DataField="Shift" HeaderText="Shift "></asp:BoundColumn>
								<asp:BoundColumn DataField="SSEJE" HeaderText="SSE/JE"></asp:BoundColumn>
								<asp:BoundColumn DataField="HC1Operator" HeaderText="HC1Operator"></asp:BoundColumn>
								<asp:BoundColumn DataField="HC2Operator" HeaderText="HC2Operator"></asp:BoundColumn>
								<asp:BoundColumn DataField="HC3Operator" HeaderText="HC3Operator"></asp:BoundColumn>
								<asp:BoundColumn DataField="STMOperator" HeaderText="STMOperator"></asp:BoundColumn>
								<asp:BoundColumn DataField="HC_StartTime" HeaderText="HC_StartTime"></asp:BoundColumn>
								<asp:BoundColumn DataField="HC_FinishTime" HeaderText="HC_FinishTime"></asp:BoundColumn>
								
								<asp:BoundColumn DataField="Moulding_WO_No" HeaderText="Moulding_WO_No"></asp:BoundColumn>
                               
							</Columns>
						</asp:datagrid></TD>
				</TR></table></div></div>

             <asp:Panel ID="panel8" runat="server">
                  <asp:DataGrid ID="grid1" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" autogeneratecolumns="false" CssClass="table">
            <AlternatingItemStyle BackColor="White"></AlternatingItemStyle>
							
          
                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                <ItemStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" Mode="NumericPages" />
                <SelectedItemStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                   <Columns>
								<asp:ButtonColumn Text="Select" HeaderText="Select" CommandName="Select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="sl_no" HeaderText="sl_no"></asp:BoundColumn>
								<asp:BoundColumn DataField="HC_ProcesType" HeaderText="HC ProcesType"></asp:BoundColumn>
								<asp:BoundColumn DataField="HeatNo" HeaderText="Heat No "></asp:BoundColumn>
								<asp:BoundColumn DataField="Wheel_No" HeaderText="Wheel No"></asp:BoundColumn>
								<asp:BoundColumn DataField="HC_Temp" HeaderText="HC Temp"></asp:BoundColumn>
								<asp:BoundColumn DataField="Stamping_Status" HeaderText="Stamping Status"></asp:BoundColumn>
								<asp:BoundColumn DataField="HC_Mcn_No" HeaderText="HC Mcn No"></asp:BoundColumn>
								<asp:BoundColumn DataField="HC_Status" HeaderText="HC Status"></asp:BoundColumn>
								<asp:BoundColumn DataField="HC_XC_Code" HeaderText="HC XC Code"></asp:BoundColumn>
                              
							</Columns>
            </asp:DataGrid>
        
        </asp:Panel>

            </div></div> 
       
    </form></div> <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS </h4></div>
</body>
</html>
