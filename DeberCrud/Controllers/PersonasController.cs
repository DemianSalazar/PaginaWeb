using DeberCrud.Data;
using DeberCrud.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeberCrud.Controllers
{
     [Authorize]

    public class PersonasController : Controller
    {
        private readonly ApplicationDbContext applicationDb;
        private ApplicationDbContext _applicationDb;

        public PersonasController(ApplicationDbContext applicationDb)
        {
            _applicationDb = applicationDb;
        }
        [Authorize(Roles = "Jefe,Empleado")]
        public IActionResult Index()
        {
            List<Persona> personas = new List<Persona>();
            personas = _applicationDb.Persona.ToList();
            return View(personas);
        }
        [Authorize(Roles = "Jefe,Empleado")]
        public IActionResult Details(int Codigo)
        {
            if (Codigo == 0)
                return RedirectToAction("Index");
             Persona persona = _applicationDb.Persona.Where(x => x.Codigo == Codigo).FirstOrDefault();
            return View(persona);

        }
        [Authorize(Roles = "Jefe")]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Jefe")]

        [HttpPost]
        public IActionResult Create(Persona persona)
        {
            
            try
            {
                persona.Estado = 1;
                _applicationDb.Add(persona);
                _applicationDb.SaveChanges();
            }
            catch (Exception)
            {

                return View(persona); ;
            }

            return RedirectToAction ("Index");
        }
        [Authorize(Roles = "Jefe")]

        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("Index");
            }
            Persona persona = _applicationDb.Persona.Where(y => y.Codigo == id).FirstOrDefault();
            if (persona == null)
                return RedirectToAction("Index");
            return View(persona);
        }


        [HttpPost]
        public IActionResult Edit(int id, Persona persona)
        {
            if (id != persona.Codigo)
                return RedirectToAction("Index");
            try
            {
             
                _applicationDb.Update(persona);
                _applicationDb.SaveChanges();
            }
            catch (Exception)
            {

                return View(persona); ;
            }

            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Jefe")]

        public IActionResult Desactivar (int id)
        {
            if (id == 0)
                return RedirectToAction("Index");
            Persona persona = _applicationDb.Persona.Where(y => y.Codigo == id).FirstOrDefault();
            try
            {
                persona.Estado = 0;
                _applicationDb.Update(persona);
                _applicationDb.SaveChanges();
            }
            catch (Exception)
            {

                return RedirectToAction("Index");
            }

            return  RedirectToAction("Index");
        }
                [Authorize(Roles = "Jefe")]

        public IActionResult Activar(int id)
        {
            if (id == 0)
                return RedirectToAction("Index");
            Persona persona = _applicationDb.Persona.Where(y => y.Codigo == id).FirstOrDefault();
            try
            {
                persona.Estado = 1;
                _applicationDb.Update(persona);
                _applicationDb.SaveChanges();
            }
            catch (Exception)
            {

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}
