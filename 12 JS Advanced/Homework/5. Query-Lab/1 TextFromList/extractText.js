function extractText() {
	let lis = $('#items li').toArray();
	
	let appended = lis.map(x => x.textContent).join(', ');
	$('#result').text(appended);
}