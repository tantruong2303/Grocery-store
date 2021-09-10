using System.Linq;
using System;

using backend.DAO.Interface;
using backend.Utils;
using backend.Models;

namespace backend.DAO
{
    public class UserRepository : IUserRepository
    {
        private readonly DBContext dbContext;
        public UserRepository(DBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public User getUserByUsername(string username)
        {
            User user = this.dbContext.user.FirstOrDefault(item => item.username == username);
            return user;
        }
    }
}