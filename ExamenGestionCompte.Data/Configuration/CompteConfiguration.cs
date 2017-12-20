using ExamenGestionCompte.Domaine.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenGestionCompte.Data.Configuration
{
  public  class CompteConfiguration : EntityTypeConfiguration<Compte>
    {
        public CompteConfiguration()
        {

            /* changer nom_table : TabCompte
             ToTable("TabCompte");
            */

            /* *********** PrimaryKey *********
            HasKey(v => v.MatriculeKey);
            */

            /********* Validateur : ************
             Property(v => v.RIB).HasMaxLength(12);
             */


            /********** Relations :  *************
            //Configuration des Relations one to many :
             HasRequired(p => p.Personne).WithMany(v => v.Vehicules);
            
            //Relation portuse :
             HasMany(p => p.Users).WithMany(u => u.Products)
             .Map(aso => aso.ToTable("Achat").MapLeftKey("UserKey").MapRightKey("ProductKey"));

            
             HasMany(c => c.Credits).WithMany(c => c.Comptes).Map(cs =>
             {
                 cs.MapLeftKey("CompteRefId");
                 cs.MapRightKey("CreditRefId");
                 cs.ToTable("CompteCredit");
             });
             */


            /* ********** Heritage *********
            Relation d'Heritage : creer les table filles.
               Map<Moto>(m => m.ToTable("Moto"));
              Map<Voiture>(vo => vo.ToTable("Voiture"));
              */




            //Personnaliser le déscriminateur : Requires pour donner le nom de déscriminateur

            Map<Compte>(p => p.Requires("Type").HasValue("Compte"));
            Map<CompteEpargne>(p => p.Requires("Type").HasValue("CompteEpargne"));
            Map<CompteCourant>(b => b.Requires("Type").HasValue("CompteCourant"));

            // Relations Compte 
            HasMany(c => c.Credits).WithMany(c => c.Comptes);
            HasRequired(c => c.Agence).WithMany(a => a.Comptes);
            HasRequired(c => c.Client).WithMany(c => c.Comptes);



        }
   }
}
