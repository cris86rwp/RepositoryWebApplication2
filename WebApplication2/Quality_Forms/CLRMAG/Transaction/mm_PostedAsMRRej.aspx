<%@ Page Language="vb" AutoEventWireup="false" Codebehind="mm_PostedAsMRRej.aspx.vb" Inherits="WebApplication2.mm_PostedAsMRRej" %>
<!DOCTYPE HTML PUBLIC "-//W3C//Dtd HTML 4.0 transitional//EN">
<html>
	<head runat="server">
		<title>mm_PostedAsMRRej</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0"/>
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0"/>
		<meta name="vs_defaultClientScript" content="JavaScript"/>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5"/>

      <%--  add...--%>
                <meta charset="utf-8"/>
  <meta name="viewport" content="width=device-width, initial-scale=1"/>
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css"/>
  <script  src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.6/umd/popper.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/js/bootstrap.min.js"></script>
        <link type="text/css" rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" />
   
	</head>
	<body >
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
       
<div class="container ">

		<form id="Form1" method="post" runat="server">
            
        



			<asp:Panel id="Panel1"  runat="server">
                <div class="row">
                <div class="table">
				
					<div class="row">
						<div class="col" colspan="6" align="center"><FONT size="6px";Font-Bold="True" >Post as&nbsp;MR XC </FONT></div>
					</div>
					<div class="row">
						<div class="col"  colspan="6">
							<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                           
						</div>
					</div>
                    <br />
                    <br />
                    <br />
					<div class="row">
						<div class="col">WhlNo</div>
						<div class="col">:</div>
						<div class="col">
							<asp:TextBox id="txtWhl" runat="server" AutoPostBack="true" CssClass="form-control"  Height="30px" TabIndex="5" Width="120px"></asp:TextBox></div>
						<div class="col">HeatNo</div>
						<div class="col">:</div>
						<div class="col">
							<asp:TextBox id="txtHeat" runat="server" AutoPostBack="true" CssClass="form-control"  Height="30px" TabIndex="5" Width="120px"></asp:TextBox></div>
					    <div class="col">Status</div>
                        <div class="col">:</div>
                        <div class="col">
                            <asp:TextBox id="txtChange" runat="server"  AutoPostBack="true" CssClass="form-control"  Height="30px" TabIndex="5" Width="120px"></asp:TextBox>
							<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtChange"></asp:RequiredFieldValidator></div>
						
                    </div>
					<%--<tr>
						<td>Status</td>
						<td>:</td>
						<td >
							<asp:TextBox id="txtChange" runat="server"  AutoPostBack="true" CssClass="form-control"  Height="30px" TabIndex="5" Width="120px"></asp:TextBox>
							<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtChange"></asp:RequiredFieldValidator></td>
						
					</tr>--%>
					<div class="row">
						<div class="col" vAlign="top" align="middle" colspan="6" style="margin-top:80px">
							<asp:Button id="btnChange" runat="server" Text="Change Status"  Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark" ></asp:Button>
							<asp:Label id="lblEmpCode" runat="server" Visible="False"></asp:Label></div>
					</div>
				</table>
                    
                
				<asp:DataGrid id="DataGrid1" runat="server" CssClass="table">
					<SelectedItemStyle Font-Bold="true" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="true" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>
                </div></div>
			</asp:Panel>
              
		</form>
    </div>
        
	</body>
     <div class="card-footer" style="text-align:right;background-color:cccccc;vertical-align:middle;position:absolute;bottom:0;width:100%;height:60px"><h4 style="color: black;font-size:15px">MAINTAINED BY CRIS</h4></div>
</html>
