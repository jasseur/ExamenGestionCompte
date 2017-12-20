using ExamenGestionCompte.Domaine.Entities;
using ServicesPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenGestionCompte.Service
{
    public interface ICreditService : IService<Credit> 
    {
        float GetMaxCredit(Client client);
        int ClientNumbers(Agence agence);
       

    }
}
