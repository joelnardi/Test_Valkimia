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
    public class FacturaAdapter : Adapter
    {
        public List<Factura> GetAll()
        {
            List<Factura> facturas = new List<Factura>();

            try
            {
                this.OpenConnection();
                SqlCommand cmdFacturas = new SqlCommand("select * from Facturas " +
                    "inner join Clientes on Clientes.ID = Facturas.IDCliente " +
                    "inner join Ciudades on Clientes.IDCiudad = Ciudades.ID ", SqlConn);
                SqlDataReader drFacturas = cmdFacturas.ExecuteReader();
                while (drFacturas.Read())
                {
                    Factura fa = new Factura();
                    Cliente cl = new Cliente();
                    Ciudad ci = new Ciudad();
                    fa.ID = (int)drFacturas["Facturas.ID"];
                    fa.Fecha = (DateTime)drFacturas["Fecha"];
                    fa.Detalle = (string)drFacturas["Detalle"];
                    fa.IdCliente = (int)drFacturas["IDCliente"];
                    fa.Importe = (double)drFacturas["Importe"];
                    cl.ID = (int)drFacturas["Clientes.ID"];
                    cl.Nombre = (string)drFacturas["Clientes.Nombre"];
                    cl.Apellido = (string)drFacturas["Apellido"];
                    cl.EMail = (string)drFacturas["Email"];
                    cl.Password = (string)drFacturas["Password"];
                    cl.IdCiudad = (int)drFacturas["IDCiudad"];
                    cl.Habilitado = (bool)drFacturas["Habilitado"];
                    cl.Domicilio = (string)drFacturas["Domicilio"];
                    ci.ID = (int)drFacturas["Ciudades.ID"];
                    ci.Nombre = (string)drFacturas["Ciudades.Nombre"];

                    fa.Cliente = cl;
                    cl.Ciudad = ci;

                    facturas.Add(fa);
                }
                drFacturas.Close();
            }
            catch (Exception Exc)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar las facturas", Exc);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return facturas;
        }

        public Factura GetOne(int ID)
        {
            Factura fa = new Factura();
            try
            {
                this.OpenConnection();
                SqlCommand cmdFacturas = new SqlCommand("select * from Facturas " +
                    "inner join Clientes on Clientes.ID = Facturas.IDCliente " +
                    "inner join Ciudades on Clientes.IDCiudad = Ciudades.ID " +
                    "where Facturas.ID = @id ", SqlConn);
                cmdFacturas.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drFacturas = cmdFacturas.ExecuteReader();

                if (drFacturas.Read())
                {
                    Cliente cl = new Cliente();
                    Ciudad ci = new Ciudad();
                    fa.ID = (int)drFacturas["Facturas.ID"];
                    fa.Fecha = (DateTime)drFacturas["Fecha"];
                    fa.Detalle = (string)drFacturas["Detalle"];
                    fa.IdCliente = (int)drFacturas["IDCliente"];
                    fa.Importe = (double)drFacturas["Importe"];
                    cl.ID = (int)drFacturas["Clientes.ID"];
                    cl.Nombre = (string)drFacturas["Clientes.Nombre"];
                    cl.Apellido = (string)drFacturas["Apellido"];
                    cl.EMail = (string)drFacturas["Email"];
                    cl.Password = (string)drFacturas["Password"];
                    cl.IdCiudad = (int)drFacturas["IDCiudad"];
                    cl.Habilitado = (bool)drFacturas["Habilitado"];
                    cl.Domicilio = (string)drFacturas["Domicilio"];
                    ci.ID = (int)drFacturas["Ciudades.ID"];
                    ci.Nombre = (string)drFacturas["Ciudades.Nombre"];

                    fa.Cliente = cl;
                    cl.Ciudad = ci;
                }
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("No se pudo obtener la factura especificada", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return fa;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete Facturas where ID=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("No se puede eliminar esta factura", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Factura factura)
        {

            if (factura.State == BusinessEntity.States.New)
            {
                this.Insert(factura);
            }
            else if (factura.State == BusinessEntity.States.Deleted)
            {
                this.Delete(factura.ID);
            }
            else if (factura.State == BusinessEntity.States.Modified)
            {
                this.Update(factura);
            }
            factura.State = BusinessEntity.States.Unmodified;
        }

        public void Update(Factura fa)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand("update Facturas set Facturas.IDCliente = @idCliente, " +
                    "Facturas.Fecha = @Fecha, Facturas.Detalle = @Detalle, Facturas.Importe = @Importe " +
                    "where Facturas.ID = @id", SqlConn);
                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = fa.ID;
                cmdUpdate.Parameters.Add("@idCliente", SqlDbType.Int).Value = fa.IdCliente;
                cmdUpdate.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = fa.Fecha;
                cmdUpdate.Parameters.Add("@Detalle", SqlDbType.VarChar, 200).Value = fa.Detalle;
                cmdUpdate.Parameters.Add("@Importe", SqlDbType.Decimal, 18).Value = fa.Importe;
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("No se pudo actualizar la factura", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Insert(Factura fa)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand("insert Facturas (IDCliente, Fecha, Detalle, Importe) " +
                "values (@idCliente, @Fecha, @Detalle, @Importe) select @@identity", SqlConn);
                cmdInsert.Parameters.Add("@idCliente", SqlDbType.Int).Value = fa.IdCliente;
                cmdInsert.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = fa.Fecha;
                cmdInsert.Parameters.Add("@Detalle", SqlDbType.VarChar, 200).Value = fa.Detalle;
                cmdInsert.Parameters.Add("@Importe", SqlDbType.Decimal, 18).Value = fa.Importe;
                fa.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("No se pudo crear nueva factura", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public bool Existe(int ID)
        {
            Factura test = GetOne(ID);
            return !(test.ID == 0);
        }
    }
}