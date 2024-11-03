using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using knowLib.Data;
using knowLib.Models;

namespace knowLib.Controllers
{
    public class EbooksController : Controller
    {
        private AddDbContext db = new AddDbContext();

        // GET: Ebooks
        public async Task<ActionResult> Index()
        {
            return View(await db.Ebooks.ToListAsync());
        }

        // GET: Ebooks/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ebook ebook = await db.Ebooks.FindAsync(id);
            if (ebook == null)
            {
                return HttpNotFound();
            }
            return View(ebook);
        }

        // GET: Ebooks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ebooks/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Titulo,Resumo,ISBN,Arquivo,DataPublicacao,NumeroPaginas,Idioma")] Ebook ebook)
        {
            if (ModelState.IsValid)
            {
                db.Ebooks.Add(ebook);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(ebook);
        }

        // GET: Ebooks/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ebook ebook = await db.Ebooks.FindAsync(id);
            if (ebook == null)
            {
                return HttpNotFound();
            }
            return View(ebook);
        }

        // POST: Ebooks/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Titulo,Resumo,ISBN,Arquivo,DataPublicacao,NumeroPaginas,Idioma")] Ebook ebook)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ebook).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(ebook);
        }

        // GET: Ebooks/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ebook ebook = await db.Ebooks.FindAsync(id);
            if (ebook == null)
            {
                return HttpNotFound();
            }
            return View(ebook);
        }

        // POST: Ebooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Ebook ebook = await db.Ebooks.FindAsync(id);
            db.Ebooks.Remove(ebook);
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
