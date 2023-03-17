using CalculatorAPI.Dtos;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace CalculatorService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculator _calculator;
        //private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ICalculator calculator)
        {
            _calculator = calculator;
        }

        [HttpPost]
        public async Task<IActionResult> Calculate(CalculationDto calculation)
        {
            try
            {
                var result = await _calculator.Calculate(calculation.Value1, calculation.Operation, calculation.Value2);

                if(!double.TryParse(result.ToString() ,out _)) { return BadRequest("Syntax Error."); }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}