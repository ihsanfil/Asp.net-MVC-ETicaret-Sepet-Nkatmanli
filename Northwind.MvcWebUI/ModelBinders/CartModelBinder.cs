using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Northwind.Entities;

namespace Northwind.MvcWebUI.ModelBinders
{
    public class CartModelBinder:IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var cart = (Cart) controllerContext.HttpContext.Session["cart"];
            if (cart==null)
            {
                cart = new Cart(); //sepet yoksa yenisini oluştur
                controllerContext.HttpContext.Session["cart"] = cart;
            }

            return cart;
        }
    }
}