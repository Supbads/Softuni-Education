// function problem1(arr){
//    let delimiter = arr.pop();
//
//    console.log(arr.join(delimiter))
// }

// function problem2(arr){
//    let step = Number(arr.pop());
//
//    for (let i = 0; i < arr.length; i+=step) {
//       console.log(arr[i]);
//    }
// }


// function problem3(arr){
//    let numbersArr = [];
//
//    let currentValue = 1;
//
//    //numbersArr.push(initialValue);
//
//    while(arr.length>0){
//       let command = arr.shift();
//
//       if(command === 'add'){
//          numbersArr.push(currentValue);
//       }else{
//          numbersArr.pop();
//
//       }
//
//       currentValue++;
//    }
//
//
//    if(numbersArr.length === 0){
//       console.log('Empty');
//       return;
//    }
//
//    for (let i = 0; i < numbersArr.length; i++) {
//       console.log(numbersArr[i]);
//    }
// }

// function problem4(arr){
//    let numberOfRotations = Number(arr.pop()) % arr.length;
//
//    let newArr = [];
//
//    for (let i = 0; i < arr.length; i++) {
//       newArr[(i + numberOfRotations)% arr.length] = arr[i];
//    }
//
//    console.log(newArr.join(' '));
// }

// function problem5(arr){
//    let currentElement = arr.shift();
//
//    let sequance = [];
//    sequance.push(currentElement);
//
//    for (let i = 0; i < arr.length; i++) {
//       if(arr[i] >= currentElement){
//          sequance.push(arr[i]);
//          currentElement = arr[i];
//       }
//    }
//
//    for (let i = 0; i < sequance.length; i++) {
//       console.log(sequance[i]);
//    }
// }

// function problem6(arr){
//    arr = arr.sort((a,b) => {
//       let aLength = a.length;
//       let bLength = b.length;
//
//       if(aLength < bLength){
//          return -1;
//       }else if(aLength > bLength){
//          return 1;
//       }
//
//       return strCompare(a,b);
//    });
//
//
//    for (let i = 0; i < arr.length; i++) {
//        console.log(arr[i]);
//     }
//
//    function strCompare(a, b)
//    {
//       return (a < b ? -1:(a > b ? 1 : 0));
//    }
// }
//problem6(['a', 'aa', 'b', 'bc', 'bb', 'c']);

// function problem7(matrix){
//    let controlSum = 0;
//
//    for (let i = 0; i < matrix[0].length; i++) {
//       controlSum += matrix[0][i];
//    }
//
//    for (let i = 1; i < matrix.length; i++) {
//       let currentRowSum = 0;
//       for (let j = 0; j < matrix[i].length; j++) {
//          currentRowSum += matrix[i][j];
//       }
//
//       if(controlSum !== currentRowSum){
//          return false;
//       }
//    }
//
//    for (let j = 0; j < matrix[0].length; j++) {
//       let currentColSum = 0;
//       for (let i = 0; i < matrix.length; i++) {
//          currentColSum += matrix[i][j];
//       }
//
//       if(controlSum !== currentColSum){
//          return false;
//       }
//    }
//
//    return true;
// }


function problem8(rows, cols){ //spiral matrix
   let matrix = fillZeros(rows, cols);
   fillMatrix(matrix, 0, 0, 1);
   printMatrix(matrix);
   
   function fillMatrix(matrix, currentRow, currentCol, counter) {
      if (matrix[currentRow][currentCol] !== 0) {
         return matrix;
      }
      
      // fill Top Row rightwards
      for (let col = currentCol; col < rows - currentRow; col++) {
         matrix[currentRow][col] = counter++;
      }
      
      // fill Right colum downwards
      for (let row = 1 + currentRow; row < cols - currentCol; row++) {
         matrix[row][rows - 1 - currentRow] = counter++;
      }
      
      // fill Bottom leftwards
      for (let col = cols - 2 - currentCol; col >= currentCol; col--) {
         matrix[rows - 1 - currentRow][col] = counter++;
      }
      
      // fill Left column upwards
      for (let row = rows - 2 - currentRow; row > currentRow; row--) {
         matrix[row][currentCol] = counter++;
      }
      
      fillMatrix(matrix, ++currentRow, ++currentCol, counter);
   }
   function printMatrix(matrix) {
      console.log(matrix.map(el => el.join(" ")).join('\n'))
   }
   function fillZeros(rows, cols) {
      let matrix = [];
      for (let i = 0; i < rows; i++) {
         matrix.push('0'.repeat(cols).split('').map(Number));
      }
      return matrix;
   }
}
problem8(5,5);


// function problem9(input){ //diagonal attack
//    let matrix = input.map(r => r.split(' ').map(Number));
//    let firstDiagonalSum = 0;
//
//    let pairs = {};
//
//    for (let i = 0; i < matrix.length; i++) {
//       firstDiagonalSum += matrix[i][i];
//    }
//
//    let secondDiagonalSum = 0;
//
//    let controlj = 0;
//    for (let i = matrix.length - 1; i >=0; i--) {
//       secondDiagonalSum += matrix[i][controlj];
//
//       pairs[i] = controlj;
//       controlj++;
//    }
//
//    if(firstDiagonalSum !== secondDiagonalSum){
//       printMatrix(matrix);
//
//       return;
//    }
//
//    for (let i = 0; i < matrix.length; i++) {
//       for (let j = 0; j < matrix[i].length; j++) {
//          if(i === j){
//             continue;
//          }
//
//          if(pairs[i] !== undefined && pairs[i] ===j){
//             continue;
//          }
//
//          matrix[i][j] = firstDiagonalSum;
//       }
//    }
//
//    printMatrix(matrix);
//
//    function printMatrix(matrix) {
//       for (let i = 0; i < matrix.length; i++) {
//          console.log(matrix[i].join(' '));
//       }
//    }
// }

// problem9(['5 3 12 3 1',
//    '11 4 23 2 5',
//    '101 12 3 21 10',
//    '1 4 5 2 2',
//    '5 22 33 11 1']
// );

// function problem10(arr){ //orbit
//    let [rows, cols, starRow, starCol] = arr;
//
//    let matrix = fillZeros(rows, cols);
//
//
//    let topHighestWave = starRow + 1;
//    let bottomHighestWave = rows - starRow;
//
//    let leftHighestWave = starCol + 1;
//    let rightHighestWave = starCol - starCol;
//
//    // let verticalSpace = Math.max(starRow, rows -1 -starRow);
//    // let horizontalSpace = Math.max(starCol, cols - 1 - starCol);
//
//    let largestWave = Math.max(topHighestWave, bottomHighestWave, leftHighestWave, rightHighestWave);
//    let currentWave = 1; //there will be an offset of 1
//
//    matrix[starRow][starCol] = 1;
//
//
//    //not drawing for -1 or matrix.length
//    while(currentWave + 1 <= largestWave) {
//       let topIndex = Math.max(starRow - currentWave, -1);
//
//       let bottomIndex = Math.min(starRow + currentWave, matrix.length);
//
//
//       let leftIndex = Math.max(starCol - currentWave, -1);
//
//
//       let rightIndex = Math.min(starCol + currentWave, matrix.length ); //i sure hope it's a matrix
//
//
//       if(topIndex >= 0) { // should draw top
//          let startLeftIndex = Math.max(leftIndex, 0);
//          let endRightIndex = Math.min(rightIndex, matrix.length - 1);
//
//          for (let i = startLeftIndex; i <= endRightIndex; i++) {
//             matrix[topIndex][i] = currentWave + 1;
//          }
//       }
//
//       if (bottomIndex < matrix.length) { // should draw bottom
//          let startLeftIndex = Math.max(leftIndex, 0);
//          let endRightIndex = Math.min(rightIndex, matrix.length - 1);
//
//          for (let i = startLeftIndex; i <= endRightIndex; i++) {
//             matrix[bottomIndex][i] = currentWave + 1;
//          }
//       }
//
//       if(leftIndex >= 0){ //should draw left
//          let startTopIndex = Math.max(topIndex, 0);
//          let endBottomIndex = Math.min(bottomIndex, matrix.length - 1);
//
//          for (let i = startTopIndex; i <= endBottomIndex; i++) {
//             matrix[i][leftIndex] = currentWave + 1;
//          }
//       }
//
//       if(rightIndex < matrix.length){ // should draw right
//          let startTopIndex = Math.max(topIndex, 0);
//          let endBottomIndex = Math.min(bottomIndex, matrix.length - 1);
//
//          for (let i = startTopIndex; i <= endBottomIndex; i++) {
//             matrix[i][rightIndex] = currentWave + 1;
//          }
//       }
//
//       currentWave++;
//    }
//
//    for (let i = 0; i < matrix.length; i++) {
//       console.log(matrix[i].join(' '));
//    }
//
//
//    function fillZeros(rows, cols) {
//       let matrix = [];
//       for (let i = 0; i < rows; i++) {
//          matrix.push('0'.repeat(cols).split('').map(Number));
//       }
//       return matrix;
//    }
// }
//problem10([5, 5, 2, 2]);