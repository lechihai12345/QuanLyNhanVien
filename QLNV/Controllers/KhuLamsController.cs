using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLNV.Model;

namespace QLNV.Controllers
{
    public class KhuLamsController : Controller
    {
        private DBnhanvien db = new DBnhanvien();

        // GET: KhuLams
        public ActionResult Index()
        {
            return View(db.KhuLams.ToList());
        }

        // GET: KhuLams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhuLam khuLam = db.KhuLams.Find(id);
            if (khuLam == null)
            {
                return HttpNotFound();
            }
            return View(khuLam);
        }

        // GET: KhuLams/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KhuLams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDKhu,TenKhu")] KhuLam khuLam)
        {
            if (ModelState.IsValid)
            {
                db.KhuLams.Add(khuLam);
                db.SaveChanges();
                TempData["AltertMessage"] = "Tạo Thành Công!";
                return RedirectToAction("Index");
            }

            return View(khuLam);
        }

        // GET: KhuLams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhuLam khuLam = db.KhuLams.Find(id);
            if (khuLam == null)
            {
                return HttpNotFound();
            }
            return View(khuLam);
        }

        // POST: KhuLams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDKhu,TenKhu")] KhuLam khuLam)
        {
            if (ModelState.IsValid)
            {
                db.Entry(khuLam).State = EntityState.Modified;
                db.SaveChanges();
                TempData["AltertMessage"] = "Sửa Thành Công!";
                return RedirectToAction("Index");
            }
            return View(khuLam);
        }

        // GET: KhuLams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhuLam khuLam = db.KhuLams.Find(id);
            if (khuLam == null)
            {
                return HttpNotFound();
            }
            return View(khuLam);
        }

        // POST: KhuLams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KhuLam khuLam = db.KhuLams.Find(id);
            db.KhuLams.Remove(khuLam);
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
