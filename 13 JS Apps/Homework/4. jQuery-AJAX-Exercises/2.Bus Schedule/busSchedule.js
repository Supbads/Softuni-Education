function solve() {
	let url = 'https://judgetests.firebaseio.com/schedule/';
	let initialStopId = 'depot';
	
	let isInitialStop = true;
	let currentStop;
	let currentStopId;
	let nextStopId;
	
	function depart() {
		currentStopId = nextStopId;
		
		if(isInitialStop){
			isInitialStop = false;
			
			currentStopId = initialStopId;
		}
		
		$.ajax({
			method: 'GET',
			url: url + currentStopId + '.json'
		}).then(successfulDepart).catch(error);
	}
	
	function successfulDepart(res) {
		currentStop = res['name'];
		nextStopId = res['next'];
		
		$('span.info').text(`Next stop ${currentStop}`);
		$('#depart').attr('disabled', 'true');
		$('#arrive').removeAttr('disabled');
	}
	
	function arrive() {
		$('span.info').text(`Arriving at ${currentStop}`);
		
		
		$('#depart').removeAttr('disabled');
		$('#arrive').attr('disabled', 'true');
	}
	
	function error(res) {
		$('span.info').text('Error');
	}
	
	return {
		depart,
		arrive
	};
}
let result = solve();