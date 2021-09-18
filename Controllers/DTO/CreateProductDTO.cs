using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Backend.Controllers.DTO
{

    public class CreateProductDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float OriginalPrice { get; set; }
        public float RetailPrice { get; set; }
        public int Quantity { get; set; }
        public IFormFile File { get; set; }
        public string CategoryId { get; set; }
    }
    public class CreateProductDTOValidator : AbstractValidator<CreateProductDTO>
    {
        public CreateProductDTOValidator()
        {
            RuleFor(x => x.Name).NotEmpty().Length(3, 50);
            RuleFor(x => x.Description).NotEmpty().Length(3, 500);
            RuleFor(x => x.OriginalPrice).NotEmpty().InclusiveBetween(0, 1000000);
            RuleFor(x => x.RetailPrice).NotEmpty().InclusiveBetween(0, 1000000);
            RuleFor(x => x.Quantity).NotEmpty().InclusiveBetween(0, 10000);
            RuleFor(x => x.File).NotNull();
            RuleFor(x => x.CategoryId).NotEmpty();
        }
    }

}