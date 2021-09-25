using Backend.Models;

namespace Backend.DAO.Interface
{
    public interface IUserRepository
    {
        public User GetUserByUsername(string username);
        public User GetUserById(string id);
        public bool RegisterHandler(User user);
        public bool UpdatePasswordHandler(User user);
        public bool UpdateUserInfoHandler(User user);
    }
}