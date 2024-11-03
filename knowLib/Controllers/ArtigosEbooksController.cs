using knowLib.Data;
using knowLib.Models;
using System;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace knowLib.Controllers
{
    public class ArtigosEbooksController : Controller
    {
        private AddDbContext db = new AddDbContext();
       
        public async Task<ActionResult> Index()
        {
            var viewModel = new ArtigosEbooksViewModel
            {
                Artigos = await db.Artigos.ToListAsync(),
                Ebooks = await db.Ebooks.ToListAsync()
            };
            return View(viewModel);
        }

        public async Task<ActionResult> DetailsArtigos(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artigo artigo = await db.Artigos.FindAsync(id);
            if (artigo == null)
            {
                return HttpNotFound();
            }
            return View(artigo);
        }

        public async Task<ActionResult> DetailsEbooks(int? id)
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
    }
}
