using Northwind.Entities;

namespace Northwind.DAL.Abstract
{
    public interface IAuthenticationDal
    {
        User Authenticate(User user);
    }
}