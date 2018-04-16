function attachEvents() {
	$('#submit').on('click', submit);
	$('#refresh').on('click', refresh);
	
	let url = 'https://messanger-3b8ca.firebaseio.com/';
	
	function refresh() {
		$.ajax({
			method: 'GET',
			url: url + '.json'
		}).then(successfulRefresh).catch(error);
	}
	
	function successfulRefresh(res) {
		let messages = '';
		
		for (let messageId in res) {
			let message = res[messageId];
			let author = message['author'];
			let content = message['content'];
			
			messages += `${author}: ${content}\n`;
		}
		
		$('#messages').text(messages);
	}
	
	function submit() {
		let author = $('#author').val();
		let content = $('#content').val();
		let timestamp = Date.now();
		
		let message = JSON.stringify({author, content, timestamp});
		
		$.ajax({
			method: 'POST',
			url: url + '.json',
			data: message
		}).then(refresh).catch(error);
		
		$('#content').val('');
	}
	
	function error(res) {
	}
}