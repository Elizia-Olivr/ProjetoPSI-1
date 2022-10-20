using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Context;
using Modelo.Tabelas;


namespace WebApplication1.Controllers
{
    public class CategoriasController : Controller
    {
        private EFContext context = new EFContext();

        /* private static IList<Categoria> cat = new List<Categoria>()
         {
             new Categoria() {CategoriaId = 1, Nome ="Notebooks"},
             new Categoria() {CategoriaId = 2, Nome = "Monitores"},
             new Categoria() {CategoriaId = 3, Nome=  "Desktops"}
         };*/
        // GET: Categorias
        public ActionResult Index()
        {
            return View(context.Categorias.OrderBy(c => c.Nome));
        }
        // Create get
        public ActionResult Create()
        {
            return View();
        }
        // Create post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria ca)
        {
            // IEnumerable<Categoria> a = cat.Where(c => c.CategoriaId >0);

            context.Categorias.Add(ca);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        //Edit alone
        public ActionResult Edit(long ? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = context.Categorias.Find(id);
            //Fabricante fabricante = fab.Where(m => m.FabricanteId == id).First();
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }
        //Edit post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                context.Entry(categoria).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoria);
        }
        //Details alone
        public ActionResult Details(long ? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = context.Categorias.Where(c => c.CategoriaId == id).Include("Produtos.Fabricante").First();
            //Fabricante fabricante = fab.Where(m => m.FabricanteId == id).First();
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }
        //Delete alone
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = context.Categorias.Find(id);
            //Fabricante fabricante = fab.Where(m => m.FabricanteId == id).First();
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }
        //Delete post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long ? id)
        {
            Categoria categoria = context.Categorias.Find(id);
            context.Categorias.Remove(categoria);
            context.SaveChanges();
            TempData["Message"] = "categoria " + categoria.Nome.ToUpper() + " foi removido";
            //Fabricante fabricante = fab.Where(m => m.FabricanteId == id).First();
            //fab.Remove(fabricante);
            return RedirectToAction("Index");
        }
    }
}
