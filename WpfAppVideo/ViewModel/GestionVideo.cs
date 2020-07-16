using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppVideo.Model;

namespace WpfAppVideo.ViewModel
{
    public class GestionVideo : IDisposable
    {
        private static EF_TP_MVVM dbContext = new EF_TP_MVVM();

        private static ObservableCollection<Role> roles;
        public static ObservableCollection<Role> Roles
        {
            get { return roles; }
            set { roles = value; }
        }


        public GestionVideo()
        {
            if (roles == null)
                roles = new ObservableCollection<Role>(dbContext.roles.ToList());

        }
        public static int LoggToBase(string log)
        {
            dbContext.traces.Add(new Trace()
            {
                Info = log
            }
            );
            // return < 0--> NOK
            return dbContext.SaveChanges();
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }

        public static int AjoutCompte(Utilisateur utilisateur)
        {
            dbContext.utilisateurs.Add(utilisateur);

            return dbContext.SaveChanges();
        }
    }
}
