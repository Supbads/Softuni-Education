(function updateMessage() {
	let message = 'Knock Knock.';
	const baseUrl = 'https://baas.kinvey.com/appdata/kid_BJXTsSi-e';
	let username = 'guest';
	let password = 'guest';
	const base64auth = btoa(username + ":" + password);
	const authHeader = {
		'Authorization': 'Basic ' + base64auth,
		'Content-type': 'application/json'
	};
	login();

	function login() {
		//let credentials = {username, password};

		$.ajax({
			method: 'POST',
			url: baseUrl + '/login',
			//data: JSON.stringify(credentials),
			headers: authHeader
		});
		
		$('#messages').append($(`<li>`).text(`${message}`));
	}

	$('#load').on('click', function() {
		$.ajax({
			method: 'GET',
			url: baseUrl + `/knock?query=${message}`,
			headers: authHeader
		}).then(displayMessage);

		function displayMessage(res) {
			message = res.message;
			let answer = res['answer'];
			
			if(message !== undefined){
				$('#messages').append($(`<li>`).text(`-${answer}. ${message}`));
			}else{
				$('#messages').append($(`<li>`).text(`${answer}`));
				
				$('#load').css('display','none');
			}
			
		}
	});
})();