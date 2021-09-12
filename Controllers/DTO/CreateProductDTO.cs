using FluentValidation;
using backend.Models;

namespace backend.Controllers.DTO
{

    public class CreateProductDTO
    {
        public string name { get; set; }
        public string description { get; set; }
        public float originalPrice { get; set; }
        public float retailPrice { get; set; }
        public int quantity { get; set; }
        public string categoryId { get; set; }
    }
    public class CreateProductDTOValidator : AbstractValidator<CreateProductDTO>
    {
        public CreateProductDTOValidator()
        {
            RuleFor(x => x.name).NotEmpty().Length(3, 50);
            RuleFor(x => x.description).NotEmpty().Length(3, 500);
            RuleFor(x => x.originalPrice).NotEmpty();
            RuleFor(x => x.retailPrice).NotEmpty();
            RuleFor(x => x.quantity).NotEmpty();
            RuleFor(x => x.categoryId).NotEmpty();
        }
    }

}