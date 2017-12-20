using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenGestionCompte.Web.Models
{
  public  class CreditModel
    {
        public int CreditKey { get; set; }
        [Range(0.0, float.MaxValue)]
        public float SommeCredit { get; set; }
        [Required]
        public DateTime DateCredit { get; set; }
        [Range(0.0, float.MaxValue)]
        public float TauxInternet { get; set; }
        public Type TypeCredit { get; set; }

        public virtual ICollection<CompteModel> Comptes { get; set; }
    }

    public enum Type {
        CreditBail,
        CreditConsommation,
        CreditImmobilier,
        CreditLongTermes
    }
    
}
