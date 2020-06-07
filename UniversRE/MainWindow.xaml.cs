using MyLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private UCAccueil TypeUC { get; set; } = new UCAccueil();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = Man;
            ContentControl.Content = new UCAccueil();
        }

        /// <summary>
        /// Intéractivité pour la recherche
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Recherche_TextChanged(object sender, TextChangedEventArgs e)
        {
            //RechercheList = Man.RechercherElementParNom(Recherche.Text);
            RechercheList = Man.RechercherElementParNomLINQ(Recherche.Text).ToList();
            if (RechercheList.Count != 0)
                Man.ElementSelectionné = RechercheList[0];
        }

        private void MenuItem_Accueil_Click(object sender, RoutedEventArgs e)
        {
            Man.ListActuelle = Man.MesElements;
            UniversRE.UCAccueil uca = new UCAccueil();
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
            if(ContentControl.Content is UCHistoire) 
                Man.ElementSelectionné = (Element)Man.EvenementSelectionné;
            ContentControl.Content = new UCModification();
        }

        private void Supprimer_click(object sender, RoutedEventArgs e)
        {
            if (ContentControl.Content is UCHistoire)
                Man.SupprimerEvenementAHistoire(Man.EvenementSelectionné);
            Man.SupprimerElement(Man.ElementSelectionné);
            AffichageMessage.AffichageMessageInfo(ref BlockMessage, Brushes.OrangeRed, "Suppression effectué avec succès");
        }

        private void MenuItem_Favoris_Click(object sender, RoutedEventArgs e)
        {
            Man.ListActuelle = Man.MesFavorisLINQ;
            ContentControl.Content = new UCAccueil();
        }

        private void MenuItem_Importer_Click(object sender, RoutedEventArgs e)
        {
            Man.ChargeLesDonnées();
            AffichageMessage.AffichageMessageInfo(ref BlockMessage, Brushes.Green, "Importation effectuée");
        }

        private void MenuItem_Sauvegarder_Click(object sender, RoutedEventArgs e)
        {
            Man.SauvegarderLesDonnées();
            AffichageMessage.AffichageMessageInfo(ref BlockMessage, Brushes.Green, "Sauvegarde effectuée");
        }
    }
}
