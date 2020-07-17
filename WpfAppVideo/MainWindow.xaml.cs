using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfAppVideo.Views;

namespace WpfAppVideo
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Afficher la fenetre pour s'authentifier
            Authentifier();
        }

        private void Authentifier()
        {
            // Masquer la fenetre courante (this)
            // Afficher la fenetre d'authentifiaction
            this.Hide();
            Authentification1 authentification = new Authentification1();
            // Afficher authenitifaction en tant que une boîte de dialogue
            // qui retourne TRUE si l'authentification est réussi
            // authentification.Visibility = Visibility.Visible;
            if (authentification.ShowDialog() == true)
            {
                // Authentification réussie
                this.Show();
            }
            else
            {
                this.Close(); // fermer l'application
            }
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            txtAjFilm.Visibility = Visibility.Visible;
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {

            txtAjFilm.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            frame.NavigationService.Navigate(new PageFormulaireFilm());
        }
    }
}
