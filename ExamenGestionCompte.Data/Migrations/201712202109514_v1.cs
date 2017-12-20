namespace ExamenGestionCompte.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agences",
                c => new
                    {
                        AgenceKey = c.Int(nullable: false, identity: true),
                        NomAgence = c.String(),
                        AdressAgence_Rue = c.String(),
                        AdressAgence_ZipCode = c.String(),
                        NombreEmploye = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AgenceKey);
            
            CreateTable(
                "dbo.Comptes",
                c => new
                    {
                        RIB = c.String(nullable: false, maxLength: 12),
                        DateOuverture = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Solde = c.Single(nullable: false),
                        DecouvertMax = c.Single(),
                        Taux = c.Single(),
                        Agence_AgenceKey = c.Int(nullable: false),
                        Client_CIN = c.String(nullable: false, maxLength: 8),
                        Type = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.RIB)
                .ForeignKey("dbo.Agences", t => t.Agence_AgenceKey, cascadeDelete: true)
                .ForeignKey("dbo.Clients", t => t.Client_CIN, cascadeDelete: true)
                .Index(t => t.Agence_AgenceKey)
                .Index(t => t.Client_CIN);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        CIN = c.String(nullable: false, maxLength: 8),
                        NomComplet_Nom = c.String(),
                        NomComplet_Prenom = c.String(),
                        DateNaissance = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Address_Rue = c.String(),
                        Address_ZipCode = c.String(),
                        Salaire = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.CIN);
            
            CreateTable(
                "dbo.Credits",
                c => new
                    {
                        CreditKey = c.Int(nullable: false, identity: true),
                        SommeCredit = c.Single(nullable: false),
                        DateCredit = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        TauxInternet = c.Single(nullable: false),
                        TypeCredit = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CreditKey);
            
            CreateTable(
                "dbo.CompteCredits",
                c => new
                    {
                        Compte_RIB = c.String(nullable: false, maxLength: 12),
                        Credit_CreditKey = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Compte_RIB, t.Credit_CreditKey })
                .ForeignKey("dbo.Comptes", t => t.Compte_RIB, cascadeDelete: true)
                .ForeignKey("dbo.Credits", t => t.Credit_CreditKey, cascadeDelete: true)
                .Index(t => t.Compte_RIB)
                .Index(t => t.Credit_CreditKey);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CompteCredits", "Credit_CreditKey", "dbo.Credits");
            DropForeignKey("dbo.CompteCredits", "Compte_RIB", "dbo.Comptes");
            DropForeignKey("dbo.Comptes", "Client_CIN", "dbo.Clients");
            DropForeignKey("dbo.Comptes", "Agence_AgenceKey", "dbo.Agences");
            DropIndex("dbo.CompteCredits", new[] { "Credit_CreditKey" });
            DropIndex("dbo.CompteCredits", new[] { "Compte_RIB" });
            DropIndex("dbo.Comptes", new[] { "Client_CIN" });
            DropIndex("dbo.Comptes", new[] { "Agence_AgenceKey" });
            DropTable("dbo.CompteCredits");
            DropTable("dbo.Credits");
            DropTable("dbo.Clients");
            DropTable("dbo.Comptes");
            DropTable("dbo.Agences");
        }
    }
}
