using Microsoft.AspNetCore.Mvc;
using System.Linq;
using VetPet.Database.VetContext;
using VetPet.Models;

namespace VetPet.Controllers
{
    public class EstadoCivilController : Controller
    {
        private readonly VetContext _context;

        public EstadoCivilController(VetContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var estados = _context.EstadoCivil.ToList();
            return View(estados);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EstadoCivilEntity model)
        {
            if (ModelState.IsValid)
            {
                var estados = new EstadoCivilEntity
                {
                    Descripcion = model.Descripcion,
                };

                _context.EstadoCivil.Add(estados);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }


            return View(model);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var estado = _context.EstadoCivil.FirstOrDefault(a => a.Id == id);

            if (estado == null)
            {
                return NotFound();
            }

            return View(estado);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EstadoCivilEntity model)
        {
            if (ModelState.IsValid)
            {
                var estado = _context.EstadoCivil.FirstOrDefault(a => a.Id == model.Id);

                if (estado == null)
                {
                    return NotFound();
                }


                estado.Descripcion = model.Descripcion;

                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var estado = _context.EstadoCivil.FirstOrDefault(a => a.Id == id);

            if (estado == null)
            {
                return NotFound();
            }

            return View(estado);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmedDelete(int id)
        {

            var estado = _context.EstadoCivil.FirstOrDefault(a => a.Id == id);

            if (estado == null)
            {
                return NotFound();
            }


            _context.EstadoCivil.Remove(estado);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}

