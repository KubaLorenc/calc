using ConsoleApp5.Calculator.Operations;

namespace ConsoleApp5.Calculator
{
    public interface ICalculator
    {
        public int Calculate(IOperation operation, int input);
    }
    public class Calculator : ICalculator
    {
        private int _balance { get; set; }
        public int Calculate(IOperation operation, int input)
        {
            return operation.Operate(input, _balance);
        }

        public int GetBalance()
        {
            return _balance;
        }
    }
}
