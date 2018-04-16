function start(input){
    let repo = [];

    for (let i = 0; i < input.length; i++) {
        let args = input[i].split(' -> ');

        let name = args[0];
        let age = args[1];
        let grade = args[2];

        repo.push({'name':name, 'age':age, 'grade':grade});
        //repo.push([name, age, grade]);
    }

    for(let person of repo){
        console.log('Name: ' + person.name);
        console.log('Age: ' + person.age);
        console.log('Grade: ' + person.grade);

    }


}
start(['Pesho -> 13 -> 6.00']);