using backend.Models;
using backend.Controllers.DTO;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace backend.Services.Interface
{
    public interface IUserService
    {
        public bool updatePasswordHandler(UpdatePasswordDTO input, ViewDataDictionary dataView);
        public bool updateUserInfoHandler(UpdateUserInfoDTO input, ViewDataDictionary dataView);
    }
}