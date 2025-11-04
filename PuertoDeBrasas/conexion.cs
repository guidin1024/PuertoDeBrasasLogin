using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PuertoDeBrasas
{
    public class Conexion
    {
        //ATRITUBOS DE CLASE
        private const string servidor = "server=127.0.0.1";
        private const string puerto = "port=3306";
        private const string username = "user=root";
        private const string password = "password=root";
        private const string bd = "database=puertodebrasasbd";
        //ATRIBUTOS DE INSTANCIA
        private String cadenaConexion;
        //CONSTRUCTOR
        public Conexion()
        {

            cadenaConexion = servidor + ";" + puerto + ";" + username
            + ";" + password + ";" + bd;

        }
        //SERVICIOS
        public MySqlConnection getConexion()
        {
            return new MySqlConnection(cadenaConexion);
        }
    }
}
