using AspCore_Events.Models;
using AspCore_Events.Models.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace AspCore_Events.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public System.Web.Mvc.JsonResult GetEvents()
        {
            DatabaseContext db = new DatabaseContext();

            return new System.Web.Mvc.JsonResult { Data = db.Events.ToList(), JsonRequestBehavior = System.Web.Mvc.JsonRequestBehavior.AllowGet };
        }
        public System.Web.Mvc.JsonResult GetEventsById(int Id)
        {
            DatabaseContext db = new DatabaseContext();

            return new System.Web.Mvc.JsonResult { Data = db.Events.FirstOrDefault(s=>s.Id==Id), JsonRequestBehavior = System.Web.Mvc.JsonRequestBehavior.AllowGet };
        }

        [HttpPost]
        public System.Web.Mvc.JsonResult SaveEvent(Event e)
        {
            var status = false;
            using (DatabaseContext dc = new DatabaseContext())
            {
                if (e.Id > 0)
                {
                    //Update the event
                    var v = dc.Events.Where(a => a.Id == e.Id).FirstOrDefault();
                    if (v != null)
                    {
                        v.Title = e.Title;
                        v.StartDate = e.StartDate;
                        v.EndDate = e.EndDate;
                        v.Description = e.Description;
                        v.AllDay = e.AllDay;
                        v.Location = e.Location;
                        //v.ThemeColor = e.ThemeColor;
                    }
                }
                else
                {
                    dc.Events.Add(e);
                }

                dc.SaveChanges();
                status = true;

            }
            return new System.Web.Mvc.JsonResult { Data = new { status = status } };
        }

        [HttpPost]
        public System.Web.Mvc.JsonResult DeleteEvent(int Id)
        {
            var status = false;
            using (DatabaseContext dc = new DatabaseContext())
            {
                var v = dc.Events.Where(a => a.Id == Id).FirstOrDefault();
                if (v != null)
                {
                    dc.Events.Remove(v);
                    dc.SaveChanges();
                    status = true;
                }
            }
            return new System.Web.Mvc.JsonResult { Data = new { status = status } };
        }
    }

}
