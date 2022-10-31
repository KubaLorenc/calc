
using ConsoleApp5.Calculator;
using ConsoleApp5.Calculator.Operations;
using Moq;
using Xunit;

namespace Calculator.Tests
{
    public class CalculatorTests
    {
        private readonly ICalculator _calculator;
        private readonly Mock<IAddingOperation> _addingOperation;
        private readonly Mock<IMultiplyOperation> _multiplyOperation;
        public CalculatorTests()
        {
            _calculator = new ConsoleApp5.Calculator.Calculator();
            _addingOperation = new Mock<IAddingOperation>();
            _multiplyOperation = new Mock<IMultiplyOperation>();
            _addingOperation.Setup(o => o.Operate(1, 0)).Returns(1);
            _multiplyOperation.Setup(o => o.Operate(1, 0)).Returns(0);
        }
        [Fact]
        public void AddingTest()
        {
            var result = _calculator.Calculate(_addingOperation.Object, 1);
            Assert.Equal(1, result);
        }
        [Fact]
        public void MultiplyTest()
        {
            var result = _calculator.Calculate(_multiplyOperation.Object, 1);
            Assert.Equal(0, result);
        }
    }
}
