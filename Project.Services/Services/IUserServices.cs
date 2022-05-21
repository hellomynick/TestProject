using Project.Models.Models;

namespace Project.Services.Services
{
    public interface IUserServices
    {
        Task<UserVm> GetIdUser(int Id);
         Task<int> CreateUser(UserCreate createUser);
         Task<int> UpdateUser(UserVm updateUser);
         Task<int> DeleteUser(int userId);
    }
}