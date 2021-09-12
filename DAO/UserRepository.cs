using System.Linq;
using System;

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
            User user = this.DBContext.user.FirstOrDefault(item => item.username == username);
            return user;
        }

        public User GetUserById(string id)
        {
            User user = this.DBContext.user.FirstOrDefault(item => item.userId == id);
            return user;
        }
    }
}