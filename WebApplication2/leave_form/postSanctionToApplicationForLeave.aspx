<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="postSanctionToApplicationForLeave.aspx.vb" Inherits="WebApplication2.Sanction" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sanction</title>
<LINK href="/
    .css" rel="stylesheet">
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

           <link rel="stylesheet" href="../StyleSheet1.css" />
    <script>
        function isInputNumber(evt) {

                    var ch = String.fromCharCode(evt.which);
        if (!(/[0-9]/.test(ch)))
        {
        evt.preventDefault();
    }

            }
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
    <form id="form1" runat="server">
        
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
            <div class="row">
                <div class="table-responsive">

<TABLE id="Table2" class="table">
                <tr>
                    <td colspan="4">
<asp:label id="Label1"  runat="server" >Sanction to Leave Application</asp:label><hr class="prettyline" />
                    </td>
                </tr>
<TR>
<TD  colSpan="3"><asp:label id="lblMessage" runat="server" Width="171px" ForeColor="blue"></asp:label></TD>
<TD><asp:label id="lblMode" runat="server" Width="169px" ForeColor="Blue"></asp:label></TD>
</TR>

<TR>
<TD >
    <asp:GridView ID="GridView1" runat="server" HorizontalAlign="Center" AutoGenerateColumns="false" BackColor="Gray" ForeColor="Black" PageSize="10" AllowPaging="True" OnPageIndexChanging="OnPageIndexChanging" OnSelectedIndexChanged = "OnSelectedIndexChanged">
       <AlternatingRowStyle BackColor="white" />
							<HeaderStyle HorizontalAlign="Center" ForeColor="White" BackColor="Navy"></HeaderStyle>
            <Columns>
                <asp:BoundField DataField="application_number" HeaderText="Application Number" />
               <asp:BoundField DataField="empno" HeaderText="Employee no" />
                <asp:BoundField DataField="empname" HeaderText="Employee Name" />
             <asp:BoundField DataField="leavecode" HeaderText="Leave Code" />
                 <asp:BoundField DataField="lvcode" HeaderText="Leave Description" />
                   <asp:BoundField DataField="from_date" HeaderText="From Date" />
                   <asp:BoundField DataField="to_date" HeaderText="To Date" />
                   <asp:BoundField DataField="number_of_days" HeaderText="Number of days" />
                   <asp:BoundField DataField="reason" HeaderText="Reason" />
         <asp:TemplateField HeaderText="Status(Y)">
            <ItemTemplate><asp:CheckBox Runat="server" ID="check1"></asp:CheckBox></ItemTemplate>
             
        </asp:TemplateField>
                <asp:TemplateField HeaderText="Status(N)">
            <ItemTemplate><asp:CheckBox Runat="server" ID="check2"></asp:CheckBox></ItemTemplate>
             
        </asp:TemplateField>
               
                <asp:TemplateField HeaderText="Remark">
            <ItemTemplate>
                <asp:textbox id="txtremark" runat="server"   CssClass="form-control" MaxLength="100" Width="100px"  TextMode="multiline"></asp:textbox></ItemTemplate>
             
        </asp:TemplateField>
      <%-- <asp:TemplateField HeaderText="View Document">
            
             <ItemTemplate><asp:CheckBox Runat="server" ID="check3"></asp:CheckBox></ItemTemplate>
        </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="View Document">
            <ItemTemplate><asp:Button id="view" runat="server" Text="Show" CommandName="Select" CommandArgument="view" OnClick="view_Click"/></ItemTemplate>
              
        </asp:TemplateField>
                 <asp:TemplateField HeaderText="Leave Details">
            <ItemTemplate><asp:Button id="show" runat="server" Text="Show" CommandName="Select" CommandArgument="show" OnClick="show_Click"/></ItemTemplate>
              
        </asp:TemplateField>
               
    </Columns>
</asp:GridView>

</TD>
<TD>
    
</TD>
<TD>
    <asp:button id="cmdUpdate" runat="server"  Text="SUBMIT" CssClass="button button2"></asp:button>
          <%--   <asp:button id="show" runat="server"   Text="SHOW" CssClass="button button2"></asp:button>--%>
</TD>

</TR>
    <tr>
        
        <td><asp:GridView ID="GridView2" runat="server" HorizontalAlign="Center" AutoGenerateColumns="false">
            <Columns>
               <%--<asp:BoundField DataField="empno" HeaderText="Employee no" />
                   <asp:BoundField DataField="appno" HeaderText="Application no" />
                  <asp:BoundField DataField="filename" HeaderText="File Name" />--%>
        <asp:TemplateField HeaderText="Uploaded document">
            <ItemTemplate>
                <asp:Image ID="Image1" runat="server" Height="300px" Width="300px"
                    ImageUrl='<%# "data:Image/png;base64," + Convert.ToBase64String(Eval("bytes")) %>' />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView><asp:datagrid id="DataGrid3" CssClass="table" runat="server"   AutoGenerateColumns="False" BackColor="Gray" ForeColor="Black" PageSize="5" AllowPaging="True" Width="206px">
							<SelectedItemStyle ForeColor="LightGray"></SelectedItemStyle>
							<EditItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></EditItemStyle>
							<AlternatingItemStyle BackColor="White"></AlternatingItemStyle>
							<ItemStyle HorizontalAlign="Center" BackColor="LightGray"></ItemStyle>
							<HeaderStyle HorizontalAlign="Center" ForeColor="White" BackColor="Navy"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="description" ReadOnly="True" HeaderText="Leave Code"></asp:BoundColumn>
								<asp:BoundColumn DataField="from_date" HeaderText="From Date"></asp:BoundColumn>
								<asp:BoundColumn DataField="to_date" HeaderText="To Date"></asp:BoundColumn>
								<asp:BoundColumn DataField="number_of_days" HeaderText="Days"></asp:BoundColumn>
                                <asp:BoundColumn DataField="reason" HeaderText="Reason"></asp:BoundColumn>
                                <asp:BoundColumn DataField="l_confirm" HeaderText="Status"></asp:BoundColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid>
      

        <asp:datagrid id="Datagrid4" runat="server" CssClass="table"   AutoGenerateColumns="False" BackColor="Gray"  ForeColor="Black">
							<SelectedItemStyle ForeColor="LightGray"></SelectedItemStyle>
							<EditItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></EditItemStyle>
							<AlternatingItemStyle BackColor="White"></AlternatingItemStyle>
							<ItemStyle HorizontalAlign="Center" BackColor="LightGray"></ItemStyle>
							<HeaderStyle HorizontalAlign="Center" ForeColor="White" BackColor="Navy"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="leavecode" ReadOnly="True" HeaderText="Leave Type"></asp:BoundColumn>
								<asp:BoundColumn DataField="leaveavailed" HeaderText="Availed"></asp:BoundColumn>
								<asp:BoundColumn DataField="balance" HeaderText="Balance"></asp:BoundColumn>
							</Columns>
						</asp:datagrid></td> 

        </td>
        
    </tr>
    <tr>
        
        <td>
        </td>
        <td></td>
       
        <td>
            
        </td>
        <td></td>
    </tr>
       

<TR>
<TD  colSpan="4"></TD>
</TR>
<TR>
<TD style="WIDTH: 163px" colSpan="4"></TD>
</TR>
</TABLE></div></div>
    </form></div>
<div class="card-footer" style="text-align:right; position:fixed; width:100%; left:0; bottom:0;"><h4>MAINTAINED BY CRIS</h4></div>
</body>
</html>
