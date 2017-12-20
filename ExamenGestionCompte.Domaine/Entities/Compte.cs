using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExamenGestionCompte.Domaine.Entities
{
    public class Compte
    {
        [Key]
        [StringLength(12)]
        public string RIB { get; set; }
        [Required]
        public DateTime DateOuverture { get; set; }
        [Range(0.0,float.MaxValue)]
        public float Solde { get; set; }

        public virtual Agence Agence { get; set; }
        public virtual  Client Client { get; set; }

        public virtual ICollection<Credit> Credits { get; set; }
    }
}