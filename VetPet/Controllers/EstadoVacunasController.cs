using Microsoft.AspNetCore.Mvc;
using System.Linq;
using VetPet.Database.VetContext;
using VetPet.Models;

namespace VetPet.Controllers
{
    public class EstadoVacunasController : Controller
    {
        private readonly VetContext _context;

        public EstadoVacunasController(VetContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var estados = _context.EstadoVacunas.ToList();
            return View(estados);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EstadoVacunasEntity model)
        {
            if (ModelState.IsValid)
            {
                var estados = new EstadoVacunasEntity
                {
                    DescripcionVacunas = model.DescripcionVacunas,
                };

                _context.EstadoVacunas.Add(estados);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }


            return View(model);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var estado = _context.EstadoVacunas.FirstOrDefault(a => a.Id == id);

            if (estado == null)
            {
                return NotFound();
            }

            return View(estado);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EstadoVacunasEntity model)
        {
            if (ModelState.IsValid)
            {
                var estado = _context.EstadoVacunas.FirstOrDefault(a => a.Id == model.Id);

                if (estado == null)
                {
                    return NotFound();
                }


                estado.DescripcionVacunas = model.DescripcionVacunas;

                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var estado = _context.EstadoVacunas.FirstOrDefault(a => a.Id == id);

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

            var estado = _context.EstadoVacunas.FirstOrDefault(a => a.Id == id);

            if (estado == null)
            {
                return NotFound();
            }


            _context.EstadoVacunas.Remove(estado);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
