using Jobportal.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobportal.Service.RoleService
{
    public interface IRoleService
    {
        Task<RoleMaster> GetById(int id);
    }
}
