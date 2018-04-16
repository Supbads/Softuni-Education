function solve(arr, order) {
	if(order === 'asc'){
		return arr.sort((a,b) => a-b );
		
	}else{
		return arr.sort((a,b) => b-a );
	}
}