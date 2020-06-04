using MyLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Security.Cryptography.X509Certificates;
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
    /// Logique d'interaction pour UCHistoire.xaml
    /// </summary>
    public partial class UCHistoire : UserControl
    {
        public Manager Man => (Application.Current as App).LeManager;
        public ReadOnlyCollection<Evenement> CollectionEvenement => (Application.Current as App).LeManager.Histoire.AsReadOnly();
        public int HistoireCount => 100/((Application.Current as App).LeManager.Histoire.Count-1);
        public UCHistoire()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
