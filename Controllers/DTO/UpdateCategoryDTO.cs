using FluentValidation;

namespace backend.Controllers.DTO
{
    public class UpdateCategoryDTO
    {
        public string categoryId { get; set; }
        public string name { get; set; }
        public string description { get; set; }

    }

    public class UpdateCategoryDTOValidator : AbstractValidator<UpdateCategoryDTO>
    {
        public UpdateCategoryDTOValidator()
        {
            RuleFor(x => x.categoryId).NotEmpty().Length(30, 50);
            RuleFor(x => x.name).NotEmpty().Length(3, 50);
            RuleFor(x => x.description).NotEmpty().Length(3, 500);
        }
    }
}