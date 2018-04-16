function solve(arr){
   arr = arr.filter(x => x);
   
   let subscribedTo = new Map();
   let subscribers = new Map();
   
   for (let line of arr) {
      if(line.length === 1){ // line === person in this case
         if(!subscribedTo.has(line)){
            subscribedTo.set(line, new Set());
            subscribers.set(line, new Set());
         }
         
      }else{
         let args = line.split('-');
         
         let personA = args[0];
         let personB = args[1];
         
         if(!subscribedTo.has(personA) || !subscribedTo.has(personB)){
            continue;
         }
         
         subscribedTo.get(personA).add(personB);
         subscribers.get(personB).add(personA);
      }
   }
   
   let theChosenOne = [...subscribers.keys()].sort(function (a, b) {
      //check for more subscribers -> descending
      let aSubscribers = subscribers.get(a).size;
      let bSubscribers = subscribers.get(b).size;
      
      if(aSubscribers > bSubscribers){
         return -1;
      }
      if(bSubscribers > aSubscribers){
         return 1;
      }
   
      //check for more subscriptions
      let aSubscriptions = subscribedTo.get(a).size;
      let bSubscriptions = subscribedTo.get(b).size;
      
      if(aSubscriptions >= bSubscriptions){
         return -1;
      }
      
      return 1;
   }).shift();
   
   console.log(theChosenOne);
   let i = 1;
   for (let subscriber of subscribers.get(theChosenOne)) {
      console.log(`${i++}. ${subscriber}`)
   }
}
solve([
'Z',
'O',
'R',
'D',
'Z-O',
'R-O',
'D-O',
'P',
'O-P',
'O-Z',
'R-Z',
'D-Z'
]);