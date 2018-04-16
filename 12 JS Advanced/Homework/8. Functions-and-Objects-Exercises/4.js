function solve(name, age, weight, height) {
	let bmi = Math.round(weight / (height / 100) / (height / 100));
	
	let person = {};
	
	person.name = name;
	let personalInfo = {};
	personalInfo.age = age;
	personalInfo.weight = weight;
	personalInfo.height = height;
	
	person.personalInfo = personalInfo;
	person.BMI = bmi;
	
	
	let status = (bmi < 18.5) ? 'underweight'
			: (bmi < 25) ? 'normal'
					: (bmi < 30) ? 'overweight'
							: 'obese';
	person.status = status;
	
	if(bmi >= 30){
		person.recommendation = 'admission required';
	}
	
	return person;
}