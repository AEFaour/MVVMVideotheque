using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfAppVideo.Model;
using WpfAppVideo.ViewModel;

namespace WpfAppVideo.Commandes
{
    public class AjoutUtilisateur : ICommand
    {
        private GestionVideo gestionVideo;

        public AjoutUtilisateur(GestionVideo gestionVideo)
        {
            this.gestionVideo = gestionVideo;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {

            bool _ok = false;

            if (parameter != null)
            {
                Utilisateur u = (Utilisateur)parameter;

                _ok = (u.Nom.Length > 3) && (u.Logname.Length > 3);
                // && GestionVideo.CompteUnique(u.Logname);
                // à tester au moment de l'insertion
            }

            return _ok;
        }

        public void Execute(object parameter)
        {
            // Enregistrer dans la Base si verif = Ok
            Utilisateur u = (Utilisateur)parameter;
            u.Roles = new List<Role>();
            u.Roles.Add(gestionVideo.Role); // role qui est selectionné sur le combobox


            if (GestionVideo.CompteUnique(u.Logname))
            {
                GestionVideo.AjoutCompte(u);
            }
            else
            {
                gestionVideo.Info.Status = " Echec d'enrigistrer en base, verifiez le logname ";
            }
        }

    }
}
