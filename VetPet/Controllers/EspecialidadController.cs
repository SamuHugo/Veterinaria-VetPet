﻿using Microsoft.AspNetCore.Mvc;
using System.Linq;
using VetPet.Database.VetContext;
using VetPet.Models;

namespace VetPet.Controllers
{
    public class EspecialidadController : Controller
    {
        private readonly VetContext _context;

        public EspecialidadController(VetContext context)
        {
            _context = context;
        }

 
        public IActionResult Index()
        {
            var especialidades = _context.Especialidad.ToList();
            return View(especialidades);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EspecialidadEntity model)
        {
            if (ModelState.IsValid)
            {
                var especialidad = new EspecialidadEntity
                {
                    Descripcion = model.Descripcion,
                };

                _context.Especialidad.Add(especialidad);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }


            return View(model);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var especialidad = _context.Especialidad.FirstOrDefault(a => a.Id == id);

            if (especialidad == null)
            {
                return NotFound();
            }

            return View(especialidad);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EspecialidadEntity model)
        {
            if (ModelState.IsValid)
            {
                var especialidad = _context.Especialidad.FirstOrDefault(a => a.Id == model.Id);

                if (especialidad == null)
                {
                    return NotFound();
                }


                especialidad.Descripcion = model.Descripcion;

                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var especialidad = _context.Especialidad.FirstOrDefault(a => a.Id == id);

            if (especialidad == null)
            {
                return NotFound();
            }

            return View(especialidad);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmedDelete(int id)
        {

            var especialidad = _context.Especialidad.FirstOrDefault(a => a.Id == id);

            if (especialidad == null)
            {
                return NotFound();
            }


            _context.Especialidad.Remove(especialidad);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}