using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using Northwind.Interfaces;

namespace Northwind.MvcWebUI.Infrastructor
{
    public static class WcfProxy<T>
    {
        public static T CreateChannel()
        {
            string address = String.Format("http://localhost:63105/{0}.svc", typeof(T).Name.Substring(1));

            var binding = new BasicHttpBinding();

            var channel = new ChannelFactory<T>(binding,address);

            return channel.CreateChannel();

            //Hangi interface istenirse onun servis noktasını oluşturan metodu yazdık
        }
    }
}