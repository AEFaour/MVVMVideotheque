using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
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
using WpfAppVideo.ViewModel;

namespace WpfAppVideo.Views
{
    /// <summary>
    /// Logique d'interaction pour PageFormulaireFilm.xaml
    /// </summary>
    public partial class PageFormulaireFilm : Page
    {
        private GestionVideo gestionVideo = new GestionVideo();
        public PageFormulaireFilm()
        {
            InitializeComponent();
            InitCombobox();

            this.DataContext = gestionVideo;
        }

        private void InitCombobox()
        {
            string _rep = ConfigurationManager.AppSettings["repImage"];
            var _listFilmFromImage = Directory.GetFiles(_rep, "*.png");
            cbbImage.ItemsSource = _listFilmFromImage;
        }

        private void cbbImage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            imgFilm.Source = new BitmapImage(new Uri(cbbImage.SelectedValue.ToString()));
        }
    }
}
