using FluentValidation;
using Backend.Models;

namespace Backend.Controllers.DTO
{
    public class CreateOrderDTO
    {
        public PaymentMethod PaymentMethod { get; set; }
    }
    public class CreateOrderDTOValidator : AbstractValidator<CreateOrderDTO>
    {
        public CreateOrderDTOValidator()
        {
            RuleFor(x => x.PaymentMethod).NotEmpty().NotNull().IsInEnum();
        }
    }
}