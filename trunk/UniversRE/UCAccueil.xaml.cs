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
            
            if (Man.ElementSelectionné.Favoris != false)
                monImage.Source = new BitmapImage(new Uri("img/iconeFullstar.png", UriKind.Relative));
            else
                monImage.Source = new BitmapImage(new Uri("img/iconeEmptystar.png", UriKind.Relative));
        }
    }
}
