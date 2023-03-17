using CalculatorAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorUnitTests.Fixtures
{
    public static class SuccessfulDtoCalculationsFixture
    {
        public static CalculationDto GetAddCalculationDto() => new CalculationDto("1","+","1");
        public static CalculationDto GetMinusCalculationDto() => new CalculationDto("2","-","1");
        public static CalculationDto GetMultiplyCalculationDto() => new CalculationDto("3","*","3");
        public static CalculationDto GetDivideCalculationDto() => new CalculationDto("9","/","3");
    }
}
