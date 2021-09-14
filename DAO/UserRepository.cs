using System.Linq;
using Backend.DAO.Interface;
using Backend.Utils;
using Backend.Models;

namespace Backend.DAO
{
    public class UserRepository : IUserRepository
    {
        private readonly DBContext DBContext;
        public UserRepository(DBContext dBContext)
        {
            this.DBContext = dBContext;
        }

        public User GetUserByUsername(string username)
        {
            User user = this.DBContext.User.FirstOrDefault(item => item.Username == username);
            return user;
        }

        public User GetUserById(string id)
        {
            User user = this.DBContext.User.FirstOrDefault(item => item.UserId == id);
            return user;
        }
    }
}