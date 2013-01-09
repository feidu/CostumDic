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
        //根据cid获取类别下的内容
        public JsonResult GetInfo(int cid)
        {
            IList list = hql.GetInfo(cid);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        //页面载入树
        public JsonResult GetFrist()
        {
            IList list = hql.GetLeve();
            List<object> tree = new List<object>();
            foreach (leve item in list)
            {
                IList infos = hql.GetInfo(item.cid);
                List<object> treechild = new List<object>();
                foreach (info item1 in infos)
                {
                    var result1 = new { id = item1.id, text = item1.name };
                    treechild.Add(result1);
                }
                var result = new { id = item.cid, text = item.pname, children = treechild };

                tree.Add(result);

            }

            return Json(tree);
        }
        //获取所有类别
        public JsonResult GetLeve()
        {
            IList list = hql.GetLeve();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        // 根据cid获取leve
        public JsonResult GetLeveBy()
        {
            int id = int.Parse(Request["id"].ToString());
            IList list = hql.GetLeveBy(id);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
       // 根据id获取详细信息
        public JsonResult GetDetail()
        {
            int id = int.Parse(Request["id"].ToString());
            IList list = hql.GetDetail(id);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        //添加新的内容
        public void InfoAdd(info Info)
        {
            hql.InfoAdd(Info);
        }
        //获取leve在下拉列表中显示
        public JsonResult LeveCombox()
        {
            int cid=0;
            int i = 0;
            if (Request["cid"]!=null)
            { 
                cid =int.Parse(Request["cid"].ToString());
            }
            IList<object> Combox = new List<object>();
            IList list = hql.GetLeve();
            foreach (leve Leve in list)
            {
                if (cid!=0 && Leve.cid==cid)
                {
                    var result = new { id = Leve.cid, text = Leve.pname, selected = "true" };
                    Combox.Add(result);
                    i++;
                }
                else
                {
                    if (i == 0)
                    {
                        var result = new { id = Leve.cid, text = Leve.pname, selected = "true" };
                        Combox.Add(result);
                        i++;
                    }
                    else { 
                            var result = new { id = Leve.cid, text = Leve.pname };
                            Combox.Add(result); 
                         }

                }
            }

            return Json(Combox);
        }
        //修改内容
        public void InfoUpd(info Info)
        {
            hql.InfoUpd(Info);

        }
        //删除内容
        public void InfoDel(info Info)
        {
            hql.InfoDel(Info);
        }
        //添加类型
        public void LeveAdd(leve Leve)
        {
            hql.LeveAdd(Leve);
        }
        //修改类型
        public void LeveUpd(leve Leve)
        {
            hql.LeveUpd(Leve);
        }
        //删除类型
        public void LeveDel(leve Leve)
        {
            hql.LeveDel(Leve);
        }
    }
}
