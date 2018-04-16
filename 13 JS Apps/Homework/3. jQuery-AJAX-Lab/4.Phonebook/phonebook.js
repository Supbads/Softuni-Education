$('#btnLoad').click(loadData);
$('#btnCreate').click(postData);

let url = 'https://phonebook-dc8e9.firebaseio.com/Phonebook';

function loadData() {
	$('#phonebook').empty();
	
	$.ajax({url: url + '.json', method: 'GET'}).then(handleSuccess).catch(handleError)
}

function handleSuccess(responce) {
	for (let key in responce) {
		let name = responce[key]['person'];
		let phone = responce[key]['phone'];
		
		let li = $(`<li>${name}: ${phone} </li>`);
		let anchor = $('<a href="#">[DELETE]</a>');
		anchor.click(function () {
			$.ajax({method: 'DELETE',
			url: url + '/' + key + '.json'}).then(() => li.remove()).catch(handleError);
		});
		
		li.append(anchor);
		$('#phonebook').append(li);
	}
}

function postData() {
	let person = $('#person');
	let phone = $('#phone');
	
	let personName = person.val();
	let phoneNumber = phone.val();
	
	let record = {person: personName, phone: phoneNumber};
	record = JSON.stringify(record);
	
	$.ajax({url: url + '.json', data: record, method: 'POST'}).then(appendElement).catch(handleError);
	
	person.val('');
	phone.val('');
	
	function appendElement(responce) {
		let key = responce.name;
		
		let li = $(`<li>${personName}: ${phoneNumber} </li>`);
		let anchor = $('<a href="#">[DELETE]</a>');
		
		anchor.click(function () {
			$.ajax({method: 'DELETE',
				url: url + '/' + key + '.json'}).then(() => li.remove()).catch(handleError);
		});
		
		li.append(anchor);
		$('#phonebook').append(li);
	}
}

function handleError(error) {
	console.log(error);
}