using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Northwind.Entities;
using Northwind.Interfaces;

namespace Northwind.MvcWebUI.Controllers
{
    public class AdminController : Controller
    {
        private IProductService _productService;

        public AdminController(IProductService productService)
        {
            _productService = productService;
        }

        public ActionResult Index()
        {
            return View(_productService.GetAll());
        }

        [Authorize]
        public ActionResult CreateNew()
        {
            return View(new Product());
        }

        [HttpPost]
        [Authorize]
        public ActionResult CreateNew(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.Add(product);
                return RedirectToAction("Index", "Admin");
            }

            return View(product);
        }
        public ActionResult Edit(int productID)
        {
            Product product = _productService.Get(productID);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.Update(product);
                return RedirectToAction("Index", "Admin");
            }

            return View(product);
        }
        //public ActionResult Delete()
        //{
        //    return View(new Product());
        //}

        //[HttpPost]
        //public ActionResult Delete(Product product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _productService.Delete(product);
        //        return RedirectToAction("Index", "Admin");
        //    }

        //    return View(product);
        //}
    }
}