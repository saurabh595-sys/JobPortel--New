using Jobportal.Model.Dto.UserDto;
using Jobportal.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobportal.Service.UserService
{
   public interface IUserService
    {
        Task<IEnumerable<GetUserDto>> GetUsersAsync(Pagination pagination);
        Task<User> GetUserByIdAsync(int id);
        Task<User> AddUserAsync(AddUserDto Users);
        Task<User> UpdateUserAsync(int id,UpdateUserDto Users);
        Task<User> GetUserAsync(string email, string password);
        
     
    }
}
