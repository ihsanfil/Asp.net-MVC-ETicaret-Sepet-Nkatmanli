using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using Ninject.Extensions.Interception.Infrastructure.Language;
//using Ninject.Extensions.Interception.Infrastructure.Language;
using Northwind.BLL.Concrete;
using Northwind.CrossCuttingConcerns;
using Northwind.CrossCuttingConcerns.Logging;
using Northwind.DAL.Concrete.EntityFramework;
using Northwind.Interfaces;

namespace Northwind.MvcWebUI.Infrastructor
{
    public class NinjectControllerFactory:DefaultControllerFactory
    {
        //bu kodu her projenin içerisinde sabit bir şekilde kullanabiliriz

        private IKernel _ninjectKernel;

        public NinjectControllerFactory()
        {
            _ninjectKernel = new StandardKernel();
            //AddBllBindings();
            AddServiceBinding();
        }

        private void AddBllBindings()
        {
            _ninjectKernel.Bind<IProductService>().To<ProductManager>().WithConstructorArgument("productDal",new EfProductDal()); //senden IProductService istenirse o kişiye ProductManager'i ver dedik

            _ninjectKernel.Bind<ICategoryService>().To<CategoryManager>().WithConstructorArgument("categoryDal", new EfCategoryDal()); //senden ICategoryService istenirse o kişiye ProductManager'i ver dedik

           _ninjectKernel.Bind<IAuthenticationService>().To<AuthenticationManager>().WithConstructorArgument("authenticationDal", new EfAuthenticationDal());

            _ninjectKernel.Intercept(p => (true)).With(new LoggingInterceptor());
        }
        
        private void AddServiceBinding()
        {
            _ninjectKernel.Bind<IProductService>().ToConstant(WcfProxy<IProductService>.CreateChannel());

            _ninjectKernel.Bind<ICategoryService>().ToConstant(WcfProxy<ICategoryService>.CreateChannel());

            _ninjectKernel.Bind<IAuthenticationService>().ToConstant(WcfProxy<IAuthenticationService>.CreateChannel());

           
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)_ninjectKernel.Get(controllerType);
        }
    }
}