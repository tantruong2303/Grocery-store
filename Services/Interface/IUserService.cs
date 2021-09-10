using backend.Models;
using backend.Controllers.DTO;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace backend.Services.Interface
{
    public interface IUserService
    {
        public User loginHandler(LoginDTO input, ViewDataDictionary dataView);
    }
}