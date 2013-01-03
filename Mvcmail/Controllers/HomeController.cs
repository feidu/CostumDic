using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;
using System.Web.UI.WebControls;
using DAL;
using Domain;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Mvcmail.Controllers
{

    public class HomeController : Controller
    {
        HQL hql = new HQL();
        //
        // GET: /index/

        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetLeve()
        {
            int id = int.Parse(Request["id"].ToString());
            IList<info> list = hql.GetLeve(id);

            var result = new { total = list.Count, rows = list };

            return Json(result);
        }

        public JsonResult GetFrist()
        {
            IList<leve> list = hql.GetFrist();
            return Json(list);
        }


        public JsonResult Add(info i)
        {
            var result = new { isSuccess = true };
            return Json(result);
        }
    }
}
