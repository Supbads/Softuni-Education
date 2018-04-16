function attachEvents() {
	$('#btnLoad').on('click', loadPhonebook);
	$('#btnCreate').on('click', createContact);
	
	let url = 'https://phonebook-nakov.firebaseio.com/phonebook';
	
	function loadPhonebook() {
		$('#phonebook').empty();
		
		$.ajax({
			method: 'GET',
			url: url + '.json'
		}).then(handleSuccess).catch(handleError);
		
		
		function handleSuccess(res) {
			for (let key in res) {
				generateLi(res[key]['person'], res[key]['phone'], key);
			}
		}
	}

	function createContact() {
		let person = $('#person').val();
		let phone = $('#phone').val();
		
		let contact = JSON.stringify({person, phone});
		
		$.ajax({
			method: 'POST',
			url: url + '.json',
			data: contact
		}).then(handleSuccess).catch(handleError)
		
		$('#person').val('');
		$('#phone').val('');
		
		function handleSuccess(res) {
			let key = res.name;
			generateLi(person, phone, key);
		}
	}
	
	// function generateLi(name, phone, key) {
	// 	let li = $(`<li>${name}: ${phone} </li>`);
	// 	let button = $('<button>[Delete]</button>')
	// 					.click(function () {
	// 						$.ajax({
	// 							method: 'DELETE',
	// 							url: url + '/' + key + '.json'
	// 						}).then(() => $(li).remove())
	// 								.catch(handleError)
	// 					});
	//
	// 	li.append(button);
	// 	$('#phonebook').append(li)
	// }
	
	function generateLi(person, phone, key) {
		let li = $(`<li>${person}: ${phone} </li>`);
		let button = ($('<button>[Delete]</button>')
						.click(deleteLi.bind(this, li, key)));
		li.append(button);
		$('#phonebook').append(li)
	}
	
	function deleteLi(li, contactId) {
		$.ajax({
			method: 'DELETE',
			url: url + '/' + contactId + '.json'}).then(() => li.remove()).catch(handleError);
	}
	
	function handleError(res) {
	
	}
}