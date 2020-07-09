<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PreHeatedLadleDetails.aspx.vb" Inherits="WebApplication2.PreHeatedLadleDetails" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PreHeatedLadleDetails</title>
    <link id="mss" href="/wap.css" rel="stylesheet" />
    <meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR" />
    <meta content="Visual Basic 7.0" name="CODE_LANGUAGE" />
    <meta content="JavaScript" name="vs_defaultClientScript" />
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema" />
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css" />
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
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.12.1/jquery-ui.min.js">  </script>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
    <script type="text/javascript" src="//ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script type="text/javascript" src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>


    <link type="text/css" rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" />

    <style type="text/css">
        .ui-datepicker {
            background: #333;
            border: 1px solid #555;
            color: #EEE;
        }
    </style>
</head>
<body>
    <nav class="mb-1 navbar navbar-expand-sm bg-dark navbar-dark ">
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
    <div class="container" align="center">

        <form id="Form1" method="post" runat="server">
            <div class="row">
                <asp:Panel ID="Panel1" runat="server">
                    <div class="row">
                        <div class="table">
                            <div class="table">
                                <div class="row">
                                    <div class="col" align="center">
                                        <h2 font=X-LARGE><b>LADLE</b></h2><br>
                                        <asp:RadioButtonList ID="rblType" runat="server" CssClass="rbl" RepeatLayout="Flow" RepeatDirection="Horizontal" AutoPostBack="True">
                                            <asp:ListItem Value="1" Selected="True">&nbsp;Pre - Heat Details &nbsp</asp:ListItem>
                                            <asp:ListItem Value="2">Temperature Details</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                </div>
                            </div></div>
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                            <div class="table">
                            </div>
                                        </asp:Panel>

                            <asp:Panel ID="pnlDetails" runat="server">
                                <div class="table">
                                </div>
                                <div class="table">
                                    <div class="row">
                                        <div class="col">Lining No</div>
                                        <%--<td>:</td>--%>
                                        <div class="col">
                                            <asp:TextBox ID="txtLiningNo" runat="server" CssClass="form-control" style="margin-left:-8px" Width="100" AutoPostBack="True"></asp:TextBox>
                                        </div>
                                        <div class="col"></div>
                                                                                <div class="col">Ladle No</div>
                                                                                <div class="col">
                                            <asp:Label ID="lblLadleNo" runat="server"></asp:Label>
                                        </div>


                                        <div class="col"></div>
                                 
                                        <%--<td>:</td>--%>
                                        
                                   </div>
                                </div>
                                <div class="table">
                                    <div class="row">
                                        <div class="col-2">Staff No</div>
                                        <%--<td>:</td>--%>
                                        <div class="col-2">
                                            <asp:TextBox ID="txtStaffNo" runat="server" style="margin-left:-8px"  Width="100" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <div class="col">
                                            <asp:RadioButtonList ID="rblSet" CssClass="rbl" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="0" Selected="True">&nbsp;New&nbsp;</asp:ListItem><asp:ListItem Value="1">&nbsp;Re-Heat</asp:ListItem>
                                                
                                            </asp:RadioButtonList>
                                        </div>
                                        <%--<div class="col"></div>
                                        <div class="col"></div>
                                        <div class="col"></div>--%>
                                    </div>
                                </div>

                                <asp:DataGrid ID="DataGrid2" runat="server" CssClass="table" AutoGenerateColumns="False">
                                    <SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
                                    <ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
                                    <HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
                                    <FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
                                    <Columns>
                                        <asp:BoundColumn DataField="HandedOverDt" ReadOnly="True" HeaderText="HandedOverDt"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="HOTime" ReadOnly="True" HeaderText="HOTime"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="WorkSartDt" ReadOnly="True" HeaderText="WorkSartDt"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="WSTime" ReadOnly="True" HeaderText="WSTime"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="WorkCompDt" ReadOnly="True" HeaderText="WorkCompDt"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="WCTime" HeaderText="WCTime"></asp:BoundColumn>
                                    </Columns>
                                    <PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
                                </asp:DataGrid>

                                <div class="table">
                                    <div class="row">
                                        <div class="col">Start Date Time</div>
                                        <div class="col">
                                            <asp:TextBox ID="txtStartDate" runat="server" style="margin-left:-3px" Width="100" CssClass="form-control" AutoPostBack="True"></asp:TextBox>
                                        </div>
                                        <div class="col">
                                            <asp:TextBox ID="txtStartTime" runat="server"  Width="65" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <div class="col">End Date Time</div>
                                        <div class="col">
                                            <asp:TextBox ID="txtEndDate" runat="server"  Width="100" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <div class="col">
                                            <asp:TextBox ID="txtEndTime" runat="server"  Width="65" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="table">
                                    <div class="row">
                                        <div class="col">Lifting Temp</div>
                                        <div class="col">
                                            <asp:TextBox ID="txtLiftingTemp" runat="server"  style="margin-right:-10px" Width="100" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <div class="col">From Heat</div>
                                        <div class="col">
                                            <asp:TextBox ID="txtFromHeat" runat="server"  Width="100"  CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <div class="col">To Heat</div>
                                        <div class="col">
                                            <asp:TextBox ID="txtToHeat"  Width="100" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="table">
                                    <div class="row">
                                        <div class="col">&nbsp;&nbsp;Remarks</div>
                                        <div class="col">
                                            <asp:TextBox ID="txtRemark" runat="server" style="margin-left:-10px" Width="100"  CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <div class="col"></div>
                                        <div class="col"></div>
                                        <div class="col"></div>
                                        <div class="col"></div>

                                    </div>
                                    <br />
                                    <br />
                                    <div class="row">
                                        <div class="col" align="center">
                                            <asp:Button ID="btnSave" align="middle" Font-Size="16px" BorderStyle="Solid" Font-Bold="True" CssClass="btn btn-dark" runat="server" Text="Save"></asp:Button>
                                            <asp:Label ID="PreHeatID" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <asp:DataGrid ID="DataGrid1" runat="server" CssClass="table" AutoGenerateColumns="False">
                                    <SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
                                    <ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
                                    <HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
                                    <FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
                                    <Columns>
                                        <asp:ButtonColumn Text="Select" CommandName="Select"></asp:ButtonColumn>
                                        <asp:BoundColumn DataField="LiningNo" HeaderText="LiningNo"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="LadleNo" HeaderText="LadleNo"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="StartDate" HeaderText="StartDate"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="StTime" HeaderText="StTime"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="EndDate" HeaderText="EndDate"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="EndTime" HeaderText="EndTime"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="TotTime" HeaderText="TotTime"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="LiftingTemp" HeaderText="LiftingTemp"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="FromHeat" HeaderText="FromHeat"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="ToHeat" HeaderText="ToHeat"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="StaffNo" HeaderText="StaffNo"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="Type" HeaderText="Type"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="Remarks" HeaderText="Remarks"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="PreHeatID" HeaderText="PreHeatID"></asp:BoundColumn>
                                        <asp:ButtonColumn Text="Delete" CommandName="Delete"></asp:ButtonColumn>
                                    </Columns>
                                    <PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
                                </asp:DataGrid>
                            </asp:Panel>
                            <asp:Panel ID="pnlTemp" runat="server">
                                <table id="Table11" class="table">
                                </table>

                                <div class="table" align="center">
                                    <div class="row" align="center">
                                        <div class="col">Set Date Time</div>
                                        <div class="col">
                                            <asp:TextBox ID="txtSetDate" runat="server" CssClass="form-control" width="100" AutoPostBack="True"></asp:TextBox>
                                        </div>
                                        <div class="col">
                                            <asp:TextBox ID="txtSetTime" runat="server"  width="65" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <div class="col">LPH</div>


                                        <div class="col">
                                            <asp:RadioButtonList ID="rblLPH" CssClass="rbl" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="1" Selected="True">&nbsp;1&nbsp</asp:ListItem>
                                                <asp:ListItem Value="2">&nbsp;2</asp:ListItem>
                                                <asp:ListItem Value="3">3</asp:ListItem>
                                            </asp:RadioButtonList>&nbsp</div>
                                                                                    <div class="col"></div>
                                                                                                                                <div class="col"></div>
                                                                                    <div class="col"></div>


                                        
                                    </div>
                                </div>
                               <br> <div class="table">
                                    <div class="row">
                                        <div class="col">LPG Qty</div>
                                        <div class="col">
                                            <asp:TextBox ID="txtHSDQty" runat="server" style="margin-left:20px" Width="100" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <div class="col">Set Temp</div>
                                        <div class="col">
                                            <asp:TextBox ID="txtSetTemp" runat="server"  Width="100" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <div class="col">Actual Temp</div>
                                        <div class="col">
                                            <asp:TextBox ID="txtActualTemp" runat="server"  Width="100" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <div class="col">Staff</div>
                                        <div class="col">
                                            <asp:TextBox ID="txtUser" runat="server"  Width="100" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    </div>
                                    <br>
                                    <div class="table">
                                        <div class="row">
                                            <br>
                                            <div class="col">Remarks</div>
                                            <div class="col">
                                                <asp:TextBox ID="txtRemarks" runat="server" Width="100" CssClass="form-control"></asp:TextBox>
                                                <asp:Label ID="lblPreHeatID" runat="server"></asp:Label>
                                            </div>
                                            <div class="col"></div>
                                            <div class="col"></div>
                                            <div class="col"></div>
                                            <div class="col"></div>
                                            <div class="col"></div>
                                            <div class="col"></div>
                                        </div>
                                        <div class="row">
                                            <div class="col" align="center" >
                                                <asp:Button ID="btnTemp" runat="server" Font-Size="16px" BorderStyle="Solid" Font-Bold="True" CssClass="btn btn-dark" Text="Save Temp Details"></asp:Button>
                                            </div>
                                        </div>
                                    </div>

                                    <asp:DataGrid ID="DataGrid3" runat="server" CssClass="table" AllowPaging="True">
                                        <SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
                                        <ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
                                        <HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
                                        <FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
                                        <Columns>
                                            <asp:ButtonColumn Text="Select" CommandName="Select"></asp:ButtonColumn>
                                        </Columns>
                                        <PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
                                    </asp:DataGrid>
                                    <asp:DataGrid ID="DataGrid4" runat="server" CssClass="table">
                                        <SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
                                        <ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
                                        <HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
                                        <FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
                                        <Columns>
                                            <asp:ButtonColumn Text="Delete" CommandName="Delete"></asp:ButtonColumn>
                                        </Columns>
                                        <PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
                                    </asp:DataGrid>
                            </asp:Panel>
                        </div>
                    </div>
                </asp:Panel>
        </form>
   </div>
    <div class="card-footer" style="text-align: right; background-color: #cccccc; vertical-align: middle; position:fixed; bottom: 0; width: 100%; height: 60px">
        <h4 style="color: black; font-size: 15px">MAINTAINED BY CRIS</h4>
    </div>
    <script type="text/javascript">

        $(document).ready(function () {

            $('#txtSetDate').datepicker({
                dateFormat: "dd/mm/yy",

                onSelect: function (date) {
                    var date1 = $('#txtSetDate').datepicker('getDate');


                }
            });

            function getDate(element) {
                var date;
                var dateFormat = "dd/MM/yyyy";
                try {
                    date = $.datepicker.parseDate(dateFormat, element.value);
                } catch (error) {
                    date = null;
                }

                return date;
            }
        });
        $(document).ready(function () {

            $('#txtStartDate').datepicker({
                dateFormat: "dd/mm/yy",

                onSelect: function (date) {
                    var date1 = $('#txtStartDate').datepicker('getDate');


                }
            });

            function getDate(element) {
                var date;
                var dateFormat = "dd/MM/yyyy";
                try {
                    date = $.datepicker.parseDate(dateFormat, element.value);
                } catch (error) {
                    date = null;
                }

                return date;
            }
        });
        $(document).ready(function () {

            $('#txtEndDate').datepicker({
                dateFormat: "dd/mm/yy",

                onSelect: function (date) {
                    var date1 = $('#txtEndDate').datepicker('getDate');


                }
            });

            function getDate(element) {
                var date;
                var dateFormat = "dd/MM/yyyy";
                try {
                    date = $.datepicker.parseDate(dateFormat, element.value);
                } catch (error) {
                    date = null;
                }

                return date;
            }
        });


    </script>
</body>
</html>
