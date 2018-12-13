using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.DAL.Abstract;
using Northwind.Entities;

namespace Northwind.DAL.Concrete.EntityFramework
{
    public class EfProductDal:IProductDal
    {
        NorthwindContext _context = new NorthwindContext(); //Contex'e bağlandık

        public List<Product> GetAll()
        {
          return  _context.Products.ToList(); //tüm ürünleri getir dedik
        }

        public Product Get(int productId)
        {
            return _context.Products.FirstOrDefault(i => i.ProductID == productId);
        }

        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Delete(int productId)
        {
            _context.Products.Remove(_context.Products.FirstOrDefault(i => i.ProductID == productId)); //remove bizden nesne istediği için bu şekilde db den bul onu sil dedik
            _context.SaveChanges();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _context.Products.FirstOrDefault(i => i.ProductID == product.ProductID);
                productToUpdate.ProductName = product.ProductName;
                productToUpdate.UnitPrice = product.UnitPrice;
                productToUpdate.CategoryID = product.CategoryID;

            //if ile ürünü control etmedik null mı diye onu farkı bir yerde yapacağız
            //bu katmanda if gibi kontroller olmamalı burası olabıldıgınce yalın tutulmalıdır

            _context.SaveChanges();
        }
    }
}
