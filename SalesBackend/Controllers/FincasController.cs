using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SalesBackend.Models;
using SalesCannon.Models;

namespace SalesBackend.Controllers
{
    public class FincasController : Controller
    {
        private LocalDataContext db = new LocalDataContext();

        // GET: Fincas
        public async Task<ActionResult> Index()
        {
            return View(await db.Fincas.ToListAsync());
        }

        // GET: Fincas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Finca finca = await db.Fincas.FindAsync(id);
            if (finca == null)
            {
                return HttpNotFound();
            }
            return View(finca);
        }

        // GET: Fincas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fincas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdFinca,NomFinca,TelefonoFinca,CantidadPultpaFinca,CoordenadasFinca,ImgFinca,FechaFinca")] Finca finca)
        {
            if (ModelState.IsValid)
            {
                db.Fincas.Add(finca);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(finca);
        }

        // GET: Fincas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Finca finca = await db.Fincas.FindAsync(id);
            if (finca == null)
            {
                return HttpNotFound();
            }
            return View(finca);
        }

        // POST: Fincas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdFinca,NomFinca,TelefonoFinca,CantidadPultpaFinca,CoordenadasFinca,ImgFinca,FechaFinca")] Finca finca)
        {
            if (ModelState.IsValid)
            {
                db.Entry(finca).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(finca);
        }

        // GET: Fincas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Finca finca = await db.Fincas.FindAsync(id);
            if (finca == null)
            {
                return HttpNotFound();
            }
            return View(finca);
        }

        // POST: Fincas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Finca finca = await db.Fincas.FindAsync(id);
            db.Fincas.Remove(finca);
            await db.SaveChangesAsync();
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
