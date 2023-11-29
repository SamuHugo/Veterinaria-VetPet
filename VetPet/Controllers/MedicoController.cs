using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using VetPet.Database.VetContext;
using VetPet.Models;

namespace VetPet.Controllers
{
    public class MedicoController : Controller
    {
        private readonly VetContext _context;


        public MedicoController(VetContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var medico = _context.Medico
                            .Include(m => m.TipoDocumento)
                            .Include(m => m.SedeClinica)
                            .Include(m => m.Genero)
                            .Include(m => m.EstadoCivil)
                            .Include(m => m.Especialidad)                       
                            .ToList();
                 
            return View(medico);
        }
        // GET: MedicoController/Create
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.TipoDocumento = _context.TipoDocumento.ToList();
            ViewBag.SedeClinica = _context.SedeClinica.ToList();
            ViewBag.Genero = _context.Genero.ToList();
            ViewBag.EstadoCivil = _context.EstadoCivil.ToList();
            ViewBag.Especialidad = _context.Especialidad.ToList();

            return View();
        }

        // POST: MedicoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MedicoEntity model, IFormFile imagen, int tipodocumentosId, int sedeclinicaId, int generoId, int estadocivilId, int especialidadId)
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



                model.TipoDocumento = _context.TipoDocumento.FirstOrDefault(t => t.Id == model.TipoDocumento.Id);
                model.SedeClinica = _context.SedeClinica.FirstOrDefault(s => s.Id == model.SedeClinica.Id);
                model.Genero = _context.Genero.FirstOrDefault(g => g.Id == model.Genero.Id);
                model.EstadoCivil = _context.EstadoCivil.FirstOrDefault(e => e.Id == model.EstadoCivil.Id);
                model.Especialidad = _context.Especialidad.FirstOrDefault(es => es.Id == model.Especialidad.Id);

                _context.Medico.Add(model);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.TipoDocumento = _context.TipoDocumento
                .Select(tipodocumento => new SelectListItem
                {
                    Value = tipodocumento.Id.ToString(),
                    Text = tipodocumento.Descripcion
                })
                .ToList();

            ViewBag.SedeClinica = _context.SedeClinica
                .Select(sedeclinica => new SelectListItem
                {
                    Value = sedeclinica.Id.ToString(),
                    Text = sedeclinica.Nombre
                })
                .ToList();


            ViewBag.Genero = _context.Genero
                .Select(genero => new SelectListItem
                {
                    Value = genero.Id.ToString(),
                    Text = genero.Descripcion
                })
                .ToList();
            ViewBag.EstadoCivil = _context.EstadoCivil
               .Select(estadocivil => new SelectListItem
               {
                   Value = estadocivil.Id.ToString(),
                   Text = estadocivil.Descripcion
               })
               .ToList();
            ViewBag.Especialidad = _context.Especialidad
               .Select(especialidad => new SelectListItem
               {
                   Value = especialidad.Id.ToString(),
                   Text = especialidad.Descripcion
               })
               .ToList();

            return View(model);
        }

       
        // GET: MedicoController/Edit/5
        [HttpGet]
        public IActionResult Edit(int id)
        {

            var medico = _context.Medico
                .Include(m => m.TipoDocumento)
                .Include(m => m.SedeClinica)
                .Include(m => m.Genero)
                .Include(m => m.EstadoCivil)
                .Include(m => m.Especialidad)
                .FirstOrDefault(p => p.Id == id);

            if (medico == null)
            {
                return NotFound();
            }

            ViewBag.TipoDocumento = _context.TipoDocumento
             .Select(tipodocumento => new SelectListItem
             {
                 Value = tipodocumento.Id.ToString(),
                 Text = tipodocumento.Descripcion
             })
             .ToList();

            ViewBag.SedeClinica = _context.SedeClinica
                .Select(sedeclinica => new SelectListItem
                {
                    Value = sedeclinica.Id.ToString(),
                    Text = sedeclinica.Nombre
                })
                .ToList();

            ViewBag.Genero = _context.Genero
                .Select(genero => new SelectListItem
                {
                    Value = genero.Id.ToString(),
                    Text = genero.Descripcion
                })
                .ToList();

            ViewBag.EstadoCivil = _context.EstadoCivil
                .Select(estadocivil => new SelectListItem
                {
                    Value = estadocivil.Id.ToString(),
                    Text = estadocivil.Descripcion
                })
                .ToList();

            ViewBag.Especialidad = _context.Especialidad
                .Select(especialidad => new SelectListItem
                {
                    Value = especialidad.Id.ToString(),
                    Text = especialidad.Descripcion
                })
                .ToList();


            return View(medico);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(MedicoEntity model)
        {
            if (ModelState.IsValid)
            {
                var medico = _context.Medico
                    .Include(m => m.TipoDocumento)
                    .Include(m => m.SedeClinica)
                    .Include(m => m.Genero)
                    .Include(m => m.EstadoCivil)
                    .Include(m => m.Especialidad)
                    .FirstOrDefault(m => m.Id == model.Id);

                if (medico == null)
                {
                    return NotFound();
                }

                medico.Nombre = model.Nombre;
                medico.Apellido = model.Apellido;
                medico.NumeroDocumento = model.NumeroDocumento;
                medico.FechaNacimiento = model.FechaNacimiento;
                medico.Telefono1 = model.Telefono1;
                medico.Telefono2 = model.Telefono2;
                medico.Direccion = model.Direccion;
                medico.DescripProfesional = model.DescripProfesional;
                medico.Correo = model.Correo;
                medico.Contrasena = model.Contrasena;

                medico.TipoDocumento = _context.TipoDocumento.FirstOrDefault(t => t.Id == model.TipoDocumento.Id);
                medico.SedeClinica = _context.SedeClinica.FirstOrDefault(s => s.Id == model.SedeClinica.Id);
                medico.Genero = _context.Genero.FirstOrDefault(g => g.Id == model.Genero.Id);
                medico.EstadoCivil = _context.EstadoCivil.FirstOrDefault(e => e.Id == model.EstadoCivil.Id);
                medico.Especialidad = _context.Especialidad.FirstOrDefault(es => es.Id == model.Especialidad.Id);

             

                if (model.Imagen != null)
                {
                    medico.Imagen = model.Imagen;
                }

                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.TipoDocumento = _context.TipoDocumento
             .Select(tipodocumento => new SelectListItem
             {
                 Value = tipodocumento.Id.ToString(),
                 Text = tipodocumento.Descripcion
             })
             .ToList();

            ViewBag.SedeClinica = _context.SedeClinica
                .Select(sedeclinica => new SelectListItem
                {
                    Value = sedeclinica.Id.ToString(),
                    Text = sedeclinica.Nombre
                })
                .ToList();

            ViewBag.Genero = _context.Genero
                .Select(genero => new SelectListItem
                {
                    Value = genero.Id.ToString(),
                    Text = genero.Descripcion
                })
                .ToList();
            ViewBag.EstadoCivil = _context.EstadoCivil
            .Select(estadocivil => new SelectListItem
            {
                Value = estadocivil.Id.ToString(),
                Text = estadocivil.Descripcion
            })
            .ToList();
            ViewBag.Especialidad = _context.Especialidad
            .Select(especialidad => new SelectListItem
            {
                Value = especialidad.Id.ToString(),
                Text = especialidad.Descripcion
            })
            .ToList();

            return View(model);
        }


        // GET: MedicoController/Delete/5
        public ActionResult Delete(int id)
        {
            var medico = _context.Medico
                             .Include(m => m.TipoDocumento)
                             .Include(m => m.SedeClinica)
                             .Include(m => m.Genero)
                             .Include(m => m.EstadoCivil)
                             .Include(m => m.Especialidad)
                            .FirstOrDefault(m => m.Id == id);

            if (medico == null)
            {
                return NotFound();
            }

            return View(medico);
        }

        // POST: ProductoController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var medico = _context.Medico.Find(id);

            if (medico == null)
            {
                return NotFound();
            }

            _context.Medico.Remove(medico);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }   
    }
}
