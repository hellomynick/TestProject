using Microsoft.EntityFrameworkCore;
using Project.EntityData.EF;
using Project.EntityData.Models;
using Project.Models.Models;
using Project.Services.Exceptions;

namespace Project.Services.Services
{
    public class UserService : IUserServices
    {
        private readonly ProjectContext _context;
        public UserService(ProjectContext context)
        {
            _context = context;
        }
        public async Task<int> CreateUser(UserCreate createUser)
        {
            var user = new User()
            {
                Name = createUser.Name,
                Age = createUser.Age,
                DoB = createUser.DoB,
                Sex = createUser.Sex,
                Address = createUser.Address
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user.Id;
        }
        public async Task<int> UpdateUser(UserVm updateUser)
        {
            var user = await _context.Users.FindAsync(updateUser.Id);
            if (user == null)
            {
                throw new ProjectException($"Can not find user with id {updateUser.Id}");
            }
            user.Name = updateUser.Name;
            user.Age = updateUser.Age;
            user.DoB = updateUser.DoB;
            user.Sex = updateUser.Sex;
            user.Address = updateUser.Address;
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteUser(int Id)
        {
            var user = await _context.Users.SingleOrDefaultAsync(i => i.Id == Id);
            if (user == null)
            {
                throw new ProjectException($"Can not find user with id {Id}");
            }
            _context.Users.Remove(user);
            return await _context.SaveChangesAsync();
        }

        public async Task<UserVm> GetIdUser(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            var userVm = new UserVm()
            {
                Id = user.Id,
                Name = user.Name,
                Age = user.Age,
                DoB = user.DoB,
                Address = user.Address,
                Sex = user.Sex,
            };
            return userVm;
        }
    }
}
