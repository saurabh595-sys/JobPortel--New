using Jobportal.Model.Model;
using JobPortal.Repository.Contexts;
using JobPortal.Repository.Inrastructure;

namespace JobPortal.Repository.RoleRepository
{
    public class RoleRepository : Repository<RoleMaster>, IRoleRepository
    {
        public RoleRepository(Context context):base(context)
        {

        }
    }
}
