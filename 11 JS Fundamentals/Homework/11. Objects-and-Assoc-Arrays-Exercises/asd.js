// function problem1(arr){
//
//    let data = [];
//
//    for (let i = 0; i < arr.length; i++) {
//       let line = arr[i];
//
//       let lineArgs = line.split(/\s*\/\s*/g);
//
//       let name = lineArgs[0];
//       let level = Number(lineArgs[1]);
//       let items = [];
//       if(lineArgs.length > 2){
//          items =  lineArgs[2].split(/\s*,\s*/g);
//       }
//
//       let hero = {
//          'name': name,
//          'level': level,
//          'items': items
//       };
//
//       data.push(hero);
//    }
//
//    console.log(JSON.stringify(data));
// }
// problem1(['Isacc / 25 / Apple, GravityGun',
// 'Derek / 12 / BarrelVest, DestructionSword',
// 'Hes / 1 / Desolator, Sentinel, Antara']);

// function problem2(arr){
//    let text = '<table>\n';
//
//    for (let i = 0; i < arr.length; i++) {
//       let line = arr[i];
//       let object = JSON.parse(line);
//
//       text += '\t<tr>\n';
//       text += `\t\t<td>${object['name']}</td>\n`;
//       text += `\t\t<td>${object['position']}</td>\n`;
//       text += `\t\t<td>${object['salary']}</td>\n`;
//
//       text += '\t<tr>\n';
//    }
//
//    text += '</table>';
//
//    console.log(text);
// }

// function problem3(arr){
//    let map = new Map();
//
//    let formedBottles = {};
//
//    for (let i = 0; i < arr.length; i++) {
//       let currentLine = arr[i];
//
//       let args = currentLine.split(' => ');
//
//       let product = args[0];
//       let quantity = Number(args[1]);
//
//       if(!map.has(product)){
//          map.set(product, 0);
//       }
//
//       map.set(product, map.get(product) + quantity);
//
//       let totalQuantityForCurrentProduct = map.get(product);
//       if(totalQuantityForCurrentProduct >= 1000 && !formedBottles.hasOwnProperty(product)){
//          formedBottles[product] = 0;
//       }
//
//    }
//
//    for (let product of Object.keys(formedBottles)) {
//       let quantity = map.get(product);
//       let bottles = Math.floor( quantity / 1000);
//
//       if(bottles>1){
//          console.log(`${product} => ${bottles}`);
//       }
//    }
// }

// function problem4(arr){
//    let data = {};
//    //name : price
//    let products = arr
//        .map(e => {
//           let tokens = e.split(' : ');
//           return { name: tokens[0], price: Number(tokens[1]) }
//        })
//        .sort((a, b) => a.name.toUpperCase() < b.name.toUpperCase() ? -1
//            : a.name.toUpperCase() > b.name.toUpperCase() ? 1 : 0);
//
//    if (products.length < 1) {
//       return '';
//    }
//
//    let lastLetter = products[0].name[0].toUpperCase();
//    let catalog = lastLetter + '\n';
//    let ident = '  ';
//
//    for (let i = 0; i < products.length; i++) {
//       let currentLetter = products[i].name[0].toUpperCase();
//       if (currentLetter !== lastLetter) {
//          catalog += currentLetter + '\n';
//          lastLetter = currentLetter;
//       }
//
//       catalog += `${ident}${products[i].name}: ${products[i].price}\n`
//    }
//
//    return catalog;
// }

// function problem5(arr){
//
//    let carsAndMap = new Map();
//    // brand -> model -> count
//
//    for (let line of arr) {
//       let args = line.split(' | ');
//
//       let brand = args[0];
//       let model = args[1];
//       let count = Number(args[2]);
//
//       if(!carsAndMap.has(brand)){
//          carsAndMap.set(brand, new Map());
//       }
//
//       if(!carsAndMap.get(brand).has(model)){
//          carsAndMap.get(brand).set(model, 0);
//       }
//
//       carsAndMap.get(brand).set(model, carsAndMap.get(brand).get(model) + count);
//    }
//
//
//    for (let [brand, map] of carsAndMap) {
//       console.log(brand);
//       for (let [model, count] of map) {
//          console.log(`###${model} -> ${count}`);
//       }
//    }
// }
// problem5([
// 'Audi | Q7 | 1000',
// 'Audi | Q6 | 100',
// 'BMW | X5 | 1000',
// 'BMW | X6 | 100',
// 'Citroen | C4 | 123',
// 'Volga | GAZ-24 | 1000000',
// 'Lada | Niva | 1000000',
// 'Lada | Jigula | 1000000',
// 'Citroen | C4 | 22',
// 'Citroen | C5 | 10'
// ]);


// function problem6(arr){
//    let data = new Map();
//
//    //sites -> components -> subcomponents
//    //map.size -> case insensitive
//    //Systems: Amount of components, in descending order, as first criteria, and by alphabetical order as second criteria.
//    //Components:  ordered by amount of Subcomponents, in descending order.
//
//    for (let line of arr) {
//       let args = line.split(' | ');
//
//       let system = args[0];
//       let component = args[1];
//       let subcomponent = args[2];
//
//       if(!data.has(system)){
//          data.set(system, new Map());
//       }
//
//       if(!data.get(system).has(component)){
//          data.get(system).set(component, []);
//       }
//
//       data.get(system).get(component).push(subcomponent);
//    }
//
//    let systemsOrder = [...data.keys()].sort((a, b) => {
//       let numberOfAComponents = data.get(a).size;
//       let numberOfBComponents = data.get(b).size;
//
//       if(numberOfAComponents > numberOfBComponents){
//          return -1;
//       }
//       else if(numberOfAComponents < numberOfBComponents){
//          return 1;
//       }
//
//       if(a <= b){
//          return -1
//       }else{
//          return 1;
//       }
//    });
//
//    for (let system of systemsOrder) {
//       console.log(system);
//       //log
//       let currentSystemComponents = data.get(system);
//
//       let componentKeys = [...currentSystemComponents.keys()].sort((a,b) => {
//          let subComponentsACount = currentSystemComponents.get(a).length;
//          let subComponentsBCount = currentSystemComponents.get(b).length;
//
//          if(subComponentsACount >= subComponentsBCount){
//             return -1;
//          }else{
//             return 1;
//          }
//       });
//
//       for (let component of componentKeys) {
//          console.log(`|||${component}`);
//
//          let subComponents = currentSystemComponents.get(component);
//
//          for (let subComponent of subComponents) {
//             console.log(`||||||${subComponent}`);
//          }
//
//       }
//    }
// }
// problem6([
// 'SULS | Main Site | Home Page',
// 'SULS | Main Site | Login Page',
// 'SULS | Main Site | Register Page',
// 'SULS | Judge Site | Login Page',
// 'SULS | Judge Site | Submittion Page',
// 'Lambda | CoreA | A23',
// 'SULS | Digital Site | Login Page',
// 'Lambda | CoreB | B24',
// 'Lambda | CoreA | A24',
// 'Lambda | CoreA | A25',
// 'Lambda | CoreC | C4',
// 'Indice | Session | Default Storage',
// 'Indice | Session | Default Security'
// ]);

// function problem7(arr){ // usernames
//
//    let data = {};
//
//    for (let name of arr) {
//
//       if(!data.hasOwnProperty(name)){
//          data[name] = 0;
//       }
//    }
//
//    let sortedKeys = Object.keys(data).sort((a,b) => {
//       return a.length < b.length ? -1 : a.length > b.length ? 1 : a.toUpperCase() < b.toUpperCase() ? -1 : a.toUpperCase() > b.toUpperCase() ? 1 : 0
//    });
//
//    console.log(sortedKeys.join('\n'))
// }
// problem7([
// 'Ashton',
// 'Kutcher',
// 'Ariel',
// 'Lilly',
// 'Keyden',
// 'Aizen',
// 'Billy',
// 'Braston'
// ]);

function problem8(params) {
   Set.prototype.containsArray = function (array) {
      let matrix = [...this];
      
      for (let i = 0; i < matrix.length; i++) {
         if (matrix[i].length !== array.length) {
            continue;
         }
         
         let areEqual = true;
         for (let j = 0; j < matrix[i].length; j++) {
            if (!matrix[i].includes(array[j])) {
               areEqual = false;
               break;
            }
         }
         
         if (areEqual) {
            return true;
         }
      }
      
      return false;
   };
   
   let unique = new Set();
   
   for (const row of params) {
      let arr = JSON.parse(row);
      if (!unique.containsArray(arr)) {
         unique.add(arr);
      }
   }
   
   console.log([...unique]
       .sort((a, b) => a.length - b.length)
       .map(a => a.sort((a, b) => b - a))
       .map(a => `[${a.join(', ')}]`)
       .join('\n')
   );
}

problem8(
    ['[7.14, 7.180, 7.339, 80.099]',
       '[7.339, 80.0990, 7.140000, 7.18]',
       '[7.339, 7.180, 7.14, 80.099]']
);
