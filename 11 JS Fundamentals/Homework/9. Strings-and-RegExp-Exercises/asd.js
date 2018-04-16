// function problem1(str, delimiter){
//    let rgx = RegExp(`${escapeRegExp(delimiter)}`, 'g');
//    let args = str.split(rgx);
//
//    for (let obj of args) {
//       console.log(obj);
//    }
//
//    function escapeRegExp(str) {
//       return str.replace(/[\-\[\]\/\{\}\(\)\*\+\?\.\\\^\$\|]/g, "\\$&");
//    }
// }
// problem1('http://platform.softuni.bg', '.');

// function problem2(str, count){
//    console.log(str.repeat(count));
// }

// function problem3(text, supposedStart){
//    console.log(text.startsWith(supposedStart));
// }

// function problem4(text, supposedEnd){
//    console.log(text.endsWith(supposedEnd));
// }

// function problem5(inputStr){
//    let replacedText = toTitleCase(inputStr);
//
//    console.log(replacedText);
//
//    function toTitleCase(str)
//    {
//       return str.replace(/\w+/g, function(txt){return txt.charAt(0).toUpperCase() + txt.substr(1).toLowerCase();});
//    }
// }

// function problem6(arr){
//    let pattern = RegExp('\\d+', 'g');
//
//    let output = [];
//
//    for (let i = 0; i < arr.length; i++) {
//       let currentLine = arr[i];
//
//       let matchedDigits = currentLine.match(pattern);
//
//       if(matchedDigits === null){
//          continue;
//       }
//       for (let obj of matchedDigits) {
//          output.push(obj);
//       }
//    }
//
//    console.log(output.join(' '));
// }
// problem6(["The300", "What is that?", "I think it's the 3rd movie.", 'Lets watch it at 22:45']);

// function problem7(str){
//    let pattern = RegExp('(?<!_)_([A-Za-z0-9]+)(?![_a-zA-Z0-9])', 'g');
//
//    let matches = pattern.exec(str);
//
//    let variableNames = [];
//
//    while(matches){
//       let variable = matches[1];
//       variableNames.push(variable);
//
//       matches = pattern.exec(str);
//    }
//
//    console.log(variableNames.join(','));
// }

// function problem8(text, word){
//    let pattern = RegExp(`${word}\\b`, 'gi');
//
//    let occurancesCount = 0;
//
//    let match = pattern.exec(text);
//
//    while(match){
//       occurancesCount++;
//
//       match = pattern.exec(text);
//    }
//
//    console.log(occurancesCount);
// }
// problem8('There was one. Therefore I bought it. I wouldn�t buy it otherwise.', 'there');

// function problem9(arr){
//    let regex = RegExp('www\\.[A-Za-z0-9\-]+(\\.[a-z]+)+', 'g');
//
//    for (let i = 0; i < arr.length; i++) {
//       let currentLine = arr[i];
//
//       let matches = regex.exec(currentLine);
//
//       while(matches){
//          let validEmail = matches[0];
//          console.log(validEmail);
//
//          matches = regex.exec(matches);
//       }
//    }
// }
// problem9(['Join WebStars now for free, at www.web-stars.com',
//    'You can also support our partners:', 'Internet - www.internet.com',
//    'WebSpiders - www.webspiders101.com', 'Sentinel - www.sentinel.-ko ']);
//
// function problem10(arr){
//    let clientNamesPattern = RegExp('(\\*[A-Z][a-zA-Z]*(?=[\\s\\n\\t]))|(\\*[A-Z][a-zA-Z]*$)', 'g');
//    let phoneNumbersPattern = RegExp('(\\+[0-9\\-]{10}(?=[\\s\\n\\t]))|(\\+[0-9\\-]{10}$)', 'g');
//    let clientIdsPattern = RegExp('(\\![a-zA-Z0-9]+(?=[\\t\\n\\s]))|(\\![a-zA-Z0-9]+$)', 'g');
//    let basesPattern = RegExp('(\\_[a-zA-Z0-9]+(?=[\\t\\n\\s]))|(\\_[a-zA-Z0-9]+$)','g');
//
//    for (let i = 0; i < arr.length; i++) {
//       let currentLine = arr[i];
//
//       currentLine = currentLine.replace(clientNamesPattern, function (match) {
//          return '|'.repeat(match.length);
//       });
//
//       currentLine = currentLine.replace(phoneNumbersPattern, function (match) {
//          return '|'.repeat(match.length);
//
//       });
//
//       currentLine = currentLine.replace(clientIdsPattern, function (match) {
//          return '|'.repeat(match.length);
//       });
//
//       currentLine = currentLine.replace(basesPattern, function (match) {
//          return '|'.repeat(match.length);
//
//       });
//
//       arr[i] = currentLine;
//       //currentLine = currentLine.replace(clientNamesPattern, replacementBySymbol(match, '|'));
//    }
//
//    if(arr !== null){
//       for (let line of arr) {
//          console.log(line);
//
//       }
//    }
//
//    function replacementBySymbol(text, symbol) {
//       return symbol.repeat(text.length);
//    }
// }
// problem10(['Agent *Ivankov was in the room when it all happened.',
// "The person in the room was heavily armed.",
// "Agent *Ivankov had to act quick in order.",
// "He picked up his phone and called some unknown number.",
// "I think it was +555-49-796",
// "I can't really remember...",
// 'He said something about "finishing work" with subject !2491a23BVB34Q and returning to Base _Aurora21',
// "Then after that he disappeared from my sight.",
// "As if he vanished in the shadows.",
// "A moment, shorter than a second, later, I saw the person flying off the top floor.",
// "I really don't know what happened there.",
// "This is all I saw, that night.",
// "I cannot explain it myself..."]);