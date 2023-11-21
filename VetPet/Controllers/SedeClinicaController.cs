using Microsoft.AspNetCore.Mvc;
using System.Linq;
using VetPet.Database.VetContext;
using VetPet.Models;

namespace VetPet.Controllers
{
    public class SedeClinicaController : Controller
    {
        private readonly VetContext _context;


        public SedeClinicaController (VetContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var sedeclinica = _context.SedeClinica.ToList();
            return View(sedeclinica);
        }

        public IActionResult Create() 
        {
            return View();
        }

        // CREAR SEDE CLINICA
        [HttpPost]
        public IActionResult Create(SedeClinicaEntity model) 
        {
            if (ModelState.IsValid)
            {
                var sedeclinica = new SedeClinicaEntity
                {
                    Nombre = model.Nombre,
                    Direccion = model.Direccion,    
                };

                _context.SedeClinica.Add(sedeclinica);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }


            return View(model);
        }

        // EDITAR SEDE CLINICA

        [HttpGet]
        public IActionResult Edit(int id)
        {

            var sedeclinica = _context.SedeClinica.FirstOrDefault(a => a.Id == id);

            if (sedeclinica == null)
            {
                return NotFound();
            }

            return View(sedeclinica);
        }

        [HttpPost]
        public IActionResult Edit(SedeClinicaEntity model)
        {
            if (ModelState.IsValid) {

                var sedeclinica = _context.SedeClinica.FirstOrDefault(a =>a.Id == model.Id);

                if (sedeclinica == null)
            {
                return NotFound();
            }

            sedeclinica.Nombre = model.Nombre;
            sedeclinica.Direccion = model.Direccion;
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(model);

        }

        // BORRAR SEDE CLINICA
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var sedeclinica = _context.SedeClinica.FirstOrDefault(a => a.Id == id);

            if (sedeclinica == null)
            {
                return NotFound();
            }

            return View(sedeclinica);
        }

        [HttpPost]
        public IActionResult ConfirmedDelete(int id)
        {

            var sedeclinica = _context.SedeClinica.FirstOrDefault(a => a.Id == id);

            if (sedeclinica == null)
            {
                return NotFound();
            }


            _context.SedeClinica.Remove(sedeclinica);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
