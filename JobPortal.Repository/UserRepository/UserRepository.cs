using Jobportal.Model.Dto.UserDto;
using Jobportal.Model.Model;
using JobPortal.Repository.Contexts;
using JobPortal.Repository.Inrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Repository.UserRepository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(Context context) : base(context)
        {

        }
        public async Task<IEnumerable<GetUserDto>> GetUsersAsync(Pagination pagination)
        {
            var users = await (from u in _context.User
                               select new GetUserDto
                               {
                                   Id = u.Id,
                                   Name = u.Name,
                                   CreatedDate = u.CreatedDate,
                                   Email = u.Email,
                                   IsActive = u.IsActive,

                               }).OrderBy(x => x.Id)
                                .ToListAsync();
            //var count = users.Count();
            //if (pagination.PageSize == -1)
            //{
            //    pagination.PageSize = count;
            //}

            var result = users.Skip((pagination.PageNumber - 1) * pagination.PageSize)
                             .Take(pagination.PageSize == -1 ? 10000 : pagination.PageSize);

            return result;



        }
    }
}
