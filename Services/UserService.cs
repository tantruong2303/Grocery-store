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

        public bool UpdatePasswordHandler(User user)
        {
            return this.UserRepository.UpdatePasswordHandler(user);
        }

        public bool UpdateUserInfoHandler(User user)
        {
            return this.UserRepository.UpdateUserInfoHandler(user);
        }

    }
}