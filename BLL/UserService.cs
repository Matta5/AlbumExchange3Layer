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
            string passwordValidationResult = IsValidPassword(user.password);
            if (passwordValidationResult != null)
            {
                throw new ArgumentException(passwordValidationResult);
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

        public string IsValidPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                return "Password cannot be empty.";

            bool hasUpperCase = Regex.IsMatch(password, "[A-Z]");
            bool hasNumber = Regex.IsMatch(password, "[0-9]");

            if (!hasUpperCase)
                return "Password must include at least one capital letter.";
            if (!hasNumber)
                return "Password must include at least one number.";

            return null; // null indicates the password is valid
        }
    }
}
