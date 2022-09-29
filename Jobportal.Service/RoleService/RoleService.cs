using Jobportal.Model.Model;
using JobPortal.Repository.RoleRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobportal.Service.RoleService
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        public RoleService(IRoleRepository role)
        {
            _roleRepository = role;
        }
        public async Task<RoleMaster> GetById(int id)
        {
            var role= await _roleRepository.GetByIdAsync(id);
            if (role != null)
                return role;
            return null;
        }
    }
}
