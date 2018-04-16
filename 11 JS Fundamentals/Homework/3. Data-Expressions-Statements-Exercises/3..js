// function problem1(input){
//     console.log(`Hello, ${input}, I am JavaScript!`);
// }

// function problem2(a,b){
//     console.log(a*b);//area
//     console.log(2*a+2*b);//perimeter
// }

// function problem3(arr){
//     let v1 = Number(arr[0]); //speed km/h
//     let v2 = Number(arr[1]); //speed km/h
//     let time = Number(arr[2]); //time in seconds
//     time = time/3600;
//
//     let s1 = v1 * time;
//     let s2 = v2 * time;
//     let distance = Math.abs(s1-s2);
//     console.log(distance * 1000); //distance in meters
// }

// function problem4(arr){
//     let x1 = Number(arr[0]);
//     let y1 = Number(arr[1]);
//     let z1 = Number(arr[2]);
//     let x2 = Number(arr[3]);
//     let y2 = Number(arr[4]);
//     let z2 = Number(arr[5]);
//
//     let distance = Math.sqrt(Math.abs(Math.pow(x2-x1, 2) + Math.pow(y2 - y1, 2) + Math.pow(z2 - z1, 2)));
//
//     console.log(distance);
// }

// function problem5(grads){
//     grads = grads % 400;
//
//     while(grads < 0){
//         grads += 400;
//     }
//
//     let gradsToRads = 360 / 400;
//
//     let rads = grads * gradsToRads;
//
//     console.log(rads);
// }

// function problem6(arr){
//     let principalSum = arr[0];
//     let interestRate = arr[1]; // in %
//     let compoundingPeriod = arr[2]; //in months
//     let totalTimeSpan = arr[3]; //in years
//
//     interestRate /= 100;
//     compoundingPeriod = 12/compoundingPeriod;
//
//     let result = principalSum * (Math.pow(1 + (interestRate / compoundingPeriod), compoundingPeriod*totalTimeSpan));
//     console.log(result);
// }


// function problem7(arr){
//     let number = arr[0];
//     let precision = Math.min(arr[1], 15);
//
//     let nAsString = number+'';
//     let length = nAsString.length;
//     if(nAsString.indexOf('.') !== -1){
//         length--;
//     }
//
//     if(length <= precision){
//         console.log(number);
//     }
//     else{
//         console.log(number.toFixed(precision));
//     }
// }


// function problem8(feet){
//     let firstPart = Math.floor(feet / 12);
//     let secondPart = feet % 12;
//
//     console.log(`${firstPart}'-${secondPart}"`);
// }


// function problem9(arr){
//     let trackName = arr[0];
//     let artistName = arr[1];
//     let duration = arr[2];
//
//     console.log(`Now Playing: ${artistName} - ${trackName} [${duration}]`);
// }


// function problem10(arr){
//     let fileLocation = arr[0];
//     let alternateText = arr[1];
//
//     console.log(`<img src="${fileLocation}" alt="${alternateText}">`);
// }


// function problem11(input){
//     console.log(parseInt(input, 2))
// }

// function problem12(arr){
//     //['name', 'Pesho', 'age', '23', 'gender', 'male']
//     let prop1 = arr[0];
//     let val1 = arr[1];
//     let prop2 = arr[2];
//     let val2 = arr[3];
//     let prop3 = arr[4];
//     let val3 = arr[5];
//
//     let newObj = {};
//     newObj[prop1] = val1;
//     newObj[prop2] = val2;
//     newObj[prop3] = val3;
//
//     console.log(newObj);
// }

// function problem13(dateArr){
//     //[17, 3, 2002]
//     let today = new Date();
//     // today.setDate(Number(dateArr[0]));
//     // today.setMonth();
//     today.setFullYear(Number(dateArr[2]), Number(dateArr[1]) - 1, Number(dateArr[0]));
//     let prevMonth = new Date(today.getFullYear(), today.getMonth(), 0);
//     console.log(prevMonth.getDate())
// }


// function problem14(inputArr){
//     let n1 = Number(inputArr[0]);
//     let n2 = Number(inputArr[1]);
//     let n3 = Number(inputArr[2]);
//
//     let arr = [];
//     arr.push(n1);
//     arr.push(n2);
//     arr.push(n3);
//
//     arr = arr.sort((a,b) => b - a);
//     console.log(arr[0]);
// }

// function problem15(arr){
//     let x = arr[0];
//     let y = arr[1];
//     let xMin = arr[2];
//     let xMax = arr[3];
//     let yMin = arr[4];
//     let yMax = arr[5];
//     //x, y, xMin, xMax, yMin, yMax
//     if(x >= xMin && x <= xMax && y >= yMin && y <= yMax){
//         console.log('inside');
//     }else{
//         console.log('outside');
//     }
//
// }

// function problem16(n){
//     let iterationsCount =  Math.ceil(n / 2);
//
//     let outputNum = 1;
//     for (let i = 0; i < iterationsCount ; i++) {
//         console.log(outputNum);
//         outputNum+=2;
//     }
// }

// function problem17(n){
//     for (let i = 1; i <= n; i++) {
//         console.log('$'.repeat(i));
//     }
//
// }

function problem18(arr){ // movies bullshit
    let megata = {'the godfather': [12, 10, 15, 12.5, 15, 25, 30],
        "schindler's list": [8.5, 8.5, 8.5, 8.5, 8.5, 15, 15],
        'casablanca': [8,8,8,8,8, 10, 10],
        'the wizard of oz': [10, 10, 10, 10, 10, 15, 15]
    };

    let movie = arr[0].toLowerCase();
    let day = arr[1].toLowerCase();

    switch(day){
        case "monday": day = 0;
        break;
        case "tuesday": day=1;
        break;
        case "wednesday": day=2;
        break;
        case "thursday": day=3;
        break;
        case "friday": day=4;
        break;
        case "saturday": day=5;
        break;
        case "sunday": day=6;
        break;
        default: day = -1;
    }

    if(day === -1 || megata[movie] === undefined){
        console.log("error");
        return;
    }

    console.log(megata[movie][day]);
}

problem18(['The Godfather', 'Friday']);

// function problem19(a, b, c){
//     let D = Math.pow(b, 2) - 4*a*c;
//
//     if(D>0){ // 2 solutions
//         let x1 = (b*(-1) + Math.sqrt(D) ) / (a*2);
//         let x2 = (b*(-1) - Math.sqrt(D) ) / (a*2);
//
//         console.log(x2);
//         console.log(x1);
//
//     }else if(D === 0){//1 solution
//         let x = b*(-1) / (a*2);
//
//         console.log(x);
//     }else{
//         console.log('No');
//     }
// }


// function problem20(n){
//     let text = '<table border="1">\n';
//
//     text += '  <tr><th>x</th>';
//     for (let i = 1; i <= n; i++) {
//         text += `<th>${i}</th>`;
//     }
//     text += '</tr>\n';
//
//     for (let i = 1; i <= n; i++) {
//         let row = '  <tr>';
//
//         for (let j = 0; j <= n; j++) {
//             if(j === 0){
//                 row += `<th>${i}</th>`;
//             }else{
//                 row += `<td>${i*j}</td>`;
//             }
//
//         }
//
//         row += '</tr>\n';
//
//         text += row;
//     }
//     text += '</table>';
//
//     console.log(text)
// }


// function problem21(n){
//     if(n === 2){
//         console.log('+++');//either this or 9 +++
//         return;
//     }
//
//     let figure = '';
//
//     let symbolsPerLine = 2*n -1;
//     let horizontalDashes = (symbolsPerLine - 3) /2; // could be used for spaces
//     let verticalLinesPerSection = Math.floor((n-3) / 2);
//
//     figure += horisontalSection(horizontalDashes);
//
//     if(verticalLinesPerSection > 0){
//         for (let i = 0; i < verticalLinesPerSection; i++) {
//             figure += verticalDashSection(horizontalDashes);
//         }
//     }
//
//     figure += horisontalSection(horizontalDashes);
//
//     if(verticalLinesPerSection > 0){
//         for (let i = 0; i < verticalLinesPerSection; i++) {
//             figure += verticalDashSection(horizontalDashes);
//         }
//     }
//
//     figure += horisontalSection(horizontalDashes);
//
//     console.log(figure);
//
//     function verticalDashSection(dashCount) {
//         let section = '';
//         section += '|';
//         section += ' '.repeat(dashCount);
//         section += '|';
//         section += ' '.repeat(dashCount);
//         section += '|\n';
//
//         return section;
//     }
//
//     function horisontalSection(dashCount){
//         let section = '';
//         section += '+';
//         section += '-'.repeat(dashCount);
//         section += '+';
//         section += '-'.repeat(dashCount);
//         section += '+\n';
//
//         return section;
//     }
// }


function problem22(input){

}