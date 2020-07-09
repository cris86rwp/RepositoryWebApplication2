<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="logon.aspx.vb" Inherits="WebApplication2.logon" %>

<!DOCTYPE html>

<head runat="server">
    <title></title>
     <meta charset="utf-8"/>
  <meta name="viewport" content="width=device-width, initial-scale=1"/>
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css"/>
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/js/bootstrap.min.js"></script>
    <style>
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
    </style>
  
   
</head>
<body id="myPage" data-spy="scroll" data-target=".navbar" data-offset="60">
    <nav class="navbar navbar-default navbar-fixed-top">
  <div class="container">
    <div class="navbar-header">
      <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>                        
      </button>
      <%--<a class="navbar-brand" href="#myPage"><img src="NewFolder1/unnamed.png" class=" rounded-circle img-responsive" style="height:30px ; width :40px;" /></a>--%>
    </div>
 <%--   <div class="collapse navbar-collapse" id="myNavbar">
      
    </div>--%>
  </div>
</nav>
   <%-- <div class="jumbotron text-center" style="height:500px">--%>
  <h1>RAIL WHEEL PLAT  BELA</h1> 
 <%-- <div id="myCarousel" class="carousel slide" data-ride="carousel" style=" height:100px">
    <!-- Indicators -->
    <ol class="carousel-indicators">
      <li data-target="#myCarousel" data-slide-to="0" ></li>
      <li data-target="#myCarousel" data-slide-to="1" class="active"></li>
      <li data-target="#myCarousel" data-slide-to="2"></li>
    </ol>


    </div>--%>

    <!-- Left and right controls -->
 
        </div>
 
</div>
        
   
    <div id="services" class="container-fluid text-center">
 
           <h3 class="text-center">INTEGRATED INFORMATION MANAGEMENT SYSTEM<br /><br /></h3>
            
                <form id="f1" runat="server">
                   <div class="form-group  " style="align-content:center ;"> 
                        
                        <asp:Label class="form-inline" runat="server" visible="true" id="lblmessage"></asp:Label><br />
                    </div>
                 <div class="form-group  " style="align-content:center ;">
                     
                     </div>
                     <div class="form-group  " style="align-content:center ;">
                     <asp:Label class="form-inline" runat="server" ID="empcode" Text="EMPLOYEE CODE"></asp:Label><br />
                         <div class="input-group-prepend"><span class="glyphicon glyphicon-user"></span><br />
                     <asp:TextBox CssClass="form-inline" runat="server" ID="txtempcode" style="width:200px ; height:35px; border-radius:35px" ></asp:TextBox></div>
                     
                 
                       <div class="form-group " style="align-content:center ;">
                    <asp:Label class="form-inline" runat="server" ID="password" Text="PASSWORD"></asp:Label><br />
                   </div>
                          <div class="input-group-prepend"><span class="glyphicon glyphicon-lock"></span><br />
                     <asp:TextBox CssClass="form-inline" TextMode="Password" runat="server" ID="txtpassword" style="width:200px; height:35px; border-radius:15px"></asp:TextBox></div><br /> <br /> 

                     </div>
                      <div class="form-group " style="align-content:center ;">
                     <asp:Button CssClass="form-inline button button2" runat="server" ID="btnlogin" type="submit"  style="width:200px ; border-radius:15px" Text="LOGIN"></asp:Button><br /><br />
                     <%--<asp:Button CssClass="form-inline button button2" runat="server" type="submit" ID="btnclear" style="width:200px; border-radius:15px " Text="CLEAR"></asp:Button>--%>
                     </div>
                </form>
           
    <div class="modal-footer text-capitalize text-center" style="background-image: linear-gradient(to right, #ff8177 0%, #ff867a 0%, #ff8c7f 21%, #f99185 52%, #cf556c 78%, #b12a5b 100%);color:black;"> MAINTAINED BY CRIS</div>     
</body>

</html>
