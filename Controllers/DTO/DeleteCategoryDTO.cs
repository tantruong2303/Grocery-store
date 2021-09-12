using FluentValidation;

namespace Backend.Controllers.DTO
{
    public class DeleteCategoryDTO
    {
        public string CategoryId { get; set; }
    }
    public class DeleteCategoryDTOValidator : AbstractValidator<DeleteCategoryDTO>
    {
        public DeleteCategoryDTOValidator()
        {
            RuleFor(x => x.CategoryId).NotEmpty().Length(30, 50);
        }
    }
}