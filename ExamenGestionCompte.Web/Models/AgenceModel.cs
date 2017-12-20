using ExamenGestionCompte.Domaine.ComplexType;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenGestionCompte.Web.Models
{
   public class AgenceModel
    {
 
        public int AgenceKey { get; set; }
        public String NomAgence { get; set; }
        public Adress AdressAgence { get; set; }
        [Range(0.0, int.MaxValue)]
        public int NombreEmploye { get; set; }

        public virtual ICollection<CompteModel> Comptes { get; set; }
    }
}
