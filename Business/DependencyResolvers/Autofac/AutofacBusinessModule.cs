using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
   public class AutofacBusinessModule : System.Reflection.Module
    {
        protected override void Load(ContainerBuider builder)
        {
            builder.RegisterType<CarManager>().As<ICarService>().SingelInstance();
            builder.RegisterType<EfCarDal>().As<ICarDal>().SingelInstance();

            builder.RegisterType<BrandManager>().As<IBrandService>().SingelInstance();
            builder.RegisterType<EfBrandDal>().As<IBrandDal>().SingelInstance();

            builder.RegisterType<ColorManager>().As<IColorService>().SingelInstance();
            builder.RegisterType<EfColorDal>().As<IColorDal>().SingelInstance();

            builder.RegisterType<UserManager>().As<IUserService>().SingelInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingelInstance();

            builder.RegisterType<CustomerManager>().As<ICustomerService>().SingelInstance();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>().SingelInstance();

            builder.RegisterType<RentalManager>().As <IRentalService>().SingelInstnce();
            builder.RegistarType<EfRentalDal>().As<IRentalDal>().SingelInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                   .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                   {
                       Selector = new AspectInterceptorSelector()
                   }).SingleInstance();
        }
    }
}
