using System.ComponentModel.DataAnnotations;

namespace TIENDA_VIRTUAL.Models
{
    public class Producto
    {
        [Key]
        public int? ID { get; set; }
        [Required(ErrorMessage = "CAMPO REQUERIDO")]
        public string NOMBRE { get; set; }
        [Required(ErrorMessage = "CAMPO REQUERIDO")]
        public string DETALLE { get; set; }
        [Required(ErrorMessage = "CAMPO REQUERIDO")]
        public decimal PRECIO { get; set; }
        [Required(ErrorMessage = "CAMPO REQUERIDO")]
        public string IMAGEN { get; set; }
        [Required(ErrorMessage = "CAMPO REQUERIDO")]
        public int STOCK { get; set; }
        [Required(ErrorMessage = "CAMPO REQUERIDO")]
        public DateTime FCRCN { get; set; } = DateTime.Now;
        // Foreign key
        public int CategoriaId { get; set; }
        // Navigation property
        public Categoria Categoria { get; set; }

    }

    public class ProductoModel
    {
        public int? ID { get; set; } = 0;
        [Required(ErrorMessage = "CAMPO REQUERIDO")]
        public string NOMBRE { get; set; }
        [Required(ErrorMessage = "CAMPO REQUERIDO")]
        public string DETALLE { get; set; }
        [Required(ErrorMessage = "CAMPO REQUERIDO")]
        public decimal PRECIO { get; set; }
        [Required(ErrorMessage = "CAMPO REQUERIDO")]
        public string IMAGEN { get; set; }
        [Required(ErrorMessage = "CAMPO REQUERIDO")]
        public int STOCK { get; set; }
        public DateTime FCRCN { get; set; } = DateTime.Now;
        //public Categoria Categoria { get; set; }
        public string DESCRIPCION { get; set; } = "";
        public int CategoriaId { get; set; } = 0;

    }

    public class ProductoListViewModel
    {
        public List<ProductoModel>? ListProductos { get; set; } = new List<ProductoModel>();
        public ProductoModel? NuevoProducto { get; set; } = new ProductoModel();
        public List<CategoriaModel>? ListCategoria { get; set; } = new List<CategoriaModel>();

    }

}
