<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="StaffOnLeave.aspx.vb" Inherits="WebApplication2.StaffOnLeave" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Staff On Leave</title>
    <link href="/
    .css" rel="stylesheet"/>
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

           <link rel="stylesheet" href="../StyleSheet1.css" />
<script>
        
               function isNumber1(evt) {

        var charCode = (evt.which) ? evt.which : event.keyCode

        if (
            (charCode != 47 ) &&    
            (charCode != 45 ) &&     
            (charCode < 48 || charCode > 57))
            return false;

        return true;
            }  
           
            </script>

    <style type="text/css">
        .auto-style1 {
            position: absolute;
            top: 195px;
            left: 16px;
            z-index: 1;
            height: 15px;
            width: 153px;
        }
    </style>

</head>
<body>
    <nav class="mb-1 navbar navbar-expand-sm bg-dark navbar-dark " >
  <a class="navbar-brand p-0" href="#"><img src="../NewFolder1/unnamed.png" class="rounded-circle z-depth-0"  height="45"/> </a>
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
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../wapframesetpp.aspx">
          <i class="fab glyphicon glyphicon-home "></i>
        </a></li>
       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../logon.aspx">
          <i class="fab glyphicon glyphicon-log-out"></i>
        </a></li>
           <li class="nav-item ">
        <a class="nav-link p-0" href="#">
          <img src="../NewFolder1/CRIS-Recruitment.jpg" class="rounded-circle z-depth-0"  height="45"/>
        </a>
      </li>
     </ul>
      
  </div>
</nav>
        
         <div class="container ">
    <form id="form1" runat="server" method="post">
        <div class="row">
                  <h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />
      </div>

        <div class ="row">
        <div class="table-responsive">
            <table id="Table2"  class="table">
				<tr>
					<td><FONT color="white" size="5">STAFF ON LEAVE</FONT><hr class="prettyline" />
                        <asp:Label ID="Label1" Text="" runat="server"> </asp:Label>
				        <asp:Label ID="Label4" runat="server" CssClass="auto-style1" Text="Label"></asp:Label>
				</tr>
			</table>
			<table id="Table1"  class="table">
				
                <tr>

					<td ><asp:Label ID="Label2" Text="All Employee On Leave" runat="server"> </asp:Label></td>
					<td></td>

					<td >   <asp:GridView ID="GridView1" runat="server" HorizontalAlign="Center" AutoGenerateColumns="false" BackColor="Gray" ForeColor="Black" PageSize="10" AllowPaging="True" OnPageIndexChanging="OnPageIndexChanging">
       <AlternatingRowStyle BackColor="white" />
							<HeaderStyle HorizontalAlign="Center" ForeColor="White" BackColor="Navy"></HeaderStyle>
            <Columns>
               <asp:BoundField DataField="empno" HeaderText="Employee no" />
                <asp:BoundField DataField="empname" HeaderText="Employee Name" />
                <asp:BoundField DataField="deptcode" HeaderText="Department" />
                <asp:BoundField DataField="leavecode" HeaderText="Leave Code" />
             <asp:BoundField DataField="description" HeaderText="Leave Desc" />
                   <asp:BoundField DataField="from_date" HeaderText="From Date" />
                   <asp:BoundField DataField="to_date" HeaderText="To Date" />
                   <asp:BoundField DataField="number_of_days" HeaderText="Number of days" />
                 <asp:BoundField DataField="l_confirm" HeaderText="Status" />
                 <asp:BoundField DataField="application_number" HeaderText="Application_No" />
                 <asp:TemplateField HeaderText="Cancel(Y)">
            <ItemTemplate><asp:CheckBox Runat="server" ID="check1"></asp:CheckBox></ItemTemplate>
             
        </asp:TemplateField>
    </Columns>
</asp:GridView></td>
					<td>
              
					</td>

                    <TD>
    <asp:button id="cmdUpdate" runat="server"  Text="SUBMIT" CssClass="button button2"></asp:button>
          <%--   <asp:button id="show" runat="server"   Text="SHOW" CssClass="button button2"></asp:button>--%>
</TD>
					<td></td>
				</tr>
               <tr>
                   <td><asp:Label ID="Label3" Text="Departmental Employee On Leave Today" runat="server">  </asp:Label> </td>
                   <td></td>
                   <td>
                         <asp:GridView ID="GridView2" runat="server" HorizontalAlign="Center" AutoGenerateColumns="false" BackColor="Gray" ForeColor="Black" PageSize="10" AllowPaging="True" OnPageIndexChanging="OnPageIndexChanging">
       <AlternatingRowStyle BackColor="white" />
							<HeaderStyle HorizontalAlign="Center" ForeColor="White" BackColor="Navy"></HeaderStyle>
            <Columns>
               <asp:BoundField DataField="empno" HeaderText="Employee no" />
                <asp:BoundField DataField="empname" HeaderText="Employee Name" />
                <asp:BoundField DataField="deptcode" HeaderText="Department" />
             <asp:BoundField DataField="description" HeaderText="Leavecode" />
                   <asp:BoundField DataField="from_date" HeaderText="From Date" />
                   <asp:BoundField DataField="to_date" HeaderText="To Date" />
                   <asp:BoundField DataField="number_of_days" HeaderText="Number of days" />
                <asp:BoundField DataField="l_confirm" HeaderText="Status" />
    </Columns>
</asp:GridView>
                     
                       </td>
                   
                   <td></td>
                   <td></td>
               </tr>
				
			</table>
			
            </div>
            </div>
    </form>
             </div>
    <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
</body>
</html>
