function solve(arr){
   arr = arr.map(Number);
   
   let biggestProduct = Number.NEGATIVE_INFINITY;
   
   for (let i = 0; i < arr.length; i++) {
      let currentNumber = arr[i];
   
      if(currentNumber > 0 && currentNumber < 10){
         
         let currentProduct = 1;
         for (let j = i + 1; j < arr.length && j <= i + currentNumber; j++) {
            currentProduct *= arr[j];
         }
         
         if(biggestProduct < currentProduct){
            biggestProduct = currentProduct;
         }
      }
   }
   
   console.log(biggestProduct);
   
}
solve([
'10',
'20',
'2',
'30',
'44',
'3',
'56',
'20',
'24'
]);