using System;
using System.Web.Http;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using MvcApplication1.Controllers;
using MvcApplication1.Models.Daos;
using MvcApplication1.Models.Daos.Implementations;
using MvcApplication1.Services;
using MvcApplication1.Transactions;
using NHibernate;
using Unity.WebApi;

namespace MvcApplication1
{
    public static class UnityBootstrapper
    {
        public static IUnityContainer Initialise()
        {
            IUnityContainer container = BuildUnityContainer();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);

            return container;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            UnityContainer container = new UnityContainer();
            container.AddNewExtension<Interception>();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();    
            RegisterTypes(container);

            return container;
        }

        private static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterInstance<ISessionFactory>(HibernateConfig.SessionFactory);

            container.RegisterType<IUserDao, UserDao>(new ContainerControlledLifetimeManager(), new InjectionProperty("SessionFactory"));

            container.RegisterType<UserService>(new ContainerControlledLifetimeManager(), 
                                                new InjectionProperty("UserDao"),
                                                new InterceptionBehavior<PolicyInjectionBehavior>(),
                                                new Interceptor<VirtualMethodInterceptor>());
        }
    }
}