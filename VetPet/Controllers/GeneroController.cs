using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using VetPet.Database.VetContext;
using VetPet.Models;

namespace VetPet.Controllers
{
    public class GeneroController : Controller
    {
        private readonly VetContext _context;

        public GeneroController(VetContext context)
        {
            _context = context;
        }

        // GET: MarcaController
        public IActionResult Index()
        {
            var generos = _context.Genero.ToList();
            return View(generos);
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
                var genero = new GeneroEntity
                {
                    Descripcion = model.Descripcion,
                };

                _context.Genero.Add(genero);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }


            return View(model);
        }


        [HttpGet]
        // GET: MarcaController/Edit/5
        public IActionResult Edit(int id)
        {
            var genero = _context.Genero.FirstOrDefault(a => a.Id == id);

            if (genero == null)
            {
                return NotFound();
            }

            return View(genero);
        }

        // POST: MarcaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(MarcaEntity model)
        {
            if (ModelState.IsValid)
            {
                var genero = _context.Genero.FirstOrDefault(a => a.Id == model.Id);

                if (genero == null)
                {
                    return NotFound();
                }


                genero.Descripcion = model.Descripcion;

                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        // GET: MarcaController/Delete/5
        public IActionResult Delete(int id)
        {
            var genero = _context.Genero.FirstOrDefault(a => a.Id == id);

            if (genero == null)
            {
                return NotFound();
            }

            return View(genero);
        }

        // POST: MarcaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmedDelete(int id)
        {

            var genero = _context.Genero.FirstOrDefault(a => a.Id == id);

            if (genero == null)
            {
                return NotFound();
            }


            _context.Genero.Remove(genero);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
