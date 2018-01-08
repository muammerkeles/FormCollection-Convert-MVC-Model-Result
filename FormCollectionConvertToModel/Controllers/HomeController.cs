using FormCollectionConvertToModel.Models;
using FormCollectionConvertToModel.MyConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormCollectionConvertToModel.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult Results()
        {

            return View();
        }

        [HttpPost]
        public JsonResult SaveForm(FormCollection fc)
        {

            return Json(new { success = true });
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ShowFormData(FormCollection fc)
        {
            SampleViewModel model = new SampleViewModel();
            model = new FormCollectionToModel<SampleViewModel>(fc).GetModel;
            return View(model);
        }
    }
}