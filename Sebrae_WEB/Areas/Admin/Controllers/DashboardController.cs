using Sebrae_WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sebrae_WEB.Areas.Admin.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        // GET: Admin/Dashboard
        public ActionResult Index(Usuario usr)
        {
            ViewBag.frase = usr.Frase;
            return View();
        }
    }
}