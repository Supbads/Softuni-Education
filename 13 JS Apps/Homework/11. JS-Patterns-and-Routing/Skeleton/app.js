$(() => {
	const app = Sammy('#main', function () {
		this.use('Handlebars', 'hbs');
		
		this.get('#/index.html', function (ctx) {
			ctx.isAuth = auth.isAuth();
			
			$.ajax('data.json')
					.then((contacts) => {
						ctx.contacts = contacts;
						
						ctx.loadPartials({
							header: './templates/common/header.hbs',
							navigation: './templates/common/navigation.hbs',
							footer: './templates/common/footer.hbs',
							contactPage: './templates/contactPage.hbs',
							details: './templates/details.hbs',
							contact: './templates/contact.hbs',
							contactsList: './templates/contactsList.hbs',
							loginForm: './templates/forms/loginForm.hbs',
						}).then(function () {
						ctx.partials = this.partials;
						
						render();
					});
			}).catch(console.error);
			
			function render() {
				ctx.partial('./templates/welcome.hbs').then(attachEvents);
			}
			
			function attachEvents() {
				$('.contact').click((e) => {
					console.log(e);
					console.log(e.target);
					console.log($(e.target).closest('.contact'));
					
					let index = $(e.target).closest('.contact').attr('data-id');
					ctx.selected = ctx.contacts[index];
					render();
				});
			}
		});
		
		this.get('#/register', function (ctx) {
			ctx.loadPartials({
				header: './templates/common/header.hbs',
				navigation: './templates/common/navigation.hbs',
				footer: './templates/common/footer.hbs',
			}).then(function () {
				this.partial('./templates/forms/registerForm.hbs')
			});
		});
		
		this.post('#/register', function (ctx) {
			let username = ctx.params.username;
			let password = ctx.params.pass;
			let repeat = ctx.params.repeatPass;
			
			console.log({username, password, repeat});
			
			if(password !== repeat){
				alert('Passwords do not match');
			}else{
				auth.register(username, password);
				ctx.redirect('#/index.html');
			}
		
		});
		
		this.post('#/login', function (ctx) {
			let username = ctx.params.username;
			let password = ctx.params.pass;
			
			console.log({username, password});
			
			auth.login(username, password).then((userData) =>
			{
				auth.saveSession(userData);
				ctx.redirect('#/index.html');
			});
		});
		
		this.get('#/logout', (ctx) => {
			auth.logout().then(() => {
				auth.clearSession();
				ctx.redirect('#/index.html');
			});
		});
	});
	
	app.run();
});