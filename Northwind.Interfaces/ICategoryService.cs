using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Northwind.Entities;

namespace Northwind.Interfaces
{
    [ServiceContract] //yayına çıkmak için gerekli
    public interface ICategoryService
    {
        [OperationContract] //yayına çıkmak için gerekli
        List<Category> GetAll();

        [OperationContract]
        Category Get(int categoryId);

        [OperationContract]
        void Add(Category category);

        [OperationContract]
        void Delete(int categoryId);

        [OperationContract]
        void Update(Category category);
    }
}
