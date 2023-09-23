using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using VetPet.Database.VetContext;
using VetPet.Models;

namespace VetPet.Controllers
{
    public class LoginController : Controller
    {
        private readonly VetContext _context;

        public LoginController(VetContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        private bool ValidarUsuario(string correo, string contraseña)
        {
            // Se verifica si el usuario existe en la BD
            var admin = _context.Admins.FirstOrDefault(a => a.correo == correo);

            if (admin != null)
            {

                // Verifica si la contraseña coincide
                if (admin.contraseña == contraseña)
                {
                    return true; // Datos correctos
                }
            }

            return false; // Datos inválidos
        }
        [HttpPost]
        public IActionResult Index(string correo, string contraseña)
        {
            if (ValidarUsuario(correo, contraseña))
            {
                // Autenticación exitosa
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Error
                ViewBag.ErrorMessage = "Usuario no encontrado. Intentelo de nuevo.";
                return View();
            }
        }

    }
}
