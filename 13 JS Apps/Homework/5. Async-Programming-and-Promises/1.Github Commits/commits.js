function loadCommits() {
	let username = $('#username').val();
	let repo = $('#repo').val();
	
	let url = `https://api.github.com/repos/${username}/${repo}/commits`;
	
	$.ajax({
		method:"GET",
		url
	}).then(handleSuccess).catch(handleError);

	function handleSuccess(res) {
		for (let entity of res) {
			let author = entity.commit.author.name;
			let message = entity.commit.message;
			
			let li = $('<li>').text(`${author}: ${message}`);
			
			$('#commits').append(li);
		}
	}
	
	function handleError(res) {
		let commits = $('#commits');
		commits.empty();
		commits.append($('<li>').text(`Error: ${res.status} (${res.statusText})`));
	}
}