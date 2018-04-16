function result() {
	
	let tally = new Map();
	for (let i = 0; i < arguments.length; i++) {
		let arg = arguments[i];
		let type = typeof arg;
		
		console.log(type + ': ' + arg);
		
		if(!tally.has(type)){
			tally.set(type, 0);
		}
		tally.set(type, tally.get(type) + 1);
	}
	
	let sortedTypes = [...tally].sort(function (a, b) {
		if (a[1] >= b[1]){
			return -1;
		}
		if(a[1] < b[1]){
			return 1;
		}
	}).forEach(pair => console.log(`${pair[0]} = ${pair[1]}`));
	
}

result({ name: 'bob'}, 3.333, 9.999);