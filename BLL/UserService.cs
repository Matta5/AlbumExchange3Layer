using Albums3Layer.BBL.Models;
using BLL.Interfaces;

namespace Albums3Layer.BLL
{
    public class UserService
    {
        private IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {

            this.userRepository = userRepository;
        }
        public User GetUserById(int id)
        {
            return userRepository.GetUserById(id);
        }

        public List<User> GetAllUsers()
        {
            return userRepository.GetAllUsers();
        }

        public void CreateUser(User user)
        {
          userRepository.CreateUser(user);
        }

        public void DeleteUser(int id)
        {
          userRepository.DeleteUser(id);
        }

        public void EditUser(User user)
        {
             userRepository.EditUser(user);
        }

        // Add other methods for implementing the business logic here
    }
}
