using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TIENDA_VIRTUAL.Datos;
using TIENDA_VIRTUAL.Models;

namespace TIENDA_VIRTUAL.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;

        }


        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Ingresar(UsuarioModelLogin model)
        {
            if (ModelState.IsValid)
            {
                Usuario usuario = _context.Usuario.FirstOrDefault(u => u.USUARIO == model.USUARIO);
                if (usuario == null)
                {
                    ModelState.AddModelError("USUARIO", "El usuario no existe");
                    return View("Index", model);
                }

                if (usuario.PASSWORD != model.PASSWORD)
                {
                    ModelState.AddModelError("PASSWORD", "Contraseña incorrecta");
                    return View("Index", model);
                }

                return RedirectToAction("Index", "Tienda", new { token = GenerarToken(usuario) });
            }

            return View("Index", model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        // GENERAR TOKEN
        public string GenerarToken(Usuario usuario)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mi_clave_secreta"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(
                issuer: "http://localhost:5000",
                audience: "http://localhost:5000",
                claims: new List<Claim> {
                    new Claim(ClaimTypes.Name, usuario.USUARIO),
                    new Claim("ROL", usuario.ROL),
                    new Claim("ID", usuario.ID.ToString())
                    
                },
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: signinCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return tokenString;
        }
    }
}
