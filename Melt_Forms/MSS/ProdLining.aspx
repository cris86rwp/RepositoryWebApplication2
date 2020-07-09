<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ProdLining.aspx.vb" Inherits="WebApplication2.ProdLining" %>

<!DOCTYPE HTML PUBLIC >
<html>
<head runat="server">
    <title>ProdLining</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0" />
    <meta name="CODE_LANGUAGE" content="Visual Basic 7.0" />
    <meta name="vs_defaultClientScript" content="JavaScript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>

    <link type="text/css" rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" />


    <%-- <link rel="stylesheet" href="../StyleSheet1.css" />--%>
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
          <li class="nav-item"> <a class="nav-link" href="#" style="color:white; font-size:25px;">Rail Wheel Plant Bela</a></li>
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
          <img src="../../NewFolder1/CRIS-Recruitment.jpg" class="rounded-circle z-depth-0"  height="45"/>
        </a>
      </li>
     </ul>
      
  </div>
</nav>
    <!--/.Navbar -->


    <div class="container">

        <form id="Form1" method="post" runat="server">

            <div class="row">

  <%--              <h4>Select Your Theme : &nbsp;&nbsp;&nbsp; </h4>

                <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                    <asp:ListItem>select</asp:ListItem>
                    <asp:ListItem>Theme1</asp:ListItem>
                    <asp:ListItem>Theme2</asp:ListItem>
                    <asp:ListItem>Theme3</asp:ListItem>
                </asp:DropDownList>
                <br />--%>
            </div>
            <asp:Panel ID="Panel1" runat="server">
                <%--style="Z-INDEX: 101; LEFT: 2px; POSITION: absolute; TOP: 2px" --%>


                <div class="row">
                    <div class="table-responsive">
                        <table id="Table1" class="table">
                            <%--  cellSpacing="1" cellPadding="1" width="300"--%>
                            <tr>
                                <td colspan="3" align="center">
                                    <asp:Label ID="lblConsignee" runat="server"></asp:Label><strong>&nbsp;Lining 
								Details</strong><hr class="prettyline" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label></td>
                            </tr>
                        </table>
                        <table id="Table2" class="table">
                            <%-- style="WIDTH: 950px; HEIGHT: 28px" cellSpacing="1" cellPadding="1" width="950"--%>
                            <tr>
                                <td>
                                    <asp:RadioButtonList ID="rblLiningType" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="rbl"></asp:RadioButtonList></td>
                            </tr>
                        </table>
                        <table id="Table3" class="table">
                            <%--cellSpacing="1" cellPadding="1" width="300"--%>
                            <tr>
                                <td>
                                    <asp:RadioButtonList ID="rblLinedBy" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="rbl"></asp:RadioButtonList></td>
                            </tr>
                        </table>
                        <table id="Table4" class="table">
                            <%-- cellSpacing="1" cellPadding="1" width="300"--%>
                            <tr>
                                <td>
                                    <asp:Label ID="lblItemName" runat="server"></asp:Label></td>
                                <td>:</td>
                                <td>
                                    <asp:RadioButtonList ID="rblLiningItemNo" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="rbl"></asp:RadioButtonList></td>
                            </tr>
                        </table>
                        <div class="row">
                            <div class="table-responsive">
                                <asp:DataGrid ID="DataGrid3" runat="server" CssClass="table" ForeColor="Black" BorderColor="#DEDFDE" BorderWidth="1px" BackColor="White" CellPadding="4" GridLines="Vertical" BorderStyle="None">
                                    <SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#CE5D5A"></SelectedItemStyle>
                                    <AlternatingItemStyle BackColor="White"></AlternatingItemStyle>
                                    <ItemStyle BackColor="#F7F7DE"></ItemStyle>
                                    <HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#6B696B"></HeaderStyle>
                                    <FooterStyle BackColor="#CCCC99"></FooterStyle>
                                    <PagerStyle HorizontalAlign="Right" ForeColor="Black" BackColor="#F7F7DE" Mode="NumericPages"></PagerStyle>
                                </asp:DataGrid>
                            </div>
                        </div>
                        <table id="Table5" class="table">
                            <%--cellSpacing="1" cellPadding="1" width="300"--%>
                            <tr>
                                <td valign="top" align="left">
                                    <table id="Table8" class="table"></table>
                                    <%--cellSpacing="1" cellPadding="1" width="300"--%>
                                    <tr>
                                        <td align="right">LiningNo</td>
                                        <td>:</td>
                                        <td>
                                            <asp:TextBox ID="txtLiningNo" runat="server" AutoPostBack="True" CssClass="form-control"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td align="right">PreviousLiningNo</td>
                                        <td>:</td>
                                        <td>
                                            <asp:TextBox ID="txtPreLiningNo" runat="server" AutoPostBack="True" CssClass="form-control"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td align="right">LastHeatNoOfPreviousLining</td>
                                        <td>:</td>
                                        <td>
                                            <asp:TextBox ID="txtLastHeatNo" runat="server" AutoPostBack="True" CssClass="form-control"></asp:TextBox></td>
                                    </tr>
                                </td>
                            </tr>

                            <asp:DataGrid ID="DataGrid1" CssClass="table" runat="server" BorderColor="#3366CC" BorderWidth="1px" BackColor="White" CellPadding="4" BorderStyle="None">
                                <SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
                                <ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
                                <HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
                                <FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
                                <PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
                            </asp:DataGrid>
                            <table id="Table9" class="table">
                                <%--   cellSpacing="1" cellPadding="1" width="300"--%>
                                <tr>
                                    <td colspan="2"></td>
                                    <td colspan="2">Date&nbsp;&nbsp;Time(hh:mm)&nbsp;&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>HandedOverOn</td>
                                    <td>:</td>
                                    <td>
                                        <asp:TextBox ID="txtHandedOverOnDate" runat="server" CssClass="form-control"></asp:TextBox></td>
                                    <td>
                                        <asp:TextBox ID="txtHandedOverOnTime" runat="server" CssClass="form-control"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>WorkStartedOn</td>
                                    <td>:</td>
                                    <td>
                                        <asp:TextBox ID="txtWorkStartedOnDate" runat="server" CssClass="form-control"></asp:TextBox></td>
                                    <td>
                                        <asp:TextBox ID="txtWorkStartedOnTime" runat="server" CssClass="form-control"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>WorkCompletedOn</td>
                                    <td>:</td>
                                    <td>
                                        <asp:TextBox ID="txtWorkCompletedOnDate" runat="server" CssClass="form-control"></asp:TextBox></td>
                                    <td>
                                        <asp:TextBox ID="txtWorkCompletedOnTime" runat="server" CssClass="form-control"></asp:TextBox></td>
                                </tr>
                            </table>
                            </td>
						<td valign="top" align="left">
                            <asp:Panel ID="pnlFWP" runat="server">
                                <table id="Table6" class="table">
                                    <%--cellSpacing="1" cellPadding="1" width="300"--%>
                                    <tr>
                                        <td>WithReferenceTo<font color="#ff6633">FurneceFullLiningNo</font></td>
                                        <td></td>
                                        <td>
                                            <asp:TextBox ID="txtFFLNo" runat="server" CssClass="form-control"></asp:TextBox></td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="pnlLadle" runat="server">
                                <table id="Table7" class="table">
                                    <%-- style="WIDTH: 393px; HEIGHT: 106px" cellSpacing="1" cellPadding="1" width="393"--%>
                                    <tr>
                                        <td colspan="3">LADLE DIAMETER AFTER RELINING in mm</td>
                                    </tr>
                                    <tr>
                                        <td>I) BOTTOM-TRUNION TO TRUNION</td>
                                        <td>:</td>
                                        <td>
                                            <asp:TextBox ID="txtBTT" runat="server" CssClass="form-control"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>II) BOTTOM-MOUTH TO OPPO MOUTH</td>
                                        <td>:</td>
                                        <td>
                                            <asp:TextBox ID="txtBMOM" runat="server" CssClass="form-control"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>III) TOP-TRUNION TO TRUNION</td>
                                        <td>:</td>
                                        <td>
                                            <asp:TextBox ID="txtTTT" runat="server" CssClass="form-control"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>IV) TOP-MOUTH TO OPPO MOUTH</td>
                                        <td>:</td>
                                        <td>
                                            <asp:TextBox ID="txtTMOM" runat="server" CssClass="form-control"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>V) LADLE DEPTH AFTER RELINING</td>
                                        <td>:</td>
                                        <td>
                                            <asp:TextBox ID="txtDepth" runat="server" CssClass="form-control"></asp:TextBox></td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                            </tr>
                    
                        </table>
                        <table id="Table10" class="table"></table>
                        <%-- cellSpacing="1" cellPadding="1" width="300"--%>
                        <tr>
                            <td valign="top" align="left">
                                <table id="Table11" class="table">
                                    <%-- cellSpacing="1" cellPadding="1" width="300"--%>
                                    <tr>
                                        <td>LOANo</td>
                                        <td>:</td>
                                        <td>
                                            <asp:TextBox ID="txtLOANo" runat="server" AutoPostBack="True" CssClass="form-control"></asp:TextBox></td>
                                        <td>LOADate</td>
                                        <td>:</td>
                                        <td>
                                            <asp:TextBox ID="txtLOADate" runat="server" CssClass="form-control"></asp:TextBox></td>
                                    </tr>
                                </table>
                                <table id="Table12" class="table">
                                    <tr>
                                        <td>SchQty</td>
                                        <td>
                                            <asp:TextBox ID="txtScheduledQty" runat="server" CssClass="form-control"></asp:TextBox></td>
                                        <td>UsedQty</td>
                                        <td style="width: 7px">
                                            <asp:TextBox ID="txtCompletedQty" runat="server" CssClass="form-control"></asp:TextBox></td>
                                        <td>Available</td>
                                        <td>
                                            <asp:Label ID="Label1" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>Remarks</td>
                                        <td colspan="5">
                                            <asp:TextBox ID="txtLOARemarks" runat="server" CssClass="form-control"></asp:TextBox></td>
                                    </tr>
                                </table>
                            </td>
                            <td valign="top" align="left">
                                <table id="Table13" class="table">
                                    <%--   cellSpacing="1" cellPadding="1" width="300"--%>
                                    <tr>
                                        <td>GroupLeader1</td>
                                        <td>
                                            <asp:TextBox ID="txtGroupLeader1" runat="server" CssClass="form-control"></asp:TextBox></td>
                                        <td>GroupLeader2</td>
                                        <td>
                                            <asp:TextBox ID="txtGroupLeader2" runat="server" CssClass="form-control"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>InspectionNote</td>
                                        <td colspan="3">
                                            <asp:TextBox ID="txtInspectionNote" runat="server" CssClass="form-control"></asp:TextBox></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>

                        <table id="Table14" class="table">
                            <tr>
                                <td align="center">
                                    <asp:Button ID="btnSave" runat="server" CssClass="button button2" Text="Save"></asp:Button></td>
                            </tr>
                        </table>
                        <div class="row">
                            <div class="table-responsive">
                                <asp:DataGrid ID="DataGrid2" CssClass="table" runat="server" BorderColor="#CC9966" BorderWidth="1px" BackColor="White" CellPadding="4" BorderStyle="None">
                                    <SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
                                    <ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
                                    <HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
                                    <FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
                                    <PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
                                </asp:DataGrid>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </form>
    </div>
    <div class="card-footer" style="text-align: right;">
        <h4>MAINTAINED BY CRIS</h4>
    </div>
</body>
</html>
