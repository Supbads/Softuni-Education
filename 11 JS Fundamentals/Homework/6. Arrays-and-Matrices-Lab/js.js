// function problem1(arr) {
//    let a = Number(arr[0]);
//    let b = Number(arr[arr.length-1]);
//
//    return a+b;
// }

// function problem2(arr) {
//    let str = '';
//    for (let i = 0; i < arr.length; i++) {
//       if(i%2===0){
//          str += arr[i] + ' ';
//       }
//    }
//    return str;
// }

// function problem3(arr) {
//    let resultArr = [];
//
//    for (let i = 0; i < arr.length; i++) {
//       let element = arr[i];
//       if(element >= 0){
//          resultArr.push(element);
//       }else{
//          resultArr.unshift(element);
//       }
//    }
//
//    for (let i = 0; i < resultArr.length; i++) {
//       console.log(resultArr[i]);
//    }
// }

// function problem4(arr) {
//    let n = arr.shift();
//    let firstNelements = '';
//    let lastNelements = '';
//
//    for (let i = 0; i < arr.length && i < n; i++) {
//       firstNelements += arr[i] + ' ';
//    }
//
//    for (let i = arr.length - n; i < arr.length; i++) {
//       lastNelements += arr[i] + ' ';
//    }
//
//    console.log(firstNelements.trim());
//    console.log(lastNelements.trim());
// }

// function problem5(n, k) {
//    let sequance = [];
//    sequance.push(1);
//
//    for (let i = 0; i < n - 1; i++) {
//          let currentElement = 0;
//       for (let j = i; j >= 0 && j > i - k; j--) {
//          currentElement += sequance[j];
//       }
//
//       sequance.push(currentElement);
//    }
//
//    for (let i = 0; i < sequance.length; i++) {
//       console.log(sequance[i]);
//    }
// }

// function problem6(arr) {
//    let newSequance = [];
//
//    for (let i = 0; i < arr.length; i++){
//       if(i % 2 ===1){
//          newSequance.unshift(arr[i] * 2);
//       }
//    }
//
//    console.log(newSequance.join(' '));
// }

// function problem7(arr) {
//    arr.sort((a,b) => a-b);
//
//    console.log(`${arr[0]} ${arr[1]}`);
// }

// function problem8(matrix) {
//    let dimentions = getDim(matrix);
//    let biggestElement = Number.NEGATIVE_INFINITY;
//    for (let i = 0; i < dimentions[0]; i++) {
//       for (let j = 0; j < dimentions[1]; j++) {
//          let element = matrix[i][j];
//          if(element > biggestElement){
//             biggestElement = element;
//          }
//       }
//    }
//
//    console.log(biggestElement);
//
//    function getDim(a) {
//       let dim = [];
//       while (true) {
//          dim.push(a.length);
//
//          if (Array.isArray(a[0])) {
//             a = a[0];
//          } else {
//             break;
//          }
//       }
//       return dim;
//    }
// }

// function problem9(matrix) {
//    let firstDiagonalSum = 0;
//
//    for (let i = 0; i < matrix.length; i++) {
//       firstDiagonalSum += matrix[i][i];
//    }
//
//    let secondDiagonalSum = 0;
//
//    let j = 0;
//    for (let i = matrix.length - 1; i >=0; i--) {
//       secondDiagonalSum += matrix[i][j];
//       j++;
//    }
//
//    console.log(firstDiagonalSum + ' ' + secondDiagonalSum)
// }


function problem10(matrix) {
   let totalNeighbors = 0;
   
   for (let i = 0; i < matrix.length; i++) {
      for (let j = 0; j < matrix[i].length; j++) {
         let element = matrix[i][j];

         //check right element
         let rightElementIndex = j + 1;
         if(rightElementIndex < matrix[i].length){
            if(matrix[i][rightElementIndex] === element){
               totalNeighbors++;
               //alreadyChecked[i][j] = true;
            }
         }
         
         //check bottom element
         let bottomElementIndex = i + 1;
         if(bottomElementIndex < matrix.length){
            if(matrix[bottomElementIndex][j] === element){
               totalNeighbors++;
               
            }
         }
      }
   }
   
   console.log(totalNeighbors);
}
problem10([['test', 'yes', 'yo', 'ho'],
   ['well', 'done', 'yo', '6'],
   ['not', 'done', 'yet', '5']]);