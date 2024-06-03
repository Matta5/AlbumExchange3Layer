using Albums3Layer.BBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserRepository
    {
        public User GetUserById(int id);
        public List<User> GetAllUsers();
        public void CreateUser(User user);
    }
}
