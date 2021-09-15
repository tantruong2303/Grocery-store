using System.Text.RegularExpressions;
using FluentValidation;
using FluentValidation.Results;
using Backend.Utils.Validator;

namespace Backend.Controllers.DTO
{
    public class SearchProductDTO
    {
        public double Min { set; get; }
        public double Max { set; get; }
    }

    public class SearchProductDTOValidator : AbstractValidator<SearchProductDTO>
    {
        public SearchProductDTOValidator()
        {
            RuleFor(x => x.Min).NotEmpty().NotNull().InclusiveBetween(0, double.MaxValue);
            RuleFor(x => x.Max).NotEmpty().NotNull().InclusiveBetween(0, double.MaxValue);
        }
    }
}