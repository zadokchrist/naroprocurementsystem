// JavaScript Document
$(document).ready(function (e) {

    if($(".gis").val()=="yes")
    {
        locationPicker();
        getMap();
    }


    $("#statement").dataTable();
    $(".btn_survey").click(function (e) {
       // materialAlert("Are you sure", "This will not be edited", null);

    });
    startGraph();
    BillingGraph();
  
    tabFrozenScroll("#mainTable", ".nav.nav-tabs", 0);
  
    //$('#verticalTab').jqTabs();
    //alert("okay");
    /*
    $(".fullname").keyup(function (e) {
        getData();
    });
    $('.tooltipman').tooltip();
    $(".remove").keyup(function (e) {
        $.confirm({
            title: 'Confirm!',
            content: 'Confirm Now',
            buttons: {
                Confirm: function () {
                    return
                },
                Cancel: function () {
                    e.preventDefault();
                }

            }
        });
    });
       */   
	
});		

function startGraph() {
    var labelvalues = Array();
    var serieslabel = Array();

   // var labelvalues2 = Array();
   // var serieslabel2 = Array();
    var freejson = $(".json").val();
	 $.ajax({
            url: 'Ajax.aspx',
            type: 'POST',
            data: {cmd:'getCollection',entity:'0'},
			dataType: 'text',
            success: function (res) {
                //alert(res);
				var json = JSON.parse(res);
				//json = Json.parse(freejson);
                /*
				var statusjson = JSON.parse(json.status);
				var categoryjson = JSON.parse(json.category);
                */
				 var c = 0;
				 $.each(json, function (key, data) {
                    labelvalues[c] = data.ZoneCode;
                    serieslabel[c] = data.Amount;
                    //alert(data.ZoneCode);
                     c++;    
				 });
                /*
				 $.each(categoryjson, function (key, data) {
				     labelvalues2[c] = data.Category;
				     serieslabel2[c] = data.Total;
				     c++;
				 });
                 */
				 var ctx = $("#collectionbar");
                    Plot(ctx, labelvalues, serieslabel, "Bar Graph", "bar");
                    Plot($("#collectionline"), labelvalues, serieslabel, "Line Chart", "line");
                    //plotPie($("#callsline"), labelvalues, serieslabel, "Pie Chart", "doughnut");
                    //Plot($("#catstats"), labelvalues2, serieslabel2, "Bar Graph Category", "bar");

            }
        });
    	
}
function BillingGraph() {
    var labelvalues = Array();
    var serieslabel = Array();

    // var labelvalues2 = Array();
    // var serieslabel2 = Array();
    var freejson = $(".json").val();
  
    var json = JSON.parse(freejson);
           
            var c = 0;
            $.each(json, function (key, data) {
                labelvalues[c] = data.ZoneCode;
                serieslabel[c] = data.Amount;
                //alert(data.ZoneCode);
                c++;
            });
            /*
             $.each(categoryjson, function (key, data) {
                 labelvalues2[c] = data.Category;
                 serieslabel2[c] = data.Total;
                 c++;
             });
             */
            var ctx = $("#billingbar");
            Plot(ctx, labelvalues, serieslabel, "Bar Graph", "bar");
            Plot($("#billingline"), labelvalues, serieslabel, "Line Chart", "line");
            //plotPie($("#callsline"), labelvalues, serieslabel, "Pie Chart", "doughnut");
            //Plot($("#catstats"), labelvalues2, serieslabel2, "Bar Graph Category", "bar");


}


function Plot(ctx,labelvalues,serieslabel,title,type)
{
    var myChart = new Chart(ctx, {
        type: type,
        data: {
            labels: labelvalues,
            datasets: [{
                label: title,
                data: serieslabel,
                backgroundColor: ['#388E3C','#1976D2','#FFA000'
                ],
                borderColor: [
                    'rgba(255,99,132,1)',
                    'rgba(54, 162, 235, 1)',
                    'rgba(255, 206, 86, 1)',
                    'rgba(75, 192, 192, 1)',
                    'rgba(153, 102, 255, 1)',
                    'rgba(255, 159, 64, 1)'
                ],
                borderWidth: 1
            }]
        },
        options: {
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
//plot pie
function plotPie(ctx,labelvalues,serieslabel,txtName,type)
{
    var myChart = new Chart(ctx, {
        type: type,
        data: {
            labels: labelvalues,
            datasets: [{
                label: txtName,
                data: serieslabel,
                backgroundColor: ['#C2185B','#03A9F4','#5D4037'
                ],
                borderColor: [
                    'rgba(255,99,132,1)',
                    'rgba(54, 162, 235, 1)',
                    'rgba(255, 206, 86, 1)',
                    'rgba(75, 192, 192, 1)',
                    'rgba(153, 102, 255, 1)',
                    'rgba(255, 159, 64, 1)'
                ],
                borderWidth: 1
            }]
        },
        
    });
	
}
//three tire
function plotTWOSERIES(ctx, data1, data2, labelvalues, label1, label2, title) {

    var myChart = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: labelvalues,
            datasets: [
              {
                  label: label1,
                  fill: false,
                  lineTension: 0.1,
                  backgroundColor:
                  ["#2196F3", "#388E3C", "#00796B", "#C2185B", "#E64A19", "#D32F2F", "#689F38", "#3F51B5"],
                  borderColor: "rgba(75,192,192,1)",
                  borderCapStyle: 'butt',
                  borderDash: [],
                  borderDashOffset: 0.0,
                  borderJoinStyle: 'miter',
                  pointBorderColor: "rgba(75,192,192,1)",
                  pointBackgroundColor: "#fff",
                  pointBorderWidth: 1,
                  pointHoverRadius: 5,
                  //pointHoverBackgroundColor: ["#0097A7","#795548","#9C27B0","#0097A7"],
                  pointHoverBorderColor: "rgba(220,220,220,1)",
                  pointHoverBorderWidth: 2,
                  pointRadius: 1,
                  pointHitRadius: 10,
                  data: data1,
                  spanGaps: false,
                  borderWidth: 0
              },
              {
                  label: label2,
                  fill: false,
                  lineTension: 0.1,
                  backgroundColor:
                  ["#388E3C", "#C2185B", "#D32F2F", "#F57C00", "#E64A19", "#D32F2F", "#689F38", "#3F51B5"],
                  borderColor: "rgba(75,192,192,1)",
                  borderCapStyle: 'butt',
                  borderDash: [],
                  borderDashOffset: 0.0,
                  borderJoinStyle: 'miter',
                  pointBorderColor: "rgba(75,192,192,1)",
                  pointBackgroundColor: "#fff",
                  pointBorderWidth: 1,
                  pointHoverRadius: 5,
                  //pointHoverBackgroundColor: ["#0097A7","#795548","#9C27B0","#0097A7"],
                  pointHoverBorderColor: "rgba(220,220,220,1)",
                  pointHoverBorderWidth: 2,
                  pointRadius: 1,
                  pointHitRadius: 10,
                  data: data2,
                  spanGaps: false,
                  borderWidth: 0
              }
            ]

        },
        options: {
            legend: {
                display: true,
                labels: {
                    fontColor: '#1976D2'
                }
            },
            title: {
                display: true,
                text: title
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
function getData() {
    var fullname = $(".fullname").val();
   
    $.ajax({
        url: 'Ajax.aspx',
        type: 'POST',
        data: { text: fullname, cmd:"filter" },
        success: function (res) {
            var json = JSON.parse(res);
            var total = json.total;
            var value = json.value;
            $(".displaytv").html(total);
            $(".tooltipman").html(value);
            $(".tooltipman").attr("title",value);
        }
    });
   

}

// JavaScript Document


