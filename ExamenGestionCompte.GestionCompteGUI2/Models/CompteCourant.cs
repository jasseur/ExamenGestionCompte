using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ExamenGestionCompte.Web.Models
{
  public class CompteCourant : CompteModel
    {
        [Range(0.0, float.MaxValue)]
        public float DecouvertMax { get; set; }
    }
}
