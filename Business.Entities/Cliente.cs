using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Cliente : BusinessEntity
    {
        private string _EMail;
        public string EMail
        {
            get { return _EMail; }
            set { _EMail = value; }
        }

        private string _Password;
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        private string _Nombre;
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        private string _Apellido;
        public string Apellido
        {
            get { return _Apellido; }
            set { _Apellido = value; }
        }

        private bool _Habilitado;
        public bool Habilitado
        {
            get { return _Habilitado; }
            set { _Habilitado = value; }
        }

        private string _Domicilio;
        public string Domicilio
        {
            get { return _Domicilio; }
            set { _Domicilio = value; }
        }

        private int _idCiudad;
        public int IdCiudad
        {
            get { return _idCiudad; }
            set { _idCiudad = value; }
        }

        private Ciudad ciudad;
        public Ciudad Ciudad
        {
            get { return ciudad; }
            set { ciudad = value; }
        }
    }
}
