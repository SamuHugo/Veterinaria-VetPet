using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using VetPet.Database.VetContext;
using VetPet.Models;

namespace VetPet.Controllers
{
    public class CitaController : Controller
    {
        private readonly VetContext _context;
        public CitaController(VetContext context)
        {
            _context = context;
        }

        // GET: ProductoController
        public ActionResult Index()
        {
            var citas = _context.CitaMedica
                            .Include(p => p.SedeClinica)
                            .Include(p => p.Especialidad)
                            .Include(p => p.Medico)
                            .Include(p =>p.Usuario)
                            .ToList();
            return View(citas);
        }

        // GET: CitaController/Create
        [HttpGet]
        public ActionResult Create()
        {   
            ViewBag.SedeClinica = _context.SedeClinica.ToList();
            ViewBag.Especialidad = _context.Especialidad.ToList();
            ViewBag.Medico = _context.Medico.ToList();
            ViewBag.Usuario = _context.Usuario.ToList();    
                
            return View();
        }

        // POST: CitaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CitaMedicaEntity model)
        {
            if (ModelState.IsValid)
            {
                model.SedeClinica = _context.SedeClinica.FirstOrDefault(c => c.Id == model.SedeClinica.Id);
                model.Especialidad = _context.Especialidad.FirstOrDefault(c => c.Id == model.Especialidad.Id);
                model.Medico = _context.Medico.FirstOrDefault(c => c.Id == model.Medico.Id);

                _context.CitaMedica.Add(model);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.SedeClinica = _context.SedeClinica
               .Select(sedeclinica => new SelectListItem
               {
                   Value = sedeclinica.Id.ToString(),
                   Text = sedeclinica.Nombre
               })
               .ToList();

            ViewBag.Especialidad = _context.TipoAnimal
                .Select(especialidad => new SelectListItem
                {
                    Value = especialidad.Id.ToString(),
                    Text = especialidad.Descripcion
                })
                .ToList();


            ViewBag.Medico = _context.Medico
                .Select(medico => new SelectListItem
                {
                    Value = medico.Id.ToString(),
                    Text = medico.Nombre
                })
                .ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cita = _context.CitaMedica
                .Include(p => p.SedeClinica)
                .Include(p => p.Especialidad)
                .Include(p => p.Medico)
                .FirstOrDefault(c => c.Id == id);

            if (cita == null)
            {
                return NotFound();
            }

            ViewBag.SedeClinica = _context.SedeClinica.ToList();
            ViewBag.Especialidad = _context.Especialidad.ToList();
            ViewBag.Medico = _context.Medico.ToList();

            return View(cita);
        }

        // POST: CitaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, CitaMedicaEntity model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                
                
                    model.SedeClinica = _context.SedeClinica.FirstOrDefault(c => c.Id == model.SedeClinica.Id);
                    model.Especialidad = _context.Especialidad.FirstOrDefault(c => c.Id == model.Especialidad.Id);
                    model.Medico = _context.Medico.FirstOrDefault(c => c.Id == model.Medico.Id);

                    _context.CitaMedica.Update(model);
                    _context.SaveChanges();
                
                
                return RedirectToAction("Index");
            }

            ViewBag.SedeClinica = _context.SedeClinica.ToList();
            ViewBag.Especialidad = _context.Especialidad.ToList();
            ViewBag.Medico = _context.Medico.ToList();
            return View(model);
        }

        // GET: CitaController/Delete/5
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cita = _context.CitaMedica
                .Include(p => p.SedeClinica)
                .Include(p => p.Especialidad)
                .Include(p => p.Medico)
                .FirstOrDefault(c => c.Id == id);

            if (cita == null)
            {
                return NotFound();
            }

            return View(cita);
        }

        // POST: CitaController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var cita = _context.CitaMedica.Find(id);

            if (cita == null)
            {
                return NotFound();
            }

            _context.CitaMedica.Remove(cita);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}

