using CRUD.Models;
using Dapper;
using System.Data.SqlClient;

namespace CRUD.Servicios
{
    public interface IServicioConexion
    {
        Task Crear(CUsuario usuario);
        Task Eliminar(string dpi);
        Task<IEnumerable<EUsusario>> EObetener();
    }
    public class ServicioConexion:IServicioConexion
    {
        private readonly string cadenaConexion;

        public ServicioConexion(IConfiguration configuracion) 
        {
            this.cadenaConexion = configuracion.GetConnectionString("DefaultConnection");
        }

        public async Task Crear(CUsuario usuario)
        {
            using var connection = new SqlConnection(cadenaConexion);
            var id = await connection.QuerySingleAsync<int>("InsertarUser", 
                                                            new {
                                                                usuario.dpi,
                                                                usuario.Nombre,
                                                                usuario.Apellido,
                                                                usuario.FechNac,
                                                                usuario.edad,
                                                                usuario.profesion,
                                                                usuario.nacionalidad,
                                                                usuario.telefono
                                                            } ,commandType: System.Data.CommandType.StoredProcedure);
            usuario.resultado= id;
        }
        public async Task<IEnumerable<EUsusario>> EObetener()
        {
            using var connection = new SqlConnection(cadenaConexion);
            return await connection.QueryAsync<EUsusario>("select * from Usuario");
        }

        public async Task Eliminar(string dpi)
        {
            using var connection = new SqlConnection(cadenaConexion);
            await connection.ExecuteAsync("delete Usuario where dpi= @dpi", new {dpi});
        }
    }
}
