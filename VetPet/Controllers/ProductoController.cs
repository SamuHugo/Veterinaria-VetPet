using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System;
using System.Linq;
using VetPet.Database.VetContext;
using VetPet.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace VetPet.Controllers
{
    public class ProductoController : Controller
    {
        private readonly VetContext _context;

        public ProductoController(VetContext context)
        {
            _context = context;
        }
        // GET: ProductoController
        public ActionResult Index()
        {
            var productos = _context.Producto
                             .Include(p => p.Marca)
                             .Include(p => p.Categoria)
                             .Include(p => p.TipoAnimal)
                             .ToList();
            return View(productos);
        }

        // GET: ProductoController/Create
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Marca = _context.Marca.ToList();
            ViewBag.Categoria = _context.Categoria.ToList();
            ViewBag.TipoAnimal = _context.TipoAnimal.ToList();
            return View();
        }

        // POST: ProductoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductoEntity model, IFormFile imagen, int categoriaId , int marcaId,int tipoAnimalId)
        {

            if (ModelState.IsValid)
            {
                if (imagen != null && imagen.Length > 0)
                {
                    // Obtiene el nombre original del archivo
                    string originalFileName = Path.GetFileName(imagen.FileName);

                    // Obtiene la ruta completa del archivo en el servidor
                    string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img");
                    string filePath = Path.Combine(uploadsFolder, originalFileName);

                    // Verifica si el archivo ya existe en el servidor
                    if (System.IO.File.Exists(filePath))
                    {
                        int counter = 1;
                        string fileNameOnly = Path.GetFileNameWithoutExtension(originalFileName);
                        string fileExtension = Path.GetExtension(originalFileName);
                        string newFileName = $"{fileNameOnly} ({counter}){fileExtension}";

                        // Mientras el nombre de archivo generado exista en el servidor, aumenta el contador
                        while (System.IO.File.Exists(Path.Combine(uploadsFolder, newFileName)))
                        {
                            counter++;
                            newFileName = $"{fileNameOnly} ({counter}){fileExtension}";
                        }

                        //Se asigna el nuevo nombre al modelo
                        model.Imagen = newFileName;
                    }
                    else
                    {
                        // Si el archivo no existe en el servidor, asigna el nombre original al modelo
                        model.Imagen = originalFileName;
                    }

                    // Se Guarda la imagen en el servidor
                    filePath = Path.Combine(uploadsFolder, model.Imagen);
                    imagen.CopyTo(new FileStream(filePath, FileMode.Create));
                }



                model.Categoria = _context.Categoria.FirstOrDefault(c => c.Id == model.Categoria.Id);
                model.Marca = _context.Marca.FirstOrDefault(m => m.Id == model.Marca.Id);
                model.TipoAnimal = _context.TipoAnimal.FirstOrDefault(t => t.Id == model.TipoAnimal.Id);

                _context.Producto.Add(model);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.Marca = _context.Marca
                .Select(marca => new SelectListItem
                {
                    Value = marca.Id.ToString(),
                    Text = marca.Descripcion
                })
                .ToList();

            ViewBag.TipoAnimal = _context.TipoAnimal
                .Select(tipoAnimal => new SelectListItem
                {
                    Value = tipoAnimal.Id.ToString(),
                    Text = tipoAnimal.Descripcion
                })
                .ToList();


            ViewBag.Categoria = _context.Categoria
                .Select(categoria => new SelectListItem
                {
                    Value = categoria.Id.ToString(),
                    Text = categoria.Descripcion
                })
                .ToList();

            return View(model);
        }


        // GET: ProductoController/Edit/5
        [HttpGet]
        public IActionResult Edit(int id)
        {

        var producto = _context.Producto
            .Include(p => p.Marca)
            .Include(p => p.Categoria)
            .Include(p => p.TipoAnimal)
            .FirstOrDefault(p => p.Id == id);

        if (producto == null)
        {
            return NotFound();
        }

            ViewBag.Marca = _context.Marca
             .Select(marca => new SelectListItem
             {
                 Value = marca.Id.ToString(),
                 Text = marca.Descripcion
             })
             .ToList();

            ViewBag.Categoria = _context.Categoria
                .Select(categoria => new SelectListItem
                {
                    Value = categoria.Id.ToString(),
                    Text = categoria.Descripcion
                })
                .ToList();

            ViewBag.TipoAnimal = _context.TipoAnimal
                .Select(tipoAnimal => new SelectListItem
                {
                    Value = tipoAnimal.Id.ToString(),
                    Text = tipoAnimal.Descripcion
                })
                .ToList();


            return View(producto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductoEntity model)
        {
            if (ModelState.IsValid)
            {
                var producto = _context.Producto
                    .Include(p => p.Marca)
                    .Include(p => p.Categoria)
                    .Include(p => p.TipoAnimal)
                    .FirstOrDefault(p => p.Id == model.Id);

                if (producto == null)
                {
                    return NotFound();
                }

                producto.Nonbre = model.Nonbre;
                producto.DescripcionProd = model.DescripcionProd;
                producto.CaracteristicasProd = model.CaracteristicasProd;
                producto.SKU = model.SKU;
                producto.Precio = model.Precio;
                producto.Stock = model.Stock;

                producto.Marca = _context.Marca.FirstOrDefault(m => m.Id == model.Marca.Id);
                producto.Categoria = _context.Categoria.FirstOrDefault(c => c.Id == model.Categoria.Id);
                producto.TipoAnimal = _context.TipoAnimal.FirstOrDefault(ta => ta.Id == model.TipoAnimal.Id);

                if (model.Imagen != null)
                {
                    producto.Imagen = model.Imagen;
                }

                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.Marca = _context.Marca
             .Select(marca => new SelectListItem
             {
                 Value = marca.Id.ToString(),
                 Text = marca.Descripcion
             })
             .ToList();

            ViewBag.Categoria = _context.Categoria
                .Select(categoria => new SelectListItem
                {
                    Value = categoria.Id.ToString(),
                    Text = categoria.Descripcion
                })
                .ToList();

            ViewBag.TipoAnimal = _context.TipoAnimal
                .Select(tipoAnimal => new SelectListItem
                {
                    Value = tipoAnimal.Id.ToString(),
                    Text = tipoAnimal.Descripcion
                })
                .ToList();

            return View(model);
        }


        // GET: ProductoController/Delete/5
        public ActionResult Delete(int id)
        {
            var producto = _context.Producto
                            .Include(p => p.Marca)
                            .Include(p => p.Categoria)
                            .Include(p => p.TipoAnimal)
                            .FirstOrDefault(p => p.Id == id);

            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: ProductoController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var producto = _context.Producto.Find(id);

            if (producto == null)
            {
                return NotFound();
            }

            _context.Producto.Remove(producto);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Tienda()
        {
            var productos = _context.Producto
                .Include(p => p.Marca)
                .Include(p => p.Categoria)
                .Include(p => p.TipoAnimal)
                .ToList();
            return View(productos);
        }
        public ActionResult Details(int id)
        {

            var producto = _context.Producto
                .Include(p => p.Marca)
                .Include(p => p.Categoria)
                .Include(p => p.TipoAnimal)
                .FirstOrDefault(p => p.Id == id);

            if (producto == null)
            {

                return RedirectToAction("Index");
            }

            return View(producto);
        }

    }
}
