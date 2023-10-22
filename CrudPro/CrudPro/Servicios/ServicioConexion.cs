using CrudPro.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace CrudPro.Servicios
{
    public interface IServicioConexion {
        Task<IEnumerable<navMenu>> ObtenerNav();

    }
    public class ServicioConexion : IServicioConexion
    {
        private readonly string cadenaConexion;

        public ServicioConexion(IConfiguration configuracion)
        {
            this.cadenaConexion = configuracion.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<navMenu>> ObtenerNav()
        {
            using var connection = new SqlConnection(cadenaConexion);
            return (IEnumerable<navMenu>)await connection.QueryAsync<navMenu>("spc_obtener_nav_menu", commandType: System.Data.CommandType.StoredProcedure);
        }
    }
}
