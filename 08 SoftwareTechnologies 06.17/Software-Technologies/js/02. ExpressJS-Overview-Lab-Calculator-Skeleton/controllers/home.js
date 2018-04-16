const Calculator =require('../models/Calculator');

module.exports = {
    indexGet: (req, res) => {
        res.render('home/index');
    },
    indexPost: (req, res) =>{
        let calculatorBody = req.body;

        let calculatorParams = calculatorBody['calculator'];

        let calculator = new Calculator();

        calculator.leftOperand = Number(calculatorParams.leftOperand);
        calculator.rightOperand = Number(calculatorParams.rightOperand);
        calculator.operator = calculatorParams.operator;

        let result = calculator.calculateResult();

        res.render('home/index', {'calculator': calculator, 'result':result});
    }
};