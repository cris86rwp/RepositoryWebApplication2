<%@ Page Language="vb" AutoEventWireup="false" Codebehind="CopyBOM.aspx.vb" Inherits="WebApplication2.CopyBOM" %>
<!DOCTYPE HTML >
<HTML>
	<HEAD>
		<title>CopyBOM</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">

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
	</HEAD>
	<body >
        <div><h1 style="text-align:center;">Rail Wheel Plant Bela (PCO Module)</h1></div>
        <div class="page-header"><img src="NewFolder1/imageedit_3_3734794333 (1).gif" height="60"/><div class="header-right "><img src="NewFolder1/ezgif.com-resize.gif" height="60"  /> </div> </div>
        <div class="container">
		<form id="Form1" method="post" runat="server">
			<asp:panel id="Panel1"  runat="server" >
                 <div class="row">
                <div class="table-responsive">
				
							<TABLE id="Table1" class="table" >
								<TR>
									<TD><STRONG><FONT face="Arial" size="3">Copy BOM</FONT></STRONG><hr class="prettyline" /></TD>
								</TR>
								<TR>
									<TD>
										<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label></TD>
								</TR>
								<TR>
									<TD>
										<asp:RadioButtonList id="rblProduct" runat="server"  AutoPostBack="True" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="rbl" >
											<asp:ListItem Value="F1" Selected="True">Forge Shop</asp:ListItem>
											<asp:ListItem Value="M1">Machine Shop</asp:ListItem>
											<asp:ListItem Value="A1">Assembly Shop</asp:ListItem>
										</asp:RadioButtonList></TD>
								</TR>
							</TABLE>
							<TABLE id="Table2" class="table">
								<TR>
									<TD>SourceProduct</TD>
									<TD>:</TD>
									<TD colSpan="4">
										<asp:TextBox id="txtSource" runat="server" CssClass="form-control" AutoPostBack="True"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD>DesinationProduct</TD>
									<TD>:</TD>
									<TD colSpan="4">
										<asp:TextBox id="txtDesinationProduct" runat="server" CssClass="form-control" AutoPostBack="True"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD align="Center" colSpan="6">
										<asp:Button id="Button1" runat="server" CssClass="button button4" Text="Copy BOM"></asp:Button></TD>
								</TR>
							</TABLE>
					
                    <TABLE id="Table4" class="table">
								<TR>
									<TD>Source Product details :</TD>
								</TR>
								<TR>
									<TD>
										<asp:DataGrid id="dgSourceDetails" runat="server" CssClass="table" AllowPaging="True">
											<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
											<AlternatingItemStyle BackColor="#DCDCDC"></AlternatingItemStyle>
											<ItemStyle ForeColor="Black" BackColor="#EEEEEE"></ItemStyle>
											<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#000084"></HeaderStyle>
											<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
											<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
										</asp:DataGrid></TD>
								</TR>
								<TR>
									<TD>Desination Product details :</TD>
								</TR>
								<TR>
									<TD>
										<asp:DataGrid id="dgDestinationDetails" runat="server" CssClass="table" AllowPaging="True">
											<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#000099"></SelectedItemStyle>
											<AlternatingItemStyle BackColor="#CCCCCC"></AlternatingItemStyle>
											<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Black"></HeaderStyle>
											<FooterStyle BackColor="#CCCCCC"></FooterStyle>
											<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999"></PagerStyle>
										</asp:DataGrid></TD>
								</TR>
							</TABLE>
				<TABLE id="Table5" class="table">
					<TR>
						<TD vAlign="top" align="left">SourceProductBOMList</TD>
						<TD vAlign="top" align="left">DesinationProductBOMList</TD>
					</TR>
					<TR>
						<TD vAlign="top" align="left">
							<asp:DataGrid id="dgSourceBOMList" runat="server" CssClass="table" AllowPaging="True">
								<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
								<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
								<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
								<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
							</asp:DataGrid></TD>
						<TD vAlign="top" align="left">
							<asp:DataGrid id="dgDestinationBOMList" runat="server" CssClass="table" AllowPaging="True">
								<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
								<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
								<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
								<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
							</asp:DataGrid></TD>
					</TR>
				</TABLE>
                    </div></div>
			</asp:panel></form>
            </div>
        <div class="card-footer"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>
