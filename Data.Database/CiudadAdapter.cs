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
    public class CiudadAdapter : Adapter
    {
        public List<Ciudad> GetAll()
        {
            List<Ciudad> ciudades = new List<Ciudad>();

            try
            {
                this.OpenConnection();
                SqlCommand cmdCiudades = new SqlCommand("select * from Ciudades ", SqlConn);
                SqlDataReader drCiudades = cmdCiudades.ExecuteReader();
                while (drCiudades.Read())
                {
                    Ciudad ci = new Ciudad();
                    ci.ID = (int)drCiudades["IDCiudad"];
                    ci.Nombre = (string)drCiudades["NombreCiudad"];

                    ciudades.Add(ci);
                }
                drCiudades.Close();
            }
            catch (Exception Exc)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar las ciudades", Exc);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return ciudades;
        }

        public Ciudad GetOne(int ID)
        {
            Ciudad ci = new Ciudad();
            try
            {
                this.OpenConnection();
                SqlCommand cmdCiudades = new SqlCommand("select * from Ciudades " +
                    "where Ciudades.IDCiudad = @id ", SqlConn);
                cmdCiudades.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drCiudades = cmdCiudades.ExecuteReader();

                if (drCiudades.Read())
                {
                    ci.ID = (int)drCiudades["IDCiudad"];
                    ci.Nombre = (string)drCiudades["NombreCiudad"];
                }
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("No se pudo obtener la ciudad especificada", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return ci;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete Ciudades where IDCiudad=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("No se puede eliminar esta ciudad", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Ciudad ciudad)
        {

            if (ciudad.State == BusinessEntity.States.New)
            {
                this.Insert(ciudad);
            }
            else if (ciudad.State == BusinessEntity.States.Deleted)
            {
                this.Delete(ciudad.ID);
            }
            else if (ciudad.State == BusinessEntity.States.Modified)
            {
                this.Update(ciudad);
            }
            ciudad.State = BusinessEntity.States.Unmodified;
        }

        public void Update(Ciudad ci)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand("update Ciudades set Ciudades.NombreCiudad = @nombre " +
                    "where Ciudades.IDCiudad = @id", SqlConn);
                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = ci.ID;
                cmdUpdate.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = ci.Nombre;
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("No se pudo actualizar la ciudad", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Insert(Ciudad ci)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand("insert Ciudades (NombreCiudad) " +
                "values (@nombre) select @@identity", SqlConn);
                cmdInsert.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = ci.Nombre;
                ci.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("No se pudo crear nueva ciudad", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public bool Existe(int ID)
        {
            Ciudad test = GetOne(ID);
            return !(test.ID == 0);
        }
    }
}