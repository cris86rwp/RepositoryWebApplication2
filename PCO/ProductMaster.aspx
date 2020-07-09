<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ProductMaster.aspx.vb" Inherits="WebApplication2.ProductMaster" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>ProductMaster</title>
                    
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

       <%--  <link rel="stylesheet" href="StyleSheet1.css" />--%>

<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR"/>
<meta content="Visual Basic 7.0" name="CODE_LANGUAGE"/>
<meta content="JavaScript" name="vs_defaultClientScript"/>
<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
                          <script>

function OnlyNumericEntry() {
        if ((event.keyCode < 48 || event.keyCode > 57)) {
        event.returnValue = false;
    }
                              }
                               function ValidateAlpha(evt)
    {
        var keyCode = (evt.which) ? evt.which : evt.keyCode
        if ((keyCode < 65 || keyCode > 90) && (keyCode < 97 || keyCode > 123) && keyCode != 32)
         
        return false;
            return true;
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
</head>
<body>
         <nav class="mb-1 navbar navbar-expand-sm bg-dark navbar-dark " >
  <a class="navbar-brand p-0" href="#"><img src="../NewFolder1/unnamed.png" class="rounded-circle z-depth-0"  height="45"/> </a>
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
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../wapframeset.aspx">
          <i class="fab glyphicon glyphicon-home " style="font-size:30px;"></i>
        </a></li>

       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../logon.aspx">
          <i class="fab glyphicon glyphicon-log-out" style="font-size:30px;"></i>
        </a></li>
    
        <li class="nav-item ">
        <a class="nav-link p-0" href="#">
          <%--<img src="../../../CRIS-Recruitment.jpg" class="rounded-circle z-depth-0"  height="50" style="border-width: 34px; background-position: 5px 5px; width:50px;margin-top:3px;border-color:white; border-width:50px"/>
        --%><img src="../NewFolder1/CRIS-Recruitment.jpg" height="45" style="border-radius:43%"/>
       </a>
      </li>
     </ul>
      
  </div>
</nav>
<!--/.Navbar -->

         
         <div class="container">
              <div class="row">
                <div class="table-responsive">
       
<form id="Form1" method="post" runat="server">
              <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <%--<h4>Select Background: &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />--%>
<asp:panel id="pnlMain" runat="server">
               

<table id="Table1" class="table">
<tr>
<td>Product Details Entry&nbsp;&nbsp;
<asp:RadioButtonList id="rblProduct" CssClass="rbl" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" RepeatLayout="Flow">
<asp:ListItem Value="Wheel" Selected="True">Wheel</asp:ListItem>

<%--<asp:ListItem Value="Wheel Set">Wheel Set</asp:ListItem>
<asp:ListItem Value="Others">Others</asp:ListItem>--%>
                                       <%-- <asp:ListItem Value="Axle">Axle</asp:ListItem>--%>
</asp:RadioButtonList>&nbsp;&nbsp;&nbsp;
<asp:Button id="btnCheckList" runat="server" CssClass="button button2" Text="Print Check List" ></asp:Button></td>
</tr>
<tr>
<td>
<asp:Label id="lblMessage" runat="server" ForeColor="red"></asp:Label></td>
</tr>
</table>
                 
<table id="Table3" class="table">
<tr>
<td>

            <%--<h4>SELECT WHEEL TYPE</h4>--%>
            <asp:DropDownList id="ddlProductNature" CssClass="form-control ll" runat="server"  AutoPostBack="True" Width="330">
                             
<asp:ListItem Value="BG" Selected="True" >BG</asp:ListItem>
<asp:ListItem Value="MG">MG</asp:ListItem>
                                <asp:ListItem Value="ST">ST</asp:ListItem>
<asp:ListItem Value="NG">NG</asp:ListItem>
</asp:DropDownList></td>

<td>
<asp:DropDownList  id="ddlProductService" CssClass="form-control ll" runat="server" AutoPostBack="True" Width="330" >
<asp:ListItem Value="1" Selected="True">Coach</asp:ListItem>
<asp:ListItem Value="2">Wagon</asp:ListItem>
<asp:ListItem Value="4">Steam Loco</asp:ListItem>
<asp:ListItem Value="5">Diesel Loco</asp:ListItem>
<asp:ListItem Value="6">Electric Loco</asp:ListItem>
<asp:ListItem Value="7">Ingot</asp:ListItem>
<asp:ListItem Value="9">Miscellaneous</asp:ListItem>
</asp:DropDownList></td>
    <td>
<asp:DropDownList id="ddlCondition" CssClass="form-control ll" runat="server" AutoPostBack="True" Width="330">
<asp:ListItem Value="1" Selected="True">Cast</asp:ListItem>
<asp:ListItem Value="2">Rough Machined</asp:ListItem>
<asp:ListItem Value="3">Semi Finished</asp:ListItem>
<asp:ListItem Value="4">Finished</asp:ListItem>
<%--<asp:ListItem Value="6">With Bearings</asp:ListItem>
<asp:ListItem Value="7">With Bearings and Axle Box</asp:ListItem>
<asp:ListItem Value="9">Others</asp:ListItem>--%>
</asp:DropDownList></td>
</tr>
</table>

                    <table id="Table2" class="table">
<tr>

</tr>
</table>

                    <table id="Table4" class="table">
<TR>
<td>ProductCode</td>
<td>:</td>
<td>
<asp:TextBox id="txtProductCode" runat="server" CssClass="form-control" ForeColor="Red"  ReadOnly="True"></asp:TextBox></td>
<TD>Drawing</TD>
<TD>:</TD>
<TD>
<asp:TextBox id="txtDrawing" runat="server" CssClass="form-control"></asp:TextBox></TD>
</TR>
<TR>
<TD>ShortDescription</TD>
<TD>:</TD>
<TD >
<asp:TextBox id="txtDescription" runat="server" CssClass="form-control"></asp:TextBox></TD>
<td>LongDescription</td>
<TD>:</TD>
<TD>
<asp:TextBox id="txtLongDescription" runat="server" CssClass="form-control"></asp:TextBox></TD>
</TR>
<TR>
<TD>TransferQty</TD>
<TD>:</TD>
<TD>
<asp:TextBox id="txtTransferQty" runat="server" CssClass="form-control" MaxLength="99" onkeypress="return isNumber(event, this);" ToolTip="enter Transfer quantity(numeric or float)"></asp:TextBox></TD>
<td>ProductWeightage</td>
<TD>:</TD>
<TD>
<asp:textbox id="txtProdwtg" runat="server" CssClass="form-control" MaxLength="99" onkeypress="return isNumber(event, this);" ToolTip="enter product weightage(numeric or float)"></asp:textbox>
<asp:RangeValidator id="RangeValidator5" runat="server" ControlToValidate="txtProdwtg" Display="Dynamic" ErrorMessage="> 0 Plz" Type="Double" MinimumValue="0.1" MaximumValue="9999999"></asp:RangeValidator></TD>
</TR>
<TR>
<TD>ScrapPercentage</TD>
<TD>:</TD>
<TD>
<asp:textbox id="txtScrapPercentage" runat="server" CssClass="form-control" ToolTip="enter scrap %(numeric or float )" onkeypress="return isNumber(event, this);"></asp:textbox>%</TD>
<TD>ProcessLossPercentage</TD>
<TD>:</TD>
<TD>
<asp:textbox id="txtLossPcnt" runat="server" CssClass="form-control" ToolTip="enter Product Loss %(numeric or float)" onkeypress="return isNumber(event, this);"></asp:textbox>%</TD>
</TR>
<TR>
<TD colSpan="3">
<asp:RangeValidator id="RangeValidator3" runat="server" ControlToValidate="txtScrapPercentage" Display="Dynamic" ErrorMessage="Not  < 0 and Not > 100" Type="Double" MinimumValue="0.0" MaximumValue="100"></asp:RangeValidator></TD>
<TD colSpan="3">
<asp:RangeValidator id="RangeValidator2" runat="server" ControlToValidate="txtLossPcnt" Display="Dynamic" ErrorMessage="Not  < 0 and Not > 100" Type="Double" MinimumValue="0.0" MaximumValue="100"></asp:RangeValidator></TD>
</TR>
<TR>
<TD>Specification</TD>
<TD>:</TD>
<TD>
<asp:textbox id="txtSpecification" runat="server" CssClass="form-control"></asp:textbox></TD>
<td>Class</td>
<TD>:</TD>
<TD>
<asp:DropDownList id="ddlClass" CssClass="form-control ll" runat="server" AutoPostBack="True" >
<asp:ListItem Value="A" Selected="True">A</asp:ListItem>
<asp:ListItem Value="B">B</asp:ListItem>
<asp:ListItem Value="C">C</asp:ListItem>
<asp:ListItem Value="SPL">SPL</asp:ListItem>
</asp:DropDownList></TD>
</TR>
<TR>
<TD>Transfer Price</TD>
<TD>:</TD>
<TD>
<asp:textbox id="txtTransferPrice" runat="server" CssClass="form-control" ToolTip="enter transfer price(numeric or float)" onkeypress="return isNumber(event, this);"></asp:textbox></TD>
<TD>Sale Price</TD>
<TD>:</TD>
<TD>
<asp:textbox id="txtSalePrice" runat="server" CssClass="form-control" ToolTip="enter sale price(numeric or float)" onkeypress="return isNumber(event, this);"></asp:textbox>&nbsp;NRCPrice
<asp:TextBox id="txtNRCPrice" runat="server" CssClass="form-control" ToolTip="enter price(numeric or float)" onkeypress="return isNumber(event, this);"></asp:TextBox></TD>
</TR>
<TR>
<TD>Rough Weight</TD>
<TD>:</TD>
<TD>
<asp:textbox id="txtRoughWeight" runat="server" CssClass="form-control" ToolTip="enter Rough weight(numeric or float)" onkeypress="return isNumber(event, this);"></asp:textbox></TD>
<TD>Finish Weight</TD>
<TD>:</TD>
<TD>
<asp:textbox id="txtFinishWeight" runat="server" CssClass="form-control" ToolTip="enter finish weight(numeric or float)" onkeypress="return isNumber(event, this);"></asp:textbox></TD>
</TR>
<TR>
<TD>WTA Name</TD>
<TD>:</TD>
<TD>
<asp:TextBox id="txtWTAName" runat="server" CssClass="form-control"></asp:TextBox></TD>
<TD>CustomerDrawingNumber</TD>
<TD>:</TD>
<TD>
<asp:TextBox id="txtcustomer_drawing_number" runat="server" CssClass="form-control"></asp:TextBox></TD>
</TR>
</table>

                   
<asp:Panel id="pnlWheel" runat="server">
<table id="Table6" class="table" style="position:center">
<tr>
<td>WeightPerWheel</td>
<td>
<asp:TextBox id="txtWeightPerWheel" runat="server" CssClass="form-control" MaxLength="99" ToolTip="enter weight per wheel(numeric or float)" onkeypress="return isNumber(event, this);"></asp:TextBox></td>
<TD>WheelPerMT</TD>
<TD>
<asp:TextBox id="txtWheelPerMT" runat="server" CssClass="form-control" ToolTip="enter WheelPerMt(numeric or float)" onkeypress="return isNumber(event, this);"></asp:TextBox></TD>

                                    <TD>MinTreadDia</TD>
<TD>
<asp:TextBox id="txtMinTreadDia" runat="server" CssClass="form-control" ToolTip="enter min Tread diameter(float)" onkeypress="return isNumber(event, this);"></asp:TextBox></TD>
<TD>MaxTreadDia</TD>
<TD>
<asp:TextBox id="txtMaxTreadDia" runat="server" CssClass="form-control" ToolTip="enter max Tread diameter(float)" onkeypress="return isNumber(event, this);"></asp:TextBox></TD>
</tr>
                                    <tr><TD>MinBoreDia</TD>
<TD>
<asp:TextBox id="txtMinBoreDia" runat="server" CssClass="form-control" ToolTip="enter min Bore diameter(float)" onkeypress="return isNumber(event, this);"></asp:TextBox></TD>
<TD>MaxBoreDia</TD>
<TD>
<asp:TextBox id="txtMaxBoreDia" runat="server" CssClass="form-control" ToolTip="enter max Bore diameter(float)" onkeypress="return isNumber(event, this);"></asp:TextBox></TD>


<TD>RejPercent</TD>
<TD>
<asp:TextBox id="txtRejPercent" runat="server" ToolTip="enter rejection percentage(float)" onkeypress="return isNumber(event, this);" CssClass="form-control"></asp:TextBox></TD>
<TD>MRRejPercent</TD>
<TD>
<asp:TextBox id="txtMRRejPercent" runat="server" ToolTip="enter MR rejection percentage(float)" onkeypress="return isNumber(event, this);" CssClass="form-control"></asp:TextBox></TD>
</tr>
                                    <tr><TD>MinPlateThk</TD>
<TD>
<asp:TextBox id="txtMinPlateThk" runat="server" CssClass="form-control" ToolTip="enter plate thickness minimum(float)" onkeypress="return isNumber(event, this);"></asp:TextBox></TD>

                                   <TD>MaxPlateThk</TD>
<TD>
<asp:TextBox id="txtMaxPlateThk" runat="server" CssClass="form-control" ToolTip="enter plate thickness maximum(float)" onkeypress="return isNumber(event, this);"></asp:TextBox></TD>
<TD>OverSizeMin</TD>
<TD>
<asp:TextBox id="txtOverSizeMin" runat="server" CssClass="form-control" ToolTip="enter over size minimum(float)" onkeypress="return isNumber(event, this);"></asp:TextBox></TD>
<TD>OverSizeMax</TD>
<TD>
<asp:TextBox id="txtOverSizeMax" runat="server" CssClass="form-control" ToolTip="enter over size maximum(float)" onkeypress="return isNumber(event, this);"></asp:TextBox></TD>
</TR>
<TR>
<TD>MinWhlNo</TD>
<TD>
                                           

<asp:TextBox id="txtMinWhlNo" runat="server" CssClass="form-control"  ToolTip="enter min wheel number(only numeric)" onkeypress="OnlyNumericEntry()" placeholder="1"></asp:TextBox></TD>
<TD>MaxWhlNo</TD>
<TD>
<asp:TextBox id="txtMaxWhlNo" runat="server" CssClass="form-control" ToolTip="enter max wheel number(only numeric)" onkeypress="OnlyNumericEntry()" placeholder="999" MaxLength="999"></asp:TextBox></TD>
<TD>SplSizeMin</TD>
<TD>
<asp:TextBox id="txtSplSizeMin" runat="server" CssClass="form-control" ToolTip="enter spl size minimum(float)" onkeypress="return isNumber(event, this);"></asp:TextBox></TD>

                                   <TD>SplSizeMax</TD>
<TD>
<asp:TextBox id="txtSplSizeMax" runat="server" CssClass="form-control" ToolTip="enter spl size maximum(float)" onkeypress="return isNumber(event, this);"></asp:TextBox></TD>
</tr>
                                    <tr>
                                        <TD>McnMinDia</TD>
<TD>
<asp:TextBox id="txtMcnMinDia" runat="server" CssClass="form-control" ToolTip="enter mcn minimum diameter(float)" onkeypress="return isNumber(event, this);"></asp:TextBox></TD>
<TD>WheelsPerHt</TD>
<TD>
<asp:TextBox id="txtWheelsPerHt" runat="server" CssClass="form-control" ToolTip="enter wheels per heat(float)" onkeypress="OnlyNumericEntry()"></asp:TextBox></TD>


<TD>LowBHN</TD>
<TD>
<asp:TextBox id="txtLowBHN" runat="server" CssClass="form-control" ToolTip="enter low bhn(float)" onkeypress="return isNumber(event, this);"></asp:TextBox></TD>
<TD>HighBHN</TD>
<TD>
<asp:TextBox id="txtHighBHN" runat="server" CssClass="form-control" ToolTip="enter high bhn(float)" onkeypress="return isNumber(event, this);"></asp:TextBox></TD>
</tr>
                                    <tr><TD>SeriesStart</TD>
<TD>
<asp:TextBox id="txtSeriesStart" runat="server" CssClass="form-control" ToolTip="enter series start number (numeric)" onkeypress="OnlyNumericEntry()"></asp:TextBox></TD>
<TD>SeriesEnd</TD>
<TD>
<asp:TextBox id="txtSereiesEnd" runat="server" CssClass="form-control" ToolTip="enter series end number(numeric)" onkeypress="OnlyNumericEntry()"></asp:TextBox></TD>

</TR>
</table>
</asp:Panel>

<asp:Panel id="pnlAxle" runat="server">

                                    
<table id="Table8" class="table">
<TR>
<TD>Weightage at Forge Shop</TD>
<TD>
<asp:TextBox id="txtWtAtForge" runat="server" ToolTip="enter Weightage at forge shop(numeric or float)" onkeypress="return isNumber(event, this);" CssClass="form-control"></asp:TextBox></TD>
<TD>Specification (R43/16)</TD>
<TD>
<asp:DropDownList id="ddlR43R16" CssClass="form-control ll" Width="270px"  runat="server" AutoPostBack="True" >
<asp:ListItem Value="R-43" Selected="True">R-43</asp:ListItem>
<asp:ListItem Value="R-16">R-16</asp:ListItem>
</asp:DropDownList></TD>
</TR>
<TR>
<TD colSpan="4">Make :
<asp:RadioButtonList id="rblMake" CssClass="rbl" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" RepeatLayout="Flow"></asp:RadioButtonList></TD>
</TR>
<TR>
<TD colSpan="4">Source :
<asp:RadioButtonList id="rblSource" CssClass="rbl" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" RepeatLayout="Flow"></asp:RadioButtonList></TD>
</TR>
<TR>
<TD>CastGroup:</TD>
<TD><asp:checkbox id="chkCastGrpAvailable"  runat="server"  AutoPostBack="True" Text="Show New Cast Groups" Font-Bold="True"></asp:checkbox></TD>
<TD><asp:DropDownList id="ddlCastGroup" runat="server" CssClass="form-control ll" Width="550px" AutoPostBack="True"></asp:DropDownList></TD>
</TR>
<TR>
<TD colSpan="4">Present Stage is
<asp:DropDownList id="ddlInitialStage" CssClass="form-control ll" runat="server" AutoPostBack="True" >
<asp:ListItem Value="FG" Selected="True">FG</asp:ListItem>
<asp:ListItem Value="RT">RT</asp:ListItem>
<asp:ListItem Value="FI">FI</asp:ListItem>
</asp:DropDownList></TD>
</TR>
</table>

<asp:panel id="pnlStageRT" runat="server">
<table id="Table10" class="table">
<TR>
<TD>Next&nbsp;Stage&nbsp;RT Product Code</TD>
<TD>:</TD>
<TD>
<asp:textbox id="txtFGtoRT" runat="server" AutoPostBack="True" ToolTip="enter next stage RT prod code" CssClass="form-control"></asp:textbox></TD>
</TR>
<TR>
<TD>Next&nbsp;Stage FI&nbsp; Product Code</TD>
<TD>:</TD>
<TD>
<asp:textbox id="txtFGtoFI" runat="server" AutoPostBack="True" ToolTip="enter next stage FI prod code" CssClass="form-control"></asp:textbox></TD>
</TR>
</table>
</asp:panel>
<asp:panel id="pnlStageFI" runat="server">
                                                           
<table id="Table11" class="table">
<TR>
<TD>Next&nbsp;Stage&nbsp;RT&nbsp; Product Code</TD>
<TD>:</TD>
<TD>
<asp:TextBox id="txtRTtoFI" runat="server" AutoPostBack="True" CssClass="form-control"></asp:TextBox></TD>
</TR>
</table>
                                                             
</asp:panel>
                                <table class="table">
<TR>
<TD colSpan="4">Products of Similar
<asp:DropDownList id="ddlSimilarProds" CssClass="form-control ll" runat="server" AutoPostBack="True">
<asp:ListItem Value="Drawing">Drawing</asp:ListItem>
<asp:ListItem Value="Specification">Specification</asp:ListItem>
<asp:ListItem Value="Make">Make</asp:ListItem>
<asp:ListItem Value="Source">Source</asp:ListItem>
<asp:ListItem Value="Stage">Stage</asp:ListItem>
<asp:ListItem Value="Cast Group" Selected="True">Cast Group</asp:ListItem>
</asp:DropDownList></TD>
</TR>
<TR>
<TD colspan="4">
<asp:checkbox id="chkInputs" runat="server" AutoPostBack="True" Text="Check Inputs before saving" Font-Bold="True"></asp:checkbox></TD>
</TR>
</table>

                                           <table id="Table9" class="table">
<TR>
<TD>
<asp:datagrid id="dgSimilarProducts" CssClass="table" runat="server" BorderStyle="Ridge" CellPadding="3" BackColor="White" BorderWidth="2px" BorderColor="White" PageSize="5">
<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#9471DE"></SelectedItemStyle>
<ItemStyle ForeColor="Black" BackColor="#DEDFDE"></ItemStyle>
<HeaderStyle Font-Bold="True" ForeColor="#E7E7FF" BackColor="#4A3C8C"></HeaderStyle>
<FooterStyle ForeColor="Black" BackColor="#C6C3C6"></FooterStyle>
<PagerStyle HorizontalAlign="Right" ForeColor="Black" BackColor="#C6C3C6"></PagerStyle>
</asp:datagrid></TD>
</TR>
</table>
</asp:Panel>

<asp:Panel id="pnlSet" runat="server">
<table id="Table7" class="table">
<TR>
<TD>MinPr</TD>
<TD>
<asp:TextBox id="txtMinPr" runat="server" CssClass="form-control"></asp:TextBox></TD>
<TD>MaxPr</TD>
<TD>
<asp:TextBox id="txtMaxPr" runat="server" CssClass="form-control"></asp:TextBox></TD>
</TR> <TR>
<TD>MinGauge</TD>
                                       
                                 
                                
<TD>
<asp:TextBox id="txtMinGauge" runat="server" CssClass="form-control"></asp:TextBox></TD>
                                  
<TD>MaxGauge</TD>
<TD>
<asp:TextBox id="txtMaxGauge" runat="server" CssClass="form-control"></asp:TextBox></TD>
                                        </TR>
                                      <TR>
<TD>WheelProduct</TD>
<TD>
<asp:DropDownList id="ddlWheel" runat="server" CssClass="form-control"> </asp:DropDownList></TD>
<TD>AxleProduct</TD>
<TD>
<asp:DropDownList id="ddlAxle" runat="server" CssClass="form-control"></asp:DropDownList></TD>
</TR>
</table>
</asp:Panel>
                <table class="table">
<TR>
<TD>
<asp:Button id="btnSave" runat="server" Text="Save" CssClass="button button2"></asp:Button>
<asp:Label id="lblMode" runat="server"></asp:Label></TD>
</TR>
</table>

                    <asp:DataGrid id="dgProductList" CssClass="table" runat="server" BorderStyle="None" CellPadding="4" BackColor="White" BorderWidth="1px" BorderColor="#CC9966">
<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
<Columns>
<asp:ButtonColumn Text="Edit" CommandName="Select"></asp:ButtonColumn>
</Columns>
<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
</asp:DataGrid>

</asp:panel>
                        </form>
            </div></div></div>
        <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
</body>
</html>

