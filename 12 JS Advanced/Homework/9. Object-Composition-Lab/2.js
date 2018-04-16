function solve() {
	let fibunator = (function () {
		let a = 1;
		let b = 0;
		
		return function () {
			let sum = a + b;
			let temp = b ;
			b = sum;
			a = temp;
			
			return sum;
		}
	})();
	
	return fibunator;
}

let asd = solve();

asd();
asd();
asd();
asd();
asd();
