using ProjectENTİTİES.Models;
using ProjectVM.PureVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectMVCUI.Areas.Admin.Data.AdminPageVMs
{
    public class AdminCategoryListPageVM
    {
        public List<AdminCategoryVM> Categories { get; set; }
        public List<Product>products { get; set; }
    }
}