using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExamenGestionCompte.Web.Startup))]
namespace ExamenGestionCompte.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
