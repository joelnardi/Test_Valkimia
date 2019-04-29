using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Factura : BusinessEntity
    {
        private string _Detalle;
        public string Detalle
        {
            get { return _Detalle; }
            set { _Detalle = value; }
        }

        private DateTime _Fecha;
        public DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        private double _Importe;
        public double Importe
        {
            get { return _Importe; }
            set { _Importe = value; }
        }

        private int _idCliente;
        public int IdCliente
        {
            get { return _idCliente; }
            set { _idCliente = value; }
        }

        private Cliente cliente;
        public Cliente Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }
    }
}
