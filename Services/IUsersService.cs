using StudentManagementApi.Entities;

namespace StudentManagementApi.Services
{
    public interface IUsersService
    {
        public IEnumerable<Users> GetUsers();

        public string CreateUser(Users user);

        public string DeleteUser(Users user);

        public string UpdateUser(Users user);
    }
}
