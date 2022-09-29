using Jobportal.Model.Model;
using JobPortal.Repository.Contexts;
using JobPortal.Repository.Inrastructure;
using JobPortal.Repository.RoleRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Repository.AccountRepository
{
   public class AccountRepository : Repository<User>, IAccountRepository
    {
        public AccountRepository(Context context) : base(context)
        {

        }
    }
}
