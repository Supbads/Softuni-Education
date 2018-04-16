function start(input) {

    let map = [];

    for (let i = 0; i < input.length - 1; i++) {
        let args = input[i].split(' ');

        let key = args[0];
        let value = args[1];

        if(!(key in map)){
            map[key] = [];
        }

        map[key].push(value);
    }
    //
    let searchKey = input[input.length-1];

    if(!(searchKey in map)){
        console.log('None')
    }
    else{
        for (let value of map[searchKey]){
            console.log(value);

        }
    }
}
//start(['key value', 'key eulav', 'key']);