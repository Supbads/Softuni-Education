function gcd(m, n) {
	let result = 0;
	
	let end = Math.min(m, n);
	
	for (let i = 1; i <= end; i++) {
		if (m % i === 0 && n % i === 0) {
			result = i;
			
		}
	}
	
	return result;
}

console.log(gcd(252,105));