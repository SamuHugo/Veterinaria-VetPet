using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using VetPet.Database.VetContext;
using VetPet.Models;

namespace VetPet.Controllers
{
    public class MarcaController : Controller
    {
        private readonly VetContext _context;

        public MarcaController(VetContext context)
        {
            _context = context;
        }

        // GET: MarcaController
        public IActionResult Index()
        {
            var marcas = _context.Marca.ToList();
            return View(marcas);
        }

        // GET: MarcaController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MarcaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MarcaEntity model)
        {
            if (ModelState.IsValid)
            {
                var marca = new MarcaEntity
                {
                    Descripcion = model.Descripcion,
                };

                _context.Marca.Add(marca);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }


            return View(model);
        }
    

        [HttpGet]
        // GET: MarcaController/Edit/5
        public IActionResult Edit(int id)
        {
            var marca = _context.Marca.FirstOrDefault(a => a.Id == id);

            if (marca == null)
            {
                return NotFound();
            }

            return View(marca);
        }

        // POST: MarcaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(MarcaEntity model)
        {
            if (ModelState.IsValid)
            {
                var marca = _context.Marca.FirstOrDefault(a => a.Id == model.Id);

                if (marca == null)
                {
                    return NotFound();
                }

                // Actualiza todas las propiedades del modelo Alumno
                marca.Descripcion = model.Descripcion;

                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        // GET: MarcaController/Delete/5
        public IActionResult Delete(int id)
        {
            var marca = _context.Marca.FirstOrDefault(a => a.Id == id);

            if (marca == null)
            {
                return NotFound();
            }

            return View(marca);
        }

        // POST: MarcaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmedDelete(int id)
        {

            var marca = _context.Marca.FirstOrDefault(a => a.Id == id);

            if (marca == null)
            {
                return NotFound();
            }


            _context.Marca.Remove(marca);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
