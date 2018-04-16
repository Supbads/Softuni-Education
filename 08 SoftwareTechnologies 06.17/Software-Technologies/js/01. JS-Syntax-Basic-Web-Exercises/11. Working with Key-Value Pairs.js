function start(input) {

    let map = {};

    for (let i = 0; i < input.length - 1; i++) {
        let args = input[i].split(' ');

        let key = args[0];
        let value = args[1];

        map[key] = value;
    }
    //
    let searchKey = input[input.length-1];

    if(!(searchKey in map)){
        console.log('None')
    }
    else{
        console.log(map[searchKey]);
    }
}