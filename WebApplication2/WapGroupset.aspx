<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WapGroupset.aspx.vb" Inherits="WebApplication2.WapGroupset" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <meta charset="utf-8"/>
  <meta name="viewport" content="width=device-width, initial-scale=1"/>
  <link rel="stylesheet" href='http://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/css/bootstrap.min.css'
        media="screen" />
    <script type="text/javascript" src='http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.3.min.js'></script>
    <script type="text/javascript" src='http://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js'></script>



  <%-- <script type="text/javascript">
       
      
       $(function () {

          

           //to fix collapse mode width issue
           $(".nav li,.nav li a,.nav li ul").removeAttr('style');
 
           //for dropdown menu
          $(".dropdown-menu").parent().removeClass().addClass('dropdown');
          $(".dropdown>a").removeClass().addClass('dropdown-toggle').append('<b class="caret"></b>').attr('data-toggle', 'dropdown');

           
          
          
           //remove default click redirect effect           
         $('.dropdown-toggle').attr('onclick', '').off('click');
 
        });


      
   </script>--%>
    <script type="text/javascript">
    Sys.WebForms.Menu._elementObjectMapper.getMappedObject = function () {
        return false;
    };
    $(function () {
        debugger;
        $(".navbar-nav li, .navbar-nav a, .navbar-nav ul").removeAttr('style');
        $(".dropdown-menu").closest("li").removeClass().addClass("dropdown-toggle");
        $(".dropdown-toggle").find("a[href='javascript:;']").attr("data-toggle", "dropdown");
        $(".dropdown-toggle").find("a[href='javascript:;'].level1").append('<b class="caret"></b>');
        $(".dropdown-toggle").find("a[href='javascript:;']:not(.level1)").closest('li').addClass('dropdown-submenu');
        $("a.selected").closest("li").addClass("active");
        $("a.selected").closest(".dropdown-toggle").addClass("active");
        $('ul.dropdown-menu [data-toggle=dropdown]').on('click', function (event) {
            event.preventDefault();
            event.stopPropagation();
            $(this).parent().siblings().removeClass('open');
            $(this).parent().toggleClass('open');
        });
    });
      
</script>
    <script type = "text/javascript" >
    function preventBack() { window.history.forward(); }
    setTimeout("preventBack()", 0);
    window.onunload = function () { null };
</script>
    
   
    <style>
        
       .navbar{
           background-color:white;
           color:black
       }
     
    </style>
    <link rel="stylesheet" href="StyleSheet1.css" />
</head>
<body>
      <%--<nav class="mb-1 navbar navbar-expand-sm bg-dark navbar-dark " >
  <a class="navbar-brand p-0" href="#"><img src="/NewFolder1/unnamed.png" class="rounded-circle z-depth-0"  height="45"/> </a>
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
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="WapGroupset.aspx">
          <i class="fab glyphicon glyphicon-home "></i>
        </a></li>

       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="Log.aspx">
          <i class="fab glyphicon glyphicon-log-out"></i>
        </a></li>
    
        <li class="nav-item ">
        <a class="nav-link p-0" href="#">
         
        <img src="NewFolder1/CRIS-Recruitment.jpg" height="45" style="border-radius:43%"/>
       </a>
      </li>
     </ul>
      
  </div>
</nav>--%>
    <form id="form1" runat="server">
     
        <div class="navbar navbar-default ">
    <div class="container-fluid">
        <div class="navbar-header">
           
            <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target=".bs-example-navbar-collapse-1 "
                aria-expanded="false">
                <span class="sr-only">Toggle navigation</span> <span class="icon-bar"></span><span
                    class="icon-bar"></span><span class="icon-bar"></span>
            </button>
            <a class="navbar-brand" href="#"><img src="NewFolder1/unnamed.png" class=" rounded-circle img-responsive" style="height:30px ; width :40px;" /></a>
           
        </div>
       <%--<div class="navbar-right collapse navbar-collapse bs-example-navbar-collapse-1">
             <a  class="navbar-brand" href="logon.aspx" id ="Submit" onclick="<% get_logouttime() %>" ><span class="glyphicon glyphicon-log-out "></span></a>
         <a class="navbar-brand" href="#">  <img src="NewFolder1/CRIS-Recruitment.jpg" class="img-responsive img-rounded" style="height:30px ; width :40px;" /></a>
        </div> --%>
        <div class="collapse navbar-collapse bs-example-navbar-collapse-1 ">
            
            <asp:Menu ID="menuBar" runat="server" Orientation="Horizontal" RenderingMode="List"
                IncludeStyleBlock="false" StaticMenuStyle-CssClass="nav navbar-nav  " DynamicMenuStyle-CssClass="dropdown-menu" MaximumDynamicDisplayLevels="10" >
               <items>
                   <asp:MenuItem Text="PLANNING">
                       <asp:MenuItem Text="PCO"><asp:MenuItem Text="PCOPCO"></asp:MenuItem><asp:MenuItem Text="PCOWTA"></asp:MenuItem><asp:MenuItem Text="SSEPCO"></asp:MenuItem></asp:MenuItem>
                   </asp:MenuItem>
                   <asp:MenuItem Text="PRODUCTION">
                       <asp:MenuItem Text="MELT"><asp:MenuItem Text="MELTING"></asp:MenuItem><asp:MenuItem Text="MELT SUBSTORE"></asp:MenuItem><asp:MenuItem Text="SSEMELT"></asp:MenuItem></asp:MenuItem>
                       <asp:MenuItem Text="MOULD"><asp:MenuItem Text="MOULDING"></asp:MenuItem><asp:MenuItem Text="MOULD INCHARGE"></asp:MenuItem><asp:MenuItem Text="MOULD SUBSTORE"></asp:MenuItem><asp:MenuItem Text="SAND AND HWL"></asp:MenuItem><asp:MenuItem Text="MPO AND SPRAY"></asp:MenuItem><asp:MenuItem Text="POURING"></asp:MenuItem></asp:MenuItem>
                       <asp:MenuItem Text="WHEEL FINAL INSPECTION"><asp:MenuItem Text="WFPS INCHARGE"></asp:MenuItem><asp:MenuItem Text="WHEEL PROCESS"></asp:MenuItem><asp:MenuItem Text="WFPS SUBSTORE"></asp:MenuItem><asp:MenuItem Text="WHEEL INSPECTION"></asp:MenuItem><asp:MenuItem Text="YARD"></asp:MenuItem><asp:MenuItem Text="DESPATCH"></asp:MenuItem></asp:MenuItem>
                       <asp:MenuItem Text="MOULD REPAIR"><asp:MenuItem Text="MOULD REPAIR PROCESS"></asp:MenuItem><asp:MenuItem Text="MRS INCHARGE"></asp:MenuItem></asp:MenuItem>
                   </asp:MenuItem>
                   <asp:MenuItem Text="MAINTENANCE">
                       <asp:MenuItem Text="MECHANICAL"><asp:MenuItem Text="MECHANICAL MELT"></asp:MenuItem><asp:MenuItem Text="MOULD AND MRS"></asp:MenuItem><asp:MenuItem Text="WFPS"></asp:MenuItem></asp:MenuItem>
                       <asp:MenuItem Text="ELECTRICAL"><asp:MenuItem Text="ELECTRICAL MELT"></asp:MenuItem><asp:MenuItem Text="MOULDS"></asp:MenuItem><asp:MenuItem Text="WFPS AND MRS"></asp:MenuItem></asp:MenuItem>
                       <asp:MenuItem Text="TOOL ROOM"></asp:MenuItem>
                       <asp:MenuItem Text="UTILITY"></asp:MenuItem>
                       <asp:MenuItem Text="ROAD TRANSPORT"></asp:MenuItem>
                       <asp:MenuItem Text="ELECTRICAL POWER"></asp:MenuItem>
                   </asp:MenuItem>
                   <asp:MenuItem Text="QUALITY">
                       <asp:MenuItem Text="MAGNA"></asp:MenuItem>
                       <asp:MenuItem Text="SPECTRO"></asp:MenuItem>
                       <asp:MenuItem Text="METLAB"><asp:MenuItem Text="CHEMICAL"></asp:MenuItem><asp:MenuItem Text="PHYSICAL"></asp:MenuItem></asp:MenuItem>
                       <asp:MenuItem Text="CMT"></asp:MenuItem>
                       <asp:MenuItem Text="WHEEL QCI"></asp:MenuItem>
                   </asp:MenuItem>
                   <asp:MenuItem Text="ADMIN">
                       <asp:MenuItem Text="SUPERVISOR"></asp:MenuItem>
                   </asp:MenuItem>
               </items>
         
                
                
            </asp:Menu>
            
         
   <%--  <script type="text/javascript">
    //Disable the default MouseOver functionality of ASP.Net Menu control.
    Sys.WebForms.Menu._elementObjectMapper.getMappedObject = function () {
        return false;
    };
    $(function () {
        //Remove the style attributes.
        $(".navbar-nav li, .navbar-nav a, .navbar-nav ul").removeAttr('style');
           
        //Apply the Bootstrap class to the Submenu.
        $(".dropdown-menu").closest("li").removeClass().addClass("dropdown-toggle");
           
        //Apply the Bootstrap properties to the Submenu.
        $(".dropdown-toggle").find("a").eq(0).attr("data-toggle", "dropdown").attr("aria-haspopup", "true").attr("aria-expanded", "false").append("<span class='caret'></span>");
                 $(".dropdown-menu").parent().removeClass().addClass('dropdown');
           $(".dropdown>a").removeClass().addClass('dropdown-toggle').append('<b class="caret"></b>').attr('data-toggle', 'dropdown');
       // Apply the Bootstrap "active" class to the selected Menu item.
        //$("a.selected").closest("li").addClass("active");
        //$("a.selected").closest(".dropdown-toggle").addClass("active");
    });
</script>--%>
 
            
        </div>
     
    </div>
</div>
            
        <table class="table">
            <tr>
                <td>
                    <asp:Label runat="server" ID="lbl" Font-Size="Medium"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                   <h2> WELCOME  TO  RAIL  WHEEL  PLANT  BELA</h2>
                </td>
            </tr>
            <tr>
                <td >
                   <div class="row ">
    
                  <h4>Select Your Theme  </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-inline ll" style="width:200px; height:35px; border-radius:15px" >
                     <asp:ListItem Selected="True">select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />
      </div>
                </td>
            </tr>
             </table>
         
     
    </form>
  
     <div class="card-footer" style="text-align:right;position: absolute;
  bottom: 0;
  width: 100%;
  height: 2.5rem;"><h4>MAINTAINED BY CRIS</h4></div>
</body>
</html>
