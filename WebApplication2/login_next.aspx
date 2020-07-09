<%--<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="login_next.aspx.vb" Inherits="WebApplication2.login_next" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <meta charset="utf-8"/>
  <meta name="viewport" content="width=device-width, initial-scale=1"/>
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css"/>
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/js/bootstrap.min.js"></script>
     <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.6/umd/popper.min.js"></script>
    <link type="text/css" rel="stylesheet" href="https://cdn.datatables.net/1.10.9/css/dataTables.bootstrap.min.css" />
    <link type="text/css" rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" />
    <link type="text/css" rel="stylesheet" href="https://cdn.datatables.net/responsive/1.0.7/css/responsive.bootstrap.min.css" />
    <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.9/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/responsive/1.0.7/js/dataTables.responsive.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.9/js/dataTables.bootstrap.min.js"></script>
    <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>--%>

    <%--<style>
        body {
       background-image: linear-gradient(to right, #ff8177 0%, #ff867a 0%, #ff8c7f 21%, #f99185 52%, #cf556c 78%, #b12a5b 100%);
    font: 400 15px Lato, sans-serif;
    line-height: 1.8;
    color: #818181;
  }
  h2 {
    font-size: 24px;
    text-transform: uppercase;
    color: #303030;
    font-weight: 600;
    margin-bottom: 30px;
  }
  h4 {
    font-size: 19px;
    line-height: 1.375em;
    color: #303030;
    font-weight: 400;
    margin-bottom: 30px;
  }  
  .jumbotron {
   background-image: linear-gradient(to right, #ff8177 0%, #ff867a 0%, #ff8c7f 21%, #f99185 52%, #cf556c 78%, #b12a5b 100%);
    color: #fff;
    padding: 100px 25px;
    font-family: Montserrat, sans-serif;
    height: 600px;
  }
  .container-fluid {
    padding: 60px 50px;
  }
  .bg-grey {
    background-color: #f6f6f6;
  }
  .logo-small {
    color: #f4511e;
    font-size: 50px;
  }
  .logo {
    color:#1e8cf4;
    font-size: 200px;
  }
  .thumbnail {
    padding: 0 0 15px 0;
    border: none;
    border-radius: 0;
  }
  .thumbnail img {
    width: 100%;
    height: 100%;
    margin-bottom: 10px;
  }
  .carousel-control.right, .carousel-control.left {
    background-image: none;
    color: #1e8cf4;
  }
  .carousel-indicators li {
    border-color:#1e8cf4;
  }
  .carousel-indicators li.active {
    background-color: #1e8cf4;
  }
  .item h4 {
    font-size: 19px;
    line-height: 1.375em;
    font-weight: 400;
    font-style: italic;
    margin: 70px 0;
  }
  .item span {
    font-style: normal;
  }
  .panel {
    border: 1px solid #f4511e; 
    border-radius:0 !important;
    transition: box-shadow 0.5s;
  }
  .panel:hover {
    box-shadow: 5px 0px 40px rgba(0,0,0, .2);
  }
  .panel-footer .btn:hover {
    border: 1px solid #f4511e;
    background-color: #fff !important;
    color: #f4511e;
  }
  .panel-heading {
    color: #fff !important;
    background-color: #f4511e !important;
    padding: 25px;
    border-bottom: 1px solid transparent;
    border-top-left-radius: 0px;
    border-top-right-radius: 0px;
    border-bottom-left-radius: 0px;
    border-bottom-right-radius: 0px;
  }
  .panel-footer {
    background-color: white !important;
  }
  .panel-footer h3 {
    font-size: 32px;
  }
  .panel-footer h4 {
    color: #aaa;
    font-size: 14px;
  }
  .panel-footer .btn {
    margin: 15px 0;
    background-color: #f4511e;
    color: #fff;
  }
  .navbar {
    margin-bottom: 0;
    background-color:black;
    z-index: 9999;
    border: 0;
    font-size: 25px !important;
    line-height: 2 !important;
    letter-spacing: 4px;
    border-radius: 0;
    font-family: Montserrat, sans-serif;
  }
  .navbar li a, .navbar .navbar-brand {
    color: #fff !important;
  }
  .navbar-nav li a:hover, .navbar-nav li.active a {
    color: black !important;
    background-color: #fff !important;
  }
  .navbar-default .navbar-toggle {
    border-color: transparent;
    color: #fff !important;
  }
  footer .glyphicon {
    font-size: 20px;
    margin-bottom: 20px;
    color: #f4511e;
  }
  .slideanim {visibility:hidden;}
  .slide {
    animation-name: slide;
    -webkit-animation-name: slide;
    animation-duration: 1s;
    -webkit-animation-duration: 1s;
    visibility: visible;
  }
  @keyframes slide {
    0% {
      opacity: 0;
      transform: translateY(70%);
    } 
    100% {
      opacity: 1;
      transform: translateY(0%);
    }
  }
  @-webkit-keyframes slide {
    0% {
      opacity: 0;
      -webkit-transform: translateY(70%);
    } 
    100% {
      opacity: 1;
      -webkit-transform: translateY(0%);
    }
  }
  @media screen and (max-width: 768px) {
    .col-sm-4 {
      text-align: center;
      margin: 25px 0;
    }
    .btn-lg {
      width: 100%;
      margin-bottom: 35px;
    }
  }
  @media screen and (max-width: 480px) {
    .logo {
      font-size: 150px;
    }
  }

  .button {
  background-color:dimgray; /* Green */
  border: none;
  color: white;
  padding: 15px 32px;
  text-align: center;
  text-decoration: none;
  display: inline-block;
  font-size: 16px;
  margin: 4px 2px;
  cursor: pointer;
  -webkit-transition-duration: 0.4s; /* Safari */
  transition-duration: 0.4s;
}

.button1 {
  box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19);
}

.button2:hover {
  box-shadow: 0 12px 16px 0 rgba(0,0,0,0.24),0 17px 50px 0 rgba(0,0,0,0.19);
}
        .auto-style3 {
            position: absolute;
            top: 337px;
            left: 901px;
            z-index: 1;
            width: 126px;
            height: 89px;
        }
        .auto-style4 {
            position: absolute;
            top: 298px;
            left: 820px;
            z-index: 1;
            height: 18px;
            width: 243px;
            font-weight: 700;
        }
        </style>--%>
<%--  
   
</head>--%>
<%--<body id="myPage" data-spy="scroll" data-target=".navbar" data-offset="60">
    <nav class="navbar navbar-default navbar-fixed-top">
  <div class="container">
    <div class="navbar-header">
      <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>                        
      </button>--%>
      <%--<a class="navbar-brand" href="#myPage"><img src="NewFolder1/unnamed.png" class=" rounded-circle img-responsive" style="height:30px ; width :40px;" /></a>--%>
<%--    </div>--%>
 <%--   <div class="collapse navbar-collapse" id="myNavbar">
      
    </div>--%>
<%--  </div>
</nav>--%>
   <%-- <div class="jumbotron text-center" style="height:500px">--%>
<%--  <h1>RAIL WHEEL PLAT  BELA</h1> --%>
 <%-- <div id="myCarousel" class="carousel slide" data-ride="carousel" style=" height:100px">
    <!-- Indicators -->
    <ol class="carousel-indicators">
      <li data-target="#myCarousel" data-slide-to="0" ></li>
      <li data-target="#myCarousel" data-slide-to="1" class="active"></li>
      <li data-target="#myCarousel" data-slide-to="2"></li>
    </ol>


    </div>--%>

    <!-- Left and right controls -->
 
     <%--   </div>
 
</div>--%>
<%--<body>
        <nav class="mb-1 navbar navbar-expand-sm bg-dark navbar-dark " >
  <a class="navbar-brand p-0" href="#"><img src="../../NewFolder1/unnamed.png" class="rounded-circle z-depth-0"  height="45"/> </a>
  <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent-333"
    aria-controls="navbarSupportedContent-333" aria-expanded="false" aria-label="Toggle navigation">
    <span class="navbar-toggler-icon"></span>
  </button>
  <div class="collapse navbar-collapse " id="navbarSupportedContent-333" >
      <ul class="navbar-nav ml-auto navbar-center">
         <li class="nav-item" style="font-weight: bold">
             <h1 style="color:white; font-size:30px; margin-left:350px; margin-top:5px">Rail Wheel Plant, Bela</h1> 
       
         </li>
          </ul>
    <ul class="navbar-nav ml-auto  navbar-right">
        <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../../wapframeset.aspx">
          <i class="fab glyphicon glyphicon-home " style="font-size:30px"></i>
        </a></li>

       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../../logon.aspx">
          <i class="fab glyphicon glyphicon-log-out" style="font-size:30px"></i>
        </a></li>
    
        <li class="nav-item ">
        <a class="nav-link p-0" href="#">
          <%--<img src="../../../CRIS-Recruitment.jpg" class="rounded-circle z-depth-0"  height="50" style="border-width: 34px; background-position: 5px 5px; width:50px;margin-top:3px;border-color:white; border-width:50px"/>
        --%><%-- <img src="../../NewFolder1/CRIS-Recruitment.jpg" height="45" style="border-radius:43%"/>
       </a>
      </li>
     </ul>
      
  </div>
</nav>
   
    <div id="services" class="container-fluid text-center">
 
           <form id="f1" runat="server">
                   
           <h2 class="text-center">INTEGRATED INFORMATION MANAGEMENT SYSTEM<br /><br /.
               <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
               </h2>
                   
               <br />
                       <div class="form-group  " style="align-content:center ;"> 
                        
                            <asp:Label ID="Label2" runat="server" CssClass="auto-style4" Text="Select Group From List To Enter"></asp:Label>
                           </div>
                        <div class="input-group-prepend">
                                <%--<asp:Button CssClass="form-inline button button2" runat="server" ID="Buttongrp" type="submit"  style="border-radius:15px" Text="Click For Group" Height="50px" Width="354px"></asp:Button>--%>
                          
                 
                          <%--  <asp:ListBox ID="ddgroup1" runat="server" height="25%" CssClass="auto-style3"></asp:ListBox>
                 
                            </div>
                            
                 
                                <br />--%>
                        <%--<asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:misConnectionString %>" SelectCommand="select distinct group_code from menu_your_password_new where employee_code=@Ecode"></asp:SqlDataSource>--%>
                            
                         <%--   
                                <br />
                           
                            <div class="input-group-prepend">
                            </div>
                            <br />
                            <br />
                      
                       
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
               <br />
                            <br />
                            <br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button CssClass="form-inline button button2" runat="server" ID="btnlogin" type="submit"  style="border-radius:15px" Text="Enter" Width="195px"></asp:Button>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <br />
                            <br />
                            <asp:Button CssClass="form-inline button button2" runat="server" type="submit" ID="back" style="border-radius:15px" Text="Back" Width="187px"></asp:Button>
                            <br />
                            <br />
                        
                   
                </form>
           </div>
    <div class="card-footer" style="text-align:right;background-color:#cccccc;vertical-align:middle;height:45px;width:100%;bottom:0;position:relative"><h4 style="color: black;font-size:15px">MAINTAINED BY CRIS</h4></div>
	</body>

</html>--%>



 <%@ Page Language="vb" AutoEventWireup="false" Codebehind="login_next.aspx.vb" Inherits="WebApplication2.logon_next" %>
<!DOCTYPE HTML>
<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title>Logon</title>
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

    <%--     <link rel="stylesheet" href="../StyleSheet1.css" />--%>
	</head>
	<body>
        <nav class="mb-1 navbar navbar-expand-sm bg-dark navbar-dark " >
  <a class="navbar-brand p-0" href="#"><img src="../../NewFolder1/unnamed.png" class="rounded-circle z-depth-0"  height="45"/> </a>
  <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent-333"
    aria-controls="navbarSupportedContent-333" aria-expanded="false" aria-label="Toggle navigation">
    <span class="navbar-toggler-icon"></span>
  </button>
  <div class="collapse navbar-collapse " id="navbarSupportedContent-333" >
      <ul class="navbar-nav ml-auto navbar-center">
         <li class="nav-item" style="font-weight: bold">
             <h1 style="color:white; font-size:30px; margin-left:350px; margin-top:5px">Rail Wheel Plant, Bela</h1> 
       
         </li>
          </ul>
    <ul class="navbar-nav ml-auto  navbar-right">
       <%-- <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../../wapframeset.aspx">
          <i class="fab glyphicon glyphicon-home " style="font-size:30px"></i>
        </a></li>--%>

      <%-- <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../../logon.aspx">
          <i class="fab glyphicon glyphicon-log-out" style="font-size:30px"></i>
        </a></li>--%>
    
        <li class="nav-item ">
        <a class="nav-link p-0" href="#">
          <%--<img src="../../../CRIS-Recruitment.jpg" class="rounded-circle z-depth-0"  height="50" style="border-width: 34px; background-position: 5px 5px; width:50px;margin-top:3px;border-color:white; border-width:50px"/>
        --%><img src="../../NewFolder1/CRIS-Recruitment.jpg" height="45" style="border-radius:43%"/>
       </a>
      </li>
     </ul>
      
  </div>
</nav> 
           <div class="container">
              <div class="row">
                <div class="table">
       
        <div id="services" class="container text-center">
  <form id="f1" runat="server">
           <h2 class="text-center">INTEGRATED INFORMATION MANAGEMENT SYSTEM</h2>
            <br /><br />
          <div class="table">
            <div class="row">
                <div class="col" align="center">
                           <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </div>
                </div>
            
                    </div>

                    <div class="form-group  " style="align-content:center ;"> 
                        <div class="row">
                            <div class="col" align="center">
                        
                            <asp:Label ID="Label2" runat="server" Text="Select Group From List To Enter"></asp:Label>
                           </div></div>
                  </div>
                  <div class="row">
                            <div class="col" align="center">
                        
                        <div >
                                <%--<asp:Button CssClass="form-inline button button2" runat="server" ID="Buttongrp" type="submit"  style="border-radius:15px" Text="Click For Group" Height="50px" Width="354px"></asp:Button>--%>
                         <asp:ListBox ID="ddgroup1" runat="server" height="75%" style="align:center" CssClass="auto-style3"></asp:ListBox>
                 </div></div>
                            </div>
                            
                 
                                <br />
                     <br />
                  <div class="row">
                            <div class="col" align="center">
                        
                           
                            <div class="input-group-prepend">
                            </div>
                                </div></div>
                        
                            <asp:Button borderStyle="Solid" Font-Bold="True" Font-Size="20px" CssClass="btn btn-dark" runat="server" ID="btnlogin" type="submit"   Text="Enter"></asp:Button>
                            
                            
                            <asp:Button borderStyle="Solid" Font-Bold="True" Font-Size="20px" CssClass="btn btn-dark" runat="server" type="submit" ID="back"  Text="Back" ></asp:Button>
                            <br />
                            <br />
                      
                       
                           
                          
               <br />
                            <br />
                            <br />
                           <div class="row">
                            <div class="col" align="center">
                        
                           </div></div> <br />
                            <br />
                        </div>
                   
                </form>
           </div>
    <div class="card-footer" style="text-align:right;background-color:#cccccc;vertical-align:middle;height:45px;width:100%;bottom:0;position:relative"><h4 style="color: black;font-size:15px">MAINTAINED BY CRIS</h4></div>
	
<%--        <div class="container">
                <form id="f1" runat="server">
                   <div class="form-group  " style="align-content:center ;"> 
                        
                        <asp:Label ID="Label2" runat="server" CssClass="auto-style4" Text="Select Group From List To Enter"></asp:Label>
                           </div>
                 <div class="form-group" style="align-content:center ;">
                     
                     </div>
                     <div class="form-group" style="text-align:center">
                         <div class="row" >
                             <div class="col" style="text-align:center">
                              <asp:Label runat="server" ID="empcode" Text="EMPLOYEE CODE"></asp:Label><br />
                      </div>
                         </div>
                    <div class="row" >
                             <div class="col" style="text-align:center">
                             
                         <div  style="align-content:center" ><span class="glyphicon glyphicon-user"></span><br />
                     <asp:TextBox  runat="server" ID="txtempcode" style="width:200px; height:35px;align-content:center; border-radius:35px" ></asp:TextBox></div>
                     </div></div>
                 <br />
                 <div class="row" >
                       <div class="col" style="align-content:center">
                    <asp:Label runat="server" ID="password" Text="PASSWORD"></asp:Label><br />
                   </div>
                     </div>
                         <div class="row" >
                       <div class="col" style="align-content:center">
                          <div style="align-content:center ;"><span class="glyphicon glyphicon-lock"></span><br />
                     <asp:TextBox  TextMode="Password" runat="server" ID="txtpassword" style="width:200px; height:35px;align-content:center ; border-radius:15px"></asp:TextBox></div><br /> <br /> 
                    </div>

                         </div>
                          
                        
                     </div>
                      <div class="form-group" style="align-content:center ;">
                     <asp:Button runat="server" ID="btnlogin" type="submit"  borderStyle="Solid" Font-Bold="True" Font-Size="20px" CssClass="btn btn-dark" Text="LOGIN"></asp:Button><br /><br />
     <asp:Button  runat="server" type="submit" ID="btnclear" borderStyle="Solid" Font-Bold="True" Font-Size="20px" CssClass="btn btn-dark" Text="CLEAR"></asp:Button>
    </div>
                </form>
           </div></div></div></div>
     <div class="card-footer" style="text-align:right;background-color:#cccccc;vertical-align:middle;height:45px;width:100%;bottom:0;position:relative"><h4 style="color: black;font-size:15px">MAINTAINED BY CRIS</h4></div>
	--%>	                         
     </body>
    </html>