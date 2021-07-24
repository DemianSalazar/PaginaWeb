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
        public GenerosController (ApplicationDbContext context)
        {
            _context = context;
        }
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
        public ActionResult Create()
        {
            

            return View();
        }

        // POST: GenerosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Genero genero )
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(genero);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(genero);
            }
        }

        // GET: GenerosController/Edit/5
        public ActionResult Edit(int id)
        {
            Genero genero = _context.Generos.FirstOrDefault(x => x.Codigo == id);
            return View(genero);
            
        }

        // POST: GenerosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Genero genero)
        {
            if (id != genero.Codigo)
            {
                return RedirectToAction("Index");
            }
            try
            {
                _context.Update(genero);
                 _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(genero);
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
        public IActionResult Desactivar(int id)
        {
            if (id == 0)
                return RedirectToAction("Index");
            Genero persona = _context.Generos.Where(y => y.Codigo == id).FirstOrDefault();
            try
            {
                persona.Estado = 0;
                _context.Update(persona);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
        

        public IActionResult Activar(int id)
        {
            if (id == 0)
                return RedirectToAction("Index");
            Genero persona = _context.Generos.Where(y => y.Codigo == id).FirstOrDefault();
            try
            {
                persona.Estado = 1;
                _context.Update(persona);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}