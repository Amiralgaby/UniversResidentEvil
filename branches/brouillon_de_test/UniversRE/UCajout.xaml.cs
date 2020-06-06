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
    /// Logique d'interaction pour UCajout.xaml
    /// </summary>
    public partial class UCajout : UserControl
    {
        public Manager Man => (Application.Current as App).LeManager;
        public UCajout()
        {
            InitializeComponent();
            DataContext = Man;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Element ElementAajouter = GetElementAajouter();
            if (ElementAajouter is null)
                return;
            if (BoxFavoris.IsChecked ?? false)
                ElementAajouter.BasculerFavoris();
            Man.AjouterElement(ElementAajouter);
            if(ElementAajouter is Evenement)
                Man.AjouterEvenementAHistoire(ElementAajouter as Evenement);
            AfficheBlockMessageInfo(Brushes.Green, "L'ajout à été effectué avec succès");           
        }

        private void AfficheBlockMessageInfo(Brush brushes, string message)
        {
            BlockMessageInfo.Text = message;
            BlockMessageInfo.Background = brushes;
            BlockMessageInfo.Visibility = Visibility.Visible;
        }

        private Element GetElementAajouter()
        {
            Element ElementAajouter = null;
            string[] séparation = BlockNom.Text.Split(" "); //sépare le nom en deux avec l'espace

            try
            {
                if (Personnage.IsChecked ?? false)
                {
                    if (séparation.Length < 2)
                        AfficheBlockMessageInfo(Brushes.Orange, "Merci de donner le nom suvi du prénom du personnage séparer par un espace");
                    else
                        ElementAajouter = new Personnage(séparation[0], séparation[1], BlockDescription.Text);
                }
                else if (Créature.IsChecked ?? false)
                {
                    ElementAajouter = new Creature(BlockNom.Text, BlockDescription.Text, Dangerosité.Sûr);
                }
                else //Evenement checked
                {
                    if (séparation.Length < 2)
                        AfficheBlockMessageInfo(Brushes.Orange, "Merci de donner le nom suivi du lieu de l'événement");
                    else
                        ElementAajouter = new Evenement(séparation[0], BlockDescription.Text, séparation[1]);
                }
            }
            catch (Exception excep)
            {
                AfficheBlockMessageInfo(Brushes.Red, excep.Message);
            }
            return ElementAajouter;
        }
    }
}
