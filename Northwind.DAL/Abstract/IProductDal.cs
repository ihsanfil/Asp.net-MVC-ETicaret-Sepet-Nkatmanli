using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Entities;

namespace Northwind.DAL.Abstract
{
    public interface IProductDal
    {
        List<Product> GetAll(); //tüm ürünleri getir

        Product Get(int productId); //tek bir ürün getir

        void Add(Product product); //ürün ekleme

        void Delete(int productId); //ürün sil

        void Update(Product product); //ürün güncelle
    }
}
