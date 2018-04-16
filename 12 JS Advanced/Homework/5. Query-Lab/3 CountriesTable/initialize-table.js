function initializeTable() {
	createCountry('Bulgaria', 'Sofia');
	createCountry('Germany', 'Berlin');
	createCountry('Russia', 'Moscow');
	
	$('#createLink').click(inputSuccessful);
	restrictRows();
	
	function inputSuccessful() {
		let country = $('#newCountryText').val();
		let capital = $('#newCapitalText').val();
		
		createCountry(country, capital);
		
		country.val('');
		capital.val('');
	}
	
	function createCountry(country, capital) {
		let tr = $('<tr>');
		
		let countryTd = $('<td>').text(country);
		let capitalTd = $('<td>').text(capital);
		
		//up
		//down
		//delete
		let actionsTd = $('<td>');
		let upText = $("<a tag='Up' href='#'>[Up]</a>").click(moveRowUp);
		let downText = $("<a tag='Down' href='#'>[Down]</a>").click(moveRowDown);
		let deleteText = $("<a href='#'>[Delete]</a>").click(deleteChild);
		
		actionsTd.append(upText);
		actionsTd.append(' ');
		actionsTd.append(downText);
		actionsTd.append(' ');
		actionsTd.append(deleteText);
		
		tr.append(countryTd);
		tr.append(capitalTd);
		tr.append(actionsTd);
		
		//tr.css('display','none');
		
		$('#countriesTable').append(tr);
		restrictRows();
	}
	
	function deleteChild() {
		//          <a>    <td>     <tr>
		let row = $(this).parent().parent();
		
		row.remove();
		restrictRows();
	}
	function moveRowUp() {
		let row = $(this).parent().parent();
		
		row.insertBefore(row.prev());
		
		restrictRows();
	}
	
	function moveRowDown() {
		let row = $(this).parent().parent();
		
		row.insertAfter(row.next());
		
		restrictRows();
	}
	
	function restrictRows() {
		$('#countriesTable a').css('display', 'inline');
		
		$('#countriesTable tr:last').find("a:contains('Down')").css('display', 'none');
		
		$('#countriesTable tr:nth-child(3)').find("a[tag='Up']").css('display', 'none');

	}
}