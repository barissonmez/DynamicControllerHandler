using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Compilation;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using Castle.Windsor;
using CastleInteg1.Controllers;

namespace CastleInteg1.Infrastructure
{
    public class CustomControllerFactory : IControllerFactory
    {
        public IController CreateController(RequestContext requestContext, string entityName)
        {
            var controllerName = entityName.ToLowerInvariant() + "controller";

            var hasControllerComponent = Container.Kernel.HasComponent(controllerName);

            var entityNameComp = entityName.ToLowerInvariant();
            var hasEntityTypeComponent = Container.Kernel.HasComponent(entityNameComp);

            if (!hasControllerComponent)
            {
                if (hasEntityTypeComponent) throw new HttpException(404, string.Empty);

                throw new HttpException(500, string.Empty);

            }

            return Container.Resolve<IController>(controllerName);
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return SessionStateBehavior.Default;
        }

        public void ReleaseController(IController controller)
        {
            Container.Release(controller);
        }

        private static IWindsorContainer Container
        {
            get { return ((IContainerAccessor)HttpContext.Current.ApplicationInstance).Container; }
        }

    }
}