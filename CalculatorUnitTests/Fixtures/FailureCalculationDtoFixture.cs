using CalculatorAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorUnitTests.Fixtures
{
    public static class FailureCalculationDtoFixture
    {
        public static CalculationDto GetEmptyStringCalculationDto() => new CalculationDto("", "", "");
        public static CalculationDto GetDivideBy0CalculationDto() => new CalculationDto("5", "/", "0");
        public static CalculationDto GetIncorrectParametersCalculationDto() => new CalculationDto("A", "40", "B");
    }
}
