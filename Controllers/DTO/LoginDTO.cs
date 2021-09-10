using System.Text.RegularExpressions;
using FluentValidation;
using FluentValidation.Results;
using backend.Utils.Validator;


namespace backend.Controllers.DTO
{
    public class LoginDTO
    {
        public string username { set; get; }
        public string password { set; get; }

    }
    public class LoginDTOValidator : AbstractValidator<LoginDTO>
    {
        public LoginDTOValidator()
        {

            RuleFor(x => x.username).NotEmpty().Length(UserValidator.USERNAME_MIN, UserValidator.USERNAME_MAX);
            RuleFor(x => x.password).NotEmpty().Length(UserValidator.PASSWORD_MIN, UserValidator.PASSWORD_MAX);
        }
    }
}