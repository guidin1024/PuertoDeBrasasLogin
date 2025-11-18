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

        public bool AgregarPlato(Plato plato)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO menu (NombrePlato, Descripcion, Precio) 
                                VALUES (@nombre, @descripcion, @precio)";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", plato.NombrePlato);
                    cmd.Parameters.AddWithValue("@descripcion", plato.Descripcion);
                    cmd.Parameters.AddWithValue("@precio", plato.Precio);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool ActualizarPlato(Plato plato)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string query = @"UPDATE menu SET 
                                NombrePlato = @nombre, 
                                Descripcion = @descripcion, 
                                Precio = @precio 
                                WHERE MenuID = @id";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", plato.MenuID);
                    cmd.Parameters.AddWithValue("@nombre", plato.NombrePlato);
                    cmd.Parameters.AddWithValue("@descripcion", plato.Descripcion);
                    cmd.Parameters.AddWithValue("@precio", plato.Precio);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool EliminarPlato(int menuId)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM menu WHERE MenuID = @id";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", menuId);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
