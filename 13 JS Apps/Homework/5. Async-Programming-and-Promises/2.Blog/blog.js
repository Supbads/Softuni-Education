function attachEvents() {
	const appId = 'kid_rJkpS0E9M';  //posts
	const url = `https://baas.kinvey.com/appdata/` + appId;
	const kinveyUsername = 'user';
	const kinveyPassword = 'u';
	const base64auth = btoa(kinveyUsername + ":" + kinveyPassword);
	const authHeaders = { "Authorization": "Basic " + base64auth };
	
	//optimization attempt
	let cachedPosts = {};
	
	$("#btnLoadPosts").click(loadPostsClick);
	$("#btnViewPost").click(viewPostClick);
	
	function loadPostsClick() {
		$.ajax({
			method: 'GET',
			url: url + '/posts',
			headers: authHeaders
		}).then(handleSuccess).catch(handleError);
		
		function handleSuccess(res) {
			let postsSelection = $('#posts');
			postsSelection.empty();
			
			for (let post of res) {
				let id = post['_id'];
				let title = post['title'];
				let body = post['body'];
				
				let option = $('<option>');
				option.val(id);
				option.text(title);
				
				cachedPosts[id] = {title, body};
				
				postsSelection.append(option);
			}
		}
	}
	
	function viewPostClick() {
		let selectedPostId = $('#posts :selected').val();
		console.log(selectedPostId);
		if (!selectedPostId)
		{
			return;
		}

		let queryUrl = url + `/comments/?query={"post_Id":"${selectedPostId}"}`;

		$.ajax({
			method: 'GET',
			url: queryUrl,
			headers: authHeaders
		}).then(handleSuccess).catch(handleError);

		function handleSuccess(res){
			console.log(res);
			let postDetails = cachedPosts[selectedPostId];

			$('#post-title').text(postDetails['title']);
			$('#post-body').text(postDetails['body']);
			let comments = $('#post-comments');
			comments.empty();

			for (let comment of res) {
				let commentText = comment['text'];
				let li = $('<li>').text(commentText);
				comments.append(li);
			}
		}
	}
	
	function handleError(res) {
		let errorDiv = $("<div>").text("Error: " +
				res.status + ' (' + res.statusText + ')');
		$(document.body).prepend(errorDiv);
		setTimeout(function() {
			$(errorDiv).fadeOut(function() {
				$(errorDiv).remove();
			});
		}, 3000);
	}
}