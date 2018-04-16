//Problem 1.
// function solve(a, b, c ){
//     a = Number(a);
//     b = Number(b);
//     c = Number(c);
//
//     return sum;
// }

//Problem 2.
// function solve(args){
//
//     let sum = 0;
//     let vat = 0;
//     for (let obj of args) {
//         sum += obj;
//
//         vat += obj *0.2;
//     }
//
//     console.log(`sum = ${sum}`);
//     console.log(`VAT = ${vat}`);
//     console.log(`total = ${sum + vat}`)
// }
//
// solve([1.20, 2.60, 3.50]);
// solve([3.12, 5, 18, 19.24, 1953.2262, 0.001564, 1.1445]);

//Problem 3.
// function solve(text, letter){
//     let count = 0;
//
//     for(let i = 0; i < text.length; i++){
//         if(text[i] === letter){
//             count++;
//         }
//     }
//
//     console.log(count);
// }

// solve('hello', 'l');
// solve('panther', 'n');

// Problem 4.
// function solve(minAge, firstName, firstAge, secondName, secondAge) {
//     let arr = [];
//
//     let firstPerson = {
//         name : firstName,
//         age : firstAge
//     };
//
//     let secondPerson = {
//         name : secondName,
//         age : secondAge
//     };
//
//     arr.push(firstPerson);
//     arr.push(secondPerson);
//
//     for (let obj of arr) {
//         if(obj.age >= minAge){
//             console.log(obj);
//         }
//     }
// }
//
// solve(12, 'Ivan', 15, 'Asen', 9);

//Problem 5.
// function solve(args){
//     let str = "";
//
//     let n = Number(args);
//
//     for (var i = 1; i <= n; i++) {
//         str += i;
//     }
//
//     console.log(str);
// }

//Problem 6.
// function solve(w, h, W, H) {
//
//     let doubleContedArea = Math.min(w, W) * Math.min(h, H);
//
//     let firstArea = H * W;
//     let secondArea = h * w;
//
//     console.log(firstArea+ secondArea - doubleContedArea);
// }

//Problem 7.
// function solve(y, m, d){
//     let daysToAdd = 1;
//     let date = new Date();
//     date.setFullYear(y, m - 1, d);
//
//     let dat = new Date(date);
//     dat.setDate(dat.getDate() + daysToAdd);
//
//     console.log(`${dat.getFullYear()}-${dat.getMonth() + 1}-${dat.getDate()}`);
// }

// function solve(y, m, d){
//     let date = new Date(y ,m -1 , d);
//     let oneDay = 24 * 60 * 60 * 1000;
//
//     let nextDay = new Date(date.getTime() + oneDay);
//
//     console.log(`${nextDay.getFullYear()}-${(nextDay.getMonth() + 1)}-${nextDay.getDate()}`);
// }
//solve(1, 1, 1);

//Problem 8.
function solve(x1,y1,x2,y2) {
    let distance = Math.sqrt(Math.abs(x1-x2) * Math.abs(x1-x2) + Math.abs(y1 - y2)*Math.abs(y1 - y2));

    console.log(distance);
}
solve(2, 4, 5, 0);