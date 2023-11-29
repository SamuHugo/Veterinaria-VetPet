using Microsoft.AspNetCore.Mvc;
using System.Linq;
using VetPet.Database.VetContext;
using VetPet.Models;

namespace VetPet.Controllers
{
    public class EnfermedadesController : Controller
    {
        private readonly VetContext _context;

        public EnfermedadesController(VetContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var enfermedades = _context.Enfermedades.ToList();
            return View(enfermedades);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EnfermedadesEntity model)
        {
            if (ModelState.IsValid)
            {
                var enfermedad = new EnfermedadesEntity
                {
                    DescripcionEnferm = model.DescripcionEnferm,
                };

                _context.Enfermedades.Add(enfermedad);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }


            return View(model);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var enfermedad = _context.Enfermedades.FirstOrDefault(a => a.Id == id);

            if (enfermedad == null)
            {
                return NotFound();
            }

            return View(enfermedad);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EnfermedadesEntity model)
        {
            if (ModelState.IsValid)
            {
                var enfermedad = _context.Enfermedades.FirstOrDefault(a => a.Id == model.Id);

                if (enfermedad == null)
                {
                    return NotFound();
                }


                enfermedad.DescripcionEnferm = model.DescripcionEnferm;

                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var enfermedad = _context.Enfermedades.FirstOrDefault(a => a.Id == id);

            if (enfermedad == null)
            {
                return NotFound();
            }

            return View(enfermedad);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmedDelete(int id)
        {

            var enfermedad = _context.Enfermedades.FirstOrDefault(a => a.Id == id);

            if (enfermedad == null)
            {
                return NotFound();
            }


            _context.Enfermedades.Remove(enfermedad);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}