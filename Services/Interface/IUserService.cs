using Backend.Controllers.DTO;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Backend.Models;
using System.Collections.Generic;

namespace Backend.Services.Interface
{
    public interface IUserService
    {
        public bool UpdatePasswordHandler(User user);
        public bool UpdateUserInfoHandler(User user);


    }
}