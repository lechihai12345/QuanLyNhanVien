using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using QLNV.Model;

namespace QLNV.Controllers
{
    public class ADMsController : Controller
    {
        private DBnhanvien db = new DBnhanvien();

        // GET: ADMs
        public ActionResult Index()
        {
            return View(db.ADMs.ToList());
        }
        //For UserName
        public JsonResult IsUserNameExits(String UserName)
        {
            return Json(!db.ADMs.Any(x => x.TenDN == UserName), JsonRequestBehavior.AllowGet);
        }
    


        // GET: ADMs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ADM aDM = db.ADMs.Find(id);
            if (aDM == null)
            {
                return HttpNotFound();
            }
            return View(aDM);
        }

        // GET: ADMs/Create
        public ActionResult Create()
        {
            return View();
        }
    
        // POST: ADMs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDadm,TenDN,Pass")] ADM aDM)
        {
            if (ModelState.IsValid)
            {
                db.ADMs.Add(aDM);
                db.SaveChanges();
                TempData["AltertMessage"] = "Tạo Thành Công!";
                return RedirectToAction("Index");
            }
                return View(aDM);
        }
        //Get: ADM/Login
        public ActionResult Login()
        {
            return View();
        }
        //POST:ADM/Login
        [HttpPost]
        public ActionResult Login(ADM usr)
        {
            var u = db.ADMs.SingleOrDefault(m => m.TenDN == usr.TenDN && m.Pass == usr.Pass);
            if (u != null)
            {

                Session["LoginSuccess"] = usr;
                return RedirectToAction("Index", "BangNV");
            }
            else
            {
                TempData["error"] = "Tài Khoản Admin Không Đúng!";
                return View();
            }    

            
        }
        // GET: ADMs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ADM aDM = db.ADMs.Find(id);
            if (aDM == null)
            {
                return HttpNotFound();
            }
            return View(aDM);
        }
        //Get: ADM/Logout
        public ActionResult Logout()
        {
            Session["LoginSuccess"] = null;
            return RedirectToAction("Index", "BangNV");
        }




        // POST: ADMs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDadm,TenDN,Pass")] ADM aDM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aDM).State = EntityState.Modified;
                db.SaveChanges();
                TempData["AltertMessage"] = "Sửa Thành Công!";
                return RedirectToAction("Index");
            }
            return View(aDM);
        }

        // GET: ADMs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ADM aDM = db.ADMs.Find(id);
            if (aDM == null)
            {
                return HttpNotFound();
            }
            return View(aDM);
        }

        // POST: ADMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ADM aDM = db.ADMs.Find(id);
            db.ADMs.Remove(aDM);
            db.SaveChanges();
            TempData["AltertMessage"] = "Xóa Thành Công!";
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
