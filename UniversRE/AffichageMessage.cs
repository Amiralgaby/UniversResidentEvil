using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace UniversRE
{
    public class AffichageMessage
    {
        /// <summary>
        /// Permet d'afficher un message dans une TextBlock
        /// </summary>
        /// <param name="textBlock">la TextBlock qui recevra le message</param>
        /// <param name="color">La couleur que prendra la TextBlock</param>
        /// <param name="message">Le message à afficher</param>
        public static void AffichageMessageInfo(ref TextBlock textBlock,Brush color,string message)
        {
            textBlock.Text = message;
            textBlock.Background = color;
            textBlock.Visibility = Visibility.Visible;
        } 
    }
}
