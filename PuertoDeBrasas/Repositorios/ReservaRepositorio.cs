using MySql.Data.MySqlClient;
using PuertoDeBrasas.Modelos;
using System;
using System.Collections.Generic;
using System.Data;


namespace PuertoDeBrasas.Repositorios
{
    public class ReservaRepositorio : BaseRepositorio
    {
        // Verificar si el cliente tiene una reserva pendiente o aceptada
        public bool TieneReservaPendiente(int clienteId)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT COUNT(*) FROM reservas 
                                   WHERE ClienteID = @clienteId 
                                   AND (Estado = 'Pendiente' OR Estado = 'Aceptado')";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@clienteId", clienteId);
                        long count = (long)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public bool CrearReserva(Reserva reserva, List<int> menusSeleccionados)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string queryReserva = @"INSERT INTO reservas 
                            (ClienteID, Dia, Lugar, Hora_Inicio, Fecha_Fin, Estado) 
                            VALUES (@clienteId, @dia, @lugar, @inicio, @fin, 'Pendiente')";

                        var cmdReserva = new MySqlCommand(queryReserva, conn, transaction);
                        cmdReserva.Parameters.AddWithValue("@clienteId", reserva.ClienteID);
                        cmdReserva.Parameters.AddWithValue("@dia", reserva.Dia.Date);
                        cmdReserva.Parameters.AddWithValue("@lugar", reserva.Lugar);
                        cmdReserva.Parameters.AddWithValue("@inicio", reserva.HoraInicio);
                        cmdReserva.Parameters.AddWithValue("@fin", reserva.HoraFin);

                        cmdReserva.ExecuteNonQuery();
                        long reservaId = cmdReserva.LastInsertedId;

                        foreach (int menuId in menusSeleccionados)
                        {
                            string queryMenu = @"INSERT INTO reservamenu 
                                (ReservaID, MenuID, Cantidad) 
                                VALUES (@reserva, @menu, 1)";

                            var cmdMenu = new MySqlCommand(queryMenu, conn, transaction);
                            cmdMenu.Parameters.AddWithValue("@reserva", reservaId);
                            cmdMenu.Parameters.AddWithValue("@menu", menuId);
                            cmdMenu.ExecuteNonQuery();
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

        public DataTable ObtenerTodasReservas()
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT 
                        r.ReservaID,
                        c.Nombre as Cliente,
                        c.Telefono as TelefonoCliente,
                        r.Dia,
                        r.Lugar,
                        r.Hora_Inicio as HoraInicio,
                        r.Fecha_Fin as HoraFin,
                        r.Estado,
                        GROUP_CONCAT(m.NombrePlato SEPARATOR ', ') as Menu
                        FROM reservas r
                        INNER JOIN clientes c ON r.ClienteID = c.ClienteID
                        LEFT JOIN reservamenu rm ON r.ReservaID = rm.ReservaID
                        LEFT JOIN menu m ON rm.MenuID = m.MenuID
                        GROUP BY r.ReservaID, c.Nombre, c.Telefono, r.Dia, r.Lugar, r.Hora_Inicio, r.Fecha_Fin, r.Estado
                        ORDER BY r.Dia DESC, r.Hora_Inicio DESC";

                    var adapter = new MySqlDataAdapter(query, conn);
                    var dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return new DataTable();
            }
        }

        public Reserva? ObtenerPorId(int reservaId)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM reservas WHERE ReservaID = @id";

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
                                    HoraFin = (TimeSpan)reader["Fecha_Fin"],
                                    Estado = reader["Estado"]?.ToString() ?? "Pendiente"
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return null;
        }

        public bool CambiarEstado(int reservaId, string nuevoEstado)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE reservas SET Estado = @estado WHERE ReservaID = @id";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@estado", nuevoEstado);
                        cmd.Parameters.AddWithValue("@id", reservaId);
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

        public bool ActualizarReserva(Reserva reserva)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    string query = @"UPDATE reservas SET 
                        Dia = @dia,
                        Lugar = @lugar,
                        Hora_Inicio = @inicio,
                        Fecha_Fin = @fin
                        WHERE ReservaID = @id";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", reserva.ReservaID);
                        cmd.Parameters.AddWithValue("@dia", reserva.Dia);
                        cmd.Parameters.AddWithValue("@lugar", reserva.Lugar);
                        cmd.Parameters.AddWithValue("@inicio", reserva.HoraInicio);
                        cmd.Parameters.AddWithValue("@fin", reserva.HoraFin);
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

        public List<string> ObtenerMenusDeReserva(int reservaId)
        {
            var menus = new List<string>();
            try
            {
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
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
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
                        string queryMenu = "DELETE FROM reservamenu WHERE ReservaID = @id";
                        using (var cmd = new MySqlCommand(queryMenu, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@id", reservaId);
                            cmd.ExecuteNonQuery();
                        }

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
                        return false;
                    }
                }
            }
        }
    }
}