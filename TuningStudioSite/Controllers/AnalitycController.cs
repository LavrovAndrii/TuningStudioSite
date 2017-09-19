using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TuningStudioSite.Models;

namespace TuningStudioSite.Controllers
{
    public class AnalitycController : Controller
    {
        // GET: Analityc
        public ActionResult PopularSuppliers()
        {
            using (var context = new ApplicationDbContext())
            {
                var allPopularSuppliers = context.Suppliers.Select(a => new ViewModel
                {
                    Id = a.Id,
                    Name = a.CompanyName,
                    Count = a.Details.SelectMany(c => c.DetailTasks).Select(b => b.Task).Count()
                });
            
            return View(allPopularSuppliers.OrderByDescending(a=>a.Count).ToList());

            }
        }
        // GET: Analityc
        public ActionResult PopularMasters()
        {
            using (var context = new ApplicationDbContext())
            {
                var allPopularMaster = context.Masters.Select(a => new ViewModel
                {
                    Id = a.Id,
                    Name = a.FullName,
                    Count = a.Tasks.Count
                });

                return View(allPopularMaster.OrderByDescending(a=>a.Count).ToList());
            }
        }
        // GET: Analityc
        public ActionResult ActiveClient()
        {
            using (var context = new ApplicationDbContext())
            {
                var allActiveClient = context.Clients.Select(a => new ViewModel
                {
                    Id = a.Id,
                    Name = a.FullName,
                    Count = a.Tasks.Count
                });

                return View(allActiveClient.OrderByDescending(a => a.Count).ToList());
            }
        }
        // GET: Analityc
        public ActionResult DoneTasks()
        {
            using (var context = new ApplicationDbContext())
            {
                var data = DateTime.Now;
                var allDoneTasks = context.Tasks.Where(a=>a.DateTime < data).Select(a => new ViewModel
                {
                    Id = a.Id,
                    Name = a.Title,
                    DateTime = a.DateTime
                });

                return View(allDoneTasks.OrderByDescending(a => a.DateTime).ToList());
            }
        }
        // GET: Analityc
        public ActionResult ActiveTasks()
        {
            using (var context = new ApplicationDbContext())
            {
                var data = DateTime.Now;
                var allActiveTasks = context.Tasks.Where(a=>a.DateTime > data).Select(a => new ViewModel
                {
                    Id = a.Id,
                    Name = a.Title,
                    DateTime = a.DateTime
                });

                return View(allActiveTasks.OrderByDescending(a => a.DateTime).ToList());
            }
        }
    }
}