using Backend.Models;
using Backend.Controllers.DTO;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Backend.Services.Interface
{
    public interface IUserService
    {
        public bool updatePasswordHandler(UpdatePasswordDTO input, ViewDataDictionary dataView);
        public bool updateUserInfoHandler(UpdateUserInfoDTO input, ViewDataDictionary dataView);
    }
}