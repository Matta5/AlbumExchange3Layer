using Albums3Layer.BLL;
using Albums3Layer.BBL.Models;
using System.Data.SqlClient;
using BLL.Interfaces;


namespace DAL
{
    public class UserRepository : IUserRepository
    {
        private string connectionString = "Server=Mathijs\\MSSQLSERVER02;Database=AlbumExchange;User Id=test;Password=test;TrustServerCertificate=True;Encrypt=False;Trusted_Connection=true;";

        public User GetUserById(int id)
        {
            User user = null;

            using (SqlConnection s = new SqlConnection(connectionString))
            {
                s.Open();

                string selectQuery = "SELECT * FROM [User] WHERE user_id = @UserId";
                SqlCommand cmd = new SqlCommand(selectQuery, s);
                cmd.Parameters.AddWithValue("@UserId", id);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new User
                        {
                            user_id = reader.GetInt32(0),
                            username = reader.GetString(1),
                            email = reader.GetString(2),
                            password = reader.GetString(3)
                            // Add other properties as needed
                        };
                    }
                }
            }

            return user;
        }

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            using (SqlConnection s = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM [User]", s);
                s.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        User u = new User();
                        u.user_id = reader.GetInt32(0);
                        u.username = reader.GetString(1);
                        u.email = reader.GetString(2);
                        u.password = reader.GetString(3);
                        u.profile_picture = reader.GetString(4);
                        users.Add(u);
                    }
                }
             return users;
            }
        }

        public void CreateUser(User user)
        {
            using (SqlConnection s = new SqlConnection(connectionString))
            {
                s.Open();

                string insertQuery = "INSERT INTO [User] (username, email, password) VALUES (@Username, @Email, @Password)";
                SqlCommand cmd = new SqlCommand(insertQuery, s);
                cmd.Parameters.AddWithValue("@Username", user.username);
                cmd.Parameters.AddWithValue("@Email", user.email);
                cmd.Parameters.AddWithValue("@Password", user.password);

                cmd.ExecuteNonQuery();
            }
        }
    }
}