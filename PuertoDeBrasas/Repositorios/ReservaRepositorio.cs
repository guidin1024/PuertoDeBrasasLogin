using MySql.Data.MySqlClient;
using PuertoDeBrasas.Modelos;
using System;
using System.Collections.Generic;
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
    }
}
