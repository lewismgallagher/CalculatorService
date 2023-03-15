using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace CalculatorService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculator _calculator;

        public CalculatorController(ICalculator calculator)
        {
            _calculator = calculator;
        }

        [HttpGet]
        public async Task<IActionResult> Calculate(double value1, string operation, double value2)
        {
            bool parameterError = false;
            List<string> ErrorMessages = new List<string>();


            if (!double.TryParse(value1.ToString() ,  out _))
            {
                parameterError = true;
                ErrorMessages.Add("The first value was not in the correct format. The value must be a number.");
            }

            if (operation != "+" && operation != "-" && operation != "*")
            {
                parameterError = true;
                ErrorMessages.Add("The operator was not in the correct format. The operator must be a +, -, * or / symbol.");
            }

            if (!double.TryParse(value2.ToString(), out _))
            {
                parameterError = true;
                ErrorMessages.Add("The second value was not in the correct format. The value must be a number.");
            }

            if (parameterError)
            {
                string compliledErrors = "";

                foreach (var errorMessage in ErrorMessages)
                {
                    compliledErrors += errorMessage + "\n";
                }

                return BadRequest(ErrorMessages);
            }

            var result = await _calculator.Calculate(value1, operation, value2);

            return Ok(result);
        }

    }
}