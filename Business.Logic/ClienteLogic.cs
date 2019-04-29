using Business.Entities;
using Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logic
{
    public class ClienteLogic
    {
        public ClienteAdapter ClienteData { get; set; }

        public ClienteLogic()
        {
            ClienteData = new ClienteAdapter();
        }

        public Cliente GetOne(int ID) { return ClienteData.GetOne(ID); }
        public Cliente GetOne(string mail) { return ClienteData.GetOne(mail); }
        public List<Cliente> GetAll() { return ClienteData.GetAll(); }
        public void Save(Cliente cliente) { ClienteData.Save(cliente); }
        public void Delete(int ID) { ClienteData.Delete(ID); }

        public bool Existe(string email)
        {
            return ClienteData.Existe(email);
        }
    }
}
