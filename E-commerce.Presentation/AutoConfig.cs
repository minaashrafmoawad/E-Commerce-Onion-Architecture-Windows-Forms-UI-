using Application.Contract;
using Application.Services;
using Context;
using Infrastracture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac ;
namespace E_commerce.Presentation
{
  
        public static class AutofacConfig
        {
            public static IContainer Configure()
            {
                var builder = new ContainerBuilder();

                // Register DbContext
                builder.RegisterType<AppDbContext>().AsSelf().InstancePerLifetimeScope();

                // Register Repositories
                builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
                builder.RegisterType<ProductRepository>().As<IProductRepository>().InstancePerLifetimeScope();
                builder.RegisterType<OrderRepository>().As<IOrderRepository>().InstancePerLifetimeScope();
                builder.RegisterType<CategoryRepository>().As<ICategoryRepository>().InstancePerLifetimeScope();
                builder.RegisterType<CartItemRepository>().As<ICartItemRepository>().InstancePerLifetimeScope();

                // Register Services
                builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
                builder.RegisterType<ProductService>().As<IProductService>().InstancePerLifetimeScope();
                builder.RegisterType<OrderService>().As<IOrderService>().InstancePerLifetimeScope();
                builder.RegisterType<CategoryService>().As<ICategoryService>().InstancePerLifetimeScope();
                builder.RegisterType<CartService>().As<ICartService>().InstancePerLifetimeScope();
                builder.RegisterType<AdminService>().As<IAdminService>().InstancePerLifetimeScope();

                // Register Forms
                //builder.RegisterType<LoginForm>().AsSelf().InstancePerLifetimeScope();
                //builder.RegisterType<AdminPanelForm>().AsSelf().InstancePerLifetimeScope();
                //builder.RegisterType<ClientDashboardForm>().AsSelf().InstancePerLifetimeScope();

                return builder.Build();
            }
        
    }
}
