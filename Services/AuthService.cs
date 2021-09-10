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
    public class AuthService : IAuthService
    {

        private readonly DBContext dbContext;
        private readonly IUserRepository userRepository;
        private readonly IJwtService jwtService;
        public AuthService(DBContext dbContext, IUserRepository userRepository, IJwtService jwtService)
        {
            this.dbContext = dbContext;
            this.userRepository = userRepository;
            this.jwtService = jwtService;
        }

        public bool registerHandler(RegisterDTO input, ViewDataDictionary dataView)
        {
            ValidationResult result = new RegisterDTOValidator().Validate(input);
            if (!result.IsValid)
            {
                ServerResponse.mapDetails(result, dataView);
                return false;
            }
            var isExistUser = this.userRepository.getUserByUsername(input.username);
            if (isExistUser != null)
            {
                ServerResponse.setFieldErrorMessage("username", CustomLanguageValidator.ErrorMessageKey.ERROR_EXISTED, dataView);
                return false;
            }
            Console.WriteLine("hello");

            var user = new User();
            user.userId = Guid.NewGuid().ToString();
            user.name = input.name;
            user.username = input.username;
            user.phone = input.phone;
            user.address = input.address;
            user.email = input.email;
            user.createDate = DateTime.Now.ToShortDateString();
            user.role = UserRole.CUSTOMER;
            user.password = this.hashingPassword(input.password);

            this.dbContext.user.Add(user);
            this.dbContext.SaveChanges();

            return true;
        }


        public string loginHandler(LoginDTO input, ViewDataDictionary dataView)
        {
            ValidationResult result = new LoginDTOValidator().Validate(input);
            if (!result.IsValid)
            {
                ServerResponse.mapDetails(result, dataView);
                return null;
            }

            var user = this.userRepository.getUserByUsername(input.username);
            if (user == null)
            {
                ServerResponse.setErrorMessage(CustomLanguageValidator.ErrorMessageKey.ERROR_LOGIN_FAIL, dataView);
                return null;
            }

            if (!this.comparePassword(input.password, user.password))
            {
                ServerResponse.setErrorMessage(CustomLanguageValidator.ErrorMessageKey.ERROR_LOGIN_FAIL, dataView);
                return null;
            }

            string token = this.jwtService.GenerateToken(user.userId);

            return token;
        }

        public string hashingPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, workFactor: 8);
        }

        public bool comparePassword(string inputPassword, string encryptedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(inputPassword, encryptedPassword);
        }


    }
}