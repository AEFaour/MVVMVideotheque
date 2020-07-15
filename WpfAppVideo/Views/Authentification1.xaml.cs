using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using WpfAppVideo.AccesHelper;

namespace WpfAppVideo.Views
{
    /// <summary>
    /// Logique d'interaction pour Authentification1.xaml
    /// </summary>
    public partial class Authentification1 : Window
    {
        public Authentification1()
        {
            InitializeComponent();
        }

        static int i = 3;

        private void SeConnecter_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(txtNom.Text + " " + txtPassword.Password);
            // Appeler notre méthode qui vérifiera les Crédentials

            // Verif();
            //   Verifier(); -- pout tester le showdialog
            // Verfier si l'utlisateur a un compte windows correcte (Local ou AD)

            bool ok = WindowsAccesHelper.IsValidateCredentials(txtNom.Text, txtPassword.Password, "");
            MessageBox.Show("Authentification " + ok);
            if (ok == false) i--;
            else
                this.DialogResult = true;
            if (i == 0) this.DialogResult = false;
            // Logger action de l'utlisateur
            // Les infos à logger sous forme crypter

            // Première Approche /
            // 1es logger les actions utilisateurs dans le journal d'évenement windows

            // Cas -1 Window

            var _log = new EventLog("Application");
            string message = "Echec de connexion" + txtNom + " "
                + " A partir de la session " + Environment.UserName + " " + DateTime.Now;
            string messageCrypte = AccesHelper.EncryptHelper.Base64Encode(message);
            //Enregistrer le message dans le journal des évenements Windows
            _log.Source = "Application";
            // On écrit l'info dans le journal avec un ID qui permet de grouper les message
            _log.WriteEntry(messageCrypte, EventLogEntryType.Information, 1588);
            MessageBox.Show("Message claire :" + message);
            MessageBox.Show("Message claire :" + messageCrypte);
            //Cas 2- log en base
            // Logger en base 
            // tester user en base
        }

        private void Verifier()
        {
            bool ok = false; // si ok : authentification réussi
            // L'intéret : utiliser la seconde fenetre comme un dialogue
            if (ok)
            {
                this.DialogResult = true;
            }
            else
            {
                this.DialogResult = false;
            }
        }
    }
}
