using Northwind.BLL.Concrete;
using Northwind.DAL.Concrete.EntityFramework;
using Northwind.Entities;
using Northwind.Interfaces;

namespace Northwind.WcfLibrary.Concrete
{
    public class AuthenticationService :IAuthenticationService
    {
        AuthenticationManager _authenticationManager = new AuthenticationManager(new EfAuthenticationDal());

        public User Authenticate(User user)
        {
            return _authenticationManager.Authenticate(user);
        }
    }
}
