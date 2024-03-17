using Microsoft.AspNetCore.Mvc;
using ShopperStopInReact_Shared.IRepository.ICustomerRepository;
using ShopperStopInReact_Shared.Maper;
using ShopperStopInReact_Shared.Model.Customer;
using ShopperStopInReact_Shared.Repositoy.CustomerRepository;
using ShopperStopInReact_Shared.ViewModel.Customer;

namespace ShopperStopInReactInReact.Server.Controllers.Customer
{
    [Route("api/[controller]/{action}")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepository _IUserRepository;
        public UserController(IUserRepository _IUserRepository)
        {
            this._IUserRepository = _IUserRepository;
        }
        [HttpPost]
        public IActionResult RegisterUser(UserRegistrationViewModel userViewmodel)
        {
            try
            {
                if (userViewmodel != null)
                {
                    User user = new User();
                    MappingProfile.MapObjectData(userViewmodel, user);
                    bool flag = _IUserRepository.AddUser(user);
                    if (flag) return Ok(flag);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return BadRequest();
        }
        [HttpGet]
        public IActionResult GetUsers()
        {
            try
            {
                List<User> users = _IUserRepository.GetUsers();
                if (users.Count > 0) return Ok(users);
            }
            catch (Exception)
            {

                throw;
            }
            return BadRequest();
        }
        [HttpGet]
        public IActionResult GetUserById(int userId)
        {
            try
            {
                User user = _IUserRepository.GetUserByUserId(userId);
                if (user != null) return Ok(user);
            }
            catch (Exception)
            {

                throw;
            }
            return BadRequest();
        }
        [HttpGet]
        public IActionResult VerifyUserMobile(string MobileNo)
        {
            try
            {
                bool flag = _IUserRepository.VerifyUserMobile(MobileNo);
                if (flag) return Ok(flag);
            }
            catch (Exception)
            {

                throw;
            }
            return BadRequest();
        }
        [HttpGet]
        public IActionResult VerifyUserEmail(string? Email)
        {
            try
            {
                bool flag = _IUserRepository.VerifyUserEmail(Email);
                if (flag) return Ok(flag);
            }
            catch (Exception)
            {

                throw;
            }
            return BadRequest();
        }
        [HttpPost]
        public IActionResult LoginInCheck(LoginViewModel loginViewModel)
        {
            try
            {
                UserNameID userNameAndID = _IUserRepository.LoginInCheck(loginViewModel.EmailOrMobile, loginViewModel.Password);
                if (userNameAndID!= null)
                {
                    return Ok(userNameAndID);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return BadRequest();
        }
        [HttpPost]
        public IActionResult SaveOTP(OtpVerificationLog otpVerificationLog)
        {
            try
            {
                bool flag = _IUserRepository.SaveOTPLog(otpVerificationLog);
                if (flag)
                    return Ok(flag);
            }
            catch (Exception)
            {

                throw;
            }
            return BadRequest();
        }
        [HttpPost]
        public IActionResult VerifyOTP(OtpVerificationViewModel otpVerificationView)
        {
            try
            {
                string message = _IUserRepository.OtpExpired(otpVerificationView.Mobile, otpVerificationView.OTP);
                if (message== "OTP Not Expired")
                {
                    UserNameID userNameAndID = _IUserRepository.VerifyOTPAndMobile(otpVerificationView.Mobile, otpVerificationView.OTP);
                    if (userNameAndID != null)
                    {
                        return Ok(userNameAndID);
                    }
                    else
                    {
                        return BadRequest("Incorrect OTP");
                    }
                }
                else if(message== "OTP Expired" || message== "Incorrect OTP")
                {
                    return BadRequest(message);
                }
                return BadRequest();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
