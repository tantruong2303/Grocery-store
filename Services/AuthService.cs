using System.Linq;
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
using Backend.Utils.Interface;

namespace Backend.Services
{
    public class AuthService : IAuthService
    {

        private readonly DBContext DBContext;
        private readonly IUserRepository UserRepository;
        private readonly IJwtService JWTService;
        public AuthService(DBContext dBContext, IUserRepository userRepository, IJwtService jwtService)
        {
            this.DBContext = dBContext;
            this.UserRepository = userRepository;
            this.JWTService = jwtService;
        }

        public bool RegisterHandler(RegisterDTO input, ViewDataDictionary dataView)
        {
            ValidationResult result = new RegisterDTOValidator().Validate(input);
            if (!result.IsValid)
            {
                ServerResponse.MapDetails(result, dataView);
                return false;
            }
            var isExistUser = this.UserRepository.GetUserByUsername(input.Username);
            if (isExistUser != null)
            {
                ServerResponse.SetFieldErrorMessage("username", CustomLanguageValidator.ErrorMessageKey.ERROR_EXISTED, dataView);
                return false;
            }
            Console.WriteLine("hello");

            var user = new User();
            user.UserId = Guid.NewGuid().ToString();
            user.Name = input.Name;
            user.Username = input.Username;
            user.Phone = input.Phone;
            user.Address = input.Address;
            user.Email = input.Email;
            user.CreateDate = DateTime.Now.ToShortDateString();
            user.Role = UserRole.CUSTOMER;
            user.Password = this.HashingPassword(input.Password);

            this.DBContext.User.Add(user);
            this.DBContext.SaveChanges();

            return true;
        }


        public string LoginHandler(LoginDTO input, ViewDataDictionary dataView)
        {
            ValidationResult result = new LoginDTOValidator().Validate(input);
            if (!result.IsValid)
            {
                ServerResponse.MapDetails(result, dataView);
                return null;
            }

            var user = this.UserRepository.GetUserByUsername(input.Username);
            if (user == null)
            {
                ServerResponse.SetErrorMessage(CustomLanguageValidator.ErrorMessageKey.ERROR_LOGIN_FAIL, dataView);
                return null;
            }

            if (!this.ComparePassword(input.Password, user.Password))
            {
                ServerResponse.SetErrorMessage(CustomLanguageValidator.ErrorMessageKey.ERROR_LOGIN_FAIL, dataView);
                return null;
            }

            string token = this.JWTService.GenerateToken(user.UserId);

            return token;
        }

        public string HashingPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, workFactor: 8);
        }

        public bool ComparePassword(string inputPassword, string encryptedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(inputPassword, encryptedPassword);
        }


    }
}