using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Entities;

namespace Northwind.DAL.Abstract
{
    public interface ICategoryDal
    {
        List<Category> GetAll(); //tüm kategorileri getir
    }
}
