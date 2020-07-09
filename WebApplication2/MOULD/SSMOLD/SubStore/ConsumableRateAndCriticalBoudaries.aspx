<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ConsumableRateAndCriticalBoudaries.aspx.vb" Inherits="WebApplication2.ConsumableRateAndCriticalBoudaries" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
		<title>Consumable rate and critical boundaries</title>
		    <link rel="stylesheet" type="text/css" href="css/jquery-ui.css">
   <LINK id="mss" href="/wap.css" rel="stylesheet"/>
		<META content="Microsoft Visual Studio.NET 7.0" name="GENERATOR"/>
		<META content="Visual Basic 7.0" name="CODE_LANGUAGE"/>
		<META content="JavaScript" name="vs_defaultClientScript"/>
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
         <meta charset="utf-8"/>
  <meta name="viewport" content="width=device-width, initial-scale=1"/>
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css"/>
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
        <script type="text/javascript" src= "https://ajax.googleapis.com/ajax/libs/jqueryui/1.12.1/jquery-ui.min.js">  </script>
<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
<script type="text/javascript" src="//ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
<script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
<script type="text/javascript" src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
 
     <style type="text/css">
         .ui-datepicker {
    background: #333;
    border: 1px solid #555;
    color: #EEE;
    
}
</style>

	</head>
	<body style="overflow-x:hidden">

            <nav class="mb-1 navbar navbar-expand-sm bg-dark navbar-dark " >
  <a class="navbar-brand p-0" href="#"><img src="../../../NewFolder1/unnamed.png" class="rounded-circle z-depth-0"  height="45"/> </a>
  <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent-333"
    aria-controls="navbarSupportedContent-333" aria-expanded="false" aria-label="Toggle navigation">
    <span class="navbar-toggler-icon"></span>
  </button>
  <div class="collapse navbar-collapse " id="navbarSupportedContent-333">
      <ul class="navbar-nav ml-auto  navbar-center">
          <li class="nav-item" style="font-weight: bold">
             <h1 style="color:white; font-size:30px; margin-left:430px; margin-top:5px">Rail Wheel Plant, Bela</h1> 
       
         </li>
          <%--<li class="nav-item"> <a class="nav-link" href="#" style="color:white; font-size:25px;">Rail Wheel Plant Bela</a></li>--%>
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
          <%--<img src="../../NewFolder1/CRIS-Recruitment.jpg" class="rounded-circle z-depth-0"  height="45"/>--%>
            <img src="../../../NewFolder1/CRIS-Recruitment.jpg" height="45" style="border-radius:43%"/>
        </a>
      </li>
     </ul>
      
  </div>
</nav>
<!--/.Navbar -->
         <div class="container">
   <form id="Form1" method="post" runat="server">
            <asp:Panel ID="Panel1" runat="server">
                <div class="container-fluid">
                <div class="row">
                        <div class="table">
                            <div class="row">
                                <div class="col-12" align="center"> <h1>Stock Item Inspection Details</h1><hr />
                                </div >
                            </div>
                            <br />
      <div class="row">
      <div class="col-2"> Material type</div>
          <div class="col-10">
          <b> <asp:RadioButton ID="Stock" runat="server" GroupName="Cri_item" Text="Stock"/>&nbsp;&nbsp;&nbsp;
        <asp:RadioButton ID="NonStock" runat="server" GroupName="Cri_item" Text="Non-Stock"/>&nbsp;&nbsp;&nbsp;
        <asp:RadioButton ID="Others" runat="server" GroupName="Cri_item" Text="Others" /></b>
    </div>
    </div>
        <br />

        <div class="row">
                  <div class="col-2" >
                          <asp:Label ID="ID" runat="server" Text="Item desc"></asp:Label></div>
                <div class="col-2">
                        <asp:TextBox ID="Itemdesc" runat="server" style="width:103px; height:35px;" TextMode="MultiLine" CssClass="form-control"></asp:TextBox></div>
                <div class="col-2">
                            <asp:Label ID="conr" runat="server" Text="Consumption rate" ></asp:Label></div>
                <div class="col-2">
                            <asp:TextBox ID="ConRate" runat="server" style="width:103px; height:35px;" TextMode="MultiLine" CssClass="form-control" ></asp:TextBox></div>
                <div class="col-2">
                         <asp:Label ID="PerUnit1" runat="server" Text="Per Unit"></asp:Label></div>
                <div class="col-2">
                <asp:DropDownList ID="Perunit" runat="server" style="width:103px;" CssClass="form-control 11">
                    <asp:ListItem>PW</asp:ListItem>
                    <asp:ListItem>PH</asp:ListItem>
                    <asp:ListItem>PY</asp:ListItem>
                </asp:DropDownList></div>
            </div>
                <br />
          <div class="row">
                 <div class="col-2">
                    <asp:Label ID="L" runat="server" Text="Critical Items if less than Heats"></asp:Label></div>
                <div class="col-2">
                   <asp:TextBox ID="CritItem" runat="server" style="width:103px;" CssClass="form-control"></asp:TextBox></div>
                <div class="col-2">
                  <asp:Label ID="h" runat="server" Text="Heats"></asp:Label>
               </div>
              </div>
        <br />
        <div class="row">
                <div class="col-12" align="center"><b>
          <asp:Label ID="Label1" runat="server" Text="No of Heat Cast"></asp:Label></b></div>
           </div><br />
               <div class="row">
                <div class="col-2">
               <asp:Label ID="Label2" runat="server" Text="Month"></asp:Label></div>
                <div class="col-2">
                <asp:DropDownList ID="HMonth" runat="server" style="width:103px;" CssClass="form-control 11">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                    <asp:ListItem>9</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                </asp:DropDownList></div>
                   
                <div class="col-2">
                <asp:Label ID="Label3" runat="server" Text="Year" ></asp:Label></div>
                <div class="col-2">
               <asp:TextBox ID="HHeat" runat="server"  placeholder="YYYY" style="width:103px;" CssClass="form-control"></asp:TextBox></div>
                <div class="col-2">
               <asp:Label ID="Label4" runat="server" Text="Heat Count"></asp:Label></div>
                <div class="col-2">
                <asp:TextBox ID="HCount" runat="server" placeholder="NNNN" style="width:103px;" CssClass="form-control"></asp:TextBox>
              </div>
            </div>
           <br />
               <div class="row">
                <div class="col-12" align="center"><b>
          <asp:Label ID="NoW" runat="server" Text="No of Wheel Cast"></asp:Label></b></div>
           </div><br />

           <div class="row">
                <div class="col-2">
                <asp:Label ID="mon" runat="server" Text="Month"></asp:Label></div>
                <div class="col-2">
                <asp:DropDownList ID="WMonth" runat="server" style="width:103px;" CssClass="form-control 11">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                    <asp:ListItem>9</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                </asp:DropDownList></div>
                
                <div class="col-2">
                <asp:Label ID="Year" runat="server" Text="Year"></asp:Label></div>
                <div class="col-2">
                <asp:TextBox ID="WYear" runat="server" placeholder="YYYY" style="width:103px;" CssClass="form-control"></asp:TextBox></div>
                <div class="col-2">
                <asp:Label ID="WC" runat="server" Text="Heat Count"></asp:Label></div>
                <div class="col-2">
                <asp:TextBox ID="WCount" runat="server" placeholder="NNNN" style="width:103px;" CssClass="form-control"></asp:TextBox>
               </div>
             </div>
            <br />
                            <br />
        <div class="row">
    <div class="col-12" align="center">
          <asp:Button ID="Submit1" runat="server" Text="Submit" CssClass="btn btn-dark" Font-Bold="True" Font-Names="Arial" Font-Size="Medium" />&nbsp;&nbsp;&nbsp;&nbsp;
          <asp:Button ID="Reset" runat="server" Text="Reset" CssClass="btn btn-dark" Font-Bold="True" Font-Names="Arial" Font-Size="Medium"/>
     </div>
   </div>  
                            <br />
     </div>
                </div></div>
            </asp:Panel>
        </form>
    </div>
     <%-- <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS </h4></div>--%>
        <div class="card-footer" style="text-align:right;background-color:#cccccc;vertical-align:middle;height:45px; width:100%; bottom:0;position:relative;"><h4 style="color: black;font-size:15px;">MAINTAINED BY CRIS</h4></div>
</body>
</html>
