function getInfo() {
	let url = "https://judgetests.firebaseio.com/businfo/";
	
	let stopId = $('#stopId').val();
	
	$.ajax({
		method: 'GET',
		url: url + stopId + '.json'
	}).then(success).catch(error);
	
	function success(data) {
		let stopName = data['name'];
		let stopBuses = data['buses'];
		
		for (let busId in stopBuses) {
			let li = $(`<li>Bus ${busId} arrives in ${stopBuses[busId]} minutes</li>`);
			$('#buses').append(li);
		}
		
		$('#stopName').text(stopName);
	}
	
	function error(data) {
		$('#stopName').text('Error');
	}
}