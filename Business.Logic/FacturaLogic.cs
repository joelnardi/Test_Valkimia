using Business.Entities;
using Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logic
{
    public class FacturaLogic
    {
        public FacturaAdapter FacturaData { get; set; }

        public FacturaLogic()
        {
            FacturaData = new FacturaAdapter();
        }

        public Factura GetOne(int ID) { return FacturaData.GetOne(ID); }
        public List<Factura> GetAll() { return FacturaData.GetAll(); }
        public void Save(Factura factura) { FacturaData.Save(factura); }
        public void Delete(int ID) { FacturaData.Delete(ID); }

        public bool Existe(int ID)
        {
            return FacturaData.Existe(ID);
        }
    }
}
