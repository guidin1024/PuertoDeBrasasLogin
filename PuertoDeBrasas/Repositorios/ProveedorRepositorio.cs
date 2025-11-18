using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using PuertoDeBrasas.Modelos;

namespace PuertoDeBrasas.Repositorios
{
    public class ProveedorRepositorio : BaseRepositorio
    {
        public List<Proveedor> ObtenerTodos()
        {
            var proveedores = new List<Proveedor>();

            using (var conn = GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM proveedores";

                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        proveedores.Add(new Proveedor
                        {
                            ProveedorID = reader.GetInt32("ProveedorID"),
                            Nombre = reader.GetString("Nombre"),
                            Telefono = reader.GetString("Telefono"),
                            CorreoElectronico = reader.GetString("CorreoElectronico")
                        });
                    }
                }
            }

            return proveedores;
        }

        public bool AgregarProveedor(Proveedor proveedor)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO proveedores (Nombre, Telefono, CorreoElectronico) 
                                VALUES (@nombre, @telefono, @correo)";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", proveedor.Nombre);
                    cmd.Parameters.AddWithValue("@telefono", proveedor.Telefono);
                    cmd.Parameters.AddWithValue("@correo", proveedor.CorreoElectronico);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool ActualizarProveedor(Proveedor proveedor)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string query = @"UPDATE proveedores SET 
                                Nombre = @nombre, 
                                Telefono = @telefono, 
                                CorreoElectronico = @correo 
                                WHERE ProveedorID = @id";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", proveedor.ProveedorID);
                    cmd.Parameters.AddWithValue("@nombre", proveedor.Nombre);
                    cmd.Parameters.AddWithValue("@telefono", proveedor.Telefono);
                    cmd.Parameters.AddWithValue("@correo", proveedor.CorreoElectronico);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}