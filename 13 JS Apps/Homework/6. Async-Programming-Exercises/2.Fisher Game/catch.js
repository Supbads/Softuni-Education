function attachEvents() {
	const baseUrl = 'https://baas.kinvey.com/appdata/kid_HJBUjKi5f';
	const kinveyUsername = 'test';
	const kinveyPassword = 'test';
	const base64auth = btoa(kinveyUsername + ":" + kinveyPassword);
	const authHeaders = {
		'Authorization': 'Basic ' + base64auth,
		'Content-type': 'application/json'
	};
	$('#aside').find('.load').click(listAllCatches);
	$('#addForm').find('.add').click(addCatch);
	
	function listAllCatches() {
		$.ajax({
			method: 'GET',
			url: baseUrl + '/biggestCatches',
			headers: authHeaders
		}).then(displayCatches)
	
	}
	
	function displayCatches(res) {
		$('#catches').empty();
		
		for (let _catch of res) {
			let id = _catch['_id'];
			let angler = _catch['angler'];
			let weight = _catch['weight'];
			let species = _catch['species'];
			let location = _catch['location'];
			let bait = _catch['bait'];
			let captureTime = _catch['captureTime'];
			displayCatch(id, angler, weight, species, location, bait, captureTime, _catch);
		}
	}
	
	function addCatch() {
		let obj = getAllFieldsData('#addForm');
		
		$.ajax({
			method: 'POST',
			url: baseUrl + '/biggestCatches',
			headers: authHeaders,
			data: JSON.stringify(obj)
		}).then(listAllCatches).catch(handleAjaxError);
	
	}
	
	function getAllFieldsData(selector) {
		let catchObj = {};
		
		$(selector).parent().find('input').each((index, element) => {
			if(element.type === 'text'){
				catchObj[element.className] = element.value;
			}else{
				catchObj[element.className] = Number(element.value);
			}
		});
		
		return catchObj;
	}
	
	function updateCatch(ev) {
		let catchObj = getAllFieldsData(ev.target);
		
		$.ajax({
			method: 'PUT',
			url: baseUrl + '/biggestCatches/' + this['_id'],
			headers: authHeaders,
			data: JSON.stringify(catchObj)
		}).then(listAllCatches).catch(handleAjaxError);
	}
	
	function deleteCatch(ev) {
		$.ajax({
			method: 'DELETE',
			url: baseUrl + '/biggestCatches/' + this['_id'],
			headers: authHeaders
		}).then(listAllCatches).catch(handleAjaxError);
	}
	
	function displayCatch(id, angler, weight, species, location, bait, captureTime, _catch) {
		let mainDiv = $(`<div class="catch" data-id="${id}">`);
		let anglerLabel = $('<label>Angler</label>');
		let anglerInput = $(`<input type="text" class="angler" value="${angler}"/>`);
		let weightLabel = $('<label>Weight</label>');
		let weightInput = $(`<input type="number" class="weight" value="${weight}"/>`);
		let speciesLabel = $('<label>Species</label>');
		let speciesInput = $(`<input type="text" class="species" value="${species}"/>`);
		let locationLabel = $('<label>Location</label>');
		let locationInput = $(`<input type="text" class="location" value="${location}"/>`);
		let baitLabel = $('<label>Bait</label>');
		let baitInput = $(`<input type="text" class="bait" value="${bait}"/>`);
		let captureLabel = $('<label>Capture Time</label>');
		let captureInput = $(`<input type="number" class="captureTime" value="${captureTime}"/>`);
		
		let updateButton = $(`<button class="update">Update</button>`).click(updateCatch.bind(_catch));
		let deleteButton = $(`<button class="delete">Delete</button>`).click(deleteCatch.bind(_catch));
		
		mainDiv.append(anglerLabel)
				.append(anglerInput)
				.append(weightLabel)
				.append(weightInput)
				.append(speciesLabel)
				.append(speciesInput)
				.append(locationLabel)
				.append(locationInput)
				.append(baitLabel)
				.append(baitInput)
				.append(captureLabel)
				.append(captureInput)
				.append(updateButton)
				.append(deleteButton);
		
		$('#catches').append(mainDiv);
	}
	
	function handleAjaxError(res) {
	}
}