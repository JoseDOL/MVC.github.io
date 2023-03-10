using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace CRUD.Models
{
    public class CUsuario
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "DPI")]
        [MinLength(15, ErrorMessage = "El {0} ser mayor a 15 digitos")]
        public string dpi { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Apellido")]
        public string Apellido { get; set;}
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechNac { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Edad")]
        public int edad { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Profesion")]
        public string profesion { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Nacionalidad")]
        public string nacionalidad { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Telefono")]
        public string telefono { get; set;}

        public int resultado { get; set; } = 0;
    }
}
