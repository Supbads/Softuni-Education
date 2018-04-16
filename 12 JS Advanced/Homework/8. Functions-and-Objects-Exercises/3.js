function solve(n) {
	let clojure = (function () {
		let sum = 0;
		function add(m) {
			sum += m;
			return add;
		}
		
		add.toString = () => sum.toString();
		return add
	})();
	
	//console.log(clojure(n).toString());
	return clojure(n);
}

solve(5);