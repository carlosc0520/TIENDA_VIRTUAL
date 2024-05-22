using Microsoft.AspNetCore.Mvc;
using TIENDA_VIRTUAL.Datos;
using TIENDA_VIRTUAL.Models;

namespace TIENDA_VIRTUAL.Controllers
{
    public class TiendaController : Controller
    {
        public readonly ApplicationDbContext _context;

        public TiendaController(ApplicationDbContext context)
        {
            _context = context;
        }


        #region PRODUCTOS
        public async Task<ActionResult> Index(int n = 5)
        {
            List<ProductoModel> productos = await _context.TopProductos(n);
            List<CategoriaModel> categorias = await _context.AllCategorias();
            ProductoListViewModel viewModel = new ProductoListViewModel
            {
                ListProductos = productos,
                NuevoProducto = new ProductoModel(),
                ListCategoria = new List<CategoriaModel>()
            };

            return View("Inicio", viewModel);
        }

        [HttpGet("Tienda/Productos")]
        public async Task<ActionResult> Productos()
        {
            List<ProductoModel> productos = await _context.AllProductos();
            List<CategoriaModel> categorias = await _context.AllCategorias();
            ProductoListViewModel viewModel = new ProductoListViewModel
            {
                ListProductos = productos,
                NuevoProducto = new ProductoModel(),
                ListCategoria = categorias
            };

            return View(viewModel);
        }

        [HttpGet("Tienda/Productos/{SEARCH}")]
        public async Task<ActionResult> Productos(string search)
        {
            List<ProductoModel> productos = await _context.AllProductos(search);
            List<CategoriaModel> categorias = await _context.AllCategorias();
            ProductoListViewModel viewModel = new ProductoListViewModel
            {
                ListProductos = productos,
                ListCategoria = categorias,
                NuevoProducto = new ProductoModel(),
            };

            return View(viewModel);
        }

        // AGREGAR PRODUCTOS
        [HttpPost("Tienda/Producto/Agregar")]
        public async Task<ActionResult> AgregarProducto(ProductoListViewModel model)
        {
            var nuevoProducto = model.NuevoProducto;

            if (TryValidateModel(nuevoProducto))
            {
                ProductoModel producto = model.NuevoProducto;
                _context.Producto.Add(new Producto
                {
                    NOMBRE = producto.NOMBRE,
                    DETALLE = producto.DETALLE,
                    PRECIO = producto.PRECIO,
                    IMAGEN = producto.IMAGEN,
                    STOCK = producto.STOCK,
                    Categoria = _context.Categoria.FirstOrDefault(c => c.CategoriaId == producto.CategoriaId),
                    CategoriaId = producto.CategoriaId,
                });

                _context.SaveChanges();
                return RedirectToAction("Productos");
            }

            model.ListProductos = await _context.AllProductos();

            List<CategoriaModel> categorias = await _context.AllCategorias();
            model.ListCategoria = categorias;
            return View("Productos", model);
        }

        // EDITAR PRODUCTOS
        [HttpPost("Tienda/Producto/Editar")]
        public async Task<ActionResult> EditarProducto(ProductoListViewModel model)
        {
            var producto = model.NuevoProducto;
            if (TryValidateModel(producto) && producto.ID > 0)
            {
                Producto productoEditar = _context.Producto.FirstOrDefault(p => p.ID == producto.ID);
                productoEditar.NOMBRE = producto.NOMBRE;
                productoEditar.DETALLE = producto.DETALLE;
                productoEditar.PRECIO = producto.PRECIO;
                productoEditar.IMAGEN = producto.IMAGEN;
                productoEditar.STOCK = producto.STOCK;
                productoEditar.Categoria = _context.Categoria.FirstOrDefault(c => c.CategoriaId == producto.CategoriaId);
                productoEditar.CategoriaId = producto.CategoriaId;
                _context.SaveChanges();
                return RedirectToAction("Productos");
            }

            model.ListProductos = await _context.AllProductos();
            List<CategoriaModel> categorias = await _context.AllCategorias();
            model.ListCategoria = categorias;

            return View("Productos", model);
        }

        [HttpGet("Tienda/Producto/Eliminar/{id}")]
        public ActionResult EliminarProducto(int id)
        {
            Producto producto = _context.Producto.FirstOrDefault(p => p.ID == id);
            _context.Producto.Remove(producto);
            _context.SaveChanges();
            return RedirectToAction("Productos");
        }

        #endregion

        #region USUARIOS

        [HttpGet("Tienda/Usuarios")]
        public async Task<ActionResult> Usuarios()
        {
            List<UsuarioModel> usuarios = await _context.AllUsuarios();
            UsuarioListViewModel viewModel = new UsuarioListViewModel
            {
                ListUsuarios = usuarios,
                Usuario = new UsuarioModel(),
            };

            return View("Usuarios", viewModel);
        }

        [HttpGet("Tienda/Usuarios/{SEARCH}")]
        public async Task<ActionResult> Usuarios(string search)
        {
           List<UsuarioModel> usuarios = await _context.AllUsuarios(search);
           UsuarioListViewModel viewModel = new UsuarioListViewModel
           {
               ListUsuarios = usuarios,
               Usuario = new UsuarioModel(),
           };

           return View(viewModel);
        }

        [HttpPost("Tienda/Usuarios/Agregar")]
        public async Task<ActionResult> AgregarUsuario(UsuarioListViewModel model)
        {
            var usuario = model.Usuario;
            if (TryValidateModel(usuario))
            {
                UsuarioModel u = model.Usuario;
                _context.Usuario.Add(new Usuario
                {
                    USUARIO = u.USUARIO,
                    PASSWORD = u.PASSWORD,
                    ROL = u.ROL,
                    NOMBRES = u.NOMBRES,
                    APELLIDOP = u.APELLIDOP,
                    APELLIDOM = u.APELLIDOM,
                });

                _context.SaveChanges();
                return RedirectToAction("Usuarios");
            }


            model.ListUsuarios = await _context.AllUsuarios();
            return View("Usuarios", model);

        }

        [HttpPost("Tienda/Usuarios/Editar")]
        public async Task<ActionResult> EditarUsuario(UsuarioListViewModel model)
        {
            var usuario = model.Usuario;
            if (TryValidateModel(usuario) && usuario.ID > 0)
            {
                Usuario usuarioEditar = _context.Usuario.FirstOrDefault(p => p.ID == usuario.ID);
                usuarioEditar.USUARIO = usuario.USUARIO;
                usuarioEditar.PASSWORD = usuario.PASSWORD;
                usuarioEditar.ROL = usuario.ROL;
                usuarioEditar.NOMBRES = usuario.NOMBRES;
                usuarioEditar.APELLIDOP = usuario.APELLIDOP;
                usuarioEditar.APELLIDOM = usuario.APELLIDOM;

                _context.SaveChanges();
                return RedirectToAction("Usuarios");
            }

            model.ListUsuarios = await _context.AllUsuarios();
            return View("Usuarios", model);
        }

        [HttpGet("Tienda/Usuarios/Eliminar/{id}")]
        public ActionResult EliminarUsuario(int id)
        {
           Usuario usuario = _context.Usuario.FirstOrDefault(p => p.ID == id);
           _context.Usuario.Remove(usuario);
           _context.SaveChanges();
           return RedirectToAction("Usuarios");
        }

        #endregion

        #region MIS DATOS

        [HttpGet("Tienda/MisDatos/{id}")]
        public async Task<ActionResult> Datos(int id = 5)
        {
            UsuarioModel u = await _context.GetUsuario(id);
            UsuarioListViewModel viewModel = new UsuarioListViewModel
            {
                ListUsuarios = new List<UsuarioModel>(),
                Usuario = u,
            };

            return View("Datos", viewModel);
        }
        
        [HttpPost("Tienda/MisDatos/Editar")]
        public async Task<ActionResult> EditarUsuarioDatos(UsuarioListViewModel model)
        {
            var usuario = model.Usuario;
            if (TryValidateModel(usuario) && usuario.ID > 0)
            {
                Usuario usuarioEditar = _context.Usuario.FirstOrDefault(p => p.ID == usuario.ID);
                usuarioEditar.USUARIO = usuario.USUARIO;
                usuarioEditar.PASSWORD = usuario.PASSWORD;
                usuarioEditar.ROL = usuario.ROL;
                usuarioEditar.NOMBRES = usuario.NOMBRES;
                usuarioEditar.APELLIDOP = usuario.APELLIDOP;
                usuarioEditar.APELLIDOM = usuario.APELLIDOM;

                _context.SaveChanges();
                return RedirectToAction("Datos", new { id = usuario.ID });
            }

            
            int usuarioId = model.Usuario.ID ?? 0;
            UsuarioModel u = await _context.GetUsuario(usuarioId);
            model.ListUsuarios = new List<UsuarioModel>();
            return View("Datos", model);
        }
        #endregion

        #region CATEGORIAS

        [HttpGet("Tienda/Categorias")]
        public async Task<ActionResult> Categorias()
        {
            List<CategoriaModel> categorias = await _context.AllCategorias();
            CategoriaListViewModel viewModel = new CategoriaListViewModel
            {
                ListCategorias = categorias,
                Categoria = new CategoriaModel(),
            };

            return View("Categorias", viewModel);
        }

        [HttpGet("Tienda/Categorias/{SEARCH}")]
        public async Task<ActionResult> Categorias(string search)
        {
            List<CategoriaModel> categorias = await _context.AllCategorias(search);
            CategoriaListViewModel viewModel = new CategoriaListViewModel
            {
                ListCategorias = categorias,
                Categoria = new CategoriaModel(),
            };

            return View(viewModel);
        }

        [HttpPost("Tienda/Categorias/Agregar")]
        public async Task<ActionResult> AgregarCategoria(CategoriaListViewModel model)
        {
            var categoria = model.Categoria;

            if (TryValidateModel(categoria))
            {
                CategoriaModel u = model.Categoria;
                _context.Categoria.Add(new Categoria
                {
                    DESCRIPCION = u.DESCRIPCION
                });

                _context.SaveChanges();
                return RedirectToAction("Categorias");
            }

            model.ListCategorias = await _context.AllCategorias();
            return View("Categorias", model);

        }

        [HttpPost("Tienda/Categorias/Editar")]
        public async Task<ActionResult> EditarCategoria(CategoriaListViewModel model)
        {
            var categoria = model.Categoria;

            if (TryValidateModel(categoria) && categoria.CategoriaId > 0)
            {
                Categoria categoriaEditar = _context.Categoria.FirstOrDefault(p => p.CategoriaId == categoria.CategoriaId);
                categoriaEditar.DESCRIPCION = categoria.DESCRIPCION;

                _context.SaveChanges();
                return RedirectToAction("Categorias");
            }

            model.ListCategorias = await _context.AllCategorias();
            return View("Categorias", model);
        }

        [HttpGet("Tienda/Categorias/Eliminar/{id}")]
        public ActionResult EliminarCategoria(int id)
        {
            Categoria categoria = _context.Categoria.FirstOrDefault(p => p.CategoriaId == id);
            _context.Categoria.Remove(categoria);
            _context.SaveChanges();
            return RedirectToAction("Categorias");
        }

        #endregion

    }
}
