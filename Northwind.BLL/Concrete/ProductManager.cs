using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.DAL.Abstract;
using Northwind.Entities;
using Northwind.Interfaces;

namespace Northwind.BLL.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> GetAll()
        {
            //Validation
            //Security
            //Ex. Handling burada yapılabilir

            return _productDal.GetAll();
        }

        public Product Get(int productId)
        {
            return _productDal.Get(productId);
        }

        public void Delete(int productId)
        {
            _productDal.Delete(productId);
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }

        public void Add(Product product)
        {
            _productDal.Add(product);
        }

    }
}
