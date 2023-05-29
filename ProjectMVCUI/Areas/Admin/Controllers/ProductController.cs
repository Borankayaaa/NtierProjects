using ProjectBLL.Repositories.ConcRep;
using ProjectMVCUI.Areas.Admin.Data.AdminPageVMs;
using ProjectVM.PureVMs;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectENTİTİES.Models;

namespace ProjectMVCUI.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        ProductRepository _pRep;
        CategoryRepository _cRep;

        public ProductController()
        {
            _pRep = new ProductRepository();
            _cRep = new CategoryRepository();

        }

      //Asagıda Action'da parametre olarak istenen id aslında CategoryID'sidir Product'ın kendi ıd'si degildir...

        public ActionResult ListProducts(int? id)
        {
            AdminCategoryListPageVM apvm = new AdminCategoryListPageVM
            {
                Categories = _cRep.Select(x => new AdminCategoryVM
                {
                    ID = x.ID,
                    CategoryName = x.CategoryName,
                    Description = x.Description,

                }).ToList(),
                products = _pRep.GetAll()
                
            };
            return View(apvm);
        }
        public ActionResult AddProduct(int? id)
        {
            AdminCategoryListPageVM apvm = new AdminCategoryListPageVM
            {
                Categories = _cRep.Select(x => new AdminCategoryVM
                {
                    ID = x.ID,
                    CategoryName = x.CategoryName,
                    Description = x.Description,

                }).ToList(),
            };
            return View(apvm);
        }
            [HttpPost] 

        public ActionResult AddProduct(Product product)
        {
            _pRep.Add(product);
            return RedirectToAction("ListProducts");
        }

        public ActionResult UpdateProduct(int id)
        {
            return View(_cRep.Find(id));
        }
        //Todo: VM refactoring unutulmasın...

        //Todo: Resim Güncelleme
        [HttpPost]

        public ActionResult UpdateProduct(Product product) 
        {
            _pRep.Update(product);
            return RedirectToAction("ListProducts");
        }

        public ActionResult DeleteProduct(int id) 
        {
            _pRep.Delete(_pRep.Find(id));
            return RedirectToAction("ListProducts");
        }

        

    }
}