using ShopperStopInReact_Shared.DbContextData;
using ShopperStopInReact_Shared.IRepository.IAdminRepository;
using ShopperStopInReact_Shared.Model.Admin;

namespace ShopperStopInReact_Shared.Repositoy.AdminRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ShoppingDbContext _context;
        public CategoryRepository(ShoppingDbContext _context)
        {
            this._context = _context;
        }
        public bool AddProductCategory(Category category)
        {
            try
            {
                if (category != null)
                {
                    _context.Category.Add(category);
                    int count = _context.SaveChanges();
                    if (count == 1)
                        return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return false;
        }
    }
}
