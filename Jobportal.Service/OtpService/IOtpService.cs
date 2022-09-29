using Jobportal.Model.Model;
using System.Threading.Tasks;

namespace Jobportal.Service.OtpService
{
    public interface IOtpService
    {
        Task<OtpMaster> AddOtpAsync(OtpMaster otp);
        Task<OtpMaster> Validate(int otp);
        Task<bool> IsOtpUnique(int otp);
    }
}
