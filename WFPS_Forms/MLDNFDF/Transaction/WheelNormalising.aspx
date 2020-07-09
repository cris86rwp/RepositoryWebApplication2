
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="WheelNormalising.aspx.vb" Inherits="WebApplication2.WheelNormalising" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
	<HEAD runat="server"  >
		<title>WheelNormalising</title>
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
      <%--   <link rel="stylesheet" href="../../../StyleSheet1.css" />--%>

        <script>
        
        function isInputNumber(evt) {
            var ch = String.fromCharCode(evt.which);
            if (!(/[0-9]/.test(ch)))
            {
                evt.preventDefault();
            }
        }
        </script>
        </HEAD>


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
         <div class="container ">
            
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
			<asp:panel id="pnlMain"  runat="server" >
                 <div class="row">
                <div class="table-responsive">
                    <TABLE id="Table2" class="table">
                        <tr>
                            <td colspan="6"><h3>Rim Quenching</h3><hr class="prettyline" /></td>

                        </tr>
                       <tr>
                           <td><asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label></td>
                       </tr>
                        <tr>
                            <td>
                                Supervisor
                            </td>
                            <td>
                                <asp:TextBox id="txtSup" runat="server" CssClass="form-control"></asp:TextBox><asp:RequiredFieldValidator id="rfv1" runat="server" ErrorMessage="*" ControlToValidate="txtSup"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                OpNo1
                            </td>
                            <td><asp:TextBox id="txtOP1" runat="server" CssClass="form-control"></asp:TextBox><asp:RequiredFieldValidator id="rfv2" runat="server" ErrorMessage="*" ControlToValidate="txtOP1"></asp:RequiredFieldValidator></td>
                            <td>OpNo2</td>
                            <td><asp:TextBox id="txtOP2" runat="server" CssClass="form-control"></asp:TextBox><asp:RequiredFieldValidator id="rfv3" runat="server" ErrorMessage="*" ControlToValidate="txtOP2"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td>HeatNo</td>
                            <td><asp:TextBox id="txtHeatNo" runat="server"  AutoPostBack="True" CssClass="form-control" ToolTip="Enter heat no. in number only" onkeypress="isInputNumber(event)" MaxLength="6"></asp:TextBox>
                            </td>
                            <td>WheelNo</td>
                            <td><asp:TextBox id="txtWheelNo" runat="server"  AutoPostBack="True" CssClass="form-control" onkeypress="isInputNumber(event)" ToolTip="Enter wheel no. in number only" MaxLength="3"></asp:TextBox>
                                    <asp:Label ID="lbl_wheel" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                                  <td>WhlType</td>
                            <td><asp:Label id="lblDesC" runat="server"></asp:Label>&nbsp;</td>
                        </tr>
                         
                        <tr>
                            <td>Quencher No</td>
                            <td><asp:TextBox id="txtPedestial" runat="server"  AutoPostBack="True" CssClass="form-control" onkeypress="isInputNumber(event)" ToolTip="Enter quencher no. between 7 to 48"></asp:TextBox>
                                
                            </td>
                              <td>Temp at RQ(in)</td>
                            <td><asp:TextBox id="txtRQ" runat="server"  AutoPostBack="True" CssClass="form-control" onkeypress="isInputNumber(event)" ToolTip="Enter number only"></asp:TextBox></td>
                        </tr>
                       
                        <tr>
                            <td>
                              Position
                            </td>
                            <td><asp:RadioButtonList id="rblPos" runat="server" AutoPostBack="True" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="rbl">
											<asp:ListItem Value="I" Selected="True">I</asp:ListItem>
											<asp:ListItem Value="O">O</asp:ListItem>
										</asp:RadioButtonList></td>
                        </tr>
                        <tr>
                            <td>Date</td>
                            <td><asp:TextBox id="txtDt" runat="server"  AutoPostBack="True" CssClass="form-control"></asp:TextBox></td>
                            <td>Time</td>
                            <td>	<asp:textbox id="txtStTimeHH" runat="server" MaxLength="2" CssClass="form-control"></asp:textbox></td>
										<td><asp:textbox id="txtStTimeMM" runat="server"  MaxLength="2" CssClass="form-control"></asp:textbox> (HH:MM)</td>
                            
                        </tr>
                       
                        <tr>
                            <td colspan="5"><asp:RadioButtonList id="rblMcnList" runat="server"  AutoPostBack="True" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="rbl"></asp:RadioButtonList></td>
                           
                        </tr>
                        <tr>
                            <td>Remarks</td>
                            <td colspan="4"><asp:TextBox id="txtRemarks" runat="server" CssClass="form-control"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td><asp:CheckBox id="chkCW" runat="server" AutoPostBack="True" Text="Cold Wheel"></asp:CheckBox></td>
                            <td><asp:CheckBox id="chkRW" runat="server" AutoPostBack="True" Text="Regular Wheel"></asp:CheckBox></td>

                        </tr>
                        <tr>
                            <td colspan="2"></td>
                            <td ><asp:Button id="btnSave" runat="server" Text="Save" CssClass="button button2"></asp:Button><asp:Label id="lblSlNo" runat="server"></asp:Label></td>
                            <td ><asp:Button id="btnClear" runat="server" Text="Clear" CssClass="button button2"></asp:Button></td>
                            <%--<td ><asp:Button id="btnScore" runat="server" Text="Score" CssClass="button button2"></asp:Button></td>--%>
                        </tr>
                        <tr>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                        </tr>
                        </TABLE>
                     <asp:DataGrid ID="dg_insert" runat="server" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" CssClass="table">
                                <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                                <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                                <ItemStyle BackColor="White" ForeColor="#330099" />
                                <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />                            
                            </asp:DataGrid>
                </div>
                 </div>
                    <%--<TABLE id="Table15" style="WIDTH: 92px; HEIGHT: 58px" cellSpacing="1" cellPadding="1" width="92" border="1">
								<TR>
									<TD vAlign="top" align="left">
										<asp:DataGrid id="dgData1" runat="server" Width="70px" BackColor="White" AutoGenerateColumns="False" Height="73px" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4">
											<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
											<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
											<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
											<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
											<Columns>
												<asp:ButtonColumn Text="Select" CommandName="Select"></asp:ButtonColumn>
												<asp:BoundColumn DataField="Wh" ReadOnly="True" HeaderText="Wh"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="wheel_type" HeaderText="wheel_type"></asp:BoundColumn>
											</Columns>
											<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
										</asp:DataGrid></TD>
									<TD vAlign="top" align="left">
										<asp:DataGrid id="dgData2" runat="server" Width="3px" BackColor="White" AutoGenerateColumns="False" Height="95px" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4">
											<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
											<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
											<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
											<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
											<Columns>
												<asp:ButtonColumn Text="Select" CommandName="Select"></asp:ButtonColumn>
												<asp:BoundColumn DataField="Wh" ReadOnly="True" HeaderText="Wh"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="wheel_type" HeaderText="wheel_type"></asp:BoundColumn>
											</Columns>
											<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
										</asp:DataGrid></TD>
									<TD vAlign="top" align="left">
										<asp:DataGrid id="dgData3" runat="server" Width="86px" BackColor="White" AutoGenerateColumns="False" Height="30px" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4">
											<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
											<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
											<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
											<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
											<Columns>
												<asp:ButtonColumn Text="Select" CommandName="Select"></asp:ButtonColumn>
												<asp:BoundColumn DataField="Wh" ReadOnly="True" HeaderText="Wh"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="wheel_type" HeaderText="wheel_type"></asp:BoundColumn>
											</Columns>
											<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
										</asp:DataGrid></TD>
									<TD vAlign="top" align="left">
										<asp:DataGrid id="dgData4" runat="server" Width="86px" BackColor="White" AutoGenerateColumns="False" Height="31px" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4">
											<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
											<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
											<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
											<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
											<Columns>
												<asp:ButtonColumn Text="Select" CommandName="Select"></asp:ButtonColumn>
												<asp:BoundColumn DataField="Wh" ReadOnly="True" HeaderText="Wh"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="wheel_type" HeaderText="wheel_type"></asp:BoundColumn>
											</Columns>
											<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
										</asp:DataGrid></TD>
								</TR>
							</TABLE>--%>
                    <%--<asp:DataGrid id="DataGrid1" runat="server" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal">
								<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#339966"></SelectedItemStyle>
								<ItemStyle ForeColor="#333333" BackColor="White"></ItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#336666"></HeaderStyle>
								<FooterStyle ForeColor="#333333" BackColor="White"></FooterStyle>
								<PagerStyle HorizontalAlign="Center" ForeColor="White" BackColor="#336666" Mode="NumericPages"></PagerStyle>
							</asp:DataGrid>--%>
				    <%--<asp:DataGrid id="DataGrid3" runat="server" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal">
								<SelectedItemStyle Font-Bold="True" ForeColor="#F7F7F7" BackColor="#738A9C"></SelectedItemStyle>
								<AlternatingItemStyle BackColor="#F7F7F7"></AlternatingItemStyle>
								<ItemStyle ForeColor="#4A3C8C" BackColor="#E7E7FF"></ItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="#F7F7F7" BackColor="#4A3C8C"></HeaderStyle>
								<FooterStyle ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
								<PagerStyle HorizontalAlign="Right" ForeColor="#4A3C8C" BackColor="#E7E7FF" Mode="NumericPages"></PagerStyle>
							</asp:DataGrid>--%>
                    <%--<asp:DataGrid id="DataGrid2" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
					<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#669999"></SelectedItemStyle>
					<ItemStyle ForeColor="#000066"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#006699"></HeaderStyle>
					<FooterStyle ForeColor="#000066" BackColor="White"></FooterStyle>
					<PagerStyle HorizontalAlign="Left" ForeColor="#000066" BackColor="White" Mode="NumericPages"></PagerStyle>
				</asp:DataGrid>--%>
                    </asp:panel>
		</form></div>
         <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
        </html>
WheelNormalising.aspx
Displaying WheelNormalising.aspx.