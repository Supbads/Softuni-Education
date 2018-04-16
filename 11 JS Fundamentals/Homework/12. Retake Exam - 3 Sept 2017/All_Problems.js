// function problem1(meals, actions) {
//    let mealsEaten = 0;
//
//    for (let i = 0; i < actions.length; i++) {
//       let currentLineArgs = actions[i].split(' ');//.filter(x => x);
//
//       let action = currentLineArgs[0];
//
//       // should I check lengths?
//
//       if(actions[i] === 'Serve'){
//          if(meals.length === 0){
//             continue;
//          }
//          let lastPortion = meals.pop();
//          console.log(`${lastPortion} served!`)
//
//       }else if(actions[i] === 'Eat'){
//          if(meals.length === 0){
//             continue;
//          }
//          let firstPortion = meals.shift();
//          console.log(`${firstPortion} eaten`);
//          mealsEaten++;
//
//       }else if(action === 'Shift' && currentLineArgs.length === 3){
//          if(meals.length === 0){
//             continue;
//          }
//
//          let firstIndex = Number(currentLineArgs[1]);
//          let secondIndex = Number(currentLineArgs[2]);
//
//          if(firstIndex < 0 || firstIndex >= meals.length || secondIndex < 0 || secondIndex >= meals.length){
//             continue;
//          }
//
//          let temp = meals[firstIndex];
//          meals[firstIndex] = meals[secondIndex];
//          meals[secondIndex] = temp;
//       }else if(action === 'Add' && currentLineArgs.length === 2){
//          let portionToAdd = currentLineArgs[1];
//          meals.unshift(portionToAdd);
//
//       }else if(action === 'Consume' && currentLineArgs.length === 3){
//          if(meals.length === 0){
//             continue;
//          }
//
//          let startIndex = Number(currentLineArgs[1]);
//          let endIndex = Number(currentLineArgs[2]);
//
//          if(startIndex >= meals.length || startIndex < 0 || endIndex < 0 ||endIndex >= meals.length){
//             continue;
//          }
//          if(startIndex > endIndex){
//             continue;
//          }
//
//          let mealsToEat = endIndex - startIndex + 1;
//
//          meals.splice(startIndex, mealsToEat);
//          mealsEaten += mealsToEat;
//
//          console.log('Burp!');
//       }else if('End'){
//          break;
//       }
//    }
//
//    if(meals.length === 0){
//       console.log('The food is gone');
//    }else{
//       console.log(`Meals left: ${meals.join(', ')}`);
//    }
//
//    console.log(`Meals eaten: ${mealsEaten}`);
// }

// problem1([],
// ['Serve',
// 'Eat',
// 'Consume 0 0',
// 'Add chicken',
// 'Add rice',
// 'Eat',
// 'End']);

function problem3() {
   let matrix = [[]];
   
   let check = matrix[1] === undefined;
   
   
   console.log(check);
}
problem3();


