// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// Set new default font family and font color to mimic Bootstrap's default styling
Chart.defaults.global.defaultFontFamily = 'Nunito', '-apple-system,system-ui,BlinkMacSystemFont,"Segoe UI",Roboto,"Helvetica Neue",Arial,sans-serif';
Chart.defaults.global.defaultFontColor = '#858796';

function number_format(number, decimals, dec_point, thousands_sep) {
    // *     example: number_format(1234.56, 2, ',', ' ');
    // *     return: '1 234,56'
    number = (number + '').replace(',', '').replace(' ', '');
    var n = !isFinite(+number) ? 0 : +number,
        prec = !isFinite(+decimals) ? 0 : Math.abs(decimals),
        sep = (typeof thousands_sep === 'undefined') ? ',' : thousands_sep,
        dec = (typeof dec_point === 'undefined') ? '.' : dec_point,
        s = '',
        toFixedFix = function (n, prec) {
            var k = Math.pow(10, prec);
            return '' + Math.round(n * k) / k;
        };
    // Fix for IE parseFloat(0.55).toFixed(0) = 0;
    s = (prec ? toFixedFix(n, prec) : '' + Math.round(n)).split('.');
    if (s[0].length > 3) {
        s[0] = s[0].replace(/\B(?=(?:\d{3})+(?!\d))/g, sep);
    }
    if ((s[1] || '').length < prec) {
        s[1] = s[1] || '';
        s[1] += new Array(prec - s[1].length + 1).join('0');
    }
    return s.join(dec);
}

// Area Chart Example
var ctx1 = document.getElementById("myAreaChart");
function createChart(dataset) {
    var myLineChart = new Chart(ctx1, {
        type: 'line',
        data: {
            labels: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"],
            datasets: [{
                label: "Earnings",
                lineTension: 0.3,
                backgroundColor: "rgba(78, 115, 223, 0.05)",
                borderColor: "rgba(78, 115, 223, 1)",
                pointRadius: 3,
                pointBackgroundColor: "rgba(78, 115, 223, 1)",
                pointBorderColor: "rgba(78, 115, 223, 1)",
                pointHoverRadius: 3,
                pointHoverBackgroundColor: "rgba(78, 115, 223, 1)",
                pointHoverBorderColor: "rgba(78, 115, 223, 1)",
                pointHitRadius: 10,
                pointBorderWidth: 2,
                data: dataset,
            }],
        },
        options: {
            maintainAspectRatio: false,
            layout: {
                padding: {
                    left: 10,
                    right: 25,
                    top: 25,
                    bottom: 0
                }
            },
            scales: {
                xAxes: [{
                    time: {
                        unit: 'date'
                    },
                    gridLines: {
                        display: false,
                        drawBorder: false
                    },
                    ticks: {
                        maxTicksLimit: 7
                    }
                }],
                yAxes: [{
                    ticks: {
                        maxTicksLimit: 5,
                        padding: 10,
                        // Include a dollar sign in the ticks
                        callback: function (value, index, values) {
                            return '$' + number_format(value);
                        }
                    },
                    gridLines: {
                        color: "rgb(234, 236, 244)",
                        zeroLineColor: "rgb(234, 236, 244)",
                        drawBorder: false,
                        borderDash: [2],
                        zeroLineBorderDash: [2]
                    }
                }],
            },
            legend: {
                display: false
            },
            tooltips: {
                backgroundColor: "rgb(255,255,255)",
                bodyFontColor: "#858796",
                titleMarginBottom: 10,
                titleFontColor: '#6e707e',
                titleFontSize: 14,
                borderColor: '#dddfeb',
                borderWidth: 1,
                xPadding: 15,
                yPadding: 15,
                displayColors: false,
                intersect: false,
                mode: 'index',
                caretPadding: 10,
                callbacks: {
                    label: function (tooltipItem, chart) {
                        var datasetLabel = chart.datasets[tooltipItem.datasetIndex].label || '';
                        return datasetLabel + ': $' + number_format(tooltipItem.yLabel);
                    }
                }
            }
        }
    });
}
// Set new default font family and font color to mimic Bootstrap's default styling
Chart.defaults.global.defaultFontFamily = 'Nunito', '-apple-system,system-ui,BlinkMacSystemFont,"Segoe UI",Roboto,"Helvetica Neue",Arial,sans-serif';
Chart.defaults.global.defaultFontColor = '#858796';

// Pie Chart Example
var ctx = document.getElementById("myPieChart");
var myPieChart = new Chart(ctx, {
    type: 'doughnut',
    data: {
        labels: ["Rent", "Internet", "Electricity", "Garbage", "Car Insurance", "Food", "Gas", "Phone"],
        datasets: [{
            data: [350, 100, 150, 30, 100, 150, 80, 80],
            backgroundColor: ['#4e73df', '#1cc88a', '#36b9cc', '#F700FF', '#333555', '#FF0000', '#FBFF00', '#FFC300'],
            hoverBackgroundColor: ['#2e59d9', '#17a673', '#2c9faf'],
            hoverBorderColor: "rgba(234, 236, 244, 1)",
        }],
    },
    options: {
        maintainAspectRatio: false,
        tooltips: {
            backgroundColor: "rgb(255,255,255)",
            bodyFontColor: "#858796",
            borderColor: '#dddfeb',
            borderWidth: 1,
            xPadding: 15,
            yPadding: 15,
            displayColors: false,
            caretPadding: 10,
        },
        legend: {
            display: false
        },
        cutoutPercentage: 80,
    },
});
console.log("test");
//const form = document.getElementById("incomeInfo");
//const formData = new FormData(form);
//formData.get("Month");
//formData.get("Income");

function addData(chart) {
    const Month = document.getElementById('Month');
    const Income = document.getElementById('Income');
    console.log(Month.value);
    console.log(Income.value);
    fetch(`/Chart/Edit?month=${Month.value}&income=${Income.value}`, {
        method: "POST",
        //body: JSON.stringify({ month: "1", income: "20" }),
        headers: {
            'Content-Type': 'application/json',
        }

    }).then(data => {
        myLineChart.data.datasets[0].data.push(Income.value);

        myLineChart.update();

    })

}
function removeData(chart) {
    console.log(Income)
    const str = chart.data.datasets[0].data.dataset;
    const arr = [...str.match(/\d+/g)];
    console.log(arr)
    console.log(chart.data.datasets[0].data.dataset);

    myLineChart.update();
}
function addData2(chart) {
    const Category = document.getElementById('Category');
    const Amount = document.getElementById('Amount');
    console.log(Category.value);
    console.log(Amount.value);
    myPieChart.data.labels.push(Category.value);
    myPieChart.data.datasets[0].data.push(Amount.value);


    myPieChart.update();
}
function removeData2(chart) {
    console.log(Income)
    myPieChart.data.datasets[0].data.pop();

    myPieChart.update();
}

function myFunction(name) {
    document.getElementById("ChangeGoal1").innerHTML = "Welcome " + name;
}
function totalBudget(chart) {
    let sum = 0;
    let i = 0;
    while (myPieChart.data.datasets[0].data[i] != null) {
        sum += myPieChart.data.datasets[0].data[i];
        i++;
    }
    console.log(sum);
    return sum;
}
let newSum = totalBudget(myPieChart);
document.getElementById('test1').textContent = newSum; 
//}
//function totalBudget(chart) {
//    let sum = 0;
//    let i = 0;
//    while (myPieChart.data.datasets[0].data[i] != null) {
//        sum += myPieChart.data.datasets[0].data[i];
//        i++;
//    }
//    console.log(sum);
//    return sum;
//}
//let newSum = totalBudget(myPieChart);
//document.getElementById('test1').textContent = newSum;