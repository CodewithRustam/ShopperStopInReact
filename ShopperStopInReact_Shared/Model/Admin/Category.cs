﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopperStopInReact_Shared.Model.Admin
{
    public class Category
    {
        public int CategoryID { get; set; }
        public int ProductId { get; set; }
        public string? CategoryName { get; set; }
        public string? SubCategoryName { get; set; }
    }
}
