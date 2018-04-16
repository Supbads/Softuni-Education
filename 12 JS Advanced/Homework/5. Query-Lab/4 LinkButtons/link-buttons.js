function attachEvents() {
	$('a.button').on('click', isClicked);
	
	function isClicked() {
		$('.selected').removeClass('selected');
		
		$(this).addClass('selected');
	}
}