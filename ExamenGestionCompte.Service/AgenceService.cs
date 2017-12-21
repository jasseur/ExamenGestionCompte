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
    public class AgenceService : Service<Agence>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork uofw = new UnitOfWork(dbf);

        public AgenceService() : base(uofw)
        {
        }

       
    }
}
