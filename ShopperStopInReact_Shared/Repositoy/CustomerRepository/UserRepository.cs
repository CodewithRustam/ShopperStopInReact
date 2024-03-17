using Microsoft.EntityFrameworkCore;
using ShopperStopInReact_Shared.DbContextData;
using ShopperStopInReact_Shared.IRepository.ICustomerRepository;
using ShopperStopInReact_Shared.Model.Customer;
using ShopperStopInReact_Shared.ViewModel.Customer;

namespace ShopperStopInReact_Shared.Repositoy.CustomerRepository
{
    public class UserRepository : IUserRepository
    {
        private ShoppingDbContext _DbContext;
        public UserRepository(ShoppingDbContext _DbContext)
        {
            this._DbContext = _DbContext;
        }
        public bool AddUser(User user)
        {
            try
            {
                user.RegisterDate = DateTime.Now;
                _DbContext.User?.Add(user);
                int count = _DbContext.SaveChanges();
                if (count == 1)
                    return true;

            }
            catch (Exception)
            {

                throw;
            }
            return false;
        }

        public bool DeleteUser(int userId)
        {
            try
            {
                User? user = _DbContext.User?.Where(x => x.UserId == userId && x.IsDeleted == false).FirstOrDefault();
                if (user != null)
                {
                    user.IsDeleted = true;
                    user.DeletedDate = DateTime.Now;
                    int count = _DbContext.SaveChanges();
                    if (count == 1) return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return false;
        }

        public User GetUserByUserId(int userId)
        {
            try
            {
                User? user = _DbContext.User?.Where(x => x.UserId == userId && x.IsDeleted == false).FirstOrDefault();
                if (user != null) return user;
            }
            catch (Exception)
            {

                throw;
            }
            return null;
        }

        public List<User> GetUsers()
        {
            try
            {
                List<User>? users = _DbContext.User?.ToList();
                if (users.Count > 0) return users;
            }
            catch (Exception)
            {

                throw;
            }
            return null;
        }

        public UserNameID LoginInCheck(string emailOrMobile, string password)
        {
            try
            {
                if (!string.IsNullOrEmpty(emailOrMobile) && !string.IsNullOrEmpty(password))
                {
                    UserNameID? userNameID = _DbContext.User?.Where(x => x.Email == emailOrMobile || x.Mobile == emailOrMobile && x.Password == password && x.IsDeleted == false).Select(x => new UserNameID
                    {
                        Name = x.Name,
                        UserId = x.UserId,
                    }).FirstOrDefault();

                    if (userNameID!=null)
                    {
                        return userNameID;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return null;
        }

        public bool SaveOTPLog(OtpVerificationLog otpVerificationLog)
        {
            try
            {
                if (otpVerificationLog != null)
                {
                    int usedId = _DbContext.User.Where(x => x.Mobile == otpVerificationLog.Mobile).Select(x => x.UserId).FirstOrDefault();
                    otpVerificationLog.UserId = usedId;
                    _DbContext.OtpVerificationLog?.Add(otpVerificationLog);
                    int count = _DbContext.SaveChanges();
                    if (count == 1) return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return false;
        }

        public bool UpdateUserDetails(User user)
        {
            try
            {
                User? userData = _DbContext.User?.Where(x => x.UserId == user.UserId && x.IsDeleted == false).FirstOrDefault();
                if (userData != null)
                {
                    userData.Mobile = user.Mobile;
                    userData.Email = user.Mobile;
                    userData.UpdatedDate = DateTime.Now;
                    userData.UpdatedBy = $"{user.Name} : {user.UserId}";
                    int count = _DbContext.SaveChanges();
                    if (count == 1) return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return false;
        }

        public UserNameID VerifyOTPAndMobile(string mobile, string OTP)
        {
            try
            {
                UserNameID userNameID = new UserNameID();
                if (!string.IsNullOrEmpty(mobile) && !string.IsNullOrEmpty(OTP))
                {
                    var otpVerified = _DbContext.OtpVerificationLog?.Where(x => x.Mobile == mobile && x.OtpCode == OTP && x.IsVerified == false).FirstOrDefault();
                    if (otpVerified != null)
                    {
                        otpVerified.IsVerified = true;
                        _DbContext.SaveChanges();
                        string? name = _DbContext.User?.Where(x => x.Mobile == otpVerified.Mobile).Select(x => x.Name).FirstOrDefault();
                        if (name != null)
                        {
                            userNameID.Name = name;
                            userNameID.UserId = otpVerified.UserId;
                            if (userNameID.UserId > 0 && userNameID.Name != null) return userNameID;
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return null;
        }

        public bool VerifyUserEmail(string email)
        {
            try
            {
                int? count = _DbContext.User?.Where(x => x.Email == email && x.IsDeleted == false).Count();
                if (count > 0) return true;
            }
            catch (Exception)
            {

                throw;
            }
            return false;
        }

        public bool VerifyUserMobile(string mobileNo)
        {
            try
            {
                int? count = _DbContext.User?.Where(x => x.Mobile == mobileNo && x.IsDeleted == false).Count();
                if (count > 0) return true;
            }
            catch (Exception)
            {

                throw;
            }
            return false;
        }
        public string OtpExpired(string mobile,string OTP)
        {
            string message = null;
            try
            {
                if (mobile!=null && OTP !=null)
                {
                    int? count=_DbContext.OtpVerificationLog.Where(x=>x.Mobile==mobile && x.OtpCode==OTP).Count();
                    if(count==1)
                    {
                        var otpVerificationLog = _DbContext.OtpVerificationLog.Where(x => x.OTPExpireTime >= DateTime.Now && x.Mobile == mobile && x.OtpCode==OTP).OrderByDescending(x => x.OtpVerificationLogId).FirstOrDefault();
                        if (otpVerificationLog != null)
                        {
                            if (otpVerificationLog.OtpVerificationLogId > 0)
                            {
                                return message = "OTP Not Expired";
                            }
                        }
                        else
                        {
                            return message = "OTP Expired";
                        }
                    }
                    else
                    {
                        return message = "Incorrect OTP";
                    }                
                }
            }
            catch (Exception)
            {

                throw;
            }
            return null;
        }
        
    }
}
