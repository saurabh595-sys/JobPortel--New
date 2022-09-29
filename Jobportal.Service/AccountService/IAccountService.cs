using Jobportal.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobportal.Service.AccountService
{
   public interface IAccountService
    {
        Task<bool> ForgotPassword(string email);
        Task<User> ResetPassword(int otp, string newPassword, string confirmPassword);
    }
}
