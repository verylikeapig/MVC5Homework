﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Day1Homework.Domain;
using Day1Homework.Fliters;

namespace Day1Homework.Areas.Admin.Controllers
{
    [AuthorizePlus]
    public class AccountBooksController : Controller
    {
        private SkillTreeHomeworkEntities db = new SkillTreeHomeworkEntities();

        // GET: Admin/AccountBooks
        public ActionResult Index()
        {
            return View(db.AccountBook.ToList());
        }

        // GET: Admin/AccountBooks/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountBook accountBook = db.AccountBook.Find(id);
            if (accountBook == null)
            {
                return HttpNotFound();
            }
            return View(accountBook);
        }

        // GET: Admin/AccountBooks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/AccountBooks/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Categoryyy,Amounttt,Dateee,Remarkkk,Updatetime")] AccountBook accountBook)
        {
            if (ModelState.IsValid)
            {
                accountBook.Id = Guid.NewGuid();
                db.AccountBook.Add(accountBook);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(accountBook);
        }

        // GET: Admin/AccountBooks/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountBook accountBook = db.AccountBook.Find(id);
            if (accountBook == null)
            {
                return HttpNotFound();
            }
            return View(accountBook);
        }

        // POST: Admin/AccountBooks/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Categoryyy,Amounttt,Dateee,Remarkkk,Updatetime")] AccountBook accountBook)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accountBook).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(accountBook);
        }

        // GET: Admin/AccountBooks/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountBook accountBook = db.AccountBook.Find(id);
            if (accountBook == null)
            {
                return HttpNotFound();
            }
            return View(accountBook);
        }

        // POST: Admin/AccountBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            AccountBook accountBook = db.AccountBook.Find(id);
            db.AccountBook.Remove(accountBook);
            db.SaveChanges();
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
