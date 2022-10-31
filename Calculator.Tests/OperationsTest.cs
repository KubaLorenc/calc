using ConsoleApp5.Calculator.Operations;
using Xunit;

namespace Calculator.Tests
{
    public class OperationsTest
    {
        private readonly IAddingOperation _addingOperation;
        public OperationsTest()
        {
            _addingOperation = new Adding();
        }
        [Fact]
        public void AddingTest()
        {
            var result = _addingOperation.Operate(1, 0);
            Assert.Equal(1, result);
        }
    }
}
