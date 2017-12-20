using ExamenGestionCompte.Data.Configuration;
using ExamenGestionCompte.Data.CustomConvention;
using ExamenGestionCompte.Domaine.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenGestionCompte.Data
{
    public class CompteContext : DbContext
    {
        public DbSet<Credit> Credit { get; set; }
        public DbSet<Compte> Comptes { get; set; }
        public DbSet<Agence> Agences { get; set; }
        public DbSet<Client> Clients { get; set; }

        public CompteContext() : base("name = Examen")
        {
         
       }


    protected override void OnModelCreating(DbModelBuilder modelBuilder)
   {
            modelBuilder.Configurations.Add(new CompteConfiguration());
            modelBuilder.Conventions.Add(new ConventionKeyInt());

        }

}
}
