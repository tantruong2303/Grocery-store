using FluentValidation;
using Backend.Models;

namespace Backend.Controllers.DTO
{
    public class CreateCategoryDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
    }
    public class CreateCategoryDTOValidator : AbstractValidator<CreateCategoryDTO>
    {
        public CreateCategoryDTOValidator()
        {
            RuleFor(x => x.Name).NotEmpty().Length(3, 50);
            RuleFor(x => x.Description).NotEmpty().Length(3, 500);
            RuleFor(x => x.Status).InclusiveBetween(0, 1);
        }
    }
}