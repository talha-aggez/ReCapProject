﻿using System;
using System.Collections.Generic;
using Autofac;
using System.Text;
using Business.Concrete;
using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameWork;
using Core.Utilities.Interceptors;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //CarImage...
            builder
                .RegisterType<CarImageManager>()
                .As<ICarImageService>().SingleInstance();
            builder
                .RegisterType<EfCarImageDal>()
                .As<ICarImageDal>().SingleInstance();
            //Brand....
            builder
                .RegisterType<BrandManager>()
                .As<IBrandService>().SingleInstance();
            builder
                .RegisterType<EfBrandDal>().
                As<IBrandDal>().SingleInstance();
            //Car.........
            builder.
                RegisterType<CarManager>()
                .As<ICarService>().SingleInstance();
            builder
                .RegisterType<EfCarDal>()
                .As<ICarDal>().SingleInstance();
            //Color.........
            builder.RegisterType<ColorManager>()
                .As<IColorService>().SingleInstance();
            builder.RegisterType<EfColorDal>()
                .As<IColorDal>().SingleInstance();
            //Customer
            builder.RegisterType<CustomerManager>()
                .As<ICustomerService>().SingleInstance();
            builder.RegisterType<EfCustomerDal>()
                .As<ICustomerDal>();
            //Rental
            builder.RegisterType<RentalManager>()
                .As<IRentalService>().SingleInstance();
            builder.RegisterType<EfRentalDal>()
                .As<IRentalDal>().SingleInstance();
            //User
            builder.RegisterType<UserManager>()
                .As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>()
                .As<IUserDal>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
