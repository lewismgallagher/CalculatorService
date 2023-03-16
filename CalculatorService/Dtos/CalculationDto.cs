using System.ComponentModel.DataAnnotations;

namespace CalculatorAPI.Dtos
{
    public class CalculationDto
    {
        public string Value1 { get; set; }

        public string Operation { get; set; }

        public string Value2 { get; set; }

        public CalculationDto(string value1, string operation, string value2)
        {
            Value1 = value1;
            Operation = operation;
            Value2 = value2;
        }
    }
}
