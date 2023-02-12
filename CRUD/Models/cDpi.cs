using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CRUD.Models
{
    public class cDpi
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MinLength(15, ErrorMessage = "El {0} ser mayor a 15 digitos")]
        [Display(Name ="DPI")]
        public string dpi { get; set; }
    }
}
