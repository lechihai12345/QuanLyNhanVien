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
    public class NhanViensController : Controller
    {
        private DBnhanvien db = new DBnhanvien();

        // GET: NhanViens
       
        public ActionResult Index()
        {
            var nhanViens = db.NhanViens.Include(n => n.ChucVu).Include(n => n.HopDong).Include(n => n.KhuLam).Include(n => n.Luong);
            return View(nhanViens.ToList());
        }
       
      


        // GET: NhanViens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // GET: NhanViens/Create
        public ActionResult Create()
        {
            ViewBag.IDChucVu = new SelectList(db.ChucVus, "IDChucVu", "TenChucVu");
            ViewBag.IDHopDong = new SelectList(db.HopDongs, "IDhopDong", "TenHopDong");
            ViewBag.IDKhu = new SelectList(db.KhuLams, "IDKhu", "TenKhu");
            ViewBag.IDLuong = new SelectList(db.Luongs, "IDLuong", "IDLuong");
            return View();
        }

        // POST: NhanViens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,HoTen,GioiTinh,Email,SoCMND,SoDienThoai,DiaChi,IDChucVu,IDHopDong,IDLuong,IDKhu,SoNgayNghi,BangCap")] NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                db.NhanViens.Add(nhanVien);
                db.SaveChanges();
                TempData["AltertMessage"] = "Tạo Thành Công!";
                return RedirectToAction("Index");
            }

            ViewBag.IDChucVu = new SelectList(db.ChucVus, "IDChucVu", "TenChucVu", nhanVien.IDChucVu);
            ViewBag.IDHopDong = new SelectList(db.HopDongs, "IDhopDong", "TenHopDong", nhanVien.IDHopDong);
            ViewBag.IDKhu = new SelectList(db.KhuLams, "IDKhu", "TenKhu", nhanVien.IDKhu);
            ViewBag.IDLuong = new SelectList(db.Luongs, "IDLuong", "IDLuong", nhanVien.IDLuong);
            return View(nhanVien);
        }

        // GET: NhanViens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDChucVu = new SelectList(db.ChucVus, "IDChucVu", "TenChucVu", nhanVien.IDChucVu);
            ViewBag.IDHopDong = new SelectList(db.HopDongs, "IDhopDong", "TenHopDong", nhanVien.IDHopDong);
            ViewBag.IDKhu = new SelectList(db.KhuLams, "IDKhu", "TenKhu", nhanVien.IDKhu);
            ViewBag.IDLuong = new SelectList(db.Luongs, "IDLuong", "IDLuong", nhanVien.IDLuong);
            return View(nhanVien);
        }

        // POST: NhanViens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,HoTen,GioiTinh,Email,SoCMND,SoDienThoai,DiaChi,IDChucVu,IDHopDong,IDLuong,IDKhu,SoNgayNghi,BangCap")] NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhanVien).State = EntityState.Modified;
                db.SaveChanges();
                TempData["AltertMessage"] = "Sửa Thành Công!";
                return RedirectToAction("Index");
            }
            ViewBag.IDChucVu = new SelectList(db.ChucVus, "IDChucVu", "TenChucVu", nhanVien.IDChucVu);
            ViewBag.IDHopDong = new SelectList(db.HopDongs, "IDhopDong", "TenHopDong", nhanVien.IDHopDong);
            ViewBag.IDKhu = new SelectList(db.KhuLams, "IDKhu", "TenKhu", nhanVien.IDKhu);
            ViewBag.IDLuong = new SelectList(db.Luongs, "IDLuong", "IDLuong", nhanVien.IDLuong);
            return View(nhanVien);
        }

        // GET: NhanViens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // POST: NhanViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NhanVien nhanVien = db.NhanViens.Find(id);
            db.NhanViens.Remove(nhanVien);
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
