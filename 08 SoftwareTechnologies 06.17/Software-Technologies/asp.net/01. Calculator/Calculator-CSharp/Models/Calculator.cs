namespace Calculator_CSharp.Models
{
    public class Calculator
    {
        public Calculator(decimal leftOperand, decimal rightOperand, string @operator)
        {
            LeftOperand = leftOperand;
            RightOperand = rightOperand;
            Operator = @operator;
            Result = 0;
        }

        public Calculator()
        {
            this.Result = 0;
        }

        public decimal LeftOperand { get; set; }

        public decimal RightOperand { get; set; }

        public string Operator { get; set; }

        public decimal Result { get; set; }


        public decimal CalculatoreResult()
        {
            decimal result = 0;

            switch (Operator)
            {
                case "+":
                    result = this.LeftOperand + this.RightOperand;
                    break;
                case "-":
                    result = this.LeftOperand - this.RightOperand;
                    break;
                case "*":
                    result = this.LeftOperand * this.RightOperand;
                    break;
                case "/":
                    result = this.LeftOperand / this.RightOperand;
                    break;
            }

            this.Result = result;

            return result;
        }
    }
}