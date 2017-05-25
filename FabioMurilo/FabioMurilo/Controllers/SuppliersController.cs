using FabioMurilo.Contexts;
using FabioMurilo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FabioMurilo.Controllers
{
    public class SuppliersController : Controller
    {
        private EFContext context = new EFContext();

        #region [ Actions ]

        #region [ Index ]
        public ActionResult Index()
        {
            return View(context.Suppliers.OrderBy(supplier => supplier.Name));
        }

        #endregion

        #region [ Create ]

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Supplier supplier)
        {
            context.Suppliers.Add(supplier);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        #endregion

        #region [ Edit ]

        public ActionResult Edit(long? id)
        {
            return LoadSuppliers(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                var dbEntityEntry = context.Entry(supplier);
                dbEntityEntry.State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(supplier);
        }

        #endregion

        #region [ Details ]

        [ValidateAntiForgeryToken]
        public ActionResult Details(long? id)
        {
            if(context.Suppliers.Find(id) == null)
            {
                return HttpNotFound();
            }
            return LoadSuppliers(id);          
        }
        #endregion

        #region [ Delete ]

        public ActionResult Delete(long? id)
        {
            return LoadSuppliers(id);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            context.Suppliers.Remove(context.Suppliers.Find(id));
            context.SaveChanges();

            return RedirectToAction("index");
        }
        #endregion
        #endregion

        public ActionResult LoadSuppliers (long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(context.Suppliers.Find(id));
        }
    }
}