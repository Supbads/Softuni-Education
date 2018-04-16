function start(nums) {
    let firstNum = Number(nums[0]);
    let secondNum = Number(nums[1]);

    let result = 0;
    if( firstNum > secondNum){
        result = firstNum / secondNum;
    }
    else{
        result = firstNum * secondNum;
    }

    console.log(result);
}