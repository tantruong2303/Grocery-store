using FluentValidation;

namespace backend.Controllers.DTO
{
    public class DeleteCategoryDTO
    {
        public string categoryId { get; set; }
    }
    public class DeleteCategoryDTOValidator : AbstractValidator<DeleteCategoryDTO>
    {
        public DeleteCategoryDTOValidator()
        {
            RuleFor(x => x.categoryId).NotEmpty().Length(30, 50);
        }
    }
}