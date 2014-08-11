using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using CastleInteg1.Models;
using Entity;
using Entity.Attributes;

namespace CastleInteg1.Controllers
{
    public class DynamicController : Controller
    {
        // GET: Dynamic
        public ActionResult Index()
        {
            var entityName = ControllerContext.RouteData.Values["entity"];
            //var model = new Foo() { EntityName = entity.ToString() };
            ViewBag.EntityName = entityName;

            return View();
        }

        public ActionResult Form()
        {
            var entityName = ControllerContext.RouteData.Values["entity"];
            var entityId = Convert.ToInt32(ControllerContext.RouteData.Values["entityId"]);
            //var model = new Foo() { EntityName = entity.ToString(), Id = entityId};
            ViewBag.EntityName = entityName;
            ViewBag.EntityId = entityId;

            return View();
        }


        public JsonResult Metadata(string entity)
        {
            var model = new List<MetadataModel>();

            var assembly =
                AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(x => x.GetTypes())
                    .FirstOrDefault(x => x.Name.ToLowerInvariant() == entity.ToLowerInvariant());

            if (assembly != null)
            {
                foreach (var prop in assembly.GetProperties())
                {
                    var attrs = (MetadataAttribute[])prop.GetCustomAttributes
                        (typeof(MetadataAttribute), false);
                    foreach (var attr in attrs)
                    {
                        var attrModel = new MetadataModel()
                        {
                            Title = attr.Title,
                            PropertyName = prop.Name,
                            ControlType = attr.ControlType.ToString(),
                            State = attr.State.ToString()
                        };

                        model.Add(attrModel);

                    }
                }
            }
            

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public JsonResult MetadataForEntity(string entity, int id)
        {
            var model = new List<MetadataModel>();

            

            var entityType =
                AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(x => x.GetTypes())
                    .FirstOrDefault(x => x.Name.ToLowerInvariant() == entity.ToLowerInvariant());



            if (entityType != null)
            {
                //var instance = Activator.CreateInstance(entityType);
            
                
                //if (instance == typeof (Foo))
                //{
                    
                //}
                //foreach (PropertyInfo pi in instance.GetType().GetProperties())
                //{
                //    pi.SetValue(instance, value, null);
                //}

                foreach (var prop in entityType.GetType().GetProperties())
                {
                    var attrs = (MetadataAttribute[])prop.GetCustomAttributes
                        (typeof(MetadataAttribute), false);
                    foreach (var attr in attrs)
                    {
                        var attrModel = new MetadataModel()
                        {
                            Title = attr.Title,
                            PropertyName = prop.Name,
                            ControlType = attr.ControlType.ToString(),
                            State = attr.State.ToString()
                        };

                        model.Add(attrModel);

                    }
                }
            }

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Create()
        {
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Update()
        {
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Delete()
        {
            return Json(null, JsonRequestBehavior.AllowGet);
        }
    }

    public class Repo<T> where T : class
    {

        public T GetById(int id, T entity)
        {
            var dbContext = new List<Foo>()
            {
                new Foo()
                {
                    Id = 1,
                    FirstName = "Brs",
                    Title = "Halob"
                },
                new Foo()
                {
                    Id = 2,
                    FirstName = "Trs",
                    Title = "Halot"
                },
                new Foo()
                {
                    Id = 3,
                    FirstName = "Frs",
                    Title = "Halof"
                }
            };

            return dbContext.FirstOrDefault(t => t.Id == id) as T;
        }

    }
}