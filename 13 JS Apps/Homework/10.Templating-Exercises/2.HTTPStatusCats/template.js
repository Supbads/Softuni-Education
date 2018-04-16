$(() => {
    renderCatTemplate();

    async function renderCatTemplate() {
        let source = await $.get('catTemplate.hbs');
		let template = Handlebars.compile(source);
		let html = template({cats: window.cats});
    
		$('#allCats').html(html);
		
		$('.btn-primary').on('click', function (ev) {
			let current = $(ev.target);
			let statusCodeDiv = current.next();
			
			statusCodeDiv.toggle();
			
			if(current.text().startsWith('Show')){
				current.text('Hide status code');
			}else{
				current.text('Show status code');
			}
		})
    }
});