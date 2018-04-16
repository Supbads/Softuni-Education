// function problem1(str){
//    for (let i = 0; i < str.length; i++) {
//       console.log(`str[${i}] -> ${str[i]}`);
//    }
// }

// function problem2(arr){
//    console.log(arr.reverse().map(a => a.split('').reverse().join('')).join(''));
// }

//problem2(['I', 'am', 'student']);

// function problem3(a,b){
//    let count = 0;
//    let pos = b.indexOf(a);
//
//    while (pos > -1) {
//       ++count;
//       pos = b.indexOf(a, ++pos);
//    }
//
//    console.log(count); //
// }

// function problem4(input){
//    // let pattern = /[(].+?[)]/g;
//    //
//    // let matches = input.match(pattern);
//    // console.log(matches.map(str => str.substring(1, str.length-1)).join(', '));
//
//    let arr = [];
//
//    let myRegexp = /[(].+?[)]/g;
//    let match = myRegexp.exec(input);
//    while (match != null) {
//    // matched text: match[0]
//    // match start: match.index
//    // capturing group n: match[n]
//    // console.log(match[0]);
//    arr.push(match[0].substring(1, match[0].length-1));
//    match = myRegexp.exec(input);
//    }
//
//    console.log(arr.join(', '))
// }
//problem4('Rakiya (Bulgarian brandy) is self-made liquor (alcoholic drink)');

// function problem5(arr){
//    let megata = arr.map(str => str.split('|').filter(e => e));
//
//    let cities = [];
//
//    let totalIncome = 0;
//
//    for (let i = 0; i < megata.length; i++) {
//       let city = megata[i][0].trim();
//
//       let income = Number(megata[i][1].trim());
//       totalIncome+= income;
//
//       cities.push(city);
//    }
//
//    console.log(cities.join(', '));
//    console.log(totalIncome);
// }

// problem5(['| Sofia           | 300',
//    '| Veliko Tarnovo  | 500',
//    '| Yambol          | 275']
//);

// function problem6(purchasesInput){
//    let purchases = [];
//    let sum = 0;
//
//    for (let i = 0; i < purchasesInput.length; i++) {
//       if(i%2 === 0){ //product
//          let product = purchasesInput[i];
//          purchases.push(product);
//       }else{
//          let price = Number(purchasesInput[i]);
//
//          sum+=price;
//       }
//    }
//
//    console.log(`You purchased ${purchases.join(', ')} for a total sum of ${sum}`);
// }

// function problem7(emailsArr){
//
//    let extractedUsernames = [];
//
//    for (let i = 0; i < emailsArr.length; i++) {
//       let currentEmail = emailsArr[i];
//
//       //let emailArgs = currentEmail.replace('@', '|').replace('.', '|').split('|');//.filter(e => e);
//
//       let emailArgs = currentEmail.split('@');//.filter(e => e);
//
//       let username = emailArgs[0];
//
//       let domains = emailArgs[1].split('.');
//
//       let charsAfterDots = "";
//
//       for (let j = 0; j < domains.length; j++) {
//          charsAfterDots += domains[j][0];
//       }
//
//       username = username + '.' + charsAfterDots;
//       extractedUsernames.push(username);
//    }
//
//    console.log(extractedUsernames.join(', '));
// }
//problem7(['peshoo@gmail.com', 'todor_43@mail.dir.bg', 'foo@bar.com']);

// function problem8(text, words){
//    for (let i = 0; i < words.length; i++) {
//       let currentWord = words[i];
//       let currentLength = currentWord.length;
//
//       let pattern = new RegExp(currentWord, 'g');
//       let replacement = '-'.repeat(currentLength);
//
//       text = text.replace(pattern, replacement);
//    }
//
//    console.log(text);
// }
//problem8('roses are red, violets are blue', [', violets are', 'red']);

// function problem9(arr){
//    let text = '<ul>\n';
//
//    let symbolsReplacement = {
//       '<' : '&lt;',
//       '>' : '&gt;',
//       '&' : '&amp;',
//       '"' : '&quot;'
//    };
//
//    for (let i = 0; i < arr.length; i++) {
//       let currentRow = '   <li>';
//
//       let currentInput = arr[i];
//       let replaced = replaceAllv2(currentInput, '&', symbolsReplacement['&']);
//       replaced = replaceAllv2(replaced, '<', symbolsReplacement['<']);
//       replaced = replaceAllv2(replaced, '>', symbolsReplacement['>']);
//       replaced = replaceAllv2(replaced, '"', symbolsReplacement['"']);
//
//       currentRow += replaced;
//
//       currentRow += '</li>\n';
//
//       text += currentRow;
//    }
//
//    text += '</ul>';
//
//    console.log(text);
//
//    function replaceAllv2(text, search, replacement) {
//       return text.replace(new RegExp(search, 'g'), replacement);
//    }
//    // String.prototype.replaceAll = function(search, replacement) {
//    //    let target = this;
//    //    return target.replace(new RegExp(search, 'g'), replacement);
//    // }
// }
// problem9(['<b>unescaped text</b>', 'normal text']);

// function problem10(input){
//    let matches = input.match(/\w+/g);
//
//    console.log(matches.join('|'));
// }
// problem10('A Regular Expression needs to have the global flag in order to match all occurrences in the text');

// function problem11(email) {
//    let regex = RegExp('^[a-zA-Z0-9]+@[a-z]+\\.[a-z]+$', 'g');
//    //let excuseme = /^[a-zA-Z0-9]+@[a-z]+\.[a-z]+$/;
//
//    let isEmailValid = regex.test(email);
//    if(isEmailValid){
//       console.log('Valid');
//    }else{
//       console.log('Invalid');
//    }
// }
//problem11('valid@email.bg');

// function problem12(str) {
//    //first the commas
//
//    //then everything else
//    // (spaces) ; . ( )
//
//    //str = str.replace(/,/g, ' let ');
//    str = str.replace(/[ ;,.)(]/g, ' ');
//
//    let args = str.split(/ /g).filter(e => e);
//
//    console.log(args.join('\n'));
// }
//problem12('let sum = 4 * 4,b = "wow";');

// function problem13(arr) {
//    let regex = RegExp('(?<![\\d])[0-9]{1,2}-[A-Z][a-z]{2}-[0-9]{4}(?![\\d])', 'g');
//
//    for (let i = 0; i < arr.length; i++) {
//       let currentSentence = arr[i];
//
//       let matches = currentSentence.match(regex);
//       if(matches !== null && matches !== undefined){
//          for (let j = 0; j < matches.length; j++) {
//             let currentMatch = matches[j];
//             let matchArgs = currentMatch.split(/-/g);
//
//             let day = matchArgs[0];
//             let month = matchArgs[1];
//             let year = matchArgs[2];
//
//             console.log(`${currentMatch} (Day: ${day}, Month: ${month}, Year: ${year})`);
//          }
//
//       }
//
//    }
//
//    function parseDate(s) {
//       let months = {jan:0,feb:1,mar:2,apr:3,may:4,jun:5,
//          jul:6,aug:7,sep:8,oct:9,nov:10,dec:11};
//       let p = s.split('-');
//       return new Date(p[2], months[p[1].toLowerCase()], p[0]);
//    }
// }
// problem13(['I am born on 30-Dec-1994.I am born on 30-Dec-1994.', 'This is not date: 512-Jan-1996.', 'My father is born on the 29-Jul-1955.']);
//
// function problem14(arr) {
//    let people = [];
//
//    let regex = RegExp('^([A-Z][A-Za-z]*)\\s-\\s([1-9][0-9]*)\\s-\\s([A-Za-z 0-9-]+)$', 'g');
//
//    for (let i = 0; i < arr.length; i++) {
//       let currentLine = arr[i];
//
//       let match = regex.exec(currentLine);
//
//       while(match !== null){
//          let name = match[1].trim();
//          let salary = match[2].trim();
//          let position = match[3].trim();
//
//          let employee = {
//             'Name': name,
//             'Position': position,
//             'Salary': salary
//          };
//
//          people.push(employee);
//
//          match = regex.exec(currentLine);
//       }
//
//    }
//
//    for (let person of people) {
//       console.log(`Name: ${person['Name']}`);
//       console.log(`Position: ${person['Position']}`);
//       console.log(`Salary: ${person['Salary']}`);
//    }
// }
// problem14(['Isacc - 1000 - CEO', 'Ivan - 500 - Employee', 'Peter - 500 - Employee']);
//problem14(['Jonathan - 2000 - Manager','Peter- 1000- Chuck', 'George - 1000 - Team Leader']);

function problem15(username, email, phone, arr) {//Form Filler
   for (let i = 0; i < arr.length; i++) {
      let currentLine = arr[i];
      currentLine = currentLine.replace(/<![a-zA-Z]+?!>/g, username);
      currentLine = currentLine.replace(/<@[a-zA-Z]+?@>/g, email);
      currentLine = currentLine.replace(/<[+][a-zA-Z]+?[+]>/g, phone)
      
      console.log(currentLine);
   }
}
problem15('Pesho', 'pesho@softuni.bg', '90-60-90',
    ['Hello, <!username!>! <!a!> <!!>',
   'Welcome to your Personal profile.',
       'Here you can modify your profile freely.',
       'Your current username is: <!fdsfs!>. Would you like to change that? (Y/N)',
       'Your current email is: <@DasEmail@>. Would you like to change that? (Y/N)',
       'Your current phone number is: <+number+>. Would you like to change that? (Y/N)']);


// function problem16(inputStr) { //match multiplication
//    let regex = RegExp('(-?[\\d]+\\.?[\\d]*)\\s*[*]{1}\\s*(-?[\\d]+\\.?[\\d]*)', 'g');
//
//    let match = regex.exec(inputStr);
//    while(match !== null){
//       let wholeMatch = match[0];
//       let firstNumber = Number(match[1]);
//       let secondNumber = Number(match[2]);
//
//       let product = firstNumber * secondNumber;
//
//       inputStr = inputStr.replace(wholeMatch, product + '');
//
//       match = regex.exec(inputStr);
//    }
//
//    console.log(inputStr);
// }
//
// problem16('My bill: 2*2.50 (beer); 2* 1.20 (kepab); -2  * 0.5 (deposit).');