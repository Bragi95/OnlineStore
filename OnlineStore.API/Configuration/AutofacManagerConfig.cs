using Autofac;
using OnlineStore.Business.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.API.Configuration
{
    public class AutofacManagerConfig : Module
    {
        protected override void Load(ContainerBuilder builder)
        {           
            builder.RegisterType<OrderManager>().As<IOrderManager>().SingleInstance();
            builder.RegisterType<StorageManager>().As<IStorageManager>().SingleInstance();
            builder.RegisterType<GoodsManager>().As<IGoodsManager>().SingleInstance();
            builder.RegisterType<UserManager>().As<IUserManager>().SingleInstance();
            builder.RegisterType<FeedBackManager>().As<IFeedBackManager>().SingleInstance();            
        }
    }
}
