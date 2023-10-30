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
    public class LuongsController : Controller
    {
        private DBnhanvien db = new DBnhanvien();

        // GET: Luongs
        public ActionResult Index()
        {
            return View(db.Luongs.ToList());
        }

        // GET: Luongs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Luong luong = db.Luongs.Find(id);
            if (luong == null)
            {
                return HttpNotFound();
            }
            return View(luong);
        }

        // GET: Luongs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Luongs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDLuong,SoLuong")] Luong luong)
        {
            if (ModelState.IsValid)
            {
                db.Luongs.Add(luong);
                db.SaveChanges();
                TempData["AltertMessage"] = "Tạo Thành Công!";
                return RedirectToAction("Index");
            }

            return View(luong);
        }

        // GET: Luongs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Luong luong = db.Luongs.Find(id);
            if (luong == null)
            {
                return HttpNotFound();
            }
            return View(luong);
        }

        // POST: Luongs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDLuong,SoLuong")] Luong luong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(luong).State = EntityState.Modified;
                db.SaveChanges();
                TempData["AltertMessage"] = "Sửa Thành Công!";
                return RedirectToAction("Index");
            }
            return View(luong);
        }

        // GET: Luongs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Luong luong = db.Luongs.Find(id);
            if (luong == null)
            {
                return HttpNotFound();
            }
            return View(luong);
        }

        // POST: Luongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Luong luong = db.Luongs.Find(id);
            db.Luongs.Remove(luong);
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
