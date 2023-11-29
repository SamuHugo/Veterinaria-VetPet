using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using VetPet.Database.VetContext;
using VetPet.Models;

namespace VetPet.Controllers
{
    public class RazaController : Controller
    {
        private readonly VetContext _context;

        public RazaController(VetContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var razas = _context.Raza.ToList();
            return View(razas);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RazaEntity model)
        {
            if (ModelState.IsValid)
            {
                var raza = new RazaEntity
                {
                    Descripcion = model.Descripcion,
                };

                _context.Raza.Add(raza);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }


            return View(model);
        }


        [HttpGet]
        // GET: MarcaController/Edit/5
        public IActionResult Edit(int id)
        {
            var raza = _context.Raza.FirstOrDefault(a => a.Id == id);

            if (raza == null)
            {
                return NotFound();
            }

            return View(raza);
        }

        // POST: MarcaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(RazaEntity model)
        {
            if (ModelState.IsValid)
            {
                var raza = _context.Raza.FirstOrDefault(a => a.Id == model.Id);

                if (raza == null)
                {
                    return NotFound();
                }


                raza.Descripcion = model.Descripcion;

                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        // GET: MarcaController/Delete/5
        public IActionResult Delete(int id)
        {
            var raza = _context.Raza.FirstOrDefault(a => a.Id == id);

            if (raza == null)
            {
                return NotFound();
            }

            return View(raza);
        }

        // POST: MarcaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmedDelete(int id)
        {

            var raza = _context.Raza.FirstOrDefault(a => a.Id == id);

            if (raza == null)
            {
                return NotFound();
            }


            _context.Raza.Remove(raza);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
