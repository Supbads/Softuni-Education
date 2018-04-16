function solve(rectangles) {
	let arr = [];
	
	for (let [width, height] of rectangles) {
		
		let newObject = {
			width: width,
			height: height,
			area: () => newObject.height * newObject.width,
			compareTo: (other) => {
				return other.area() - newObject.area() < 0 ?
						-1 : other.area() - newObject.area() > 0 ? 1 :
								other.width < newObject.width ?
										-1 : other.width > newObject.width ? 1 : 0 }
		};
		
		
		arr.push(newObject);
	}
	
	
	arr = arr.sort((x, y) => x.compareTo(y));
	
	//return arr;
	for (let object of arr) {
		console.log(object);
	}
}


solve([[1,20],[20,1],[5,3],[5,3]]);
//solve([[10,5], [3,20], [5,12]]);