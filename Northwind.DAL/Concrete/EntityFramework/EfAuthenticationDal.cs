using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.DAL.Abstract;
using Northwind.Entities;

namespace Northwind.DAL.Concrete.EntityFramework
{
    public class EfAuthenticationDal : IAuthenticationDal
    {
        public User Authenticate(User user)
        {
            //burası veritabanından alınacak
            if (user.UserName=="engin" && user.Password=="1234") 
            {
                return user;
            }
            return null;

        }
    }
}
