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
        public ImageSource Source => new BitmapImage(new Uri((Application.Current as App).LeManager.ElementSelectIsFavoris(), UriKind.Relative));
        public UCAccueil()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Executez lors d'un clic sur l'icone favoris afin de basculer l'attribut favoris (True/False)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MonImage_MouseUp(object sender, MouseButtonEventArgs e)
        {
           Man.BasculerFavoris(Man.ElementSelectionné);
           MonImage.Source = Source;
        }
    }
}
