using ShopperStopInReact_Shared.Model.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopperStopInReact_Shared.IRepository.IAdminRepository
{
    public interface ICategoryRepository
    {
        bool AddProductCategory(Category category);
    }
}
