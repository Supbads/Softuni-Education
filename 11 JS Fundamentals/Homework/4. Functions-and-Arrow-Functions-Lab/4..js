// function problem1(n){
//     for (let i = 1; i <= n; i++) {
//         console.log('*'.repeat(i));
//     }
//     for (let i = n-1; i >0; i--) {
//         console.log('*'.repeat(i));
//
//     }
// }

// function problem2(n = 5) {
//     for (let i = 0; i < n; i++) {
//         let line = '';
//         for (let j = 0; j < n; j++) {
//             line += '* ';
//         }
//         console.log(line);
//     }
// }

// function problem3(str) {
//     for (let i = 0; i < str.length / 2; i++) {
//         if(str[i] !== str[str.length - 1 - i]){
//             console.log(false);
//             return;
//         }
//     }
//
//     console.log(true);
// }


// function problem4(str) {
//     switch(str){
//         case 'Monday':
//             console.log(1);
//             break;
//         case 'Tuesday':
//             console.log(2);
//             break;
//         case 'Wednesday':
//             console.log(3);
//             break;
//         case 'Thursday':
//             console.log(4);
//             break;
//         case 'Friday':
//             console.log(5);
//             break;
//         case 'Saturday':
//             console.log(6);
//             break;
//         case 'Sunday':
//             console.log(7);
//             break;
//         default:
//             console.log('error');
//             break;
//     }
// }

// function problem5(a,b,operator) {
//     switch(operator){
//         case '+':
//             console.log(a+b);
//             break;
//         case '-':
//             console.log(a-b);
//             break;
//         case '*':
//             console.log(a*b);
//             break;
//         case '/':
//             console.log(a/b);
//             break;
//     }
// }

// function problem6(arr) {
//     console.log(arr.reduce((a, b) => a + b,0));
//     console.log(arr.reduce((a, b) => a + 1/b, 0));
//
//     let appenedArr = "";
//     arr.forEach(function (item, index) {
//         appenedArr = appenedArr + "" + item;
//     });
//     console.log(appenedArr);
// }

// function problem7(str) {
//     let pattern = /[\w]+/g;
//
//     let output = str.match(pattern);
//
//     console.log(output.map(x => x.toUpperCase()).join(', '));
// }