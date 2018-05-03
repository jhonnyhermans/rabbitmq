using FluentValidation;

namespace JH.RabbitMq.Domain.Validators
{
     public class TemperatureDataStorageValidator : AbstractValidator<TemperatureDataStorage>
    {
        public TemperatureDataStorageValidator()
        {
            RuleFor(customer => customer.Country).NotEmpty().WithMessage("Please specify a Country"); 
            RuleFor(customer => customer.State).NotEmpty().WithMessage("Please specify a State");
            RuleFor(customer => customer.Name).NotEmpty().WithMessage("Please specify a Name");
            // forçar erro de validação
            // RuleFor(customer => customer.RainPrecipitation).NotEqual(0).WithMessage("Precisamos de chuva!");
        }

    }
}
