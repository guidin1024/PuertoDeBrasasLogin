using MySqlConnector;
using PuertoDeBrasas.Modelos;
using System;


namespace PuertoDeBrasas.Data
{
    public class ClienteRepositorio
    {
        private readonly string connectionString =
            "Server=localhost;Database=puertodebrasasbd;User ID=root;Password=root";

        public ClienteRepositorio()
        {
            try
            {
                using var conn = new MySqlConnection(connectionString);
                conn.Open();
                Console.WriteLine("✅ Conexión exitosa a la base de datos");
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Error al conectar con la base de datos: " + ex.Message);
            }
        }

        public bool Registrar(Cliente cliente)
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"INSERT INTO clientes 
                                    (nombre, correoElectronico, clave, telefono, tipoCliente)
                                    VALUES (@nombre, @correo, @clave, @telefono, @tipo)";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@nombre", cliente.Nombre);
                        command.Parameters.AddWithValue("@correo", cliente.CorreoElectronico);
                        command.Parameters.AddWithValue("@clave", cliente.Clave);
                        command.Parameters.AddWithValue("@telefono", cliente.Telefono);
                        command.Parameters.AddWithValue("@tipo", cliente.TipoCliente);

                        int filasAfectadas = command.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en ClienteRepositorio.Registrar: " + ex.Message, ex);
            }
        }

        public Cliente? Autenticar(string correo, string clave)
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"SELECT * FROM clientes 
                                     WHERE correoElectronico = @correo AND clave = @clave";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@correo", correo);
                        command.Parameters.AddWithValue("@clave", clave);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Cliente
                                {
                                    ClienteID = reader.GetInt32("ClienteID"),
                                    Nombre = reader["nombre"].ToString() ?? "",
                                    CorreoElectronico = reader["correoElectronico"].ToString() ?? "",
                                    Clave = reader["clave"].ToString() ?? "",
                                    Telefono = reader["telefono"].ToString() ?? "",
                                    TipoCliente = reader["tipoCliente"].ToString() ?? "Persona"
                                };
                            }
                        }
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en ClienteRepository.Autenticar: " + ex.Message, ex);
            }
        }

        public List<Cliente> ObtenerTodos()
        {
            var clientes = new List<Cliente>();

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"SELECT * FROM clientes ORDER BY TipoCliente, Nombre";

                    using (var command = new MySqlCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            clientes.Add(new Cliente
                            {
                                ClienteID = reader.GetInt32("ClienteID"),
                                TipoCliente = reader["tipoCliente"].ToString() ?? "Persona",
                                Nombre = reader["nombre"].ToString() ?? "",
                                CorreoElectronico = reader["correoElectronico"].ToString() ?? "",
                                Telefono = reader["telefono"].ToString() ?? "",
                                Clave = reader["clave"].ToString() ?? ""
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en ClienteRepositorio.ObtenerTodos: " + ex.Message, ex);
            }

            return clientes;
        }

        public bool Actualizar(Cliente cliente)
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"UPDATE clientes SET 
                                    Nombre = @nombre,
                                    CorreoElectronico = @correo,
                                    Telefono = @telefono,
                                    Clave = @clave,
                                    TipoCliente = @tipo
                                    WHERE ClienteID = @id";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", cliente.ClienteID);
                        command.Parameters.AddWithValue("@nombre", cliente.Nombre);
                        command.Parameters.AddWithValue("@correo", cliente.CorreoElectronico);
                        command.Parameters.AddWithValue("@telefono", cliente.Telefono);
                        command.Parameters.AddWithValue("@clave", cliente.Clave);
                        command.Parameters.AddWithValue("@tipo", cliente.TipoCliente);

                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en ClienteRepositorio.Actualizar: " + ex.Message, ex);
            }
        }

        public bool Eliminar(int clienteId)
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Primero verificar si el cliente tiene reservas
                    string queryVerificar = @"SELECT COUNT(*) FROM reservas WHERE ClienteID = @id";
                    using (var cmdVerificar = new MySqlCommand(queryVerificar, connection))
                    {
                        cmdVerificar.Parameters.AddWithValue("@id", clienteId);
                        long cantidadReservas = (long)cmdVerificar.ExecuteScalar();

                        if (cantidadReservas > 0)
                        {
                            throw new Exception(
                                $"No se puede eliminar el cliente porque tiene {cantidadReservas} reserva(s) asociada(s). " +
                                "Elimina primero las reservas.");
                        }
                    }

                    // Si no tiene reservas, proceder con la eliminación
                    string query = @"DELETE FROM clientes WHERE ClienteID = @id";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", clienteId);
                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en ClienteRepositorio.Eliminar: " + ex.Message, ex);
            }
        }
    }
}