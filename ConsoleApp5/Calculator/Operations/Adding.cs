namespace ConsoleApp5.Calculator.Operations
{
    public interface IAddingOperation : IOperation
    {

    }
    public class Adding : IAddingOperation
    {
        public int Operate(int input, int balance)
        {
            return input + balance;
        }
    }
}
