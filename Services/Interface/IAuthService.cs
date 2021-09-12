using Backend.Models;
using Backend.Controllers.DTO;
using Microsoft.AspNetCore.Mvc.ViewFeatures;


namespace Backend.Services.Interface
{
    public interface IAuthService
    {
        public string loginHandler(LoginDTO input, ViewDataDictionary dataView);
        public bool registerHandler(RegisterDTO input, ViewDataDictionary dataView);
        public string hashingPassword(string password);
        public bool comparePassword(string inputPassword, string encryptedPassword);
    }
}