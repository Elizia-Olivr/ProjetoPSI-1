﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Context;

namespace WebApplication1.Controllers
{
    public class FabricanteController : Controller
    {
        private EFContext context = new EFContext();
        // GET: Fabricante
        public ActionResult Index()
        {
            return View(context.Fabricantes.OrderBy(c=> c.Nome));
        }
    }
}