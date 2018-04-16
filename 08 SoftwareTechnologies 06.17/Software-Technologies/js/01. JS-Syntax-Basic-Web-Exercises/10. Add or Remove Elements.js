function start(input) {
    let arr = [];

    for (let i = 0; i < input.length; i++) {
        let currentLine = input[i];
        let args = currentLine.split(' ');

        let command = args[0];
        let value = Number(args[1]);

        if(command === 'add'){
            arr.push(value); //addlast
        }
        else{
            arr.splice(value, 1); //delete and rearrange
        }

    }

    for (let i = 0; i < arr.length; i++) {
        console.log(arr[i]);
    }

}
start(['add 3', 'add 5', 'add 7']);