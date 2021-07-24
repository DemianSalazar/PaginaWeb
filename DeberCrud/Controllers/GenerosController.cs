using DeberCrud.Data;
using DeberCrud.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeberCrud.Controllers
{
    public class GenerosController : Controller
    {
        // GET: GenerosController
        private readonly ApplicationDbContext _context;
        public ActionResult Index()
        {
            List<Genero> ltsgenero = _context.Generos.ToList();

            return View(ltsgenero);
        }

        // GET: GenerosController/Details/5
        public ActionResult Details(int id)
        {
            Genero genero = _context.Generos.FirstOrDefault(x => x.Codigo == id);
            return View(genero);
        }

        // GET: GenerosController/Create
        public ActionResult Create(Genero genero)
        {
            if (ModelState.IsValid)
            {
                _context.Add(genero);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(genero);
        }

        // POST: GenerosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GenerosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GenerosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GenerosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GenerosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
