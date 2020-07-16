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
using System.Windows.Shapes;
using WpfAppVideo.Model;
using WpfAppVideo.ViewModel;

namespace WpfAppVideo.Views
{
    /// <summary>
    /// Logique d'interaction pour ViewUtilisateur.xaml
    /// </summary>
    public partial class ViewUtilisateur : Window
    {
        GestionVideo gestionVideo = new GestionVideo();
        public ViewUtilisateur()
        {
            InitializeComponent();
            this.DataContext = gestionVideo;
        }


        private void AjouterUtilisateur_Click(object sender, RoutedEventArgs e)
        {
            //this.DialogResult = true; // simuler le cas ou l'utilisateur s'est enregistré en base

            // Verification --> Pas même login, nom > 3 caractères, Mot de Pass > 5 caractères
            if (txtPass1.Password.Equals(txtPass2.Password))
            {
                Utilisateur utilisateur = new Utilisateur();
                utilisateur.Logname = txtLogname.Text.Trim().ToLower();
                utilisateur.Nom = txtNom.Text.Trim().ToLower();
                utilisateur.Passwd = AccesHelper.EncryptHelper.Base64Encode(txtPass1.Password);
                int i = GestionVideo.AjoutCompte(utilisateur);
                if (i > 0)
                {
                    this.DialogResult = true;
                }
                else
                {

                    this.DialogResult = false;
                }
            }
            else
            {
                MessageBox.Show("Mot de passe non identiques");
            }

        }
    }
}
