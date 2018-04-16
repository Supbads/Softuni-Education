$(() => {
    const app = Sammy('#main', function () {
	    this.use('Handlebars', 'hbs');
	
	    this.get('index.html', displayHome);
		this.get('#/home', displayHome);
	    
	    function displayHome(ctx) {
		    ctx.loggedIn = sessionStorage.getItem('authtoken') !== null;
		 
			if(ctx.loggedIn){
				ctx.username = sessionStorage.getItem('username');
				let teamId = sessionStorage.getItem('teamId');
				console.log(teamId);
				ctx.hasTeam = teamId === undefined;
				ctx.teamId = teamId;
			}

		    ctx.loadPartials({
			    header: './templates/common/header.hbs',
			    footer: './templates/common/footer.hbs',
		    }).then(function () {
			    this.partial('./templates/home/home.hbs');
		    });
	    }
	    
	    this.get('#/about', function (ctx) {
		    ctx.loggedIn = sessionStorage.getItem('authtoken') !== null;
		    ctx.username = sessionStorage.getItem('username');
		    
		    ctx.loadPartials({
			    header: './templates/common/header.hbs',
			    footer: './templates/common/footer.hbs',
		    }).then(function () {
			    this.partial('templates/about/about.hbs');
		    });
	    });
	    
	    this.get('#/login', function (ctx) {
		    ctx.loadPartials({
			    loginForm: './templates/login/loginForm.hbs',
			    header: './templates/common/header.hbs',
			    footer: './templates/common/footer.hbs',
			    
		    }).then(function () {
			    this.partial('./templates/login/loginPage.hbs');
		    });
	    });
	    
	    this.post('#/login', function (ctx) {
	    	let username = ctx.params.username;
	    	let password = ctx.params.password;
	    	
	    	auth.login(username, password).then(function (userInfo) {
			    auth.saveSession(userInfo);
			    auth.showInfo('Successfully logged in!');
			    
			    displayHome(ctx)
		    });
	    });
	    
	    this.get('#/register', function (ctx) {
		   ctx.loadPartials({
			   header: './templates/common/header.hbs',
			   footer: './templates/common/footer.hbs',
			   registerForm: './templates/register/registerForm.hbs',
		   }).then(function () {
			   this.partial('./templates/register/registerPage.hbs')
		   })
	    });
	    
	    this.post('#/register', function (ctx) {
		    let username = ctx.params.username;
		    let password = ctx.params.password;
		    let repeat = ctx.params.repeatPassword;
		    
		    if(password !== repeat){
		    	auth.showError('Passwords do not match');
		    }else{
			    auth.register(username, password).then(function () {
			    	auth.showInfo('Successfully registered!');
			        ctx.redirect('#/login');
			    });
		    }
	    });
	
	    this.get('#/logout', (ctx) => {
		    auth.logout().then(() => {
			    auth.clearSession();
			    
			    displayHome(ctx)
		    });
	    });
	    
	    this.get('#/catalog', (ctx) => {
		    ctx.loggedIn = sessionStorage.getItem('authtoken') !== null;
		
		    if(ctx.loggedIn){
			    ctx.username = sessionStorage.getItem('username');
			    let teamId = sessionStorage.getItem('teamId');
			    ctx.teamId = teamId;
			    ctx.hasNoTeam = teamId === 'undefined';
		    }
				
		    teamsService.loadTeams().then(function (teams) {
		    	ctx.teams = teams;
		    	
			    ctx.loadPartials({
				    header: './templates/common/header.hbs',
				    footer: './templates/common/footer.hbs',
				    team: './templates/catalog/team.hbs',
			    }).then(function () {
				    this.partial('./templates/catalog/teamCatalog.hbs');
			    });
		    }).catch(auth.handleError);
	    });
			  
	    this.get('#/catalog/:id', (ctx) => {
	    	let teamId = ctx.params.id.substr(1);
		    ctx.teamId = teamId;
	    	
		    ctx.loggedIn = sessionStorage.getItem('authtoken') !== null;
		    ctx.username = sessionStorage.getItem('username');
		    
	    	Promise.all([teamsService.loadTeamDetails(teamId), teamsService.loadTeamMembers(teamId)])
			    .then(function ([teamDetails, teamMembers]) {
					
				    ctx.name = teamDetails.name;
				    ctx.comment = teamDetails.comment;
				    ctx.members = teamMembers;
				    ctx.isAuthor = teamDetails._acl.creator === sessionStorage.getItem('userId');
				    ctx.isOnTeam = sessionStorage.getItem('teamId') === teamId;
				    
				    //edited the app slightly so that you cannot request to join a team if you're already in one
				    ctx.hasNoTeam = sessionStorage.getItem('teamId') === 'undefined';
				    
				    ctx.loadPartials({
					    header: './templates/common/header.hbs',
					    footer: './templates/common/footer.hbs',
						teamMember: './templates/catalog/teamMember.hbs',
					    teamControls: './templates/catalog/teamControls.hbs'
				    }).then(function () {
					    this.partial('./templates/catalog/details.hbs')
				    });
            });
	    });
	    
	    this.get('#/create', (ctx) => {
		
		    ctx.loggedIn = sessionStorage.getItem('authtoken') !== null;
		    ctx.username = sessionStorage.getItem('username');
	    	
	        ctx.loadPartials({
		        header: './templates/common/header.hbs',
		        footer: './templates/common/footer.hbs',
		        createForm: './templates/create/createForm.hbs',
	        }).then(function() {
	        	 this.partial('./templates/create/createPage.hbs');
	        });
	    });
	    
	    this.post('#/create', (ctx) => {
	    	let teamName = ctx.params.name;
	    	let comment = ctx.params.comment;
	    	
	    	teamsService.createTeam(teamName, comment).then(function (res) {
	    		// you should be in the team once you create it, no?
			    teamsService.joinTeam(res._id);
			    sessionStorage.setItem('teamId', res._id);
			    ctx.redirect('#/catalog');
			    
			    auth.showInfo(`Team "${teamName}" created successfully!`);
		    });
	    });
	    
	    this.get('#/edit/:id', (ctx) => {
		    ctx.loggedIn = sessionStorage.getItem('authtoken') !== null;
		    ctx.username = sessionStorage.getItem('username');
		    
		    let teamId = ctx.params.id.substr(1);
		    teamsService.loadTeamDetails(teamId).then((teamDetails) => {
		    	ctx.name = teamDetails.name;
		    	ctx.comment = teamDetails.comment;
		    	ctx.teamId = teamDetails._id;
		    	
			    ctx.loadPartials({
				    header: './templates/common/header.hbs',
				    footer: './templates/common/footer.hbs',
				    editForm: './templates/edit/editForm.hbs',
			    }).then(function() {
				    this.partial('./templates/edit/editForm.hbs');
			    });
		    });
	    });
	    
	    this.post('#/edit/:id', (ctx) => {
	    	let id = ctx.params.id.substr(1);
	    	let name = ctx.params.name;
	    	let comment = ctx.params.comment;
	    	
	        teamsService.edit(id, name, comment).then(function () {
		        auth.showInfo('Team successfully edited');
		        ctx.redirect('#/catalog');
	        });
	    });
	
	    this.get('#/join/:id', (ctx) => {
			let teamId = ctx.params.id.substr(1);
			
			teamsService.joinTeam(teamId).then(function (res) {
				console.log(res);
				
				sessionStorage.setItem('teamId', teamId);
				ctx.redirect('#/catalog');
				//auth.showInfo(`Team ${} successfully joined`);
			});
	    });
	    
	    this.get('#/leave', (ctx) => {
	    	teamsService.leaveTeam().then((res)=> {
	    		auth.showInfo('Team was left successfully');
	    		
			    sessionStorage.setItem('teamId', 'undefined');
			    ctx.redirect('#/catalog');
		    }).catch(auth.handleError);
	    });
	    
    });

    app.run();
});