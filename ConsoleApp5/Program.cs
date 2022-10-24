using System;
using System.Runtime.CompilerServices;

namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //calculator bedzie wstrzykniety przez autofac
            var service = new CalculatorCommand(new Calculator());
            Console.WriteLine(service.Call(args));
        } 


    }
    public enum Operations
    {
        Undefined,
        Add,
        Subtract,
        Multiply
    }

    public interface IOperation
    {
        public int Operate(int input1, int input2);
    }

    public interface ICalculator
    {
        public int Calculate(IOperation operation, int input1, int input2);
    }
    internal class Adding : IOperation
    {
        public int Operate(int input1, int input2)
        {
            return input1 + input2;
        }
    }
    internal class Calculator : ICalculator
    {
        public int Calculate(IOperation operation, int input1, int input2)
        {
            return operation.Operate(input1, input2);
        }
    }
}
