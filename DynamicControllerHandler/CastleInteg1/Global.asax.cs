using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.Windsor;
using Castle.Windsor.Installer;
using CastleInteg1.Controllers;
using CastleInteg1.Infrastructure;

namespace CastleInteg1
{
    public class MvcApplication : System.Web.HttpApplication, IContainerAccessor
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            _container = new WindsorContainer();
            _container.Install(new ApplicationCastleInstaller());

            ControllerBuilder.Current.SetControllerFactory(_container.Resolve<IControllerFactory>());
        }

        private static IWindsorContainer _container;

        public IWindsorContainer Container
        {
            get
            {
                return _container;
            }
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var error = Server.GetLastError();
            var code = (error is HttpException) ? (error as HttpException).GetHttpCode() : 500;

            if (code == 404)
            {
                var routeValues = HttpContext.Current.Request.RequestContext.RouteData.Values;

                string controllerName = null;
                string actionName = null;
                string id = null;

                if (routeValues != null)
                {
                    if (routeValues.ContainsKey("action"))
                    {
                        actionName = routeValues["action"].ToString();

                    }
                    if (routeValues.ContainsKey("controller"))
                    {
                        controllerName = routeValues["controller"].ToString();
                    }
                    if (routeValues.ContainsKey("id"))
                    {
                        id = routeValues["id"].ToString();
                    }
                }

                var routeData = new RouteData();
                routeData.Values.Add("controller", "Dynamic");
                routeData.Values.Add("action", actionName);
                routeData.Values.Add("entity", controllerName);
                routeData.Values.Add("entityId", id);

                IController errorController = new DynamicController();

                errorController.Execute(new RequestContext(new HttpContextWrapper(System.Web.HttpContext.Current), routeData));
                Response.End();
            }




        }

    }

    
}
