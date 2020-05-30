using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net;
using System.Text;
using System.Xml;

namespace MyLib
{
    public class Manager : INotifyPropertyChanged
    {
        private Element elementSelectionné; 
        
        public List<Evenement> Histoire = new List<Evenement>();
        private ObservableCollection<Element> mesElements = new ObservableCollection<Element>();

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Element> MesElements
        {
            get { return mesElements; }
            set { mesElements = value; }
        }

        public Element ElementSelectionné 
        { 
            get => elementSelectionné;
            set
            {
                if(elementSelectionné != value)
                {
                    elementSelectionné = value;
                    OnPropertyChanged(nameof(elementSelectionné));
                }
            }
        }
        

        void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(propertyName));
        //Fonction pour la liste d'éléments
        public void AjouterElement(Element e) => MesElements.Add(e);
        public bool SupprimerElement(Element e) { return MesElements.Remove(e); }
        public void ModifierElement(Element e, string nom, string description,bool favoris) => e.ModifierAttribut(nom, description, favoris);
        public void BasculerFavoris(Element e) => e.BasculerFavoris();

        //Fonctions pour l'histoire (la liste d'événement)
        public void AjouterEvenementAHistoire(Evenement ev) => Histoire.Add(ev);
        public void SupprimerEvenementAHistoire(Evenement ev) => Histoire.Remove(ev);
        public void ModifierEvenementAHistoire(Evenement ev, string lieu, DateTime date)
        {
            ev.ModifierLieu(lieu);
            ev.ModifierDate(date);
        }

        public void TrierLaListe() => Histoire.Sort();
        public List<Element> RechercherElementParNom(string nomAchercher)
        {
            List<Element> listRetourDeLaRecherche = new List<Element>();
            foreach(Element e in mesElements)
            {
                if(SimilaritéLevenshtein(e.Nom,nomAchercher) < 4)
                {
                    listRetourDeLaRecherche.Add(e);
                }
            }
            return listRetourDeLaRecherche;
        }

        private Int32 SimilaritéLevenshtein(String a, String b)
        {
            if (string.IsNullOrEmpty(a))
            {
                if (!string.IsNullOrEmpty(b))
                {
                    return b.Length;
                }
                return 0;
            }

            if (string.IsNullOrEmpty(b))
            {
                if (!string.IsNullOrEmpty(a))
                {
                    return a.Length;
                }
                return 0;
            }

            Int32 cost;
            Int32[,] d = new int[a.Length + 1, b.Length + 1];
            Int32 min1;
            Int32 min2;
            Int32 min3;

            for (Int32 i = 0; i <= d.GetUpperBound(0); i += 1)
            {
                d[i, 0] = i;
            }

            for (Int32 i = 0; i <= d.GetUpperBound(1); i += 1)
            {
                d[0, i] = i;
            }

            for (Int32 i = 1; i <= d.GetUpperBound(0); i += 1)
            {
                for (Int32 j = 1; j <= d.GetUpperBound(1); j += 1)
                {
                    cost = Convert.ToInt32(!(a[i - 1] == b[j - 1]));

                    min1 = d[i - 1, j] + 1;
                    min2 = d[i, j - 1] + 1;
                    min3 = d[i - 1, j - 1] + cost;
                    d[i, j] = Math.Min(Math.Min(min1, min2), min3);
                }
            }

            return d[d.GetUpperBound(0), d.GetUpperBound(1)];
        }

        public void ChargerLesDonnées()
        {
            AjouterElement(new Personnage("Valentine", "Jill", "Elle est experte dans le maniement des armes à feu, le crochetage de serrures et la neutralisation d'explosifs."));

            AjouterElement(new Personnage("Kennedy", "Leon Scott", "Leon semble être un jeune homme naïf avec un fort sens de la justice, et ayant pour priorité de venir en aide aux faibles."));

            AjouterElement(new Personnage("Redfield", "Claire", "Elle sait faire face à des situations imprévues grâce à une grande imagination, elle échafaude des plans extravagants mais qui sont généralement efficaces."));

            AjouterElement(new Personnage("Redfield", "Chris", "Chris Redfield a commencé sa carrière militaire en tant que pilote de l'US Air Force."));

            AjouterElement(new Personnage("Wong", "Ada", "Elle est une belle mercenaire américaine vraisemblablement d'origine chinoise, extrêmement habile en espionnage et redoutable au combat."));

            AjouterElement(new Personnage(" Aiken", "Richard", "Membre de l'équipe Bravo des S.T.A.R.S. Il agit en renfort de l'équipe. Il veille également sur la nouvelle recrue," +
                " Rebecca Chambers. Il fera tout ce qui est en son pouvoir pour protéger quelqu'un, allant même jusqu'à mettre sa vie en danger." + "" +
                " Il est empoisonné par un serpent géant (s'il est sauvé par le sérum il sera dévoré par le serpent géant). Par la suite," +
                " il sera dévoré par un requin en sauvant Chris Redfield dans le premier épisode de la série."));

            AjouterElement(new Personnage("Chambers", "Rebecca", "Membre de l'équipe Bravo des S.T.A.R.S., Rebecca est une experte en préparation et fabrication de médicaments et tient le rôle d'infirmière de l'équipe." +
                        "Après la séparation du reste de son équipe partie enquêter sur des meurtres, le crash de leur hélicoptère et l'ordre de capturer Billy Coen, elle rencontra ce dernier dans un train appelé l'Ecliptic Express." +
                        "Ils n'eurent pas d'autre choix que de faire équipe et d'affronter James Marcus. Rebecca se sépara de Billy et se dirige vers le manoir," +
                        " point de rendez-vous de l'équipe Bravo.Elle est aurai vécu dans le manoir dans RE1 et elle s'en sortira vivante avec Jill et Chris. Elle est la seule survivante de l'équipe bravo dans l'incident du manoir."));

            AjouterElement(new Personnage("Coen", "Billy", "Ancien sous-lieutenant des Corps des Marines, il a été condamné à mort pour assassinat à l'occasion de la mort de 23 personnes." +
                " Billy est capable de manier n'importe quelle arme. Endurci par l'entraînement au sein des Marines, il est en mesure d'affronter n'importe quel monstre." +
                " Il fera équipe avec Rebecca Chambers et une fois vaincu Marcus dans sa forme finale, on le revoit plus."));

            AjouterElement(new Personnage("Dewey", "Edward", "Membre de l'équipe Bravo des S.T.A.R.S., dont il assure la sécurité d'arrière-garde." +
                " Généralement pilote, il a été le copilote de Kevin Dooley lors de la mission dans la forêt de Raccoon City. Après le crash de l'appareil," +
                " il a découvert l'Ecliptic Express dont il a examiné l'intérieur. C'est à ce moment qu'il a été mordu par un Zombie, devenant ainsi la première victime de l'équipe avant de devenir lui-même un zombie."));

            AjouterElement(new Creature("Nemesis", "Le Nemesis-T Type (Nemesis-Tyrant Type) était une troisième génération d'armes biologique de type Tyran développée par le Sixième Laboratoire d'Umbrella Europe en France" +
                " sous la direction directe du Quartier Général d'Umbrella, à travers l'utilisation de l'organisme parasite artificiel « Type NE-α »," +
                " généralement appelé « Nemesis ». Son but était de prouver qu'une créature infectée par le Virus-T puisse avoir une intelligence supérieure," +
                " des capacités de combat et une plus grande capacité de suivre les ordres sans avoir besoin d'être dirigée constamment, manipulant ainsi une grande variété d'armes.",
                Dangerosité.Très_dangereux));

            AjouterElement(new Creature("T-00",
                "Le T-103, aussi appelé communément Mr. X, est l'un des antagonistes de Resident Evil 2 (1998) et Resident Evil 2 (2019). C'est une arme biologique de catégorie Tyran." +
                "Sa mission principale est de récupérer l'échantillon de Virus-G.",
                Dangerosité.Très_dangereux));

            AjouterElement(new Creature("Tyran", "Le Tyran est un boss classique de la saga Resident Evil. Il s'agit d'une série d'armes biologiques expérimentales et produites en série," +
                " développées par Umbrella Corporation pour servir de supers soldats potentiels. Les Tyrans sont forts et vigoureux, quoiqu'un peu lents." +
                " D'un jeu à l'autre, on retrouve généralement un modèle de Tyran différent.",
                Dangerosité.Boss));

            AjouterElement(new Creature("Plaga",
                "Contrairement au Virus-t, qui transformait ses victimes en zombies écervelés, les Plagas sont des parasites qui prennent le contrôle du système nerveux des hôtes dans lesquels ils sont implantés." +
                " Les personnes infectées par ce parasite (Ganado comme Majini) deviennent beaucoup plus fortes et très résistantes à la douleur, tout en travaillant collectivement à la poursuite de leurs objectifs." +
                "D'autres effets secondaires incluent la perte complète de raisonnement — sauf chez certains sujets (qui ne sont toutefois pas en mesure de résister à la nécessité d'obéir à des ordres supérieurs) — et la pleine conformité à l’espèce de Plaga dominante.",
                Dangerosité.Dangereux));
            
            
            ElementSelectionné = mesElements[0]; //Element sélectionné par défaut
        }
    }
}
