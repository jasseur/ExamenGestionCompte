using ExamenGestionCompte.Domaine.ComplexType;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenGestionCompte.Web.Models
{
   public class ClientModel
    {
        [Key]

        [StringLength(8, MinimumLength = 8, ErrorMessage = "CIN legth has to be 8")]
        [Required]
        public string CIN { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        [Required]
        public DateTime DateNaissance { get; set; }
        public string Rue { get; set; }
        public string ZipCode { get; set; }
        [Range(0.0, float.MaxValue)]
        public float Salaire { get; set; }

        public virtual  ICollection<CompteModel> Comptes { get; set; }
    }
}
