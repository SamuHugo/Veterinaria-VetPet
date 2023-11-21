using Microsoft.AspNetCore.Mvc;
using System.Linq;
using VetPet.Database.VetContext;
using VetPet.Models;

namespace VetPet.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly VetContext _context;

        public CategoriaController (VetContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var categorias = _context.Categoria.ToList();
            return View(categorias);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoriaEntity model)
        {
            if (ModelState.IsValid)
            {
                var categoria = new CategoriaEntity
                {
                    Descripcion=model.Descripcion,
                };

                _context.Categoria.Add(categoria);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }


            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

            var categoria = _context.Categoria.FirstOrDefault(a => a.Id == id);

            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }
        [HttpPost]
        public IActionResult Edit(CategoriaEntity model)
        {
            if (ModelState.IsValid)
            {
                var categoria = _context.Categoria.FirstOrDefault(a => a.Id == model.Id);

                if (categoria == null)
                {
                    return NotFound();
                }

                    categoria.Descripcion = model.Descripcion;

                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
        }

        // Borrar Categoria
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var categoria = _context.Categoria.FirstOrDefault(a => a.Id == id);

            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        [HttpPost]
        public IActionResult ConfirmedDelete(int id)
        {

            var categoria = _context.Categoria.FirstOrDefault(a => a.Id == id);

            if (categoria == null)
            {
                return NotFound();
            }


            _context.Categoria.Remove(categoria);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
