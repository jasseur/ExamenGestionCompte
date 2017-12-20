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
    public class CompteCourantService : Service<CompteCourant>, ICompteCourantService
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork uofw = new UnitOfWork(dbf);
        public CompteCourantService() : base(uofw)
        {
        }


        
        public IEnumerable<CompteCourant> GetComptesSorted()
        {
            return GetMany(c => 
            c.Credits.Any(cr => cr.SommeCredit> 10000) )
                .OrderBy(c => c.RIB);
        }
        public bool AbleToRetrait(Client client)
        {
            return Get(c => c.Client == client).DecouvertMax < client.Salaire;
        }

    }
}
