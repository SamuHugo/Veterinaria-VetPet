using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
            var admin = _context.Admins.FirstOrDefault(a => a.correo == correo);

            if (admin != null && admin.contraseña == contraseña)
            {
                // Configurar la cookie de autenticación
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, admin.nombres),
            // Otros reclamos según sea necesario
        };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    // Puedes configurar propiedades adicionales si es necesario
                };

                HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                return true;
            }

            return false;
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
