function start(input){
    let n = Number(input[0]);

    let arr = [];

    for (let i = 1; i < input.length; i++) {
        let splittedInput = input[i].split(' - ');
        let index = Number(splittedInput[0]);
        let value = Number(splittedInput[1]);

        arr[index] = value;
    }

    for (let i = 0; i < n; i++) {
        if(arr[i] === undefined){
            console.log(0);
        }
            else{
            console.log(arr[i]);
        }

    }
}

//start(['3', '0 - 5', '1 - 6', '2 - 7']);
start(['2', '0 - 5', '0 - 6', '0 - 7']);