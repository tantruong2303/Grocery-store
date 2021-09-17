using System;
using Backend.Controllers.DTO;
using FluentValidation.Results;
using Backend.Utils.Common;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Backend.Utils;
using Backend.DAO.Interface;
using Backend.Utils.Locale;
using Backend.Models;
using Backend.Services.Interface;

namespace Backend.Services
{
    public class UserService : IUserService
    {
        private readonly DBContext DBContext;
        private readonly IUserRepository UserRepository;
        private readonly IAuthService AuthService;

        public UserService(DBContext dBContext, IUserRepository userRepository, IAuthService authService)
        {
            this.DBContext = dBContext;
            this.UserRepository = userRepository;
            this.AuthService = authService;
        }

        public bool UpdatePasswordHandler(UpdatePasswordDTO input, ViewDataDictionary dataView)
        {
            ValidationResult result = new UpdatePasswordDTOValidator().Validate(input);
            if (!result.IsValid)
            {
                ServerResponse.MapDetails(result, dataView);
                return false;
            }
            Console.WriteLine(input.oldPassword);
            User user = (User)dataView["user"];

            if (!AuthService.ComparePassword(input.oldPassword, user.Password))
            {
                ServerResponse.SetErrorMessage(CustomLanguageValidator.ErrorMessageKey.ERROR_OLD_PASSWORD_NOT_CORRECT, dataView);
                return false;
            }

            user.Password = AuthService.HashingPassword(input.newPassword);
            Console.WriteLine(user.Password);

            this.DBContext.User.Update(user);
            this.DBContext.SaveChanges();
            return true;
        }

        public bool UpdateUserInfoHandler(UpdateUserInfoDTO input, ViewDataDictionary dataView)
        {
            ValidationResult result = new UpdateUserInfoDTOValidator().Validate(input);
            if (!result.IsValid)
            {
                ServerResponse.MapDetails(result, dataView);
                return false;
            }

            User user = (User)dataView["user"];
            user.Name = input.name;
            user.Email = input.email;
            user.Phone = input.phone;
            user.Address = input.address;

            this.DBContext.Update(user);
            this.DBContext.SaveChanges();
            return true;
        }
    }
}