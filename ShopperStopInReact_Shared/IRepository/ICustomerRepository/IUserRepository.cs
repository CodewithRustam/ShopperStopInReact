using ShopperStopInReact_Shared.Model.Customer;
using ShopperStopInReact_Shared.ViewModel.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopperStopInReact_Shared.IRepository.ICustomerRepository
{
    public interface IUserRepository
    {
        bool AddUser(User user);
        List<User> GetUsers();
        User GetUserByUserId(int userId);
        bool DeleteUser(int userId);
        bool UpdateUserDetails(User user);
        bool VerifyUserMobile(string mobileNo);
        bool VerifyUserEmail(string email);
        UserNameID LoginInCheck(string emailOrMobile, string password);
        bool SaveOTPLog(OtpVerificationLog otpVerificationLog);
        UserNameID VerifyOTPAndMobile(string mobile, string OTP);
        string OtpExpired(string mobile, string OTP);
    }
}
