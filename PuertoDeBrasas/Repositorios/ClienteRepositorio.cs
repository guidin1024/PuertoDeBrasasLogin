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
                                // Si el usuario existe, devolvemos un objeto Cliente
                                return new Cliente
                                {
                                    Nombre = reader["nombre"].ToString(),
                                    CorreoElectronico = reader["correoElectronico"].ToString(),
                                    Clave = reader["clave"].ToString(),
                                    Telefono = reader["telefono"].ToString(),
                                    TipoCliente = reader["tipoCliente"].ToString()
                                };
                            }
                        }
                    }
                }

                // Si no encontró coincidencias, devolvemos null
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en ClienteRepository.Autenticar: " + ex.Message, ex);
            }
        }
    }
}
