using MySql.Data.MySqlClient;
using PuertoDeBrasas.Modelos;
using System;
using System.Collections.Generic;

namespace PuertoDeBrasas.Repositorios
{
    public class PlatoRepositorio : BaseRepositorio
    {
        public List<Plato> ObtenerTodos()
        {
            var platos = new List<Plato>();
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    string query = "SELECT MenuID, NombrePlato, Precio FROM menu ORDER BY MenuID";

                    using (var cmd = new MySqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            platos.Add(new Plato
                            {
                                MenuID = reader.GetInt32("MenuID"),
                                NombrePlato = reader.GetString("NombrePlato"),
                                Precio = reader.GetDecimal("Precio")
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return platos;
        }

        public bool AgregarPlato(Plato plato)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO menu (NombrePlato, Precio) VALUES (@nombre, @precio)";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", plato.NombrePlato);
                        cmd.Parameters.AddWithValue("@precio", plato.Precio);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public bool ActualizarPlato(Plato plato)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE menu SET NombrePlato = @nombre, Precio = @precio WHERE MenuID = @id";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", plato.MenuID);
                        cmd.Parameters.AddWithValue("@nombre", plato.NombrePlato);
                        cmd.Parameters.AddWithValue("@precio", plato.Precio);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public bool EliminarPlato(int menuId)
        {
            try
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
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }
    }
}