function Aggregate(arr) {
	let funcs = {
		'Sum': (a,b) => a + b,
		'Min': (a,b) => a < b ? a : b,
		'Max': (a,b) => a > b ? a : b,
		'Product': (a,b) => a*b,
		'Join': (a,b) => a += b.toString(),
	};
	
	console.log('Sum = ' + arr.reduce(funcs['Sum']));
	console.log('Min = ' + arr.reduce(funcs['Min']));
	console.log('Max = ' + arr.reduce(funcs['Max']));
	console.log('Product = ' + arr.reduce(funcs['Product']));
	console.log('Join = ' + arr.reduce(funcs['Join']));
}

Aggregate([2,3,10,5]);