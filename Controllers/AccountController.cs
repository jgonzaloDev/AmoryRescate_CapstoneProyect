using Microsoft.AspNetCore.Mvc;
using Albergue_aspnet_DAS.Models;
using Microsoft.EntityFrameworkCore;

namespace Albergue_aspnet_DAS.Controllers
{
    public class AccountController : Controller
    {
        private readonly BdAlbergueAspnetContext _BDContext;

        public AccountController(BdAlbergueAspnetContext Context)
        {
            _BDContext = Context;
        }

        // ============================================
        // LOGIN - GET
        // ============================================
        [HttpGet]
        public IActionResult Login()
        {
            // Si ya tiene sesión, redirigir al inicio
            if (HttpContext.Session.GetString("UsuarioNombre") != null)
            {
                return RedirectToAction("Inicio", "Pestanias");
            }
            return View();
        }

        // ============================================
        // LOGIN - POST
        // ============================================
        [HttpPost]
        public IActionResult Login(string correo, string contrasena)
        {
            if (string.IsNullOrWhiteSpace(correo) || string.IsNullOrWhiteSpace(contrasena))
            {
                ViewData["Error"] = "Por favor completa todos los campos.";
                return View();
            }

            // -------------------------------------------------------
            // OPCIÓN 1: Login simple con credenciales fijas (demo)
            // Puedes reemplazar esto con tu tabla de usuarios real
            // -------------------------------------------------------
            if (correo == "admin@amoryrescate.com" && contrasena == "admin123")
            {
                HttpContext.Session.SetString("UsuarioNombre", "Administrador");
                HttpContext.Session.SetString("UsuarioCorreo", correo);
                HttpContext.Session.SetString("UsuarioRol", "Admin");

                return RedirectToAction("Inicio", "Pestanias");
            }

            // -------------------------------------------------------
            // OPCIÓN 2: Si tienes una tabla de usuarios, descomenta esto:
            // -------------------------------------------------------
            // var usuario = _BDContext.TbUsuarios
            //     .FirstOrDefault(u => u.Correo == correo && u.Contrasena == contrasena);
            //
            // if (usuario != null)
            // {
            //     HttpContext.Session.SetString("UsuarioNombre", usuario.Nombre);
            //     HttpContext.Session.SetString("UsuarioCorreo", usuario.Correo);
            //     HttpContext.Session.SetString("UsuarioRol", usuario.Rol ?? "Usuario");
            //     return RedirectToAction("Inicio", "Pestanias");
            // }

            ViewData["Error"] = "Correo o contraseña incorrectos.";
            return View();
        }

        // ============================================
        // REGISTRO - GET
        // ============================================
        [HttpGet]
        public IActionResult Registro()
        {
            if (HttpContext.Session.GetString("UsuarioNombre") != null)
            {
                return RedirectToAction("Inicio", "Pestanias");
            }
            return View();
        }

        // ============================================
        // REGISTRO - POST (demo - solo muestra éxito)
        // ============================================
        [HttpPost]
        public IActionResult Registro(string nombre, string correo, string contrasena, string confirmar)
        {
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(correo) ||
                string.IsNullOrWhiteSpace(contrasena) || string.IsNullOrWhiteSpace(confirmar))
            {
                ViewData["Error"] = "Por favor completa todos los campos.";
                return View();
            }

            if (contrasena != confirmar)
            {
                ViewData["Error"] = "Las contraseñas no coinciden.";
                return View();
            }

            if (contrasena.Length < 6)
            {
                ViewData["Error"] = "La contraseña debe tener al menos 6 caracteres.";
                return View();
            }

            // -------------------------------------------------------
            // Si tienes tabla de usuarios, guarda aquí:
            // -------------------------------------------------------
            // var existe = _BDContext.TbUsuarios.Any(u => u.Correo == correo);
            // if (existe)
            // {
            //     ViewData["Error"] = "Ya existe una cuenta con ese correo.";
            //     return View();
            // }
            //
            // var nuevoUsuario = new TbUsuario
            // {
            //     Nombre = nombre,
            //     Correo = correo,
            //     Contrasena = contrasena,
            //     Rol = "Usuario"
            // };
            // _BDContext.TbUsuarios.Add(nuevoUsuario);
            // _BDContext.SaveChanges();

            // Iniciar sesión automáticamente
            HttpContext.Session.SetString("UsuarioNombre", nombre);
            HttpContext.Session.SetString("UsuarioCorreo", correo);
            HttpContext.Session.SetString("UsuarioRol", "Usuario");

            TempData["RegistroExitoso"] = "¡Cuenta creada exitosamente!";
            return RedirectToAction("Inicio", "Pestanias");
        }

        // ============================================
        // CERRAR SESIÓN
        // ============================================
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Inicio", "Pestanias");
        }
    }
}