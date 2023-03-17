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

        public CalculatorController(ICalculator calculator)
        {
            _calculator = calculator;
        }

        [HttpPost]
        public IActionResult Calculate(CalculationDto calculation)
        {
            try
            {
                var result =  _calculator.Calculate(calculation.Value1, calculation.Operation, calculation.Value2);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}