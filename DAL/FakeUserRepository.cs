using Albums3Layer.BBL.Models;
using BLL.Interfaces;

public class FakeUserRepository : IUserRepository
{
    private List<User> _users = new List<User>();

    public void CreateUser(User user)
    {
        _users.Add(user);
    }

    // Implement the GetUserById method
    public User GetUserById(int id)
    {
        return _users.FirstOrDefault(u => u.user_id == id);
    }

    // Implement the GetAllUsers method
    public List<User> GetAllUsers()
    {
        return new List<User>(_users);
    }

    // Implement the DeleteUser method
    public void DeleteUser(int id)
    {
        var user = _users.FirstOrDefault(u => u.user_id == id);
        if (user != null)
        {
            _users.Remove(user);
        }
    }

    public void EditUser(User user)
    {
        var existingUser = _users.FirstOrDefault(u => u.user_id == user.user_id);
        if (existingUser != null)
        {
            existingUser.username = user.username;
            existingUser.password = user.password;
        }
    }
}