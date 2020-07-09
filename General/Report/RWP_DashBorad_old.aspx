<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="RWP_DashBorad_old.aspx.vb" Inherits="WebApplication2.RWP_DashBorad_old" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
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

        <script src="js/Chart.min.js"></script>
 <title>Dashboard </title> 
	  
</head>
<body>
  <nav class="mb-1 navbar navbar-expand-sm bg-dark navbar-dark " >
  <a class="navbar-brand p-0" href="#"><img src="../../NewFolder1/unnamed.png" class="rounded-circle z-depth-0"  height="45"/> </a>
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
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../wapframeset.aspx">
          <i class="fab glyphicon glyphicon-home "style="font-size:30px;"></i>
        </a></li>

       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../logon.aspx">
          <i class="fab glyphicon glyphicon-log-out"style="font-size:30px;"></i>
        </a></li>
    
        <li class="nav-item ">
        <a class="nav-link p-0" href="#">
          <img src="../../NewFolder1/CRIS-Recruitment.jpg" class="rounded-circle z-depth-0"  height="45"/>
        </a>
      </li>
     </ul>
      
  </div>
</nav>  
  
    <main role="main">
     <section class=" text-center">
        <div class="container">
            
        <div class="row"> 
<div class="col-md-12">  <br /><br />
    <div style="float:left" >  <span style="font-weight:bold"> WHEEL CATEGORY :</span> <br /> 
        <a class="btn btn-primary btn-sm widgetsbox active " style="color:white" perd="WTA" id="WTA">WHELL ALLOTMENT
</a> 
        <a   class="btn btn-primary widgetsbox btn-sm " style="color:white" perd="WHD" id="WHD">WHEEL DESPATCH
 </a> 
        <a style="color:white"  class="btn btn-sm widgetsbox btn-primary" id="WHC" perd="WHC">WHEEL CASTING
 </a> </div>
		<br />
</div>
<div class="col-md-6"> 
    
     
    <div id="container" >
       <canvas id="chart1"></canvas>
	</div>
          </div>
<div class="col-md-6">
      <div id="container">
             <div style="float:left" >  <span style="font-weight:bold"> QUARTER :</span>  
        <a class="btn btn-primary btn-sm quarterbox active " style="color:white" perd="1" id="1">1st QUARTER
</a> 
        <a   class="btn btn-primary quarterbox btn-sm " style="color:white"   perd="2" id="2">2nd QUARTER
 </a> 
        <a style="color:white"  class="btn btn-sm quarterbox btn-primary"     id="3" perd="3">3rd QUARTER
 </a> 
                   <a style="color:white"  class="btn btn-sm quarterbox btn-primary" id="4" perd="4">4th QUARTER
 </a> 
             </div>
		<br />

		      <canvas id="chart2"></canvas>
	</div> 
</div>
            <div class="col-md-6"> 
      <%--<div style="float:left" >  <span style="font-weight:bold"> QUARTER DATA </span></div>--%>
    <br />
    <div id="container"  >
		<canvas id="chart3"></canvas>
	</div>
          </div>
             <div class="col-md-6"> 
      <%--<div style="float:left" >  <span style="font-weight:bold"> QUARTER DATA </span></div>--%>
    <br />
    <div id="container"  >
		<canvas id="chart4"></canvas>
	</div>
          </div>
             <div class="col-md-6"> 
      <%--<div style="float:left" >  <span style="font-weight:bold"> QUARTER DATA </span></div>--%>
    <br />
    <div id="container"  >
		<canvas id="chart5"></canvas>
	</div>
          </div>
            <div class="col-md-6"> 
      <%--<div style="float:left" >  <span style="font-weight:bold"> QUARTER DATA </span></div>--%>
    <br />
    <div id="container"  >
		<canvas id="chart6"></canvas>
	</div>
          </div>
             <div class="col-md-6"> 
      <%--<div style="float:left" >  <span style="font-weight:bold"> QUARTER DATA </span></div>--%>
    <br />
    <div id="container"  >
		<canvas id="chart7"></canvas>
	</div>
          </div>
               <div class="col-md-6"> 
      <%--<div style="float:left" >  <span style="font-weight:bold"> QUARTER DATA </span></div>--%>
    <br />
    <div id="container"  >
		<canvas id="chart8"></canvas>
	</div>
          </div>
        </div>
            
      </section>
        </main>

    <script type="text/javascript">
        var myChart1;
        var myChart2;
        var myChart3;
        var myChart4;
        var myChart5;
        var myChart6;
        var myChart7;
        var myChart8;
        var perd = 'WTA';
        var colors = ['#007bff','#ff1a1a', '#00e618', '#ff1a75', '#cc33ff'];

         var qtr_category = new Array();
        var type_category = new Array();

         var sum1 = new Array();
        var sum2 = new Array();
        var sum3 = new Array();

        var allotment = new Array();
        var dispatch = new Array();
        var cast = new Array();

        var boxn_bgc = new Array();
        var bgc = new Array();

        var off_heat_rejection = new Array();
        var mr_rejection = new Array();
        var mg_utr_rejection = new Array();
        var mach_rejection = new Array();
        var rejection_type_desc = new Array()


        $(document).ready(function() { 
	     
            ctx1 = document.getElementById('chart1').getContext('2d');
            ctx1.save(); 
           ctx2 = document.getElementById('chart2').getContext('2d');
            ctx2.save();
            ctx3 = document.getElementById('chart3').getContext('2d');
            ctx3.save();
            ctx4 = document.getElementById('chart4').getContext('2d');
            ctx4.save();
            ctx5 = document.getElementById('chart5').getContext('2d');
            ctx5.save();
            ctx6 = document.getElementById('chart6').getContext('2d');
            ctx6.save();
             ctx7 = document.getElementById('chart7').getContext('2d');
            ctx7.save();
            ctx8 = document.getElementById('chart8').getContext('2d');
            ctx8.save();
           category_type_year(1);
            quater_data_category(1);
            allot_dis();
            allot_cast();
            dis_cast();
            rejection();
            rejection_type();
            working_days_year();
		});

        $(".widgetsbox").click(function()
	      {
            var perd = $(this).attr("perd");

            $(".widgetsbox").removeClass("active");
          
		  switch (perd)		    {
              case 'WTA': 
                  
                  $("#WTA").addClass("active");
            category_type_year(1);                   
				 break;
              case 'WHD':
                 
                 $("#WHD").addClass("active");
				category_type_year(2);            
				 break;
            case 'WHC':    
                 $("#WHC").addClass("active");
             category_type_year(3);
				 break;		 
		}
        });
         $(".quarterbox").click(function()
	      {
            var perd = $(this).attr("perd");
            
            $(".quarterbox").removeClass("active");
          
		  switch (perd)		    {
            case '1':                 
                  $("#1").addClass("active");
            quater_data_category(1);                   
				 break;
			case '2':
                 $("#2").addClass("active");
				quater_data_category(2);            
				 break;
            case '3':    
                 $("#3").addClass("active");
             quater_data_category(3);
                  break;		 
              case '4':    
                 $("#4").addClass("active");
              quater_data_category(4);
				 break;
		}
        });

       
        
    var val = 1;
        function category_type_year(value) {
            //3 chart
              val = value;
            type_category = new Array();
          <% Dim periodType As Integer = 1
           dim category_year As Integer = fyear
          %>
            
            if (val == 1) {
                <%periodType = 1
          category_year =fyear
        %>  
               // alert(<%=periodType%>)
                
                 <%         
         wheel_allotment_year(category_year-1, periodType)
        For i = 0 To wheel_type.Count - 1%>  
         type_category.push('<%=wheel_type.Item(i)%>')        
       <% Next    
        %>
                if(myChart1) myChart1.destroy();
		ctx1.restore;
		myChart1 = new Chart(ctx1, {
			type: 'bar',
            data: {
                labels:type_category ,
				datasets:[ <% For category_year = category_year To category_year + endyear %>
                         {
                        label:  <%=category_year-1%> +"-"+<%=category_year%>  ,
                        backgroundColor: colors[<%=category_year-fyear%>],
                        borderColor: colors[<%=category_year-fyear%>],
                          borderWidth: 1,                           
                         <% wheel_allotment_year(category_year-1,periodType) %>                      

                    data: [<% For i = 0 To wheel_type_value.Count - 1%>         
                           <%=wheel_type_value.Item(i)%>,
                      <%Next%> 
                      ]
                    },
         <%   Next
        %>
				],

			},
			options:{
					responsive: true,
					legend: {
						position: 'top',
					},
					title: {
						display: true,
						text: 'YEAR WISE DATA OF WHEEL TYPE '
                },
                       scales: {
                           yAxes: [{
                               ticks: {
                                   beginAtZero: true
                               }
            }]
        }
				}
				
		});
	 
            }
            else if (val == 2) {
                 <%periodType = 2
         category_year =fyear %> 
              //  alert(<%=periodType%>)

               
                <%         
         wheel_dispatch_cast_year(category_year-1, periodType)
        For i = 0 To wheel_type.Count - 1%>  
         type_category.push('<%=wheel_type.Item(i)%>')        
       <% Next    
        %>

                if(myChart1) myChart1.destroy();
		ctx1.restore;
		myChart1 = new Chart(ctx1, {
			type: 'bar',
            data: {
                labels:type_category ,
				datasets:[ <% For category_year = category_year To category_year + endyear %>
                         {
                        label:  <%=category_year-1%> +"-"+<%=category_year%>  ,
                        backgroundColor: colors[<%=category_year-fyear%>],
                        borderColor: colors[<%=category_year-fyear%>],
                          borderWidth: 1,                           
                         <%wheel_dispatch_cast_year(category_year-1,periodType) %>                      

                    data: [<% For i = 0 To wheel_type_value.Count - 1%>         
                           <%=wheel_type_value.Item(i)%>,
                      <%Next%> 
                      ]
                    },
         <%   Next
        %>
				],

			},
			options:{
					responsive: true,
					legend: {
						position: 'top',
					},
					title: {
						display: true,
						text: 'YEAR WISE DATA OF WHEEL TYPE '
					}
				}
				
		});
	 
            }
             else {
              <%periodType = 3
        
            category_year =fyear %>
               // alert(<%=periodType%>)
               
                <%         
         wheel_dispatch_cast_year(category_year-1,periodType)
        For i = 0 To wheel_type.Count - 1%>  
         type_category.push('<%=wheel_type.Item(i)%>')        
       <% Next    
        %>

                if(myChart1) myChart1.destroy();
		ctx1.restore;
		myChart1 = new Chart(ctx1, {
			type: 'bar',
            data: {
                labels:type_category ,
				datasets:[ <% For category_year = category_year To category_year + endyear %>
                         {
                        label:<%=category_year-1%> +"-"+<%=category_year%>  ,
                        backgroundColor: colors[<%=category_year-fyear%>],
                        borderColor: colors[<%=category_year-fyear%>],
                          borderWidth: 1,                           
                         <% wheel_dispatch_cast_year(category_year-1,periodType) %>                      

                    data: [<% For i = 0 To wheel_type_value.Count - 1%>         
                           <%=wheel_type_value.Item(i)%>,
                      <%Next%> 
                      ]
                    },
         <%   Next
        %>
				],

			},
			options:{
					responsive: true,
					legend: {
						position: 'top',
					},
					title: {
						display: true,
						text: 'YEAR WISE DATA OF WHEEL TYPE'
					}
				}
				
		});
	 
            }

           
        }

        

		
        <%--function quarter_data(value) {
            if(myChart2) myChart2.destroy();
		ctx2.restore;
		myChart2 = new Chart(ctx2, {
				type: 'bar',
            data: {
                labels: month_category,
				
				datasets:[ 
                    <% For myear = myear To myear+endyear %>
                      {
                        label: <%=myear-1%> +"-"+<%=myear%> ,
                        backgroundColor: colors[<%=myear-fyear%>],
                        borderColor: colors[<%=myear-fyear%>],
                          borderWidth: 1,
                         fill: false,

                         <% get_month_wise(myear-1) %>  

                    data: [<% For i = 0 To month_value.Count - 1%>         
                           <%=month_value.Item(i)%>,
                      <%Next%> 
                      ]
                    },
         <%   Next
        %>
				],
				 

			},
			options:{
					responsive: true,
					legend: {
						position: 'top',
					},
					title: {
						display: true,
						text: 'MONTHLY WISE OF WHEEL PRODUCTION'
                },
                    
					tooltips: {
						mode: 'index',
						intersect: false
					},
					responsive: true,
					scales: {
						xAxes: [{
							stacked: true,
						}],
						yAxes: [{
							stacked: true
						}]
					}
				}
				
		});
 }--%>


         function quater_data_category(value) {   
            val = value;

           
            
               <% Dim category_type As Integer = 1
                  dim qua_year As Integer = fyear
            
                %>      
              

              <% category_type = 1
                 qua_year =fyear
                %>    
            if (val == 1) {
                sum1 = new Array();
                sum2 = new Array();
                sum3 = new Array();
                type_category = new Array(); 
                   <% 
        
        wheel_data_quarter(1)
        
         For i = 0 To quarter_wise_wheel_category_wise.Count - 1%>   
            type_category.push('<%=quarter_wise_wheel_category_wise.Item(i)%>'); 
            sum1.push(<%=quarter_wise_wheel_category_value1.Item(i)%>)
            sum2.push(<%=quarter_wise_wheel_category_value2.Item(i)%>)
            sum3.push(<%=quarter_wise_wheel_category_value3.Item(i)%>)
                      <%Next%> 
            }
            else if (val == 2) {                
                 sum1 = new Array();
                sum2 = new Array();
                sum3 = new Array();
                type_category = new Array(); 
                   <% 
          
        wheel_data_quarter(2)
        
         For i = 0 To quarter_wise_wheel_category_wise.Count - 1%>   
            type_category.push('<%=quarter_wise_wheel_category_wise.Item(i)%>'); 
            sum1.push(<%=quarter_wise_wheel_category_value1.Item(i)%>)
            sum2.push(<%=quarter_wise_wheel_category_value2.Item(i)%>)
            sum3.push(<%=quarter_wise_wheel_category_value3.Item(i)%>)
                      <%Next%> 
            }
            else if (val == 3) {                
                 sum1 = new Array();
                sum2 = new Array();
                sum3 = new Array();
                type_category = new Array(); 
                   <% 
      
        wheel_data_quarter(3)       
            For i = 0 To quarter_wise_wheel_category_wise.Count - 1%>   
            type_category.push('<%=quarter_wise_wheel_category_wise.Item(i)%>'); 
            sum1.push(<%=quarter_wise_wheel_category_value1.Item(i)%>)
            sum2.push(<%=quarter_wise_wheel_category_value2.Item(i)%>)
            sum3.push(<%=quarter_wise_wheel_category_value3.Item(i)%>)
                      <%Next%> 
            }
            else{                
                sum1 = new Array();
                sum2 = new Array();
                sum3 = new Array();
                type_category = new Array(); 

                <% 
        
        wheel_data_quarter(4)        
         For i = 0 To quarter_wise_wheel_category_wise.Count - 1%>   
            type_category.push('<%=quarter_wise_wheel_category_wise.Item(i)%>'); 
            sum1.push(<%=quarter_wise_wheel_category_value1.Item(i)%>)
            sum2.push(<%=quarter_wise_wheel_category_value2.Item(i)%>)
            sum3.push(<%=quarter_wise_wheel_category_value3.Item(i)%>)

                      <%Next%> 
                }

            //alert(sum3)

         if(myChart2) myChart2.destroy();
		ctx2.restore;
		myChart2 = new Chart(ctx2, {
			type: 'line',
            data: {
                labels:type_category ,
                datasets: [ 
                         {
                        label:  "WHEEL ALLOTMENT"  ,
                     // backgroundColor: colors[0],
                        borderColor: colors[0],
                        borderWidth: 1,  
                       fill: false,
                      data:sum1
                    },
                     {
                        label:  "WHEEL DISPATCH" ,
                  // backgroundColor: colors[1],
                        borderColor: colors[1],
                         borderWidth: 1, 
                      fill: false,
                      data:sum2
                    },
              {
                        label: "WHEEL CASTING"  ,
                      // backgroundColor: colors[2],
                        borderColor: colors[2],
                     borderWidth: 1,
                       fill: false,
                      data:sum3
                    },
				],

			},
			options:{
					responsive: true,
					legend: {
						position: 'top',
					},
					title: {
						display: true,
						text: 'COMPARISION OF QUARTER WISE  OF WHEEL CATEGORY '
					}
				}
				
		});
	 
            } 
     
       function allot_dis() {
            allotment = new Array();
            dispatch = new Array();
            type_category = new Array();
                 <% 
                  dim years As Integer = fyear
            
                %>      
              <% 
                 years =fyear
                %>  
           // years =fyear
           // alert("ALLOTMENT")
         
            
           // alert(<%=quarter_wise_wheel_category_wise.Count%>)
           // alert(allotment.values(0))


           

           <% For years = years To years + endyear %>
           <% allotment_dispatch(years-1) %>  
           
           <% For i = 0 To wheel_allotment.Count - 1%> 
           type_category.push('<%=years-1%>-<%=years%>');
           allotment.push(<%=wheel_allotment.Item(i)%>)
           dispatch.push(<%=wheel_dispatch.Item(i)%>)
                      <%Next%> 

                <%   Next
        %>
         
         if(myChart3) myChart3.destroy();
		ctx3.restore;
		myChart3 = new Chart(ctx3, {
			type: 'line',
            data: {
                labels: type_category,
                datasets:[ 
                         {
                        label:  "WHEEL ALLOTMENT"   ,
                        backgroundColor: colors[0],
                        borderColor: colors[0],
                        borderWidth: 1,                           
                        fill: false,              

                    data: allotment 
                       
                    },
                    {
                        label:  "WHEEL DISPATCH"   ,
                        backgroundColor: colors[1],
                        borderColor: colors[1],
                        borderWidth: 1,                           
                         fill: false,                  

                        data: dispatch
                    },
        
				],

                

			},
			options:{
					responsive: true,
					legend: {
						position: 'top',
                },
                     scales: {
                           yAxes: [{
                               ticks: {
                                   beginAtZero: true
                               }
            }]
        },
					title: {
						display: true,
						text: 'COMPARISION OF ALLOTMENT AND DISPATCH OF WHEEL'
					}
				}
				
		});
	 }
        function allot_cast() {
            allotment = new Array();
            cast = new Array();
            type_category = new Array();     
              <% 
                 years =fyear
                %>  
           // years =fyear
          //  alert("ALLOTMENT")
         
          
           // alert(<%=quarter_wise_wheel_category_wise.Count%>)
           // alert(allotment.values(0))





           <% For years = years To years + endyear %>
           <% allotment_cast(years-1) %>   
           <% For i = 0 To wheel_allotment.Count - 1%> 
            type_category.push('<%=years-1%>-<%=years%>');
           allotment.push(<%=wheel_allotment.Item(i)%>)
           cast.push(<%=wheel_cast.Item(i)%>)
                      <%Next%> 

                <%   Next
        %>
         
         if(myChart4) myChart4.destroy();
		ctx4.restore;
		myChart4 = new Chart(ctx4, {
			type: 'line',
            data: {
                labels: type_category,
                datasets:[ 
                         {
                        label:  "WHEEL ALLOTMENT"   ,
                        backgroundColor: colors[0],
                        borderColor: colors[0],
                        borderWidth: 1,                           
                        fill: false,              

                    data: allotment 
                       
                    },
                    {
                        label:  "WHEEL CAST"   ,
                        backgroundColor: colors[1],
                        borderColor: colors[1],
                        borderWidth: 1,                           
                         fill: false,                  

                        data: cast
                    },
        
				],

                

			},
			options:{
					responsive: true,
					legend: {
						position: 'top',
                },
                     scales: {
                           yAxes: [{
                               ticks: {
                                   beginAtZero: true
                               }
            }]
        },
					title: {
						display: true,
						text: 'COMPARISION OF ALLOTMENT AND CAST OF WHEEL'
					}
				}
				
		});
        }

          function dis_cast() {
            dispatch = new Array();
            cast = new Array();
            type_category = new Array();     
              <% 
                 years =fyear
                %>  
           // years =fyear
          //  alert("ALLOTMENT")
         
          
           // alert(<%=quarter_wise_wheel_category_wise.Count%>)
           // alert(allotment.values(0))





           <% For years = years To years + endyear %>
           <% dispatch_cast(years-1) %>   
           <% For i = 0 To wheel_allotment.Count - 1%> 
            type_category.push('<%=years-1%>-<%=years%>');
           dispatch.push(<%=wheel_dispatch.Item(i)%>)
           cast.push(<%=wheel_cast.Item(i)%>)
                      <%Next%> 

                <%   Next
        %>
         
         if(myChart5) myChart5.destroy();
		ctx5.restore;
		myChart5 = new Chart(ctx5, {
			type: 'bar',
            data: {
                labels: type_category,
                datasets:[ 
                         {
                        label:  "WHEEL DISPATCH"   ,
                        backgroundColor: colors[0],
                        borderColor: colors[0],
                        borderWidth: 1,                           
                        fill: false,              

                    data: dispatch 
                       
                    },
                    {
                        label:  "WHEEL CAST"   ,
                        backgroundColor: colors[1],
                        borderColor: colors[1],
                        borderWidth: 1,                           
                         fill: false,                  

                        data: cast
                    },
        
				],

                

			},
			options:{
					responsive: true,
					legend: {
						position: 'top',
                },
                     scales: {
                           yAxes: [{
                               ticks: {
                                   beginAtZero: true
                               }
            }]
        },
					title: {
						display: true,
						text: 'COMPARISION OF DISPATCH AND CAST OF WHEEL'
					}
				}
				
		});
	 }

        function rejection() {
            boxn_bgc = new Array();
            bgc = new Array();
            type_category = new Array();     
              <% 
                 years =fyear
                %>  

           <% reject() %>   
           <% For i = 0 To wheel_year.Count - 1%> 
            type_category.push('<%=wheel_year.Item(i)%>');
           boxn_bgc.push(<%=boxn_bgc_reject.Item(i)%>)
           bgc.push(<%=bgc_reject.Item(i)%>)
                      <%Next%> 
         if(myChart6) myChart6.destroy();
		ctx6.restore;
		myChart6 = new Chart(ctx6, {
			type: 'bar',
            data: {
                labels: type_category,
                datasets:[ 
                         {
                        label:  "BOXN AND BGC"   ,
                        backgroundColor: colors[0],
                        borderColor: colors[0],
                        borderWidth: 1,                           
                        fill: false,              

                    data: boxn_bgc 
                       
                    },
                    {
                        label:  "BGC"   ,
                        backgroundColor: colors[1],
                        borderColor: colors[1],
                        borderWidth: 1,                           
                         fill: false,                  

                        data: bgc
                    },
        
				],

                

			},
			options:{
					responsive: true,
					legend: {
						position: 'top',
                },
                     scales: {
                           xAxes: [{
                               ticks: {
                                   beginAtZero: true
                               }
                         }],
                         yAxes: [{
                                    ticks: {
                                   beginAtZero: true,
                                   callback: function(value){return value+ "%"}
                               },
                               scaleLabel: {
                   display: true,
                   labelString: "Percentage"
                }
            }]

        },
					title: {
						display: true,
						text: 'REJECTION OF WHEELS'
					}
				}
				
		});
	 }
        function rejection_type() {
            off_heat_rejection = new Array();
            mr_rejection = new Array();
            mg_utr_rejection = new Array();
            mach_rejection = new Array();
           
            type_category = new Array();
              <% 
                 years =fyear
                %>  

           <% reject_type() %>   
           <% For i = 0 To wheel_year.Count - 1%> 
            type_category.push('<%=wheel_year.Item(i)%>');
           off_heat_rejection.push(<%=off_heat_reject.Item(i)%>)
            mr_rejection.push(<%=mr_reject.Item(i)%>)
            mg_utr_rejection.push(<%=mg_utr_reject.Item(i)%>)
            mach_rejection.push(<%=mach_reject.Item(i)%>)
           
          
                      <%Next%> 
         if(myChart7) myChart7.destroy();
		ctx7.restore;
		myChart7 = new Chart(ctx7, {
			type: 'line',
            data: {
                labels: type_category,
                datasets:[ 
                         {
                        label:  "Off-Heats"   ,
                        backgroundColor: colors[0],
                        borderColor: colors[0],
                        borderWidth: 1,                           
                        fill: false,              

                    data: off_heat_rejection 
                       
                    },
                    {
                        label:  "Mould Room Rejection"   ,
                        backgroundColor: colors[1],
                        borderColor: colors[1],
                        borderWidth: 1,                           
                         fill: false,                  

                        data: mr_rejection
                    },
                      {
                        label:  "Magna Glow and UT Rejection"   ,
                        backgroundColor: colors[2],
                        borderColor: colors[2],
                        borderWidth: 1,                           
                         fill: false,                  

                        data: mg_utr_rejection
                    },
                        {
                        label:  "Proportionate Rejections for wheels requiring Machining"   ,
                        backgroundColor: colors[4],
                        borderColor: colors[4],
                        borderWidth: 1,                           
                         fill: false,                  

                        data: mach_rejection
                    }
        
				],

                

			},
			options:{
					responsive: true,
					legend: {
						position: 'top',
                },
                     scales: {
                           xAxes: [{
                               ticks: {
                                   beginAtZero: true
                               }
                         }],
                         yAxes: [{
                                    ticks: {
                                   beginAtZero: true,
                                   callback: function(value){return value+ "%"}
                               },
                               scaleLabel: {
                   display: true,
                   labelString: "Percentage"
                }
            }]

        },
					title: {
						display: true,
						text: 'REJECTION OF WHEELS'
					}
				}
				
		});
        }
         function working_days_year() {
            //4 chart
              type_category = new Array();
               <%  dim working_year As Integer = fyear%>             
              var working_year =(new Date()).getFullYear();          
              type_category.push(working_year-1+ "-" + working_year);       
        
          if(myChart8) myChart8.destroy();
		ctx8.restore;
		myChart8 = new Chart(ctx8, {
			type: 'horizontalBar',
            data: {
                labels:type_category ,
				datasets:[  
                        {
                        label: 'Till Date' ,
                        backgroundColor: colors[2],
                        borderColor: colors[2],
                          borderWidth: 1,
                    data: [        
                           <%=wdays_tilldate%>               
                          ]
                    },
                     {
                        label: 'Total working day' ,
                        backgroundColor: colors[4],
                        borderColor: colors[4],
                          borderWidth: 1,
                        data: [         
                         <%=wdays_year%>                      
                      ]
                    },
				],

			},
			options:{
					responsive: true,
					legend: {
						position: 'top',
                },
                    scales: {
                           xAxes: [{
                               ticks: {
                                   beginAtZero: true
                               }
            }]
        },
					title: {
						display: true,
						text: 'Working Days '
					}
				}
				
		});
	       

        }


      </script> 

    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>



    <form id="form1" runat="server">
        <div>
        </div>
    </form>
</body>
</html>
