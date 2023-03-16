using CalculatorAPI.Dtos;
using FluentValidation;

namespace CalculatorAPI.Validators
{
    public class CalculationValidator : AbstractValidator<CalculationDto>
    {
        public CalculationValidator()
        {
            RuleFor(v1 => v1.Value1).NotEmpty()
                .WithErrorCode("400")
                .WithMessage("Value 1 cannot be empty");

            RuleFor(v1 => v1.Value1).Must(BeAValueThatCanBeConvertedToANumericalValue)
                .WithErrorCode("400")
                .WithMessage("Value 1 must be a numerical value");

            RuleFor(v2 => v2.Value2).NotEmpty()
                .WithErrorCode("400")
                .WithMessage("Value 2 cannot be empty");

            RuleFor(v2 => v2.Value2).Must(BeAValueThatCanBeConvertedToANumericalValue)
                .WithErrorCode("400")
                .WithMessage("Value 2 must be a numerical value");

            RuleFor(o => o.Operation).NotEmpty()
                .WithErrorCode("400")
                .WithMessage("The operation cannot be empty");

            RuleFor(o => o.Operation).Must(BeAnOperationSymbol)
                .WithErrorCode("400")
                .WithMessage("Invalid operation. The valid operation symbols are +, -, * and / ");
        }

        public bool BeAValueThatCanBeConvertedToANumericalValue(string value)
        {
            if (double.TryParse(value, out _)) { return true; }

            return false;
        }

        public bool BeAnOperationSymbol(string operation)
        {
            if (operation == "+" || operation == "-" || operation == "*" || operation == "/") { return true; }

            return false;
        }

    }
}
