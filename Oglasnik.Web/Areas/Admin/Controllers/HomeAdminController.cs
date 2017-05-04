using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Oglasnik.Web.Areas.Admin.Controllers
{
    [RequireHttps]
    [Authorize(Roles = "Admin")]
    [RouteArea("Admin", AreaPrefix = "Admin")]
    [RoutePrefix("")]
    public class HomeAdminController : Controller
    {
        // GET: Admin/HomeAdmin
        [Route("")]
        public ActionResult Index()
        {
            return View();
        }
    }
}