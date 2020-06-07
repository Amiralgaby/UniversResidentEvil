using MyLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UniversRE
{
    /// <summary>
    /// Logique d'interaction pour UCAccueil.xaml
    /// </summary>
    public partial class UCAccueil : UserControl
    {
        public Manager Man => (Application.Current as App).LeManager;
        public UCAccueil()
        {
            InitializeComponent();
            SourceDeMonImage();
        }

        /// <summary>
        /// Executez lors d'un clic sur l'icone favoris afin de basculer l'attribut favoris (True/False)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MonImage_MouseUp(object sender, MouseButtonEventArgs e)
        {
           Man.BasculerFavoris(Man.ElementSelectionné);
           SourceDeMonImage();
        }

        /// <summary>
        /// Donne la source à avoir pour l'image favoris
        /// </summary>
        private void SourceDeMonImage()
        {
            if (ReferenceEquals(Man.ElementSelectionné, null))
                return;
            if (Man.ElementSelectionné.Favoris != false)
                MonImage.Source = new BitmapImage(new Uri("img/iconeFullstar.png", UriKind.Relative));
            else
                MonImage.Source = new BitmapImage(new Uri("img/iconeEmptystar.png", UriKind.Relative));
        }
    }
}
