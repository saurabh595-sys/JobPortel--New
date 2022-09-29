using Jobportal.Model.Model;
using JobPortal.Repository.Contexts;
using JobPortal.Repository.Inrastructure;

namespace JobPortal.Repository.AccountRepository
{
    public class AccountRepository : Repository<User>, IAccountRepository
    {
        public AccountRepository(Context context) : base(context)
        {

        }
    }
}
