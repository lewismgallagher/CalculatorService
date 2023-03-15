using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ICalculator
    {
        public Task<double> Calculate(double value1, string operation, double value2);
    }
}
