using System;
using ConsoleApp5.Calculator;
using ConsoleApp5.Calculator.Operations;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<ICalculator, Calculator.Calculator>()
                .AddSingleton<IAddingOperation, Adding>()
                .AddSingleton<IMultiplyOperation, Multiply>()
                .BuildServiceProvider();

            var calculator = serviceProvider.GetService<ICalculator>();
            var addingOperation = serviceProvider.GetService<IAddingOperation>();
            var multiplyOperation = serviceProvider.GetService<IMultiplyOperation>();

            var service = new CalculatorCommand(calculator, addingOperation, multiplyOperation);
            Console.WriteLine(service.Call(args));
        }
    }
}
