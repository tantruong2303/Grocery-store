using System;
using backend.Controllers.DTO;
using FluentValidation.Results;
using backend.Utils.Common;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using backend.Utils;
using backend.Models;
namespace backend.Services
{
    public class UserService
    {
        private readonly DBContext dbContext;
        public UserService(DBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Boolean registerHandler(RegisterDTO input, ViewDataDictionary dataView)
        {
            // ValidationResult result = new RegisterDTOValidator().Validate(input);
            // if (!result.IsValid)
            // {
            //     ServerResponse.mapDetails(result, dataView);
            //     return false;
            // }

            var user = new User();
            user.userId = Guid.NewGuid().ToString();
            user.username = "hello";
            user.password = "123";
            user.createDate = "123";
            user.address = "123";
            user.email = "123";
            user.phone = "123";
            user.role = UserRole.CUSTOMER;
            user.name = "123";

            this.dbContext.user.Add(user);
            this.dbContext.SaveChanges();
            return true;
        }
    }
}