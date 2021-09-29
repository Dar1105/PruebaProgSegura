using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProgSeguraLogin.Repositories
{
    public class IndexRepository
    {
        private readonly string ConnectionString = "server=localhost; database=SistemaDeBusquedaDB;Integrated Security=true;";

        public bool ValidarUsuario(string usuario, string password)
         {
            bool resultado = false;
            using SqlConnection sql = new SqlConnection(ConnectionString);
            using SqlCommand cmd = new SqlCommand("select count(*) from usuarios where usuario = '" + usuario + "' and [password] = '" + password + "'", sql);
            int valor;

            sql.Open();
            valor = (int)cmd.ExecuteScalar();
            if (valor > 0)
            {
                resultado = true;
            }

            return resultado;

        }
    } 
    }
/*

public bool ExisteUsuario(string nombreUsuario, string password)
{
    bool respuesta = false;
    string connectionString = "server=localhost;database=sistemaBusqueda2;Integrated Security = true;";
    using SqlConnection sql = new SqlConnection(connectionString);
    using SqlCommand cmd = new SqlCommand("sp_check_usuario", sql);
    cmd.CommandType = System.Data.CommandType.StoredProcedure;
    cmd.Parameters.Add(new SqlParameter("@nombreUsuario", nombreUsuario));
    cmd.Parameters.Add(new SqlParameter("@password", password));
    sql.Open();
    int resultadoQuery = (int)cmd.ExecuteScalar();
    if (resultadoQuery > 0)
    {
        respuesta = true;
    }
    return respuesta;

*/