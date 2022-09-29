using Jobportal.Model.Model;
using System.Threading.Tasks;

namespace Jobportal.Service.RoleService
{
    public interface IRoleService
    {
        Task<RoleMaster> GetById(int id);
    }
}
