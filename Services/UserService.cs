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

namespace backend.Services
{
    public class UserService : IUserService
    {
        private readonly DBContext dbContext;
        private readonly IUserRepository userRepository;
        public UserService(DBContext dbContext, IUserRepository userRepository)
        {
            this.dbContext = dbContext;
            this.userRepository = userRepository;
        }
        public Boolean registerHandler(RegisterDTO input, ViewDataDictionary dataView)
        {
            ValidationResult result = new RegisterDTOValidator().Validate(input);
            if (!result.IsValid)
            {
                ServerResponse.mapDetails(result, dataView);
                return false;
            }

            // var user = new User();
            // user.userId = Guid.NewGuid().ToString();
            // user.username = "hello";
            // user.password = "123";
            // user.createDate = "123";
            // user.address = "123";
            // user.email = "123";
            // user.phone = "123";
            // user.role = UserRole.CUSTOMER;
            // user.name = "123";
            // this.dbContext.order.AsQueryable();
            // this.dbContext.user.Add(user);
            // this.dbContext.SaveChanges();
            return true;
        }


        public User loginHandler(LoginDTO input, ViewDataDictionary dataView)
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
                ServerResponse.setErrorMessage(CustomLanguageValidator.ErrorMessageKey.Error_LoginFail, dataView);
                return null;
            }

            if (user.password != input.password)
            {
                ServerResponse.setErrorMessage(CustomLanguageValidator.ErrorMessageKey.Error_LoginFail, dataView);
                return null;
            }

            return user;
        }
    }
}