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

        private void SeConnecter_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(txtNom.Text + " " + txtPassword.Password);

        }
    }
}
