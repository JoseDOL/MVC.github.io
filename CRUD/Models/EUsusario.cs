using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Xml.Linq;

namespace CRUD.Models
{
    public class EUsusario
    {
        public BigInteger dpi { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechNac { get; set; }
        public int edad { get; set; }
        public string profesion { get; set; }
        public string nacionalidad { get; set; }
        public string telefono { get; set; }
        public int sn_activo { get; set; }

        internal IEnumerable<EUsusario> ToList()
        {
            throw new NotImplementedException();
        }
    }
}
