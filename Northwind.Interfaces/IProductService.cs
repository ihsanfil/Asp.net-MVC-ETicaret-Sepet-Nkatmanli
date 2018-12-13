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
    public interface IProductService
    {
        [OperationContract] //yayına çıkmak için gerekli
        List<Product> GetAll();

        [OperationContract]
        Product Get(int productId);

        [OperationContract]
        void Add(Product product);

        [OperationContract]
        void Delete(int productId);

        [OperationContract]
        void Update(Product product);
    }
}
