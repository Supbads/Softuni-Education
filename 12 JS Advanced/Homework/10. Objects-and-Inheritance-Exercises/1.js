(function solve() {
	Array.prototype.last = function () {
		return this[this.length - 1];
	};
	
	Array.prototype.skip = function (n) {
		let elements = [];
		for (let i = n; i < this.length; i++) {
			elements.push(this[i]);
		}
		
		return elements;
	};
	
	Array.prototype.take = function (n) {
		let elements = [];
		for (let i = 0; i < n; i++) {
			elements.push(this[i]);
		}
		
		return elements;
	};
	
	Array.prototype.sum = function () {
		let sum = 0;
		for (let i = 0; i < this.length; i++) {
			sum += this[i];
		}
		
		return sum;
	};
	
	Array.prototype.average = function () {
		let sum = this.sum();
		
		return sum/this.length;
	}
	
	
})();