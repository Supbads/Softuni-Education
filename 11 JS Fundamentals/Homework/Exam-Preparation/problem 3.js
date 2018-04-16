function solve(arr) {
   let key = arr[0];
   
   let regex = new RegExp(`(\\s|^)(${key}\\s+)([!%$#A-Z]{8,})(\\.|\\,|\\s|$)`, 'gi');
   
   for (let i = 1; i < arr.length; i++) {
      let currentLine = arr[i];
      
      let match = regex.exec(currentLine);
      
      while(match){
         if(match[3].toUpperCase() === match[3]){
            let escapedGroup = match[3].toLowerCase().replace(/!/g, '1');
            escapedGroup = escapedGroup.replace(/%/g, '2');
             escapedGroup = escapedGroup.replace(/#/g, '3');
             escapedGroup = escapedGroup.replace(/\$/g, '4');
             
             let escapedmatch = match[1] + match[2] + escapedGroup+match[4];
             //let escapedmatch = match[0].replace(match[3], escapedGroup);
            
            currentLine = currentLine.replace(match[0], escapedmatch);
         }
         
         match = regex.exec(currentLine);
      }
      
      console.log(currentLine);
   }
}

solve([
'specialKey',
'In this text the specialKey HELLOWORLD! is correct, but',
'the following specialKey $HelloWorl#d and spEcIaLKEy HOLLOWORLD1 are not, while',
'SpeCIaLkeY   SOM%%ETH$IN and dSpeCIaLkeY   SOM%%ETH$IN  are!'
]);