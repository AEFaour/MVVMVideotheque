using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
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
            return true;
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
