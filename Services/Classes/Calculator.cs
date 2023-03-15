using Services.Interfaces;
using System.Data;

namespace Services.Classes
{
    public class Calculator : ICalculator
    {
        private readonly HttpClient _httpClient;

        public Calculator(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }



        public async Task<double> Calculate(double value1, string operation, double value2)
        {
            var userResponse = await _httpClient.GetAsync("https://example.com");
            double result = 0;
            switch (operation)
            {
                case "+": result = value1 + value2; break;
                case "-": result = value1 - value2; break;
                case "*": result = value1 * value2; break;
                case "/": result = value1 / value2; break;
                default: 
                    break;
            }

            return result;
        }

    }
}