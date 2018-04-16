// function problem1(arr) {
//     // x 10 -> 50
//     // y 20 -> 80
//     // z 15 -> 50
//
//     for (let i = 0; i < arr.length; i+=3) {
//         if(arr[i] === undefined){
//             return;
//         }
//         let x = arr[i];
//         let y = arr[i+1];
//         let z = arr[i+2];
//
//         let withinXCoords = x <= 50 && x >= 10;
//         let withinYCoords = y <= 80 && y >=20;
//         let withinZCoords = z <= 50 && z >= 15;
//         let isPointInside3dObject = withinXCoords && withinYCoords && withinZCoords;
//
//         console.log(isPointInside3dObject ? 'inside' : 'outside');
//     }
// }

// function problem2(arr) {
//     let benchmarks = {
//         'motorway' : 130,
//         'interstate' : 90,
//         'city' : 50,
//         'residential' : 20,
//
//     };
//
//     let speed = arr[0];
//     let area = arr[1];
//
//     let areaSpeedLimit = benchmarks[area];
//
//     let difference = speed - areaSpeedLimit;
//
//     if(difference > 40){
//         console.log('reckless driving');
//     }else if (difference > 20){
//         console.log('excessive speeding');
//     }else if(difference > 0){
//         console.log('speeding');
//     }
// }

// function problem3(arr) {
//     let text = '<?xml version="1.0" encoding="UTF-8"?>\n<quiz>\n';
//     for (let i = 0; i < arr.length; i+=2) {
//         if(arr[i] === undefined){
//             return;
//         }
//         let q = arr[i];
//         let a = arr[i + 1];
//
//         let QnA = `  <question>\n    ${q}\n  </question>\n  <answer>\n    ${a}\n  </answer>\n`;
//         text += QnA;
//     }
//     text += '</quiz>';
//     console.log(text);
// }

// function problem4(arr) {
//     let n = arr[0];
//     for (let i = 1; i < arr.length; i++) {
//         let currentCommand = arr[i];
//         switch(currentCommand){
//             case 'chop':
//                 n /= 2;
//                 break;
//             case 'dice':
//                 n = Math.sqrt(n);
//                 break;
//             case 'spice':
//                 n+=1;
//                 break;
//             case 'bake':
//                 n*=3;
//                 break;
//             case 'fillet':
//                 n = n*80/100;
//                 break;
//         }
//
//         console.log(n);
//     }
// }

// function problem5(n) {
//     let numAsStr = n.toString();
//     let sum = sumDigits(numAsStr);
//     while (sum /numAsStr.length <= 5){
//         numAsStr += '9';
//         sum = sumDigits(numAsStr);
//     }
//     console.log(numAsStr);
//     function sumDigits(numAsStr) {
//         let sum = 0 ;
//         for(let digit of numAsStr){
//             sum += Number(digit);
//         }
//         return sum;
//     }
// }

// function problem6(arr) {
//     let x1 = arr[0];
//     let y1 = arr[1];
//     let x2 = arr[2];
//     let y2 = arr[3];
//
//     let firstPointToMiddle = pythagorasTheorem(x1, y1, 0, 0);
//     let secondPointToMiddle = pythagorasTheorem(x2, y2, 0, 0);
//     let firstPointToSecondPoint = pythagorasTheorem(x1, y1, x2, y2);
//
//     let isFirstToMiddleInteger = firstPointToMiddle === parseInt(firstPointToMiddle, 10);
//     let isSecondToMiddleInteger = secondPointToMiddle === parseInt(secondPointToMiddle, 10);
//     let isFirstToSecondInteger = firstPointToSecondPoint === parseInt(firstPointToSecondPoint, 10);
//     console.log(`{${x1}, ${y1}} to {0, 0} is ${isFirstToMiddleInteger ? 'valid' : 'invalid'}`);
//     console.log(`{${x2}, ${y2}} to {0, 0} is ${isSecondToMiddleInteger ? 'valid' : 'invalid'}`);
//     console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is ${isFirstToSecondInteger ? 'valid' : 'invalid'}`);
//
//     function pythagorasTheorem(a1,b1,a2,b2) {
//         return Math.sqrt((a1-a2)*(a1-a2) + (b1-b2) * (b1-b2));
//     }
// }

// noinspection SpellCheckingInspection
// function problem7(arr) {
//     // Tuvalu -> 1 - 3  : 1 - 3
//     // Tonga -> 0 - 2 : 6 - 8
//     // Samoa -> 5 - 7 : 3 - 6
//     // Tokelau -> 8 - 9 : 0 - 1
//     // Cook -> 4 - 9 : 7 - 8
//     for (let i = 0; i < arr.length; i+=2) {
//         if(arr[i] === undefined){
//             return;
//         }
//
//         let x = arr[i];
//         let y = arr[i+1];
//
//         let checkTuvalu = x <= 3 && x >= 1 && y <= 3 && y >= 1;
//         if(checkTuvalu){
//             console.log('Tuvalu');
//             continue;
//         }
//
//         let checkTonga = x <= 2 && x >= 0 && y <= 8 && y >= 6;
//         if(checkTonga){
//             console.log('Tonga');
//             continue;
//         }
//
//         let checkSamoa = x <= 7 && x >= 5 && y <= 6 && y >= 3;
//         if (checkSamoa){
//             console.log('Samoa');
//             continue;
//         }
//
//         let checkTokelau = x <= 9 && x >= 8 && y <= 1 && y >= 0;
//         if(checkTokelau){
//             console.log('Tokelau');
//             continue;
//         }
//
//         let checkCook = x <= 9 && x >= 4 && y <= 8 && y >= 7;
//         if(checkCook){
//             console.log('Cook');
//             continue;
//         }
//
//         let notAnIsland = 'On the bottom of the ocean';
//         console.log(notAnIsland);
//     }
// }

// function problem8(arr) {
//     let x1 = arr[0];
//     let y1 = arr[1];
//     let x2 = arr[2];
//     let y2 = arr[3];
//     let x3 = arr[4];
//     let y3 = arr[5];
//
//     // try 1->2->3
//     // try 1->3->2
//     // try 2->1->3
//     // compare results
//
//     let distanceOneTwo = pythagorasTheorem(x1,y1,x2,y2);
//     let distanceOneThree = pythagorasTheorem(x1,y1,x3,y3);
//     let distanceTwoThree = pythagorasTheorem(x2,y2,x3,y3);
//
//     let distanceOneTwoThree = distanceOneTwo + distanceTwoThree;
//     let distanceOneThreeTwo = distanceOneThree + distanceTwoThree;
//     let distanceOTwoOneThree = distanceOneTwo + distanceOneThree;
//
//     let optimalRoute = Math.min(distanceOneTwoThree,distanceOneThreeTwo, distanceOTwoOneThree);
//
//     if(optimalRoute === distanceOneTwoThree){
//         console.log(`1->2->3: ${distanceOneTwoThree}`);
//     }else if (optimalRoute === distanceOneThreeTwo){
//         console.log(`1->3->2: ${distanceOneThreeTwo}`);
//     }else { //distanceOTwoOneThree
//         console.log(`2->1->3: ${distanceOTwoOneThree}`);
//     }
//
//     function pythagorasTheorem(a1,b1,a2,b2) {
//         return Math.sqrt((a1-a2)*(a1-a2) + (b1-b2) * (b1-b2));
//     }
// }

// function problem9(arr) {
//     /*
//     ⦁	Cut – cuts the crystal in 4
//     ⦁	Lap – removes 20% of the crystal’s thickness
//     ⦁	Grind – removes 20 microns of thickness
//     ⦁	Etch – removes 2 microns of thickness
//     ⦁	X-ray – increases the thickness of the crystal by 1 micron; this operation can only be done once!
//     ⦁	Transporting and washing – removes any imperfections smaller than 1 micron (round down the number);
//          do this after every batch of operations that remove material
//     */
//
//     let target = arr[0];
//     for (let i = 1; i < arr.length; i++) {
//         console.log(`Processing chunk ${arr[i]} microns`);
//         let currentCrystal = arr[i];
//
//         let shouldWash = false;
//         let cutCount = 0;
//         while(currentCrystal / 4 >= target){
//             currentCrystal /= 4;
//             cutCount++;
//             shouldWash = true;
//         }
//
//         action('Cut', cutCount);
//
//         if(shouldWash){
//             currentCrystal = wash(currentCrystal);
//         }
//
//         shouldWash = false;
//         let lapCount = 0;
//         while(currentCrystal * 80/100 >= target){
//             currentCrystal =  currentCrystal*80/100;
//             lapCount++;
//             shouldWash = true;
//         }
//
//         action('Lap', lapCount);
//
//         if(shouldWash){
//             currentCrystal = wash(currentCrystal);
//         }
//
//         shouldWash = false;
//         let grindCount = 0;
//         while(currentCrystal - 20 >= target){
//             currentCrystal -= 20;
//             grindCount++;
//             shouldWash = true;
//         }
//
//         action('Grind', grindCount);
//
//         if(shouldWash){
//             currentCrystal = wash(currentCrystal);
//         }
//
//         shouldWash = false;
//         let etchCount = 0;
//         while(currentCrystal - 2 >= target || currentCrystal === (target + 1)){
//             currentCrystal -= 2;
//             etchCount++;
//             shouldWash = true;
//         }
//
//         action('Etch', etchCount);
//
//         if(shouldWash){
//             currentCrystal = wash(currentCrystal);
//         }
//
//         let xrayCount = 0;
//         if(currentCrystal < target){
//             currentCrystal += 1;
//             xrayCount++;
//         }
//         action('X-ray', xrayCount);
//
//         console.log(`Finished crystal ${currentCrystal} microns`);
//     }
//
//
//     function wash(crystal){
//         console.log('Transporting and washing');
//         return Math.floor(crystal);
//     }
//
//     function action(actionStr, times) {
//         if(times === 0){
//             return undefined;
//         }
//
//         console.log(`${actionStr} x${times}`);
//     }
// }

function problem10(n) {
    let dnaStr = 'ATCGTTAGGG';

    // i = 0 -> 0 dashes first
    /*
    **AT**
    *C--G*
    T----T
    *A--G*
    **GG**
    */
    //let width = (6 - 2) / 2; //2
    let letterIndex = 0;
    for (let i = 0; i < n; i++) {
        let firstLetter = dnaStr[(letterIndex++)%dnaStr.length];
        let secondLetter = dnaStr[(letterIndex++)%dnaStr.length];
        if(i%4 ===0){
            console.log(`**${firstLetter}${secondLetter}**`);
        }else if(i%4 === 1){
            console.log(`*${firstLetter}--${secondLetter}*`);
        }else if(i%4 === 2){
            console.log(`${firstLetter}----${secondLetter}`);
        }else {
            console.log(`*${firstLetter}--${secondLetter}*`);
        }


        // let asterisks = '*'.repeat(Math.abs(width - i%3));
        // let firstLetter = dnaStr[(letterIndex++)%dnaStr.length];
        // let secondLetter = dnaStr[(letterIndex++)%dnaStr.length];
        // let dashes = '-'.repeat(width - Math.abs(width - i%3));
        //
        // let line = `${asterisks}${firstLetter}${dashes}${dashes}${secondLetter}${asterisks}`;

        // console.log(line);
    }
}

problem10(12);