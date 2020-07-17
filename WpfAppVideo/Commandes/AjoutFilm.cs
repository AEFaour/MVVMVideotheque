using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfAppVideo.ViewModel;

namespace WpfAppVideo.Commandes
{
    public class AjoutFilm : ICommand
    {
        private GestionVideo gestionVideo;

        public AjoutFilm(GestionVideo gestionVideo)
        {
            this.gestionVideo = gestionVideo;
        }

        public event EventHandler CanExecuteChanged;
        //{
        //    add { CommandManager.RequerySuggested += value; }
        //    remove { CommandManager.RequerySuggested -= value; }
        //}

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {

        }
    }
}
