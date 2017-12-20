using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenGestionCompte.Data.CustomConvention
{
    class ConventionKeyInt : Convention 
    {
        public ConventionKeyInt()
        {
         // tous int qe qui se termine par Key --> sont ds cle primaire.
            this.Properties<int>().Where(c => c.Name.EndsWith("Key")).Configure(c => c.IsKey());


        // Convert datetime to datetime2
            this.Properties<DateTime>().Configure(d => d.HasColumnType("DateTime2"));
        }
      
    }
}
