function start(input){

    let arr = {};

    for (let i = 0; i < input.length; i++) {
        let args = input[i].split(' -> ');
        let key = args[0];
        let value = args[1];

        arr[key] = value;

        if(key === "grade" || key === "age"){
            let kuras = Math.round(Number(value));
            arr[key] = kuras;
        }
    }

    console.log(JSON.stringify(arr));
}


//start(['name -> Angel', 'surname -> Georgiev', 'age -> 20', 'grade -> 6.00', 'date -> 23/05/1995', 'town -> Sofia']);