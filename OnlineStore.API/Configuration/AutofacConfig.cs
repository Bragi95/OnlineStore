using Autofac;
using OnlineStore.Data.Repository;
using Shop.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.API.Configuration
{
    public class AutofacConfig : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<OrderRepository>().As<IOrderRepository>().SingleInstance();
            builder.RegisterType<FeedBackRepository>().As<IFeedBackRepository>().SingleInstance();
            builder.RegisterType<OrderGoodsRepository>().As<IOrderGoodsRepository>().SingleInstance();
            builder.RegisterType<GoodsRepository>().As<IGoodsRepositoty>().SingleInstance();
            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>().SingleInstance();
            builder.RegisterType<StorageRepository>().As<IStorageRepository>().SingleInstance();        
         
           
            
        }
    }
}
