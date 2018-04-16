function start (input){

    for (let i = 0; i < input.length; i++) {
        let currentLine = input[i];
        if(currentLine === 'Stop'){
            break;
        }

        console.log(currentLine);
    }
}