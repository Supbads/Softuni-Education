function attachEvents() {
	$('#btnLoadTowns').on('click', appendTowns);
	
	async function appendTowns(ev){
		let townsArr = await $('#towns').val().split(',');
		townsArr = townsArr.map(e => {
			return {name: e.trim()}
		});
		
		let context = {
			towns: townsArr
		};
		
		let source = await $('#towns-template').html();
		let template = Handlebars.compile(source);
		let html = template(context);
		
		$('#root').html(html);
		
		$('#root li:empty').remove();
	}
}