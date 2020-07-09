<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="HeatTreatmentMaster.aspx.vb" Inherits="WebApplication2.HeatTreatmentMaster" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> HeatTreatmentMaster </title>
  
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR"/>
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>

         <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css"/>

  <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.6/umd/popper.min.js"></script>
  <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/js/bootstrap.min.js"></script>
  <link type="text/css" rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" />
  <%--<link rel="stylesheet" href="../../../StyleSheet1.css" />--%>
 </head>
 <body>

  <nav class="mb-1 navbar navbar-expand-sm bg-dark navbar-dark " >
  <a class="navbar-brand p-0" href="#"><img src="../../../NewFolder1/unnamed.png" class="rounded-circle z-depth-0"  height="45"/> </a>
  <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent-333"
    aria-controls="navbarSupportedContent-333" aria-expanded="false" aria-label="Toggle navigation">
    <span class="navbar-toggler-icon"></span>
  </button>
  <div class="collapse navbar-collapse " id="navbarSupportedContent-333">
      <ul class="navbar-nav ml-auto  navbar-center">
          <li class="nav-item"> <a class="nav-link" href="#" style="color:white; font-size:25px;">Rail Wheel Plant Bela</a></li>
      </ul>
    <ul class="navbar-nav ml-auto  navbar-right">
        <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../../wapframeset.aspx">
          <i class="fab glyphicon glyphicon-home " style="font-size:30px;"></i>
        </a></li>
       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../../logon.aspx">
          <i class="fab glyphicon glyphicon-log-out" style="font-size:30px;"></i>
        </a></li> 
    
        <li class="nav-item ">
        <a class="nav-link p-0" href="#">
          <img src="../../../NewFolder1/CRIS-Recruitment.jpg" class="rounded-circle z-depth-0"  height="45"/>
        </a>
      </li>
     </ul>
      
  </div>
</nav>
        
   <div class="container">
   <form id="Form1" method="post" runat="server">

                     <div class="row">
    
                  <%--<h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />--%>
      </div>
         <asp:Panel runat="server" ID="panel3">
                  <div class ="row">
        <div class="table-responsive">
            <table  class="table"  id="table4">
          <tr>
                   <td colspan="8" align="center" ><h4> HEAT TREATMENT MASTER REGISTER </h4> <hr class="prettyline" /></td>
                </tr>
                <tr>
                    <td > Date:</td>
                    <td >
                        <asp:TextBox ID="txtdate" runat="server"  CssClass="form-control"></asp:TextBox></td> 
                     <%--  <td> Time </td>
                     <td> <asp:TextBox ID="TxtTime" runat="server" CssClass="form-control" placeholder="hh:mm:ss"></asp:TextBox></td>--%>

                    <td>shift:</td>
                    <td>   <asp:DropDownList ID="DDLshift" runat="server" AutoPostBack="True" CssClass="form-control ll">
                            <asp:ListItem>select-shift</asp:ListItem>
                            <asp:ListItem>A</asp:ListItem>
                            <asp:ListItem>B</asp:ListItem>
                            <asp:ListItem>C</asp:ListItem>
                            <asp:ListItem>G</asp:ListItem>                            
                        </asp:DropDownList>                
                    <td class="tooltiptext"> </td>
                    <td> Operator:</td>
                    <td> <asp:TextBox ID="TxtOperator" runat="server" CssClass="form-control"></asp:TextBox></td>
                    </tr>                             
                </table></div></div>
                 <asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                   </asp:Panel>
          
         <asp:Panel runat="server" ID="Panel1" >
             <div class ="row">
        <div class="table-responsive">
                <table id="table1" class="table">
                    <tr>
                         <td> Heat Number </td>
                    <td>
                        <asp:TextBox ID="TxtHeat_No" runat="server" CssClass="form-control" ToolTip="enter 6 digit no only" AutoPostBack="True" ></asp:TextBox></td>
                  
                        <td>Wheel No </td>
                        <td>
                            <asp:DropDownList ID="DDLWheelNo" CssClass="form-control ll" runat="server">
                            </asp:DropDownList>
                        </td>
                        <%--   <td>Status</td>
                        <td><asp:DropDownList ID="DDLWhlStatus" runat="server" CssClass="form-control ll" AutoPostBack="True">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>PASS</asp:ListItem>
                            <asp:ListItem>RHT</asp:ListItem>
                            </asp:DropDownList></td> --%>

                     <td> Batch No:</td>
                    <td> <asp:TextBox ID="TxtBatchNo" runat="server" CssClass="form-control"></asp:TextBox></td>
                 </tr>                     
               </table>
             <asp:Label id="Label2" runat="server" ForeColor="Red"></asp:Label>
    
        </div></div>
             </asp:Panel>

         <div class ="row">
        <div class="table-responsive">
       <table id="table3" class="table">
        <tr>
            <TD>Batch Serial No </TD>
		    <TD> <asp:textbox id="txtSrNo" runat="server" CssClass="form-control" ToolTip="Enter Ped Number(only numeric)" onkeypress="OnlyNumericEntry()"></asp:textbox>
                 <asp:Button ID="addsrno" runat="server" Text="Reset SrNo" CssClass="button button1"/> 	</TD>
            <td>Remarks:</td>
            <td colspan="5"> <asp:TextBox ID="TxtRemarks" runat="server" CssClass="form-control"></asp:TextBox></td>
            </tr>
            <tr>
            <td  colspan="12" align="center"> <asp:Button ID="BtnSave" runat="server" Text="SAVE" CssClass="button button" />
                    <asp:Button ID="BtnClear" runat="server" Text="CLEAR"  CssClass="button button" />
                    <asp:Button ID="BtnExit" runat="server" Text="EXIT" CssClass="button button" />
              <asp:Label ID="Label1" runat="server" ></asp:Label>
           </td>
           </tr>
               
        </table>

            <asp:DataGrid id="DataGrid1" runat="server" CssClass="table" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966" AutoGenerateColumns="False">
									<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
									<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
									<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
									<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
									<Columns>	
					<asp:BoundColumn DataField="BNo" HeaderText="BTNo" ReadOnly="True"></asp:BoundColumn>									
					<asp:BoundColumn DataField="SNo" HeaderText="Sl_No" ReadOnly="True"></asp:BoundColumn>                                        
                                        <asp:BoundColumn DataField="HT" HeaderText="HTNo" ReadOnly="True"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="Wh" HeaderText="WhNo" ReadOnly="True"></asp:BoundColumn>
                                        </Columns>
			<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
		        </asp:DataGrid>
            </div></div>             
              
    </form></div>
     <div class="card-footer" style="text-align:right;"> <h4> MAINTAINED BY CRIS </h4> </div>
</body>
</html>
