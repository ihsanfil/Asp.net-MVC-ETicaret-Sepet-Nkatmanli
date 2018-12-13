using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Northwind.Interfaces;

namespace Northwind.MvcWebUI.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public PartialViewResult List(int category=0) // tıklanan buraya gelecek
        {
            ViewBag.CurrentCategory = category; // tıklanan

            return PartialView(_categoryService.GetAll());
        }
    }
}