using Microsoft.AspNetCore.Mvc;
using TIENDA_VIRTUAL.Datos;
using TIENDA_VIRTUAL.Models;


namespace TIENDA_VIRTUAL.Controllers
{
    public class LoginController : Controller
    {
        public readonly ApplicationDbContext _context;

        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Ingresar(UsuarioModelLogin model)
        {
            if (ModelState.IsValid)
            {
                // obtener si existe usuario
                var usuario = _context.Usuario.FirstOrDefault(u => u.USUARIO == model.USUARIO);
                if (usuario == null)
                {
                    ModelState.AddModelError("USUARIO", "El usuario no existe");
                    return View("Index", model);
                }

                // validar contraseña
                if (usuario.PASSWORD != model.PASSWORD)
                {
                    ModelState.AddModelError("PASSWORD", "Contraseña incorrecta");
                    return View("Index", model);
                }
                
                return RedirectToAction("Index", "Tienda");
            }

            // Si hay errores de validación, se vuelve a mostrar el formulario con errores
            return View("Index", model);
        }
    }
}
