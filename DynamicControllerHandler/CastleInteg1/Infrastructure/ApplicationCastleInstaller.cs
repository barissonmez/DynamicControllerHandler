using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace CastleInteg1.Infrastructure
{
    public class ApplicationCastleInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            RegisterControllers(container);
            RegisterControllerFactory(container);
            RegisterEntities(container);
            Registerservices(container);
        }

        private void Registerservices(IWindsorContainer container)
        {
            //var services = Classes
            //    .FromAssemblyNamed("Service")
                

            //container.Register(services);
        }

        private static void RegisterEntities(IWindsorContainer container)
        {
            var entities = Classes
                .FromAssemblyNamed("Entity")
                .Pick()
                .Configure(x => x.LifeStyle.Transient.Named(x.Implementation.Name.ToLowerInvariant()));

            container.Register(entities);
        }

        private static void RegisterControllers(IWindsorContainer container)
        {
            var controllers = Classes
                .FromThisAssembly()
                .BasedOn<IController>()
                .Configure(x => x.LifeStyle.Transient.Named(x.Implementation.Name.ToLowerInvariant()));

            container.Register(controllers);

        }

        private static void RegisterControllerFactory(IWindsorContainer container)
        {
            var mvcControllerFactory = Component
                .For<IControllerFactory>()
                .ImplementedBy<CustomControllerFactory>()
                .LifeStyle.Singleton;

            container.Register(mvcControllerFactory);
        }

    }
}