using Business.Entities;
using Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logic
{
    class CiudadLogic
    {
        public CiudadAdapter CiudadData { get; set; }

        public CiudadLogic()
        {
            CiudadData = new CiudadAdapter();
        }

        public Ciudad GetOne(int ID) { return CiudadData.GetOne(ID); }
        public List<Ciudad> GetAll() { return CiudadData.GetAll(); }
        public void Save(Ciudad ciudad) { CiudadData.Save(ciudad); }
        public void Delete(int ID) { CiudadData.Delete(ID); }

        public bool Existe(int ID)
        {
            return CiudadData.Existe(ID);
        }
    }
}
