using Microsoft.Data.SqlClient;
using StudentManagementApi.Entities;

namespace StudentManagementApi.Services
{
    public class UserService : IUsersService
    {
        private readonly string _connectionString;
        public UserService(string connectionString)
        {
            _connectionString = connectionString;

        }




        public string CreateUser(Users user)
        {
            string message = "";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Users (FirstName, LastName, Stream, Email, phone) VALUES(@FirstName, @LastName, @Stream, @Email, @Phone)", conn))
                {
                    cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", user.LastName);
                    cmd.Parameters.AddWithValue("@Stream", user.Stream);
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@Phone", user.Phone);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        message = "Data Inserted Successfully";
                    }
                    else
                    {
                        message = "Data Not Successfully Inserted";
                    }

                }

            }
            return message;
        }

        public string DeleteUser(Users user)
        {
            string message = "";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("delete from Users where id=@Id", conn))
                {
                    cmd.Parameters.AddWithValue("@Id", user.Id);

                    conn.Open();

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        message = "Data deleted  Successfully";
                    }
                    else
                    {
                        message = "Data Not deleted";
                    }

                }

            }
            return message;
        }

        public IEnumerable<Users> GetUsers()
        {
            List<Users> users = new List<Users>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Users", conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Users user = new Users
                            {
                                Id = reader.GetInt32(0),
                                FirstName = reader.GetString(1),
                                LastName = reader.GetString(2),
                                Stream = reader.GetString(3),
                                Email = reader.GetString(4),
                                Phone = reader.GetInt64(5)
                            };
                            users.Add(user);
                        }
                    }
                }
            }
            return users;

        }

        public string UpdateUser(Users user)
        {
            string message = "";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Update  Users set FirstName=@FirstName,LastName=@LastName,Stream=@Stream,Email=@Email,Phone=@Phone where id=@Id", conn))
                {
                    cmd.Parameters.AddWithValue("@Id", user.Id);

                    cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", user.LastName);
                    cmd.Parameters.AddWithValue("@Stream", user.Stream);
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@Phone", user.Phone);

                    conn.Open();

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        message = "Data Updated  Successfully";
                    }
                    else
                    {
                        message = "Data Not Updated ";
                    }

                }

            }
            return message;
        }
    }
}
