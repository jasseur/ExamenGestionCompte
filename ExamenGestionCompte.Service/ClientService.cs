using ExamenGestionCompte.Domaine.Entities;
using ServicesPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;

namespace ExamenGestionCompte.Service
{
    public class ClientService : Service<Client>,IClientService
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork uofw = new UnitOfWork(dbf);

        public ClientService() : base(uofw)
        {
        }

       
    }
}
