using Microsoft.AspNetCore.Mvc;
using System.Linq;
using VetPet.Database.VetContext;
using VetPet.Models;

namespace VetPet.Controllers
{
    public class TipoAnimalController : Controller
    {
        private readonly VetContext _context;

        public TipoAnimalController(VetContext context)
        {
            _context = context;
        }

        // GET: MarcaController
        public IActionResult Index()
        {
            var tipos = _context.TipoAnimal.ToList();
            return View(tipos);
        }

        // GET: MarcaController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MarcaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TipoAnimalEntity model)
        {
            if (ModelState.IsValid)
            {
                var tipo = new TipoAnimalEntity
                {
                    Descripcion = model.Descripcion,
                };

                _context.TipoAnimal.Add(tipo);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }


            return View(model);
        }


        [HttpGet]
        // GET: MarcaController/Edit/5
        public IActionResult Edit(int id)
        {
            var tipo = _context.TipoAnimal.FirstOrDefault(a => a.Id == id);

            if (tipo == null)
            {
                return NotFound();
            }

            return View(tipo);
        }

        // POST: MarcaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(MarcaEntity model)
        {
            if (ModelState.IsValid)
            {
                var tipo = _context.TipoAnimal.FirstOrDefault(a => a.Id == model.Id);

                if (tipo == null)
                {
                    return NotFound();
                }

                // Actualiza todas las propiedades del modelo Alumno
                tipo.Descripcion = model.Descripcion;

                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        // GET: MarcaController/Delete/5
        public IActionResult Delete(int id)
        {
            var tipo = _context.TipoAnimal.FirstOrDefault(a => a.Id == id);

            if (tipo == null)
            {
                return NotFound();
            }

            return View(tipo);
        }

        // POST: MarcaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmedDelete(int id)
        {

            var tipo = _context.TipoAnimal.FirstOrDefault(a => a.Id == id);

            if (tipo == null)
            {
                return NotFound();
            }


            _context.TipoAnimal.Remove(tipo);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
