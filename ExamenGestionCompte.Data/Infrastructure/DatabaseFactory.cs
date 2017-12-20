using ExamenGestionCompte.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Data.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private CompteContext dataContext;
        public CompteContext DataContext { get { return dataContext; } }
        public DatabaseFactory()
        {
            dataContext = new CompteContext();
        }
        protected override void DisposeCore()
        {
            if (DataContext != null)
                DataContext.Dispose();
        }
    }


}
