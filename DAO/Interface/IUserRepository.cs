using backend.Models;

namespace backend.DAO.Interface
{
    public interface IUserRepository
    {
        public User getUserByUsername(string username);
        public User getUserById(string id);
    }
}