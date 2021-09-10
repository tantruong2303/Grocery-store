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



    }
}