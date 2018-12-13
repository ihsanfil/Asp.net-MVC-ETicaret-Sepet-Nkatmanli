using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.DAL.Abstract;
using Northwind.Entities;

namespace Northwind.DAL.Concrete.EntityFramework
{
    public class EfCategoryDal:ICategoryDal
    {
        NorthwindContext _context = new NorthwindContext();
        public List<Category> GetAll()
        {
            return _context.Categories.ToList();
        }
    }
}
