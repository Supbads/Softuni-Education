function start(nums) {
    let a = Number(nums[0]);
    let b = Number(nums[1]);
    let c = Number(nums[2]);

    let negativeCounter = 0;

    if(a < 0){
        negativeCounter++;
    }

    if(b < 0){
        negativeCounter++;
    }
    if(c < 0){
        negativeCounter++;
    }

    if(negativeCounter%2 === 0){
        console.log('Positive')
    }
    else{
        console.log('Negative')
    }

}