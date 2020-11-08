using Autofac;
using OnlineStore.API.Serveces;
using OnlineStore.Business.Configurations;
using OnlineStore.Business.Manager;
using OnlineStore.Data.Repository;
using Shop.Data.Repository;

namespace OnlineStore.API.Configuration
{
    public class AutofacRepositoryConfig : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<OrderRepository>().As<IOrderRepository>().SingleInstance();
            builder.RegisterType<FeedBackRepository>().As<IFeedBackRepository>().SingleInstance();
            builder.RegisterType<OrderGoodsRepository>().As<IOrderGoodsRepository>().SingleInstance();
            builder.RegisterType<GoodsRepository>().As<IGoodsRepositoty>().SingleInstance();
            builder.RegisterType<CustomerRepository>().As<IUserRepository>().SingleInstance();
            builder.RegisterType<StorageRepository>().As<IStorageRepository>().SingleInstance();        
            builder.RegisterType<GoodsStorageRepository>().As<IGoodsStorageRepository>().SingleInstance();             
            builder.RegisterType<ValidationGoods>().SingleInstance();              
            builder.RegisterType<ValidationOrder>().SingleInstance();              
            builder.RegisterType<DivisionGoodsByType>().SingleInstance();              
        }
    }
}
