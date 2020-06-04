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
        //public string IsFavoris => (Application.Current as App).LeManager.IsMyElementSelectionnéFavoris;
        public UCAccueil()
        {
            InitializeComponent();
            SourceDeMonImage();
        }

        private void MonImage_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Man.ElementSelectionné.BasculerFavoris();
            SourceDeMonImage();
        }

        private void SourceDeMonImage()
        {
            if (Man.ElementSelectionné.Favoris != false)
                MonImage.Source = new BitmapImage(new Uri("img/iconeFullstar.png", UriKind.Relative));
            else
                MonImage.Source = new BitmapImage(new Uri("img/iconeEmptystar.png", UriKind.Relative));
        }
    }
}
