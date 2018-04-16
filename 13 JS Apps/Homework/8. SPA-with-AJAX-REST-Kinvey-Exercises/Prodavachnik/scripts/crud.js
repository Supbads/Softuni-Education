const BASE_URL = 'https://baas.kinvey.com/';
const APP_KEY = 'kid_S1bU7J-jz';
const APP_SECRET = '994d0e607366487a94f12ba8d526339a';
const AUTH_HEADERS = {'Authorization': "Basic " + btoa(APP_KEY + ":" + APP_SECRET)};

function loginUser() {
	let username = $('#formLogin input[name=username]').val();
	let password = $('#formLogin input[name=passwd]').val();
	console.log(username);
	console.log(password);
	$.ajax({
		method: 'POST',
		headers: AUTH_HEADERS,
		url : BASE_URL + 'user/' + APP_KEY + '/login',
		data : {username, password}
	}).then(function (res) {
		console.log(res);
		signInUser(res, 'Login successful.');
	}).catch(handleAjaxError);
}

function signInUser(res, message) {
	sessionStorage.setItem('username', res.username);
	sessionStorage.setItem('authToken', res._kmd.authtoken);
	sessionStorage.setItem('userId', res._id);
	showHomeView();
	showHideMenuLinks();
	showInfo(message);
}

function registerUser() {
	let username = $('#formRegister input[name=username]').val();
	let password = $('#formRegister input[name=passwd]').val();
	
	$.ajax({
		method: 'POST',
		headers: AUTH_HEADERS,
		url : BASE_URL + 'user/' + APP_KEY + '/',
		data : {username, password}
	}).then(function (res) {
		signInUser(res, 'Registration successful.');
	}).catch(handleAjaxError);
}

function logoutUser(){
	sessionStorage.clear();
	showHomeView();
	showHideMenuLinks();
	showInfo('Successfully logged out.');
}

function listAds() {
	$.ajax({
		url: BASE_URL + 'appdata/' + APP_KEY + '/items',
		headers: {'Authorization': 'Kinvey ' + sessionStorage.getItem('authToken')}
	}).then(function (res) {
		showAdsView();
		displayAds(res);
	}).catch(handleAjaxError);
	
	function displayAds(res) {
		res = res.reverse();
		$('table tr').slice(1).remove();
		let table = $('table');
		
		for (let ad of res) {
			let title = ad.title;
			let description = ad.description;
			let price = ad.price;
			let publisher = ad._acl.creator;
			let date = ad.date;
			
			let tr = $('<tr>');
			let titleTd = $('<td>').text(title);
			let publisherTd = $('<td>').text(publisher);
			let descriptionTd = $('<td>').text(description);
			let priceTd = $('<td>').text(price);
			let dateTd = $('<td>').text(date);
			
			tr.append(titleTd)
					.append(publisherTd)
					.append(descriptionTd)
					.append(priceTd)
					.append(dateTd);
			
			
			let viewDetailsAction = $('<a href="#">[Read More] </a>').on('click', function () {
				viewDetailsAd(ad);
			});
			if(publisher === sessionStorage.getItem('userId')){
				let actionsTd = $('<td>');
				let editAction = $('<a href="#">[Edit] </a>').on('click', function () {
					loadAdForEdit(ad);
				});
				let deleteAction = $('<a href="#">[Delete]</a>').on('click', function () {
					deleteAd(ad);
				});
				
				actionsTd.append(viewDetailsAction);
				actionsTd.append(editAction);
				actionsTd.append(deleteAction);
				tr.append(actionsTd);
			}
			else{
				tr.append($('<td>').append(viewDetailsAction));
			}
			
			table.append(tr);
		}
	}
}

function createAd() {
	let title = $('#formCreateAd input[name=title]').val();
	let description = $('#formCreateAd textarea[name=description]').val();
	let date =$('#formCreateAd input[name=datePublished]').val();
	let price = $('#formCreateAd input[name=price]').val();
	
	let publisher = sessionStorage.getItem('username');
	console.log(publisher)
	
	$.ajax({
		method: 'POST',
		url: BASE_URL + 'appdata/' + APP_KEY + '/items',
		headers: {'Authorization': 'Kinvey ' + sessionStorage.getItem('authToken')},
		data: {title, description, date, price, publisher}
	}).then(function (res) {
		listAds();
		showInfo('Ad created.')
	}).catch(handleAjaxError);
}

function loadAdForEdit(ad) {
	showView('viewEditAd');
	$('#formEditAd input[name=id]').val(ad._id);
	$('#formEditAd input[name=publisher]').val(ad._acl.creator)
	$('#formEditAd input[name=title]').val(ad.title);
	$('#formEditAd textarea[name=description]').val(ad.description);
	$('#formEditAd input[name=datePublished]').val(ad.date);
	$('#formEditAd input[name=price]').val(ad.price);
	
}

function editAd(ev) {
	let id = $('#formEditAd input[name=id]').val();
	let title = $('#formEditAd input[name=title]').val();
	let description = $('#formEditAd textarea[name=description]').val();
	let date = $('#formEditAd input[name=datePublished]').val();
	let price = $('#formEditAd input[name=price]').val();
	
	$.ajax({
		method: 'PUT',
		url: BASE_URL + 'appdata/' + APP_KEY + '/items/' + id,
		headers: {'Authorization': 'Kinvey ' + sessionStorage.getItem('authToken')},
		data: {title, description, date, price}
	}).then(function () {
		showAdsView();
		listAds();
		showInfo('Ad edited successfully.');
	}).catch(handleAjaxError)
}

function deleteAd(ad) {
	let id = ad._id;
	
	$.ajax({
		method: 'DELETE',
		url: BASE_URL + 'appdata/' + APP_KEY + '/items/' + id,
		headers: {'Authorization': 'Kinvey ' + sessionStorage.getItem('authToken')}
	}).then(function () {
		showHomeView();
		listAds();
	}).catch(handleAjaxError);
}

function viewDetailsAd(ad) {
	$('#viewDetailsAd').empty();
	
	let adInfo = $('<div>').append(
			$('<br>'),
			$('<label>').text('Title: '),
			$('<h1>').text(ad.title),
			$('<label>').text('Description: '),
			$('<p>').text(ad.description),
			$('<label>').text('Publisher: '),
			$('<div>').text(ad.publisher),
			$('<label>').text('Date: '),
			$('<div>').text(ad.date)
	)
	
	$('#viewDetailsAd').append(adInfo);
	showView('viewDetailsAd');
}

function handleAjaxError(response) {
	console.log(response);
	let errorMsg = JSON.stringify(response);
	if (response.readyState === 0)
		errorMsg = "Cannot connect due to network error.";
	if (response.responseJSON && response.responseJSON.description)
		errorMsg = response.responseJSON.description;
	showError(errorMsg);
}