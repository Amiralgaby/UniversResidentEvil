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
        public Manager Man { get; set; }
        public MainWindow()
        {
            Man = new Manager();
            Man.AjouterElement(new Element("Jean Bon", "L'homme le plus cool de l'univers"));
            Man.AjouterElement(new Element("Moldu", "Truc", true));
            Man.AjouterElement(new Element("Le dernier essai", "il n'a pas fait long feu", false));
            Man.AjouterElement(new Personnage("Chaplin", "Charlie", "un génie"));
            Man.AjouterElement(new Personnage("Tolvarld", "Linus", "un hacker"));
            Man.AjouterElement(new Personnage("PlaceholderName", "PlaceHolderPrenom", "c'est a supprimer"));

            
            DataContext = this;
            InitializeComponent();
        }

        private void Recherche_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        //public Manager man => (Application.Current as App).Manager;
    }
}
