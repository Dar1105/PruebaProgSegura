using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProgSeguraLogin.Repositories
{
    public class IndexRepository
    {
        private readonly string ConnectionString = "server=localhost; database=SistemaDeBusquedaBD;Integrated Security=true;";

        public bool ValidarUsuario(string usuario, string password)
        {
            bool resultado = false;
            using SqlConnection sql = new SqlConnection(ConnectionString);
            using SqlCommand cmd = new SqlCommand("select count(*) from usuarios where usuario = '" + usuario + "' and[password] = '" + password + "'", sql);
            int valor;

            sql.Open(); //con esto se abre
            valor = (int)cmd.ExecuteScalar();
            if (valor > 0)
            {
                resultado = true;
            }

            return resultado;

        }
    }
    }