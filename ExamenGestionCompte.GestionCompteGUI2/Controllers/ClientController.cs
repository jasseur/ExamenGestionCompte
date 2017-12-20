using ExamenGestionCompte.Domaine.Entities;
using ExamenGestionCompte.Service;
using ExamenGestionCompte.Web.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamenGestionCompte.GestionCompteGUI2.Controllers
{
    public class ClientController : Controller
    {
        List<Client> Clients;
        public ClientController() : base()
        {
            Clients = new List<Client>();
           
        }

        IClientService us = new ClientService();

        //My patial vue
        public List<ClientModel> ListClients()
        {

            List<ClientModel> ClientModels=new List<ClientModel>();
            ((List<Client>)Session["ListClients"])
                .ForEach(delegate (Client client)
                {
                    ClientModel clientModel = new ClientModel();
                    clientModel.CIN = client.CIN;
                    clientModel.Salaire = client.Salaire;
                    clientModel.DateNaissance = client.DateNaissance;
                    clientModel.Nom = client.NomComplet.Nom;
                    clientModel.Prenom = client.NomComplet.Prenom;
                    clientModel.Rue = client.Address.Rue;
                    clientModel.ZipCode = client.Address.ZipCode;

                    ClientModels.Add(clientModel);

                });
            return  ClientModels;
        }


   
        // GET: Client/Create
        public ActionResult CreateClient()
        {

            return View();
        }

        // POST: Client/Create
        [HttpPost]
        public ActionResult CreateClient(ClientModel clientModel)
        {
          
                Client client = new Client();
                client.CIN = clientModel.CIN;
                client.Salaire = clientModel.Salaire;
                client.Address.Rue = clientModel.Rue;
                client.Address.ZipCode = clientModel.ZipCode;
                client.NomComplet.Nom = clientModel.Nom;
                client.NomComplet.Prenom = clientModel.Prenom;

                us.Add(client);
                us.Commit();

            //add to Clients in session
            if(Session["ListClients"]== null)
                Session["ListClients"]= Clients;

            Clients = (List<Client>)Session["ListClients"];
            Clients.Add(client);
            Session["ListClients"] = Clients;

            return View();
         
        }
        // GET: Client
        public ActionResult Index()
        {
            List<ClientModel> ClientModels = new List<ClientModel>();
            ((List<Client>)Session["ListClients"])
                .ForEach(delegate (Client client)
                {
                    ClientModel clientModel = new ClientModel();
                    clientModel.CIN = client.CIN;
                    clientModel.Salaire = client.Salaire;
                    clientModel.DateNaissance = client.DateNaissance;
                    clientModel.Nom = client.NomComplet.Nom;
                    clientModel.Prenom = client.NomComplet.Prenom;
                    clientModel.Rue = client.Address.Rue;
                    clientModel.ZipCode = client.Address.ZipCode;

                    ClientModels.Add(clientModel);

                });
            return  View(ClientModels);
        }

    }
}
