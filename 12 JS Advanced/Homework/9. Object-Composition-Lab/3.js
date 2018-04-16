function solve(inputArr) {
	let closure = (function () {
		let data = [];
		
		return {
			'add': (arg) => data.push(arg),
			'remove': (arg) => data = data.filter(x => x !== arg),
			'print': () => console.log(data.join(','))
		}
	})();
	
	for (let commandLine of inputArr) {
		let [command, arg] = commandLine.split(' ');
		closure[command](arg);
	}
}


solve(['add pesho', 'add gosho', 'add pesho', 'remove pesho','print']);