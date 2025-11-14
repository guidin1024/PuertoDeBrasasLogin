using MySql.Data.MySqlClient;
using PuertoDeBrasas.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuertoDeBrasas.Repositorios
{
    public class PlatoRepositorio : BaseRepositorio
    {
        public List<Plato> ObtenerTodos()
        {
            var platos = new List<Plato>();

            using (var conn = GetConnection())
            {
                conn.Open();
                string query = "SELECT MenuID, NombrePlato, Descripcion, Precio FROM menu";

                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        platos.Add(new Plato
                        {
                            MenuID = reader.GetInt32("MenuID"),
                            NombrePlato = reader.GetString("NombrePlato"),
                            Descripcion = reader.GetString("Descripcion"),
                            Precio = reader.GetDecimal("Precio")
                        });
                    }
                }
            }

            return platos;
        }
    }
}
