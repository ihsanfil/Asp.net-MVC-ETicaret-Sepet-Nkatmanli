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
   public class CategoryService : ICategoryService
    {
        CategoryManager _categoryManager = new CategoryManager(new EfCategoryDal());

        public List<Category> GetAll()
        {
            return _categoryManager.GetAll();
        }

        public Category Get(int categoryId)
        {
            throw new NotImplementedException();
        }

        public void Add(Category category)
        {
            throw new NotImplementedException();
        }

        public void Delete(int categoryId)
        {
            throw new NotImplementedException();
        }

        public void Update(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
