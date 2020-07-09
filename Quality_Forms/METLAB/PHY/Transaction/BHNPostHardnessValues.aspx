<%@ Page Language="vb" AutoEventWireup="false" Codebehind="BHNPostHardnessValues.aspx.vb" Inherits="WebApplication2.BHNPostHardnessValues" smartNavigation="True" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>BHNPostHardnessValues</title>
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
    <!-- <link rel="stylesheet" href="../../StyleSheet1.css" />-->
	    <style type="text/css">
            .auto-style1 {
                display: block;
                width: 100%;
                height: 34px;
                font-size: 14px;
                font-weight: 400;
                line-height: 1.42857143;
                color: #555;
                background-clip: padding-box;
                border-radius: 4px;
                transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
                -webkit-box-shadow: inset 0 1px 1px rgba(0, 0, 0, .075);
                box-shadow: inset 0 1px 1px rgba(0, 0, 0, .075);
                -webkit-transition: border-color ease-in-out .15s, -webkit-box-shadow ease-in-out .15s;
                -o-transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
                right: 1112px;
                border: 1px solid #ccc;
                padding: 6px 12px;
                background-color: #fff;
                background-image: none;
            }
        </style>
	</HEAD>
	<BODY >

          <nav class="mb-1 navbar navbar-expand-sm bg-dark navbar-dark " >
  <a class="navbar-brand p-0" href="#" style=""><img src="../../../../NewFolder1/unnamed.png" class="rounded-circle z-depth-0"  height="45"/ > </a>
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
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../../../wapframeset.aspx">
          <i class="fab glyphicon glyphicon-home " style="font-size:30px"></i>
        </a></li>

       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../../../logon.aspx">
          <i class="fab glyphicon glyphicon-log-out" style="font-size:30px"> </i>
        </a></li>
    
        <li class="nav-item ">
        <a class="nav-link p-0" href="#"><img src="../../../../NewFolder1/CRIS-Recruitment.jpg" height="45" style="border-radius:43%"/>
        
        
       </a>
      </li>
     </ul>
      
  </div>
</nav>
        <br />
<!--/.Navbar -->
        <div class="container">
		<FORM id="Form1" method="post" runat="server">
            <div class="row"><div class="table">
                <div class="row">
                 <div class="col"  align="center">
                 <asp:dropdownlist id="ddlWheelNumber"   runat="server" Width="125px" AutoPostBack="True" CssClass="form-control"></asp:dropdownlist> </div>
           
            </div>
                <br />
                 <div class="row">
                        <div class="col" align="center" >
          
            <asp:label id="Label1" runat="server">LabNumber :</asp:label>
                      <asp:label id="lblLabNum" runat="server"></asp:label></div></div>

                      </div>
                <br />
               <asp:Panel id="Panel1"  runat="server">
                   <div class="table">
				<div class="row">
					<div class="col" align="center"><asp:label id="lblmessage" runat="server"  ForeColor="Red" Font-Size="Large" Font-Bold="True"></asp:label></div>
                         <div class="col" align="center" >
                        <asp:label id="lblTestType" runat="server" Visible="False"></asp:label></div>
				</div>
			</div>
                      <div class="row">
        <div class="col">
<asp:customvalidator id="CustomValidator1"  runat="server" Height="3px" Width="3px" ControlToValidate="txtBHN" ErrorMessage="*" Display="Dynamic"></asp:customvalidator></div>
 <div class="col" style="margin-left:-110px">
<asp:label id="lblProductType"  runat="server"></asp:label>
       </div>
                    </div>
              <div class="row">
                  <div class="col" style="margin-left:100px">
           	<asp:image id="imgHSBlank" runat="server" Height="850px" Width="900px" ImageAlign="AbsMiddle" ImageUrl="../../../../NewFolder1/HS-BLANKforReport.jpg" ></asp:image>
                  
            
			<%--<asp:dropdownlist id="ddlWheelNumber" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:dropdownlist>
            <asp:customvalidator id="CustomValidator1"  runat="server" ControlToValidate="txtBHN" ErrorMessage="*" Display="Dynamic"></asp:customvalidator>
            <asp:label id="lblProductType" runat="server"></asp:label>
            <asp:textbox id="txtBHN"  runat="server" CssClass="form-control" AutoPostBack="True" MaxLength="3"></asp:textbox>
            <asp:textbox id="txtF11"  runat="server" CssClass="form-control" AutoPostBack="True" MaxLength="3"></asp:textbox>
            <asp:textbox id="txtR11"  runat="server" CssClass="form-control" AutoPostBack="True" MaxLength="3"></asp:textbox>
            <asp:textbox id="txtR12"  runat="server" CssClass="form-control" AutoPostBack="True" MaxLength="3"></asp:textbox>
            <asp:textbox id="txtR13"  runat="server" CssClass="form-control" AutoPostBack="True" MaxLength="3"></asp:textbox>
            <asp:textbox id="txtR14"  runat="server" CssClass="form-control" AutoPostBack="True" MaxLength="3"></asp:textbox>
            <asp:textbox id="txtR21"  runat="server" CssClass="form-control" AutoPostBack="True" MaxLength="3"></asp:textbox>
            <asp:textbox id="txtR22"  runat="server" CssClass="form-control" AutoPostBack="True" MaxLength="3"></asp:textbox>
            <asp:textbox id="txtR23"  runat="server" CssClass="form-control" AutoPostBack="True" MaxLength="3"></asp:textbox>
            <asp:textbox id="txtR24"  runat="server" CssClass="form-control" AutoPostBack="True" MaxLength="3"></asp:textbox>
            <asp:textbox id="txtR31"  runat="server" CssClass="form-control" AutoPostBack="True" MaxLength="3"></asp:textbox>
            <asp:textbox id="txtR32"  runat="server" CssClass="form-control" AutoPostBack="True" MaxLength="3"></asp:textbox>
            <asp:textbox id="txtR33"  runat="server" CssClass="form-control" AutoPostBack="True" MaxLength="3"></asp:textbox>
            <asp:textbox id="txtR34"  runat="server" CssClass="form-control" AutoPostBack="True" MaxLength="3"></asp:textbox>
            <asp:textbox id="txtR41"  runat="server" CssClass="form-control" AutoPostBack="True" MaxLength="3"></asp:textbox>
            <asp:textbox id="txtR42"  runat="server" CssClass="form-control" AutoPostBack="True" MaxLength="3"></asp:textbox>
            
            
            
            <asp:textbox id="txtR43"  runat="server" CssClass="form-control" AutoPostBack="True" MaxLength="3"></asp:textbox>
            <asp:textbox id="txtP11"  runat="server" CssClass="form-control" AutoPostBack="True" MaxLength="3"></asp:textbox>
            <asp:textbox id="txtP12"  runat="server" CssClass="form-control" AutoPostBack="True" MaxLength="3"></asp:textbox>
            <asp:textbox id="txtP21"  runat="server" CssClass="form-control" AutoPostBack="True" MaxLength="3"></asp:textbox>
            <asp:textbox id="txtP31"  runat="server" CssClass="form-control" AutoPostBack="True" MaxLength="3"></asp:textbox>
            <asp:textbox id="txtP41"  runat="server" CssClass="form-control" AutoPostBack="True" MaxLength="3"></asp:textbox>
            <asp:textbox id="txtP51"  runat="server" CssClass="form-control" AutoPostBack="True" MaxLength="3"></asp:textbox>
            <asp:textbox id="txtP61"  runat="server" CssClass="form-control" AutoPostBack="True" MaxLength="3"></asp:textbox>
            <asp:textbox id="txtP71"  runat="server" CssClass="form-control" AutoPostBack="True" MaxLength="3"></asp:textbox>
            <asp:textbox id="txtP81"  runat="server" CssClass="form-control" AutoPostBack="True" MaxLength="3"></asp:textbox>
            
            <asp:textbox id="txtP91"  runat="server" CssClass="form-control" AutoPostBack="True" MaxLength="3"></asp:textbox>
            <asp:textbox id="txtH11"  runat="server" CssClass="form-control" AutoPostBack="True" MaxLength="3"></asp:textbox>
            <asp:textbox id="txtH12"  runat="server" CssClass="form-control" AutoPostBack="True" MaxLength="3"></asp:textbox>
            <asp:textbox id="txtH21"  runat="server" CssClass="form-control" AutoPostBack="True" MaxLength="3"></asp:textbox>
            <asp:textbox id="txtH22"  runat="server" CssClass="form-control" AutoPostBack="True" MaxLength="3"></asp:textbox>
            <asp:textbox id="txtH23"  runat="server" CssClass="form-control" AutoPostBack="True" MaxLength="3"></asp:textbox>
            <asp:textbox id="txtH24"  runat="server" CssClass="form-control" AutoPostBack="True" MaxLength="3"></asp:textbox>
            <asp:textbox id="txtH25"  runat="server" CssClass="form-control" AutoPostBack="True" MaxLength="3"></asp:textbox>
            <asp:textbox id="txtH26"  runat="server" CssClass="form-control" AutoPostBack="True" MaxLength="3"></asp:textbox>
            <asp:textbox id="txtH31"  runat="server" CssClass="form-control" AutoPostBack="True" MaxLength="3"></asp:textbox>
            <asp:textbox id="txtH32"  runat="server" CssClass="form-control" AutoPostBack="True" MaxLength="3"></asp:textbox>
            <asp:textbox id="txtH33"  runat="server" CssClass="form-control" AutoPostBack="True" MaxLength="3"></asp:textbox>
            <asp:textbox id="txtH34"  runat="server" CssClass="form-control" AutoPostBack="True" MaxLength="3"></asp:textbox>
            
            <asp:textbox id="txtH35"  runat="server" CssClass="form-control" AutoPostBack="True" MaxLength="3"></asp:textbox>
            <asp:textbox id="txtH36"  runat="server" CssClass="form-control" AutoPostBack="True" MaxLength="3"></asp:textbox>
           <asp:button id="btnSave"  runat="server" CssClass="button button2" Text="Save"></asp:button>--%>

    
                <br />
            <div class="row">                
      <div class="col">  
          <asp:textbox id="txtF11"  runat="server"   CssClass="form-control" MaxLength="3" style="Z-INDEX: 101; WIDTH: 50px; POSITION: absolute; TOP: -795px;left:650px"></asp:textbox> </div>
      </div>
      <div class="row">                
      <div class="col">
            <asp:textbox id="txtBHN"  runat="server"  AutoPostBack="True" CssClass="form-control" style="Z-INDEX: 101; WIDTH: 50px; POSITION:absolute; TOP: -745px;left:150px" MaxLength="3" ></asp:textbox> </div>
    
            <div class="col">
            <asp:textbox id="txtR11" runat="server" CssClass="form-control"  AutoPostBack="True" MaxLength="3" style="Z-INDEX: 101; WIDTH: 50px; POSITION: absolute; TOP: -745px;left:70px"></asp:textbox> </div>
      <div class="col">
            <asp:textbox id="txtR12"  runat="server"  CssClass="auto-style1" AutoPostBack="True" MaxLength="3" style="Z-INDEX: 101; WIDTH: 50px; POSITION: absolute; TOP: -745px;left:10px"></asp:textbox>
            </div>
      <div class="col">
           <asp:textbox id="txtR13"  runat="server"   CssClass="form-control" AutoPostBack="True" MaxLength="3" style="Z-INDEX: 101; WIDTH: 50px; POSITION: absolute; TOP: -745px;left:-40px"></asp:textbox> </div>
      <div class="col">
            <asp:textbox id="txtR14"  runat="server"  Width="50px" CssClass="form-control" AutoPostBack="True" MaxLength="3" style="Z-INDEX: 101; WIDTH: 50px; POSITION: absolute; TOP: -745px;left:-95px"></asp:textbox> </div>
        
          </div>
       <div class="row">
            <div class="col">
           <asp:textbox id="txtR21"  runat="server" Width="50px" CssClass="form-control" AutoPostBack="True" MaxLength="3" style="Z-INDEX: 101; WIDTH: 50px; POSITION: absolute; TOP: -707px;left:205px"></asp:textbox> </div>
          <div class="col">
           <asp:textbox id="txtR22"  runat="server" Width="50px" CssClass="form-control" AutoPostBack="True" MaxLength="3" style="Z-INDEX: 101; WIDTH: 50px; POSITION: absolute; TOP: -707px;left:90px" ></asp:textbox> </div>
          <div class="col">
           <asp:textbox id="txtR23"  runat="server"  Width="50px" CssClass="form-control" AutoPostBack="True" MaxLength="3" style="Z-INDEX: 101; WIDTH: 50px; POSITION: absolute; TOP: -707px;left:-15px"></asp:textbox> </div>
           <div class="col">
             <asp:textbox id="txtR24" runat="server"   CssClass="form-control" AutoPostBack="True" MaxLength="3" style="Z-INDEX: 101; WIDTH: 50px; POSITION: absolute; TOP: -707px;left:-110px"></asp:textbox> </div>
    
     
       </div>
     <div class="row">
           <div class="col">
            <asp:textbox id="txtR31"  runat="server"  Width="50px" CssClass="form-control" AutoPostBack="True" MaxLength="3" style="Z-INDEX: 101; WIDTH: 50px; POSITION: absolute; TOP: -670px;left:260px"></asp:textbox> </div>
         <div class="col">
            <asp:textbox id="txtR32"  runat="server"  Width="50px" CssClass="form-control" AutoPostBack="True" MaxLength="3" style="Z-INDEX: 101; WIDTH: 50px; POSITION: absolute; TOP: -670px;left:150px"></asp:textbox>
         </div>
        <div class="col">
                <asp:textbox id="txtR33"  runat="server"  Width="50px" AutoPostBack="True" MaxLength="3" CssClass="form-control"  style="Z-INDEX: 101; WIDTH: 50px; POSITION: absolute; TOP: -670px;left:60px"></asp:textbox> </div>
        <div class="col">
                 <asp:textbox id="txtR34"  runat="server"  Width="50px" AutoPostBack="True" MaxLength="3" CssClass="form-control" style="Z-INDEX: 101; WIDTH: 50px; POSITION: absolute; TOP: -670px;left:-45px"></asp:textbox> </div>
       
     </div>

     <div class="row"> 
            
         <div class="col">
                 <asp:textbox id="txtR41"  runat="server"  Width="50px" AutoPostBack="True" MaxLength="3" CssClass="form-control" style="Z-INDEX: 101; WIDTH: 50px; POSITION: absolute; TOP: -630px;left:320px"></asp:textbox> </div>
             <div class="col">
                  <asp:textbox id="txtR42" runat="server" Width="50px" AutoPostBack="True" MaxLength="3" CssClass="form-control" style="Z-INDEX: 101; WIDTH: 50px; POSITION: absolute; TOP: -630px;left:150px"></asp:textbox> </div>
            <div class="col">
                 <asp:textbox id="txtR43"  runat="server"  Width="50px" AutoPostBack="True" MaxLength="3" CssClass="form-control" style="Z-INDEX: 101; WIDTH: 50px; POSITION: absolute; TOP: -630px;left:-35px"></asp:textbox> </div>
    
     </div>
     <div class="row">
         
         <div class="col">
                  <asp:textbox id="txtP11"  runat="server"  Width="50px" AutoPostBack="True" MaxLength="3" CssClass="form-control" style="Z-INDEX: 101; WIDTH: 50px; POSITION: absolute; TOP: -590px;left:400px"></asp:textbox> </div>
      <div class="col">
               <asp:textbox id="txtP12"  runat="server"  Width="50px" AutoPostBack="True" MaxLength="3" CssClass="form-control" style="Z-INDEX: 101; WIDTH: 50px; POSITION: absolute; TOP: -590px;left:50px"></asp:textbox> </div>
     
         </div>
    <div class="row">
        <div class="col">
                    <asp:textbox id="txtP21"  runat="server"  Width="50px" AutoPostBack="True" MaxLength="3" CssClass="form-control" style="Z-INDEX: 101; WIDTH: 50px; POSITION: absolute; TOP: -550px;left:460px"></asp:textbox> </div>
        
         </div>  
     <div class="row">
           <div class="col">
                    <asp:textbox id="txtP31"  runat="server"  Width="50px" AutoPostBack="True" MaxLength="3" CssClass="form-control" style="Z-INDEX: 101; WIDTH: 50px; POSITION: absolute; TOP: -500px;left:500px"></asp:textbox> </div>
      
        </div>  
     <div class="row">
         <div class="col">
                    <asp:textbox id="txtP41"  runat="server"  Width="50px" AutoPostBack="True" MaxLength="3" CssClass="form-control" style="Z-INDEX: 101; WIDTH: 50px; POSITION: absolute; TOP: -450px;left:530px"></asp:textbox> </div>
       
         </div>
                 
      <div class="row">
          <div class="col">
                    <asp:textbox id="txtP51" runat="server"  Width="50px" AutoPostBack="True" MaxLength="3" CssClass="form-control" style="Z-INDEX: 101; WIDTH: 50px; POSITION: absolute; TOP: -400px;left:550px"></asp:textbox> </div>
           
            </div>
                 
      <div class="row">   
           <div class="col">
                     <asp:textbox id="txtP61"  runat="server"  Width="50px" AutoPostBack="True" MaxLength="3" CssClass="form-control" style="Z-INDEX: 101; WIDTH: 50px; POSITION: absolute; TOP: -350px;left:580px"></asp:textbox></div>
         </div>
                 
      <div class="row">
           <div class="col">
                   <asp:textbox id="txtP71"  runat="server"  Width="50px" AutoPostBack="True" MaxLength="3" CssClass="form-control" style="Z-INDEX: 101; WIDTH: 50px; POSITION: absolute; TOP: -305px;left:590px"></asp:textbox></div>
          </div>  
      <div class="row">
          <div class="col">
                    <asp:textbox id="txtP81"  runat="server"  Width="50px" AutoPostBack="True" MaxLength="3" CssClass="form-control" style="Z-INDEX: 101; WIDTH: 50px; POSITION: absolute; TOP: -250px;left:580px"></asp:textbox></div>
       </div>
                 
      <div class="row">  
          <div class="col">
                    <asp:textbox id="txtP91"  runat="server"  Width="50px" AutoPostBack="True" MaxLength="3" CssClass="form-control" style="Z-INDEX: 101; WIDTH: 50px; POSITION: absolute; TOP: -200px;left:570px"></asp:textbox></div>
         </div>  
      <div class="row"> 
          <div class="col">
                    <asp:textbox id="txtH11"  runat="server"  Width="50px" AutoPostBack="True" MaxLength="3" CssClass="form-control" style="Z-INDEX: 101; WIDTH: 50px; POSITION: absolute; TOP: -145px;left:525px"></asp:textbox>
              <div class="col">
                    <asp:textbox id="txtH12" runat="server"  Width="50px" AutoPostBack="True" MaxLength="3" CssClass="form-control" style="Z-INDEX: 101; WIDTH: 50px; POSITION: absolute; TOP: -145px;left:610px"></asp:textbox> </div>
           
              </div>
      
   </div>
    <div class="row">  
            <div class="col">
                 <asp:textbox id="txtH21" runat="server"  Width="50px" AutoPostBack="True" MaxLength="3" CssClass="form-control" style="Z-INDEX: 101; WIDTH: 50px; POSITION: absolute; TOP: -90px;left:170px"></asp:textbox> </div>
            <div class="col">
                 <asp:textbox id="txtH22"  runat="server"  Width="50px" AutoPostBack="True" MaxLength="3" CssClass="form-control" style="Z-INDEX: 101; WIDTH: 50px; POSITION: absolute; TOP: -90px;left:140px"></asp:textbox> </div>
          
    
        <div class="col">
                  <asp:textbox id="txtH23"  runat="server"  Width="50px" AutoPostBack="True" MaxLength="3" CssClass="form-control" style="Z-INDEX: 101; WIDTH: 50px; POSITION: absolute; TOP: -90px;left:130px"></asp:textbox> </div>
       
        <div class="col">
                  <asp:textbox id="txtH24"  runat="server" Width="50px" AutoPostBack="True" MaxLength="3" CssClass="form-control" style="Z-INDEX: 101; WIDTH: 50px; POSITION: absolute; TOP: -90px;left:100px"></asp:textbox> </div>
         <div class="col">
                  <asp:textbox id="txtH25"  runat="server"  Width="50px" AutoPostBack="True" MaxLength="3" CssClass="form-control" style="Z-INDEX: 101; WIDTH: 50px; POSITION: absolute; TOP: -90px;left:70px"></asp:textbox> </div>
         <div class="col">
                 <asp:textbox id="txtH26"  runat="server"  Width="50px" AutoPostBack="True" MaxLength="3" CssClass="form-control" style="Z-INDEX: 101; WIDTH: 50px; POSITION: absolute; TOP: -90px;left:50px"></asp:textbox > </div>
       </div>
    <div class="row"> 
        
        <div class="col">
                  <asp:textbox id="txtH31" runat="server"  Width="50px" AutoPostBack="True" MaxLength="3" CssClass="form-control" style="Z-INDEX: 101; WIDTH: 50px; POSITION: absolute; TOP: -50px;left:170px"></asp:textbox> 
         </div>
        
      <div class="col">
                 <asp:textbox id="txtH32" runat="server"  Width="50px" AutoPostBack="True" MaxLength="3" CssClass="form-control" style="Z-INDEX: 101; WIDTH: 50px; POSITION: absolute; TOP: -50px;left:140px"></asp:textbox> </div>
       <div class="col">
            <asp:textbox id="txtH33"  runat="server"  Width="50px" AutoPostBack="True" MaxLength="3" CssClass="form-control" style="Z-INDEX: 101; WIDTH: 50px; POSITION: absolute; TOP: -50px;left:130px"></asp:textbox> </div>
      <div class="col">
            <asp:textbox id="txtH34" runat="server"  Width="50px" AutoPostBack="True" MaxLength="3" CssClass="form-control" style="Z-INDEX: 101; WIDTH: 50px; POSITION: absolute; TOP: -50px;left:100px"></asp:textbox> </div>
      <div class="col">
             <asp:textbox id="txtH35"  runat="server"  Width="50px" AutoPostBack="True" MaxLength="3" CssClass="form-control" style="Z-INDEX: 101; WIDTH: 50px; POSITION: absolute; TOP: -50px;left:70px"></asp:textbox> 
        </div>
    <div class="col">
              <asp:textbox id="txtH36"  runat="server"  Width="50px" AutoPostBack="True" MaxLength="3" CssClass="form-control" style="Z-INDEX: 101; WIDTH: 50px; POSITION: absolute; TOP: -50px;left:50px"></asp:textbox>
         </div>
                    
      </div>
                 <br />
                <br />
                <br />
                           
			
                 <div class="row">
                      
                      <div class="col" align="center">
        <asp:button id="btnSave" runat="server" Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark" Text="Save"></asp:button>
  
                           </div>
                      </div>
                <br />
                </div></div>
           </div></div>
        </asp:Panel>
                </FORM>
           </div>
        </BODY>
        <div class="card-footer" style="text-align:right;background-color:#cccccc;vertical-align:middle;bottom:0;width:100%;height:60px"><h4 style="color: black;font-size:15px">MAINTAINED BY CRIS</h4></div>
</HTML>
