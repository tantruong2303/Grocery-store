using FluentValidation;
using backend.Models;

namespace backend.Controllers.DTO
{
    public class CreateCategoryDTO
    {
        public string name { get; set; }
        public string description { get; set; }
    }
    public class CreateCategoryDTOValidator : AbstractValidator<CreateCategoryDTO>
    {
        public CreateCategoryDTOValidator()
        {
            RuleFor(x => x.name).NotEmpty().Length(3, 50);
            RuleFor(x => x.description).NotEmpty().Length(3, 500);
        }
    }
}