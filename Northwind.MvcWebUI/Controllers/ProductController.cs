using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Northwind.BLL.Concrete;
using Northwind.DAL.Concrete.EntityFramework;
using Northwind.Entities;
using Northwind.Interfaces;
using Northwind.MvcWebUI.Models;

namespace Northwind.MvcWebUI.Controllers
{
    public class ProductController : Controller
    {
        //ProductManager _productManager = new ProductManager(new EfProductDal()); //önerilmeyen yöntem

        private IProductService _productService;
        public ProductController(IProductService productService) //Constructor'ü set ettik buraya ne verirsek _productService'in içi onun ile dolacak bağımlılığı ortadan kaldımak için yaptık
        {
            _productService = productService;
        }

        public int PageSize = 5; //default olarak her seferinde 5 urun dedık
        public ActionResult Index(int page = 1, int category = 0) //burası tıklanınca gelicek default
        {
            //her seferinde 5 urun gosterıyor ve bı oncekı 5 urunu atlıyor
            //Skip ile kaç eleman atlanacağını söyledik parametre kaç gelirse -1*5 şeklinde 
            //Take(5)  5 elemanı al dedik

            List<Product> products = _productService.GetAll().Where(i => i.CategoryID == category||category== 0).ToList();

            return View(new ProducViewModel
            {
                Products = products.Skip((page - 1) * PageSize).Take(5).ToList(),
                PageingInfo = new PageingInfo
                {
                    ItemsPerpage=PageSize, //birsayfadaki ürün sayısı
                    TotalItems=products.Count, //toplam ürün sayısı
                    CurrentPage=page, //seçili olan sayfa
                    CurrentCategory=category
                }

            });
        }
    }
}