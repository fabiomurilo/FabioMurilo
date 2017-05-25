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
    public class CategoriesController : Controller
    {
        #region [ Properties ]

        private EFContext context = new EFContext();

        #endregion

        #region [ Action ]

        #region [ Index ]

        // GET: Categories
        public ActionResult Index()
        {
            return View(context.Categories.OrderBy(category => category.name));
        }

        #endregion

        #region [ CREATE ]

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        #endregion

        #region [ Edit ]

        public ActionResult Edit(long? id)
        {
            return LoadCategory(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                var dbEntityEntry = context.Entry(category);
                dbEntityEntry.State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        #endregion

        #region [ Delete ]

        public ActionResult Delete(long id)
        {
            return LoadCategory(id);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            context.Categories.Remove(context.Categories.Find(id));
            context.SaveChanges();

            return RedirectToAction("index");
        }


        #endregion

        #region [ Details ]

        public ActionResult Details(long? id)
        {
            return LoadCategory(id);
        }

        #endregion

        #endregion

        #region [ Methods ]

        public ActionResult LoadCategory(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(context.Categories.Find(id));
        }

        #endregion
    }
}