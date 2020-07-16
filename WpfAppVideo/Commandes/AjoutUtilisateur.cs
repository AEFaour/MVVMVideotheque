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

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            Utilisateur u = (Utilisateur)parameter;
            bool _ok = false;
            _ok = (u.Nom.Length > 3) && (u.Logname.Length
                 > 3) && GestionVideo.CompteUnique(u.Logname);
            return _ok;
        }

        public void Execute(object parameter)
        {
            // Enregistrer dans la Base si verif = Ok
            Utilisateur u = (Utilisateur)parameter;
            u.Roles = new List<Role>();
            u.Roles.Add(gestionVideo.Role); // role qui est selectionné sur le combobox
            GestionVideo.AjoutCompte(u);
        }

    }
}
