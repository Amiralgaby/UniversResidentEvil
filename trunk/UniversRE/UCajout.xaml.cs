﻿using MyLib;
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
            bool isChecked = BoxFavoris.IsChecked ?? false;
            try
            {
                Man.AjouterElement(new Element(BlockNom.Text, BlockDescription.Text, isChecked));
                AfficheBlockMessageErreur(Brushes.Green, "L'ajout à été effectué avec succès");
            }
            catch(Exception excep)
            {
                AfficheBlockMessageErreur(Brushes.Red, excep.Message);
            }            
        }

        private void AfficheBlockMessageErreur(Brush brushes, string message)
        {
            BlockMessageErreur.Text = message;
            BlockMessageErreur.Background = brushes;
            BlockMessageErreur.Visibility = Visibility.Visible;
        }
    }
}