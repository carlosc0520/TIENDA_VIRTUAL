using System.ComponentModel.DataAnnotations;

namespace TIENDA_VIRTUAL.Models
{
    public class Usuario
    {
        [Key]
        public int? ID { get; set; }
        [Required(ErrorMessage = "CAMPO REQUERIDO")]
        public string USUARIO { get; set; }
        [Required(ErrorMessage = "CAMPO REQUERIDO")]
        public string? PASSWORD { get; set; }
        public DateTime FECHA { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "CAMPO REQUERIDO")]
        public string? ROL { get; set; }
        [Required(ErrorMessage = "CAMPO REQUERIDO")]
        public string? NOMBRES { get; set; }        
        [Required(ErrorMessage = "CAMPO REQUERIDO")]
        public string? APELLIDOP { get; set; }
        [Required(ErrorMessage = "CAMPO REQUERIDO")]
        public string? APELLIDOM { get; set; }

    }

    public class UsuarioModel
    {
        public int? ID { get; set; } = 0;

        [Required(ErrorMessage = "Por favor ingrese su usuario.")]
        public string USUARIO { get; set; }

        [Required(ErrorMessage = "Por favor ingrese su contraseña.")]
        public string PASSWORD { get; set; }
        public string? TOKEN { get; set; } = null;
        public DateTime? FECHA { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Por favor ingrese su rol.")]
        public string? ROL { get; set; } = null;
        [Required(ErrorMessage = "Por favor ingrese su nombre.")]
        public string? NOMBRES { get; set; } = null;
        [Required(ErrorMessage = "Por favor ingrese su apellido paterno.")]
        public string? APELLIDOP { get; set; } = null;
        public string? APELLIDOM { get; set; } = null;
    }

    public class UsuarioModelLogin
    {
        public int? ID { get; set; } = 0;

        [Required(ErrorMessage = "Por favor ingrese su usuario.")]
        public string USUARIO { get; set; }

        [Required(ErrorMessage = "Por favor ingrese su contraseña.")]
        public string PASSWORD { get; set; }
        public string? TOKEN { get; set; } = null;
        public string? ROL { get; set; } = null;
    }

    public class UsuarioListViewModel
    {
        public List<UsuarioModel>? ListUsuarios { get; set; } = new List<UsuarioModel>();
        public UsuarioModel? Usuario { get; set; } = new UsuarioModel();
    }
}
