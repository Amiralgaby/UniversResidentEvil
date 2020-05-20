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
    /// Logique d'interaction pour MyUC2.xaml
    /// </summary>
    public partial class Details : UserControl
    {
        public Details()
        {
            Element Element = new Element("jaaj", "desceription");
            InitializeComponent();
        }
    }
}
