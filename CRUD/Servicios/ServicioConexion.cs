using CRUD.Models;
using Dapper;
using System.Data.SqlClient;

namespace CRUD.Servicios
{
    public interface IServicioConexion
    {
        Task ActrivarU(string dpi);
        Task<EUsuario> BuscarU(string dpi);
        Task<bool> BuscarUs(string dpi);
        Task Crear(CUsuario usuario);
        Task DesactrivarU(string dpi);
        Task Eliminar(string dpi);
        Task<IEnumerable<EUsuario>> EObetener();
        Task ModUsuario(EUsuario usuario);
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
        public async Task<IEnumerable<EUsuario>> EObetener()
        {
            using var connection = new SqlConnection(cadenaConexion);
            return await connection.QueryAsync<EUsuario>("select * from Usuario");
        }

        public async Task Eliminar(string dpi)
        {
            using var connection = new SqlConnection(cadenaConexion);
            await connection.ExecuteAsync("delete Usuario where dpi= @dpi", new {dpi});
        }

        public async Task<EUsuario> BuscarU(string dpi)
        {
            using var connection = new SqlConnection(cadenaConexion);
            return await connection.QuerySingleAsync<EUsuario>("select * from Usuario where dpi= @dpi", new { dpi });
        }

        public async Task<bool> BuscarUs(string dpi)
        {
            using var connection = new SqlConnection(cadenaConexion);
            var respueta = await connection.QuerySingleAsync<int>("select count(*) from Usuario where dpi= @dpi", new { dpi });
            if (respueta == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task ModUsuario(EUsuario usuario)
        {
            using var connection = new SqlConnection(cadenaConexion);
            var id = await connection.QuerySingleAsync<int>("ModificarUser",
                                                            new
                                                            {
                                                                usuario.dpi,
                                                                usuario.Nombre,
                                                                usuario.Apellido,
                                                                usuario.FechNac,
                                                                usuario.edad,
                                                                usuario.profesion,
                                                                usuario.nacionalidad,
                                                                usuario.telefono
                                                            }, commandType: System.Data.CommandType.StoredProcedure);
            usuario.sn_activo = id;
        }

        public async Task DesactrivarU(string dpi)
        {
            using var connection = new SqlConnection(cadenaConexion);
            await connection.ExecuteAsync("update Usuario set sn_activo = 0 from Usuario  where dpi= @dpi", new { dpi });
        }
        public async Task ActrivarU(string dpi)
        {
            using var connection = new SqlConnection(cadenaConexion);
            await connection.ExecuteAsync("update Usuario set sn_activo = 1 from Usuario  where dpi= @dpi", new { dpi });
        }




    }
}
