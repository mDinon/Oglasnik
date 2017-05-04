using Ninject;
using Oglasnik.DAL.Repository;
using Oglasnik.Model;
using Oglasnik.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Oglasnik.Web.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        [Inject]
        public AdRepository AdRepository { get; set; }
        public ActionResult Index()
        {
            return View(this.AdRepository.GetList());
        }

        [HttpPost]
        public ActionResult IndexAjax(AdFilterModel model)
        {
            return PartialView("_IndexTable", this.AdRepository.GetList(model));
        }

        // GET: Home/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ad ad = this.AdRepository.Find(id.Value);
            if (ad == null)
            {
                return HttpNotFound();
            }
            return View(ad);
        }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}