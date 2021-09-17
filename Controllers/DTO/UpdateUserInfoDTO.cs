using FluentValidation;
using Backend.Utils.Validator;
using System.Text.RegularExpressions;

namespace Backend.Controllers.DTO
{
    public class UpdateUserInfoDTO
    {
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
    }

    public class UpdateUserInfoDTOValidator : AbstractValidator<UpdateUserInfoDTO>
    {
        public UpdateUserInfoDTOValidator()
        {
            RuleFor(x => x.name).NotEmpty().Length(UserValidator.NAME_MIN, UserValidator.NAME_MAX);
            RuleFor(x => x.email).NotEmpty().EmailAddress();
            RuleFor(x => x.phone).NotEmpty().NotNull().Matches(new Regex(@"^(03|05|07|08|09|01[2|6|8|9])+([0-9]{8})\b"));
            RuleFor(x => x.address).NotEmpty().Length(UserValidator.ADDRESS_MIN, UserValidator.ADDRESS_MAX);
        }
    }
}