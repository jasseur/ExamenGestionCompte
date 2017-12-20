using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenGestionCompte.Web.Models
{
    public class CompteEpargne : CompteModel
    {
        [Range(0.0, float.MaxValue)]
        public float Taux { get; set; }
    }
}
