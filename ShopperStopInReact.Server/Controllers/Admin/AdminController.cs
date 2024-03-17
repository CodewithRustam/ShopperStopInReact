using Microsoft.AspNetCore.Mvc;
using ShopperStopInReact_Shared.IRepository.IAdminRepository;
using ShopperStopInReact_Shared.Maper;
using ShopperStopInReact_Shared.Model.Admin;
using ShopperStopInReact_Shared.ViewModel.Admin;
using ShopperStopInReact_Shared.ViewModel.Customer;

namespace ShopperStop.Server.Controllers.Admin
{
    [Route("api/[controller]/{action}")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminDetailsRepository _iadmindminRepository; 
        public AdminController(IAdminDetailsRepository _iadmindminRepository)
        { 
           this._iadmindminRepository = _iadmindminRepository;
        }
        public IActionResult AddAdmin(AdminViewModel adminViewModel)
        {
            try
            {
                AdminDetails adminDetails = new AdminDetails();
                if (adminViewModel != null)
                {
                    MappingProfile.MapObjectData(adminViewModel, adminDetails);
                    bool flag= _iadmindminRepository.AddAdminDetails(adminDetails);
                    if (flag) return Ok(true);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return BadRequest(false);
        }
        public IActionResult AdminLogInVerify(LoginViewModel loginViewModel)
        {
            try
            {
                if (loginViewModel != null)
                {
                    _iadmindminRepository.AdminLoginCheck(loginViewModel.EmailOrMobile, loginViewModel.Password);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return BadRequest(false);
        }
    }
}
