using ShopperStopInReact_Shared.Model.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopperStopInReact_Shared.IRepository.IAdminRepository
{
    public interface IAdminDetailsRepository
    {
        bool AddAdminDetails(AdminDetails adminDetails);
        bool AdminLoginCheck(string Email,string Password);
        bool UpdateAdminDetails(AdminDetails adminDetails);
        AdminDetails GetAdminDetails(int id);
        List<AdminDetails> GetAllAdminDetails();
        bool RemoveAdmin(int id);   
    }
}
