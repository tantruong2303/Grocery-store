using System.Linq;
using System;
using backend.Controllers.DTO;
using FluentValidation.Results;
using backend.Utils.Common;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using backend.Utils;
using backend.DAO.Interface;
using backend.Utils.Locale;
using backend.Models;
using backend.Services.Interface;
using backend.Utils.Interface;

namespace backend.Services
{
    public class UserService : IUserService
    {
        private readonly DBContext dbContext;
        private readonly IUserRepository userRepository;
        private readonly IAuthService authService;

        public UserService(DBContext dbContext, IUserRepository userRepository, IAuthService authService)
        {
            this.dbContext = dbContext;
            this.userRepository = userRepository;
            this.authService = authService;
        }

        public bool updatePasswordHandler(UpdatePasswordDTO input, ViewDataDictionary dataView)
        {
            ValidationResult result = new UpdatePasswordDTOValidator().Validate(input);
            if (!result.IsValid)
            {
                ServerResponse.mapDetails(result, dataView);
                return false;
            }
            Console.WriteLine(input.oldPassword);
            User user = (User)dataView["user"];

            if (!authService.comparePassword(input.oldPassword, user.password))
            {
                ServerResponse.setErrorMessage(CustomLanguageValidator.ErrorMessageKey.ERROR_OLD_PASSWORD_NOT_CORRECT, dataView);
                return false;
            }

            user.password = authService.hashingPassword(input.newPassword);
            Console.WriteLine(user.password);

            this.dbContext.user.Update(user);
            this.dbContext.SaveChanges();
            return true;
        }

        public bool updateUserInfoHandler(UpdateUserInfoDTO input, ViewDataDictionary dataView)
        {
            ValidationResult result = new UpdateUserInfoDTOValidator().Validate(input);
            if (!result.IsValid)
            {
                ServerResponse.mapDetails(result, dataView);
                return false;
            }

            User user = (User)dataView["user"];
            user.name = input.name;
            user.email = input.email;
            user.phone = input.phone;
            user.address = input.address;

            this.dbContext.Update(user);
            this.dbContext.SaveChanges();
            return true;
        }
    }
}