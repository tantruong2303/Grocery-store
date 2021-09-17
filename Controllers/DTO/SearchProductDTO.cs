using FluentValidation;

namespace Backend.Controllers.DTO
{
    public class SearchProductDTO
    {
        public double Min { set; get; }
        public double Max { set; get; }
        public string Name { set; get; }
        public string CategoryId { set; get; }
    }

    public class SearchProductDTOValidator : AbstractValidator<SearchProductDTO>
    {
        public SearchProductDTOValidator()
        {
            RuleFor(x => x.Min).NotNull().InclusiveBetween(0, double.MaxValue);
            RuleFor(x => x.Max).NotNull().InclusiveBetween(0, double.MaxValue);
        }
    }
}