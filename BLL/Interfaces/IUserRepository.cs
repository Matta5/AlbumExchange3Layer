using Albums3Layer.BBL.Models;

namespace BLL.Interfaces
{
    public interface IUserRepository
    {
        public User GetUserById(int id);
        public List<User> GetAllUsers();
        public void CreateUser(User user);
        public void DeleteUser(int id);
        public void EditUser(User user);
    }
}
