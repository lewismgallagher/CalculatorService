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
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ICalculator calculator, ILogger<CalculatorController> logger)
        {
            _calculator = calculator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Calculate(CalculationDto calculation)
        {
            try
            {

                var result = await _calculator.Calculate(2, calculation.Operation, 2);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}