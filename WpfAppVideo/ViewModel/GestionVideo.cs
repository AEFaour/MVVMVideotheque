using System;
using System.Collections.ObjectModel;
using System.Linq;
using WpfAppVideo.Commandes;
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
        //private static ObservableCollection<Utilisateur> utilisateurs;

        //public static ObservableCollection<Utilisateur> Utilisateurs

        //{
        //    get { return utilisateurs; }
        //    set { utilisateurs = value; }
        //}

        // Pour que le commandeParameter du XAML puisse se binder sur User
        // il faut créer la propriété avec le getter et le setter
        private Utilisateur user;
        public Utilisateur User
        {
            get { return user; }
            set { user = value; }
        }

        private Role role;
        public Role Role
        {
            get { return role; }
            set { role = value; }
        }

        private Info info;
        public Info Info
        {
            get { return info; }
            set { info = value; }
        }

        public AjoutUtilisateur AjoutUtilisateur { get; set; }

        public GestionVideo()
        {
            if (roles == null)
                roles = new ObservableCollection<Role>(dbContext.roles.ToList());
            //if (utilisateurs == null)
            //    utilisateurs = new ObservableCollection<Utilisateur>(dbContext.utilisateurs.ToList());
            AjoutUtilisateur = new AjoutUtilisateur(this); // Passer la class au constructeur pour que 
                                                           // la class AjoutUtilisateur accede aux membres du ViewModel
                                                           // Injection de dépendance
                                                           // Instancier le paramètre de la commande
            User = new Utilisateur() { Logname = string.Empty, Nom = string.Empty };
            Role = new Role();
            Info = new Info() { Status = string.Empty };
        }

        public static bool CompteUnique(string logname)
        {
            // Utilisateur u = dbContext.utilisateurs.SingleOrDefault(x => x.Logname == logname);
            var u = dbContext.utilisateurs.Where(x => x.Logname == logname);
            return (u == null);
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

        public static Utilisateur RechercheUserByLogin(string login, string passCrypt)
        {
            Utilisateur utilisateur = dbContext.utilisateurs.SingleOrDefault(
                 x => x.Logname.ToLower() == login.ToLower()
                 &&
                 x.Passwd == passCrypt
                 );

            // if (utilisateur == null) return false;
            // si on veut retourner l'utilisateur

            return utilisateur;
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
