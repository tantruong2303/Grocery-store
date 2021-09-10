using System.Text.RegularExpressions;
using FluentValidation;
using FluentValidation.Results;
using backend.Utils.Validator;

namespace backend.Controllers.DTO
{
    public class RegisterDTO
    {
        public string name { set; get; }
        public string username { set; get; }
        public string password { set; get; }
        public string confirmPassword { set; get; }
        public string email { set; get; }
        public string phone { set; get; }
        public string address { set; get; }
    }

    public class RegisterDTOValidator : AbstractValidator<RegisterDTO>
    {
        public RegisterDTOValidator()
        {
            RuleFor(x => x.username).NotEmpty().Length(UserValidator.USERNAME_MIN, UserValidator.USERNAME_MAX);
            RuleFor(x => x.password).NotEmpty().Length(UserValidator.PASSWORD_MIN, UserValidator.PASSWORD_MAX);
            RuleFor(x => x.confirmPassword).NotEmpty().Equal(x => x.password);
            RuleFor(x => x.name).NotEmpty().Length(UserValidator.NAME_MIN, UserValidator.NAME_MAX);
            RuleFor(x => x.email).NotEmpty().EmailAddress();
            RuleFor(x => x.phone).NotEmpty().NotNull().Matches(new Regex(@"^(03|05|07|08|09|01[2|6|8|9])+([0-9]{8})\b"));
            RuleFor(x => x.address).NotEmpty().Length(UserValidator.ADDRESS_MIN, UserValidator.ADDRESS_MAX);
        }
    }
}