function SaleAmountPerDay(result) {
	var dataPoints = [];
	for (var i = 0; i < result.length; i++) {
		dataPoints.push({ x: new Date(result[i].Date), y: result[i].Amount });
	}
	var chart = new CanvasJS.Chart("chartContainerColumn", {
		animationEnabled: true,
		theme: "light2",
		title: {
			text: "Amount of sales per day"
		},
		axisY: {
			title: "Amount",
			gridThickness: 0,
		},
		axisX: {
			labelFormatter: function (e) {
				return CanvasJS.formatDate(e.value, "DD MMM");
			},
			labelTextAlign: "center",
		},
		data: [{
			type: "column",
			indexLabel: "{y}",
			indexLabelPlacement: "outside",
			dataPoints: dataPoints
		}]
	});
	chart.render();
}


function SaleRevenuePerDay(result, rate,symbol) {
	var dataPoints = [];

	if (rate === undefined) {
		for (var i = 0; i < result.length; i++) {
			dataPoints.push({ x: new Date(result[i].Date), y: (result[i].Amount) });
		}
	} else {
		for (var i = 0; i < result.length; i++) {
			dataPoints.push({ x: new Date(result[i].Date), y: (result[i].Amount * parseFloat(rate.replace(",", ".")).toFixed(1)) });
		}
    }

	var chart = new CanvasJS.Chart("chartContainerLine", {
		animationEnabled: true,
		theme: "light2",
		title: {
			text: "Revenue per day"
		},
		axisY: {
			title: "Revenue ("+symbol+")",
			gridThickness: 0,
		},
		axisX: {
			labelFormatter: function (e) {
				return CanvasJS.formatDate(e.value, "DD MMM");
			},
			labelTextAlign: "center",
		},
		data: [{
			type: "spline",
			indexLabel: "{y}",
			indexLabelPlacement: "outside",
			dataPoints: dataPoints
		}]
	});
	chart.render();
}
