using Backend.Models;
using Backend.Controllers.DTO;
using Microsoft.AspNetCore.Mvc.ViewFeatures;


namespace Backend.Services.Interface
{
    public interface IAuthService
    {
        public string LoginHandler(LoginDTO input, ViewDataDictionary dataView);
        public bool RegisterHandler(RegisterDTO input, ViewDataDictionary dataView);
        public string HashingPassword(string password);
        public bool ComparePassword(string inputPassword, string encryptedPassword);
    }
}