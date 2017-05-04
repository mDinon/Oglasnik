﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Oglasnik.DAL;
using Oglasnik.Model;
using Oglasnik.DAL.Repository;
using Ninject;
using Oglasnik.Web.Extensions;

namespace Oglasnik.Web.Areas.Admin.Controllers
{
    [RequireHttps]
    [Authorize(Roles = "Admin")]
    public class AdsController : Controller
    {
        [Inject]
        public AdRepository AdRepository { get; set; }
        [Inject]
        public AdDetailsRepository AdDetailsRepository { get; set; }
        [Inject]
        public CategoryRepository CategoryRepository { get; set; }
        [Inject]
        public CurrencyRepository CurrencyRepository { get; set; }

        // GET: Admin/Ads
        public ActionResult Index()
        {
            return View(this.AdRepository.GetList());
        }

        // GET: Admin/Ads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ad ad = this.AdRepository.Find(id.Value);
            if (ad == null)
            {
                return HttpNotFound();
            }
            return View(ad);
        }

        // GET: Admin/Ads/Create
        public ActionResult Create()
        {
            this.FillDropDownList(new Ad());
            return View();
        }

        // POST: Admin/Ads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Category_ID,Price,IsNew,Currency_ID")] Ad ad)
        {
            ad.User_ID = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                this.AdRepository.Add(ad, true);
                return RedirectToAction("Index");
            }

            this.FillDropDownList(ad);
            return View(ad);
        }

        // GET: Admin/Ads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ad ad = this.AdRepository.Find(id.Value);
            if (ad == null)
            {
                return HttpNotFound();
            }
            this.FillDropDownList(new Ad());
            return View(ad);
        }

        // POST: Admin/Ads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Category_ID,Price,IsNew,Currency_ID,DateCreated")] Ad ad)
        {
            ad.User_ID = User.Identity.GetUserId();
            bool isOk = TryUpdateModel(ad);
            if (ModelState.IsValid && isOk)
            {
                this.AdRepository.Update(ad, true);
                return RedirectToAction("Index");
            }
            this.FillDropDownList(ad);
            return View(ad);
        }

        // GET: Admin/Ads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ad ad = this.AdRepository.Find(id.Value);
            if (ad == null)
            {
                return HttpNotFound();
            }
            return View(ad);
        }

        // POST: Admin/Ads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (this.AdDetailsRepository.Delete(id, true, true))
            {
                if (this.AdRepository.Delete(id))
                    return RedirectToAction("Index");
                else
                    return RedirectToAction("Delete", id);
            }
            else
            {
                return RedirectToAction("Delete", id);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.AdRepository.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FillDropDownList(Ad ad)
        {
            ViewBag.Category_ID = new SelectList(this.CategoryRepository.GetList(), "ID", "Name", ad.Category_ID);
            ViewBag.Currency_ID = new SelectList(this.CurrencyRepository.GetList(), "ID", "Name", ad.Currency_ID);
        }
    }
}
