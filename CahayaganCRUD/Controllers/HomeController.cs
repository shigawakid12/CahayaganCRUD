using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CahayaganCRUD.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var list = new List<user>();
            using (var db = new dbsys32Entities())
            {
                list = db.user.ToList();
            }
                return View(list);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(user u)
        {
            using (var db = new dbsys32Entities())
            {
                var Newuser = new user();
                Newuser.username = u.username;
                Newuser.password = u.password;

                db.user.Add(Newuser);
                db.SaveChanges();

               TempData["msg"] = $"Added {Newuser.username} Successfully";
            }
                return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {
            var u = new user();
            using (var db = new dbsys32Entities())
            {
                u = db.user.Find(id);
            }
                return View(u);
        }
        [HttpPost]
        public ActionResult Update(user u)
        {
            using (var db = new dbsys32Entities())
            {
                var Newuser = db.user.Find(u.id);
                Newuser.username = u.username;
                Newuser.password = u.password;

                db.user.Add(Newuser);
                db.SaveChanges();

                TempData["msg"] = $"Updated {Newuser.username} Successfully";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var u = new user();
            using (var db = new dbsys32Entities())
            {
                u = db.user.Find(id);
                db.user.Remove(u);
                db.SaveChanges();

                TempData["msg"] = $"Deleted {u.username} Successfully";

            }
            return RedirectToAction("Index");
        }
    }
}