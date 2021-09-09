using System.Text.RegularExpressions;
using FluentValidation;
using FluentValidation.Results;
using backend.Utils.Validator;

namespace backend.Controllers.DTO
{
    public class RegisterDTO
    {
        public string username;
        public string password;
    }

    public class RegisterDTOValidator : AbstractValidator<RegisterDTO>
    {
        public RegisterDTOValidator()
        {
            RuleFor(x => x.username).NotEmpty().Length(UserValidator.USERNAME_MIN, UserValidator.USERNAME_MAX);
            RuleFor(x => x.password).NotEmpty().Length(UserValidator.PASSWORD_MIN, UserValidator.PASSWORD_MAX);
        }
    }
}