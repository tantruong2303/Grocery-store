using Backend.Controllers.DTO;
using Backend.Models;
using Microsoft.AspNetCore.Mvc.ViewFeatures;


namespace Backend.Services.Interface
{
    public interface IAuthService
    {
        public string LoginHandler(string userId);
        public bool RegisterHandler(User user);
        public string HashingPassword(string password);
        public bool ComparePassword(string inputPassword, string encryptedPassword);
    }
}