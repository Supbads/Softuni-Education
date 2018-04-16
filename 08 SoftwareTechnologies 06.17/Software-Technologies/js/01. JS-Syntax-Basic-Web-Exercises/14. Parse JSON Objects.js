function start(input){
    let arr = [];

    for (let i = 0; i < input.length; i++) {
        let currentLine = input[i];

        let parsedData = JSON.parse(currentLine);

        for (let key in parsedData) {
            console.log(capitalizeFirstLetter(key) + ": " + parsedData[key])

        }

    }

    function capitalizeFirstLetter(string) {
        return string.charAt(0).toUpperCase() + string.slice(1);
    }

}


//start(['{"name":"Gosho","age":10,"date":"19/06/2005"}', '{"name":"Tosho","age":11,"date":"04/04/2005"}']);