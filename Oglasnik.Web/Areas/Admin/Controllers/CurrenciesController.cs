using System;
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

namespace Oglasnik.Web.Areas.Admin.Controllers
{
    [RequireHttps]
    [Authorize(Roles = "Admin")]
    public class CurrenciesController : Controller
    {
        [Inject]
        public CurrencyRepository CurrencyRepository { get; set; }

        // GET: Admin/Currencies
        public ActionResult Index()
        {
            return View(this.CurrencyRepository.GetList());
        }

        // GET: Admin/Currencies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Currency currency = this.CurrencyRepository.Find(id.Value);
            if (currency == null)
            {
                return HttpNotFound();
            }
            return View(currency);
        }

        // GET: Admin/Currencies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Currencies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name")] Currency currency)
        {
            if (ModelState.IsValid)
            {
                this.CurrencyRepository.Add(currency, true);
                return RedirectToAction("Index");
            }

            return View(currency);
        }

        // GET: Admin/Currencies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Currency currency = this.CurrencyRepository.Find(id.Value);
            if (currency == null)
            {
                return HttpNotFound();
            }
            return View(currency);
        }

        // POST: Admin/Currencies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] Currency currency)
        {
            bool isOk = TryUpdateModel(currency);
            if (ModelState.IsValid && isOk)
            {
                this.CurrencyRepository.Update(currency, true);
                return RedirectToAction("Index");
            }
            return View(currency);
        }

        // GET: Admin/Currencies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Currency currency = this.CurrencyRepository.Find(id.Value);
            if (currency == null)
            {
                return HttpNotFound();
            }
            return View(currency);
        }

        // POST: Admin/Currencies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (this.CurrencyRepository.Delete(id))
                return RedirectToAction("Index");
            else
                return RedirectToAction("Delete", id);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.CurrencyRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
