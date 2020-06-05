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
            DataContext = Man.ElementSelectionné;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool isChecked = BoxFavoris.IsChecked ?? false;
            try
            {
                Man.ElementSelectionné.ModifierAttribut(BlockNom.Text, BlockDescription.Text, isChecked);

                AfficheBlockMessageInfo(Brushes.Green, "La modification à été effectué avec succès");
            }
            catch(Exception excep)
            {
                AfficheBlockMessageInfo(Brushes.Red, excep.Message);
            }
        }
        private void AfficheBlockMessageInfo(Brush brushes, string message)
        {
            BlockMessageInfo.Text = message;
            BlockMessageInfo.Background = brushes;
            BlockMessageInfo.Visibility = Visibility.Visible;
        }
    }
}
