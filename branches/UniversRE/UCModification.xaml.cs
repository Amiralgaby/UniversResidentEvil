using MyLib;
using System;
using System.Collections.Generic;
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
    /// Logique d'interaction pour UCModification.xaml
    /// </summary>
    public partial class UCModification : UserControl
    {
        public Manager Man => (Application.Current as App).LeManager;
        public UCModification()
        {
            InitializeComponent();
            DataContext = Man;
        }
    }
}
