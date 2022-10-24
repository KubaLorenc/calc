using System;

namespace ConsoleApp5
{
    internal class CalculatorCommand
    {
        private readonly ICalculator _calculator;
        public CalculatorCommand(ICalculator calculator)
        {
            _calculator = calculator;
        }

        public int Call(string[] args)
        {
            //to w obecnym setupie nie ma jak zamockowac przy testowaniu metody Call, czy to problem?
            var operationType = DetermineOperationType(args[0]);
            return _calculator.Calculate(operationType, 1, 2);
        }

        public IOperation DetermineOperationType(string input)
        {
            if (!Enum.TryParse(typeof(Operations), input.ToString().ToUpper(), out object operationType))
            {
                throw new Exception();
            }
            switch ((Operations)operationType)
            {
                case Operations.Add:
                    return new Adding();
                default:
                    throw new Exception();
            }
        }
    }
}
