using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExamenGestionCompte.Web.Models
{
    public class CompteModel
    {
        [Key]
        [StringLength(12)]
        public string RIB { get; set; }
        [Required]
        public DateTime DateOuverture { get; set; }
        [Range(0.0,float.MaxValue)]
        public float Solde { get; set; }

        public virtual AgenceModel Agence { get; set; }
        public virtual ClientModel Client { get; set; }

        public virtual ICollection<CreditModel> Credits { get; set; }
    }
}