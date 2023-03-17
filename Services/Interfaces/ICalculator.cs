using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ICalculator
    {
        public double Calculate(string value1, string operation, string value2);
    }
}
