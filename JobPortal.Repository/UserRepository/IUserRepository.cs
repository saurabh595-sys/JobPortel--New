using Jobportal.Model.Dto.UserDto;
using Jobportal.Model.Model;
using JobPortal.Repository.Inrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Repository.UserRepository
{

   public interface IUserRepository:IRepository<User>
    {
        Task<IEnumerable<GetUserDto>> GetUsersAsync(Pagination pagination);
    }
}
