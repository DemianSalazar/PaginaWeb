using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PaginaWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaginaWeb.Controllers
{
    public class PersonasController : Controller
    {
       
        // GET: PersonasController
        public ActionResult Index()
        {
            List<Persona> ltsperson = new List<Persona>();
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("ListaPersona")))
            {
            Persona person = new Persona();
                person.Cedula = "1724446495";
                person.Nombre = "Demian";
                person.Apellido = "Salazar";
                person.Direccion = "Turubamba";
                person.Genero = "Masculino";
                for (int i = 0; i < 3; i++)
                {
                    ltsperson.Add(person);
                }
             }
            else
            {
                ltsperson = JsonConvert.DeserializeObject<List<Persona>>(HttpContext.Session.GetString("ListaPersona"));
            }



            HttpContext.Session.SetString("ListaPersona", JsonConvert.SerializeObject(ltsperson));

            return View(ltsperson);
        }

        // GET: PersonasController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PersonasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Persona persona)
        {
            try
            {
                List<Persona> pers = new List<Persona>();
                pers = JsonConvert.DeserializeObject<List<Persona>>(HttpContext.Session.GetString("ListaPersona"));
                pers.Add(persona);
                HttpContext.Session.SetString("ListaPersona", JsonConvert.SerializeObject(pers));

                // ltsperson.Add(persona);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PersonasController/Edit/5
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

        // GET: PersonasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PersonasController/Delete/5
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
