using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.BLL.Concrete;
using Northwind.DAL.Concrete.EntityFramework;
using Northwind.Entities;
using Northwind.Interfaces;

namespace Northwind.WcfLibrary.Concrete
{
    public class ProductService: IProductService
    {
        //Instance Provider ile ezilecek
        ProductManager _productManger = new ProductManager(new EfProductDal()); //hangi teknoloji ile çalışacağınız belirttiğimiz yer

        List<Product> IProductService.GetAll()
        {
            return _productManger.GetAll();
        }

        public Product Get(int productId)
        {
            return _productManger.Get(productId);
        }

        public void Delete(int productId)
        {
           _productManger.Delete(productId);
        }

        public void Update(Product product)
        {
            _productManger.Update(product);
        }

        public void Add(Product product)
        {
            _productManger.Add(product);
        }

    }
}
