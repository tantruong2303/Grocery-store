using FluentValidation;
using FluentValidation.Results;
using backend.Utils.Validator;

namespace backend.Controllers.DTO
{
    public class UpdatePasswordDTO
    {
        public string oldPassword { get; set; }
        public string newPassword { get; set; }
        public string confirmNewPassword { get; set; }
    }

    public class UpdatePasswordDTOValidator : AbstractValidator<UpdatePasswordDTO>
    {
        public UpdatePasswordDTOValidator()
        {
            RuleFor(x => x.oldPassword).NotEmpty().Length(UserValidator.PASSWORD_MIN, UserValidator.PASSWORD_MAX);
            RuleFor(x => x.newPassword).NotEmpty().Length(UserValidator.PASSWORD_MIN, UserValidator.PASSWORD_MAX);
            RuleFor(x => x.confirmNewPassword).NotEmpty().Equal(x => x.newPassword);
        }
    }
}