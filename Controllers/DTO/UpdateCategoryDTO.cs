using FluentValidation;
using Backend.Models;

namespace Backend.Controllers.DTO
{
    public class UpdateCategoryDTO
    {
        public string CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CategoryStatus Status { get; set; }
    }

    public class UpdateCategoryDTOValidator : AbstractValidator<UpdateCategoryDTO>
    {
        public UpdateCategoryDTOValidator()
        {
            RuleFor(x => x.CategoryId).NotEmpty().Length(30, 50);
            RuleFor(x => x.Name).NotEmpty().NotNull().Length(3, 50);
            RuleFor(x => x.Description).NotEmpty().Length(3, 500);
            RuleFor(x => x.Status).IsInEnum().NotNull();
        }
    }
}