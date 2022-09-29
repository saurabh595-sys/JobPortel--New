using Jobportal.Model.Dto.UserDto;
using Jobportal.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobPortal.Repository.UserRepository;
using JobPortal.Repository.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Jobportal.Service.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;

        }
        public async Task<IEnumerable<GetUserDto>> GetUsersAsync(Pagination pagination)
        {
            var user = await _userRepository.GetUsersAsync(pagination);
            if (user != null)
                return user;
            return null;
        }

        public async Task<User> GetUserByIdAsync(int Id)
        {
            var user= await _userRepository.GetByIdAsync(Id);
            if (user != null)
                return user;
            return null;
        }


        public async Task<User> AddUserAsync(AddUserDto Users)
        {

            User user = new User();
            user.Name = Users.Name;
            user.Password = BCrypt.Net.BCrypt.HashPassword(Users.Password);
            user.RoleId = Users.RoleId;
            user.Email = Users.Email;
            user.CreatedDate = DateTime.Now;
            user.ModifiedDate = DateTime.Now;
            user.IsActive = true;
            var result= await _userRepository.AddAsync(user);
            if (result != null)
                return result;
            return null;

        }

        public async Task<User> UpdateUserAsync(int id, UpdateUserDto Users)
        {
            User user = await _userRepository.GetByIdAsync(id);
            if (user != null)
            {
                user.Name = Users.Name;
                user.Email = Users.Email;
                user.ModifiedDate = DateTime.Now;
                await _userRepository.UpdateAsync(user);
                return user;
            }
            return null;
        }

        public async Task<User> GetUserAsync(string email, string password)
        {

            var user = await _userRepository.GetDefault(x => x.Email == email);
            if (user != null)
            {
                if (!BCrypt.Net.BCrypt.Verify(password, user.Password))
                {
                    return null;
                }
                return user;
            }
            return null;
        }
    }
}
