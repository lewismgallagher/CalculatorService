using Services.Interfaces;
using System.Data;

namespace Services.Classes
{
    public class Calculator : ICalculator
    {

        public void ValidateParameters(string value1, string operation, string value2)
        {

        }


        public double Calculate(string value1, string operation, string value2)
        {
            try
            {
                if (!double.TryParse(value1, out _) || !double.TryParse(value2, out _) ||
                    (operation != "+" && operation != "-" && operation != "*" && operation != "/"))
                {
                    throw new ArgumentException("Syntax Error, Incorrect Expression");
                }

                string expression = value1 + operation + value2;

                DataTable dt = new DataTable();

                var rawResult = dt.Compute(expression, "");

                if (!double.TryParse(rawResult.ToString(), out _))
                {
                    throw new ArgumentException("Syntax Error, Incorrect Expression");
                }

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