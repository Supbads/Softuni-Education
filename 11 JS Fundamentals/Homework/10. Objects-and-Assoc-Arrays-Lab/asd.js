// function problem1(arr){
//    let firstLineArgs = arr.shift().split(/\|+/g).filter(x => x).map(x => x.trim());
//
//    let dataArr = [];
//
//    for (let i = 0; i < arr.length; i++) {
//       let currentLineArgs = arr[i].split(/\|+/g).filter(x => x).map(x => x.trim());
//
//       let object = {};
//
//       object[firstLineArgs[0]] = currentLineArgs[0];
//       object[firstLineArgs[1]] = Number(currentLineArgs[1]);
//       object[firstLineArgs[2]] = Number(currentLineArgs[2]);
//
//       dataArr.push(object);
//    }
//
//    let outputStr = JSON.stringify(dataArr);
//
//    console.log(outputStr);
// }
// problem1(['| Town | Latitude | Longitude |',
//    '| Sofia | 42.696552 | 23.32601 |',
//    '| Beijing | 39.913818 | 116.363625 |']
// );
//
// function problem2(jsonStr){
//    let objects = JSON.parse(jsonStr);
//
//    let output = '<table>\n';
//
//    output += '  <tr><th>name</th><th>score</th></tr>\n';
//
//    for (let i = 0; i < objects.length; i++) {
//       let currentObject = objects[i];
//
//       let escapedName = escapeHtml(currentObject['name']);
//       //let escapedScore = escapeHtml(currentObject['score']);
//
//       let currentLine = `  <tr><td>${escapedName}</td><td>${currentObject['score']}</td></tr>\n`;
//
//       output += currentLine;
//    }
//
//
//    output+= '</table>';
//
//    console.log(output);
//
//    function escapeHtml(unsafe) {
//       return unsafe
//           .replace(/&/g, "&amp;")
//           .replace(/</g, "&lt;")
//           .replace(/>/g, "&gt;")
//           .replace(/"/g, "&quot;")
//           .replace(/'/g, "&#39;");
//    }
// }
// problem2('[{"name":"Pesho","score":479},{"name":"Gosho","score":205}]');

// function problem3(jsonStr){
//    let objects = JSON.parse(jsonStr);
//
//    let output = '<table>\n';
//
//    let properties = [];
//
//    output+= '  <tr>';
//    for (let key in objects[0]) {
//       output += `<th>${key}</th>`;
//       properties.push(key);
//    }
//
//    output+= '</tr>\n';
//
//    for (let obj of objects) {
//       output+= '  <tr>';
//
//       for (let property of properties) {
//          let escaped = escapeHtml(obj[property].toString());
//
//          output += `<td>${escaped}</td>`;
//       }
//
//       output += '</tr>\n';
//    }
//
//    output += '</table>';
//
//    console.log(output);
//
//    function escapeHtml(unsafe) {
//       return unsafe
//           .replace(/&/g, "&amp;")
//           .replace(/</g, "&lt;")
//           .replace(/>/g, "&gt;")
//           .replace(/"/g, "&quot;")
//           .replace(/'/g, "&#39;");
//    }
// }
//problem3('[{"Name":"Tomatoes & Chips","Price":2.35},{"Name":"J&B Chocolate","Price":0.96}]');

// function problem4(arr){
//    let townsAndIncome = {};
//
//    let lastTown = '';
//    for (let i = 0; i < arr.length; i++) {
//       if(i%2 ===0){ //town
//          lastTown = arr[i];
//       }else{
//          if(townsAndIncome[lastTown] === undefined){
//             townsAndIncome[lastTown] = 0;
//          }
//
//          let income = Number(arr[i]);
//
//          townsAndIncome[lastTown] += income;
//       }
//    }
//
//    console.log(JSON.stringify(townsAndIncome));
// }
//problem4(['Sofia', '20', 'Varna', '3', 'Sofia', '5', 'Varna', '4']);

// function problem5(arr){
//    let entriesAndCount = {};
//
//    for (let i = 0; i < arr.length; i++) {
//       let currentLineArgs = arr[i].split(/\W+/g).filter(x => x);
//
//       for (let j = 0; j < currentLineArgs.length; j++) {
//          let currentWord = currentLineArgs[j];
//
//          if(entriesAndCount[currentWord] === undefined){
//             entriesAndCount[currentWord] = 0;
//          }
//
//          entriesAndCount[currentWord] += 1;
//       }
//    }
//
//    console.log(JSON.stringify(entriesAndCount));
// }
//
// function problem6(arr){
//    let entriesAndCount = new Map();
//
//    for (let i = 0; i < arr.length; i++) {
//       let currentLineArgs = arr[i].split(/\W+/g).filter(x => x).map(x => x.toLowerCase());
//
//       for (let j = 0; j < currentLineArgs.length; j++) {
//          let currentWord = currentLineArgs[j];
//
//          if(entriesAndCount.get(currentWord) === undefined){
//             entriesAndCount.set(currentWord, 0);
//          }
//
//          entriesAndCount.set(currentWord, entriesAndCount.get(currentWord) + 1);
//       }
//    }
//
//    let allWords = Array.from(entriesAndCount.keys()).sort();
//
//    allWords.forEach(w => console.log(`'${w}' -> ${entriesAndCount.get(w)} times`));
//
// }
// problem6(['Far too slow, you\'re far too slow.']);
// problem6(['The man was walking the dog down the road when it suddenly started barking against the other dog. Surprised he pulled him away from it.']);

// function problem7(arr){
//    let pattern = RegExp('(.*?)\\s<->\\s(.*)', 'g');
//
//    let townsAndPopulation = new Map();
//
//    for (let i = 0; i < arr.length; i++) {
//       let currentLine = arr[i];
//
//       let match = pattern.exec(currentLine);
//
//       if(match !== null)
//       {
//          let townName = match[1];
//          let population = Number(match[2]);
//
//          if(!townsAndPopulation.has(townName)) {
//             townsAndPopulation.set(townName, 0);
//          }
//
//          townsAndPopulation.set(townName, townsAndPopulation.get(townName) + population);
//       }
//
//       pattern.exec(currentLine);
//    }
//
//    for (let [town, population] of townsAndPopulation) {
//       console.log(`${town} : ${population}`);
//
//    }
// }
// problem7(['Sofia <-> 1200000',
//       'Montana <-> 20000',
//       'New York <-> 10000000',
//       'Washington <-> 2345000',
//       'Las Vegas <-> 1000000']);

// function problem8(arr){
//    let pattern = RegExp('(.*?)\\s*->\\s*(.*?)\\s*->\\s*(\\d+\\.?[\\d]*)\\s*:\\s*(\\d+\\.?[\\d]*)', 'g');
//
//    let townProductMoney = new Map();
//
//    for (let line of arr) {
//       let match = pattern.exec(line);
//
//       if(match !== null){
//          let town = match[1];
//          let product = match[2];
//          let sales = Number(match[3]);
//          let price = Number(match[4]);
//
//          let money = sales*price;
//
//          if(!townProductMoney.has(town)){
//             townProductMoney.set(town, new Map());
//          }
//
//          if(!townProductMoney.get(town).has(product)){
//             townProductMoney.get(town).set(product, 0);
//          }
//
//          townProductMoney.get(town).set(product, townProductMoney.get(town).get(product) + money);
//       }
//
//       pattern.exec(line);
//    }
//
//    for (let [town, map] of townProductMoney) {
//       console.log(`Town - ${town}`);
//
//       for (let [product, revenue] of map) {
//          console.log(`$$$${product} : ${revenue}`);
//       }
//
//    }
// }
// problem8([
// 'Sofia -> Laptops HP -> 200 : 2000',
// 'Sofia -> Raspberry -> 200000 : 1500',
// 'Sofia -> Audi Q7 -> 200 : 100000',
// 'Montana -> Portokals -> 200000 : 1',
// 'Montana -> Qgodas -> 20000 : 0.2',
// 'Montana -> Chereshas -> 1000 : 0.3'
// ]);

// function problem9(arr){
//    let pattern = RegExp('(.*?)\\s*\\|\\s*(.*?)\\s*\\|\\s*(\\d+\\.?[\\d]*)', 'g');
//
//    let inputProductTownPrice = new Map();
//    let productTownPrice = new Map();
//
//    for (let line of arr) {
//       let match = pattern.exec(line);
//
//       if(match !== null){
//          let town = match[1];
//          let product = match[2];
//          let price = Number(match[3]);
//
//          if(!inputProductTownPrice.has(product)){
//             inputProductTownPrice.set(product, new Map());
//          }
//
//          inputProductTownPrice.get(product).set(town, price);
//       }
//
//       pattern.exec(line);
//    }
//
//    for (let [product, townPriceMap] of inputProductTownPrice) {
//       let cheapestTown = '';
//       let cheapestPrice = Number.POSITIVE_INFINITY;
//
//       for (let [town, price] of townPriceMap) {
//          if (cheapestPrice > price){
//             cheapestTown = town;
//             cheapestPrice = price;
//          }
//       }
//
//       productTownPrice.set(product, {'town': cheapestTown, 'price': cheapestPrice});
//    }
//
//    for (let [product, obj] of productTownPrice) {
//
//       console.log(`${product} -> ${obj.price} (${obj.town})`);
//    }
// }
// problem9([
// 'Sofia City | Audi | 100000',
// 'Sofia City | BMW | 100000',
// 'Sofia City | Mitsubishi | 10000',
// 'Sofia City | Mercedes | 10000',
// 'Sofia City | NoOffenseToCarLovers | 0',
// 'Mexico City | Audi | 1000',
// 'Mexico City | BMW | 99999',
// 'New York City | Mitsubishi | 10000',
// 'New York City | Mitsubishi | 1000',
// 'Mexico City | Audi | 100000',
// 'Washington City | Mercedes | 1000'
// ]);

// function problem10(arr){
//    let pattern = RegExp('[a-zA-Z]+', 'g');
//
//    let allMatches = [];
//
//    for (let i = 0; i < arr.length; i++) {
//       let line = arr[i];
//
//       let matches = pattern.exec(line);
//
//       while(matches !== null){
//          let currentMatch = matches[0].toLowerCase();
//          allMatches.push(currentMatch);
//
//          matches = pattern.exec(line);
//       }
//    }
//
//    let filtered = allMatches.filter(onlyUnique);
//
//    console.log(filtered.join(', '));
//
//    function onlyUnique(value, index, self) {
//       return self.indexOf(value) === index;
//    }
// }
// problem10([
// 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque quis hendrerit dui.',
// 'Quisque fringilla est urna, vitae efficitur urna vestibulum fringilla.',
// 'Vestibulum dolor diam, dignissim quis varius non, fermentum non felis.',
// 'Vestibulum ultrices ex massa, sit amet faucibus nunc aliquam ut.',
// 'Morbi in ipsum varius, pharetra diam vel, mattis arcu.',
// 'Integer ac turpis commodo, varius nulla sed, elementum lectus.',
// 'Vivamus turpis dui, malesuada ac turpis dapibus, congue egestas metus.'
// ]);