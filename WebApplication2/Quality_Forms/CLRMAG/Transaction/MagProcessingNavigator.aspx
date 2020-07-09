<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MagProcessingNavigator.aspx.vb" Inherits="WebApplication2.MagProcessingNavigator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MAGNA PROCESS NEVIGATOR</title>
    <meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR"/>
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>

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
 </head>
<body>
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
          <i class="fab glyphicon glyphicon-home " style="font-size:30px;"></i>
        </a></li>

       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../../logon.aspx">
          <i class="fab glyphicon glyphicon-log-out" style="font-size:30px;"></i>
        </a></li>

        <li class="nav-item ">
        <a class="nav-link p-0" href="#">
         
        <img src="../../../NewFolder1/CRIS-Recruitment.jpg" height="45" style="border-radius:43%"/>
       </a>
      </li>
     </ul>
      
  </div>
</nav>
    <br />
<!--/.Navbar -->
    <div class="container">

    <form id="form1" runat="server">

       <%-- <div class="row"> <div class="table"> --%>
        <asp:Panel ID="panel1" runat="server">
            <table class="table">
                <div class="row">
                    <div class="col" align="center"><FONT size="5">MAGNAGLOW ROOM PROCESSING</FONT></div>
                    
                </div>
                <br />
                <div class="row">
                    <div class="col"><asp:Label ID="lblmsg1" runat="server"  BorderStyle="Dotted"></asp:Label></div>
                </div>
               <br />
                <div class="row">
                    <div class="col"> Drag User Id</div>
                    <div class="col"><asp:TextBox ID="txtuid" runat="server" Width="150px" CssClass="form-control"></asp:TextBox></div>
                    <div class="col">Password</div>
                    <div class="col"><asp:TextBox ID="txtpass" runat="server"  Width="150px" TextMode="Password" CssClass="form-control"></asp:TextBox></div>

                </div>
                <br />
                 <div class="row">
                    <div class="col"> Cope User Id</div>
                    <div class="col"><asp:TextBox ID="txtuidd" runat="server"  Width="150px" CssClass="form-control"></asp:TextBox></div>
                    <div class="col">Password</div>
                    <div class="col"><asp:TextBox ID="txtpasss" runat="server"   Width="150px" TextMode="Password" CssClass="form-control"></asp:TextBox></div>

                </div>
                <br />
                 <br />
                <div class="row">
                    <div class="col" vAlign="top" align="middle"><asp:Button ID="btnsub" runat="server" Text="Submit"  Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark"/></div>
                </div>
            </table>
        </asp:Panel>

   <asp:panel ID="panel2" runat="server">
           <%-- <table class="table">--%>
       <div class="table">
                <div class="row">
                    <div class="col" align="center"><FONT size="5">MAGNAGLOW ROOM PROCESSING</FONT></div>

                </div>
                 <br />
                <div class="row">
                    <div class="col"><asp:Label ID="lblmsg" runat="server" style="font-size:20px" forecolor="red" Font-Bold="true"></asp:Label></div>
                    <div class="col"><asp:Label ID="LblWhlMesg" runat="server" style="font-size:20px" forecolor="Blue" Font-Bold="true" ></asp:Label></div>
                </div>
                 <br />
                 <div class="row">
                    <div class="col">Date</div>
                    <div class="col"><asp:TextBox ID="txtdate" runat="server" CssClass="form-control" Width="120px"></asp:TextBox></div>
                    <div class="col">Shift</div>
                    <div class="col"><asp:RadioButtonList ID="rblshift" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="rbl">
                        <asp:ListItem Value="A">A</asp:ListItem>
                        <asp:ListItem Value="B">B</asp:ListItem>
                        <asp:ListItem Value="C">C</asp:ListItem>
                        <asp:ListItem Value="G">G</asp:ListItem>
                        </asp:RadioButtonList></div>

                <div class="col"> Product Type </div>
                <div class="col"><asp:RadioButtonList ID="RBLProductType" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="rbl">
                        <asp:ListItem Value="BGC" Selected="True">BGC</asp:ListItem>
                        <asp:ListItem Value="BOXN">BOXN</asp:ListItem>
                        <asp:ListItem Value="BLC">BLC</asp:ListItem> 
                        </asp:RadioButtonList> </div>              
                </div>
                <br />
                 <div class="row">
                      <div class="col">Line No</div>
                      <div class="col"><asp:DropDownList ID="ddline" runat="server" CssClass="form-control ll" Width="120px">
                        <asp:ListItem Value="1" Selected="True">ONE</asp:ListItem>
                        <asp:ListItem Value="2">TWO</asp:ListItem>
                        <asp:ListItem Value="3">THREE</asp:ListItem>
                        <asp:ListItem Value="4">FOUR</asp:ListItem>
                        </asp:DropDownList></div>
                    <div class="col">Inspector(Drag)</div>
                    <div class="col"><asp:TextBox ID="txtdrag" runat="server" CssClass="form-control" Width="120px" ReadOnly="True"></asp:TextBox></div>
                    <div class="col">Inspector(Cope)</div>
                    <div class="col"><asp:TextBox ID="txtcope" runat="server" CssClass="form-control" Width="120px" ReadOnly="True"></asp:TextBox></div>
                </div>
                <br />
                <div class="row">
                    <div class="col">UT Batch No</div>
                    <div class="col"><asp:TextBox ID="txtutbatch" runat="server" Width="120px" CssClass="form-control" TabIndex="1"></asp:TextBox></div>
                    <div class="col">BCF</div>
                    <div class="col"><asp:TextBox ID="txtbcf" runat="server" Width="120px" CssClass="form-control" MaxLength="6" TabIndex="2">0.2603</asp:TextBox></div>
                    <div class="col">HT Batch No</div>
                    <div class="col"><asp:TextBox ID="txthtbatch" runat="server" Width="120px" CssClass="form-control" ReadOnly="True"></asp:TextBox></div>
                    </div>
                    <br />
                <div class="row">
                    <div class="col">Heat Number</div>
                    <div class="col"><asp:TextBox ID="txtheat" runat="server" CssClass="form-control" Width="120px" MaxLength="4" TabIndex="3"></asp:TextBox></div>
                    <div class="col">Mould Number</div>
                    <div class="col"><asp:TextBox ID="txtwheel" runat="server" AutoPostBack="true" Width="120px" CssClass="form-control" MaxLength="3" TabIndex="4"></asp:TextBox></div>
                    <div class="col">HT status</div>
                    <div class="col"><asp:DropDownList ID="ddhtstatus" runat="server" CssClass="form-control ll" Width="120px">
                        <asp:ListItem Value="ok" Selected="True">Ok</asp:ListItem>
                        <asp:ListItem Value="not ok">Not Ok</asp:ListItem>
                        </asp:DropDownList></div>
                    </div>
                <br />
             </div>
        
            <Div class="table">
                <div class="row"> 
                <asp:DataGrid ID="PreMagnaGrid" runat="server" CssClass="table" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                <ItemStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                </asp:DataGrid> 
                </div>                
                </Div>
                  
            <div class="table">
               <div class="row">
                    <div class="col">BHN </div>
                    <div class="col"><asp:TextBox ID="txtbhnone" runat="server" CssClass="form-control" MaxLength="3" Width="100px" TabIndex="5"></asp:TextBox> </div>
                     <div class="col">PREV-1 BHN </div>
                    <div class="col"><asp:TextBox ID="txtbhntwo" runat="server" CssClass="form-control" Width="100px" ReadOnly="True"></asp:TextBox> </div>
                   <div class="col">PREV-2 BHN </div>
                    <div class="col"><asp:TextBox ID="txtbhnthree" runat="server" CssClass="form-control" Width="100px" ReadOnly="True"></asp:TextBox> </div>
               <div class="col">Wheel Type</div>
                    <div class="col"><asp:DropDownList ID="ddwhltype" runat="server" CssClass="form-control ll"  AutoPostBack="true" Width="80px" TabIndex="6">
                        <asp:ListItem Value="F">F</asp:ListItem>
                        <asp:ListItem Value="M">M</asp:ListItem>
                        </asp:DropDownList> </div>      
               </div> 
                 <br /> 
                 <div class="row">
                    <asp:Panel runat="server" ID="Panel8" >
                     <div class="col">Operation Done </div>
                     </asp:Panel>
                     <asp:Panel runat="server" ID="Panel11" >
                     <div class="col"><asp:TextBox ID="TxtWFPSdone" runat="server" CssClass="form-control" Width="120px" TabIndex="7"></asp:TextBox> </div>
                    </asp:Panel> 
                    <div class="col">Mag Boom A.Current </div>
                    <div class="col"><asp:TextBox ID="txtamm" runat="server" CssClass="form-control" Width="100px" MaxLength="3" TabIndex="8">107</asp:TextBox></div>
                    <div class="col">Defect Code <asp:Label ID="lblHelp" runat="server">Help(?)</asp:Label>   
                     <asp:CheckBox ID="Help_Code" runat="server" AutoPostBack="true" OnCheckedChanged="Help_Code_CheckedChanged"/> </div>
                     <div class="col"><asp:TextBox ID="TxtDefectCode" runat="server" CssClass="form-control" Width="120px" TabIndex="9"></asp:TextBox></div>
                     <div class="col"><asp:Label ID="lbltype" runat="server" Text="Operation Required"></asp:Label></div>
                    <div class="col"><asp:DropDownList ID="ddOperReqd" runat="server" AutoPostBack="true"  Width="130px" CssClass="form-control ll" TabIndex="10">
                        <asp:ListItem Value="MACHINING">MACHINING</asp:ListItem>
                        <asp:ListItem Value="GRINDING">GRINDING</asp:ListItem>
                        <asp:ListItem Value="MCNGRD">MCN&GRD</asp:ListItem>
                        <asp:ListItem Value="DEFECTXC">DEFECT-XC</asp:ListItem>
                        <asp:ListItem Value="NODEFECT" Selected="True">NODEFECT</asp:ListItem>
                       </asp:DropDownList></div> 
                 </div> 
                 <br />                             
              <div class="row">
                    <div class="col">MPI Remarks</div>
                     <asp:Panel runat="server" ID="Panel3" >
                    <div class="col"> <asp:TextBox ID="TxtMPIRemarks" runat="server" AutoPostBack="true" CssClass="form-control" Width="120px"></asp:TextBox>  </div>
                    </asp:Panel> 
                    <asp:Panel runat="server" ID="Panel4">
                   <div class="col"><asp:DropDownList ID="DDDefTNull" runat="server" CssClass="form-control ll" Width="100px">
                        <asp:ListItem Value="OK" Selected="True">OK</asp:ListItem>
                        <asp:ListItem Value="RLC">RLC</asp:ListItem>
                        <asp:ListItem Value="RLB">RLB</asp:ListItem>
                        <asp:ListItem Value="RLM">RLM</asp:ListItem>
                    </asp:DropDownList> </div> </asp:Panel>  
                    <asp:Panel runat="server" ID="Panel5" >
                     <div class="col"> <asp:TextBox ID="TxtMachining" runat="server"  AutoPostBack="true" placeholder="MACHINING" CssClass="form-control" Width="120px"></asp:TextBox> </div>
                    </asp:Panel> 
                    <asp:Panel runat="server" ID="Panel6" >
                    <div class="col"> <asp:TextBox ID="TxtGrinding" runat="server" AutoPostBack="true" placeholder="GRINDING" CssClass="form-control" Width="120px"></asp:TextBox> </div>
                    </asp:Panel>
                   <asp:Panel runat="server" ID="Panel7" >
                    <div class="col"> <asp:TextBox ID="TxtXCcodes" runat="server" AutoPostBack="true" placeholder="XCCODES" CssClass="form-control" Width="120px" TabIndex="11"></asp:TextBox>  </div>
                    </asp:Panel> 
                    <div class="col">UT Wheel No</div>
                    <div class="col"><asp:TextBox ID="txtutwheel" runat="server" CssClass="form-control" MaxLength="4" Width="120px" TabIndex="12"></asp:TextBox></div>
                  <div class="col">UT Status</div>
                    <div class="col"><asp:DropDownList ID="ddutstatus" runat="server" AutoPostBack="true" Width="120px" TabIndex="13" CssClass="form-control ll">
                        <asp:ListItem Value="Passed" Selected="True">Passed</asp:ListItem>
                        <asp:ListItem Value="Reject" >Reject</asp:ListItem>
                        <asp:ListItem Value="UnChecked">Unchecked</asp:ListItem>
                        <asp:ListItem Value="FReject">FinalReject</asp:ListItem>
                        </asp:DropDownList></div>
                     <asp:Panel runat="server" ID="Panel9">
                    <div class="col">UTDefect Code</div>
                    </asp:Panel>
                    <asp:Panel runat="server" ID="Panel12" >
                    <div class="col"><asp:TextBox ID="TxtUTDefectCode" runat="server" Width="120px" CssClass="form-control" TabIndex="14"></asp:TextBox></div>
                     </asp:Panel>
                     </div> 
                 <br />                             
                            <br />--%> 
                 <div class="row">
                     <div class="col">Final Status</div>
                <div class="col"><asp:TextBox ID="txtFinalstatus" runat="server" CssClass="form-control" Width="120px" ReadOnly="True"></asp:TextBox></div>
                     <%--<div class="col"> <asp:Label ID="lblHelp" runat="server">Code Help(?)</asp:Label>   
                     <asp:CheckBox ID="Help_Code" runat="server" AutoPostBack="true" OnCheckedChanged="Help_Code_CheckedChanged"/> </div>--%>
                     <div class="col"><asp:Button ID="btnstock" runat="server" Text="SAVE RECORDS"  CssClass="button button2"/> </div>
                    <div class="col"><asp:Button ID="btnclear" runat="server" Text="CLEAR DATA" CssClass="button button2" /></div>
                    <div class="col"><asp:Button ID="btnMagStatus" runat="server" Text="BREAKUP DETAILS"  CssClass="button button2"/> </div>
                   <div class="col"><asp:Button ID="BtnUpdate" runat="server" Text="UPDATE MAGNA RECORDS"  CssClass="button button2"/> </div>
                </div>
                <br /> 
            </div>
             
        </asp:panel>
            <asp:Panel runat="server" ID="Panel10">
        <div class="table">  <div class="row">  
          <asp:datagrid id="MAGNAGRID" CssClass="table-responsive" runat="server" CellPadding="1" CellSpacing="1" AutoGenerateColumns="False" forecolor="Black">
          <AlternatingItemStyle BackColor="White"></AlternatingItemStyle>
          <HeaderStyle ForeColor="White" BackColor="Navy"></HeaderStyle>
          <Columns>                                					
    <asp:ButtonColumn Text="Select" HeaderText="Select" CommandName="Select"></asp:ButtonColumn>
	<asp:BoundColumn DataField="TestDate" HeaderText="MagnaTDate"></asp:BoundColumn>
	<asp:BoundColumn DataField="Shift" HeaderText="Shift"></asp:BoundColumn>
	<asp:BoundColumn DataField="ProdType" HeaderText="ProdType"></asp:BoundColumn>
	<asp:BoundColumn DataField="CopeInsp" HeaderText="COPEID"></asp:BoundColumn>
    <asp:BoundColumn DataField="DragInsp" HeaderText="DRAGID"></asp:BoundColumn>
    <asp:BoundColumn DataField="LineNumber" HeaderText="LINENO"></asp:BoundColumn>
 	<asp:BoundColumn DataField="HeatNo" HeaderText="HEATNO"></asp:BoundColumn>
	<asp:BoundColumn DataField="WheelNo" HeaderText="WHEELNO"></asp:BoundColumn>
	<asp:BoundColumn DataField="WheelType" HeaderText="WType"></asp:BoundColumn>
	<asp:BoundColumn DataField="DefectCodes" HeaderText="DefectCodes"></asp:BoundColumn>	
	<asp:BoundColumn DataField="MPI_Remarks" HeaderText="MPI_Remarks"></asp:BoundColumn>
	<asp:BoundColumn DataField="Machining" HeaderText="Machining"></asp:BoundColumn>  
	<asp:BoundColumn DataField="Grinding" HeaderText="Grinding"></asp:BoundColumn> 
	<asp:BoundColumn DataField="BHN" HeaderText="BHN"></asp:BoundColumn>
	<asp:BoundColumn DataField="MbsCurrent" HeaderText="MbsCurrent"></asp:BoundColumn>
	<asp:BoundColumn DataField="BCF" HeaderText="BCF"></asp:BoundColumn>
	<asp:BoundColumn DataField="UtBatch" HeaderText="UTBATCH"></asp:BoundColumn>
	<asp:BoundColumn DataField="UtWheelNo" HeaderText="UTWHLNO"></asp:BoundColumn>
	<asp:BoundColumn DataField="UtStatus" HeaderText="UTSTATUS"></asp:BoundColumn>
	<asp:BoundColumn DataField="UtDefectCode" HeaderText="UtDefectCode"></asp:BoundColumn>
	<asp:BoundColumn DataField="FinalStatus" HeaderText="FinalStatus"></asp:BoundColumn>
       		</Columns>
        </asp:datagrid></div>  
          </div>
                 </asp:panel>
       <%-- </div></div>--%>
    </form> 

        </div>
</body>
</html>
