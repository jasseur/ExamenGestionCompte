using ExamenGestionCompte.Domaine.Entities;
using ServicesPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenGestionCompte.Service
{
    public interface ICompteCourantService : IService<CompteCourant> 
    {
        IEnumerable<CompteCourant> GetComptesSorted();
        Boolean AbleToRetrait(Client client);

    }
}
