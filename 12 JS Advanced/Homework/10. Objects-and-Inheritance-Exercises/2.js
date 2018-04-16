function solve(object) {
	if(object.handsShaking === false){
		
		return object;
		console.log(object);
	}
	
	
	let weight = object.weight;
	let experience = object.experience;
	let alchoholLevel = object.bloodAlcoholLevel;
	
	let newLevel = alchoholLevel + 0.1 * weight * experience;
	
	object.bloodAlcoholLevel = newLevel;
	object.handsShaking = false;
	
	return object;
	console.log(object);
}

solve({ weight: 80,
	experience: 1,
	bloodAlcoholLevel: 0,
	handsShaking: true });