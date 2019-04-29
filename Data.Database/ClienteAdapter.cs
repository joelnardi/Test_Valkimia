using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;

namespace Data.Database
{
    public class ClienteAdapter : Adapter
    {
        public List<Cliente> GetAll()
        {
            List<Cliente> clientes = new List<Cliente>();

            try
            {
                this.OpenConnection();
                SqlCommand cmdClientes = new SqlCommand("select * from Clientes " +
                    "inner join Ciudades on Clientes.IDCiudad = Ciudades.IDCiudad ", SqlConn);
                SqlDataReader drClientes = cmdClientes.ExecuteReader();
                while (drClientes.Read())
                {
                    Cliente cl = new Cliente();
                    Ciudad ci = new Ciudad();
                    cl.ID = (int)drClientes["IDCliente"];
                    cl.Nombre = (string)drClientes["Nombre"];
                    cl.Apellido = (string)drClientes["Apellido"];
                    cl.EMail = (string)drClientes["Email"];
                    cl.Password = (string)drClientes["Password"];
                    cl.IdCiudad = (int)drClientes["IDCiudad"];
                    cl.Habilitado = (bool)drClientes["Habilitado"];
                    cl.Domicilio = (string)drClientes["Domicilio"];
                    ci.ID = (int)drClientes["IDCiudad"];
                    ci.Nombre = (string)drClientes["NombreCiudad"];

                    cl.Ciudad = ci;

                    clientes.Add(cl);
                }
                drClientes.Close();
            }
            catch (Exception Exc)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar los clientes", Exc);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return clientes;
        }

        public Cliente GetOne(int ID)
        {
            Cliente cl = new Cliente();
            try
            {
                this.OpenConnection();
                SqlCommand cmdClientes = new SqlCommand("select * from Clientes " +
                    "inner join Ciudades on Clientes.IDCiudad = Ciudades.IDCiudad " +
                    "where Clientes.IDCliente = @id ", SqlConn);
                cmdClientes.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drClientes = cmdClientes.ExecuteReader();

                if (drClientes.Read())
                {
                    Ciudad ci = new Ciudad();
                    cl.ID = (int)drClientes["IDCliente"];
                    cl.Nombre = (string)drClientes["Nombre"];
                    cl.Apellido = (string)drClientes["Apellido"];
                    cl.EMail = (string)drClientes["Email"];
                    cl.Password = (string)drClientes["Password"];
                    cl.IdCiudad = (int)drClientes["IDCiudad"];
                    cl.Habilitado = (bool)drClientes["Habilitado"];
                    cl.Domicilio = (string)drClientes["Domicilio"];
                    ci.ID = (int)drClientes["IDCiudad"];
                    ci.Nombre = (string)drClientes["NombreCiudad"];

                    cl.Ciudad = ci;
                }
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("No se pudo obtener el cliente especificado", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return cl;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete Clientes where IDCliente=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("No se puede eliminar este cliente", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Cliente cliente)
        {

            if (cliente.State == BusinessEntity.States.New)
            {
                this.Insert(cliente);
            }
            else if (cliente.State == BusinessEntity.States.Deleted)
            {
                this.Delete(cliente.ID);
            }
            else if (cliente.State == BusinessEntity.States.Modified)
            {
                this.Update(cliente);
            }
            cliente.State = BusinessEntity.States.Unmodified;
        }

        public void Update(Cliente cl)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand("update Clientes set Clientes.IDCiudad = @idCiudad, " +
                    "Clientes.Nombre = @nombre, Clientes.Apellido = @apellido, Clientes.Email = @email " +
                    "Clientes.Password = @password, Clientes.Habilitado = @habilitado, Clientes.Domicilio = @domicilio " +
                    "where Clientes.IDCliente = @id", SqlConn);
                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = cl.ID;
                cmdUpdate.Parameters.Add("@idCiudad", SqlDbType.Int).Value = cl.IdCiudad;
                cmdUpdate.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = cl.Nombre;
                cmdUpdate.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = cl.Apellido;
                cmdUpdate.Parameters.Add("@email", SqlDbType.VarChar, 100).Value = cl.EMail;
                cmdUpdate.Parameters.Add("@password", SqlDbType.VarChar, 100).Value = cl.Password;
                cmdUpdate.Parameters.Add("@habilitado", SqlDbType.Bit).Value = cl.Habilitado;
                cmdUpdate.Parameters.Add("@domicilio", SqlDbType.VarChar, 100).Value = cl.Domicilio;
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("No se pudo actualizar el cliente", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Insert(Cliente cl)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand("insert Clientes (IDCiudad, Nombre, Apellido, Email, Password, Habilitado, Domicilio) " +
                "values (@idCiudad, @nombre, @apellido, @email, @password, @habilitado, @domicilio) select @@identity", SqlConn);
                cmdInsert.Parameters.Add("@idCiudad", SqlDbType.Int).Value = cl.IdCiudad;
                cmdInsert.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = cl.Nombre;
                cmdInsert.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = cl.Apellido;
                cmdInsert.Parameters.Add("@email", SqlDbType.VarChar, 100).Value = cl.EMail;
                cmdInsert.Parameters.Add("@password", SqlDbType.VarChar, 100).Value = cl.Password;
                cmdInsert.Parameters.Add("@habilitado", SqlDbType.Bit).Value = cl.Habilitado;
                cmdInsert.Parameters.Add("@domicilio", SqlDbType.VarChar, 100).Value = cl.Domicilio;
                cl.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("No se pudo crear nuevo cliente", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public Cliente GetOne(string email)
        {
            Cliente cl = new Cliente();
            try
            {
                this.OpenConnection();
                SqlCommand cmdClientes = new SqlCommand("select * from Clientes " +
                    "inner join Ciudades on Clientes.IDCiudad = Ciudades.IDCiudad " +
                    "where Clientes.Email = @Email ", SqlConn);
                cmdClientes.Parameters.Add("@Email", SqlDbType.VarChar, 100).Value = email;
                SqlDataReader drClientes = cmdClientes.ExecuteReader();

                if (drClientes.Read())
                {
                    Ciudad ci = new Ciudad();
                    cl.ID = (int)drClientes["IDCliente"];
                    cl.Nombre = (string)drClientes["Nombre"];
                    cl.Apellido = (string)drClientes["Apellido"];
                    cl.EMail = (string)drClientes["Email"];
                    cl.Password = (string)drClientes["Password"];
                    cl.IdCiudad = (int)drClientes["IDCiudad"];
                    cl.Habilitado = (bool)drClientes["Habilitado"];
                    cl.Domicilio = (string)drClientes["Domicilio"];
                    ci.ID = (int)drClientes["IDCiudad"];
                    ci.Nombre = (string)drClientes["NombreCiudad"];

                    cl.Ciudad = ci;
                }
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("No se pudo obtener el cliente especificado", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return cl;
        }

        public bool Existe(string Email)
        {
            Cliente test = GetOne(Email);
            return !("" == test.EMail || null == test.EMail);
        }
    }
}