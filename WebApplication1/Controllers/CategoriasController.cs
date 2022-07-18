using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Context;
using WebApplication1.Models;


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
        public ActionResult Edit(int id)
        {
            return View(cat.Where(m => m.CategoriaId == id).First());//true or false ; 1 ,notebook
        }
        //Edit post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria ca)
        {
            cat.Remove(cat.Where(c => c.CategoriaId == ca.CategoriaId).First());//true or false; 1 , notebook
            cat.Add(ca);//colocar o novo id=1
            return RedirectToAction("Index");
        }
        //Details alone
        public ActionResult Details(long id)
        {
            return View(cat.Where(c => c.CategoriaId == id).First());
        }
        //Delete alone
        public ActionResult Delete(int id)
        {
            Categoria a = cat.Where(c => c.CategoriaId == id).First();
            return View(cat.Where(c => c.CategoriaId == id).First());
        }
        //Delete post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Categoria ca)
        {
            Categoria a = cat.Where(c => c.CategoriaId == ca.CategoriaId).First();
            cat.Remove(a);
            return RedirectToAction("Index");
        }
    }
}