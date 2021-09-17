using Backend.Controllers.DTO;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Backend.Services.Interface
{
    public interface IUserService
    {
        public bool UpdatePasswordHandler(UpdatePasswordDTO input, ViewDataDictionary dataView);
        public bool UpdateUserInfoHandler(UpdateUserInfoDTO input, ViewDataDictionary dataView);
    }
}