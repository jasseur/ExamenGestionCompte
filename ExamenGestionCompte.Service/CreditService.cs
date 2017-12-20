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
  public  class CreditService : Service<Credit>, ICreditService
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork uofw = new UnitOfWork(dbf);
        public CreditService() : base(uofw)
        {
        }

    

        public float GetMaxCredit(Client client)
        {
            int ClientAge = (DateTime.Now.Year - client.DateNaissance.Year)*12
                            +(DateTime.Now.Month - client.DateNaissance.Month) ;
            if(ClientAge/12 < 60 )
            {
                int Monthes = 60 * 12 - ClientAge;

               return client.Salaire * 0.4f * Monthes;
            }
            return 0f;
        }

        public int ClientNumbers(Agence agence)
        {
            return GetMany(c => c.Comptes
            .Any(cp => cp.Agence.Equals(agence)))
            .Count();
        }

       
    }
}
