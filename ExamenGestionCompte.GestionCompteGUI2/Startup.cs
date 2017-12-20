using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExamenGestionCompte.GestionCompteGUI2.Startup))]
namespace ExamenGestionCompte.GestionCompteGUI2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
