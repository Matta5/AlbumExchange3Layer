using Albums3Layer.BBL.Models;
using BLL.Interfaces;
using System.Text.RegularExpressions;

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
            if (!IsValidPassword(user.password))
            {
                throw new ArgumentException("Password must include at least one capital letter.");
            }
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

        public bool IsValidPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                return false;

            // Check if the password contains at least one capital letter
            return Regex.IsMatch(password, "[A-Z]");
        }
    }
}
