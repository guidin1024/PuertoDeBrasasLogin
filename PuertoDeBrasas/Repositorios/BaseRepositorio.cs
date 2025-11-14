using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuertoDeBrasas.Repositorios
{
    public abstract class BaseRepositorio
    {
        protected readonly string connectionString =
            "Server=localhost;Database=puertodebrasasbd;User ID=root;Password=root";

        protected MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
