function attachEvents() {
	$('#submit').on('click', getWeather);
	
	function getWeather() {
		let city = $('#location').val();
		
		$.ajax({
			method: 'GET',
			url: 'https://judgetests.firebaseio.com/locations.json',
		}).then(handleLocations);
		
		function handleLocations(res) {
			let rightObject = res.find((element) => element.name === city);
			let code = rightObject.code;
			
			let weatherToday = $.ajax({
				method: 'GET',
				url: `https://judgetests.firebaseio.com/forecast/today/${code}.json`
			});
			
			let upcomingWeather = $.ajax({
				method: 'GET',
				url: `https://judgetests.firebaseio.com/forecast/upcoming/${code}.json`
			});
			
			Promise.all([weatherToday, upcomingWeather]).then(displayWeather).catch(displayError);
			
			function displayWeather([today, upcoming]){
				let currentDiv = $('#current');
				currentDiv.empty().append('<div class="label">Current conditions</div>');
				let forecast = $('#forecast');
				forecast.show();
				
				let todayForecast = today['forecast'];
				let upcomingForecasts = upcoming.forecast;
				
				let mainSpan = $('<span class="condition">');
				
				let locationNameSpan = generateForecastData(today.name);
				let temperatureSpan = $('<span class="forecast-data">').html(todayForecast.low + '&#176;' + '/' + todayForecast.high + '&#176;')
				let todayConditionSpan = generateForecastData(todayForecast.condition);
				
				let todaySymbol = getSymbol(todayForecast.condition);
				let symbolSpan = $(`<span class="condition symbol">`).html(todaySymbol);
				
				mainSpan.append(locationNameSpan);
				mainSpan.append(temperatureSpan);
				mainSpan.append(todayConditionSpan);
				
				currentDiv.append(symbolSpan);
				currentDiv.append(mainSpan);
				
				let upcomingDiv = $('#upcoming');
				upcomingDiv.empty().append('<div class="label">Three-day forecast</div>');
				for (let upcomingForecast of upcomingForecasts) {
					let upcomingSpan = $('<span class="upcoming">');
					
					let uptemperatureSpan = $('<span class="forecast-data">').html(upcomingForecast.low + '&#176;' + '/' + upcomingForecast.high + '&#176;')
					let upConditionSpan = generateForecastData(upcomingForecast.condition);
					
					let upSymbol = getSymbol(upcomingForecast.condition);
					let upsymbolSpan = $(`<span class="symbol">`).html(upSymbol);
					
					upcomingSpan.append(upsymbolSpan);
					upcomingSpan.append(uptemperatureSpan);
					upcomingSpan.append(upConditionSpan);
					
					upcomingDiv.append(upcomingSpan);
				}
				
			}
			
			function displayError(res) {
				//idk
			}
		}
	}
	
	function getSymbol(condition) {
		if(condition === 'Sunny'){
			return '&#x2600;'
		}else if(condition === 'Partly sunny'){
			return '&#x26C5';
		}else if(condition === 'Overcast'){
			return '&#x2601;'
		}else if(condition === 'Rain'){
			return '&#x2614;'
		}else if(condition === 'Degrees'){
			return '&#176;';
		}	
	}
	
	function generateForecastData(string) {
		return $('<span class="forecast-data">').text(string);
	}
}