using Microsoft.EntityFrameworkCore;
using TIENDA_VIRTUAL.Models;

namespace TIENDA_VIRTUAL.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        // CREAR DE TABLES
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Categoria> Categoria { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de la relación uno a muchos
            modelBuilder.Entity<Producto>()
                .HasOne(p => p.Categoria)
                .WithMany(c => c.Productos)
                .HasForeignKey(p => p.CategoriaId);
        }


        #region PRODUCTOS
        public async Task<List<ProductoModel>> AllProductos(string search = null)
        {
            var query = Producto.Include(p => p.Categoria).AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(p => p.NOMBRE.Contains(search) || p.DETALLE.Contains(search));
            }

            return await query
                .Select(p => new ProductoModel
                {
                    ID = p.ID,
                    NOMBRE = p.NOMBRE,
                    DETALLE = p.DETALLE,
                    PRECIO = p.PRECIO,
                    IMAGEN = p.IMAGEN,
                    STOCK = p.STOCK,
                    CategoriaId = p.CategoriaId,
                    DESCRIPCION = p.Categoria.DESCRIPCION
                })
                .ToListAsync();
        }
        
        public async Task<List<ProductoModel>> TopProductos(int n)
        {
            return await Producto
                .Include(p => p.Categoria)
                .OrderByDescending(p => p.STOCK)
                .Take(n)
                .Select(p => new ProductoModel
                {
                    ID = p.ID,
                    NOMBRE = p.NOMBRE,
                    DETALLE = p.DETALLE,
                    PRECIO = p.PRECIO,
                    IMAGEN = p.IMAGEN,
                    STOCK = p.STOCK,
                    CategoriaId = p.CategoriaId,
                    DESCRIPCION = p.Categoria.DESCRIPCION
                })
                .ToListAsync();
        }
        #endregion

        #region CATEGORIAS
        public async Task<List<CategoriaModel>> AllCategorias(string search = null)
        {
            var query = Categoria.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(c => c.DESCRIPCION.Contains(search));
            }

            return await query
                .Select(c => new CategoriaModel
                {
                    CategoriaId = c.CategoriaId,
                    DESCRIPCION = c.DESCRIPCION
                })
                .ToListAsync();
        }
        #endregion

        #region USUARIOS
        public async Task<List<UsuarioModel>> AllUsuarios(string search = null)
        {
            var query = Usuario.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(u => u.USUARIO.Contains(search));
            }

            return await query
                .Select(u => new UsuarioModel
                {
                    ID = u.ID,
                    USUARIO = u.USUARIO,
                    PASSWORD = u.PASSWORD,
                    FECHA = u.FECHA,
                    ROL = u.ROL,
                    NOMBRES = u.NOMBRES,
                    APELLIDOP = u.APELLIDOP,
                    APELLIDOM = u.APELLIDOM,
                })
                .ToListAsync();
        }   

        public async Task<UsuarioModel> GetUsuario(int? id)
        {
            return await Usuario
                .Where(u => u.ID == id)
                .Select(u => new UsuarioModel
                {
                    ID = u.ID,
                    USUARIO = u.USUARIO,
                    PASSWORD = u.PASSWORD,
                    FECHA = u.FECHA,
                    ROL = u.ROL,
                    NOMBRES = u.NOMBRES,
                    APELLIDOP = u.APELLIDOP,
                    APELLIDOM = u.APELLIDOM,
                })
                .FirstOrDefaultAsync();
        }   
        #endregion
    }
}
