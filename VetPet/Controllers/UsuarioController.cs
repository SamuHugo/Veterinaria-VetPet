using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using VetPet.Database.VetContext;
using VetPet.Models;
using static System.Net.Mime.MediaTypeNames;

namespace VetPet.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly VetContext _context;

        public UsuarioController(VetContext context)
        {
            _context = context;
        }

        // GET: Usuario
        public IActionResult Index()
        {
            var usuarios = _context.Usuario
                            .Include(u => u.Genero)
                            .ToList();

            return View(usuarios);
        }

        // GET: Usuario/Create
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Genero = _context.Genero.ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UsuarioEntity model, int generoId, IFormFile imagen)
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



                model.Genero = _context.Genero.FirstOrDefault(c => c.Id == model.Genero.Id);

                _context.Usuario.Add(model);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.Genero = _context.Genero.ToList();
            return View(model);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {

            var usuario = _context.Usuario
                .Include(p => p.Genero)
                .FirstOrDefault(p => p.Id == id);

            if (usuario == null)
            {
                return NotFound();
            }

            ViewBag.Genero = _context.Genero
                .Select(genero => new SelectListItem
                {
                    Value = genero.Id.ToString(),
                    Text = genero.Descripcion
                })
                .ToList();


            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UsuarioEntity model)
        {
            if (ModelState.IsValid)
            {
                var usuario = _context.Usuario
                    .Include(p => p.Genero)
                    .FirstOrDefault(p => p.Id == model.Id);

                if (usuario == null)
                {
                    return NotFound();
                }

                usuario.Apellido = model.Apellido;
                usuario.NumeroDocumento = model.NumeroDocumento;
                usuario.Telefono = model.Telefono;
                usuario.Direccion = model.Direccion;
                usuario.FechaNacimiento = model.FechaNacimiento;
                usuario.Correo = model.Correo;
                usuario.Contrasena = model.Contrasena;

                usuario.Genero = _context.Genero.FirstOrDefault(m => m.Id == model.Genero.Id);


                if (model.Imagen != null)
                {
                    usuario.Imagen = model.Imagen;
                }

                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.Genero = _context.Genero
             .Select(genero => new SelectListItem
             {
                 Value = genero.Id.ToString(),
                 Text = genero.Descripcion
             })
             .ToList();


            return View(model);
        }
        public ActionResult Delete(int id)
        {
            var usuario = _context.Usuario
                             .Include(m => m.Genero)
                            .FirstOrDefault(m => m.Id == id);

            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: ProductoController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var usuario = _context.Usuario.Find(id);

            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuario.Remove(usuario);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
