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



        public async Task<double> Calculate(string value1, string operation, string value2)
        {

            try
            {
                var userResponse = await _httpClient.GetAsync("https://example.com");
                string expression = value1 + operation + value2;

                DataTable dt = new DataTable();

                var rawResult = dt.Compute(expression, "");

                double result = double.Parse(rawResult.ToString());

                if (result.ToString() == "∞")
                {
                    throw new DivideByZeroException("Syntax Error, Cannot Divide by 0 ");
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }


        }

    }
}