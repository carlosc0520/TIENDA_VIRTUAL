using System.ComponentModel.DataAnnotations;

namespace TIENDA_VIRTUAL.Models
{
    public class Categoria
    {
        [Key]
        public int? CategoriaId { get; set; }
        [Required(ErrorMessage = "CAMPO REQUERIDO")]
        public string DESCRIPCION { get; set; }
        public ICollection<Producto> Productos { get; set; }
        
    }

    public class CategoriaModel
    {
        public int? CategoriaId { get; set; } = 0;

        public string DESCRIPCION { get; set; }

    }

    public class CategoriaListViewModel
    {
        public List<CategoriaModel>? ListCategorias { get; set; } = new List<CategoriaModel>();
        public CategoriaModel? Categoria { get; set; } = new CategoriaModel();
    }

}
