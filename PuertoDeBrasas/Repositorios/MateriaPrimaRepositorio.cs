using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using PuertoDeBrasas.Modelos;

namespace PuertoDeBrasas.Repositorios
{
    public class MateriaPrimaRepositorio : BaseRepositorio
    {
        public List<MateriaPrima> ObtenerTodas()
        {
            var materias = new List<MateriaPrima>();

            using (var conn = GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM materiaprima";

                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        materias.Add(new MateriaPrima
                        {
                            MateriaPrimaID = reader.GetInt32("MateriaPrimaID"),
                            Nombre = reader.GetString("Nombre"),
                            Stock = reader.GetInt32("Stock"),
                            UnidadMedida = reader.GetString("UnidadMedida"),
                            ProveedorID = reader.GetInt32("ProveedorID")
                        });
                    }
                }
            }

            return materias;
        }

        public bool ActualizarStock(int materiaPrimaId, int nuevoStock)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string query = "UPDATE materiaprima SET Stock = @stock WHERE MateriaPrimaID = @id";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", materiaPrimaId);
                    cmd.Parameters.AddWithValue("@stock", nuevoStock);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}