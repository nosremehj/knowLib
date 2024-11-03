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
    public class AvaliacaosController : Controller
    {
        private AddDbContext db = new AddDbContext();

        // GET: Avaliacaos
        public async Task<ActionResult> Index()
        {
            var avaliacoes = db.Avaliacoes.Include(a => a.Artigo).Include(a => a.Ebook).Include(a => a.Usuario);
            return View(await avaliacoes.ToListAsync());
        }

        // GET: Avaliacaos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Avaliacao avaliacao = await db.Avaliacoes.FindAsync(id);
            if (avaliacao == null)
            {
                return HttpNotFound();
            }
            return View(avaliacao);
        }

        // GET: Avaliacaos/Create
        public ActionResult Create()
        {
            ViewBag.ArtigoId = new SelectList(db.Artigos, "Id", "Titulo");
            ViewBag.EbookId = new SelectList(db.Ebooks, "Id", "Titulo");
            ViewBag.UsuarioId = new SelectList(db.Usuario, "Id", "Email");
            return View();
        }

        // POST: Avaliacaos/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Comentario,Nota,DataAvaliacao,UsuarioId,EbookId,ArtigoId")] Avaliacao avaliacao)
        {
            if (ModelState.IsValid)
            {
                db.Avaliacoes.Add(avaliacao);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ArtigoId = new SelectList(db.Artigos, "Id", "Titulo", avaliacao.ArtigoId);
            ViewBag.EbookId = new SelectList(db.Ebooks, "Id", "Titulo", avaliacao.EbookId);
            ViewBag.UsuarioId = new SelectList(db.Usuario, "Id", "Email", avaliacao.UsuarioId);
            return View(avaliacao);
        }

        // GET: Avaliacaos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Avaliacao avaliacao = await db.Avaliacoes.FindAsync(id);
            if (avaliacao == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArtigoId = new SelectList(db.Artigos, "Id", "Titulo", avaliacao.ArtigoId);
            ViewBag.EbookId = new SelectList(db.Ebooks, "Id", "Titulo", avaliacao.EbookId);
            ViewBag.UsuarioId = new SelectList(db.Usuario, "Id", "Email", avaliacao.UsuarioId);
            return View(avaliacao);
        }

        // POST: Avaliacaos/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Comentario,Nota,DataAvaliacao,UsuarioId,EbookId,ArtigoId")] Avaliacao avaliacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(avaliacao).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ArtigoId = new SelectList(db.Artigos, "Id", "Titulo", avaliacao.ArtigoId);
            ViewBag.EbookId = new SelectList(db.Ebooks, "Id", "Titulo", avaliacao.EbookId);
            ViewBag.UsuarioId = new SelectList(db.Usuario, "Id", "Email", avaliacao.UsuarioId);
            return View(avaliacao);
        }

        // GET: Avaliacaos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Avaliacao avaliacao = await db.Avaliacoes.FindAsync(id);
            if (avaliacao == null)
            {
                return HttpNotFound();
            }
            return View(avaliacao);
        }

        // POST: Avaliacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Avaliacao avaliacao = await db.Avaliacoes.FindAsync(id);
            db.Avaliacoes.Remove(avaliacao);
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
