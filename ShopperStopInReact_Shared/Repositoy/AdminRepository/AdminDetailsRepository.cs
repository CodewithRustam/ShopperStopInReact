using ShopperStopInReact_Shared.DbContextData;
using ShopperStopInReact_Shared.IRepository.IAdminRepository;
using ShopperStopInReact_Shared.Model.Admin;

namespace ShopperStopInReact_Shared.Repositoy.AdminRepository
{
    public class AdminDetailsRepository : IAdminDetailsRepository
    {
        public readonly ShoppingDbContext shoppingDbContext;
        public AdminDetailsRepository(ShoppingDbContext shoppingDbContext) 
        { 
          this.shoppingDbContext = shoppingDbContext;
        }
        public bool AddAdminDetails(AdminDetails adminDetails)
        {
            try
            {
                if (adminDetails != null)
                {
                    adminDetails.CreatedAt = DateTime.Now;
                    shoppingDbContext.AdminDetails?.Add(adminDetails);
                    int count=shoppingDbContext.SaveChanges();
                    if (count ==1)
                        return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }

        public bool AdminLoginCheck(string Email, string Password)
        {
            throw new NotImplementedException();
        }

        public AdminDetails GetAdminDetails(int id)
        {
            throw new NotImplementedException();
        }

        public List<AdminDetails> GetAllAdminDetails()
        {
            throw new NotImplementedException();
        }

        public bool RemoveAdmin(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateAdminDetails(AdminDetails adminDetails)
        {
            throw new NotImplementedException();
        }
    }
}
