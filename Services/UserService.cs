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

namespace Backend.Services
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



    }
}