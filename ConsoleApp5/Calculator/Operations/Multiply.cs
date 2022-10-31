using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5.Calculator.Operations
{
    public interface IMultiplyOperation : IOperation
    {

    }
    public class Multiply : IMultiplyOperation
    {
        public int Operate(int input, int balance)
        {
            return input*balance;
        }
    }


}
