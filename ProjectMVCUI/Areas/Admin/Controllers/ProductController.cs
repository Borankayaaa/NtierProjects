using ProjectBLL.Repositories.ConcRep;
using ProjectENTİTİES.Models;
using ProjectMVCUI.Areas.Admin.Data.AdminPageVMs;
using ProjectMVCUI.Models.CustomTools;
using ProjectVM.PureVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectMVCUI.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        ProductRepository _pRep;
        CategoryRepository _cRep;


        public ProductController()
        {
            _cRep = new CategoryRepository();
            _pRep = new ProductRepository();
        }
        public ActionResult ListProducts()
        {
            AdminCategoryListPageVM apvm = new AdminCategoryListPageVM
            {
                Categories = _cRep.Select(x => new AdminCategoryVM
                {
                    ID = x.ID,
                    CategoryName = x.CategoryName,
                    Description = x.Description,

                }).ToList(),
                Products = _pRep.GetAll()
            };
            return View(apvm);
        }
        public ActionResult AddProduct()
        {
            AdminAddUpdateProductPageVM apvm = new AdminAddUpdateProductPageVM
            {
                Categories = _cRep.Select(x => new AdminCategoryVM
                {
                    ID = x.ID,
                    CategoryName = x.CategoryName,
                    Description = x.Description,

                }).ToList()
            };
            return View(apvm);
        }
        //todo :  validation
        [HttpPost]
        public ActionResult AddProduct(Product product, HttpPostedFileBase image, string fileName)
        {
            product.ImagePath = ImageUploader.UploadImage("/Pictures/", image, fileName);
            _pRep.Add(product);
            return RedirectToAction("ListProducts");
        }


        public ActionResult UpdateProduct(int id)
        {
            AdminAddUpdateProductPageVM apvm = new AdminAddUpdateProductPageVM
            {
                Categories = _cRep.Select(x => new AdminCategoryVM
                {
                    ID = x.ID,
                    CategoryName = x.CategoryName,
                    Description = x.Description
                }).ToList(),

                Product = _pRep.Find(id)
            };
            return View(apvm);
        }




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
        public ActionResult Index()
        {
            return View();
        }
    }
}