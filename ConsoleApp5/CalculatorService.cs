using System;
using ConsoleApp5.Calculator;
using ConsoleApp5.Calculator.Operations;

namespace ConsoleApp5
{
    public class CalculatorCommand
    {
        private readonly ICalculator _calculator;
        private readonly IAddingOperation _addingOperation;
        private readonly IMultiplyOperation _multiplyOperation;
        public CalculatorCommand(ICalculator calculator, IAddingOperation addingOperation, IMultiplyOperation multiplyOperation)
        {
            _calculator = calculator;
            _addingOperation = addingOperation;
            _multiplyOperation = multiplyOperation;
        }

        public int Call(string[] args)
        {
            var operationType = DetermineOperationType(args[0]);
            var inputNumber = DetermineInputValue(args[1]);
            switch (operationType)
            {
                case Operations.ADD:
                    return _calculator.Calculate(_addingOperation, inputNumber);
                case Operations.MULTIPLY:
                    return _calculator.Calculate(_multiplyOperation, inputNumber);
                default:
                    throw new NotImplementedException();
            }
        }

        public Operations DetermineOperationType(string input)
        {
            if (!Enum.TryParse(typeof(Operations), input.ToUpper(), out object operationType))
                return Operations.UNDEFINED;

            if (operationType == null)
                return Operations.UNDEFINED;
            
            return (Operations) operationType;
        }

        public int DetermineInputValue(string input)
        {
            if (!int.TryParse(input, out int result))
                throw new ArgumentException();

            return result;
        }
    }
}
