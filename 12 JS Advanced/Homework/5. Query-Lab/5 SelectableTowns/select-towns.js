function attachEvents() {
	$('#items li').on('click', townClicked);
	$('#showTownsButton').click(listTowns);
	
	function townClicked() {
		let currentTown = $(this);
		
		if(currentTown.attr('data-selected')){ //apperently it's also a contains function ?
			currentTown.removeAttr('data-selected');
			currentTown.css('background', '');
			
		}else{
			currentTown.attr('data-selected', true);
			currentTown.css('background', '#DDD')
		}
	}
	
	function listTowns() {
		let selectedLis = $('li[data-selected=true]'); //
		let towns = selectedLis.toArray().map(x => x.textContent);

		$('#selectedTowns').text(towns.join(', '));
	}
}