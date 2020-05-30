using MyLib;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UniversRE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Manager Man => (Application.Current as App).LeManager;
        List<Element> RechercheList = new List<Element>();
        public MainWindow()
        {
            Man.AjouterEvenementAHistoire(new Evenement("Test de l'histoire", "test de l'autre","nulle part"));
            DataContext = Man;
            InitializeComponent();
        }

        private void Recherche_TextChanged(object sender, TextChangedEventArgs e)
        {
            RechercheList = Man.RechercherElementParNom(Recherche.Text);

            if (RechercheList.Count != 0)
                Man.ElementSelectionné = RechercheList[0];
        }

        private void MenuItem_Accueil_Click(object sender, RoutedEventArgs e)
        {
            ContentControl.Content = new UCAccueil();
        }
        private void Histoire_click(object sender, RoutedEventArgs e)
        {
            ContentControl.Content = new UCHistoire();
        }
        private void Ajouter_click(object sender, RoutedEventArgs e)
        {
            ContentControl.Content = new UCajout();
        }

        private void Modifier_click(object sender, RoutedEventArgs e)
        {
            ContentControl.Content = new UCModification();
        }

        private void Supprimer_click(object sender, RoutedEventArgs e)
        {
            Man.SupprimerElement(Man.ElementSelectionné);
        }
    }
}
