using ExamenGestionCompte.Domaine.Entities;
using ExamenGestionCompte.Service;
using ExamenGestionCompte.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamenGestionCompte.GestionCompteGUI2.Controllers
{
    public class CompteController : Controller
    {
        CompteCourantService ccs = new CompteCourantService();
        CreditService cs = new CreditService();
        AgenceService ass = new AgenceService();

        // GET: Compte
        public ActionResult Index()
        {
            
            return View(ccs.GetComptesSorted());
        }

        // GET: Compte/Details/5
        public ActionResult Details()
        {
            Agence a1 = ass.GetById(2);
            
            
            ViewBag.nbr= cs.ClientNumbers(a1);
            return View();
        }

        // GET: Compte/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Compte/Create
        [HttpPost]
        public ActionResult Create(CompteModel compteModel)
        {
            Agence a = new Agence();
            AgenceService ass = new AgenceService();
           
            ass.Add(a);
            ass.Commit();
          
            String type = Request.Form["typeSelect"].ToString();

            if (type == "Compte Courant") {
                Domaine.Entities.CompteCourant cc = new Domaine.Entities.CompteCourant();
                cc.RIB = "123456789101";
                cc.DateOuverture = DateTime.Now;
                cc.Solde = compteModel.Solde;
                cc.DecouvertMax = 0f;
             
                ccs.Add(cc);
                ccs.Commit();
                
            }

            return View();
            
        }

        // GET: Compte/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Compte/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Compte/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Compte/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
