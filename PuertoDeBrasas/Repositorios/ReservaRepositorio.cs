using MySql.Data.MySqlClient;
using PuertoDeBrasas.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PuertoDeBrasas.Repositorios
{
    public class ReservaRepositorio : BaseRepositorio
    {
        public bool CrearReserva(Reserva reserva, List<int> menusSeleccionados)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Insertar reserva
                        string queryReserva = @"INSERT INTO reservas 
                            (ClienteID, Dia, Lugar, Hora_Inicio, Fecha_Fin) 
                            VALUES (@clienteId, @dia, @lugar, @inicio, @fin)";

                        var cmdReserva = new MySqlCommand(queryReserva, conn, transaction);
                        cmdReserva.Parameters.AddWithValue("@clienteId", reserva.ClienteID);
                        cmdReserva.Parameters.AddWithValue("@dia", reserva.Dia.Date);
                        cmdReserva.Parameters.AddWithValue("@lugar", reserva.Lugar);
                        cmdReserva.Parameters.AddWithValue("@inicio", reserva.HoraInicio);
                        cmdReserva.Parameters.AddWithValue("@fin", reserva.HoraFin);

                        cmdReserva.ExecuteNonQuery();
                        long reservaId = cmdReserva.LastInsertedId;

                        // 2. Insertar los menús seleccionados en reservamenu
                        foreach (int menuId in menusSeleccionados)
                        {
                            string queryMenu = @"INSERT INTO reservamenu 
                                (ReservaID, MenuID, Cantidad) 
                                VALUES (@reserva, @menu, @cantidad)";

                            var cmdMenu = new MySqlCommand(queryMenu, conn, transaction);
                            cmdMenu.Parameters.AddWithValue("@reserva", reservaId);
                            cmdMenu.Parameters.AddWithValue("@menu", menuId);
                            cmdMenu.Parameters.AddWithValue("@cantidad", 1);
                            cmdMenu.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Error al crear la reserva: " + ex.Message, ex);
                    }
                }
            }
        }
        // ⭐ AGREGAR ESTOS MÉTODOS AL FINAL:

        public DataTable ObtenerTodasReservas()
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string query = @"SELECT r.ReservaID, c.Nombre as Cliente, r.Dia, 
                                r.Lugar, r.Hora_Inicio, r.Fecha_Fin, 
                                'Pendiente' as Estado
                                FROM reservas r
                                INNER JOIN clientes c ON r.ClienteID = c.ClienteID
                                ORDER BY r.Dia DESC";

                var adapter = new MySqlDataAdapter(query, conn);
                var dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public Reserva? ObtenerPorId(int reservaId)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string query = @"SELECT * FROM reservas WHERE ReservaID = @id";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", reservaId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Reserva
                            {
                                ReservaID = reader.GetInt32("ReservaID"),
                                ClienteID = reader.GetInt32("ClienteID"),
                                Dia = reader.GetDateTime("Dia"),
                                Lugar = reader.GetString("Lugar"),
                                HoraInicio = (TimeSpan)reader["Hora_Inicio"],
                                HoraFin = (TimeSpan)reader["Fecha_Fin"]
                            };
                        }
                    }
                }
            }
            return null;
        }

        public List<string> ObtenerMenusDeReserva(int reservaId)
        {
            var menus = new List<string>();
            using (var conn = GetConnection())
            {
                conn.Open();
                string query = @"SELECT m.NombrePlato 
                                FROM reservamenu rm
                                INNER JOIN menu m ON rm.MenuID = m.MenuID
                                WHERE rm.ReservaID = @id";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", reservaId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            menus.Add(reader.GetString("NombrePlato"));
                        }
                    }
                }
            }
            return menus;
        }

        public bool EliminarReserva(int reservaId)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Primero eliminar de reservamenu
                        string queryMenu = "DELETE FROM reservamenu WHERE ReservaID = @id";
                        using (var cmd = new MySqlCommand(queryMenu, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@id", reservaId);
                            cmd.ExecuteNonQuery();
                        }

                        // Luego eliminar la reserva
                        string queryReserva = "DELETE FROM reservas WHERE ReservaID = @id";
                        using (var cmd = new MySqlCommand(queryReserva, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@id", reservaId);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}
