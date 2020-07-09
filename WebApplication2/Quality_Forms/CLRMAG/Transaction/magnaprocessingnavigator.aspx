<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="magnaprocessingnavigator.aspx.vb" Inherits="WebApplication2.magnaprocessingnavigator" %>

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
  <!--   <link rel="stylesheet" href="../../../StyleSheet1.css" />-->
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

        <div class="row"><div class="table">
        <asp:Panel ID="panel1" runat="server">
            <table class="table">
                <div class="row">
                    <div class="col" align="center"><FONT size="5">MAGNAGLOW ROOM PROCESSING</FONT></div>
                    
                </div>
                <br />
                <div class="row">
                    <div class="col"><asp:Label ID="lblmsg1" runat="server"></asp:Label></div>
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
            <table class="table">
                <div class="row">
                    <div class="col" align="center"><FONT size="5">MAGNAGLOW ROOM PROCESSING</FONT></div>

                </div>
                 <br />
                <div class="row">
                    <div class="col"><asp:Label ID="lblmsg" runat="server"></asp:Label></div>
                </div>
                 <br />
                <div class="row">
                    <div class="col">Date</div>
                    <div class="col"><asp:TextBox ID="txtdate" runat="server" CssClass="form-control"></asp:TextBox></div>
                    <div class="col">shift</div>
                    <div class="col"><asp:RadioButtonList ID="rblshift" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="rbl">
                        <asp:ListItem Value="A" Selected="True" >A</asp:ListItem>
                        <asp:ListItem Value="B">B</asp:ListItem>
                        <asp:ListItem Value="C">C</asp:ListItem>
                        <asp:ListItem Value="G">G</asp:ListItem>
                        </asp:RadioButtonList></div>
                </div>
                 <br />
                <div class="row">
                    <div class="col">Drag(I)</div>
                    <div class="col"><asp:TextBox ID="txtdrag" runat="server" CssClass="form-control"></asp:TextBox></div>
                    <div class="col">Cope(I)</div>
                    <div class="col"><asp:TextBox ID="txtcope" runat="server" CssClass="form-control"></asp:TextBox></div>
                </div>
                 <br />
                <div class="row">
                    <div class="col">Line No</div>
                    <div class="col"><asp:DropDownList ID="ddline" runat="server" CssClass="form-control ll">
                       
                        <asp:ListItem Value="1" Selected="True">1</asp:ListItem>
                        <asp:ListItem Value="2">2</asp:ListItem>
                        <asp:ListItem Value="3">3</asp:ListItem>
                        <asp:ListItem Value="4">4</asp:ListItem>
                        </asp:DropDownList></div>
                    <div class="col">Wheel Type</div>
                    <div class="col"><asp:DropDownList ID="ddwhltype" runat="server" CssClass="form-control ll">
                    
                        <asp:ListItem Value="F" Selected="True">F</asp:ListItem>
                        <asp:ListItem Value="M">M</asp:ListItem>
                        </asp:DropDownList></div>
                </div>
                 <br />
                <div class="row">
                    <div class="col">Heat Number</div>
                    <div class="col"><asp:TextBox ID="txtheat" runat="server" CssClass="form-control"></asp:TextBox></div>
                    <div class="col">Wheel Number</div>
                    <div class="col"><asp:TextBox ID="txtwheel" runat="server" AutoPostBack="true" CssClass="form-control"></asp:TextBox></div>
                </div>
                 <br />
                <div class="row">
                    <div class="col">Defects</div>
                    <div class="col"><asp:RadioButtonList ID="rbldefects" runat="server" AutoPostBack="true" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="rbl" >
                        <asp:ListItem Value="yes" Selected="True">YES</asp:ListItem>
                        <asp:ListItem Value="no" >NO</asp:ListItem>                   
                        </asp:RadioButtonList></div>
                    </div>
                 <br />
               
                <div class="row">
                    <div class="col"><asp:Label ID="lbltype" runat="server" Text="Type of defects"></asp:Label></div>
                    <div class="col"><asp:DropDownList ID="ddtyped" runat="server" AutoPostBack="true" CssClass="form-control ll">
                        <asp:ListItem Value="no defects" Selected="True">No Defects</asp:ListItem>
                        <asp:ListItem Value="defects for grinding" >Defects for Grinding</asp:ListItem>
                        <asp:ListItem Value="defects for machining">Defects for Machining</asp:ListItem>
                        <asp:ListItem Value="defects for machining and grinding">Defects for Machining and Grinding</asp:ListItem>
                         <asp:ListItem Value="Defects for XC">Defects for XC</asp:ListItem>
                        </asp:DropDownList></div>
                                   
                    <div class="col"><asp:CheckBox ID="chkgrdsts" runat="server" Text="Grind sts" /></div>
                    <div class="col"><asp:CheckBox ID="Chkmcnopn" runat="server" Text="Mcn Opn" /></div>
                     </div>
                 <br />
                 <div class="row">
                      <asp:Panel runat="server" ID="Panel4" >
                    <div class="col"> Machining Required</div>
                    <div class="col"><asp:TextBox ID="TxtmMchining" runat="server" CssClass="form-control"></asp:TextBox></div>
                     </asp:Panel>
                      <asp:Panel runat="server" ID="Panel5" >
                    <div class="col">Grinding Required</div>
                    <div class="col"><asp:TextBox ID="TxtGrinding" runat="server" AutoPostBack="true" CssClass="form-control"></asp:TextBox></div>
                    </asp:Panel>
                      <asp:Panel runat="server" ID="Panel6" >
                    <div class="col">XC Codes</div>
                    <div class="col"><asp:TextBox ID="TxtXCcodes" runat="server" AutoPostBack="true" CssClass="form-control"></asp:TextBox></div>
                    </asp:Panel>
                </div>
                 <br />
                <div class="row">
                    <div class="col">BHN</div>
                    <div class="col"><asp:TextBox ID="txtbhnone" runat="server" CssClass="form-control"></asp:TextBox></div>
                    <div class="col"><asp:TextBox ID="txtbhntwo" runat="server" CssClass="form-control"></asp:TextBox></div>
                    <div class="col"><asp:TextBox ID="txtbhnthree" runat="server" CssClass="form-control"></asp:TextBox></div>
                    </div>
                 <br />
                <div class="row">
                     
                    
                    <div class="col">Magnatic Boom Ammeter Current</div>
                    <div class="col"><asp:TextBox ID="txtamm" runat="server" CssClass="form-control">107</asp:TextBox></div>
               
                     <div class="col">BCF</div>
                    <div class="col"><asp:TextBox ID="txtbcf" runat="server" CssClass="form-control">0.2603</asp:TextBox></div>
                </div>
                 <br />
                <div class="row">
                   <div class="col">UT Batch No</div>
                    <div class="col"><asp:TextBox ID="txtutbatch" runat="server" CssClass="form-control"></asp:TextBox></div>
                    <div class="col">UT Wheel No</div>
                    <div class="col"><asp:TextBox ID="txtutwheel" runat="server" CssClass="form-control"></asp:TextBox></div>
                    </div>
                 <br />
                <div class="row">
                    <div class="col">UT Status</div>
                    <div class="col"><asp:DropDownList ID="ddutstatus" runat="server" CssClass="form-control ll">
                        <asp:ListItem Value="passed" Selected="True">Passed</asp:ListItem>
                        <asp:ListItem Value="reject" >Reject</asp:ListItem>
                        <asp:ListItem Value="unchecked">Unchecked</asp:ListItem>
                        </asp:DropDownList></div>
                    <div class="col">UT XcWhlSts</div>
                    <div class="col"><asp:TextBox ID="txtutstatus" runat="server" CssClass="form-control"></asp:TextBox></div>
                </div>
                 <br />
                <div class="row">
                    <div class="col">HT Batch No</div>
                    <div class="col"><asp:TextBox ID="txthtbatch" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox></div>
                    <div class="col" aria-readonly="True">HT status</div>
                    <div class="col"><asp:DropDownList ID="ddhtstatus" runat="server" CssClass="form-control ll">
                        <asp:ListItem Value="ok" Selected="True">Ok</asp:ListItem>
                        <asp:ListItem Value="not ok">Not Ok</asp:ListItem>
                        </asp:DropDownList></div>
                </div>
                 <br />
                <div class="row">
                    <div class="col" ><asp:Button ID="btnstock" runat="server" Text="Stock"  CssClass="button button2"/> </div>
                    <div class="col"><asp:Button ID="btnclear" runat="server" Text="Clear" CssClass="button button2" /></div>
                </div>
                 <br />
            </table>
            </asp:panel>
        <table>    <TR>
           
                     <TD colSpan="6">
                    <asp:datagrid id="MAGNAGRID" CssClass="table" runat="server" CellPadding="1" CellSpacing="1" AutoGenerateColumns="False" forecolor="Black">
                    <AlternatingItemStyle BackColor="White"></AlternatingItemStyle>
                    <HeaderStyle ForeColor="White" BackColor="Navy"></HeaderStyle>
                    <Columns>
             <%--<asp:DataGrid ID="MAGNAGRID" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" autogeneratecolumns="false" CssClass="table">
                <AlternatingItemStyle BackColor="White"></AlternatingItemStyle>
                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                <ItemStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" Mode="NumericPages" />
                <SelectedItemStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />--%>
                      					
								<asp:ButtonColumn Text="Select" HeaderText="Select" CommandName="Select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="date" HeaderText="MAGNA_DATE"></asp:BoundColumn>
								<asp:BoundColumn DataField="shift" HeaderText="Shift"></asp:BoundColumn>
								<asp:BoundColumn DataField="copeinsp" HeaderText="COPEID"></asp:BoundColumn>
								<asp:BoundColumn DataField="draginsp" HeaderText="DRAGID"></asp:BoundColumn>
								<asp:BoundColumn DataField="linenumber" HeaderText="LINENO"></asp:BoundColumn>
								<asp:BoundColumn DataField="heatno" HeaderText="HEATNO"></asp:BoundColumn>
								<asp:BoundColumn DataField="wheelno" HeaderText="WHEELNO"></asp:BoundColumn>
								<asp:BoundColumn DataField="bhn" HeaderText="BHN"></asp:BoundColumn>
								<asp:BoundColumn DataField="utbatch" HeaderText="UTBATCH"></asp:BoundColumn>
								<asp:BoundColumn DataField="utwheelno" HeaderText="UTWHLNO"></asp:BoundColumn>
								<asp:BoundColumn DataField="utstatus" HeaderText="UTSTATUS"></asp:BoundColumn>
								<asp:BoundColumn DataField="utxcwhlsts" HeaderText="UTXCWHLSTS"></asp:BoundColumn>
								<asp:BoundColumn DataField="Machining" HeaderText="HC_XC_Code"></asp:BoundColumn>
								<asp:BoundColumn DataField="Grinding" HeaderText="GRINDCODE"></asp:BoundColumn>
								<asp:BoundColumn DataField="XcCodes" HeaderText="XCCODE"></asp:BoundColumn>                              
						 </Columns>
                    </asp:datagrid></TD>
                             </TR> </table>

            </div></div>
    </form> 

        </div>
    <div class="card-footer" style="text-align:right;background-color:#cccccc;vertical-align:middle;position:fixed;bottom:0;width:100%;height:60px"><h4 style="color: black;font-size:15px">MAINTAINED BY CRIS</h4></div>
	
</body>
</html>
