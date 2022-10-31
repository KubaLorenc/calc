using System;
using System.ComponentModel;
using ConsoleApp5;
using ConsoleApp5.Calculator;
using ConsoleApp5.Calculator.Operations;
using Moq;
using Xunit;

namespace Calculator.Tests
{
    public class CalculatorCommandTests
    {
        private readonly Mock<ICalculator> _calculator;
        private readonly CalculatorCommand _calculatorCommand;
        private readonly Mock<IAddingOperation> _addingOperation;
        private readonly Mock<IMultiplyOperation> _multiplyOperation;
        public CalculatorCommandTests()
        {
            _calculator = new Mock<ICalculator>();
            _addingOperation = new Mock<IAddingOperation>();
            _multiplyOperation = new Mock<IMultiplyOperation>();
            _calculator.Setup(c => c.Calculate(_addingOperation.Object, 1)).Returns(1);
            _calculator.Setup(c => c.Calculate(_multiplyOperation.Object, 1)).Returns(0);


            _calculatorCommand = new CalculatorCommand(_calculator.Object, _addingOperation.Object, _multiplyOperation.Object);
        }
        [Fact]
        public void AddingTest()
        {
            var result = _calculatorCommand.Call(new[] {"add"});
            Assert.Equal(1, result);
        }
        [Fact]
        public void MultiplyTest()
        {
            var result = _calculatorCommand.Call(new[] { "multiply" });
            Assert.Equal(0, result);
        }
        [Fact]
        public void DetermineOperationTypeTest()
        {
            var result = _calculatorCommand.DetermineOperationType("add");
            Assert.Equal(result, Operations.ADD);
        }
    }
}
