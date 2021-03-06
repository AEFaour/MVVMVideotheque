﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            //Se souscrire à l'évènement INotifypropertyChanged de la classe Info
            gestionVideo.Info.PropertyChanged += EnregistrementEffectue;
        }
        // La méthode va s'executer à cheque fois qu'on crée un compte

        private void EnregistrementEffectue(object sender, PropertyChangedEventArgs e)
        {
            //string s = string.Empty;
            Info info = (Info)sender;
            if (info.Status.Equals(AccesHelper.Messages.EnregistrementCompte))
            {
                MessageBox.Show("Enregistrement effectue, retour à la fênetre d'authentification");
                this.DialogResult = true;
                //this.Close();
            }
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

                // Récupérer le role selectionné
                Role roleUtilisateur = (Role)cbbRole.SelectedItem;

                //roleUtilisateur.Utilisateurs = new List<Utilisateur>();

                //Initialiser la liste des roles pour le nouveau utilisateur

                utilisateur.Roles = new List<Role>();

                utilisateur.Roles.Add(roleUtilisateur);
                //Exemple si le role est attribué en fonction de la présence du mot Modt admin dans le login
                //if (utilisateur.Nom.Contains("Admin"))
                //{
                //    // Récupérer le role Admin depuis la base
                //    using (EF_TP_MVVM dtc = new EF_TP_MVVM())
                //    {
                //        //Role _r = dtc.roles.Where(x => x.Nom.Contains("Admin")).SingleOrDefault();
                //        Role _r = dtc.roles.SingleOrDefault(x => x.Nom.Contains("Admin"));
                //        utilisateur.Roles.Add(_r);

                //    }

                //}
                int i = GestionVideo.AjoutCompte(utilisateur);
                if (i > 0)
                {
                    this.DialogResult = true;
                }
                else
                {
                    MessageBox.Show("Erreur sur insertion en base");
                    this.DialogResult = false;

                }
            }
            else
            {
                MessageBox.Show("Mot de passe non identiques");
            }

        }

        private void Passwd_Click(object sender, RoutedEventArgs e)
        {
            // Binding sur Password ...
            if (txtPass2.Password == txtPass1.Password)
            {
                gestionVideo.User.Passwd = AccesHelper.EncryptHelper.Base64Encode(txtPass2.Password);
            }
            // tant qu'ils ne sont pas égaux user.passwd vide

        }
    }
}
