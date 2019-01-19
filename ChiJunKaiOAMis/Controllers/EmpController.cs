using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChiJunKaiOAMis.Models;

namespace ChiJunKaiOAMis.Controllers
{
    public class EmpController : Controller
    {
        OADBEntities db = new OADBEntities();
        // GET: Emp
        public ActionResult Index()
        {
            ViewBag.name = db.Dep.ToList();
            return View();
        }
        public ActionResult Search(int limit=10, int page=1) {
            IQueryable<View_Employees> res = db.View_Employees.Where(p=>true);
            String realName = Request.Params["realName"];
            String name = Request.Params["name"];
            String sex = Request.Params["sex"];
            if (!String.IsNullOrWhiteSpace(realName))
                res = res.Where(p => p.RealName.Contains(realName));
            if (!String.IsNullOrWhiteSpace(name))
                res = res.Where(p => p.Name.Contains(name));
            if (!String.IsNullOrWhiteSpace(sex))
                res = res.Where(p => p.Sex.Contains(sex));
            var list = res.OrderBy(p=>p.Name).Skip((page-1)*limit).Take(limit).ToList();
            var count = res.Count();
            return Content(Pager.PagedData(list,count));
        }
        public ActionResult Del(Guid id)
        {
            var a = db.Employees.SingleOrDefault(p => p.UserID == id);
            if (a == null)
            {
                return Json(new { success = false, msg = "请选择要删除的员工" });
            }
            else {
                db.Employees.Remove(a);
                db.SaveChanges();
                return Json(new { success = true, msg = "删除成功" });
            }
        }
    }
}