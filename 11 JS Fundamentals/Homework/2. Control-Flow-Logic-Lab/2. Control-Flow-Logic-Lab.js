// function problem1(a,b){
//     console.log(a*b);
// }

// function problem2(nBottles, capacity){
//     console.log(Math.ceil(nBottles / capacity));
// }

// function problem3(year) {
//     let isLeapYear = true;
//     if((year % 4 === 0 && year % 100 !== 0) || (year % 400 === 0)){
//         isLeapYear = true;
//     }else {
//         isLeapYear = false;
//     }
//
//     console.log(isLeapYear ? 'yes' : 'no')
// }

// function problem4(radius) {
//     console.log(Math.PI * radius*radius);
//     console.log((Math.PI * radius*radius).toFixed(2));
// }

// function problem5(a,b,c) {
//     let p = (a+b+c) /2;
//     let area = Math.sqrt(p *(p-a) * (p-b) * (p-c));
//     console.log(area);
// }

// function problem6(r, h) {
//     let volume = Math.PI * r*r*h/3;
//     let area = Math.PI*r*(r + Math.sqrt(h*h + r*r));
//     console.log(`volume = ${volume}`);
//     console.log(`area = ${area}`);
// }

// function problem7(n) {
//     if(n % 1 !== 0){
//         console.log('invalid');
//         return;
//     }
//
//     if(n%2===0){
//         console.log('even');
//     }else{
//         console.log('odd');
//     }
// }

// function problem8(food) {
//     let fruits = ['banana', 'apple', 'kiwi', 'cherry', 'lemon', 'grapes', 'peach'];
//     let vegetables = ['tomato', 'cucumber', 'pepper', 'onion', 'garlic', 'parsley'];
//
//     let isfruit = fruits.includes(food);
//
//     if(isfruit){
//         console.log('fruit');
//         return;
//     }
//
//     if(vegetables.includes(food)){
//         console.log('vegetable');
//         return;
//     }
//
//     console.log('unknown');
// }

// function problem9(n) {
//     let text = '';
//     text += '<ul>';
//     for (let i = 1; i <= n; i++) {
//         let color = 'green';
//         if(i % 2 === 0){
//             color = 'blue';
//         }
//         let li = `    <li><span style=\'color:${color}\'>${i}</span></li>`;
//
//         text += li;
//     }
//
//     text += '</ul>';
//
//     console.log(text);
// }

/*
function problem10(n) {
    let chessboard = '<div class="chessboard">\n';
    for (let i = 0; i < n; i++) {
        chessboard += '    <div>\n';

        for (let j = 0; j < n; j++) {
            let color = (i + j) % 2 === 0 ? 'black' : 'white';

            let span = `        <span class="${color}"></span>\n`;
            chessboard += span;
        }

        chessboard += '    </div>\n';
    }

    chessboard += '</div>\n';

    console.log(chessboard);
}
*/

// function problem11(arr) {
//     for (let num of arr) {
//         console.log(Math.log2(num));
//     }
// }

// function problem12(n) {
//     if(n < 2){
//         return false;
//     }
//
//     let sqrtNum = Math.floor(Math.sqrt(n));
//     let isPrime = n !== 1;
//     for(let i = 2; i < sqrtNum + 1; i++) {
//         if(n % i === 0) {
//             isPrime = false;
//             break;
//         }
//     }
//
//     console.log(isPrime);
// }