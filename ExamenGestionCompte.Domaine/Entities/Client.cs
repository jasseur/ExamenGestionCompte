using ExamenGestionCompte.Domaine.ComplexType;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenGestionCompte.Domaine.Entities
{
   public class Client
    {
        [Key]
        [StringLength(8)]
        public string CIN { get; set; }
        public FullName NomComplet { get; set; }
        [Required]
        public DateTime DateNaissance { get; set; }
        public Adress Address { get; set; }
        [Range(0.0, float.MaxValue)]
        public float Salaire { get; set; }

        public Client()
        {
            NomComplet = new FullName();
            Address = new Adress();

        }

        public virtual  ICollection<Compte> Comptes { get; set; }
    }
}
